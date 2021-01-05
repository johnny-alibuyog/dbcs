using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Members;
using CooperativeSystem.UI.Views.Utilities;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.UI.Views.Member
{
    public delegate void MemberSelectedEventHandler(object sender, long memberID);    

    public partial class MemberInquiryListingView : FormTemplate, IMemberInquiryListingView
    {
        private MemberInquiryListingPresernter _presenter;
        public event MemberSelectedEventHandler MemberSelected;
        
        public MemberInquiryListingView()
        {
            InitializeComponent();

            _presenter = new MemberInquiryListingPresernter(this);

            _presenter.Success += new SuccessHandler(NotifyInformation);
            _presenter.Error += new ErrorHandler(NotifyError);

            _membersDataGridView.AutoGenerateColumns = false;
            _membersDataGridView.Columns.AddRange(
                new DataGridViewTextBoxColumn() { DataPropertyName = "AccountNumber", FillWeight = Width * .25F /* 65.9693F */ , HeaderText = "Account Number", ReadOnly = true },
                new DataGridViewTextBoxColumn() { DataPropertyName = "FullName", FillWeight = Width * .4F /* 137.0558F */, HeaderText = "Name", ReadOnly = true },
                new DataGridViewTextBoxColumn() { DataPropertyName = "MembershipCategoryName", FillWeight = Width * .35F /* 96.97487F */, HeaderText = "Category", ReadOnly = true });
        }

        #region IMemberInquiryListingView Members

        public long MemberID { get; set; }
        
        public string AccountNumber
        {
            get { return _accountNumberTextBox.Text; }
            set { _accountNumberTextBox.Text = value; }
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

        public string MembershipCategoryID
        {
            get 
            { 
                return _membershipCategoryComboBox.SelectedValue != null 
                    ? _membershipCategoryComboBox.SelectedValue.ToString() 
                    : string.Empty; 
            }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    _membershipCategoryComboBox.SelectedItem = null;
                else
                    _membershipCategoryComboBox.SelectedValue = value; 
            }
        }

        public int ResultCount
        {
            set { _resultCountToolStripStatusLabel.Text = value.ToString(); } 
        }
        
        public void PopulateMembershipCategory(IList<MembershipCategory> modelList)
        {
            _membershipCategoryComboBox.DataSource = modelList;
            _membershipCategoryComboBox.ValueMember = "MembershipCategoryID";
            _membershipCategoryComboBox.DisplayMember = "MembershipCategoryName";
        }

        public void PopulateListing(IList<MemberInquiryListingModel> modelList)
        {
            if (modelList != null)
                _membersDataGridView.DataSource = new SearchableSortableBindingList<MemberInquiryListingModel>(modelList);
            else
                _membersDataGridView.DataSource = new SearchableSortableBindingList<MemberInquiryListingModel>();
        }

        #endregion

        #region Routine Helpers

        private bool NotifyMemberSelected()
        {
            var row = _membersDataGridView.CurrentRow;
            var isThereSelected = (row != null);

            if (isThereSelected)
                OnMemberSelected(((MemberInquiryListingModel)row.DataBoundItem).MemberID);
            else
                NotifyError(this, "There is no item selected.");

            return isThereSelected;
        }

        protected virtual void OnMemberSelected(long memberID)
        {
            RaiseMemberSelectedEvent(this, memberID);
        }

        private void RaiseMemberSelectedEvent(object sender, long memberID)
        {
            if (MemberSelected != null)
                MemberSelected.Invoke(sender, memberID);
        }

        #endregion

        private void SearchButton_Click(object sender, EventArgs e)
        {
            _presenter.SearchMembers();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            _presenter.ClearCriteria();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (NotifyMemberSelected())
                Close();
        }

        private void MembersDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (NotifyMemberSelected())
                Close();
        }
    }
}
