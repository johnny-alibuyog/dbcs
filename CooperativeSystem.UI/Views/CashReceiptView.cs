using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Members;
using CooperativeSystem.Service.Utilities.Logs;
using CooperativeSystem.UI.Views.Loans;
using CooperativeSystem.UI.Views.Plans;
using CooperativeSystem.UI.Views.Plans.CollegeInsurancePlan;
using CooperativeSystem.UI.Views.Savings;
using CooperativeSystem.UI.Views.Savings.TimeDeposit;
using CooperativeSystem.UI.Views.SpecialFunds;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;
using CooperativeSystem.UI.Views.Plans.PensionPlan;


namespace CooperativeSystem.UI.Views
{
    public partial class CashReceiptView : FormTemplate, ICashReceiptView, IServicesAdapter
    {
        public event EventHandler TransactionCommitted;

        private CashReceiptPresenter _presenter;

        private LoanPaymentView _childLoanPaymentView;
        private TimeDepositDepositView _childTimeDepositDepositView;
        private CIPPaymentView _childCIPView;
        private PensionPlanPaymentView _childPensionPlanView;

        private IMemberInquiryDetailsView _member;
        private ErrorLogger _errorLogger;

        private IList<TextBox> _inputTextBoxes;

        #region ICashReceiptView Members

        public long MemberID
        {
            get { return _member.MemberID; }
        }

        public string UserID { get; set; }

        public DateTime ReceiptDate
        {
            get { return _receiptDateTimePicker.Value; }
        }

        public string ReceiptNumber
        {
            get { return _officialReceiptNumber.Text; }
            set { _officialReceiptNumber.Text = value; }
        }

        public string Sequence
        {
            get { return _sequenceTextBox.Text; }
        }

        public decimal ApplianceLoan
        {
            get { return Convert.ToDecimal(_applianceLoanTextBox.Text); }
            set { _applianceLoanTextBox.Text = value.ToString("N2"); }
        }

        public decimal EasyLoan
        {
            get { return Convert.ToDecimal(_easyLoanTextBox.Text); }
            set { _easyLoanTextBox.Text = value.ToString("N2"); }
        }

        public decimal EmergencyLoan
        {
            get { return Convert.ToDecimal(_emergencyLoanTextBox.Text); }
            set { _emergencyLoanTextBox.Text = value.ToString("N2"); }
        }

        public decimal EquityLoan
        {
            get { return Convert.ToDecimal(_equityLoanTextBox.Text); }
            set { _equityLoanTextBox.Text = value.ToString("N2"); }
        }

        public decimal PensionLoan
        {
            get { return Convert.ToDecimal(_pensionLoanTextBox.Text); }
            set { _pensionLoanTextBox.Text = value.ToString("N2"); }
        }

        public decimal RegularLoan
        {
            get { return Convert.ToDecimal(_regularLoanTextBox.Text); }
            set { _regularLoanTextBox.Text = value.ToString("N2"); }
        }

        public decimal DTILoan
        {
            get { return 0M; }
            set { }
        }

        public decimal MEDPLoan
        {
            get { return 0M; }
            set { }
        }

        public decimal CollegeInsurancePlan
        {
            get { return Convert.ToDecimal(_collegeInsurancePlanTextBox.Text); }
            set { _collegeInsurancePlanTextBox.Text = value.ToString("N2"); }
        }

        public decimal PensionPlan
        {
            get { return Convert.ToDecimal(_pensionPlanTextBox.Text); }
            set { _pensionPlanTextBox.Text = value.ToString("N2"); }
        }

        public decimal CapitalShare
        {
            get { return Convert.ToDecimal(_capitalShareTextBox.Text); }
            set { _capitalShareTextBox.Text = value.ToString("N2"); }
        }

        public decimal SavingsDeposit
        {
            get { return Convert.ToDecimal(_savingsDepositTextBox.Text); }
            set { _savingsDepositTextBox.Text = value.ToString("N2"); }
        }

        public decimal TimeDeposit
        {
            get { return Convert.ToDecimal(_timeDepositTextBox.Text); }
            set { _timeDepositTextBox.Text = value.ToString("N2"); }
        }

