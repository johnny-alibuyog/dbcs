using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.Plans.PensionPlan;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Plans.PensionPlan
{
    public partial class PensionPlanWithdrawalAssessmentView : WithdrawalAssessmentFormTemplate, IPensionPlanWithdrawalAssessmentView
    {
        private PensionPlanWithdrawalAssessmentPresenter _presenter;

        #region Routine Helpers

        protected virtual void OnAssessmentAdd(EventArgs e)
        {
            RaiseAssessmentAdd(this, e);
        }

        private void RaiseAssessmentAdd(object sender, EventArgs e)
        {
            if (AssessmentAdd != null)
                AssessmentAdd.Invoke(sender, e);
        }

        #endregion

        #region IPensionPlanWithdrawalAssessmentView Members

        public event EventHandler AssessmentAdd;

        public bool IsAssessed
        {
            get { return _acceptButton.Enabled; }
            set { _acceptButton.Enabled = value; }
        }

        public long MemberID { get; set; }

        public string AvailOption
        {
            set { _availOptionTextBox.Text = value; }
        }

        public DateTime? ApplicationDate
        {
            set { _applicationDateTextBox.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
        }

        public DateTime? PaymentCompeletionDate
        {
            set { _paymentCompletionDateTextBox.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
        }

        public DateTime? MaturityDate
        {
            get { return string.IsNullOrWhiteSpace(_maturityDateTextBox.Text) == false ? new Nullable<DateTime>(Convert.ToDateTime(_maturityDateTextBox.Text)) : null; }
            set { _maturityDateTextBox.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
        }

        public decimal PaymentCompletionAmount
        {
            get { return Convert.ToDecimal(_paymentCompletionAmountTextBox.Text); }
            set { _paymentCompletionAmountTextBox.Text = value.ToString("N2"); }
        }

        public decimal AwardAmount
        {
            set { _awardAmountTextBox.Text = value.ToString("N2"); }
        }

        public decimal PayedAmount
        {
            get { return Convert.ToDecimal(_payedAmountTextBox.Text); }
            set { _payedAmountTextBox.Text = value.ToString("N2"); }
        }

        public decimal Interests
        {
            set { _interestsTextBox.Text = value.ToString("N2"); }
        }

        public decimal DisbursedAmount
        {
            set { _disbursedAmountTextBox.Text = value.ToString("N2"); }
        }

        public decimal MaximumWithdrawableAmount
        {
            get { return Convert.ToDecimal(_maximumWithdrawableAmountTextBox.Text); }
            set { _maximumWithdrawableAmountTextBox.Text = value.ToString("N2"); }
        }

        public decimal WithdrawAmount
        {
            get { return Convert.ToDecimal(_withdrawAmountTextBox.Text); }
            set { _withdrawAmountTextBox.Text = value.ToString("N2"); }
        }

        #endregion

        public PensionPlanWithdrawalAssessmentView()
        {
            InitializeComponent();

            _presenter = new PensionPlanWithdrawalAssessmentPresenter(this);
            _presenter.Error += new CooperativeSystem.Service.Presenters.ErrorHandler(NotifyError);
            _presenter.Success += new CooperativeSystem.Service.Presenters.SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_withdrawAmountTextBox, InputType.Currency, true, "Withdraw Amount", 16, 2);
        }

        private void PensionPlanWithdrawalAssessmentView_Shown(object sender, EventArgs e)
        {
            IsAssessed = _presenter.Load();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ControlValidator.Validate())
                    return;

                OnAssessmentAdd(new EventArgs());
                Close();
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }
    }
}
