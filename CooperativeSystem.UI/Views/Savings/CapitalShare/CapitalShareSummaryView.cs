using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.Savings.CapitalShare;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.UI.Views.Utilities;
using CooperativeSystem.Service.Presenters.Savings.CapitalShare.Calculators;

namespace CooperativeSystem.UI.Views.Savings.CapitalShares
{
    public partial class CapitalShareSummaryView : SavingsSummaryTemplate, ICapitalShareSummaryView
    {
        private CapitalShareSummaryPresenter _presenter;

        public CapitalShareSummaryView()
        {
            InitializeComponent();

            _presenter = new CapitalShareSummaryPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        #region ICapitalShareSummaryView Members

        public IList<CapitalShareTransaction> Transactions
        {
            set
            {
                //_transactionsDataGridView.DataSource = value;
                _transactionsDataGridView.DataSource = value != null
                    ? new SearchableSortableBindingList<CapitalShareTransaction>(value)
                    : new SearchableSortableBindingList<CapitalShareTransaction>();
            }
        }

        public Nullable<decimal> TotalShare
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
