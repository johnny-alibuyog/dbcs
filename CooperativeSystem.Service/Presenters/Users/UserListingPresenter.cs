using System;
using System.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.Users
{
    public class UserListingPresenter : PresenterTemplate
    {
        private IUserListingView _view;

        public UserListingPresenter(IUserListingView view)
        {
            _view = view;
        }

        public bool PopulateListing()
        {
            bool result = false;
            try
            {
                var repository = new GenericRepository<User>();
                var users = repository.GetAll()
                    .Select( u => new UserListingModel()
                    {
                        UserID = u.UserID,
                        Name = string.Format("{0}, {1} {2}", u.LastName, u.FirstName, u.MiddleName),
                        UserCategoryName = u.UserCategory.UserCategoryName
                    })
                    .ToList();

                _view.PopulateListing(users);
                result = true;
            }
            catch(Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
            return result;
        }
    }
}
