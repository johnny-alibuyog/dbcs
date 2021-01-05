using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.SpecialFunds.TulunganFund;
using CooperativeSystem.Service.Presenters;

namespace CooperativeSystem.UI.Views.SpecialFunds.TulunganFund
{
    public partial class TulunganFundSummaryView : SpecialFundsSummaryTemplate, ITulunganFundSummaryView
    {
        private TulunganFundSummaryPresenter _presenter;

        public TulunganFundSummaryView()
        {
            InitializeComponent();

            _dataGridView.AutoGenerateColumns = false;

            _presenter = new TulunganFundSummaryPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

        }

        #region ITulunganFundSummaryView Members

        public IList<TulunganFundTransaction> Transactions
        {
            set { _dataGridView.DataSource = value; ; }
        }

        public decimal? Total
        {
            set { _totalTextBox.Text = (value != null) ? value.Value.ToString("N2") : string.Empty; }
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
    }
}
