using System;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Loans.ApplianceLoan;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Loans.ApplianceLoan
{
    public partial class ServiceRateView : ServiceRateFormTemplate, IServiceRateView
    {
        private ServiceRatePreseter _presenter;

        #region IServiceRateView Members

        public decimal AddOnMaximumAmount
        {
            get { return Convert.ToDecimal(_addOnMaximumAmountTextBox.Text); }
            set { _addOnMaximumAmountTextBox.Text = value.ToString("N2"); }
        }

        public decimal AddOnServiceFee
        {
            get { return Convert.ToDecimal(_addOnServiceFeeTextBox.Text); }
            set { _addOnServiceFeeTextBox.Text = value.ToString("N2"); }
        }

        public decimal AddOnCollectionFee
        {
            get { return Convert.ToDecimal(_addOnCollectionFeeTextBox.Text); }
            set { _addOnCollectionFeeTextBox.Text = value.ToString("N2"); }
        }

        public decimal AddOnCapitalBuildup
        {
            get { return Convert.ToDecimal(_addOnCapitalBuildupTextBox.Text); }
            set { _addOnCapitalBuildupTextBox.Text = value.ToString("N2"); }
        }

        public decimal AddOnInterest
        {
            get { return Convert.ToDecimal(_addOnInterestTextBox.Text); }
            set { _addOnInterestTextBox.Text = value.ToString("N2"); }
        }

        public decimal DeductedMaximumAmount
        {
            get { return Convert.ToDecimal(_deductedMaximumAmountTextBox.Text); }
            set { _deductedMaximumAmountTextBox.Text = value.ToString("N2"); }
        }

        public decimal DeductedServiceFee
        {
            get { return Convert.ToDecimal(_deductedServiceFeeTextBox.Text); }
            set { _deductedServiceFeeTextBox.Text = value.ToString("N2"); }
        }

        public decimal DeductedCollectionFee
        {
            get { return Convert.ToDecimal(_deductedCollectionFeeTextBox.Text); }
            set { _deductedCollectionFeeTextBox.Text = value.ToString("N2"); }
        }

        public decimal DeductedCapitalBuildup
        {
            get { return Convert.ToDecimal(_deductedCapitalBuildupTextBox.Text); }
            set { _deductedCapitalBuildupTextBox.Text = value.ToString("N2"); }
        }

        public decimal DeductedInterest
        {
            get { return Convert.ToDecimal(_deductedInterestTextBox.Text); }
            set { _deductedInterestTextBox.Text = value.ToString("N2"); }
        }

        #endregion

        public ServiceRateView()
        {
            InitializeComponent();
            _presenter = new ServiceRatePreseter(this);
            _presenter.Success += new SuccessHandler(NotifyInformation);
            _presenter.Error += new ErrorHandler(NotifyError);

            // register controls to validate

            // maximum amount
            ControlValidator.RegisterControl(_deductedMaximumAmountTextBox, InputType.Currency, true, "Maximum Amount", 12, 2);
            ControlValidator.RegisterControl(_addOnMaximumAmountTextBox, InputType.Currency, true, "Maximum Amount", 12, 2);

            // service fee
            ControlValidator.RegisterControl(_deductedServiceFeeTextBox, InputType.Currency, true, "Service Fee", 12, 2);
            ControlValidator.RegisterControl(_addOnServiceFeeTextBox, InputType.Currency, true, "Service Fee", 12, 2);

            // collection fee
            ControlValidator.RegisterControl(_deductedCollectionFeeTextBox, InputType.Currency, true, "Collection Fee", 12, 2);
            ControlValidator.RegisterControl(_addOnCollectionFeeTextBox, InputType.Currency, true, "Collection Fee", 12, 2);

            // capital build up
            ControlValidator.RegisterControl(_deductedCapitalBuildupTextBox, InputType.Currency, true, "Capital Build-up", 12, 2);
            ControlValidator.RegisterControl(_addOnCapitalBuildupTextBox, InputType.Currency, true, "Capital Build-up", 12, 2);

            // interest
            ControlValidator.RegisterControl(_deductedInterestTextBox, InputType.Currency, true, "Interest", 12, 2);
            ControlValidator.RegisterControl(_addOnInterestTextBox, InputType.Currency, true, "Interest", 12, 2);
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
