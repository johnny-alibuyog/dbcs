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
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Plans.PensionPlan
{
    public partial class PensionPlanPaymentView : PaymentFormTemplate, IPensionPlanPaymentView
    {
        private PensionPlanPaymentPresenter _presenter;

        #region Routine Helpser

        private void OnReceiptAdd(EventArgs e)
        {
            RaiseReceiptAddEvent(this, e);
        }

        private void RaiseReceiptAddEvent(object sender, EventArgs e)
        {
            if (ReceiptAdd != null)
                ReceiptAdd.Invoke(sender, e);
        }

        #endregion

        #region IPensionPlanPaymentView Members

        public event EventHandler ReceiptAdd;

        public bool HasPlan
        {
            get { return _acceptButton.Enabled; }
            set { _acceptButton.Enabled = value; }
        }

        public long MemberID 
        { 
            get; 
            set; 
        }

        public string PaymentMode
        {
            set { _paymentModeTextBox.Text = value; }
        }

        public decimal Amortization
        {
            set { _amortizationTextBox.Text = value.ToString("N2"); }
        }

        public decimal UnpaidAmortization
        {
            set { _unpaidAmortizationTextBox.Text = value.ToString("N2"); }
        }

        public decimal PaymentAmount
        {
            get { return Convert.ToDecimal(_paymentAmountTextBox.Text); }
            set { _paymentAmountTextBox.Text = value.ToString("N2"); }
        }

        #endregion

        public PensionPlanPaymentView()
        {
            InitializeComponent();

            _presenter = new PensionPlanPaymentPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_paymentAmountTextBox, InputType.Currency, true, "Payment Amount", 16, 2);
        }

        private void PensionPlanPaymentView_Shown(object sender, EventArgs e)
        {
            HasPlan = _presenter.Load();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ControlValidator.Validate())
                    return;

                OnReceiptAdd(new EventArgs());
                Close();
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }
    }
}
