using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.Reports.WithdrawnMembers;
using CooperativeSystem.Service.Presenters;
using Microsoft.Reporting.WinForms;
using CooperativeSystem.UI.Properties;

namespace CooperativeSystem.UI.Views.Reports.WithdrawnMembers
{
    public partial class WithdrawnMembersReportView : ReportViewTemplate, IWithdrawnMembersReportView
    {
        private WithdrawnMemberReportPresenter _presenter;

        #region IWithdrawnMembersReportView Members

        public void PopulateReports(IList<WithdrawnMemberModel> withdrawnMembers)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
            };

            _withdrawnMemberModelBindingSource.DataSource = withdrawnMembers;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }

        #endregion

        public WithdrawnMembersReportView()
        {
            InitializeComponent();

            _presenter = new WithdrawnMemberReportPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void WithdrawnMembersReportView_Load(object sender, EventArgs e)
        {
            _presenter.PopulateReports();
        }
    }
}
