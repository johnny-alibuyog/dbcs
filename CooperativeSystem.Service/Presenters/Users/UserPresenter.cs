using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Users
{
    public class UserPresenter : PresenterTemplate
    {
        private IUserView _view;

        #region Routine Helpers

        private bool ValidatePasswordConfirmation(out string remarks)
        {
            remarks = string.Empty;
            var result = (_view.UserPassword == _view.PasswordConfirmation);
            if (!result)
                remarks = "Password nofirmation does not match your password.";
            return result;
        }

        private void InitializePersistenceManager()
        {
            using (var db = new DataContextFactory().CreateDataContext())
            {
                var roles = db.GetTable<Role>().ToList();
                var categories = db.GetTable<UserCategory>().ToList();

                _view.PopulateRolesPulldown(roles);
                _view.PopulateUserCategoryPulldown(categories);
            }
        }

        private void SetValuesToModel(User entity, IUserView value, DataContext db)
        {
            var roles = db.GetTable<Role>().ToList();

            if (string.IsNullOrWhiteSpace(entity.UserID))
                entity.UserID = value.UserID;

            entity.UserPassword = value.UserPassword;
            entity.UserCategoryID = value.UserCategoryID;
            entity.LastName = value.LastName;
            entity.FirstName = value.FirstName;
            entity.MiddleName = value.MiddleName;
            entity.UsersRoles.Clear();
            foreach (var roleName in _view.Roles)
            {
                entity.UsersRoles.Add(new UsersRole()
                {
                    User = entity,
                    Role = roles.FirstOrDefault(x => x.Name == roleName)
                });
            }
        }

        private void SetValuesToView(IUserView view, User value)
        {
            view.UserID = value.UserID;
            view.UserPassword = value.UserPassword;
            view.PasswordConfirmation = value.UserPassword;
            view.UserCategoryID = value.UserCategoryID;
            view.LastName = value.LastName;
            view.FirstName = value.FirstName;
            view.MiddleName = value.MiddleName;
            view.Roles = value.UsersRoles.Select(x => x.Role.Name).ToList();
        }

        private void InitializeViewValue(IUserView view)
        {
            view.UserID = string.Empty;
            view.UserPassword = string.Empty;
            view.UserCategoryID = string.Empty;
            view.LastName = string.Empty;
            view.FirstName = string.Empty;
            view.MiddleName = string.Empty;
            view.PasswordConfirmation = string.Empty;
            view.Roles = new List<string>();
        }

        #endregion

        public UserPresenter(IUserView view)
        {
            _view = view;
            InitializePersistenceManager();
        }

        public bool NewUser()
        {
            bool result = false;
            try
            {
                InitializeViewValue(_view);
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
            return result;
        }

        public bool LoadUser(string userID)
        {
            bool result = false;
            try
            {
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    var user = db.GetTable<User>().FirstOrDefault(x => x.UserID == userID);
                    SetValuesToView(_view, user);
                }

                result = true;

                //InitializePersistenceManager();
                //_model = _repository.GetEntity(u => u.UserID == userID);
                //SetValuesToView(_view, _model);
                //result = true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
            return result;
        }

        public bool Insert()
        {
            bool result = false;
            try
            {
                var remarks = string.Empty;
                if (ValidatePasswordConfirmation(out remarks))
                {
                    using (var db = new DataContextFactory().CreateDataContext())
                    {
                        var user = new User();
                        SetValuesToModel(user, _view, db);
                        db.GetTable<User>().InsertOnSubmit(user);
                        db.SubmitChanges();
                    }
                    RaiseSusccessEvent("Successful saving.");
                    result = true;
                }
                else
                {
                    RaiseErrorEvent(remarks);
                    result = false;
                }
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
            return result;
        }

        public bool Update()
        {
            bool result = false;
            try
            {
                var remarks = string.Empty;
                if (ValidatePasswordConfirmation(out remarks))
                {
                    using (var db = new DataContextFactory().CreateDataContext())
                    {
                        var user = db.GetTable<User>().FirstOrDefault(x => x.UserID == _view.UserID);
                        SetValuesToModel(user, _view, db);
                        db.SubmitChanges();
                    }
                    RaiseSusccessEvent("Successful saving.");
                    result = true;
                }
                else
                {
                    RaiseErrorEvent(remarks);
                    result = false;
                }
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
            return result;
        }

        public bool Delete()
        {
            bool result = false;
            try
            {
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    var user = db.GetTable<User>().FirstOrDefault(x => x.UserID == _view.UserID);
                    db.GetTable<User>().DeleteOnSubmit(user);
                    db.SubmitChanges();
                }
                RaiseSusccessEvent("Successful deleting.");
                result = true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
            return result;
        }
    }
}
