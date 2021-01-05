using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.Savings.CapitalShare;
using CooperativeSystem.UI.Properties;
using CooperativeSystem.UI.Views.Reports;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Savings.CapitalShare
{
    public partial class DividendDistributionSummaryReportView : ReportViewTemplate, IDividendDistributionSummaryReportView
    {
        public DividendDistributionSummaryReportView()
        {
            InitializeComponent();
        }

        public void Populate(IList<DividendDistributionSummaryItem> items, int year)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("Year", year.ToString(), true),
            };

            _dividendDistributionSummaryItemBindingSource.DataSource = items;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }

        private void DividendDistributionSummaryReportView_Load(object sender, EventArgs e)
        {

        }
    }
}
