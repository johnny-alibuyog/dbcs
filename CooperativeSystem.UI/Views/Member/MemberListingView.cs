using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Models;
using CooperativeSystem.UI.Views.Utilities;
using CooperativeSystem.UI.Views.Maintenance;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Members;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.UI.Views.Member
{
    public partial class MemberListingView : ListingFormTemplate, IMemberListingView
    {
        private MemberListingPresenter _presenter;
        private MemberView _memberView;

        public MemberListingView()
        {
            InitializeComponent();

            _dataGridView.AutoGenerateColumns = false;
            _dataGridView.Columns.AddRange(
                new DataGridViewTextBoxColumn() { DataPropertyName = "AccountNumber", FillWeight = Width * .2F, HeaderText = "Account Number", ReadOnly = true },
                new DataGridViewTextBoxColumn() { DataPropertyName = "ApplicationDate", FillWeight = Width * .2F, HeaderText = "Date Applied", ReadOnly = true },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Name", FillWeight = Width * .3F, HeaderText = "Name", ReadOnly = true },
                new DataGridViewTextBoxColumn() { DataPropertyName = "MembershipCategory", FillWeight = Width * .3F, HeaderText = "Category", ReadOnly = true }
            );
            
            _presenter = new MemberListingPresenter(this);
            _presenter.Success += new SuccessHandler(NotifyInformation);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.PopulateListing();

            AddNewClick += new EventHandler(MemberListingView_AddNewClick);
            ModifyClick += new EventHandler(MemberListingView_ModifyClick);
            DeleteClick += new EventHandler(MemberListingView_DeleteClick);
            RefreshListClick += new EventHandler(MemberListingView_RefreshListClick);

            _memberView = new MemberView();
            _memberView.ItemAdded += new EventHandler(MemberView_ItemAdded);
            _memberView.ItemModified += new EventHandler(MemberView_ItemModified);
            _memberView.ItemDeleted += new EventHandler(MemberView_ItemDeleted);

            ListingModelType = typeof(MemberListingModel);
        }

        private void MemberListingView_AddNewClick(object sender, EventArgs e)
        {
            _memberView.ActionType = ActionType.Insert;
            _memberView.NewMember();
            _memberView.ShowDialog(this);
        }

        private void MemberListingView_ModifyClick(object sender, EventArgs e)
        {
            var memberID = ((MemberListingModel)CurrentItem).MemberID;

            _memberView.ActionType = ActionType.Update;
            _memberView.LoadMember(memberID);
            _memberView.ShowDialog(this);
        }

        private void MemberListingView_DeleteClick(object sender, EventArgs e)
        {
            var memberID = ((MemberListingModel)CurrentItem).MemberID;

            _memberView.ActionType = ActionType.Delete;
            _memberView.LoadMember(memberID);
            _memberView.ShowDialog(this);
        }

        private void MemberListingView_RefreshListClick(object sender, EventArgs e)
        {
            _presenter.PopulateListing();
        }

        private void MemberView_ItemAdded(object sender, EventArgs e)
        {
            var items = (SearchableSortableBindingList<MemberListingModel>)DataSource;
            var item = new MemberListingModel()
            {
                MemberID = _memberView.MemberID,
                AccountNumber = _memberView.AccountNumber,
                Name = _memberView.FullName,
                MembershipCategory = _memberView.MembershipCategoryName,
                ApplicationDate = _memberView.ApplicationDate
            };
            items.Add(item);
        }

        private void MemberView_ItemModified(object sender, EventArgs e)
        {
            var item = (MemberListingModel)CurrentItem;
            item.MemberID = _memberView.MemberID;
            item.AccountNumber = _memberView.AccountNumber;
            item.Name = _memberView.FullName;
            item.MembershipCategory = _memberView.MembershipCategoryName;
            item.ApplicationDate = _memberView.ApplicationDate;
        }

        private void MemberView_ItemDeleted(object sender, EventArgs e)
        {
            var items = (SearchableSortableBindingList<MemberListingModel>)DataSource;
            var item = (MemberListingModel)CurrentItem;
            items.Remove(item);
        }

        #region IMemberListingView Members

        public void PopulateListing(IList<MemberListingModel> modelList)
        {
            DataSource = new SearchableSortableBindingList<MemberListingModel>(modelList);
        }

        #endregion
    }
}