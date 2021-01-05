using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.SpecialFunds.DeathAidFund;

namespace CooperativeSystem.UI.Views.SpecialFunds.DeathAidFund
{
    public partial class DeathAidFundWithdrawalAssessmentView : FormTemplate, IDeathAidFundWithdrawalAssessmentView
    {
        private DeathAidFundWithdrawalAssessmentPresenter _presenter;

        #region Routine Helpers

        internal virtual void OnAssessmentAdd(EventArgs e)
        {
            RaiseAssessmentAddEvent(this, e);
        }

        private void RaiseAssessmentAddEvent(object sender, EventArgs e)
        {
            if (AssessmentAdd != null)
                AssessmentAdd.Invoke(sender, e);
        }

        #endregion

        #region IDeathAidFundWithdrawalAssessmentView Members

        public event EventHandler AssessmentAdd;

        public bool IsAssessed 
        {
            get { return _acceptButton.Enabled; }
            set { _acceptButton.Enabled = value; } 
        }

        public long MemberID { get; set; }

        public char DeathAidFundTypeId
        {
            get { return (char)_deathAidFundTypesComboBox.SelectedValue; }
            set { _deathAidFundTypesComboBox.SelectedValue = (char)value; }
        }

        public decimal WithdrawAmount
        {
            get { return Convert.ToDecimal(_withdrawAmountTextBox.Text); }
            set { _withdrawAmountTextBox.Text = value.ToString("N2"); }
        }

        public void PopulateDeathAidFundTypes(IList<CooperativeSystem.Service.Models.DeathAidFundType> deathAidFundTypes)
        {
            _deathAidFundTypesComboBox.ValueMember = "Id";
            _deathAidFundTypesComboBox.DisplayMember = "Name";
            _deathAidFundTypesComboBox.DataSource = deathAidFundTypes;
        }

        #endregion

        public DeathAidFundWithdrawalAssessmentView()
        {
            InitializeComponent();

            _presenter = new DeathAidFundWithdrawalAssessmentPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void DeathAidFundWithdrawalAssessmentView_Shown(object sender, EventArgs e)
        {
            _presenter.Load();
        }

        private void DeathAidFundTypesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presenter.LoadWithdrawAmount();
        }

        //private void DeathAidFundTypesComboBox_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    _presenter.LoadWithdrawAmount();
        //}

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                OnAssessmentAdd(new EventArgs());
                Close();
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            var items = _presenter.Items;
            if (items != null)
            {
                var view = new WithdrawalAssessmentSummaryReportView();
                view.PopulateReports(items);
                view.ShowDialog(this);
            }
        }
    }
}
