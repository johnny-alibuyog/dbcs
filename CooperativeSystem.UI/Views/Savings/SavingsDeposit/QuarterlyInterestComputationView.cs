using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Savings.SavingsDeposit;
using CooperativeSystem.UI.Properties;
using Microsoft.Reporting.WinForms;

namespace CooperativeSystem.UI.Views.Savings.SavingsDeposit
{
    public partial class QuarterlyInterestComputationView : FormTemplate, IQuarterlyInterestComputationView
    {
        private QuarterlyInterestComputationPresenter _presenter;
        private PostingView _postingView;


        #region IQuarterlyInterestComputationView Members

        public string UserID { get; set; }

        public int Year
        {
            get { return (int)_yearNumericUpDown.Value; }
        }

        public int QuarterID
        {
            get { return (int)_quarterComboBox.SelectedValue; }
        }

        public bool AllowSave
        {
            set { _saveButton.Enabled = value; ; }
        }

        public bool AllowPost
        {
            set { _postButton.Enabled = value; }
        }

        public void PopulateQuaterPulldown(IList<Service.Models.Quarter> quarters)
        {
            _quarterComboBox.ValueMember = "QuarterID";
            _quarterComboBox.DisplayMember = "Name";
            _quarterComboBox.DataSource = quarters;
        }

        public void PopulateReports(IList<QuarterlyInterestComputationItem> quarterlyInterestItems)
        {
            //var reportParameters = new List<ReportParameter>() 
            //{ 
            //    new ReportParameter("OrganizationName", Program.AppData.OrganizationName),
            //    new ReportParameter("Address", Program.AppData.Address),
            //};

            _quarterlyInterestComputationItemBindingSource.DataSource = quarterlyInterestItems;
            //_reportViewer.LocalReport.SetParameters(reportParameters);
            _reportViewer.RefreshReport();
        }

        #endregion

        public QuarterlyInterestComputationView(string userID)
        {
            InitializeComponent();

            UserID = userID;

            _postingView = new PostingView();
            _presenter = new QuarterlyInterestComputationPresenter(this, _postingView);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void QuarterlyInterestComputationView_Load(object sender, EventArgs e)
        {
            _yearNumericUpDown.Value = DateTime.Today.Year;
            if (_quarterComboBox.Items.Count > 0)
                _quarterComboBox.SelectedIndex = 0;
        }

        private void ComputeButton_Click(object sender, EventArgs e)
        {
            _presenter.Compute();
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
    }
}