        public decimal DeathAidFund
        {
            get { return Convert.ToDecimal(_deathAidFundTextBox.Text); }
            set { _deathAidFundTextBox.Text = value.ToString("N2"); }
        }

        public decimal TulunganFund
        {
            get { return Convert.ToDecimal(_tulunganFundTextBox.Text); }
            set { _tulunganFundTextBox.Text = value.ToString("N2"); }
        }

        public decimal MiscellaneousIncome
        {
            get { return Convert.ToDecimal(_miscellaneousIncomeTextBox.Text); }
            set { _miscellaneousIncomeTextBox.Text = value.ToString("N2"); }
        }

        public decimal MembershipFee
        {
            get { return Convert.ToDecimal(_membershipFeeTextBox.Text); }
            set { _membershipFeeTextBox.Text = value.ToString("N2"); }
        }

        public decimal Others
        {
            get { return Convert.ToDecimal(_othersTextBox.Text); }
            set { _othersTextBox.Text = value.ToString("N2"); }
        }

        public bool IsThereServiceReceipt
        {
            get { return _acceptButton.Enabled; }
            set { _acceptButton.Enabled = value; }
        }

        #endregion

        #region IServicesAdapter Members

        bool IServicesAdapter.ApplianceLoan
        {
            get { return _applienceLoanAddButton.Enabled; }
            set { _applienceLoanAddButton.Enabled = value; }
        }

        bool IServicesAdapter.EasyLoan
        {
            get { return _easyLoanAddButton.Enabled; }
            set { _easyLoanAddButton.Enabled = value; }
        }

        bool IServicesAdapter.EmergencyLoan
        {
            get { return _emergencyLoanAddButton.Enabled; }
            set { _emergencyLoanAddButton.Enabled = value; }
        }

        bool IServicesAdapter.EquityLoan
        {
            get { return _equityLoanAddButton.Enabled; }
            set { _equityLoanAddButton.Enabled = value; }
        }

        bool IServicesAdapter.PensionLoan
        {
            get { return _pensionLoanAddButton.Enabled; }
            set { _pensionLoanAddButton.Enabled = value; }
        }

        bool IServicesAdapter.RegularLoan
        {
            get { return _regularLoanAddButton.Enabled; }
            set { _regularLoanAddButton.Enabled = value; }
        }

        bool IServicesAdapter.DTILoan
        {
            get;
            set;
        }

        bool IServicesAdapter.MEDPLoan
        {
            get;
            set;
        }

        bool IServicesAdapter.CollegeInsurancePlan
        {
            get { return _collegeInsurancePlanAddButton.Enabled; }
            set { _collegeInsurancePlanAddButton.Enabled = value; }
        }

        bool IServicesAdapter.PensionPlan
        {
            get { return !_pensionPlanAddButton.Enabled; }
            set { _pensionPlanAddButton.Enabled = value; }
        }

        bool IServicesAdapter.CapitalShare
        {
            get { return !_capitalShareTextBox.ReadOnly; }
            set { _capitalShareTextBox.ReadOnly = !value; }
        }

        bool IServicesAdapter.SavingsDeposit
        {
            get { return !_savingsDepositTextBox.ReadOnly; }
            set { _savingsDepositTextBox.ReadOnly = !value; }
        }

        bool IServicesAdapter.TimeDeposit
        {
            get { return _timeDepositAddButton.Enabled; }
            set { _timeDepositAddButton.Enabled = value; }
        }

        bool IServicesAdapter.DeathAidFund
        {
            get { return !_deathAidFundTextBox.ReadOnly; }
            set { _deathAidFundTextBox.ReadOnly = !value; }
        }

        bool IServicesAdapter.TulunganFund
        {
            get { return !_tulunganFundTextBox.ReadOnly; }
            set { _tulunganFundTextBox.ReadOnly = !value; }
        }

        #endregion

        #region Routine Helpers

        protected virtual void OnTransactionCommitted(EventArgs e)
        {
            RaiseTransactionCommittedEvent(this, e);
        }

