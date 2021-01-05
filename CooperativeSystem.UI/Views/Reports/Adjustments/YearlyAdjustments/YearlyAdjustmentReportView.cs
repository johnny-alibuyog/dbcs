using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Reports.Adjustments.YearlyAdjustments;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.Adjustments.YearlyAdjustments
{
    public partial class YearlyAdjustmentReportView : ReportViewTemplate, IYearlyAdjustmentReportView
    {
        private YearlyAdjustmentReportPresenter _presenter;

        public YearlyAdjustmentReportView()
        {
            InitializeComponent();

            _presenter = new YearlyAdjustmentReportPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void YearlyAdjustmentReportView_Load(object sender, EventArgs e)
        {
            _presenter.PopulateReports();
        }

        #region IYearlyAdjustmentReportView Members

        public DateTime Date { get; set; }

        public void PopulateReports(IList<YearlyAdjustment> adjustments)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("Date", Date.ToString(), true),
                new ReportParameter("RunDate", DateTime.Now.ToString(), true)
            };

            this._yearlyAdjustmentBindingSource.DataSource = adjustments;
            this._reportViewer.LocalReport.SetParameters(reportParameters);
            this._reportViewer.RefreshReport();
        }

        #endregion
    }
}
