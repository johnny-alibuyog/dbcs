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
using CooperativeSystem.Service.Presenters.Plans.PensionPlan;

namespace CooperativeSystem.UI.Views.Plans.PensionPlan
{
    public partial class PensionPlanSummaryView : SummaryTemplate, IPensionPlanSummaryView
    {
        private PensionPlanSummaryPresenter _presenter;
        private long _memberID;
        private Nullable<bool> _hasEnrolled;

        public PensionPlanSummaryView()
        {
            InitializeComponent();

            _transactionDetailsDataGridView.AutoGenerateColumns = false;

            _presenter = new PensionPlanSummaryPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        #region IPensionPlanSummaryView Members

        public bool? HasEnrolled
        {
            get
            {
                return _hasEnrolled;
            }
            set
            {
                _hasEnrolled = value;
                if (_hasEnrolled != null)
                {
                    _enrollButton.Enabled = !_hasEnrolled.Value;
                    _setAvailOptionButton.Enabled = _hasEnrolled.Value;
                }
                else
                {
                    _enrollButton.Enabled = false;
                    _setAvailOptionButton.Enabled = false;
                }
            }
        }

        public IList<TransactionDetail> TransactionDetails
        {
            set { _transactionDetailsDataGridView.DataSource = value; }
        }

        public decimal? TotalBalance
        {
            set { _totalBalanceTextBox.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
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

        public decimal? Amortization
        {
            set { _amortizationLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public decimal? PaymentCompletionAmount
        {
            set { _paymentCompletionAmountLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public string AvailOption
        {
            set { _availOptionLabel.Text = value.Trim(); }
        }

        public int? AgingPeriod
        {
            set { _agingPeriodLabel.Text = value != null ? value.ToString() : string.Empty; }
        }

        public decimal? AwardAmount
        {
            set { _awardAmountLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public decimal? MonthlyPension
        {
            set { _monthlyPensionLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public string OptionDescription
        {
            set { _optionDescriptionRichTextBox.Text = value; }
        }

        #endregion

        #region ISummaryView Members

        public bool IsSummaryLoaded { get; set; }

        public void LoadSummary(long memberID)
        {
            if (IsSummaryLoaded)
                return;

            IsSummaryLoaded = _presenter.Load(memberID);

            if (IsSummaryLoaded)
                _memberID = memberID;
        }

        public void ClearSummary()
        {
            _presenter.Clear();
            _memberID = 0L;
            IsSummaryLoaded = false;
        }

        #endregion

        #region Routine Helpers

        private void RefreshSummary()
        {
            // refresh
            IsSummaryLoaded = false;
            LoadSummary(_memberID);
        }

        #endregion

        private void EnrollButton_Click(object sender, EventArgs e)
        {
            if (!_presenter.CheckQualification())
                return;

            using (var ppev = new PensionPlanEnrollmentView())
            {
                ppev.Enrolled += new EventHandler(PensionPlanEnrollmentView_Enrolled);
                ppev.MemberID = _memberID;
                ppev.ShowDialog(this);
            }
        }

        private void SetAvailOptionButton_Click(object sender, EventArgs e)
        {
            using (var aosv = new AvailOptionSetterView())
            {
                aosv.MemberID = _memberID;
                aosv.Changed += new EventHandler(AvailOptionSetterView_Changed);
                aosv.ShowDialog(this);
            }
        }

        private void PensionPlanEnrollmentView_Enrolled(object sender, EventArgs e)
        {
            RefreshSummary();
        }

        private void AvailOptionSetterView_Changed(object sender, EventArgs e)
        {
            RefreshSummary();
        }
    }
}
