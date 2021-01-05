using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Savings;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Savings
{
    public partial class NetSurplusView : FormTemplate, INetSurplusView
    {
        private NetSurplusPresenter _presenter;

        public NetSurplusView()
        {
            InitializeComponent();

            _presenter = new NetSurplusPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success  += new SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_amountTextBox, InputType.Currency, true, "Amount", 18, 2);
        }

        #region INetSurplusView Members

        public int Year
        {
            get { return Convert.ToInt16(_yearNumericUpDown.Value); }
            set { _yearNumericUpDown.Value = value; }
        }

        public decimal Amount
        {
            get { return Convert.ToDecimal(_amountTextBox.Text); }
            set { _amountTextBox.Text = value.ToString("N2"); }
        }

        #endregion

        private void NetSurplusView_Load(object sender, EventArgs e)
        {
            _yearNumericUpDown.Value = DateTime.Today.Year;
            _amountTextBox.Text = (0M).ToString("N2");
        }

        private void NetSurplusView_Shown(object sender, EventArgs e)
        {
            _presenter.Populate();
        }

        private void YearNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _presenter.Populate();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!ControlValidator.Validate())
                return;

            if (AskConfirmation(this, "Do you want to save?") != DialogResult.Yes)
                return;

            _presenter.Save();
        }
    }
}
