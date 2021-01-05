using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.Savings.CapitalShare;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Savings.CapitalShare
{
    public partial class RefundRatioView : FormTemplate, IRefundRatioView
    {
        private RefundRatioPresenter _presenter;

        public RefundRatioView()
        {
            InitializeComponent();

            _presenter = new RefundRatioPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_dividendRatioTextBox, InputType.NumericOnly, true, "Dividend Ratio");
            ControlValidator.RegisterControl(_patronageRatioTextBox, InputType.NumericOnly, true, "Patronage Ratio");
        }

        public int DividendRatio
        {
            get { return Convert.ToInt32(_dividendRatioTextBox.Text); }
            set { _dividendRatioTextBox.Text = value.ToString(); }
        }

        public int PatronageRatio
        {
            get { return Convert.ToInt32(_patronageRatioTextBox.Text); }
            set { _patronageRatioTextBox.Text = value.ToString(); }
        }

        private void RefundRatioView_Shown(object sender, EventArgs e)
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
