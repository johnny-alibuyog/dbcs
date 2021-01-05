using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Collections.YearlyCollections
{
    public interface IYearlyCollectionReportView
    {
        DateTime Date { get; set; }
        void PopulateReports(IList<YearlyCollection> collections);
    }
}
