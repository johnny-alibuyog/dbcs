using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.ServiceFeeCalculators
{
    internal class PensionLoanCalculator : ServiceFeeCalculatorTemplate
    {
        public PensionLoanCalculator(DataContext db, Member member)
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
            var capitalBuildupRate = (loanAmount < 5000M
                ? rates.CapitalBuildupRates.BelowFiveThousand
                : rates.CapitalBuildupRates.FiveThousandAndAbove);
            var loanGuaranteeFundRate = (terms < 6
                ? rates.LoanGuaranteeFundRates.OneToFiveMonths
                : rates.LoanGuaranteeFundRates.SixToTenMonths);
            if (interestRate == 0M)
                interestRate = rates.InterestRates.InterestRate;

            var fees = new ServiceFees()
            {
                ServiceFee = loanAmount * (serviceFeeRate / 100),
                CollectionFee = loanAmount * (collectionFeeRate / 100),
                CapitalBuildup = loanAmount * (capitalBuildupRate / 100),
                LoanGuaranteeFund = 0M, // loanAmount * (loanGuaranteeFundRate / 100), there is not loan guarantee fund for Pension Loan
                Interest = loanAmount * terms * (interestRate / 100)
            };
            return fees;

        }
    }
}
