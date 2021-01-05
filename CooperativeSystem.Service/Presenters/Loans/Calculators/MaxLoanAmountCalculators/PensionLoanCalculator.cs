using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.MaxLoanAmountCalculators
{
    internal class PensionLoanCalculator : MaxLoanAmountCalculatorTemplate
    {
        public PensionLoanCalculator(DataContext db, Member member)
            : base(db, member) { }

        internal override decimal ComputeMaxLoanAmount(out string remarks)
        {
            var maxAmount = 0M;
            remarks = string.Empty;


            if (Member.PensionPlan == null)
            {
                remarks = "You do not have active pension plan.";
            }
            else
            {
                var receipts = Member.PensionPlan.PensionPlanReceipts.Sum(ppr => ppr.Amount);
                var disbursements = Member.PensionPlan.PensionPlanDisbursements.Sum(ppr => ppr.Amount);

                // maximum loan amount is 100% of current pension plan
                //maxAmount = receipts - (disbursements + OutstandingBalance);
                maxAmount = receipts - disbursements;
            }

            if (maxAmount == 0M && string.IsNullOrEmpty(remarks))
                remarks = "You do not have loanable amount.";

            return maxAmount;
        }
    }
}
