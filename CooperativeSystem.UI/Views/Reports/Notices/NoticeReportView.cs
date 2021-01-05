using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.Reports.Notices;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.Notices
{
    public partial class NoticeReportView : FormTemplate, INoticeReportView
    {
        private readonly NoticeReportPresenter _presenter;
        private BindingSource _bindingSource;
        private IContainer _container;

        #region INoticeReportView Members

        public NoticeType SelectedNoticeType
        {
            get { return _noticeTypeComboBox.SelectedItem as NoticeType; }
            set { _noticeTypeComboBox.SelectedItem = value; }
        }

        public IEnumerable<NoticeType> NoticeTypes
        {
            set
            {
                _noticeTypeComboBox.DataSource = value;
                _noticeTypeComboBox.ValueMember = "Key";
                _noticeTypeComboBox.DisplayMember = "Value";
            }
        }

        public void PopulateReports(IList<NoticeReportItem> items)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("TelephoneNumber", Program.AppData.TelephoneNumber),
                new ReportParameter("Address", Program.AppData.Address),
            };

            _bindingSource.DataSource = items;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }

        #endregion

        public NoticeReportView()
        {
            InitializeComponent();

            _noticeTypeComboBox.SelectedIndexChanged += (sender, e) =>
            {
                var noticeType = _noticeTypeComboBox.SelectedItem as NoticeType;
                if (noticeType != null)
                {
                    // initialize report viewer
                    _container = new Container();
                    _bindingSource = new BindingSource(_container);

                    ((ISupportInitialize)(_bindingSource)).BeginInit();
                    _reportViewer.LocalReport.DataSources.Clear();
                    _reportViewer.LocalReport.DataSources.Add(new ReportDataSource()
                    {
                        Name = "ItemDataSet",
                        Value = _bindingSource,
                    });
                    _reportViewer.LocalReport.ReportEmbeddedResource = "CooperativeSystem.UI.Views.Reports.Notices." + noticeType.ReportName;
                    ((ISupportInitialize)(_bindingSource)).EndInit();
                }
            };

            _presenter = new NoticeReportPresenter(this);
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            _presenter.PopulateReport();
        }
    }
}
