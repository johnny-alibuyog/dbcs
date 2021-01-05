using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Savings.CapitalShare;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Savings.CapitalShare
{
    public partial class PatronageRefundView : FormTemplate, IPatronageRefundView
    {
        private PatronageRefundPresenter _presenter;
        private PostingView _postingView;

        #region IPatronageRefundView

        public string UserID { get; set; }

        public int Year
        {
            get { return (int)_yearNumericUpDown.Value; }
        }

        public decimal TotalPatronageForRefund
        {
            set { _totalPatronageForRefundTextBox.Text = value.ToString("N2"); }
        }

        public decimal TotalPatronage
        {
            set { _totalPatronageTextBox.Text = value.ToString("N2"); }
        }

        public decimal TotalAveragePatronage
        {
            set { _totalAveragePatronageTextBox.Text = value.ToString("N2"); }
        }

        public bool AllowSummary
        {
            set { _summaryButton.Enabled = value; }
        }

        public bool AllowSave
        {
            set { _saveButton.Enabled = value; }
        }

        public bool AllowPost
        {
            set { _postButton.Enabled = value; }
        }

        public void PopulateReports(IList<PatronageRefundItem> patronageRefundItems)
        {
            //var reportParameters = new List<ReportParameter>() 
            //{ 
            //    new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
            //    new ReportParameter("Address", Program.AppData.Address),
            //};

            _patronageRefundItemBindingSource.DataSource = patronageRefundItems;
            //_reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }

        #endregion

        public PatronageRefundView(string userID)
        {
            InitializeComponent();

            UserID = userID;

            _postingView = new PostingView();
            _presenter = new PatronageRefundPresenter(this, _postingView);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void PatronageRefundView_Load(object sender, EventArgs e)
        {
            _yearNumericUpDown.Value = DateTime.Today.Year;
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            _presenter.Generate();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!ControlValidator.Validate())
                return;

            if (AskConfirmation(this, "Do you want to save?") != DialogResult.Yes)
                return;

            _presenter.Save();
        }

        private void PostButton_Click(object sender, EventArgs e)
        {
            _postingView.ShowDialog(this);
        }

        private void SummaryButton_Click(object sender, EventArgs e)
        {
            var summary = _presenter.GetSummary();
            if (summary != null)
            {
                using (var view = new PatronageRefundSummaryReportView())
                {
                    view.Populate(summary, this.Year);
                    view.ShowDialog(this);
                }
            }
        }
    }
}
