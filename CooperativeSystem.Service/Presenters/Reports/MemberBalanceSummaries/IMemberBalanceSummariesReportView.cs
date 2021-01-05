using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.MemberBalanceSummaries
{
    public interface IMemberBalanceSummariesReportView
    {
        DateTime Date { get; set; }
        string MembershipCategory { get; set; }
        IList<MemberBalanceSummaryItem> BalanceSummaries { get; set; }
    }
}
