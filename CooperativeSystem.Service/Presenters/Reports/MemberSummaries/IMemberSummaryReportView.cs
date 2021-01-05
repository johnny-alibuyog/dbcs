using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.MemberSummaries
{
    public interface IMemberSummaryReportView
    {
        void PopulateReports(IList<MemberSummaryItem> members);
    }
}
