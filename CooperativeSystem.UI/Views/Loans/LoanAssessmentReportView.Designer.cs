namespace CooperativeSystem.UI.Views.Loans
{
    partial class LoanAssessmentReportView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this._loanAssessmentReportModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._loanAssessmentReportModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _reportViewer
            // 
            reportDataSource2.Name = "ItemDataSet";
            reportDataSource2.Value = this._loanAssessmentReportModelBindingSource;
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "CooperativeSystem.UI.Views.Loans.LoanAssessmentReport.rdlc";
            // 
            // _loanAssessmentReportModelBindingSource
            // 
            this._loanAssessmentReportModelBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Loans.LoanAssessmentReportModel);
            // 
            // LoanAssessmentReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 266);
            this.Name = "LoanAssessmentReportView";
            this.Text = "Loan Assessment Report";
            this.Load += new System.EventHandler(this.LoanAssessmentReportView_Load);
            ((System.ComponentModel.ISupportInitialize)(this._loanAssessmentReportModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource _loanAssessmentReportModelBindingSource;
    }
}