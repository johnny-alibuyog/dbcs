using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Reports.MembersInformations;

namespace CooperativeSystem.UI.Views.Reports.MembersInformations
{
    public partial class MembersInformationsReportView : ReportViewTemplate, IMembersInformationsReportView
    {
        private readonly MembersInformationsReportPresenter _presenter;

        #region IMembersInformationsReportView Members

        public void Populate(IList<MembersInformationsReportModel> items)
        {
            _membersInformationsReportModelBindingSource.DataSource = items;
            _reportViewer.RefreshReport();
        }

        #endregion

        public MembersInformationsReportView()
        {
            InitializeComponent();

            _presenter = new MembersInformationsReportPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void MembersInformationsReportView_Load(object sender, EventArgs e)
        {
            _presenter.Populate();
        }
    }
}
