using System;
using System.Collections.Generic;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Loans;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;
using CooperativeSystem.Service.Presenters.Lookups.DeductionTypes;
using CooperativeSystem.Service.Presenters.Lookups.PaymentModes;

namespace CooperativeSystem.UI.Views.Loans
{
    public partial class LoanAssessmentView : FormTemplate, ILoanAssessmentView
    {
        private readonly LoanAssessmentPresenter _presenter;
        private readonly string _defaultValue = "0.00";
        private string _serviceId;

        #region Routine Helpers

        private bool IsFixedAmountLoan
        {
            get
            {
                return (_serviceId == ServiceCodes.ApplianceLoan ||
                    _serviceId == ServiceCodes.EasyLoan);// ||
                    //_serviceId == ServiceCodes.EmergencyLoan);
            }
        }

        private void InitializeScreen()
        {
            switch (_serviceId)
            {
                case ServiceCodes.ApplianceLoan:
                    Text = "Appliance Loan";
                    LoanDeductionTypeID = LoanDeductionTypeCodes.AddOn;
                    PaymentModeID = PaymentModeCodes.Daily;
                    break;
                case ServiceCodes.EasyLoan:
                    Text = "Easy Loan";
                    LoanDeductionTypeID = LoanDeductionTypeCodes.AddOn;
                    PaymentModeID = PaymentModeCodes.Daily;
                    break;
                case ServiceCodes.EmergencyLoan:
                    Text = "Emergency Loan";
                    LoanDeductionTypeID = LoanDeductionTypeCodes.Deducted;
                    PaymentModeID = PaymentModeCodes.Monthly;
                    break;
                case ServiceCodes.EquityLoan:
                    Text = "Equity Loan";
                    LoanDeductionTypeID = LoanDeductionTypeCodes.AddOn;
                    PaymentModeID = PaymentModeCodes.Daily;
                    break;
                case ServiceCodes.PensionLoan:
                    Text = "Pension Loan";
                    LoanDeductionTypeID = LoanDeductionTypeCodes.AddOn;
                    PaymentModeID = PaymentModeCodes.Daily;
                    break;
                case ServiceCodes.RegularLoan:
                    Text = "Regular Loan";
                    LoanDeductionTypeID = LoanDeductionTypeCodes.AddOn;
                    PaymentModeID = PaymentModeCodes.Daily;
                    break;
                default:
                    throw new ArgumentException(_serviceId + " is not included in this loan service.");
            }

            _loanAmountTextBox.ReadOnly = IsFixedAmountLoan;
        }

        private void InitializeInputs()
        {
            //if (_paymentModeComboBox.Items.Count > 0)
            //    _paymentModeComboBox.SelectedIndex = 0;
            _termsNumericUpDown.Value = 1;
            _interestRateTextBox.Text = _defaultValue;
            _maximumLoanAmountTextBox.Text = _defaultValue;
            _loanAmountTextBox.Text = _defaultValue;

            InitializeAssessment();
        }

        private void InitializeAssessment()
        {
            _outstandingBalanceTextBox.Text = _defaultValue;
            _serviceFeeTextBox.Text = _defaultValue;
            _collectionFeeTextBox.Text = _defaultValue;
            _capitalBuildupTextBox.Text = _defaultValue;
            _loanGuaranteeFundTextBox.Text = _defaultValue;
            _interestTextBox.Text = _defaultValue;
            _amortizationTextBox.Text = _defaultValue;
            _dueDateTextBox.Text = _defaultValue;
            _netAmountDueTextBox.Text = _defaultValue;
            _remaksLabel.Text = string.Empty;
            IsAssessed = false;
        }

        protected virtual void OnAssessmentAdd(EventArgs e)
        {
            RaiseAssessmentAddEvent(this, e);
        }

        private void RaiseAssessmentAddEvent(object sender, EventArgs e)
        {
            if (AssessmentAdd != null)
                AssessmentAdd.Invoke(sender, e);
        }

        #endregion

        #region ILoanAssessmentView Members

        public event EventHandler AssessmentAdd;

        public bool IsAssessed
        {
            get { return _acceptButton.Enabled; }
            set { _acceptButton.Enabled = value; }
        }

        public long MemberID { get; set; }

        public string LoanServiceID
        {
            get { return _serviceId; }
            set { _serviceId = value; }
        }

        public DateTime LoanDate { get; set; }

        public string PaymentModeID
        {
            get { return _paymentModeComboBox.SelectedValue.ToString(); }
            set { _paymentModeComboBox.SelectedValue = value; }
        }

        public string LoanDeductionTypeID
        {
            get { return _loanDeductionTypeComboBox.SelectedValue.ToString(); }
            set { _loanDeductionTypeComboBox.SelectedValue = value; }
        }

        public decimal InterestRate
        {
            get { return Convert.ToDecimal(_interestRateTextBox.Text); }
            set { _interestRateTextBox.Text = value.ToString("N2"); }
        }

