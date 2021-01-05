using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Loans;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;
using CooperativeSystem.UI.Views.User;

namespace CooperativeSystem.UI.Views.Loans
{
    public partial class LoanPaymentView : FormTemplate, ILoanPaymentView
    {
        private LoanPaymentPresenter _presenter;

        private string _serviceID;

        public LoanPaymentView()
        {
            InitializeComponent();

            _presenter = new LoanPaymentPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_paymentAmountTextBox, InputType.Currency, false, "Payment Amount", 16, 2);
            ControlValidator.RegisterControl(_latePaymentChargeTextBox, InputType.Currency, false, "Late Payment Charge", 16, 2);
            ControlValidator.RegisterControl(_delinquentChargeTextBox, InputType.Currency, false, "Delinquent Charge", 16, 2);
        }

        #region ILoanPaymentView Members

        public event EventHandler ReceiptAdd;

        public bool HasLoan
        {
            get { return _acceptButton.Enabled; }
            set { _acceptButton.Enabled = value; }
        }

        public long MemberID { get; set; }

        public long LoanID { get; set; }

        public string LoanServiceID
        {
            get
            {
                return _serviceID;
            }
            set
            {
                _serviceID = value;
                switch (_serviceID)
                {
                    case ServiceCodes.ApplianceLoan:
                        Text = "Appliance Loan";
                        break;
                    case ServiceCodes.EasyLoan:
                        Text = "Easy Loan";
                        break;
                    case ServiceCodes.EmergencyLoan:
                        Text = "Emergency Loan";
                        break;
                    case ServiceCodes.EquityLoan:
                        Text = "Equity Loan";
                        break;
                    case ServiceCodes.PensionLoan:
                        Text = "Pension Loan";
                        break;
                    case ServiceCodes.RegularLoan:
                        Text = "Regular Loan";
                        break;
                    default:
                        throw new ArgumentException(value + " is not included in this loan service.");
                }
            }
        }

        public bool FullyPayOutstandingBalance
        {
            get { return this.OutstandingBalance <= this.PaymentAmount; }
        }

        public bool FullyPayPayableAmount
        {
            get { return this.PayableAmount <= this.PaymentAmount; }
        }

        public string PaymentMode
        {
            get { return _paymentModeTextBox.Text; }
            set { _paymentModeTextBox.Text = value; }
        }

        public DateTime? PaymentDueDate
        {
            get
            {
                DateTime? date = null;
                if (!string.IsNullOrEmpty(_paymentDueDateTextBox.Text))
                    date = DateTime.Parse(_paymentDueDateTextBox.Text);
                return date;
            }
            set
            {
                _paymentDueDateTextBox.Text = value != null
                    ? value.Value.ToShortDateString()
                    : string.Empty;
            }
        }

        public decimal LoanAmount
        {
            get { return Convert.ToDecimal(_loanAmountTextBox.Text); }
            set { _loanAmountTextBox.Text = value.ToString("N2"); }
        }

        public decimal OutstandingBalance
        {
            get { return Convert.ToDecimal(_outstandingBalanceTextBox.Text); }
            set { _outstandingBalanceTextBox.Text = value.ToString("N2"); }
        }

        public decimal Amortization
        {
            get { return Convert.ToDecimal(_amortizationTextBox.Text); }
            set { _amortizationTextBox.Text = value.ToString("N2"); }
        }

        public decimal PayableAmount
        {
            get;
            set;
        }

        public decimal PaymentAmount
        {
            get { return Convert.ToDecimal(_paymentAmountTextBox.Text); }
            set { _paymentAmountTextBox.Text = value.ToString("N2"); }
        }

        public bool HasLatePaymentCharge
        {
            get { return _latePaymentChargeGroupBox.Enabled; }
            set { _latePaymentChargeGroupBox.Enabled = value; }
        }

        public bool CondoneLatePaymentCharge
        {
            get { return _condoneLatePaymentChargeCheckBox.Checked; }
            set { _condoneLatePaymentChargeCheckBox.Checked = value; }
        }

