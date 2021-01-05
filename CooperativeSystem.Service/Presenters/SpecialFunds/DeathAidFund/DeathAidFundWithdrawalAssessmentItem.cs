using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.SpecialFunds.DeathAidFund
{
    public class DeathAidFundWithdrawalAssessmentItem
    {
        public virtual string Member { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual decimal ConsumableAmount { get; set; }
    }
}
