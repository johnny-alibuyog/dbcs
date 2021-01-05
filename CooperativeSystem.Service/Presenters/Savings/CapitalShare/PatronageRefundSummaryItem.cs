using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare
{
    public class PatronageRefundSummaryItem
    {
        public virtual string Member { get; set; }
        public virtual decimal Amount { get; set; }
    }
}
