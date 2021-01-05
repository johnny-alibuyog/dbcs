using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.CashFlows.YearlyCashFlows
{
    public class YearlyCashFlow : CashFlowTemplate
    {
        public virtual string Month { get; set; }
    }
}