        public bool FullyPayLatePaymentCharge
        {
            get { return this.ComputedLatePaymentCharge <= this.LatePaymentCharge; }
        }

        public DateTime? LatePaymentDueDate
        {
            get
            {
                DateTime? date = null;
                if (!string.IsNullOrEmpty(_latePaymentDueDateTextBox.Text))
                    date = DateTime.Parse(_latePaymentDueDateTextBox.Text);
                return date;
            }
            set
            {
                _latePaymentDueDateTextBox.Text = value != null
                    ? value.Value.ToShortDateString()
                    : string.Empty;
            }
        }

        public int LatePaymentDaysDelayed
        {
            get { return Convert.ToInt32(_latePaymentDaysDelayedTextBox.Text); }
            set { _latePaymentDaysDelayedTextBox.Text = value.ToString(); }
        }

        public decimal ComputedLatePaymentCharge
        {
            get { return Convert.ToDecimal(_computedLatePaymentChargeTextBox.Text); }
            set { _computedLatePaymentChargeTextBox.Text = value.ToString("N2"); }
        }

        public decimal PreviousUnpaidLatePaymentCharge
        {
            get { return Convert.ToDecimal(_previousUnpaidLatePaymentChargeTextBox.Text); }
            set { _previousUnpaidLatePaymentChargeTextBox.Text = value.ToString("N2"); }
        }

        public decimal LatePaymentCharge
        {
            get { return Convert.ToDecimal(_latePaymentChargeTextBox.Text); }
            set { _latePaymentChargeTextBox.Text = value.ToString("N2"); }
        }

        public bool HasDelinquentCharge
        {
            get { return _delinquentChargeGroupBox.Enabled; }
            set { _delinquentChargeGroupBox.Enabled = value; }
        }

        public bool CondoneDelinquentCharge
        {
            get { return _condoneDelinquentChargeCheckBox.Checked; }
            set { _condoneDelinquentChargeCheckBox.Checked = value; }
        }

        public bool FullyPayDelinquentCharge
        {
            get { return this.ComputedDelinquentCharge <= this.DelinquentCharge; }
        }

        public DateTime? DelinquentDueDate
        {
            get
            {
                DateTime? date = null;
                if (!string.IsNullOrEmpty(_delinquentDueDateTextBox.Text))
                    date = DateTime.Parse(_delinquentDueDateTextBox.Text);
                return date;
            }
            set
            {
                _delinquentDueDateTextBox.Text = value != null
                    ? value.Value.ToShortDateString()
                    : string.Empty;
            }
        }

        public int DelinquentDaysDelinquent
        {
            get { return Convert.ToInt32(_delinquentDaysDelayedTextBox.Text); }
            set { _delinquentDaysDelayedTextBox.Text = value.ToString("N2"); }
        }

        public decimal ComputedDelinquentCharge
        {
            get { return Convert.ToDecimal(_computedDelinquentChargeTextBox.Text); }
            set { _computedDelinquentChargeTextBox.Text = value.ToString("N2"); }
        }

        public decimal PreviousUnpaidDelinquentCharge
        {
            get { return Convert.ToDecimal(_previousUnpaidDelinquentChargeTextBox.Text); }
            set { _previousUnpaidDelinquentChargeTextBox.Text = value.ToString("N2"); }
        }

        public decimal DelinquentCharge
        {
            get { return Convert.ToDecimal(_delinquentChargeTextBox.Text); }
            set { _delinquentChargeTextBox.Text = value.ToString("N2"); }
        }

        public decimal TotalPaymentAmount
        {
            get { return Convert.ToDecimal(_totalPaymentAmountTextBox.Text); }
            set { _totalPaymentAmountTextBox.Text = value.ToString("N2"); }
        }

