using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Reports.Disbursements.YearlyDisbursements;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.Disbursements.YearlyDisbursements
{
    public partial class YearlyDisbursementReportView : ReportViewTemplate, IYearlyDisbursementReportView
    {
        private YearlyDisbursementReportPresenter _presenter;

        public YearlyDisbursementReportView()
        {
            InitializeComponent();

            _presenter = new YearlyDisbursementReportPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void YearlyDisbursementReportView_Load(object sender, EventArgs e)
        {
            _presenter.PopulateReports();
        }

        #region IYearlyDisbursementReportView Members

        public DateTime Date { get; set; }

        public void PopulateReports(IList<YearlyDisbursement> disbursements)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("Date", Date.ToString(), true),
                new ReportParameter("RunDate", DateTime.Now.ToString(), true)
            };

            this._yearlyDisbursementBindingSource.DataSource = disbursements;
            this._reportViewer.LocalReport.SetParameters(reportParameters);
            this._reportViewer.RefreshReport();
        }

        #endregion
    }
}
