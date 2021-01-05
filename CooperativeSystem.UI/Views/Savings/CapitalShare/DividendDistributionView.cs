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
    public partial class DividendDistributionView : FormTemplate, IDividendDistributionView
    {
        private DividendDistributionPresenter _presenter;
        private PostingView _postingView;

        #region IDividendDistributionView Members

        public string UserID { get; set; }

        public int Year
        {
            get { return Convert.ToInt16(_yearNumericUpDown.Value); }
        }

        public decimal TotalDividendForDistribution
        {
            set { _totalDividendForDistributionTextBox.Text = value.ToString("N2"); }
        }

        public decimal TotalDividend
        {
            set { _totalDividendTextBox.Text = value.ToString("N2"); }
        }

        public decimal TotalAverageShare
        {
            set { _totalAverageShareTextBox.Text = value.ToString("N2"); }
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

        public void PopulateReports(IList<DividendDistributionItem> dividendDistributionItems)
        {
            _dividendDistributionItemBindingSource.DataSource = dividendDistributionItems;
            _reportViewer.RefreshReport();
        }

        #endregion

        public DividendDistributionView(string userID)
        {
            InitializeComponent();

            UserID = userID;

            _postingView = new PostingView();
            _presenter = new DividendDistributionPresenter(this, _postingView);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void DividendDistributionView_Load(object sender, EventArgs e)
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
                using (var view = new DividendDistributionSummaryReportView())
                {
                    view.Populate(summary, this.Year);
                    view.ShowDialog(this);
                }
            }
        }
    }
}
