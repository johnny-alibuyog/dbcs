using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Reports.CashFlows.YearlyCashFlows;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.CashFlows.YearlyCashFlows
{
    public partial class YearlyCashFlowReportView : ReportViewTemplate, IYearlyCashFlowReportView
    {
        private YearlyCashFlowReportPresenter _presenter;

        public YearlyCashFlowReportView()
        {
            InitializeComponent();

            _presenter = new YearlyCashFlowReportPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void YearlyCashFlowReportView_Load(object sender, EventArgs e)
        {
            _presenter.PopulateReports();
        }

        #region IYearlyCashFlowReportView Members

        public DateTime Date { get; set; }

        public void PopulateReports(IList<YearlyCashFlow> cashFlows)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("Date", Date.ToString(), true),
                new ReportParameter("RunDate", DateTime.Now.ToString(), true)
            };

            _yearlyCashFlowBindingSource.DataSource = cashFlows;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }

        #endregion
    }
}
