using System;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Loans.DTILoan;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;


namespace CooperativeSystem.UI.Views.Loans.DTILoan
{
    public partial class ServiceRateView : ServiceRateFormTemplate, IServiceRateView
    {
        ServiceRatePresenter _presenter;

        #region IServiceRateView Members

        public decimal ServiceFeeRate
        {
            get { return Convert.ToDecimal(_serviceFeeRateTextBox.Text); }
            set { _serviceFeeRateTextBox.Text = value.ToString(); }
        }

        public decimal CollectionFeeRate
        {
            get { return Convert.ToDecimal(_collectionFeeRateTextBox.Text); }
            set { _collectionFeeRateTextBox.Text = value.ToString(); }
        }

        public decimal LoanGuaranteeFundRate
        {
            get { return Convert.ToDecimal(_loanGuaranteeFundRateTextBox.Text); }
            set { _loanGuaranteeFundRateTextBox.Text = value.ToString(); }
        }

        public decimal CapitalBuildupRate
        {
            get { return Convert.ToDecimal(_capitalBuildupRateTextBox.Text); }
            set { _capitalBuildupRateTextBox.Text = value.ToString(); }
        }

        public decimal InterestRate
        {
            get { return Convert.ToDecimal(_interestRateTextBox.Text); }
            set { _interestRateTextBox.Text = value.ToString(); }
        }

        #endregion

        public ServiceRateView()
        {
            InitializeComponent();
            _presenter = new ServiceRatePresenter(this);
            _presenter.Success += new SuccessHandler(NotifyInformation);
            _presenter.Error += new ErrorHandler(NotifyError);

            // register controls to validate
            ControlValidator.RegisterControl(_interestRateTextBox, InputType.DecimalOnly, true, "Interest Rate", 5, 2);
            ControlValidator.RegisterControl(_capitalBuildupRateTextBox, InputType.DecimalOnly, true, "Capital Build-up Rate", 5, 2);
            ControlValidator.RegisterControl(_loanGuaranteeFundRateTextBox, InputType.DecimalOnly, true, "Loan Guarantee Fund Rate", 5, 3);
            ControlValidator.RegisterControl(_collectionFeeRateTextBox, InputType.DecimalOnly, true, "Collection Fee Rate", 5, 2);
            ControlValidator.RegisterControl(_serviceFeeRateTextBox, InputType.DecimalOnly, true, "Service Fee Rate", 5, 2);
        }

        private void ServiceRateView_Shown(object sender, EventArgs e)
        {
            _presenter.Populate();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (ControlValidator.Validate())
                _presenter.Update();
        }
    }
}