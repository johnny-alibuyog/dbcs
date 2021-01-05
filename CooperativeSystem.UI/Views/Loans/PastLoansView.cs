using System;
using System.Collections.Generic;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Loans;
using CooperativeSystem.UI.Views.Utilities;

namespace CooperativeSystem.UI.Views.Loans
{
    public partial class PastLoansView : FormTemplate, IPastLoansView
    {
        private PastLoansPresenter _presenter;

        public PastLoansView()
        {
            InitializeComponent();

            _presenter = new PastLoansPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        #region IPastLoansView Members

        public long MemberID { get; set; }

        public string LoanServiceID { get; set; }

        public Nullable<long> SelectedLoanID
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
            set { _loanDateLabel.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
        }

        public DateTime? SettlementDate
        {
            set { _settlementDateLabel.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
        }

        public DateTime? DueDate
        {
            set { _dueDateLabel.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
        }

        public int? Terms
        {
            set { _termsLabel.Text = value != null ? value.Value.ToString() : string.Empty; }
        }

        public string PaymentMode
        {
            set { _paymentModeLabel.Text = value; }
        }

        public string DeductionType
        {
            set { _deductionTypeLabel.Text = value; ; }
        }


        public decimal? ServiceFee
        {
            set { _serviceFeeLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public decimal? CollectionFee
        {
            set { _collectionFeeLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public decimal? CapitalBuildup
        {
            set { _capitalBuildupLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public decimal? LoanGuranteeFund
        {
            set { _loanGuaranteeFundLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public decimal? Interest
        {
            set { _interestLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public decimal? LoanAmount
        {
            set { _loanAmountLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public decimal? TotalPayableAmount
        {
            set { _totalPayableAmountLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public decimal? Amortization
        {
            set { _amortizationLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public IList<TransactionModel> Transactions
        {
            set
            {
                //_paymentsDataGridView.DataSource = value;
                _paymentsDataGridView.DataSource = value != null
                    ? new SearchableSortableBindingList<TransactionModel>(value)
                    : new SearchableSortableBindingList<TransactionModel>();
            }
        }

        public decimal? TotalTransaction
        {
            set { _totalPaymentTextBox.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public IList<ReceiptModel> Fines
        {
            set
            {
                //_finesDataGridView.DataSource = value;
                _finesDataGridView.DataSource = value != null
                    ? new SearchableSortableBindingList<ReceiptModel>(value)
                    : new SearchableSortableBindingList<ReceiptModel>();
            }
        }

        public decimal? TotalFine
        {
            set { _totalFineTextBox.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public IList<ReceiptModel> Charges
        {
            set
            {
                //_chargesDataGridView.DataSource = value;
                _chargesDataGridView.DataSource = value != null
                    ? new SearchableSortableBindingList<ReceiptModel>(value)
                    : new SearchableSortableBindingList<ReceiptModel>();
            }
        }

        public decimal? TotalCharge
        {
            set { _totalChargeTextBox.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public bool IsPopulatingPulldown { get; set; }

        public void PopulateLoanPulldown(IList<LoanLookupModel> loansLookup)
        {
            _loansComboBox.DataSource = loansLookup;
            _loansComboBox.ValueMember = "LoanID";
            _loansComboBox.DisplayMember = "VoucherNumber";
        }

        #endregion

        private void PastLoansView_Shown(object sender, EventArgs e)
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
    }
}
