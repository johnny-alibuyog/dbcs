using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Reports.Disbursements.DailyDisbursements;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.Disbursements.DailyDisbursements
{
    public partial class DailyDisbursementReportView : ReportViewTemplate, IDailyDisbursementReportView
    {
        private DailyDisbursementReportPresenter _presenter;

        public DailyDisbursementReportView()
        {
            InitializeComponent();

            _presenter = new DailyDisbursementReportPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success +=new SuccessHandler(NotifyInformation);
        }

        private void DailyDisbursementReportView_Load(object sender, EventArgs e)
        {
            _presenter.PopulateReports();
        }

        #region IDailyDisbursementReportView Members

        public DateTime Date { get; set; }

        public void PopulateReports(IList<DailyDisbursement> disbursements)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("Date", Date.ToString(), true),
                new ReportParameter("RunDate", DateTime.Now.ToString(), true)
            };

            _dailyDisbursementBindingSource.DataSource = disbursements;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }

        #endregion
    }
}
