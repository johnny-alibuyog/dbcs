using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Sandbox.Models.QuarterlyInterestModels
{
    public class SavingsDeposit
    {
        public virtual DateTime Date { get; set; }
        public virtual decimal Amount { get; set; }
    }
}
