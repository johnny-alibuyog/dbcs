using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.CashFlows.MonthlyCashFlows
{
    public class MonthlyCashFlow : CashFlowTemplate
    {
        public virtual int Day { get; set; }
    }
}
