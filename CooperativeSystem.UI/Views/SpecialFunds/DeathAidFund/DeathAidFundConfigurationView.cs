using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.SpecialFunds.DeathAidFund;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.SpecialFunds.DeathAidFund
{
    public partial class DeathAidFundConfigurationView : FormTemplate, IDeathAidFundConfigurationView
    {
        private DeathAidFundConfigurationPresenter _presenter;

        #region IDeathAidFundConfigurationView Members

        public decimal Beneficiary
        {
            get { return Convert.ToDecimal(_beneficiaryTextBox.Text); }
            set { _beneficiaryTextBox.Text = value.ToString("N2"); }
        }

        public decimal Member
        {
            get { return Convert.ToDecimal(_memberTextBox.Text); }
            set { _memberTextBox.Text = value.ToString("N2"); }
        }

        #endregion

        public DeathAidFundConfigurationView()
        {
            InitializeComponent();

            _presenter = new DeathAidFundConfigurationPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_beneficiaryTextBox, InputType.Currency, true, "Beneficiary", 16, 2);
            ControlValidator.RegisterControl(_memberTextBox, InputType.Currency, true, "Member", 16, 2);
        }

        private void DeathAidFundConfigurationView_Shown(object sender, EventArgs e)
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
