using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.MaxLoanAmountCalculators
{
    internal class RegularLoanCalculator : MaxLoanAmountCalculatorTemplate
    {
        public RegularLoanCalculator(DataContext db, Member member)
            : base(db, member) { }

        internal override decimal ComputeMaxLoanAmount(out string remarks)
        {
            remarks = string.Empty;

            if (Member.CapitalShare == null)
            {
                remarks = "You do not have capital share.";
                return 0M;
            }

            // maximum loan amount is RegularLoanMaxPrecentage times current capital share
            var loanSetting = Db.GetTable<LoanSetting>().Single();
            var maxAmount = Member.CapitalShare.CurrentBalance * (loanSetting.RegularLoanMaxPrecentage / 100);
            if (maxAmount == 0M)
            {
                remarks = "You do not have loanable amount.";
                return 0M;
            }

            return maxAmount;
        }
    }
}
