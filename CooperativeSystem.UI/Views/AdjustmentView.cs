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
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Members;
using CooperativeSystem.Service.Utilities.Logs;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;
using CooperativeSystem.UI.Views.Plans.CollegeInsurancePlan;

namespace CooperativeSystem.UI.Views
{
    public partial class AdjustmentView : FormTemplate, IAdjustmentView, IServicesAdapter
    {
        public event EventHandler TransactionCommitted;

        private AdjustmentPresenter _presenter;

        private CIPAdjustmentView _childCIPAdjustmentView;

        private IMemberInquiryDetailsView _member;
        private ErrorLogger _errorLogger;

        private IList<TextBox> _inputTextBoxes;

        #region IAdjustmentView Members

        public long MemberID
        {
            get { return _member.MemberID; }
        }

        public string UserID { get; set; }

        public DateTime AdjustmentDate
        {
            get { return _adjustmentDateTimePicker.Value; }
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

        public bool IsThereAdjustment
        {
            get { return _acceptButton.Enabled; }
            set { _acceptButton.Enabled = value; }
        }

        public bool IsLoadingDetails { get; set; }

        #endregion

        #region IServicesAdapter Members

        bool IServicesAdapter.ApplianceLoan
        {
            get { return _applianceLoanTextBox.Enabled; }
            set { _applianceLoanTextBox.Enabled = value; }
        }

        bool IServicesAdapter.EasyLoan
        {
            get { return _easyLoanTextBox.Enabled; }
            set { _easyLoanTextBox.Enabled = value; }
        }

        bool IServicesAdapter.EmergencyLoan
        {
            get { return _emergencyLoanTextBox.Enabled; }
            set { _emergencyLoanTextBox.Enabled = value; }
        }

        bool IServicesAdapter.EquityLoan
        {
            get { return _equityLoanTextBox.Enabled; }
            set { _equityLoanTextBox.Enabled = value; }
        }

        bool IServicesAdapter.PensionLoan
        {
            get { return _pensionLoanTextBox.Enabled; }
            set { _pensionLoanTextBox.Enabled = value; }
        }

        bool IServicesAdapter.RegularLoan
        {
            get { return _regularLoanTextBox.Enabled; }
            set { _regularLoanTextBox.Enabled = value; }
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
            get { return _collegeInsurancePlanAdjustButton.Enabled; }
            set { _collegeInsurancePlanAdjustButton.Enabled = value; }
        }

        bool IServicesAdapter.PensionPlan
        {
            get { return _pensionPlanTextBox.Enabled; }
            set { _pensionPlanTextBox.Enabled = value; }
        }

        bool IServicesAdapter.CapitalShare
        {
            get { return _capitalShareTextBox.Enabled; }
            set { _capitalShareTextBox.Enabled = value; }
        }

        bool IServicesAdapter.SavingsDeposit
        {
            get { return _savingsDepositTextBox.Enabled; }
            set { _savingsDepositTextBox.Enabled = value; }
        }

        bool IServicesAdapter.TimeDeposit
        {
            get { return _timeDepositTextBox.Enabled; }
            set { _timeDepositTextBox.Enabled = value; }
        }

        bool IServicesAdapter.DeathAidFund
        {
            get { return _deathAidFundTextBox.Enabled; }
            set { _deathAidFundTextBox.Enabled = value; }
        }

        bool IServicesAdapter.TulunganFund
        {
            get { return _tulunganFundTextBox.Enabled; }
            set { _tulunganFundTextBox.Enabled = value; }
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
                    _inputTextBoxes = new List<TextBox>()
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
                        };
                }

                return _inputTextBoxes;
            }
        }

        private void DisableFields()
        {
            _acceptButton.Enabled = false;
            _clearButton.Enabled = false;
            _adjustmentDateTimePicker.Enabled = false;
            _sequenceTextBox.Enabled = false;
            _restartVoucherCheckBox.Enabled = false;
            ((IServicesAdapter)this).SetValues(false);
        }

        #endregion

        public AdjustmentView(IMemberInquiryDetailsView member, string userID)
        {
            InitializeComponent();

            _errorLogger = new ErrorLogger();
            _member = member;
            UserID = userID;
            ((IServicesAdapter)this).GetValuesFrom(_member.AvailedServices);

            _childCIPAdjustmentView = new CIPAdjustmentView();

            _presenter = new AdjustmentPresenter(this, _childCIPAdjustmentView);
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
            ControlValidator.RegisterControl(_regularLoanTextBox, InputType.Currency, false, "Regular Loan", 16, 2);

            ControlValidator.RegisterControl(_collegeInsurancePlanTextBox, InputType.Currency, false, "College Insurance Plan", 16, 2);
            ControlValidator.RegisterControl(_pensionPlanTextBox, InputType.Currency, false, "Pension Plan", 16, 2);

            ControlValidator.RegisterControl(_tulunganFundTextBox, InputType.Currency, false, "Tulungan Fund", 16, 2);
            ControlValidator.RegisterControl(_deathAidFundTextBox, InputType.Currency, false, "Death Aid Fund", 16, 2);
        }

        private void InputChanged(object sender, EventArgs e)
        {
            if (IsLoadingDetails)
                return;

            IsThereAdjustment = true;
        }

        private void AdjustmentView_Shown(object sender, EventArgs e)
        {
            _restartVoucherCheckBox.Checked = false;
            _presenter.Load();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            _restartVoucherCheckBox.Checked = false;
            _presenter.Clear();
        }

        private void RestartVoucherCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var restart = ((CheckBox)sender).Checked;

            _generateVoucherButton.Enabled = restart;
            _sequenceTextBox.Enabled = restart;
            _sequenceTextBox.Text = string.Empty;
            _sequenceTextBox.Select();
        }

        private void GenerateVoucherButton_Click(object sender, EventArgs e)
        {
            if (_presenter.GenerateVoucherNumber())
                _restartVoucherCheckBox.Checked = false;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsThereAdjustment)
                {
                    NotifyInformation(this, "You have not perform any adjustment yet. Please perform adjustment first.");
                    return;
                }

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

        private void CollegeInsurancePlanChangeButton_Click(object sender, EventArgs e)
        {
            _childCIPAdjustmentView.MemberID = _member.MemberID;
            _childCIPAdjustmentView.ShowDialog(this);
        }

        private void AdjustmentView_Load(object sender, EventArgs e)
        {

        }
    }
}
