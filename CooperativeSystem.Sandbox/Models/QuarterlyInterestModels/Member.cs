using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Sandbox.Models.QuarterlyInterestModels
{
    public class Member
    {
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual IList<SavingsDeposit> SavingsDeposits { get; set; }

        public override string ToString()
        {
            return LastName + ", " + FirstName + " " + MiddleName;
        }
    }
}
