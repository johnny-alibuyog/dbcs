using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Plans.PensionPlan;
using CooperativeSystem.UI.Views.Maintenance;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Plans.PensionPlan
{
    public partial class AvailOptionView : DetailsFormTemplate, IAvailOptionView
    {
        private AvailOptionPresenter _presenter;

        public AvailOptionView()
        {
            InitializeComponent();

            _presenter = new AvailOptionPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_availOptionNameTextBox, InputType.Normal, true, "Avail Option Name", 30);
            ControlValidator.RegisterControl(_awardAmountTextBox, InputType.Currency, true, "Award Amount", 16, 2);
            ControlValidator.RegisterControl(_availOptionDescriptionRichTextBox, InputType.Normal, false, "Avail Option Description");
        }

        #region IAvailOptionView Members

        public int AvailOptionID { get; set; }

        public string AvailOptionName
        {
            get { return _availOptionNameTextBox.Text; }
            set { _availOptionNameTextBox.Text = value; }
        }

        public string AvailOptionDescription
        {
            get { return _availOptionDescriptionRichTextBox.Text; }
            set { _availOptionDescriptionRichTextBox.Text = value ?? string.Empty ; }
        }

        public decimal AwardAmount
        {
            get { return Convert.ToDecimal(_awardAmountTextBox.Text); }
            set { _awardAmountTextBox.Text = value.ToString("N2"); }
        }

        public int AgingPeriod
        {
            get { return (int)_agingPeriodNumericUpDown.Value; }
            set { _agingPeriodNumericUpDown.Value = value; }
        }

        public bool WithMonthlyPension
        {
            get { return _withMonthlyPensionCheckBox.Checked; }
            set { _withMonthlyPensionCheckBox.Checked = value; }
        }

        public void NewAvailOption()
        {
            _presenter.NewAvailOption();
        }

        public void LoadAvailOption(int availOptionID)
        {
            _presenter.LoadAvailOption(availOptionID);
        }

        #endregion

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!ControlValidator.Validate())
                return;

            if (ActionType == ActionType.Insert)
            {
                if (AskConfirmation(this, "Do you want to add new avail option?") == DialogResult.Yes)
                {
                    if (_presenter.Insert())
                    {
                        OnItemAdded(new EventArgs());
                        Close();
                    }
                }
            }
            else if (ActionType == ActionType.Update)
            {
                if (AskConfirmation(this, "Do you want to modify avail option information?") == DialogResult.Yes)
                {
                    if (_presenter.Update())
                    {
                        OnItemModified(new EventArgs());
                        Close();
                    }
                }
            }
            else if (ActionType == ActionType.Delete)
            {
                if (AskConfirmation(this, "Do you want to delete avail option?") == DialogResult.Yes)
                {
                    if (_presenter.Delete())
                    {
                        OnItemDeleted(new EventArgs());
                        Close();
                    }
                }
            }
        }
    }
}
