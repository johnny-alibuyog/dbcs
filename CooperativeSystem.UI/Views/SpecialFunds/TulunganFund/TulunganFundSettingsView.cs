using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.SpecialFunds.TulunganFund;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;
using CooperativeSystem.Service.Presenters;

namespace CooperativeSystem.UI.Views.SpecialFunds.TulunganFund
{
    public partial class TulunganFundSettingsView : FormTemplate, ITulunganFundSettingsView
    {
        private TulunganFundSettingsPresenter _presenter;

        #region ITulunganFundSettingsView Members

        public decimal PerMemberYearlyContribution
        {
            get { return Convert.ToDecimal(_perMemberYearlyContributionTextBox.Text); }
            set { _perMemberYearlyContributionTextBox.Text = value.ToString("N2"); }
        }

        public decimal RequiredMinimumShare
        {
            get { return Convert.ToDecimal(_requiredMinimumShareTextBox.Text); }
            set { _requiredMinimumShareTextBox.Text = value.ToString("N2"); }
        }

        public decimal AwardForShareBelowFifteenThousand
        {
            get { return Convert.ToDecimal(_awardForShareBelowFifteenThousandTextBox.Text); }
            set { _awardForShareBelowFifteenThousandTextBox.Text = value.ToString("N2"); }
        }

        public decimal AwardForShareFifteenThousandAndAbove
        {
            get { return Convert.ToDecimal(_awardForShareFifteenThousandAndAboveTextBox.Text); }
            set { _awardForShareFifteenThousandAndAboveTextBox.Text = value.ToString("N2"); }
        }

        #endregion

        public TulunganFundSettingsView()
        {
            InitializeComponent();

            _presenter = new TulunganFundSettingsPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_perMemberYearlyContributionTextBox, InputType.Currency, true, "Per-Member Yearly Contribution", 16, 2);
            ControlValidator.RegisterControl(_requiredMinimumShareTextBox, InputType.Currency, true, "Required Minimum Share", 16, 2);
            ControlValidator.RegisterControl(_awardForShareBelowFifteenThousandTextBox, InputType.Currency, true, "Award for Share Below Fifteen Thousand", 16, 2);
            ControlValidator.RegisterControl(_awardForShareFifteenThousandAndAboveTextBox, InputType.Currency, true, "Award for Share Fifteen Thousand and Above", 16, 2);
        }

        private void TulunganFundSettingsView_Shown(object sender, EventArgs e)
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
