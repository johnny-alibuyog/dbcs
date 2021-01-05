using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;
using CooperativeSystem.Service.Presenters.Lookups.PaymentModes;

namespace CooperativeSystem.UI.Views.Plans.CollegeInsurancePlan
{
    public enum CIPAction
    {
        Enroll,
        Modify,
        View
    }

    public partial class CIPEnrollmentView : FormTemplate, ICIPEnrollmentView
    {
        private CIPEnrollmentPresenter _presenter;
        private CIPAction _action;

        public CIPEnrollmentView()
        {
            InitializeComponent();

            _presenter = new CIPEnrollmentPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_userLastNameTextBox, InputType.Normal, true, "User Last Name", 30);
            ControlValidator.RegisterControl(_userFirstNameTextBox, InputType.Normal, true, "User First Name", 30);
            ControlValidator.RegisterControl(_userMiddleNameTextBox, InputType.Normal, false, "User Middle Name", 30);
            ControlValidator.RegisterControl(_addressTextBox, InputType.Normal, true, "Address", 80);
            ControlValidator.RegisterControl(_amortizationTextBox, InputType.DecimalOnly, true, "Amortization", 16, 2);
            ControlValidator.RegisterControl(_paymentCompletionAmountTextBox, InputType.DecimalOnly, true, "Maturity Amount", 16, 2);
            ControlValidator.RegisterControl(_awardAmountTextBox, InputType.DecimalOnly, true, "Award Amount", 16, 2);
        }

        public bool SetAction(CIPAction action)
        {
            return SetAction(action, 0);
        }

        public bool SetAction(CIPAction action, long collegeInsurancePlanID)
        {
            _action = action;
            switch (_action)
            {
                case CIPAction.Enroll:
                    InitializeInputFields(false, "&Enroll");
                    _presenter.Clear();
                    break;
                case CIPAction.Modify:
                    InitializeInputFields(false, "&Update");
                    _presenter.Load(collegeInsurancePlanID);
                    break;
                case CIPAction.View:
                    InitializeInputFields(true, string.Empty);
                    _presenter.Load(collegeInsurancePlanID);
                    break;
            }
            return true;
        }

        #region Routine Helpers

        private void OnModify(EventArgs e)
        {
            RaiseModifyEvent(this, e);
        }

        private void RaiseModifyEvent(object sender, EventArgs e)
        {
            if (Modify != null)
                Modify.Invoke(sender, e);
        }

        protected virtual void OnEnroll(EventArgs e)
        {
            RaiseEnrollEvent(this, e);
        }

        private void RaiseEnrollEvent(object sender, EventArgs e)
        {
            if (Enroll != null)
                Enroll.Invoke(sender, e);
        }

        private void InitializeInputFields(bool readOnly)
        {
            InitializeInputFields(readOnly, null);
        }

        private void InitializeInputFields(bool readOnly, string acceptButtonText)
        {
            _acceptButton.Enabled = !readOnly;

            if (!string.IsNullOrEmpty(acceptButtonText))
                _acceptButton.Text = acceptButtonText;

            _userLastNameTextBox.ReadOnly = readOnly;
            _userFirstNameTextBox.ReadOnly = readOnly;
            _userMiddleNameTextBox.ReadOnly = readOnly;
            _dateOfBirthdateTimePicker.Enabled = !readOnly;
            _relationComboBox.Enabled = !readOnly;
            _addressTextBox.ReadOnly = readOnly;

            _applicationDateDateTimePicker.Enabled = !readOnly;
            _paymentModeComboBox.Enabled = !readOnly;
            _termsNumericUpDown.ReadOnly = readOnly;
            _agingPeriodNumericUpDown.ReadOnly = readOnly;
            _amortizationTextBox.ReadOnly = true;
            _paymentCompletionAmountTextBox.ReadOnly = true;
            _awardAmountTextBox.ReadOnly = true;
        }

        //private bool ClearEnrollmentViewValues()
        //{
        //    CollegeInsurancePlanID = 0;
        //    UserLastName = string.Empty;
        //    UserFirstName = string.Empty;
        //    UserMiddleName = string.Empty;
        //    DateOfBirth = DateTime.Today;
        //    Relation = null;
        //    Address = string.Empty;

        //    ApplicationDate = DateTime.Today;
        //    PaymentMode = new PaymentMode() { PaymentModeID = PaymentModeCodes.Daily };
        //    Terms = 5;
        //    AgingPeriod = 5;
        //    PaymentCompletionAmount = 0M;
        //    AwardAmount = 0M;

        //    return true;
        //}

