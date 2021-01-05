using System;
using System.Collections.Generic;
using CooperativeSystem.Service.Presenters.Reports.IndividualLedgers;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.IndividualLedgers
{
    public partial class IndividualLedgerReportView : ReportViewTemplate, IIndividualLedgerReportView
    {
        public IndividualLedgerReportView()
        {
            InitializeComponent();
        }

        #region IIndividualLedgerReportView Members

        public DateTime Date { get; set; }

        public string MembershipCategory { get; set; }

        public IList<LoanAccount> LoanAccounts { get; set; }

        public IList<SavingsAccount> SavingsAccounts { get; set; }

        #endregion

        private void IndividualLedgerReportView_Load(object sender, EventArgs e)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("Date", Date.ToString(), true),
                new ReportParameter("RunDate", DateTime.Now.ToString(), true),
                new ReportParameter("MembershipCategory", MembershipCategory, true)
            };

            _savingsAccountBindingSource.DataSource = SavingsAccounts;
            _loanAccountBindingSource.DataSource = LoanAccounts;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }
    }
}
