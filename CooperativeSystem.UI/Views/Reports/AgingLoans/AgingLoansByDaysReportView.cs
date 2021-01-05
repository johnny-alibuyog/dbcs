using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Reports.AgingLoans;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.AgingLoans
{
    public partial class AgingLoansByDaysReportView : ReportViewTemplate, IAgingLoansReportView
    {
        private bool _usePresenter;
        private AgingLoansReportPresenter _presenter;

        public AgingLoansByDaysReportView() : this(true) { }

        public AgingLoansByDaysReportView(bool usePresenter)
        {
            InitializeComponent();

            _usePresenter = usePresenter;

            _presenter = new AgingLoansReportPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        #region IAgingLoansReportView Members

        public void PopulateReports(IList<AgingLoanModel> agingLoans)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address)
            };

            _agingLoanModelBindingSource.DataSource = agingLoans;
            //_agingLoan2ModelBindingSource.DataSource = agingLoans;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }

        #endregion

        private void AgingLoansByDaysReportView_Load(object sender, EventArgs e)
        {
            if (_usePresenter)
                _presenter.PopulateReports();
        }
    }
}