        public int Terms
        {
            get { return (int)_termsNumericUpDown.Value; }
            set { _termsNumericUpDown.Value = value; }
        }

        public decimal LoanAmount
        {
            get { return Convert.ToDecimal(_loanAmountTextBox.Text); }
            set { _loanAmountTextBox.Text = value.ToString("N2"); }
        }

        public decimal MaximumLoanAmount
        {
            get { return Convert.ToDecimal(_maximumLoanAmountTextBox.Text); }
            set { _maximumLoanAmountTextBox.Text = value.ToString("N2"); }
        }

        public DateTime DueDate
        {
            get { return DateTime.Parse(_dueDateTextBox.Text); }
            set { _dueDateTextBox.Text = value.ToShortDateString(); }
        }

        public DateTime PaymentStartDate
        {
            get { return DateTime.Parse(_paymentStartDateTextBox.Text); }
            set { _paymentStartDateTextBox.Text = value.ToShortDateString(); }
        }

        public decimal OutstandingBalance
        {
            get { return Convert.ToDecimal(_outstandingBalanceTextBox.Text); }
            set { _outstandingBalanceTextBox.Text = value.ToString("N2"); }
        }

        public Nullable<long> OutstandingLoanId
        {
            get;
            set;
        }

        public decimal ServiceFee
        {
            get { return Convert.ToDecimal(_serviceFeeTextBox.Text); }
            set { _serviceFeeTextBox.Text = value.ToString("N2"); }
        }

        public decimal CollectionFee
        {
            get { return Convert.ToDecimal(_collectionFeeTextBox.Text); }
            set { _collectionFeeTextBox.Text = value.ToString("N2"); }
        }

        public decimal CapitalBuildup
        {
            get { return Convert.ToDecimal(_capitalBuildupTextBox.Text); }
            set { _capitalBuildupTextBox.Text = value.ToString("N2"); }
        }

        public decimal LoanGuaranteeFund
        {
            get { return Convert.ToDecimal(_loanGuaranteeFundTextBox.Text); }
            set { _loanGuaranteeFundTextBox.Text = value.ToString("N2"); }
        }

        public decimal Interest
        {
            get { return Convert.ToDecimal(_interestTextBox.Text); }
            set { _interestTextBox.Text = value.ToString("N2"); }
        }

        public decimal Amortization
        {
            get { return Convert.ToDecimal(_amortizationTextBox.Text); }
            set { _amortizationTextBox.Text = value.ToString("N2"); }
        }

        public decimal NetAmountDue
        {
            get { return Convert.ToDecimal(_netAmountDueTextBox.Text); }
            set { _netAmountDueTextBox.Text = value.ToString("N2"); }
        }

        public void Initialize()
        {
            InitializeScreen();
            InitializeInputs();
        }

        public void ViewReport(LoanAssessmentReportModel model)
        {
            var items = new List<LoanAssessmentReportModel>() { model };
            using (var view = new LoanAssessmentReportView())
            {
                view.Populate(items);
                view.ShowDialog(this);
            }
        }

        public void PopulatePaymentMode(IList<PaymentMode> paymentModes)
        {
            _paymentModeBindingSource.DataSource = paymentModes;
        }

        public void PopulateLoanDeductionType(IList<LoanDeductionType> loanDeductionTypes)
        {
            _loanDeductionTypeBindingSource.DataSource = loanDeductionTypes;
        }

        #endregion

        public LoanAssessmentView()
        {
            InitializeComponent();

            _presenter = new LoanAssessmentPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
            //_presenter.Initialize();

            ControlValidator.RegisterControl(_loanAmountTextBox, InputType.Currency, true, "Loan Amount", 16, 2);

        }

        private void LoanAssessmentView_Shown(object sender, EventArgs e)
        {
            _presenter.Initialize();
            Initialize();
        }

        private void AssessLoanButton_Click(object sender, EventArgs e)
        {
            if (!ControlValidator.Validate())
                return;

            var remarks = string.Empty;
            IsAssessed = _presenter.Assess(out remarks);
            _remaksLabel.Text = remarks;
        }

        private void InputChanged(object sender, EventArgs e)
        {
            InitializeAssessment();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private void InterestRateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _interestRateTextBox.ReadOnly = !_interestRateCheckBox.Checked;
            if (_interestRateTextBox.ReadOnly)
                _interestRateTextBox.Text = "0.00";
            else
                _interestRateTextBox.SelectAll();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ControlValidator.Validate())
                    return;

                //if (AskConfirmation(this, "Do you want to add assessment?") != DialogResult.Yes)
                //    return;

                OnAssessmentAdd(new EventArgs());
                Close();
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }

        private void ViewReportButton_Click(object sender, EventArgs e)
        {
            _presenter.ViewReport();
        }
    }
}
