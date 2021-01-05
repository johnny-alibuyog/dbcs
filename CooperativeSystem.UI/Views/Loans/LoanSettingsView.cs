using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Loans;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Loans
{
    public partial class LoanSettingsView : FormTemplate, ILoanSettingsView
    {
        private readonly LoanSettingsPresenter _presenter;


        #region ILoanSettingsView Members

        public decimal RenewablePaidRercentage
        {
            get { return Convert.ToDecimal(_renewablePaidRecentageTextBox.Text); }
            set { _renewablePaidRecentageTextBox.Text = value.ToString("N2"); }
        }


        public decimal RegularLoanMaxPrecentage
        {
            get { return Convert.ToDecimal(_regularLoanMaxPrecentageTextBox.Text); }
            set { _regularLoanMaxPrecentageTextBox.Text = value.ToString("N2"); }

        }

        public int RebateExemptedTerms
        {
            get { return Convert.ToInt32(_rebateExcemptedTermsTextBox.Text); }
            set { _rebateExcemptedTermsTextBox.Text = value.ToString(); }
        }

        #endregion

        public LoanSettingsView()
        {
            InitializeComponent();

            _presenter = new LoanSettingsPresenter(this);
            _presenter.Success += new SuccessHandler(NotifyInformation);
            _presenter.Error += new ErrorHandler(NotifyError);

            ControlValidator.RegisterControl(_renewablePaidRecentageTextBox, InputType.DecimalOnly, true, "Renewable Paid Percentage", 5, 2);
            ControlValidator.RegisterControl(_regularLoanMaxPrecentageTextBox, InputType.DecimalOnly, true, "Regular Loan Max Precentage", 6, 2);
        }

        private void LoanSettingsView_Load(object sender, EventArgs e)
        {
            _presenter.Populate();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            _presenter.Update();
        }

    }
}
