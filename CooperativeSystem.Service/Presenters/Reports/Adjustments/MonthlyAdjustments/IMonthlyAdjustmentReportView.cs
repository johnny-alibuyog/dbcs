using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Adjustments.MonthlyAdjustments
{
    public interface IMonthlyAdjustmentReportView
    {
        DateTime Date { get; set; }
        void PopulateReports(IList<MonthlyAdjustment> adjustments);
    }
}
