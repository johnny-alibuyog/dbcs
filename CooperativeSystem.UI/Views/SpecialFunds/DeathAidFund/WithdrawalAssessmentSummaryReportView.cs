using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.SpecialFunds.DeathAidFund;
using CooperativeSystem.UI.Properties;
using CooperativeSystem.UI.Views.Reports;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.SpecialFunds.DeathAidFund
{
    public partial class WithdrawalAssessmentSummaryReportView : ReportViewTemplate, IWithdrawalAssessmentSummaryReport
    {
        public WithdrawalAssessmentSummaryReportView()
        {
            InitializeComponent();
        }

        private void WithdrawalAssessmentSummaryReportView_Load(object sender, EventArgs e)
        {

        }

        public void PopulateReports(IList<DeathAidFundWithdrawalAssessmentItem> items)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("RunDate", DateTime.Now.ToString(), true)
            };

            _deathAidFundWithdrawalAssessmentItemBindingSource.DataSource = items;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();

        }
    }
}
