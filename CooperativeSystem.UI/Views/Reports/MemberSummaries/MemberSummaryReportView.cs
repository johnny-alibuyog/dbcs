using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Reports.MemberSummaries;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.MemberSummaries
{
    public partial class MemberSummaryReportView : ReportViewTemplate, IMemberSummaryReportView
    {
        private MemberSummaryReportPresenter _presenter;

        #region IMemberSummaryReportView Members

        public void PopulateReports(IList<MemberSummaryItem> members)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
            };

            _memberSummaryItemBindingSource.DataSource = members;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }

        #endregion

        public MemberSummaryReportView()
        {
            InitializeComponent();

            _presenter = new MemberSummaryReportPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void MemberSummaryReportView_Load(object sender, EventArgs e)
        {
            _presenter.PopulateReports();
        }
    }
}
