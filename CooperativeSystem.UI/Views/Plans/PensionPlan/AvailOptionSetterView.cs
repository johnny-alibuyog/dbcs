using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.Plans.PensionPlan;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Plans.PensionPlan
{
    public partial class AvailOptionSetterView : FormTemplate, IAvailOptionSetterView
    {
        private AvailOptionSetterPersenter _presenter;

        public AvailOptionSetterView()
        {
            InitializeComponent();

            _presenter = new AvailOptionSetterPersenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_monthlyPensionTextBox, InputType.Currency, false, "Monthly Pension", 16, 2);
        }

        #region IAvailOptionSetterView Members

        public event EventHandler Changed;

        public long MemberID { get; set; }

        public PensionPlanAvailOption AvailOption
        {
            get { return (PensionPlanAvailOption)_availOptionComboBox.SelectedItem; }
            set { _availOptionComboBox.SelectedValue = value.AvailOptionID; }
        }

        public bool WithMonthlyPension
        {
            get { return _monthlyPensionTextBox.Enabled; }
            set { _monthlyPensionTextBox.Enabled = value; }
        }

        public decimal? MonthlyPension
        {
            get { return _monthlyPensionTextBox.Enabled ? new Nullable<decimal>(Convert.ToDecimal(_monthlyPensionTextBox.Text)) : null; }
            set { _monthlyPensionTextBox.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public decimal AwardAmount
        {
            get { return Convert.ToDecimal(_awardAmountTextBox.Text); }
            set { _awardAmountTextBox.Text = value.ToString("N2"); }
        }

        public int AgingPeriod
        {
            get { return Convert.ToInt32(_agingPeriodTextBox.Text); }
            set { _agingPeriodTextBox.Text = value.ToString(); }
        }

        public string AvailOptionDescription
        {
            get { return _availOptionDescriptionRichTextBox.Text; }
            set { _availOptionDescriptionRichTextBox.Text = value; }
        }

        public void PopulateAvailOption(IList<PensionPlanAvailOption> availOptions)
        {
            _availOptionComboBox.DataSource = availOptions;
            _availOptionComboBox.ValueMember = "AvailOptionID";
            _availOptionComboBox.DisplayMember = "AvailOptionName";
        }

        #endregion

        #region Routine Helpers

        protected virtual void OnChanged(EventArgs e)
        {
            RaiseChangedEvent(this, e);
        }

        private void RaiseChangedEvent(object sender, EventArgs e)
        {
            if (Changed != null)
                Changed.Invoke(sender, e);
        }

        #endregion

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ControlValidator.Validate())
                    return;

                if (!_presenter.SetAvailOption())
                    return;

                OnChanged(new EventArgs());
                Close();
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }

        private void AvailOptionComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_presenter != null)
                _presenter.SyncronizeSelection();
        }

        private void AvailOptionSetterView_Shown(object sender, EventArgs e)
        {
            _presenter.LoadAvailOptions();
        }
    }
}
