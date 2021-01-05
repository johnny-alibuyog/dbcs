using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Lookups;
using CooperativeSystem.Service.Presenters.Lookups.GracePeriods;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Lookups
{
    public partial class GracePeriodView : FormTemplate, IGracePeriodView
    {
        private GracePeriodPresenter _presenter;

        public GracePeriodView()
        {
            InitializeComponent();

            _presenter = new GracePeriodPresenter(this);
            _presenter.Success += new SuccessHandler(NotifyInformation);
            _presenter.Error += new ErrorHandler(NotifyError);

            // register controls to validate
            ControlValidator.RegisterControl(_dailyTextBox, InputType.NumericOnly, true, "Daily");
            ControlValidator.RegisterControl(_weeklyTextBox, InputType.NumericOnly, true, "Weekly");
            ControlValidator.RegisterControl(_semiMonthlyTextBox, InputType.NumericOnly, true, "Semi-Monthly");
            ControlValidator.RegisterControl(_monthlyTextBox, InputType.NumericOnly, true, "Monthly");
        }

        #region IGracePeriodView Members

        public int Daily
        {
            get { return Convert.ToInt32(_dailyTextBox.Text); }
            set { _dailyTextBox.Text = value.ToString(); }
        }

        public int Weekly
        {
            get { return Convert.ToInt32(_weeklyTextBox.Text); }
            set { _weeklyTextBox.Text = value.ToString(); }
        }

        public int SemiMonthly
        {
            get { return Convert.ToInt32(_semiMonthlyTextBox.Text); }
            set { _semiMonthlyTextBox.Text = value.ToString(); }
        }

        public int Monthly
        {
            get { return Convert.ToInt32(_monthlyTextBox.Text); }
            set { _monthlyTextBox.Text = value.ToString(); }
        }

        #endregion

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (ControlValidator.Validate())
                _presenter.Update();
        }

        private void GracePeriodView_Shown(object sender, EventArgs e)
        {
            _presenter.Populate();
        }
    }
}