        //private bool SetEnrollmentViewValues(CooperativeSystem.Service.Models.CollegeInsurancePlan entity)
        //{
        //    CollegeInsurancePlanID = entity.CollegeInsurancePlanID;
        //    MemberID = entity.MemberID;

        //    UserLastName = entity.UserLastName;
        //    UserFirstName = entity.UserFirstName;
        //    UserMiddleName = entity.UserMiddleName;
        //    DateOfBirth = entity.DateOfBirth;
        //    Relation = entity.Relation;
        //    Address = entity.Address;

        //    ApplicationDate = entity.ApplicationDate;
        //    PaymentMode = entity.PaymentMode;
        //    Terms = entity.Terms;
        //    AgingPeriod = entity.AgingPeriod;
        //    Amortization = entity.Amortization;
        //    PaymentCompletionAmount = entity.PaymentCompletionAmount;
        //    AwardAmount = entity.AwardAmount;

        //    return true;
        //}

        #endregion

        #region ICIPEnrollmentView Members

        public event EventHandler Enroll;

        public event EventHandler Modify;

        public long CollegeInsurancePlanID { get; set; }

        public long MemberID { get; set; }

        public string UserLastName
        {
            get { return _userLastNameTextBox.Text; }
            set { _userLastNameTextBox.Text = value; }
        }

        public string UserFirstName
        {
            get { return _userFirstNameTextBox.Text; }
            set { _userFirstNameTextBox.Text = value; }
        }

        public string UserMiddleName
        {
            get { return _userMiddleNameTextBox.Text; }
            set { _userMiddleNameTextBox.Text = value; }
        }

        public DateTime? DateOfBirth
        {
            get { return _dateOfBirthdateTimePicker.Value; }
            set { _dateOfBirthdateTimePicker.Value = value != null ? value.Value : DateTime.Today; }
        }

        public string Address
        {
            get { return _addressTextBox.Text; }
            set { _addressTextBox.Text = value; }
        }

        public Relation Relation
        {
            get { return (Relation)_relationComboBox.SelectedItem; }
            set { _relationComboBox.SelectedItem = value; }
        }

        public DateTime ApplicationDate
        {
            get { return _applicationDateDateTimePicker.Value; }
            set { _applicationDateDateTimePicker.Value = value; }
        }

        public PaymentMode PaymentMode
        {
            get { return (PaymentMode)_paymentModeComboBox.SelectedItem; }
            set { _paymentModeComboBox.SelectedValue = value.PaymentModeID; }
        }

        public int Terms
        {
            get { return (int)_termsNumericUpDown.Value; }
            set { _termsNumericUpDown.Value = value; }
        }

        public int AgingPeriod
        {
            get { return (int)_agingPeriodNumericUpDown.Value; }
            set { _agingPeriodNumericUpDown.Value = value; }
        }

        public decimal Amortization
        {
            get { return Convert.ToDecimal(_amortizationTextBox.Text); }
            set { _amortizationTextBox.Text = value.ToString("N2"); }
        }

        public decimal PaymentCompletionAmount
        {
            get { return Convert.ToDecimal(_paymentCompletionAmountTextBox.Text); }
            set { _paymentCompletionAmountTextBox.Text = value.ToString("N2"); }
        }

        public decimal AwardAmount
        {
            get { return Convert.ToDecimal(_awardAmountTextBox.Text); }
            set { _awardAmountTextBox.Text = value.ToString("N2"); }
        }

        public void PopulateRelationPulldown(IList<Relation> relations)
        {
            _relationComboBox.DataSource = relations;
            _relationComboBox.DisplayMember = "RelationName";
            _relationComboBox.ValueMember = "RelationID";
        }

        public void PopulatePaymentModePulldown(IList<PaymentMode> paymentModes)
        {
            _paymentModeComboBox.DataSource = paymentModes;
            _paymentModeComboBox.DisplayMember = "PaymentModeName";
            _paymentModeComboBox.ValueMember = "PaymentModeID";
        }

        #endregion

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_action)
                {
                    case CIPAction.Enroll:
                        OnEnroll(new EventArgs());
                        NotifyInformation(this, "Successful enrolling.");
                        break;
                    case CIPAction.Modify:
                        OnModify(new EventArgs());
                        NotifyInformation(this, "Successful updating.");
                        break;
                    case CIPAction.View:
                        break;
                }
                Close();
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }

        private void PaymentModeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_presenter != null)
                _presenter.SyncronizeAmortization();
        }

        private void CIPEnrollmentView_Shown(object sender, EventArgs e)
        {
            //if (!_presenter.Validate())
            //    InitializeInputFields(readOnly: false);
        }
    }
}
