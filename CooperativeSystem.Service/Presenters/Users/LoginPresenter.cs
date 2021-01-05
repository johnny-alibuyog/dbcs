using System;
using System.Data.Linq;
using System.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.Services;

namespace CooperativeSystem.Service.Presenters.Users
{
    public class LoginPresenter : PresenterTemplate
    {
        private DataContext _db;

        private IRepository<Models.User> _userRepository;
        private IRepository<Models.Application> _applicationRepository;
        private User _user;
        private Application _application;

        private ILoginView _view;

        public LoginPresenter(ILoginView view)
        {
            var loadOptions = new DataLoadOptions();
            loadOptions.LoadWith<User>(x => x.UserCategory);
            loadOptions.LoadWith<User>(x => x.UsersRoles);
            loadOptions.LoadWith<UsersRole>(x => x.Role);

            _db = new DataContextFactory().CreateDataContext();
            _db.LoadOptions = loadOptions;

            _userRepository = new GenericRepository<Models.User>(_db);
            _applicationRepository = new GenericRepository<Models.Application>(_db);

            _user = new User();
            _view = view;
        }

        public bool Login()
        {
            //var db = new DataContextFactory().CreateDataContext();
            //var query = db.GetTable<Member>().Where(m => m.AccountNumber == "1112").Single().Loans
            //    .Where(l =>
            //        l.Settled == false &&
            //        l.DueDate.AddDays(l.PaymentMode.GracePeriod) > DateTime.Now);
            //var query1 = db.GetTable<Loan>().Where(l => l.AccountNumber == "1112");
            //var query2 = query1
            //    .Where(l =>
            //        l.Settled == false &&
            //        l.DueDate.AddDays(l.PaymentMode.GracePeriod) > DateTime.Now);

            if (!ValidateExpiration())
                return false;

            if (!ValidateCredentials())
                return false;

            return true;
        }

        public bool ChagePassword()
        {
            try
            {
                if (!ValidateCredentials())
                    return false;

                if (_view.NewPassword != _view.NewPasswordConfirmation)
                {
                    RaiseErrorEvent("New password does not match with password confirmation.");
                    return false;
                }

                _user.UserPassword = _view.NewPassword;
                _userRepository.SaveAll();
                RaiseSusccessEvent("Password successfully changed.");
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message);
                return false;
            }
        }

        private bool ValidateCredentials()
        {
            _user = _userRepository.GetEntity(u => u.UserID == _view.UserID);

            if (_user == null)
            {
                RaiseErrorEvent(string.Format("UserID does not exist."));
                return false;
            }

            if (_user.UserPassword != _view.Password)
            {
                RaiseErrorEvent("You have entered incorrect password.");
                return false;
            }

            return true;
        }

        private bool ValidateExpiration()
        {
            _application = _applicationRepository.GetEntity();

            if (_application == null)
                return true;

            if (_application.ExpirationDate == null)
                return true;

            if ((_application.ExpirationDate.Value - DateTime.Today).Days > 15)
                return true;

            if (_application.ExpirationDate.Value > DateTime.Today)
            {
                RaiseSusccessEvent(string.Format("Your application registration will expire on {0}.", DateTime.Today.ToShortDateString()));
                return true;
            }

            RaiseErrorEvent("You application has already expired. Please contact the vendor.");
            return false;
        }

        public User GetUser()
        {
            return _user;
        }

        public Application GetApplication()
        {
            return _application;
        }
    }
}
