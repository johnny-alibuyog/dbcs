using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.Reports.AgingLoans;
using CooperativeSystem.Service.Presenters;

namespace CooperativeSystem.UI.Views.Reports.AgingLoans
{
    public partial class AgingLoansHistoryView : FormTemplate, IAgingLoansHistoryView
    {
        private AgingLoansHistoryPresenter _presenter;

        public AgingLoansHistoryView()
        {
            InitializeComponent();

            _presenter = new AgingLoansHistoryPresenter(this);
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
            using (var view = new AgingLoansByDaysReportView(usePresenter: false))
            {
                view.PopulateReports(items);
                view.ShowDialog();
            }
        }
    }
}
