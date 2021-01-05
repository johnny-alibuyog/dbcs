using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.Savings.TimeDeposit;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Savings.TimeDeposit
{
    public partial class TimeDepositDepositView : FormTemplate, ITimeDepositDepositView
    {
        public TimeDepositDepositView()
        {
            InitializeComponent();

            ControlValidator.RegisterControl(_amountTextBox, InputType.Currency, true, "Amount", 16, 2);
        }

        #region ITimeDepositDepositView Members

        public event EventHandler AssessmentAdd;

        public DateTime DepositDate { get; set; }

        public decimal Amount
        {
            get { return Convert.ToDecimal(_amountTextBox.Text); }
            set { _amountTextBox.Text = value.ToString("N2"); }
        }

        public int Terms
        {
            get { return (int)_termsNumericUpDown.Value; }
            set { _termsNumericUpDown.Value = value; }
        }

        public DateTime MaturityDate
        {
            get { return DateTime.Parse(_maturityDateTextBox.Text); }
            set { _maturityDateTextBox.Text = value.ToShortDateString(); }
        }

        #endregion

        #region Routine Helpers

        private void OnAssessmentAdd(EventArgs e)
        {
            RaiseAssessmentAddEvent(this, e);
        }

        private void RaiseAssessmentAddEvent(object sender, EventArgs e)
        {
            if (AssessmentAdd != null)
                AssessmentAdd.Invoke(sender, e);
        }

        private void ComputeMaturitiyDate()
        {
            var terms = (int)(_termsNumericUpDown).Value;
            MaturityDate = DepositDate.AddMonths(terms);
        }

        #endregion    

        private void TimeDepositDepositView_Shown(object sender, EventArgs e)
        {
            ComputeMaturitiyDate();
        }

        private void TermsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ComputeMaturitiyDate();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ControlValidator.Validate())
                    return;

                //if (AskConfirmation(this, "Do you want to add assessment?") != DialogResult.Yes)
                //    return;

                OnAssessmentAdd(new EventArgs());
                Close();
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }
    }
}
