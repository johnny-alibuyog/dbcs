using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Adjustments.YearlyAdjustments
{
    public interface IYearlyAdjustmentReportView
    {
        DateTime Date { get; set; }
        void PopulateReports(IList<YearlyAdjustment> adjustments);
    }
}
