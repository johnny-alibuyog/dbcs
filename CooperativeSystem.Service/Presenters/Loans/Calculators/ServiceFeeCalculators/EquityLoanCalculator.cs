using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.ServiceFeeCalculators
{
    internal class EquityLoanCalculator : ServiceFeeCalculatorTemplate
    {
        public EquityLoanCalculator(DataContext db, Member member)
            : base(db, member) { }

        internal override ServiceFees ComputeServiceFees(string paymentModeID, string loanDeductionTypeID, decimal loanAmount, int terms, ref decimal interestRate)
        {
            var rates = Db.GetTable<LoanDeductionType>()
                .Where(ldt => ldt.LoanDeductionTypeID == loanDeductionTypeID)
                .Select(ldt => new 
                {
                    ServiceFeeRates = ldt.LoanServiceFeeRate,
                    CollectionFeeRates = ldt.LoanCollectionFeeRate,
                    CapitalBuildupRates = ldt.LoanCapitalBuildupRate,
                    LoanGuaranteeFundRates = ldt.LoanGuaranteeFundRate,
                    InterestRates = ldt.LoanInterestRates.Single(x => x.PaymentModeID == paymentModeID)
                })
                .Single();

            var serviceFeeRate = (terms < 6
                ? rates.ServiceFeeRates.OneToFiveMonths
                : rates.ServiceFeeRates.SixToTenMonths);
            var collectionFeeRate = (terms < 6
                ? rates.CollectionFeeRates.OneToFiveMonths
                : rates.CollectionFeeRates.SixToTenMonths);
            var capitalBuildupRate = (Member.CapitalShare.CurrentBalance < 15000M
                ? rates.CapitalBuildupRates.ShareBelowFifteenThousand
                : rates.CapitalBuildupRates.ShareFifteenThousandAndAbove);
            var loanGuaranteeFundRate = (terms < 6
                ? rates.LoanGuaranteeFundRates.OneToFiveMonths
                : rates.LoanGuaranteeFundRates.SixToTenMonths);
            if (interestRate == 0M)
                interestRate = rates.InterestRates.InterestRate;

            var fees = new ServiceFees()
            {
                ServiceFee = loanAmount * (serviceFeeRate / 100),
                CollectionFee = loanAmount * (collectionFeeRate / 100),
                CapitalBuildup = loanAmount < 5000M
                    ? rates.CapitalBuildupRates.BelowFiveThousand   // apply fixed amount Capital Build up if loan amount is below 5,000
                    : loanAmount * (capitalBuildupRate / 100),      // apply Capital Share based rate if loan amount is 5,000 and above
                LoanGuaranteeFund = 0M, // loanAmount * (loanGuaranteeFundRate / 100), there is no loan guarantee fund for Equity Loan
                Interest = loanAmount * terms * (interestRate / 100)
            };
            return fees;
        }
    }
}
