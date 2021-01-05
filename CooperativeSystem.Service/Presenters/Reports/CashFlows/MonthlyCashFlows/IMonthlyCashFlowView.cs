using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.CashFlows.MonthlyCashFlows
{
    public interface IMonthlyCashFlowView
    {
        DateTime Date { get; set; }
        void PopulateReports(IList<MonthlyCashFlow> cashFlows);
    }
}
