using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.ServiceFeeCalculators
{
    internal class EasyLoanCalculator : ServiceFeeCalculatorTemplate
    {
        public EasyLoanCalculator(DataContext db, Member member)
            : base(db, member) { }

        internal override ServiceFees ComputeServiceFees(string paymentModeID, string loanDeductionTypeID, decimal loanAmount, int terms, ref decimal interestRate)
        {
            var ldt = Db.GetTable<LoanDeductionType>().Single(x => x.LoanDeductionTypeID == loanDeductionTypeID);
            var sr = ldt.EasyLoanServiceRate;
            //var fees = new ServiceFees()
            //{
            //    ServiceFee = sr.ServiceFee,
            //    CollectionFee = sr.CollectionFee,
            //    CapitalBuildup = sr.CapitalBuildup,
            //    LoanGuaranteeFund = 0M,
            //    Interest = sr.Interest
            //};
            // this should be apply as rates
            var fees = new ServiceFees()
            {
                ServiceFee = loanAmount * (sr.ServiceFee / 100),
                CollectionFee = loanAmount * (sr.CollectionFee / 100),
                CapitalBuildup = loanAmount * (sr.CapitalBuildup / 100),
                LoanGuaranteeFund = 0M,
                Interest = loanAmount * terms * (sr.Interest / 100)
            };

            return fees;
        }
    }
}
