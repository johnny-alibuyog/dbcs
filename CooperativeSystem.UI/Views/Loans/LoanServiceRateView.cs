using System;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Loans;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Loans
{
    public partial class LoanServiceRateView : ServiceRateFormTemplate, ILoanServiceRateView
    {
        LoanServiceRatesPresenter _presenter;

        #region ICapitalBuildupRateView Members

        decimal ILoanCapitalBuildupRateView.AddOnBelowFiveThousand // money field
        {
            get { return Convert.ToDecimal(_addOnBelow5000CBRTextBox.Text); }
            set { _addOnBelow5000CBRTextBox.Text = value.ToString("N2"); }
        }

        decimal ILoanCapitalBuildupRateView.AddOnFiveThousandAndAbove
        {
            get { return Convert.ToDecimal(_addOn5000andAboveCBRTextBox.Text); }
            set { _addOn5000andAboveCBRTextBox.Text = value.ToString(); }
        }

        decimal ILoanCapitalBuildupRateView.DeductedBelowFiveThousand // money field
        {
            get { return Convert.ToDecimal(_deductedBelow5000CBRTextBox.Text); }
            set { _deductedBelow5000CBRTextBox.Text = value.ToString("N2"); }
        }

        decimal ILoanCapitalBuildupRateView.DeductedFiveThousandAndAbove
        {
            get { return Convert.ToDecimal(_deducted5000andAboveCBRTextBox.Text); }
            set { _deducted5000andAboveCBRTextBox.Text = value.ToString(); }
        }

        decimal ILoanCapitalBuildupRateView.AddOnShareBelowFifteenThousand
        {
            get { return Convert.ToDecimal(_addOnShareBelow15000CBRTextBox.Text); }
            set { _addOnShareBelow15000CBRTextBox.Text = value.ToString(); }
        }

        decimal ILoanCapitalBuildupRateView.AddOnShareFifteenThousandAndAbove
        {
            get { return Convert.ToDecimal(_addOnShare15000andAboveCBRTextBox.Text); }
            set { _addOnShare15000andAboveCBRTextBox.Text = value.ToString(); }
        }

        decimal ILoanCapitalBuildupRateView.DeductedShareBelowFifteenThousand
        {
            get { return Convert.ToDecimal(_deductedShareBelow15000CBRTextBox.Text); }
            set { _deductedShareBelow15000CBRTextBox.Text = value.ToString(); }
        }

        decimal ILoanCapitalBuildupRateView.DeductedShareFifteenThousandAndAbove
        {
            get { return Convert.ToDecimal(_deductedShare15000andAboveCBRTextBox.Text); }
            set { _deductedShare15000andAboveCBRTextBox.Text = value.ToString(); }
        }

        #endregion

        #region ICollectionFeeRateView Members

        decimal ILoanCollectionFeeRateView.AddOnOneToFiveMonths
        {
            get { return Convert.ToDecimal(_addOn1to5MonthsCFRTextBox.Text); }
            set { _addOn1to5MonthsCFRTextBox.Text = value.ToString(); }
        }

        decimal ILoanCollectionFeeRateView.AddOnSixToTenMonths
        {
            get { return Convert.ToDecimal(_addOn6to10MonthsCFRTextBox.Text); }
            set { _addOn6to10MonthsCFRTextBox.Text = value.ToString(); }
        }

        decimal ILoanCollectionFeeRateView.DeductedOneToFiveMonths
        {
            get { return Convert.ToDecimal(_deducted1to5MonthsCFRTextBox.Text); }
            set { _deducted1to5MonthsCFRTextBox.Text = value.ToString(); }
        }

        decimal ILoanCollectionFeeRateView.DeductedSixToTenMonths
        {
            get { return Convert.ToDecimal(_deducted6to10MonthsCFRTextBox.Text); }
            set { _deducted6to10MonthsCFRTextBox.Text = value.ToString(); }
        }

        #endregion

        #region IGuaranteeFundRateView Members

        decimal ILoanGuaranteeFundRateView.AddOnOneToFiveMonths
        {
            get { return Convert.ToDecimal(_addOn1to5MonthsGFRTextBox.Text); }
            set { _addOn1to5MonthsGFRTextBox.Text = value.ToString(); }

        }

        decimal ILoanGuaranteeFundRateView.AddOnSixToTenMonths
        {
            get { return Convert.ToDecimal(_addOn6to10MonthsGFRTextBox.Text); }
            set { _addOn6to10MonthsGFRTextBox.Text = value.ToString(); }
        }

        decimal ILoanGuaranteeFundRateView.DeductedOneToFiveMonths
        {
            get { return Convert.ToDecimal(_deducted1to5MonthsGFRTextBox.Text); }
            set { _deducted1to5MonthsGFRTextBox.Text = value.ToString(); }
        }

        decimal ILoanGuaranteeFundRateView.DeductedSixToTenMonths
        {
            get { return Convert.ToDecimal(_deducted6to10MonthsGFRTextBox.Text); }
            set { _deducted6to10MonthsGFRTextBox.Text = value.ToString(); }
        }

        #endregion

        #region IInterestRateView Members

        decimal ILoanInterestRateView.AddOnDaily
        {
            get { return Convert.ToDecimal(_addOnDailyIRTextBox.Text); }
            set { _addOnDailyIRTextBox.Text = value.ToString(); }
        }

        decimal ILoanInterestRateView.AddOnWeekly
        {
            get { return Convert.ToDecimal(_addOnWeeklyIRTextBox.Text); }
            set { _addOnWeeklyIRTextBox.Text = value.ToString(); }
        }

        decimal ILoanInterestRateView.AddOnSemiMonthly
        {
            get { return Convert.ToDecimal(_addOnSemiMontlyIRTextBox.Text); }
            set { _addOnSemiMontlyIRTextBox.Text = value.ToString(); }
        }

        decimal ILoanInterestRateView.AddOnMonthly
        {
            get { return Convert.ToDecimal(_addOnMonthlyIRTextBox.Text); }
            set { _addOnMonthlyIRTextBox.Text = value.ToString(); }
        }

        decimal ILoanInterestRateView.DeductedDaily
        {
            get { return Convert.ToDecimal(_deductedDailyIRTextBox.Text); }
            set { _deductedDailyIRTextBox.Text = value.ToString(); }
        }

        decimal ILoanInterestRateView.DeductedWeekly
        {
            get { return Convert.ToDecimal(_deductedWeeklyIRTextBox.Text); }
            set { _deductedWeeklyIRTextBox.Text = value.ToString(); }
        }

        decimal ILoanInterestRateView.DeductedSemiMonthly
        {
            get { return Convert.ToDecimal(_deductedSemiMontlyIRTextBox.Text); }
            set { _deductedSemiMontlyIRTextBox.Text = value.ToString(); }
        }

        decimal ILoanInterestRateView.DeductedMonthly
        {
            get { return Convert.ToDecimal(_deductedMonthlyIRTextBox.Text); }
            set { _deductedMonthlyIRTextBox.Text = value.ToString(); }
        }

        #endregion

        #region IServiceFeeRateView Members

        decimal ILoanServiceFeeRateView.AddOnOneToFiveMonths
        {
            get { return Convert.ToDecimal(_addOn1to5MonthsSFRTextBox.Text); }
            set { _addOn1to5MonthsSFRTextBox.Text = value.ToString(); }
        }

        decimal ILoanServiceFeeRateView.AddOnSixToTenMonths
        {
            get { return Convert.ToDecimal(_addOn6to10MonthsSFRTextBox.Text); }
            set { _addOn6to10MonthsSFRTextBox.Text = value.ToString(); }
        }

        decimal ILoanServiceFeeRateView.DeductedOneToFiveMonths
        {
            get { return Convert.ToDecimal(_deducted1to5MonthsSFRTextBox.Text); }
            set { _deducted1to5MonthsSFRTextBox.Text = value.ToString(); }
        }

        decimal ILoanServiceFeeRateView.DeductedSixToTenMonths
        {
            get { return Convert.ToDecimal(_deducted6to10MonthsSFRTextBox.Text); }
            set { _deducted6to10MonthsSFRTextBox.Text = value.ToString(); }
        }

        #endregion

        public LoanServiceRateView()
        {
            InitializeComponent();
            _presenter = new LoanServiceRatesPresenter(this);
            _presenter.Success += new SuccessHandler(NotifyInformation);
            _presenter.Error += new ErrorHandler(NotifyError);

            // register controls to validate

            // service fee rate
            ControlValidator.RegisterControl(_deducted6to10MonthsSFRTextBox, InputType.DecimalOnly, true, "Deducted 6 to 10 months Service Fee Rates", 5, 2);
            ControlValidator.RegisterControl(_deducted1to5MonthsSFRTextBox, InputType.DecimalOnly, true, "Deducted 1 to 5 months Service Fee Rates", 5, 2);
            ControlValidator.RegisterControl(_addOn6to10MonthsSFRTextBox, InputType.DecimalOnly, true, "Add-on 6 to 10 months Service Fee Rates", 5, 2);
            ControlValidator.RegisterControl(_addOn1to5MonthsSFRTextBox, InputType.DecimalOnly, true, "Add-on 1 to 5 months Service Fee Rates", 5, 2);

            // collection fee rate
            ControlValidator.RegisterControl(_deducted6to10MonthsCFRTextBox, InputType.DecimalOnly, true, "Deducted 6 to 10 months Collection Fee Rates", 5, 2);
            ControlValidator.RegisterControl(_deducted1to5MonthsCFRTextBox, InputType.DecimalOnly, true, "Deducted 1 to 5 months Collection Fee Rates", 5, 2);
            ControlValidator.RegisterControl(_addOn6to10MonthsCFRTextBox, InputType.DecimalOnly, true, "Add-on 6 to 10 months Collection Fee Rates", 5, 2);
            ControlValidator.RegisterControl(_addOn1to5MonthsCFRTextBox, InputType.DecimalOnly, true, "Add-on 1 to 5 months Collection Fee Rates", 5, 2);

            // guarantee fund rate
            ControlValidator.RegisterControl(_deducted6to10MonthsGFRTextBox, InputType.DecimalOnly, true, "Deducted 6 to 10 months Guarantee Fund Rates", 5, 3);
            ControlValidator.RegisterControl(_deducted1to5MonthsGFRTextBox, InputType.DecimalOnly, true, "Deducted 1 to 5 months Guarantee Fund Rates", 5, 3);
            ControlValidator.RegisterControl(_addOn6to10MonthsGFRTextBox, InputType.DecimalOnly, true, "Add-on 6 to 10 months Guarantee Fund Rates", 5, 3);
            ControlValidator.RegisterControl(_addOn1to5MonthsGFRTextBox, InputType.DecimalOnly, true, "Add-on 1 to 5 months Guarantee Fund Rates", 5, 3);

            // capital buildup rate
            ControlValidator.RegisterControl(_deductedBelow5000CBRTextBox, InputType.Currency, true, "Deducted below 50000 Capital Build-up Rates", 16, 2);
            ControlValidator.RegisterControl(_deducted5000andAboveCBRTextBox, InputType.DecimalOnly, true, "Deducted 50000 and above Capital Build-up Rates", 5, 2);
            ControlValidator.RegisterControl(_addOnBelow5000CBRTextBox, InputType.Currency, true, "Add-on below 50000 Capital Build-up Rates", 16, 2);
            ControlValidator.RegisterControl(_addOn5000andAboveCBRTextBox, InputType.DecimalOnly, true, "Add-on 50000 and above Capital Build-up Rates", 5, 2);

            ControlValidator.RegisterControl(_deductedShareBelow15000CBRTextBox, InputType.DecimalOnly, true, "Deducted share below 15,000 Capital Build-up Rates", 5, 2);
            ControlValidator.RegisterControl(_deductedShare15000andAboveCBRTextBox, InputType.DecimalOnly, true, "Deducted 15,000 and above Capital Build-up Rates", 5, 2);
            ControlValidator.RegisterControl(_addOnShareBelow15000CBRTextBox, InputType.DecimalOnly, true, "Add-on share below 15,000 Capital Build-up Rates", 5, 2);
            ControlValidator.RegisterControl(_addOnShare15000andAboveCBRTextBox, InputType.DecimalOnly, true, "Add-on share 15,000 and above Capital Build-up Rates", 5, 2);

            // interest rate
            ControlValidator.RegisterControl(_deductedMonthlyIRTextBox, InputType.DecimalOnly, true, "Deducted monthly Interest Rates", 5, 2);
            ControlValidator.RegisterControl(_deductedSemiMontlyIRTextBox, InputType.DecimalOnly, true, "Deducted semi-monthly Interest Rates", 5, 2);
            ControlValidator.RegisterControl(_deductedWeeklyIRTextBox, InputType.DecimalOnly, true, "Deducted weekly Interest Rates", 5, 2);
            ControlValidator.RegisterControl(_deductedDailyIRTextBox, InputType.DecimalOnly, true, "Deducted weekly Interest Rates", 5, 2);
            ControlValidator.RegisterControl(_addOnMonthlyIRTextBox, InputType.DecimalOnly, true, "Add-on monthly Interest Rates", 5, 2);
            ControlValidator.RegisterControl(_addOnSemiMontlyIRTextBox, InputType.DecimalOnly, true, "Add-on semi-monthly Interest Rates", 5, 2);
            ControlValidator.RegisterControl(_addOnWeeklyIRTextBox, InputType.DecimalOnly, true, "Add-on weekly Interest Rates", 5, 2);
            ControlValidator.RegisterControl(_addOnDailyIRTextBox, InputType.DecimalOnly, true, "Add-on weekly Interest Rates", 5, 2);
        }

        private void ServiceRateView_Shown(object sender, EventArgs e)
        {
            _presenter.Populate();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ControlValidator.Validate())
                    return;

                if (AskConfirmation(this, "Do you want to modify?") != DialogResult.Yes)
                    return;

                _presenter.Update();
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }
    }
}
