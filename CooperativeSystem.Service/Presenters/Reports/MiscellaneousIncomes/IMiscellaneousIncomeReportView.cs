using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.MiscellaneousIncomes
{
    public interface IMiscellaneousIncomeReportView
    {
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
        MiscellaneousIncomeType Type { get; set; }
        void PopulateTypePulldown(IList<MiscellaneousIncomeType> items);
        void PopulateReport(IList<MiscellaneousIncomeItem> items);
    }
}
