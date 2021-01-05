using System.Collections.Generic;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Users
{
    public interface IUserView
    {
        string UserID { get; set; }
        string UserPassword { get; set; }
        string UserCategoryID { get; set; }
        string UserCategoryName { get; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string PasswordConfirmation { get; set; }
        IList<string> Roles { get; set; }
        string FullName { get; }

        void PopulateRolesPulldown(IList<Role> roles);
        void PopulateUserCategoryPulldown(IList<UserCategory> userCategories);

        void NewUser();
        void LoadUser(string userID);
    }
}
