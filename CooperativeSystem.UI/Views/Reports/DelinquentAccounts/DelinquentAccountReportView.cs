using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Reports.DelinquentAccounts;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.DelinquentAccounts
{
    public partial class DelinquentAccountReportView : ReportViewTemplate, IDelinquentAccountReportView
    {
        private bool _usePresenter;
        private DelinquentAccountReportPresenter _presenter;

        public DelinquentAccountReportView() : this(true) { }

        public DelinquentAccountReportView(bool usePresenter)
        {
            InitializeComponent();

            _usePresenter = usePresenter;
            _presenter = new DelinquentAccountReportPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void DelinquentAccountReportView_Load(object sender, EventArgs e)
        {
            if (_usePresenter)
                _presenter.PopulateReports();
        }

        #region IDelinquentAccountReportView Members

        public void PopulateReports(IList<DelinquentAccount> delinquentAccounts, decimal totalCapitalShare, decimal totalSavingsDeposit, decimal totalTimeDeposit, decimal totalOutstandingBalance, decimal totalNetExposure)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("TotalCapitalShare", totalCapitalShare.ToString("N2")),
                new ReportParameter("TotalSavingsDeposit", totalSavingsDeposit.ToString("N2")),
                new ReportParameter("TotalTimeDeposit", totalTimeDeposit.ToString("N2")),
                new ReportParameter("TotalOutstandingBalance", totalOutstandingBalance.ToString("N2")),
                new ReportParameter("TotalNetExposure", totalNetExposure.ToString("N2")),
            };

            _delinquentAccountBindingSource.DataSource = delinquentAccounts;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }

        #endregion
    }
}
