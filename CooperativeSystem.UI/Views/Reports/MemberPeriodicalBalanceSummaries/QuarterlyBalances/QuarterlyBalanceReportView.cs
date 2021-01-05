using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Reports.MemberPeriodicalBalanceSummaries;
using CooperativeSystem.Service.Presenters.Reports.MemberPeriodicalBalanceSummaries.QuarterlyBalances;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.MemberPeriodicalBalanceSummaries.QuarterlyBalances
{
    public partial class QuarterlyBalanceReportView : ReportViewTemplate, IQuarterlyBalanceReportView
    {
        private QuarterlyBalanceReportPersenter _presenter;

        public QuarterlyBalanceReportView()
        {
            InitializeComponent();

            _presenter = new QuarterlyBalanceReportPersenter(this);
            _presenter.Error += new ErrorHandler(NotifyInformation);
            _presenter.Success += new SuccessHandler(NotifyError);
        }

        #region IQuarterlyBalanceReportView Members

        public int Year { get; set; }

        public Quarter Quarter { get; set; }

        public void PopulateReports(IList<PeriodicalBalance> balances)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("Year", Year.ToString(), true),
                new ReportParameter("Quarter", Quarter.Name, true)
            };

            _periodicalBalanceBindingSource.DataSource = balances;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }

        #endregion

        private void QuarterlyBalanceReportView_Load(object sender, EventArgs e)
        {
            //_presenter.PopulateReports();
        }

        private void QuarterlyBalanceReportView_Shown(object sender, EventArgs e)
        {
            _presenter.PopulateReports();
        }
    }
}
