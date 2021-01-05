using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Plans.CollegeInsurancePlan
{
    public partial class CIPWithdrawalAssessmentView : WithdrawalAssessmentFormTemplate, ICIPWithdrawalAssessmentView
    {
        private CIPWithdrawalAssessmentPresenter _presenter;

        public CIPWithdrawalAssessmentView()
        {
            InitializeComponent();

            _presenter = new CIPWithdrawalAssessmentPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            ControlValidator.RegisterControl(_totalWithdrawAmountTextBox, InputType.Currency, true, "Withdraw Amount", 16, 2);
        }

        #region ICIPWithdrawalAssessmentView Members

        public event EventHandler ReceiptAdd;

        public bool IsAssessed
        {
            get { return _acceptButton.Enabled; }
            set { _acceptButton.Enabled = value; }
        }

        public long MemberID { get; set; }

        public IList<CIPWithdrawalAssessmentModel> CIPAssessments
        {
            get { return _cipAssessmentsBindingSource.List as IList<CIPWithdrawalAssessmentModel>; }
            set { _cipAssessmentsBindingSource.DataSource = value; }
        }

        public IList<CIPWithdrawalAssessmentModel> CIPAssessmentsToWithdraw
        {
            get { return _cipAssessmentsToWithdrawBindingSource.List as IList<CIPWithdrawalAssessmentModel>; }
            set { _cipAssessmentsToWithdrawBindingSource.DataSource = value; }
        }

        public decimal TotalWithdrawAmount
        {
            get 
            {
                var total = 0M;
                var list = (IList<CIPWithdrawalAssessmentModel>)_cipAssessmentsToWithdrawBindingSource.List;
                if (list != null)
                    total = list.Sum(cip => cip.WithdrawAmount);
                return total;
            }
        }

        #endregion

        #region Routine Helpers

        private void OnAssessmentAdd(EventArgs e)
        {
            RaiseAssessmentAddEvent(this, e);
        }

        private void RaiseAssessmentAddEvent(object sender, EventArgs e)
        {
            if (ReceiptAdd != null)
                ReceiptAdd.Invoke(sender, e);
        }

        private void AddToWithdrawList()
        {
            var itemToAdd = _cipAssessmentsBindingSource.Current as CIPWithdrawalAssessmentModel;
            if (itemToAdd == null)
                return;

            var cipsToWithdraw = _cipAssessmentsToWithdrawBindingSource.List as IList<CIPWithdrawalAssessmentModel>;
            if (cipsToWithdraw.Any(x => x.CollegeInsurancePlanID == itemToAdd.CollegeInsurancePlanID))
                return;

            _cipAssessmentsToWithdrawBindingSource.List.Add(itemToAdd);

            var amount = TotalWithdrawAmount;
            IsAssessed = (amount != 0M);
            _totalWithdrawAmountTextBox.Text = amount.ToString("N2");
        }

        private void RemoveFromWithdrawList()
        {
            var itemToRemove = _cipAssessmentsToWithdrawBindingSource.Current as CIPWithdrawalAssessmentModel;
            if (itemToRemove == null)
                return;

            _cipAssessmentsToWithdrawBindingSource.List.Remove(itemToRemove);

            var amount = TotalWithdrawAmount;
            IsAssessed = (amount != 0M);
            _totalWithdrawAmountTextBox.Text = amount.ToString("N2");
        }

        #endregion

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_cipAssessmentsBindingSource.Count < 1)
                {
                    NotifyError(this, "You do not have any college insurance plan that pass maturity. Please verify.");
                    return;
                }

                if (_cipAssessmentsToWithdrawBindingSource.Count < 1)
                {
                    NotifyError(this, "There is no selected plan.");
                    return;
                }

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

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddToWithdrawList();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveFromWithdrawList();
        }

        private void CIPsAssessmentsDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddToWithdrawList();
        }

        private void CIPsAssessmentsToWithdrawDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RemoveFromWithdrawList();
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            if (_cipAssessmentsBindingSource.DataSource == null)
            {
                NotifyError(this, "No item exist from the list.");
                return;
            }

            var entity = _cipAssessmentsBindingSource.Current as CIPWithdrawalAssessmentModel;
            if (entity == null)
            {
                NotifyError(this, "No item is selected from the list.");
                return;
            }

            using (var cipev = new CIPEnrollmentView())
            {
                cipev.SetAction(CIPAction.View, entity.CollegeInsurancePlanID);
                cipev.ShowDialog(this);
            }
        }

        private void CIPWithdrawalAssessmentView_Shown(object sender, EventArgs e)
        {
            IsAssessed = _presenter.Load();
        }
    }
}
