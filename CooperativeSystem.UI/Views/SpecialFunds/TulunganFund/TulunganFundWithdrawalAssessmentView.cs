using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.SpecialFunds.TulunganFund;

namespace CooperativeSystem.UI.Views.SpecialFunds.TulunganFund
{
    public partial class TulunganFundWithdrawalAssessmentView : FormTemplate, ITulunganFundWithdrawalAssessmentView
    {
        private TulunganFundWithdrawalAssessmentPresenter _presenter;

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

        #region ITulunganFundWithdrawalAssessmentView Members

        public event EventHandler AssessmentAdd;

        public bool IsAssessed { get; set; }

        public long MemberID { get; set; }

        public decimal Amount
        {
            get { return Convert.ToDecimal(_withdrawAmountTextBox.Text); }
            set { _withdrawAmountTextBox.Text = value.ToString("N2"); }
        }

        #endregion

        public TulunganFundWithdrawalAssessmentView()
        {
            InitializeComponent();

            _presenter = new TulunganFundWithdrawalAssessmentPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void TulunganFundWithdrawalAssessmentView_Shown(object sender, EventArgs e)
        {
            _presenter.Load();
        }

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

        private void _cancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
