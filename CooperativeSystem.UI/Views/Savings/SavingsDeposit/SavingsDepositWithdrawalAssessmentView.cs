using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.Savings.SavingsDeposit;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Savings.SavingsDeposit
{
    public partial class SavingsDepositWithdrawalAssessmentView : FormTemplate, ISavingsDepositWithdrawalAssessmentView
    {
        private SavingsDepositWithdrawalAssessmentPresenter _presenter;

        public SavingsDepositWithdrawalAssessmentView()
        {
            InitializeComponent();

            _presenter = new SavingsDepositWithdrawalAssessmentPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_withdrawAmountTextBox, InputType.Currency, true, "Withdraw Amount", 16, 2);
        }

        #region ISavingsDepositWithdrawalAssessmentView Members

        public event EventHandler AssessmentAdd;

        public bool IsAssessed
        {
            get { return _acceptButton.Enabled; }
            set { _acceptButton.Enabled = value; }
        }

        public long MemberID { get; set; }

        public decimal CurrentBalance
        {
            get { return Convert.ToDecimal(_currentBalanceTextBox.Text); }
            set { _currentBalanceTextBox.Text = value.ToString("N2"); }
        }

        public decimal WithdrawAmount
        {
            get { return Convert.ToDecimal(_withdrawAmountTextBox.Text); }
            set { _withdrawAmountTextBox.Text = value.ToString("N2"); }
        }

        #endregion

        #region Routine Helpers

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

        private void SavingsDepositWithdrawalAssessmentView_Shown(object sender, EventArgs e)
        {
            IsAssessed = _presenter.Load();
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
    }
}
