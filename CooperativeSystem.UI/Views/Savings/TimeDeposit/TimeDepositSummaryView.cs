using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Savings.TimeDeposit;
using CooperativeSystem.UI.Views.Utilities;

namespace CooperativeSystem.UI.Views.Savings.TimeDeposit
{
    public partial class TimeDepositSummaryView : SavingsSummaryTemplate, ITimeDepositSummaryView
    {
        private TimeDepositSummaryPresenter _presenter;

        public TimeDepositSummaryView()
        {
            InitializeComponent();

            _detailsDataGridView.AutoGenerateColumns = false;

            _presenter = new TimeDepositSummaryPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        #region ITimeDepositSummaryView Members

        public IList<TimeDepositTransaction> Transactions
        {
            set 
            {
                //_detailsDataGridView.DataSource = value;
                _detailsDataGridView.DataSource = value != null
                    ? new SearchableSortableBindingList<TimeDepositTransaction>(value)
                    : new SearchableSortableBindingList<TimeDepositTransaction>(); 
            }
        }

        public DateTime? DepositDate
        {
            set { _depoistDateLabel.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
        }

        public decimal? DepositAmount
        {
            set { _depoistAmountLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public int? Terms
        {
            set { _termsLabel.Text = value != null ? value.ToString() : string.Empty; }
        }

        public decimal? InterestRate
        {
            set { _interestRateLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public decimal? Interest
        {
            set { _interestLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
        }

        public DateTime? MaturityDate
        {
            set { _maturityDateLabel.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
        }

        public DateTime? DisbursementDate
        {
            set { _disbursementDateLabel.Text = value != null ? value.Value.ToShortDateString() : string.Empty; }
        }

        public decimal? DisbursementAmount
        {
            set { _disbursedAmountLabel.Text = value != null ? value.Value.ToString("N2") : string.Empty; }
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

        #region Routine Helpers

        private TimeDepositTransaction GetCurrentItem()
        {
            TimeDepositTransaction currentItem = null;
            var currentRow = _detailsDataGridView.CurrentRow;
            if (currentRow != null)
                currentItem = (TimeDepositTransaction)currentRow.DataBoundItem;
            return currentItem;
        }


        #endregion

        private void DetailsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var item = GetCurrentItem();
            if (item != null)
                _presenter.DisplayTransactionDetails(item);
        }
    }
}
