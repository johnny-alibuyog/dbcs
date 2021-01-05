using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Reports.MemberPeriodicalBalanceSummaries;
using CooperativeSystem.Service.Presenters.Reports.MemberPeriodicalBalanceSummaries.MonthlyBalances;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.MemberPeriodicalBalanceSummaries.MonthlyBalances
{
    public partial class MonthlyBalanceReportView : ReportViewTemplate, IMonthlyBalanceReportView
    {
        private MonthlyBalanceReportPresenter _presenter;

        public MonthlyBalanceReportView()
        {
            InitializeComponent();

            _presenter = new MonthlyBalanceReportPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        #region IMonthlyBalanceReportView Members

        public DateTime Date { get; set; }

        public void PopulateReports(IList<PeriodicalBalance> balances)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("Month", Date.ToString("MMMM"), true),
                new ReportParameter("Year", Date.ToString("yyyy"), true)
            };

            _periodicalBalanceBindingSource.DataSource = balances;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }

        private void MonthlyBalanceReportView_Shown(object sender, EventArgs e)
        {
            _presenter.PopulateReports();
        }

        #endregion

        private void MonthlyBalanceReportView_Load(object sender, EventArgs e)
        {

        }
    }
}
