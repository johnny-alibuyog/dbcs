using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.CashFlows.YearlyCashFlows
{
    public interface IYearlyCashFlowReportView
    {
        DateTime Date { get; set; }
        void PopulateReports(IList<YearlyCashFlow> cashFlows);
    }
}
