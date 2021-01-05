using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.UI.Views.Reports;
using CooperativeSystem.Service.Presenters.Loans;

namespace CooperativeSystem.UI.Views.Loans
{
    public partial class LoanAssessmentReportView : ReportViewTemplate, ILoanAssessmentReportView
    {
        public LoanAssessmentReportView()
        {
            InitializeComponent();
        }

        private void LoanAssessmentReportView_Load(object sender, EventArgs e)
        {
            _reportViewer.RefreshReport();
        }

        public void Populate(IList<LoanAssessmentReportModel> items)
        {
            _loanAssessmentReportModelBindingSource.DataSource = items;
            _reportViewer.RefreshReport();
        }
    }
}
