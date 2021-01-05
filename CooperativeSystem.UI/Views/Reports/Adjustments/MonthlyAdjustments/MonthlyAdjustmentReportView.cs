using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Reports.Adjustments.MonthlyAdjustments;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.Adjustments.MonthlyAdjustments
{
    public partial class MonthlyAdjustmentReportView : ReportViewTemplate, IMonthlyAdjustmentReportView
    {
        private MonthlyAdjustmentReportPresenter _presenter;

        public MonthlyAdjustmentReportView()
        {
            InitializeComponent();

            _presenter = new MonthlyAdjustmentReportPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void MonthlyAdjustmentReportView_Load(object sender, EventArgs e)
        {
            _presenter.PopulateReports();
        }

        #region IMonthlyAdjustmentReportView Members

        public DateTime Date { get; set; }

        public void PopulateReports(IList<MonthlyAdjustment> adjustments)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("Date",  Date.ToString(), true),
                new ReportParameter("RunDate", DateTime.Now.ToString(), true)
            };

            _monthlyAdjustmentBindingSource.DataSource = adjustments;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }

        #endregion
    }
}
