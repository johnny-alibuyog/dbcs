using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.SavingsDeposit
{
    public class QuarterlyInterestComputationItem
    {
        public virtual string Member { get; set; }
        public virtual string FirstMonthName { get; set; }
        public virtual string SecondMonthName { get; set; }
        public virtual string ThirdMonthName { get; set; }
        public virtual decimal FirstMonthAMB { get; set; }
        public virtual decimal SecondMonthAMB { get; set; }
        public virtual decimal ThirdMonthAMB { get; set; }
        public virtual decimal LowestAverageMonthlyBalance { get; set; }
        public virtual decimal InterestRate { get; set; }
        public virtual decimal Interest { get; set; }
    }
}
