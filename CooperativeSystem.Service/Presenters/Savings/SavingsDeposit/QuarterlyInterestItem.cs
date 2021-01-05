using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.SavingsDeposit
{
    public class QuarterlyInterestItem
    {
        public virtual string Member { get; set; }
        public virtual string Month { get; set; }
        public virtual decimal AverageMonthlyBalance { get; set; }
        public virtual decimal LowestAverageMonthlyBalance { get; set; }
        public virtual decimal InterestRate { get; set; }
        public virtual decimal Interest { get; set; }
    }
}
