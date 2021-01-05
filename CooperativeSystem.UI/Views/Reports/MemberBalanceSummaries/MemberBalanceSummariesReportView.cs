using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.Reports.MemberBalanceSummaries;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.MemberBalanceSummaries
{
    public partial class MemberBalanceSummariesReportView : ReportViewTemplate, IMemberBalanceSummariesReportView
    {
        public MemberBalanceSummariesReportView()
        {
            InitializeComponent();
        }

        #region IMemberBalanceSummariesReportView Members

        public DateTime Date { get; set; }

        public string MembershipCategory { get; set; }

        public IList<MemberBalanceSummaryItem> BalanceSummaries { get; set; }

        #endregion

        private void MemberBalanceSummariesReportView_Load(object sender, EventArgs e)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("Date", Date.ToString(), true),
                new ReportParameter("RunDate", DateTime.Now.ToString(), true),
                new ReportParameter("MembershipCategory", MembershipCategory, true)
            };

            _memberBalanceSummaryItemBindingSource.DataSource = BalanceSummaries;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }
    }
}
