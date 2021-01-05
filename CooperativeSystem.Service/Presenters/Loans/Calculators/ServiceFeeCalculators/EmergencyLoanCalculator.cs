using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.ServiceFeeCalculators
{
    internal class EmergencyLoanCalculator : ServiceFeeCalculatorTemplate
    {
        public EmergencyLoanCalculator(DataContext db, Member member)
            : base(db, member) { }

        internal override ServiceFees ComputeServiceFees(string paymentModeID, string loanDeductionTypeID, decimal loanAmount, int terms, ref decimal interestRate)
        {
            var loanDeductionType = Db.GetTable<LoanDeductionType>().Single(x => x.LoanDeductionTypeID == loanDeductionTypeID);
            var serviceRate = loanDeductionType.EmergencyLoanServiceRate;
            var multiples = loanAmount / serviceRate.MaximumAmount;

            var fees = new ServiceFees()
            {
                ServiceFee = multiples * serviceRate.ServiceFee,
                CollectionFee = multiples * serviceRate.CollectionFee,
                CapitalBuildup = multiples * serviceRate.CapitalBuildup,
                LoanGuaranteeFund = 0M,
                Interest = multiples * serviceRate.Interest
            };

            return fees;
        }
    }
}
