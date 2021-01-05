using System;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Savings.TimeDeposit;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Savings.TimeDeposit
{
    public partial class InterestRateView : InterestRateFormTemplate, IInterestRateView
    {
        InterestRatePresenter _presenter;

        #region IInterestRateView Members

        public decimal BelowFiftyThousand
        {
            get { return Convert.ToDecimal(_below50000TextBox.Text); }
            set { _below50000TextBox.Text = value.ToString(); }
        }

        public decimal FiftyToNinetyNineThousand
        {
            get { return Convert.ToDecimal(_50000to99000TextBox.Text); }
            set { _50000to99000TextBox.Text = value.ToString(); }
        }

        public decimal AboveNinetyNineThousand
        {
            get { return Convert.ToDecimal(_above99000TextBox.Text); }
            set { _above99000TextBox.Text = value.ToString(); }
        }

        #endregion
        
        public InterestRateView()
        {
            InitializeComponent();
            _presenter = new InterestRatePresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            // register controls to validate
            ControlValidator.RegisterControl(_below50000TextBox, InputType.DecimalOnly, true, "Below 50,000.00", 5, 2);
            ControlValidator.RegisterControl(_50000to99000TextBox, InputType.DecimalOnly, true, "50.000.00 to 99,000.00", 5, 2);
            ControlValidator.RegisterControl(_above99000TextBox, InputType.DecimalOnly, true, "Above 99,000.00", 5, 2);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (!ControlValidator.Validate())
                return;

            if (AskConfirmation(this, "Do you want to modify?") != DialogResult.Yes)
                return;

            _presenter.Update();
        }

        private void InterestRateView_Shown(object sender, EventArgs e)
        {
            _presenter.Populate();
        }
    }
}
