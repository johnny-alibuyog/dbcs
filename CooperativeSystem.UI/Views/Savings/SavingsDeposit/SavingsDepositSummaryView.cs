using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Savings.SavingsDeposit;
using CooperativeSystem.UI.Views.Utilities;

namespace CooperativeSystem.UI.Views.Savings.SavingsDeposit
{
    public partial class SavingsDepositSummaryView : SavingsSummaryTemplate, ISavingsDepositSummaryView
    {
        private SavingsDepositSummaryPresenter _presenter;

        public SavingsDepositSummaryView()
        {
            InitializeComponent();

            _presenter = new SavingsDepositSummaryPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            _detailsDataGridView.AutoGenerateColumns = false;
        }

        #region ISavingsDepositDetailsView Members

        public IList<SavingsDepositTransaction> Transactions
        {
            set 
            {
                //_detailsDataGridView.DataSource = value;
                _detailsDataGridView.DataSource = value != null
                    ? new SearchableSortableBindingList<SavingsDepositTransaction>(value)
                    : new SearchableSortableBindingList<SavingsDepositTransaction>();
            }
        }

        public Nullable<decimal> TotalSavings
        {
            set { _totalShareTextBox.Text = (value != null) ? value.Value.ToString("N2") : string.Empty; }
        }

        #endregion

        #region ISummaryView Members

        public bool IsSummaryLoaded { get; set; }

        public void LoadSummary(long memberID)
        {
            if (IsSummaryLoaded)
                return;

            IsSummaryLoaded = _presenter.Load(memberID);
        }

        public void ClearSummary()
        {
            _presenter.Clear();
            IsSummaryLoaded = false;
        }

        #endregion

        private void RecomputBalanceButton_Click(object sender, EventArgs e)
        {
            _presenter.RecomputeBalance();
        }
    }
}
