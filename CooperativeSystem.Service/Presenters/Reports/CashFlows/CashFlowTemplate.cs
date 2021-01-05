using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.CashFlows
{
    public abstract class CashFlowTemplate
    {
        public virtual decimal TotalCollection { get; set; }
        public virtual decimal TotalDisbursement { get; set; }
        public virtual decimal TotalBalance { get { return TotalCollection - TotalDisbursement; } }
    }
}