        private void RaiseTransactionCommittedEvent(object sender, EventArgs e)
        {
            if (TransactionCommitted != null)
                TransactionCommitted.Invoke(sender, e);
        }

        private IList<TextBox> InputTextBoxes
        {
            get
            {
                if (_inputTextBoxes == null)
                {
                    _inputTextBoxes  = new List<TextBox>()
                        {
                            _savingsDepositTextBox,
                            _capitalShareTextBox,
                            _timeDepositTextBox,
                            _applianceLoanTextBox,
                            _easyLoanTextBox,
                            _emergencyLoanTextBox,
                            _equityLoanTextBox,
                            _pensionLoanTextBox,
                            _collegeInsurancePlanTextBox,
                            _pensionPlanTextBox,
                            _tulunganFundTextBox,
                            _deathAidFundTextBox,
                            _miscellaneousIncomeTextBox,
                            _membershipFeeTextBox,
                            _othersTextBox
                        };
                }

                return _inputTextBoxes;
            }
        }

        private void DisableFields()
        {
            _acceptButton.Enabled = false;
            _clearButton.Enabled = false;
            _receiptDateTimePicker.Enabled = false;
            _sequenceTextBox.Enabled = false;
            _restartReceiptCheckBox.Enabled = false;
            ((IServicesAdapter)this).SetValues(false);

            _miscellaneousIncomeTextBox.Enabled = false;
            _membershipFeeTextBox.Enabled = false;
            _othersTextBox.Enabled = false;
        }

        #endregion

        public CashReceiptView(IMemberInquiryDetailsView member, string userID)
        {
            InitializeComponent();

            _errorLogger = new ErrorLogger();
            _member = member;
            UserID = userID;
            ((IServicesAdapter)this).GetValuesFrom(_member.AvailedServices);

            // child instantiation goes here
            _childLoanPaymentView = new LoanPaymentView();
            _childTimeDepositDepositView = new TimeDepositDepositView();
            _childCIPView = new CIPPaymentView();
            _childPensionPlanView = new PensionPlanPaymentView();

            _presenter = new CashReceiptPresenter(this, _childLoanPaymentView, _childTimeDepositDepositView, _childCIPView, _childPensionPlanView);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_savingsDepositTextBox, InputType.Currency, false, "Savings Deposit", 16, 2);
            ControlValidator.RegisterControl(_capitalShareTextBox, InputType.Currency, false, "Capital Share", 16, 2);
            ControlValidator.RegisterControl(_timeDepositTextBox, InputType.Currency, false, "Time Deposit", 16, 2);

            ControlValidator.RegisterControl(_applianceLoanTextBox, InputType.Currency, false, "Appliance Loan", 16, 2);
            ControlValidator.RegisterControl(_easyLoanTextBox, InputType.Currency, false, "Easy Loan", 16, 2);
            ControlValidator.RegisterControl(_emergencyLoanTextBox, InputType.Currency, false, "Emergency Loan", 16, 2);
            ControlValidator.RegisterControl(_equityLoanTextBox, InputType.Currency, false, "Equity Loan", 16, 2);
            ControlValidator.RegisterControl(_pensionLoanTextBox, InputType.Currency, false, "Pension Loan", 16, 2);

            ControlValidator.RegisterControl(_collegeInsurancePlanTextBox, InputType.Currency, false, "College Insurance Plan", 16, 2);
            ControlValidator.RegisterControl(_pensionPlanTextBox, InputType.Currency, false, "Pension Plan", 16, 2);

            ControlValidator.RegisterControl(_tulunganFundTextBox, InputType.Currency, false, "Tulungan Fund", 16, 2);
            ControlValidator.RegisterControl(_deathAidFundTextBox, InputType.Currency, false, "Death Aid Fund", 16, 2);

            ControlValidator.RegisterControl(_miscellaneousIncomeTextBox, InputType.Currency, false, "Miscellaneous Income", 16, 2);
            ControlValidator.RegisterControl(_membershipFeeTextBox, InputType.Currency, false, "Membership Fee", 16, 2);
            ControlValidator.RegisterControl(_othersTextBox, InputType.Currency, false, "Others", 16, 2);
        }

