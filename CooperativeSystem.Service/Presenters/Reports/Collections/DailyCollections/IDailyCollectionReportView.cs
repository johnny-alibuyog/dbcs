using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Collections.DailyCollections
{
    public interface IDailyCollectionReportView
    {
        DateTime Date { get; set; }
        void PopulateReports(IList<DailyCollection> collections);
    }
}
