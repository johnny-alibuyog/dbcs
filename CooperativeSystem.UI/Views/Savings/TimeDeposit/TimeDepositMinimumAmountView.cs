using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Savings.TimeDeposit;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Savings.TimeDeposit
{
    public partial class TimeDepositMinimumAmountView : FormTemplate, ITimeDepositMinimumAmountView
    {
        private TimeDepositMinimumAmountPresenter _presenter;

        public TimeDepositMinimumAmountView()
        {
            InitializeComponent();

            _presenter = new TimeDepositMinimumAmountPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_amountTextBox, InputType.Currency, true, "Minimum Amount", 16, 2);
        }

        #region ITimeDepositMinimumAmountView Members

        public int Id { get; set; }

        public decimal Amount
        {
            get { return Convert.ToDecimal(_amountTextBox.Text); }
            set { _amountTextBox.Text = value.ToString("N2"); }
        }

        #endregion

        private void SavingsDepositMaintainingBalanceView_Shown(object sender, EventArgs e)
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
