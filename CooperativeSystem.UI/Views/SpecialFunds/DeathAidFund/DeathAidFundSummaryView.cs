using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.SpecialFunds.DeathAidFund;
using CooperativeSystem.Service.Presenters;

namespace CooperativeSystem.UI.Views.SpecialFunds.DeathAidFund
{
    public partial class DeathAidFundSummaryView : SpecialFundsSummaryTemplate, IDeathAidFundSummaryView
    {
        private DeathAidFundSummaryPresenter _presenter;

        public DeathAidFundSummaryView()
        {
            InitializeComponent();

            _dataGridView.AutoGenerateColumns = false;

            _presenter = new DeathAidFundSummaryPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        #region IDeathAidFundSummaryView Members

        public IList<DeathAidFundTransaction> Transactions
        {
            set { _dataGridView.DataSource = value; }
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
