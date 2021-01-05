using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Presenters.Lookups.UserCategories;
using CooperativeSystem.Service.Presenters.Lookups.Roles;

namespace CooperativeSystem.Service.Models
{
    partial class User
    {
        private static readonly string _defaultPassword = "12345a$";

        public override string ToString()
        {
            return (LastName + ", " + FirstName + " " + MiddleName).Trim();
        }

        partial void OnCreated()
        {
            
            UserID = string.Empty;
            UserPassword = string.Empty;
            UserCategoryID = UserCategoryCodes.RegularUser;
            LastName = string.Empty;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            UserPassword = _defaultPassword;
        }

        public virtual IList<string> GetRoles()
        {
            return UsersRoles.Select(x => x.Role.Name).ToList();
        }

        public virtual bool IsAdministrator()
        {
            return this.UsersRoles.Any(x => x.Role.Name == RoleCodes.Administrator);
        }

        public virtual bool IsAdjuster()
        {
            return this.UsersRoles.Any(x => x.Role.Name == RoleCodes.Adjuster);
        }

        public virtual bool IsDisburser()
        {
            return this.UsersRoles.Any(x => x.Role.Name == RoleCodes.Disburser);
        }

        public virtual bool IsReceiver()
        {
            return this.UsersRoles.Any(x => x.Role.Name == RoleCodes.Receiver);
        }

        public virtual bool IsManager()
        {
            return this.UsersRoles.Any(x => x.Role.Name == RoleCodes.Manager);
        }
    }
}