        public void Initialize()
        {
            LoanID = 0L;

            // payment
            PaymentMode = string.Empty;
            PaymentDueDate = null;
            LoanAmount = 0M;
            OutstandingBalance = 0M;
            Amortization = 0M;
            PayableAmount = 0M;
            PaymentAmount = 0M;

            // late payment charge
            HasLatePaymentCharge = false;
            CondoneLatePaymentCharge = false;
            LatePaymentDueDate = null;
            LatePaymentDaysDelayed = 0;
            ComputedLatePaymentCharge = 0M;
            PreviousUnpaidLatePaymentCharge = 0M;
            LatePaymentCharge = 0M;

            // delinquent charge
            HasDelinquentCharge = false;
            CondoneDelinquentCharge = false;
            DelinquentDueDate = null;
            DelinquentDaysDelinquent = 0;
            ComputedDelinquentCharge = 0M;
            PreviousUnpaidDelinquentCharge = 0M;
            DelinquentCharge = 0M;

            TotalPaymentAmount = 0M;
        }

        #endregion

        #region Routine Helpers

        private void OnReceiptAdd(EventArgs e)
        {
            RaiseReceiptAdd(this, e);
        }

        private void RaiseReceiptAdd(object sender, EventArgs e)
        {
            if (ReceiptAdd != null)
                ReceiptAdd.Invoke(sender, e);
        }

        #endregion

        private void PayDelinquentChargeCheckBox_Click(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                using (var view = new ManagerApprovalView())
                {
                    var result = view.ShowDialog(this);
                    if (result == System.Windows.Forms.DialogResult.Cancel)
                        ((CheckBox)sender).Checked = !((CheckBox)sender).Checked;
                }
            }

            //_delinquentChargeTextBox.ReadOnly = !((CheckBox)sender).Checked;
            InputChanged(sender, e);
        }

        private void PayLatePaymentChargeCheckBox_Click(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                using (var view = new ManagerApprovalView())
                {
                    var result = view.ShowDialog(this);
                    if (result == System.Windows.Forms.DialogResult.Cancel)
                        ((CheckBox)sender).Checked = !((CheckBox)sender).Checked;
                }
            }

            //_latePaymentChargeTextBox.ReadOnly = !((CheckBox)sender).Checked;
            InputChanged(sender, e);
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ControlValidator.Validate())
                    return;

                if (this.PaymentAmount > this.OutstandingBalance)
                {
                    var message = "Payment amount exeeds outstanding balance.\nDo you still want to continue payment?";
                    var dialogResult = AskConfirmation(this, message, MessageBoxIcon.Error);
                    if (dialogResult != DialogResult.Yes)
                        return;
                }

                //if (AskConfirmation(this, "Do you want to add payment?") != DialogResult.Yes)
                //    return;

                OnReceiptAdd(new EventArgs());
                Close();
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }

        private void LoanPaymentView_Shown(object sender, EventArgs e)
        {
            HasLoan = _presenter.Load();
            _paymentAmountTextBox.Focus();
            _paymentAmountTextBox.SelectAll();

            //_delinquentChargeTextBox.ReadOnly = !this.CondoneDelinquentCharge;
            //_latePaymentChargeTextBox.ReadOnly = !this.CondoneLatePaymentCharge;
        }

        private void InputChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_paymentAmountTextBox.Text.Trim()))
                TotalPaymentAmount = PaymentAmount;

            if (!string.IsNullOrEmpty(_latePaymentChargeTextBox.Text.Trim()))
            {
                //if (!this.CondoneLatePaymentCharge)
                //    LatePaymentCharge = PreviousLatePaymentCharge + ComputedLatePaymentCharge;

                TotalPaymentAmount += LatePaymentCharge;
            }

            if (!string.IsNullOrEmpty(_delinquentDaysDelayedTextBox.Text.Trim()))
            {
                //if (!this.CondoneDelinquentCharge)
                //    DelinquentCharge = PreviousDelinquentCharge + ComputedDelinquentCharge;

                TotalPaymentAmount += DelinquentCharge;
            }
        }
    }
}