        private void LoansAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                string serviceID;
                if (sender == _applienceLoanAddButton)
                    serviceID = ServiceCodes.ApplianceLoan;
                else if (sender == _easyLoanAddButton)
                    serviceID = ServiceCodes.EasyLoan;
                else if (sender == _emergencyLoanAddButton)
                    serviceID = ServiceCodes.EmergencyLoan;
                else if (sender == _equityLoanAddButton)
                    serviceID = ServiceCodes.EquityLoan;
                else if (sender == _pensionLoanAddButton)
                    serviceID = ServiceCodes.PensionLoan;
                else if (sender == _regularLoanAddButton)
                    serviceID = ServiceCodes.RegularLoan;
                else
                    throw new Exception(string.Format("Implementation for {0} not yet defined.", ((Button)sender).Name));

                _childLoanPaymentView.LoanServiceID = serviceID;
                _childLoanPaymentView.MemberID = _member.MemberID;
                _childLoanPaymentView.ShowDialog(this);
            }
            catch (Exception ex)
            {
                _errorLogger.Log(ex.ToString());
            }
        }

        private void SavingsAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender == _timeDepositAddButton)
                {
                    _childTimeDepositDepositView.DepositDate = _receiptDateTimePicker.Value;
                    _childTimeDepositDepositView.ShowDialog(this);
                }
                else
                {
                    throw new Exception(string.Format("Implementation for {0} not yet defined.", ((Button)sender).Name));
                }
            }
            catch (Exception ex)
            {
                _errorLogger.Log(ex.ToString());
            }
        }

        private void PlansAddButton_Click(object sender, EventArgs e)
        {
            try 
            {
                if (sender == _collegeInsurancePlanAddButton)
                {
                    _childCIPView.MemberID = MemberID;
                    _childCIPView.ShowDialog(this);
                }
                else if (sender == _pensionPlanAddButton)
                {
                    _childPensionPlanView.MemberID = MemberID;
                    _childPensionPlanView.ShowDialog(this);
                }
                else
                {
                    throw new Exception(string.Format("Implementation for {0} not yet defined.", ((Button)sender).Name));
                }
            }
            catch (Exception ex)
            {
                _errorLogger.Log(ex.ToString());
            }
        }

        private void SpecialFundsAddButton_Click(object sender, EventArgs e)
        {
            try 
            {
                //SpecialFundType sft;
                //if (sender == _deathAidFundAddButton)
                //    sft = SpecialFundType.DeathAidFund;
                //else if (sender == _tulunganFundAddButton)
                //    sft = SpecialFundType.TulunganFund;
                //else
                //    throw new Exception(string.Format("Implementation for {0} not yet defined.", ((Button)sender).Name));

                //using (var sff = new SpecialFunds.Factories.ContributionFormFactory().CreateForm(sft))
                //    sff.ShowDialog(this);
            }
            catch (Exception ex)
            {
                _errorLogger.Log(ex.ToString());
            }
        }

        private void CashReceiptView_Shown(object sender, EventArgs e)
        {
            _presenter.Load();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            _presenter.Clear();
        }

        private void InputChanged(object sender, EventArgs e)
        {
            Func<TextBox, bool> HasValue = textBox => 
            {
                var amount = 0M;
                var validationResult = decimal.TryParse(textBox.Text, out amount);
                return (amount != 0M);
            };

            IsThereServiceReceipt = InputTextBoxes.Where(tb => HasValue(tb)).Any();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsThereServiceReceipt)
                {
                    NotifyInformation(this, "You haven't inputed any payment. Please input payment amount.");
                    return;
                }

                if (!ControlValidator.Validate())
                    return;

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

        private void RestartReceiptCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var restart = ((CheckBox)sender).Checked;

            _generateReceiptButton.Enabled = restart;
            _sequenceTextBox.Enabled = restart;
            _sequenceTextBox.Text = string.Empty;
            _sequenceTextBox.Select();
        }

        private void GenerateReceiptButton_Click(object sender, EventArgs e)
        {
            if (_presenter.GenerateReceiptNumber())
                _restartReceiptCheckBox.Checked = false;
        }
    }
}
