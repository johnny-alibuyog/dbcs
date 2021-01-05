using System;
using System.Collections.Generic;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Users;
using CooperativeSystem.UI.Views.Maintenance;
using CooperativeSystem.UI.Views.Utilities;

namespace CooperativeSystem.UI.Views.User
{
    public partial class UserListingView : ListingFormTemplate, IUserListingView
    {
        private UserListingPresenter _presenter;
        private UserView _userView;

        public UserListingView()
        {
            InitializeComponent();

            _presenter = new UserListingPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            _presenter.PopulateListing();

            AddNewClick += new EventHandler(UserListingView_AddNewClick);
            ModifyClick += new EventHandler(UserListingView_ModifyClick);
            DeleteClick += new EventHandler(UserListingView_DeleteClick);
            RefreshListClick += new EventHandler(UserListingView_RefreshListClick);

            _userView = new UserView();
            _userView.ItemAdded += new EventHandler(UserView_ItemAdded);
            _userView.ItemModified += new EventHandler(UserView_ItemModified);
            _userView.ItemDeleted += new EventHandler(UserView_ItemDeleted);

            ListingModelType = typeof(UserListingModel);
        }

        private void UserListingView_AddNewClick(object sender, EventArgs e)
        {
            _userView.ActionType = ActionType.Insert;
            _userView.NewUser();
            _userView.ShowDialog(this);
            
        }

        private void UserListingView_ModifyClick(object sender, EventArgs e)
        {
            var userID = ((UserListingModel)CurrentItem).UserID;

            _userView.ActionType = ActionType.Update;
            _userView.LoadUser(userID);
            _userView.ShowDialog(this);
        }

        private void UserListingView_DeleteClick(object sender, EventArgs e)
        {
            var userID = ((UserListingModel)CurrentItem).UserID;

            _userView.ActionType = ActionType.Delete;
            _userView.LoadUser(userID);
            _userView.ShowDialog(this);
        }

        private void UserListingView_RefreshListClick(object sender, EventArgs e)
        {
            _presenter.PopulateListing();
        }

        private void UserView_ItemAdded(object sender, EventArgs e)
        {
            var items = (SearchableSortableBindingList<UserListingModel>)DataSource;
            var item = new UserListingModel()
            {
                UserID = _userView.UserID,
                Name = _userView.FullName,
                UserCategoryName = _userView.UserCategoryName
            };
            items.Add(item);
            _dataGridView.Refresh();
        }

        private void UserView_ItemModified(object sender, EventArgs e)
        {
            var item = (UserListingModel)CurrentItem;
            item.UserID = _userView.UserID;
            item.Name = _userView.FullName;
            item.UserCategoryName = _userView.UserCategoryName;
            _dataGridView.Refresh();
        }

        private void UserView_ItemDeleted(object sender, EventArgs e)
        {
            var items = (SearchableSortableBindingList<UserListingModel>)DataSource;
            var item = (UserListingModel)CurrentItem;
            items.Remove(item);
            _dataGridView.Refresh();
        }

        #region IUserListingView Members

        public void PopulateListing(IList<UserListingModel> modelList)
        {
            DataSource = new SearchableSortableBindingList<UserListingModel>(modelList);
        }

        #endregion
    }
}
