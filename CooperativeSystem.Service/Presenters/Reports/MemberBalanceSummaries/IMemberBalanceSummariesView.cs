using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.Reports.MemberBalanceSummaries
{
    public interface IMemberBalanceSummariesView
    {
        string MembershipCategoryID { get; }
        FilterType FilterType { get; }
        string SelectedAccountNumber { get; set; }
        void PopulateMemberLookup(List<MemberLookupModel> members);
        void PopulateReports(IList<MemberBalanceSummaryItem> balanceSummaries, string membershipCategory);
    }
}
