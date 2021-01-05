using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Plans.CollegeInsurancePlan
{
    public partial class CIPSettingsView : FormTemplate, ICIPSettingsView
    {
        private CIPSettingsPresenter _presenter;

        public CIPSettingsView()
        {
            InitializeComponent();

            _presenter = new CIPSettingsPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_paymentCompletionAmountTextBox, InputType.Currency, true, "Payment Completion Amount", 16, 2);
            ControlValidator.RegisterControl(_awardAmountTextBox, InputType.Currency, true, "Award Amount", 16, 2);
            ControlValidator.RegisterControl(_amortizationDailyTextBox, InputType.Currency, true, "Amortization Daily", 16, 2);
            ControlValidator.RegisterControl(_amortizationWeeklyTextBox, InputType.Currency, true, "Amortization Weekly", 16, 2);
            ControlValidator.RegisterControl(_amortizationSemiMonthlyTextBox, InputType.Currency, true, "Amortization Semi-Monthly", 16, 2);
            ControlValidator.RegisterControl(_amortizationMonthlyTextBox, InputType.Currency, true, "Amortization Monthly", 16, 2);
            ControlValidator.RegisterControl(_amortizationYearlyTextBox, InputType.Currency, true, "Amortization Yearly", 16, 2);
        }

        #region ICIPSettingsView Members

        public int Id { get; set; }

        public int Terms
        {
            get { return (int)_termsNumericUpDown.Value; }
            set { _termsNumericUpDown.Value = value; }
        }

        public int AgingPeriod
        {
            get { return (int)_aginPeriodNumericUpDown.Value; }
            set { _aginPeriodNumericUpDown.Value = value; }
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

        public decimal AmortizationDaily
        {
            get { return Convert.ToDecimal(_amortizationDailyTextBox.Text); }
            set { _amortizationDailyTextBox.Text = value.ToString("N2"); }
        }

        public decimal AmortizationWeekly
        {
            get { return Convert.ToDecimal(_amortizationWeeklyTextBox.Text); }
            set { _amortizationWeeklyTextBox.Text = value.ToString("N2"); }
        }

        public decimal AmortizationSemiMonthly
        {
            get { return Convert.ToDecimal(_amortizationSemiMonthlyTextBox.Text); }
            set { _amortizationSemiMonthlyTextBox.Text = value.ToString("N2"); }
        }

        public decimal AmortizationMonthly
        {
            get { return Convert.ToDecimal(_amortizationMonthlyTextBox.Text); }
            set { _amortizationMonthlyTextBox.Text = value.ToString("N2"); }
        }

        public decimal AmortizationYearly
        {
            get { return Convert.ToDecimal(_amortizationYearlyTextBox.Text); }
            set { _amortizationYearlyTextBox.Text = value.ToString("N2"); }
        }

        #endregion

        private void CIPSettingsView_Shown(object sender, EventArgs e)
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
