using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Users
{
    public class ManagerApprovalPresenter : PresenterTemplate
    {
        private readonly IManagerApprovalView _view;

        public ManagerApprovalPresenter(IManagerApprovalView view)
        {
            _view = view;
        }

        public virtual bool Execute()
        {
            try
            {
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    var loadOptions = new DataLoadOptions();
                    loadOptions.LoadWith<User>(x => x.UsersRoles);
                    loadOptions.LoadWith<UsersRole>(x => x.Role);

                    db.LoadOptions = loadOptions;

                    var user = db.GetTable<User>()
                        .Where(x =>
                            x.UserID == _view.UserID &&
                            x.UserPassword == _view.Password
                        )
                        .FirstOrDefault();

                    if (user == null)
                        throw new Exception("Invalid credentials.");

                    if (!user.IsManager())
                        throw new Exception("Approver is not manager.");
                }
                return true;
            }
            catch (Exception ex)
            {
                this.RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }
    }
}
