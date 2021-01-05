using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare
{
    public class DividendDistributionSummaryItem
    {
        public virtual string Member { get; set; }
        public virtual string Dipository { get; set; }
        public virtual string DistributionRemarks { get; set; }
        public virtual decimal Amount { get; set; }
    }
}
