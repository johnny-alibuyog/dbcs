using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Reports.Disbursements.MonthlyDisbursements;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.Disbursements.MonthlyDisbursements
{
    public partial class MonthlyDisbursementReportView : ReportViewTemplate, IMonthlyDisbursementReportView
    {
        private MonthlyDisbursementReportPresenter _presenter;

        public MonthlyDisbursementReportView()
        {
            InitializeComponent();

            _presenter = new MonthlyDisbursementReportPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void MonthlyDisbursementReportView_Load(object sender, EventArgs e)
        {
            _presenter.PopulateReports();
        }

        #region IMonthlyDisbursementReportView Members

        public DateTime Date { get; set; }

        public void PopulateReports(IList<MonthlyDisbursement> disbursements)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("Date",  Date.ToString(), true),
                new ReportParameter("RunDate", DateTime.Now.ToString(), true)
            };

            _monthlyDisbursementBindingSource.DataSource = disbursements;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }

        #endregion
    }
}
