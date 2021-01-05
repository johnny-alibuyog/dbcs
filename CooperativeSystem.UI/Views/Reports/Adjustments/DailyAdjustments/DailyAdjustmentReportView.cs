using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Reports.Adjustments.DailyAdjustments;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.Adjustments.DailyAdjustments
{
    public partial class DailyAdjustmentReportView : ReportViewTemplate, IDailyAdjustmentReportView
    {
        private DailyAdjustmentReportPresenter _presenter;

        public DailyAdjustmentReportView()
        {
            InitializeComponent();

            _presenter = new DailyAdjustmentReportPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        #region IDailyAdjustmentReportView Members

        public DateTime Date { get; set; }

        public void PopulateReports(IList<DailyAdjustment> adjustments)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("Date", Date.ToString(), true),
                new ReportParameter("RunDate", DateTime.Now.ToString(), true)
            };

            _dailyAdjustmentBindingSource.DataSource = adjustments;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }

        #endregion

        private void DailyAdjustmentReportView_Load(object sender, EventArgs e)
        {
            _presenter.PopulateReports();
        }
    }
}
