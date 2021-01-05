using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.Reports.DelinquentAccounts;
using CooperativeSystem.Service.Presenters;

namespace CooperativeSystem.UI.Views.Reports.DelinquentAccounts
{
    public partial class DelinquentLoansHistoryView : FormTemplate, IDelinquentLoansHistoryView
    {
        private readonly DelinquentLoansHistoryPresenter _presenter;

        public DelinquentLoansHistoryView()
        {
            InitializeComponent();

            _presenter = new DelinquentLoansHistoryPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        public Nullable<DateTime> Period
        {
            get { return _periodComboBox.SelectedItem as Nullable<DateTime>; }
        }

        public void PopulatePeriods(IList<Nullable<DateTime>> periods)
        {
            _periodComboBox.DataSource = periods;
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            var items = _presenter.Generate();
            using (var view = new DelinquentAccountReportView(usePresenter: false))
            {
                var totalCapitalShare = items
                    .GroupBy(x => x.Name)
                    .Sum(x => x.First().CapitalShare ?? 0M);

                var totalSavingsDeposit = items
                    .GroupBy(x => x.Name)
                    .Sum(x => x.First().SavingsDeposit ?? 0M);

                var totalTimeDeposit = items
                    .GroupBy(x => x.Name)
                    .Sum(x => x.First().TimeDeposit ?? 0M);

                var totalOutstandingBalance = items
                    .Sum(x => x.OutstandingBalance ?? 0M);

                var totalNetExposure = items
                    .GroupBy(x => x.Name)
                    .Sum(x =>
                        (x.First().CapitalShare ?? 0M) +
                        (x.First().SavingsDeposit ?? 0M) +
                        (x.First().TimeDeposit ?? 0M) -
                        (x.Sum(o => o.OutstandingBalance ?? 0M))
                    );

                view.PopulateReports(items, totalCapitalShare, totalSavingsDeposit, totalTimeDeposit, totalOutstandingBalance, totalNetExposure);
                view.ShowDialog();
            }
        }
    }
}
