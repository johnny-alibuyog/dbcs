using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Members;
using CooperativeSystem.Service.Presenters.MiscellaneousIncomes;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.MiscellaneousIncomes
{
    public partial class MiscellaneousIncomeCashReceiptView : FormTemplate, IMiscellaneousIncomeCashReceiptView
    {
        private MiscellaneousIncomeCashReceiptPresenter _presenter;

        #region Routine Helpers

        private void DisableFields()
        {
            _acceptButton.Enabled = false;
            _clearButton.Enabled = false;
            _receiptDateTimePicker.Enabled = false;
            _sequenceTextBox.Enabled = false;
            _restartReceiptCheckBox.Enabled = false;
            _amountTextBox.Enabled = false;
        }

        #endregion

        #region IMiscellaneousIncomeCashReceiptView Members

        public string UserID { get; private set; }

        public DateTime ReceiptDate
        {
            get { return _receiptDateTimePicker.Value; }
        }

        public string ReceiptNumber
        {
            get { return _officialReceiptNumber.Text; }
            set { _officialReceiptNumber.Text = value; }
        }

        public string Sequence
        {
            get { return _sequenceTextBox.Text; }
        }

        public decimal Amount
        {
            get { return Convert.ToDecimal(_amountTextBox.Text); }
            set { _amountTextBox.Text = value.ToString("N2"); }
        }

        public string Remarks
        {
            get { return _remarksTextBox.Text; }
            set { _remarksTextBox.Text = value; }
        }

        #endregion

        public MiscellaneousIncomeCashReceiptView(string userID)
        {
            InitializeComponent();

            UserID = userID;

            _presenter = new MiscellaneousIncomeCashReceiptPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_amountTextBox, InputType.Currency, false, "Miscellaneous Income", 16, 2);
        }

        private void RestartReceiptCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var restart = ((CheckBox)sender).Checked;

            _generateReceiptButton.Enabled = restart;
            _sequenceTextBox.Enabled = restart;
            _sequenceTextBox.Text = string.Empty;
            _sequenceTextBox.Select();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Amount == 0M)
                {
                    NotifyError(this, "Please provide value for receipt amount.");
                    return;
                }

                if (!ControlValidator.Validate())
                    return;

                if (AskConfirmation(this, "Are you sure you want to the commit transaction?") != DialogResult.Yes)
                    return;

                if (_presenter.Accept())
                    DisableFields();
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            _presenter.Clear();
        }

        private void GenerateReceiptButton_Click(object sender, EventArgs e)
        {
            if (_presenter.GenerateReceiptNumber())
                _restartReceiptCheckBox.Checked = false;
        }
    }
}
