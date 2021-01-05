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
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Plans.CollegeInsurancePlan
{
    public partial class CIPAdjustmentView : FormTemplate, ICIPAdjustmentView
    {
        private CIPAdjustmentPresenter _presenter;

        public CIPAdjustmentView()
        {
            InitializeComponent();

            _presenter = new CIPAdjustmentPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            _cipsAdjustmentsDataGridView.SelectionChanged += new EventHandler(CIPsAdjustmentsDataGridView_SelectionChanged);

            ControlValidator.RegisterControl(_amountTextBox, InputType.Currency, false, "Payment Amount", 16, 2);
            ControlValidator.RegisterControl(_totalAmountTextBox, InputType.Currency, false, "Total Payment Amount", 16, 2);
        }

        #region ICIPAdjustmentView Members

        public event EventHandler MakeAdjustment;

        public bool HasAdjustment
        {
            get { return _acceptButton.Enabled; }
            set { _acceptButton.Enabled = value; }
        }

        public long MemberID { get; set; }

        public IList<CIPAdjustmentItem> CIPAdjustments
        {
            get { return (IList<CIPAdjustmentItem>)_cipAdjustmentItemBindingSource.List; }
            set { _cipAdjustmentItemBindingSource.DataSource = value; }
        }

        public decimal TotalAmount
        {
            get { return (CIPAdjustments != null) ? CIPAdjustments.Sum(x => x.Amount) : 0M; }
        }

        #endregion

        #region Routine Helpers

        protected virtual void OnMakeAdjustment(EventArgs e)
        {
            RaiseMakeAdjustmentEvent(this, e);
        }

        private void RaiseMakeAdjustmentEvent(object sender, EventArgs e)
        {
            if (MakeAdjustment != null)
                MakeAdjustment.Invoke(sender, e);
        }

        private void SyncTotal()
        {
            HasAdjustment = CIPAdjustments.Any(x => x.Amount != 0M);
            _totalAmountTextBox.Text = TotalAmount.ToString("N2");
        }

        #endregion

        private void CIPAdjustmentView_Shown(object sender, EventArgs e)
        {
            HasAdjustment = false;
            _presenter.Load();
        }

        private void CIPAdjustmentItemBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            SyncTotal();
        }

        private void CIPAdjustmentItemBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            SyncTotal();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_cipAdjustmentItemBindingSource.Count < 1)
                {
                    NotifyError(this, "You do not have any college insurance plan. Please verify.");
                    return;
                }

                if (AskConfirmation(this, "Do you want to include adjustment?") != DialogResult.Yes)
                    return;

                OnMakeAdjustment(new EventArgs());
                Close();
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            _cipsAdjustmentsDataGridView.Select();
        }

        private void CIPsAdjustmentsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            _amountTextBox.Select();
        }


        private void CIPsAdjustmentsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _amountTextBox.Select();
        }

        private void CIPAdjustmentView_Load(object sender, EventArgs e)
        {

        }

        private void _cipsAdjustmentsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
