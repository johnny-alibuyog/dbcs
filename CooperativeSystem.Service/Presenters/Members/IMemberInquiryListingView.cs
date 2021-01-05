using System.Collections.Generic;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Members
{
    public interface IMemberInquiryListingView
    {
        long MemberID { get; set; }
        string AccountNumber { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string MembershipCategoryID { get; set; }
        int ResultCount { set; }

        void PopulateMembershipCategory(IList<MembershipCategory> modelList);
        void PopulateListing(IList<MemberInquiryListingModel> modelList);
    }
}
