using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Lookups.MembershipCategories;
using CooperativeSystem.Service.Presenters.Reports;
using CooperativeSystem.Service.Presenters.Reports.IndividualLedgersRevision;

namespace CooperativeSystem.UI.Views.Reports.IndividualLedgersRevision
{
    public partial class IndividualLedgerRevisionView : FormTemplate, IIndividualLedgerRevisionView
    {
        private IndividualLedgerRevisionPresenter _presenter;

        public IndividualLedgerRevisionView()
        {
            InitializeComponent();

            _presenter = new IndividualLedgerRevisionPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        #region IIndividualLedgerRevisionView Members
        
        public string MembershipCategoryID
        {
            get
            {
                var membershipCategoryID = MembershipCategoryCodes.Regular;
                if (_associateRadioButton.Checked)
                    membershipCategoryID = MembershipCategoryCodes.Associate;
                else if (_juniorSaverRadioButton.Checked)
                    membershipCategoryID = MembershipCategoryCodes.JuniorSaver;
                else if (_regularRadioButton.Checked)
                    membershipCategoryID = MembershipCategoryCodes.Regular;
                return membershipCategoryID;
            }
        }

        public FilterType FilterType
        {
            get
            {
                var filterType = FilterType.AllMembers;
                if (_allMembersRadioButton.Checked)
                    filterType = FilterType.AllMembers;
                else if (_byMemberRadioButton.Checked)
                    filterType = FilterType.ByMember;
                return filterType;
            }
        }

        public string SelectedAccountNumber
        {
            get
            {
                var item = _memberComboBox.SelectedItem as MemberLookupModel;
                return (item != null) ? item.AccountNumber : string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _memberComboBox.SelectedIndex = -1;
                else
                    _memberComboBox.SelectedValue = value;
            }
        }

        public void PopulateMemberLookup(IList<MemberLookupModel> members)
        {
            _memberComboBox.DataSource = members;
            _memberComboBox.DisplayMember = "Name";
            _memberComboBox.ValueMember = "AccountNumber";
        }

        public void PopulateReports(IList<Account> accounts, string membershipCategory)
        {
            try
            {
                using (var view = new IndividualLedgerRevisionReportView())
                {
                    view.Date = DateTime.Today;
                    view.MembershipCategory = membershipCategory;
                    view.Accounts = accounts;
                    view.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }
        
        #endregion

        private void MembershipCategoryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                _presenter.PopulateMemberLookup();
        }

        private void FilterTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _byMemberGroupBox.Enabled = _byMemberRadioButton.Checked;
            if (_byMemberGroupBox.Enabled == false)
                SelectedAccountNumber = null;
        }

        private void IndividualLedgerView_Shown(object sender, EventArgs e)
        {
            _associateRadioButton.Checked = true;
            _allMembersRadioButton.Checked = true;
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            _presenter.PopulateReports();
        }

    }
}
