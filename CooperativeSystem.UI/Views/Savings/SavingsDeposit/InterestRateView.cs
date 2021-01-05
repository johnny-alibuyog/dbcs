using System;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Savings.SavingsDeposit;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Savings.SavingsDeposit
{
    public partial class InterestRateView : InterestRateFormTemplate, IInterestRateView
    {
        InterestRatePresenter _presenter;

        #region IInterestRateView Members

        public decimal InterestRate
        {
            get { return Convert.ToDecimal(_interestRateTextBox.Text); }
            set { _interestRateTextBox.Text = value.ToString(); }
        }

        #endregion

        public InterestRateView()
        {
            InitializeComponent();

            _presenter = new InterestRatePresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            // register controls to validate
            ControlValidator.RegisterControl(_interestRateTextBox, InputType.DecimalOnly, true, "Interest Rate", 5, 2);
        }

        private void InterestRateView_Shown(object sender, EventArgs e)
        {
            _presenter.Populate();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (!ControlValidator.Validate())
                return;

            if (AskConfirmation(this, "Do you want to modify?") != DialogResult.Yes)
                return;

            _presenter.Update();
        }
    }
}
