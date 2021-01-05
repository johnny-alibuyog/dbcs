using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Plans.PensionPlan;

namespace CooperativeSystem.UI.Views.Plans.PensionPlan
{
    public partial class PensionPlanEnrollmentView : FormTemplate, IPensionPlanEnrollmentView
    {
        private PensionPlanEnrollmentPresenter _presenter;

        public PensionPlanEnrollmentView()
        {
            InitializeComponent();

            _presenter = new PensionPlanEnrollmentPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        #region IPensionPlanEnrollmentView Members

        public event EventHandler Enrolled;

        public long MemberID { get; set; }

        public DateTime ApplicationDate
        {
            get { return _applicationDateDateTimePicker.Value; }
            set { _applicationDateDateTimePicker.Value = value; }
        }

        public PaymentMode PaymentMode
        {
            get { return (PaymentMode)_paymentModeComboBox.SelectedItem; }
            set { _paymentModeComboBox.SelectedValue = value.PaymentModeID; }
        }

        public int Terms
        {
            get { return Convert.ToInt32(_termsTextBox.Text); }
            set { _termsTextBox.Text = value.ToString(); }
        }

        public int AgingPeriod
        {
            get { return Convert.ToInt32(_agingPeriodTextBox.Text); }
            set { _agingPeriodTextBox.Text = value.ToString(); }
        }

        public decimal Amortization
        {
            get { return Convert.ToDecimal(_amortizationTextBox.Text); }
            set { _amortizationTextBox.Text = value.ToString("N2"); }
        }

        public decimal PaymentCompletionAmount
        {
            get { return Convert.ToDecimal(_paymentCompletionAmountTextBox.Text); }
            set { _paymentCompletionAmountTextBox.Text = value.ToString("N2"); }
        }

        public void PopulatePaymentMode(IList<PaymentMode> paymentModes)
        {
            _paymentModeComboBox.DataSource = paymentModes;
            _paymentModeComboBox.ValueMember = "PaymentModeID";
            _paymentModeComboBox.DisplayMember = "PaymentModeName";
        }

        #endregion

        #region Routine Helpers

        protected virtual void OnEnrolled(EventArgs e)
        {
            RaiseEnrolledEvent(this, e);
        }

        private void RaiseEnrolledEvent(object sender, EventArgs e)
        {
            if (Enrolled != null)
                Enrolled.Invoke(this, e);
        }

        #endregion

        private void PensionPlanEnrollmentView_Shown(object sender, EventArgs e)
        {
            _presenter.LoadDefaults();
        }

        private void PaymentModeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            _presenter.SyncronizeAmortization();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_presenter.Enroll())
                {
                    OnEnrolled(new EventArgs());
                    NotifyInformation(this, "Successful enrolling.");
                    Close();
                }
                else
                {
                    NotifyError(this, "Error occured in enrolling.");
                }
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }
    }
}
