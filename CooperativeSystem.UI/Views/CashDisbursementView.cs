using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Members;
using CooperativeSystem.Service.Utilities.Logs;
using CooperativeSystem.UI.Views.Loans;
using CooperativeSystem.UI.Views.Plans;
using CooperativeSystem.UI.Views.Plans.CollegeInsurancePlan;
using CooperativeSystem.UI.Views.Plans.PensionPlan;
using CooperativeSystem.UI.Views.Savings;
using CooperativeSystem.UI.Views.Savings.CapitalShare;
using CooperativeSystem.UI.Views.Savings.SavingsDeposit;
using CooperativeSystem.UI.Views.Savings.TimeDeposit;
using CooperativeSystem.UI.Views.SpecialFunds;
using CooperativeSystem.UI.Views.SpecialFunds.DeathAidFund;
using CooperativeSystem.UI.Views.SpecialFunds.TulunganFund;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views
{
    public partial class CashDisbursementView : FormTemplate, ICashDisbursementView, IServicesAdapter
    {
        public event EventHandler TransactionCommitted;

        private CashDisbursementPresenter _presenter;

        private LoanAssessmentView _childLoanAssessmentView;
        private CIPWithdrawalAssessmentView _childCIPAssessmentView;
        private PensionPlanWithdrawalAssessmentView _childPensionPlanView;
        private TimeDepositWithdrawalAssessmentView _childTimeDepositView;
        private CapitalShareWithdrawalAssessmentView _childCapitalShareView;
        private SavingsDepositWithdrawalAssessmentView _childSavingsDepositView;
        private DeathAidFundWithdrawalAssessmentView _childDeathAidFundView;
        private TulunganFundWithdrawalAssessmentView _childTulunganFundView;

        private IMemberInquiryDetailsView _member;
        private ErrorLogger _errorLogger;

        #region IServicesAdapter Members

        bool IServicesAdapter.ApplianceLoan
        {
            get { return _applienceLoanAssessButton.Enabled; }
            set { _applienceLoanAssessButton.Enabled = value; }
        }

        bool IServicesAdapter.EasyLoan
        {
            get { return _easyLoanAssessButton.Enabled; }
            set { _easyLoanAssessButton.Enabled = value; }
        }

        bool IServicesAdapter.EmergencyLoan
        {
            get { return _emergencyLoanAssessButton.Enabled; }
            set { _emergencyLoanAssessButton.Enabled = value; }
        }

        bool IServicesAdapter.EquityLoan
        {
            get { return _equityLoanAssessButton.Enabled; }
            set { _equityLoanAssessButton.Enabled = value; }
        }

        bool IServicesAdapter.PensionLoan
        {
            get { return _pensionLoanAssessButton.Enabled; }
            set { _pensionLoanAssessButton.Enabled = value; }
        }

        bool IServicesAdapter.RegularLoan
        {
            get { return _regularLoanAssessButton.Enabled; }
            set { _regularLoanAssessButton.Enabled = value; }
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
            get { return _collegeInsurancePlanAssessButton.Enabled; }
            set { _collegeInsurancePlanAssessButton.Enabled = value; }
        }

        bool IServicesAdapter.PensionPlan
        {
            get { return _pensionPlanAssessButton.Enabled; }
            set { _pensionPlanAssessButton.Enabled = value; }
        }

        bool IServicesAdapter.CapitalShare
        {
            get { return _capitalShareAssessButton.Enabled; }
            set { _capitalShareAssessButton.Enabled = value; }
        }

        bool IServicesAdapter.SavingsDeposit
        {
            get { return _savingsDepositAssessButton.Enabled; }
            set { _savingsDepositAssessButton.Enabled = value; }
        }

        bool IServicesAdapter.TimeDeposit
        {
            get { return _timeDepositAssessButton.Enabled; }
            set { _timeDepositAssessButton.Enabled = value; }
        }

        bool IServicesAdapter.DeathAidFund
        {
            get { return _deathAidFundAssessButton.Enabled; }
            set { _deathAidFundAssessButton.Enabled = value; }
        }

        bool IServicesAdapter.TulunganFund
        {
            get { return _tulunganFundAssessButton.Enabled; }
            set { _tulunganFundAssessButton.Enabled = value; }
        }

        #endregion

        #region ICashDisbursementView Members

        public long MemberID
        {
            get { return _member.MemberID; }
        }

        public string UserID { get; set; }

        public DateTime DisbursementDate
        {
            get { return _disbursementDateDateTimePicker.Value; }
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

        public bool IsThereServiceAssessed 
        {
            get { return _acceptButton.Enabled; }
            set { _acceptButton.Enabled = value; }
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

        #endregion

        public CashDisbursementView(IMemberInquiryDetailsView member, string userID)
        {
            InitializeComponent();

            _errorLogger = new ErrorLogger();
            _member = member;
            UserID = userID;
            ((IServicesAdapter)this).GetValuesFrom(_member.AvailedServices);

            _childLoanAssessmentView = new LoanAssessmentView();
            _childCIPAssessmentView = new CIPWithdrawalAssessmentView();
            _childPensionPlanView = new PensionPlanWithdrawalAssessmentView();
            _childTimeDepositView = new TimeDepositWithdrawalAssessmentView();
            _childCapitalShareView = new CapitalShareWithdrawalAssessmentView();
            _childSavingsDepositView = new SavingsDepositWithdrawalAssessmentView();
            _childTulunganFundView = new TulunganFundWithdrawalAssessmentView();
            _childDeathAidFundView = new DeathAidFundWithdrawalAssessmentView();

            _presenter = new CashDisbursementPresenter(this, _childLoanAssessmentView,
                _childCIPAssessmentView, _childPensionPlanView, _childTimeDepositView,
                _childCapitalShareView, _childSavingsDepositView, _childTulunganFundView,
                _childDeathAidFundView);

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

        private void SavingsAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender == _capitalShareAssessButton)
                {
                    _childCapitalShareView.MemberID = MemberID;
                    _childCapitalShareView.ShowDialog(this);
                }
                else if (sender == _savingsDepositAssessButton)
                {
                    _childSavingsDepositView.MemberID = MemberID;
                    _childSavingsDepositView.ShowDialog(this);
                }
                else if (sender == _timeDepositAssessButton)
                {
                    _childTimeDepositView.MemberID = MemberID;
                    _childTimeDepositView.ShowDialog(this);
                }
                else
                {
                    throw new Exception(string.Format("Implementation for {0} not yet defined.", ((Button)sender).Name));
                }
            }
            catch (Exception ex)
            {
                _errorLogger.Log(ex.Message);
            }
        }

        private void LoanAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                #region Routine Helpers

                Func<string, bool> ThereAnyOtherLoansThan = (loanServiceID) =>
                    {
                        var loanDisbursements = new Dictionary<string, decimal>();
                        loanDisbursements.Add(ServiceCodes.ApplianceLoan, this.ApplianceLoan);
                        loanDisbursements.Add(ServiceCodes.EasyLoan, this.EasyLoan);
                        loanDisbursements.Add(ServiceCodes.EmergencyLoan, this.EmergencyLoan);
                        loanDisbursements.Add(ServiceCodes.EquityLoan, this.EquityLoan);
                        loanDisbursements.Add(ServiceCodes.PensionLoan, this.PensionLoan);
                        loanDisbursements.Add(ServiceCodes.RegularLoan, this.RegularLoan);
                        loanDisbursements.Add(ServiceCodes.DTILoan, this.DTILoan);
                        loanDisbursements.Add(ServiceCodes.MEDPLoan, this.MEDPLoan);

                        var result = loanDisbursements
                            .Where(x =>
                                x.Key != loanServiceID &&
                                x.Value != 0M)
                            .Any();

                        return result;
                    };

                #endregion

                string serviceID;
                if (sender == _applienceLoanAssessButton)
                    serviceID = ServiceCodes.ApplianceLoan;
                else if (sender == _easyLoanAssessButton)
                    serviceID = ServiceCodes.EasyLoan;
                else if (sender == _emergencyLoanAssessButton)
                    serviceID = ServiceCodes.EmergencyLoan;
                else if (sender == _equityLoanAssessButton)
                    serviceID = ServiceCodes.EquityLoan;
                else if (sender == _pensionLoanAssessButton)
                    serviceID = ServiceCodes.PensionLoan;
                else if (sender == _regularLoanAssessButton)
                    serviceID = ServiceCodes.RegularLoan;
                else
                    throw new Exception(string.Format("Implementation for {0} not yet defined.", ((Button)sender).Name));

                if (ThereAnyOtherLoansThan(serviceID))
                {
                    NotifyError(this, "You can only disburse one Loan at a time.");
                    return;
                }

                _childLoanAssessmentView.LoanServiceID = serviceID;
                _childLoanAssessmentView.MemberID = _member.MemberID;
                _childLoanAssessmentView.LoanDate = _disbursementDateDateTimePicker.Value;
                _childLoanAssessmentView.ShowDialog(this);
            }
            catch (Exception ex)
            {
                _errorLogger.Log(ex.Message);
            }
        }

        private void PlansAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender == _collegeInsurancePlanAssessButton)
                {
                    _childCIPAssessmentView.MemberID = MemberID;
                    _childCIPAssessmentView.ShowDialog(this);
                }
                else if (sender == _pensionPlanAssessButton)
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
                _errorLogger.Log(ex.Message);
            }
        }

        private void SpecialFundsAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender == _deathAidFundAssessButton)
                {
                    _childDeathAidFundView.MemberID = MemberID;
                    _childDeathAidFundView.ShowDialog(this);
                }
                else if (sender == _tulunganFundAssessButton)
                {
                    _childTulunganFundView.MemberID = MemberID;
                    _childTulunganFundView.ShowDialog(this);
                }
                else
                {
                    throw new Exception(string.Format("Implementation for {0} not yet defined.", ((Button)sender).Name));
                }

                //SpecialFundType sft;
                //if (sender == _deathAidFundAssessButton)
                //    sft = SpecialFundType.DeathAidFund;
                //else if (sender == _tulunganFundAssessButton)
                //    sft = SpecialFundType.TulunganFund;
                //else
                //    throw new Exception(string.Format("Implementation for {0} not yet defined.", ((Button)sender).Name));

                //using (var waf = new SpecialFunds.Factories.WithdrawalAssessmentFormFactory().CreateForm(sft))
                //    waf.ShowDialog(this);
            }
            catch (Exception ex)
            {
                _errorLogger.Log(ex.Message);
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsThereServiceAssessed)
                {
                    NotifyInformation(this, "You have not perform any assessment yet. Please perform assessment first.");
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
            catch(Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }

        private void DisableFields()
        {
            _acceptButton.Enabled = false;
            _clearButton.Enabled = false;
            _disbursementDateDateTimePicker.Enabled = false;
            _sequenceTextBox.Enabled = false;
            _restartVoucherCheckBox.Enabled = false;
            ((IServicesAdapter)this).SetValues(false);
        }

        private void CashDisbursementView_Shown(object sender, EventArgs e)
        {
            _restartVoucherCheckBox.Checked = false;
            _presenter.Load();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            _restartVoucherCheckBox.Checked = false;
            _presenter.Clear();
        }

        private void InputTextBox_Enter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
                textBox.BackColor = SystemColors.Window;
        }

        private void InputTextBox_Leave(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
                textBox.BackColor = SystemColors.Control;
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
    }
}
