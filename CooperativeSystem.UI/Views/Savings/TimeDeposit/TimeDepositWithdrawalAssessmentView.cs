using System;
using System.Linq;
using System.Collections.Generic;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Savings.TimeDeposit;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;
using CooperativeSystem.Service.Presenters.Savings.TimeDeposit.Calculators;

namespace CooperativeSystem.UI.Views.Savings.TimeDeposit
{
    public partial class TimeDepositWithdrawalAssessmentView : FormTemplate, ITimeDepositWithdrawalAssessmentView
    {
        private readonly TimeDepositWithdrawalAssessmentPresenter _presenter;

        #region Routine Helpers

        protected virtual void OnAssessmentAdd(EventArgs e)
        {
            RaiseAssessmentAddEvent(this, e);
        }

        private void RaiseAssessmentAddEvent(object sender, EventArgs e)
        {
            if (AssessmentAdd != null)
                AssessmentAdd.Invoke(sender, e);
        }

        private void AddToWithdrawList()
        {
            var itemToAdd = _assessmentsBindingSource.Current as TimeDepositWithdrawalAssessmentModel;
            if (itemToAdd == null)
                return;

            var timeDepositsToWithdraw = _assessmentsToWithdrawBindingSource.List as IList<TimeDepositWithdrawalAssessmentModel>;
            if (timeDepositsToWithdraw.Any(x => x.TimeDepositID == itemToAdd.TimeDepositID))
                return;

            _assessmentsToWithdrawBindingSource.List.Add(itemToAdd);

            var amount = TotalWithdrawAmount;
            IsAssessed = (amount != 0M);
            _totalWithdrawAmountTextBox.Text = amount.ToString("N2");
        }

        private void RemoveFromWithdrawList()
        {
            var itemToRemove = _assessmentsToWithdrawBindingSource.Current as TimeDepositWithdrawalAssessmentModel;
            if (itemToRemove == null)
                return;

            _assessmentsToWithdrawBindingSource.List.Remove(itemToRemove);

            var amount = TotalWithdrawAmount;
            IsAssessed = (amount != 0M);
            _totalWithdrawAmountTextBox.Text = amount.ToString("N2");
        }

        #endregion

        #region ITimeDepositWithdrawalAssessmentView Members

        public event EventHandler AssessmentAdd;

        public bool IsAssessed
        {
            get { return _acceptButton.Enabled; }
            set { _acceptButton.Enabled = value; }
        }

        public long MemberID { get; set; }

        public IList<TimeDepositWithdrawalAssessmentModel> TimeDeposits
        {
            get { return (IList<TimeDepositWithdrawalAssessmentModel>)_assessmentsBindingSource.List; }
            set { _assessmentsBindingSource.DataSource = value; }
        }

        public IList<TimeDepositWithdrawalAssessmentModel> TimeDepositsToWithdraw
        {
            get { return (IList<TimeDepositWithdrawalAssessmentModel>)_assessmentsToWithdrawBindingSource.List; }
            set { _assessmentsToWithdrawBindingSource.DataSource = value; }
        }

        public decimal TotalWithdrawAmount
        {
            get
            {
                var total = 0M;
                var list = (IList<TimeDepositWithdrawalAssessmentModel>)_assessmentsToWithdrawBindingSource.List;
                if (list != null)
                    total = list.Sum(td => td.PrincipalAmount + td.Interest);
                return total;
            }
        }

        #endregion

        public TimeDepositWithdrawalAssessmentView()
        {
            InitializeComponent();

            _presenter = new TimeDepositWithdrawalAssessmentPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_totalWithdrawAmountTextBox, InputType.Currency, true, "Withdraw Amount", 16, 2);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddToWithdrawList();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveFromWithdrawList();
        }

        private void TimeDepositDataGridView_CellContentDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            AddToWithdrawList();
        }

        private void TimeDepositsToAvailDataGridView_CellContentDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            RemoveFromWithdrawList();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_assessmentsBindingSource.Count < 1)
                {
                    NotifyError(this, "You do not have any time deposit that pass maturity." +
                        "Please verify.");
                    return;
                }

                if (_assessmentsToWithdrawBindingSource.Count < 1)
                {
                    NotifyError(this, "There is no selected plan.");
                    return;
                }

                OnAssessmentAdd(new EventArgs());
                Close();
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }

        private void TimeDepositWithdrawalAssessmentView_Shown(object sender, EventArgs e)
        {
            IsAssessed = _presenter.Load();
        }
    }
}
