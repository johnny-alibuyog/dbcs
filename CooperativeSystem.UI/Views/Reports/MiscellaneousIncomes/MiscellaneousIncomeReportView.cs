using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Reports.MiscellaneousIncomes;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Reports.MiscellaneousIncomes
{
    public partial class MiscellaneousIncomeReportView : FormTemplate, IMiscellaneousIncomeReportView
    {
        private readonly MiscellaneousIncomeReportPresenter _presenter;

        public MiscellaneousIncomeReportView()
        {
            InitializeComponent();

            _presenter = new MiscellaneousIncomeReportPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

        }

        #region IMiscellaneousIncomeReportView Members

        public DateTime FromDate
        {
            get { return _fromDateDateTimePicker.Value; }
            set { _fromDateDateTimePicker.Value = value; }
        }

        public DateTime ToDate
        {
            get { return _toDateDateTimePicker.Value; }
            set { _toDateDateTimePicker.Value = value; }
        }

        public MiscellaneousIncomeType Type
        {
            get { return _typeComboBox.SelectedItem as MiscellaneousIncomeType; }
            set { _typeComboBox.SelectedItem = value; }
        }

        public void PopulateTypePulldown(IList<MiscellaneousIncomeType> items)
        {
            _typeComboBox.DataSource = items;
            _typeComboBox.DisplayMember = "Name";
            _typeComboBox.ValueMember = "ID";
        }

        public void PopulateReport(IList<MiscellaneousIncomeItem> items)
        {
            var reportParameters = new List<ReportParameter>() 
            { 
                new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
                new ReportParameter("Address", Program.AppData.Address),
                new ReportParameter("FromDate", this.FromDate.ToString()),
                new ReportParameter("ToDate", this.ToDate.ToString()),
            };

            _miscellaneousIncomeItemBindingSource.DataSource = items;
            _reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }

        #endregion

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            _presenter.Populate();
        }
    }
}
