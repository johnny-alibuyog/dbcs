using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.Reports.MemberPeriodicalBalanceSummaries;
using CooperativeSystem.Service.Presenters.Reports.MemberPeriodicalBalanceSummaries.YearlyBalances;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.MemberPeriodicalBalanceSummaries.YearlyBalances
{
    public partial class YearlyBalanceReportView : ReportViewTemplate, IYearlyBalanceReportView
    {
        private YearlyBalanceReportPresenter _presenter;

        public YearlyBalanceReportView()
        {
            InitializeComponent();

            _presenter = new YearlyBalanceReportPresenter(this);
        }

        public int Year { get; set; }

        public void PopulateReports(IList<PeriodicalBalance> balances)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("Year", Year.ToString(), true)
            };

            _periodicalBalanceBindingSource.DataSource = balances;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }

        private void YearlyBalanceReportView_Shown(object sender, EventArgs e)
        {
            _presenter.PopulateReports();
        }

        private void YearlyBalanceReportView_Load(object sender, EventArgs e)
        {

        }
    }
}
