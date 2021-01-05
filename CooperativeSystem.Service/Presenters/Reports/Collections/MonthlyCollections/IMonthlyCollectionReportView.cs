using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Collections.MonthlyCollections
{
    public interface IMonthlyCollectionReportView
    {
        DateTime Date { get; set; }
        void PopulateReports(IList<MonthlyCollection> collections);
    }
}
