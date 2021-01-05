using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Adjustments.DailyAdjustments
{
    public interface IDailyAdjustmentReportView
    {
        DateTime Date { get; set; }
        void PopulateReports(IList<DailyAdjustment> adjustments);
    }
}