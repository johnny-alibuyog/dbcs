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
using CooperativeSystem.Service.Presenters.Reports.Collections.YearlyCollections;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.Collections.YearlyCollections
{
    public partial class YearlyCollectionReportView : ReportViewTemplate, IYearlyCollectionReportView
    {
        private YearlyCollectionReportPresenter _presenter;

        public YearlyCollectionReportView()
        {
            InitializeComponent();

            _presenter = new YearlyCollectionReportPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void YearlyCollecitonReportView_Load(object sender, EventArgs e)
        {
            _presenter.PopulateReports();
        }

        #region IYearlyCollectionReportView Members

        public DateTime Date { get; set; }

        public void PopulateReports(IList<YearlyCollection> collections)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("Date", Date.ToString(), true),
                new ReportParameter("RunDate", DateTime.Now.ToString(), true)
            };

            this._yearlyCollectionBindingSource.DataSource = collections;
            this._reportViewer.LocalReport.SetParameters(reportParameters);
            this._reportViewer.RefreshReport();
        }

        #endregion
    }
}
