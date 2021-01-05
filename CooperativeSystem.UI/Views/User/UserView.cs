using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Users;
using CooperativeSystem.UI.Views.Maintenance;

namespace CooperativeSystem.UI.Views.User
{
    public partial class UserView : DetailsFormTemplate, IUserView
    {
        private UserPresenter _presenter;

        public UserView()
        {
            InitializeComponent();

            _presenter = new UserPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

        }

        #region IUserView Members

        public string UserID
        {
            get { return _userIDTextBox.Text; }
            set { _userIDTextBox.Text = value; }
        }

        public string UserPassword
        {
            get { return _passwordTextBox.Text; }
            set { _passwordTextBox.Text = value; }
        }

        public string UserCategoryID
        {
            get { return _userCategoryComboBox.SelectedValue.ToString(); }
            set { _userCategoryComboBox.SelectedValue = value; }
        }

        public string UserCategoryName
        {
            get { return _userCategoryComboBox.Text; }
        }

        public string LastName
        {
            get { return _lastNameTextBox.Text; }
            set { _lastNameTextBox.Text = value; }
        }

        public string FirstName
        {
            get { return _firstNameTextBox.Text; }
            set { _firstNameTextBox.Text = value; }
        }

        public string MiddleName
        {
            get { return _middleNameTextBox.Text; }
            set { _middleNameTextBox.Text = value; }
        }

        public string PasswordConfirmation
        {
            get { return _passwordConfirmationTextBox.Text; }
            set { _passwordConfirmationTextBox.Text = value; }
        }

        public IList<string> Roles
        {
            get
            {
                return _rolesCheckedListBox.CheckedItems.Cast<Role>().Select(x => x.Name).ToList();
            }
            set
            {
                for (int i = 0; i < _rolesCheckedListBox.Items.Count; i++)
			    {
			        var item = _rolesCheckedListBox.Items[i];
                    var role = (Role)item;

                    if (value.Contains(role.Name))
                        _rolesCheckedListBox.SetItemCheckState(i, CheckState.Checked);
                    else
                        _rolesCheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
			    }
            }
        }

        public string FullName
        {
            get { return LastName + ", " + FirstName + " " + MiddleName; }
        }

        public void PopulateRolesPulldown(IList<Role> roles)
        {
            _rolesCheckedListBox.Items.Clear();

            foreach (var item in roles.OrderBy(x => x.Name))
                _rolesCheckedListBox.Items.Add(item);
        }

        public void PopulateUserCategoryPulldown(IList<UserCategory> userCategories)
        {
            _userCategoryComboBox.DataSource = userCategories;
            _userCategoryComboBox.ValueMember = "UserCategoryID";
            _userCategoryComboBox.DisplayMember = "UserCategoryName";
        }

        public void LoadUser(string userID)
        {
            _userIDTextBox.ReadOnly = true;
            _presenter.LoadUser(userID);
        }

        public void NewUser()
        {
            _userIDTextBox.ReadOnly = false;
            _presenter.NewUser();
        }

        #endregion

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ActionType == ActionType.Insert)
            {
                if (AskConfirmation(this, "Do you want to add new user?") == DialogResult.Yes)
                {
                    if (_presenter.Insert())
                    {
                        OnItemAdded(new EventArgs());
                        Close();
                    }
                }
            }
            else if (ActionType == ActionType.Update)
            {
                if (AskConfirmation(this, "Do you want to modify user information?") == DialogResult.Yes)
                {
                    if (_presenter.Update())
                    {
                        OnItemModified(new EventArgs());
                        Close();
                    }
                }
            }
            else if (ActionType == ActionType.Delete)
            {
                if (AskConfirmation(this, "Do you want to delete user?") == DialogResult.Yes)
                {
                    if (_presenter.Delete())
                    {
                        OnItemDeleted(new EventArgs());
                        Close();
                    }
                }
            }
        }
    }
}
