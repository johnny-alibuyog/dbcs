using System.Collections.Generic;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.Users
{
    public interface IUserListingView
    {
        void PopulateListing(IList<UserListingModel> modelList);
    }
}
