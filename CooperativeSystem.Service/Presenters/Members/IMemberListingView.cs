using System.Collections.Generic;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.Members
{
    public interface IMemberListingView
    {
        void PopulateListing(IList<MemberListingModel> modelList);
    }
}
