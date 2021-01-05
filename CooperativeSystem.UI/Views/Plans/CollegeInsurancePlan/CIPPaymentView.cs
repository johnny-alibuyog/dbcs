using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan;
using CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan.Calculators;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Plans.CollegeInsurancePlan
{
    public partial class CIPPaymentView : PaymentFormTemplate, ICIPPaymentView
    {
        private CIPPaymentPresenter _presenter;

        public CIPPaymentView()
        {
            InitializeComponent();

            _presenter = new CIPPaymentPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_paymentAmountTextBox, InputType.Currency, false, "Payment Amount", 16, 2);
            ControlValidator.RegisterControl(_totalPaymentAmountTextBox, InputType.Currency, false, "Total Payment Amount", 16, 2);
        }

        #region ICIPPaymentView Members

        public event EventHandler ReceiptAdd;

        public bool HasPlan
        {
            get { return _acceptButton.Enabled; }
            set { _acceptButton.Enabled = value; }
        }

        public long MemberID { get; set; }

        public IList<PayablePlanDetails> PayablePlans
        {
            get { return (IList<PayablePlanDetails>)_payablePlansBindingSource.List; }
            set { _payablePlansBindingSource.DataSource = value; }
        }

        public IList<PayablePlanDetails> PayablePlansToPay
        {
            get { return (IList<PayablePlanDetails>)_payablePlansToPayBindingSource.List; }
            set { _payablePlansToPayBindingSource.DataSource = value; }
        }

        public decimal TotalPaymentAmount
        {
            get { return (PayablePlansToPay != null) ? PayablePlansToPay.Sum(p => p.PaymentAmount) : 0M; }
        }

        #endregion

        #region Routine Helpers

        protected virtual void OnReceiptAdd(EventArgs e)
        {
            RaiseRecetipAddEvent(this, e);
        }

        private void RaiseRecetipAddEvent(object sender, EventArgs e)
        {
            if (ReceiptAdd != null)
                ReceiptAdd.Invoke(sender, e);
        }

        private void AddAllToPaymentList()
        {
            if (PayablePlans != null)
            {
                foreach (var itemToAdd in PayablePlans)
                    AddItemToPaymentList(itemToAdd);
            }
        }

        private void AddItemToPaymentList(PayablePlanDetails itemToAdd)
        {
            if (itemToAdd != null && !_payablePlansToPayBindingSource.Contains(itemToAdd))
            {
                itemToAdd.PaymentAmount = itemToAdd.UnpaidAmortization > 0M 
                    ? itemToAdd.UnpaidAmortization
                    : itemToAdd.Amortization;
                _payablePlansToPayBindingSource.Add(itemToAdd);
            }
        }

        private void RemoveItemFromPaymentList(PayablePlanDetails itemToRemove)
        {
            if (itemToRemove != null)
                _payablePlansToPayBindingSource.Remove(itemToRemove);
        }

        private void SyncTotalPayment()
        {
            var amount = TotalPaymentAmount;
            HasPlan = (amount != 0M);
            _totalPaymentAmountTextBox.Text = amount.ToString("N2");
        }

        #endregion

        private void CIPPaymentView_Shown(object sender, EventArgs e)
        {
            HasPlan = _presenter.Load();
        }

        private void AddAllButton_Click(object sender, EventArgs e)
        {
            AddAllToPaymentList();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var itemToAdd = _payablePlansBindingSource.Current as PayablePlanDetails;
            AddItemToPaymentList(itemToAdd);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var itemToRemove = _payablePlansToPayBindingSource.Current as PayablePlanDetails;
            RemoveItemFromPaymentList(itemToRemove);
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_payablePlansBindingSource.Count < 1)
                {
                    NotifyError(this, "You do not have any payable college insurance plan. Please verify.");
                    return;
                }

                if (_payablePlansToPayBindingSource.Count < 1)
                {
                    NotifyError(this, "There is no selected plan.");
                    return;
                }

                if (AskConfirmation(this, "Do you want to add payment?") != DialogResult.Yes)
                    return;

                OnReceiptAdd(new EventArgs());
                Close();
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }

        private void PayablePlansToPayBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            SyncTotalPayment();
        }

        private void PayablePlansToPayBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            SyncTotalPayment();
        }

        private void PaymentAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            var amount = 0M;
            decimal.TryParse(_paymentAmountTextBox.Text, out amount);
            _paymentAmountTextBox.Text = amount.ToString("N2");
        }
    }
}
