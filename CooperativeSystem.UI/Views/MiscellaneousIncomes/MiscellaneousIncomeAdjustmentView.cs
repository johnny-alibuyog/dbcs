using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.MiscellaneousIncomes;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.MiscellaneousIncomes
{
    public partial class MiscellaneousIncomeAdjustmentView : FormTemplate, IMiscellaneousIncomeAdjustmentView
    {
        private MiscellaneousIncomeAdjustmentPresenter _presenter;

        #region Routine Helpers

        private void DisableFields()
        {
            _acceptButton.Enabled = false;
            _clearButton.Enabled = false;
            _adjustmentDateTimePicker.Enabled = false;
            _sequenceTextBox.Enabled = false;
            _restartVoucherCheckBox.Enabled = false;
            _amountTextBox.Enabled = false;
        }

        #endregion

        #region IMiscellaneousIncomeAdjustmentView Members

        public string UserID { get; private set; }

        public DateTime AdjustmentDate 
        {
            get { return _adjustmentDateTimePicker.Value; }
        }

        public string VoucherNumber 
        {
            get { return _voucherNumberTextBox.Text; }
            set { _voucherNumberTextBox.Text = value; } 
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
            set { _remarksTextBox.Text = value; }
        }

        public bool IsLoadingDetails { get; set; }

        public bool IsThereAdjustment
        {
            get { return _acceptButton.Enabled; }
            set { _acceptButton.Enabled = value; }
        }

        #endregion

        public MiscellaneousIncomeAdjustmentView(string userID)
        {
            InitializeComponent();

            UserID = userID;

            _presenter = new MiscellaneousIncomeAdjustmentPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_amountTextBox, InputType.Currency, false, "Miscellaneous Income", 16, 2);
        }

        private void MiscellaneousIncomeAdjustmentView_Shown(object sender, EventArgs e)
        {
            _restartVoucherCheckBox.Checked = false;
            _presenter.Load();
        }

        private void AmountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (IsLoadingDetails)
                return;

            IsThereAdjustment = true;
        }

        private void ReceiptNumberComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (IsLoadingDetails)
                return;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            _restartVoucherCheckBox.Checked = false;
            _presenter.Clear();
        }

        private void RestartVoucherCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var restart = ((CheckBox)sender).Checked;

            _generateVoucherButton.Enabled = restart;
            _sequenceTextBox.Enabled = restart;
            _sequenceTextBox.Text = string.Empty;
            _sequenceTextBox.Select();
        }

        private void GenerateVoucherButton_Click(object sender, EventArgs e)
        {
            if (_presenter.GenerateVoucherNumber())
                _restartVoucherCheckBox.Checked = false;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsThereAdjustment)
                {
                    NotifyInformation(this, "You have not perform any adjustment yet. Please perform adjustment first.");
                    return;
                }

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
    }
}
