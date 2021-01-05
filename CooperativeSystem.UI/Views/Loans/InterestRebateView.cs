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
using CooperativeSystem.Service.Presenters.Loans;
using CooperativeSystem.Service.Presenters.Members;

namespace CooperativeSystem.UI.Views.Loans
{
    public partial class InterestRebateView : FormTemplate, IInterestRebateView
    {
        public event EventHandler TransactionCommitted;

        private InterestRebatePresenter _presenter;
        private IMemberInquiryDetailsView _member;

        #region Routine Helpers

        private void DisableFields()
        {
            _receiptDateTimePicker.Enabled = false;
            _acceptButton.Enabled = false;
        }

        protected virtual void OnTransactionCommitted(EventArgs e)
        {
            RaiseTransactionCommittedEvent(this, e);
        }

        private void RaiseTransactionCommittedEvent(object sender, EventArgs e)
        {
            if (TransactionCommitted != null)
                TransactionCommitted.Invoke(sender, e);
        }

        #endregion

        #region IInterestRebateView Members

        public string UserID { get; private set; }

        public DateTime AdjustmentDate
        {
            get { return _receiptDateTimePicker.Value; }
        }

        public string VoucherNumber
        {
            get { return _voucherNumberTextBox.Text; }
            set { _voucherNumberTextBox.Text = value; }
        }

        public string Sequence
        {
            get { return _sequenceTextBox.Text; }
        }

        public long MemberID
        {
            get { return _member.MemberID; }
        }

        public long? SelectedLoanID
        {
            get
            {
                return _loansComboBox.SelectedValue != null
                    ? new Nullable<long>((long)_loansComboBox.SelectedValue)
                    : null;
            }
        }

        public DateTime? LoanDate
        {
            set { _loanDateTextBox.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
        }

        public DateTime? SettlementDate
        {
            set { _settlementDateTextBox.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
        }

        public DateTime? DueDate
        {
            set { _dueDateTextBox.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
        }

        public string PaymentMode
        {
            set { _paymentModeTextBox.Text = value; }
        }

        public int? Terms
        {
            set { _termsTextBox.Text = value != null ? value.Value.ToString() : string.Empty; }
        }

        public decimal? LoanAmount
        {
            set { _loanAmountTextBox.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public decimal? InterestRate
        {
            set { _interestRateTextBox.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public decimal? Interest
        {
            set { _interestTextBox.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public int? MonthsRebatable
        {
            set { _monthsPaidTextBox.Text = value != null ? value.Value.ToString() : string.Empty; }
        }

        public decimal? InterestRebate
        {
            get { return new Nullable<decimal>(Convert.ToDecimal(_interestRebateTextBox.Text)); }
            set { _interestRebateTextBox.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public bool IsPopulatingPulldown { get; set; }

        public bool HasRebatableLoan
        {
            get { return _acceptButton.Enabled; }
            set { _acceptButton.Enabled = value; }
        }

        public void PopulateLoanPulldown(IList<LoanLookupModel> loansLookup)
        {
            _loansComboBox.DataSource = loansLookup;
            _loansComboBox.ValueMember = "LoanID";
            _loansComboBox.DisplayMember = "VoucherNumber";
        }

        #endregion

        public InterestRebateView(IMemberInquiryDetailsView member, string userID)
        {
            InitializeComponent();

            _member = member;
            UserID = userID;

            _presenter = new InterestRebatePresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void InterestRebateView_Shown(object sender, EventArgs e)
        {
            _presenter.Load();
            _presenter.SelectLoan();
        }

        private void LoansComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (IsPopulatingPulldown)
                return;

            _presenter.SelectLoan();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (AskConfirmation(this, "Are you sure you want to the commit transaction?") != DialogResult.Yes)
                    return;

                if (_presenter.Accept())
                {
                    DisableFields();
                    OnTransactionCommitted(new EventArgs());
                }
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }

        private void RestartVoucherCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var restart = ((CheckBox)sender).Checked;

            _generateReceiptButton.Enabled = restart;
            _sequenceTextBox.Enabled = restart;
            _sequenceTextBox.Text = string.Empty;
            _sequenceTextBox.Select();
        }

        private void GenerateReceiptButton_Click(object sender, EventArgs e)
        {
            if (_presenter.GenerateVoucherNumber())
                _restartVoucherCheckBox.Checked = false;
        }
    }
}
