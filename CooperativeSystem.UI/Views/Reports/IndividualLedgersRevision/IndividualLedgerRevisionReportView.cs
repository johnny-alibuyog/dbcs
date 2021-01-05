using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Presenters.Reports;
using CooperativeSystem.Service.Presenters.Reports.IndividualLedgersRevision;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.IndividualLedgersRevision
{
    public partial class IndividualLedgerRevisionReportView : FormTemplate, IIndividualLedgerRevisionReportView
    {
        public IndividualLedgerRevisionReportView()
        {
            InitializeComponent();
        }
        
        #region IIndividualLedgerRevisionReportView Members

        public DateTime Date { get; set; }

        public string MembershipCategory { get; set; }

        public IList<Account> Accounts { get; set; }

        #endregion

        private void IndividualLedgerRevisionReportView_Load(object sender, EventArgs e)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("Date", Date.ToString(), true),
                new ReportParameter("RunDate", DateTime.Now.ToString(), true),
                new ReportParameter("MembershipCategory", MembershipCategory, true)
            };

            _accountBindingSource.DataSource = Accounts;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }
    }
}
