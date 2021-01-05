using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Reports.Collections;
using CooperativeSystem.Service.Presenters.Reports.Collections.MonthlyCollections;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.Collections.MonthlyCollections
{
    public partial class MonthlyCollectionReportView : ReportViewTemplate, IMonthlyCollectionReportView
    {
        private MonthlyCollectionReportPresenter _presenter;

        public MonthlyCollectionReportView()
        {
            InitializeComponent();

            Date = DateTime.Now;

            _presenter = new MonthlyCollectionReportPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void MonthlyCollectoinReportView_Load(object sender, EventArgs e)
        {
            _presenter.PopulateReports();
        }

        #region IMonthlyCollectionReportView Members

        public DateTime Date { get; set; }

        public void PopulateReports(IList<MonthlyCollection> collections)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("Date",  Date.ToString(), true),
                new ReportParameter("RunDate", DateTime.Now.ToString(), true)
            };

            _monthlyCollectionBindingSource.DataSource = collections;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }

        #endregion
    }
}
