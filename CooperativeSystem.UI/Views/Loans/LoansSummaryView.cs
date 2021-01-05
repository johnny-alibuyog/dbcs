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
using CooperativeSystem.Service.Presenters.Loans.Calculators;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.UI.Views.Utilities;

namespace CooperativeSystem.UI.Views.Loans
{
    public partial class LoansSummaryView : UserControlTemplate, ILoanSummaryView
    {
        private LoanSummaryPresenter _presenter;
        private Nullable<long> _memberID;

        private SafeInvoker _invoker;

        public LoanType LoanType { get; set; }

        #region Threading Helpers

        public delegate void SafeInvokeDelegate(System.Action action);

        private class SafeInvoker
        {
            private readonly System.ComponentModel.ISynchronizeInvoke _threadControl;

            public SafeInvoker()
            {
                _threadControl = new System.Windows.Forms.Control();
            }

            public void Invoke(System.Action action)
            {
                if (_threadControl.InvokeRequired)
                    _threadControl.Invoke(new SafeInvokeDelegate(Invoke), new object[] { action });
                else if (action != null) 
                    action.Invoke();
            }
        }

        #endregion

        #region ISummaryView Members

        public bool IsSummaryLoaded
        {
            get { return _pastLoansButton.Enabled; }
            set { _pastLoansButton.Enabled = value; }
        }

        public void LoadSummary(long memberID)
        {
            if (IsSummaryLoaded)
                return;

            _memberID = memberID;
            IsSummaryLoaded = _presenter.Load(_memberID.Value);
        }

        public void ClearSummary()
        {
            _presenter.Clear();
            _memberID = null;
            IsSummaryLoaded = false;
        }

        #endregion

        #region ILoanSummaryView Members

        public string CashDisbursementVoucher
        {
            get { return _cashDisbursementVoucher.Text; }
            set { _cashDisbursementVoucher.Text = value; }
        }

        public string LoanServiceID
        {
            get
            {
                switch (LoanType)
                {
                    case LoanType.ApplianceLoan:
                        return ServiceCodes.ApplianceLoan;
                    case LoanType.EasyLoan:
                        return ServiceCodes.EasyLoan;
                    case LoanType.EmergencyLoan:
                        return ServiceCodes.EmergencyLoan;
                    case LoanType.EquityLoan:
                        return ServiceCodes.EquityLoan;
                    case LoanType.PensionLoan:
                        return ServiceCodes.PensionLoan;
                    case LoanType.RegularLoan:
                        return ServiceCodes.RegularLoan;
                    default:
                        return ServiceCodes.RegularLoan;
                }
            }
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

        public DateTime? LoanDate
        {
            set { _loanDateLabel.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
        }

        public DateTime? NextPaymentDue
        {
            set { _nextPaymentDueLabel.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
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
            set { _paymentModeLabel.Text = value; ; }
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

        public decimal? OutstandingBalance
        {
            set { _outstandingBalanceLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public decimal? Amortization
        {
            set { _amortizationLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public DateTime? DelayedPaymentDueDate
        {
            set { _delayedPaymentDueDateLabel.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
        }

        public int? DelayedPaymentDaysDelayed
        {
            set { _delayedPaymentDaysDelayedLabel.Text = value != null ? value.Value.ToString() : string.Empty; }
        }

        public decimal? DelayedPaymentFine
        {
            set { _delayedPaymentChargeLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public string DelayedPaymentRemarks
        {
            set { _delayedPaymentRemarksLabel.Text = value; }
        }

        public DateTime? DelinquentDueDate
        {
            set { _delinquentDueDateLabel.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
        }

        public int? DelinquentDaysDelinquent
        {
            set { _delinquentDaysDelinquentLabel.Text = value != null ? value.Value.ToString() : string.Empty; ; }
        }

        public decimal? DelinquentCharge
        {
            set { _delinquentChargeLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public string DelinquentRemarks
        {
            set { _delinquentRemarksLabel.Text = value; }
        }

        #endregion

        public LoansSummaryView()
        {
            InitializeComponent();

            _chargesDataGridView.AutoGenerateColumns = false;
            _finesDataGridView.AutoGenerateColumns = false;

            _invoker = new SafeInvoker();

            _presenter = new LoanSummaryPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void BlinkTimer_Tick(object sender, EventArgs e)
        {

            //var thread = new Thread(InvokeBlinkEffect);
            //thread.Start();

            _invoker.Invoke(InvokeBlinkEffect);
        }

        private void InvokeBlinkEffect()
        {
            if (!string.IsNullOrEmpty(_delayedPaymentRemarksLabel.Text))
                _delayedPaymentRemarksLabel.Visible = !_delayedPaymentRemarksLabel.Visible;

            if (!string.IsNullOrEmpty(_delinquentRemarksLabel.Text))
                _delinquentRemarksLabel.Visible = !_delinquentRemarksLabel.Visible;
        }

        private void PastLoansButton_Click(object sender, EventArgs e)
        {
            if (_memberID == null)
                return;

            using (var pastLoansView = new PastLoansView())
            {
                pastLoansView.MemberID = _memberID.Value;
                pastLoansView.LoanServiceID = LoanServiceID;
                pastLoansView.ShowDialog(this);
            }
        }
    }
}
