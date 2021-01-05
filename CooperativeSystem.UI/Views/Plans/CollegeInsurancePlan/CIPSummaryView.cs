using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Lookups.PaymentModes;
using CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan;
using CooperativeSystem.UI.Views.Utilities;

namespace CooperativeSystem.UI.Views.Plans.CollegeInsurancePlan
{
    public partial class CIPSummaryView : SummaryTemplate, ICIPSummaryView
    {
        private CIPSummaryPresenter _presenter;
        private CIPEnrollmentView _enrollmentView;

        public CIPSummaryView()
        {
            InitializeComponent();

            _collegeInsurancePlansDataGridView.AutoGenerateColumns = false;
            _receiptsDataGridView.AutoGenerateColumns = false;

            _enrollmentView = new CIPEnrollmentView();

            _presenter = new CIPSummaryPresenter(this, _enrollmentView);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        #region Routine Helpers

        private CIPModel GetCurrentItem()
        {
            CIPModel currentItem = null;
            var currentRow = _collegeInsurancePlansDataGridView.CurrentRow;
            if (currentRow != null)
                currentItem = (CIPModel)currentRow.DataBoundItem;
            return currentItem;
        }

        #endregion

        #region SummaryTemplate Members

        public bool IsSummaryLoaded { get; set; }

        public void LoadSummary(long memberID)
        {
            if (IsSummaryLoaded)
                return;

            if (!_presenter.LoadPulldownValues())
                return;

            if (!_presenter.Load(memberID))
                return;

            MemberID = memberID;
            IsSummaryLoaded = true; 
        }

        public void ClearSummary()
        {
            _presenter.Clear();
            IsSummaryLoaded = false;
            MemberID = 0L;
        }

        #endregion

        #region ICIPSummaryView Members

        public long MemberID { get; set; }

        public IList<CIPModel> CollegeInsurancePlans
        {
            get 
            {
                return _collegeInsurancePlansDataGridView.DataSource as IList<CIPModel>; 
            }
            set
            {
                //_collegeInsurancePlansDataGridView.DataSource = value;
                _collegeInsurancePlansDataGridView.DataSource = (value != null)
                    ? new SearchableSortableBindingList<CIPModel>(value)
                    : new SearchableSortableBindingList<CIPModel>();
            }
        }

        public IList<TransactionModel> Receipts
        {
            get 
            {
                return (IList<TransactionModel>)_receiptsDataGridView.DataSource; 
            }
            set
            {
                //_receiptsDataGridView.DataSource = value;
                _receiptsDataGridView.DataSource = (value != null)
                    ? new SearchableSortableBindingList<TransactionModel>(value)
                    : new SearchableSortableBindingList<TransactionModel>();
            }
        }

        public decimal? TotalBalance
        {
            set { _totalBalanceTextBox.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public string UserName
        {
            set { _userNameLabel.Text = value; }
        }

        public DateTime? DateOfBirth
        {
            set { _dateOfBirthLabel.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
        }

        public string Relation
        {
            set { _relationLabel.Text = value; }
        }

        public string Address
        {
            set { _addressLabel.Text = value; }
        }

        public DateTime? ApplicationDate
        {
            set { _applicationDateLabel.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
        }

        public DateTime? PaymentCompletionDate
        {
            set { _paymentCompletionDateLabel.Text = value != null ? value.Value.ToShortDateString() : string.Empty; } 
        }

        public DateTime? MaturityDate
        {
            set { _maturityDateLabel.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
        }

        public string PaymentMode
        {
            set { _paymentModeLabel.Text = value; }
        }

        public int? Terms
        {
            set { _termsLabel.Text = value != null ? value.Value.ToString() : string.Empty; }
        }

        public int? AgingPeriod
        {
            set { _agingPeriodLabel.Text = value != null ? value.Value.ToString() : string.Empty; }
        }

        public decimal? Amortization
        {
            set { _amortizationLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public decimal? PaymentCompletionAmount
        {
            set { _maturityAmountLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public decimal? AwardAmount
        {
            set { _awardAmountLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        #endregion

        private void ActionButton_Click(object sender, EventArgs e)
        {
            if (!IsSummaryLoaded)
            {
                NotifyError(this, "You did not perform member inquiry. Please select a member first.");
                return;
            }

            if (sender == _enrollButton)
            {
                if (!_presenter.CheckQualification())
                    return;

                _enrollmentView.SetAction(CIPAction.Enroll);
                _enrollmentView.ShowDialog(this);
            }
            else if (sender == _modifyButton)
            {
                var item = GetCurrentItem();
                if (item == null)
                    return;

                _enrollmentView.SetAction(CIPAction.Modify, item.CollegeInsurancePlanID);
                _enrollmentView.ShowDialog(this);
            }
        }

        private void CollegeInsurancePlansDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var item = GetCurrentItem();
            if (item != null)
                _presenter.DisplayPlanDetails(item.CollegeInsurancePlanID);
        }
    }
}
