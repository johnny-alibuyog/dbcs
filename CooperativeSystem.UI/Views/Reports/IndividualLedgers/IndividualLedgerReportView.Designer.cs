namespace CooperativeSystem.UI.Views.Reports.IndividualLedgers
{
    partial class IndividualLedgerReportView
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this._loanAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._savingsAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._loanAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._savingsAccountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _reportViewer
            // 
            reportDataSource1.Name = "CooperativeSystem_Service_Presenters_Reports_IndividualLedgers_LoanAccount";
            reportDataSource1.Value = this._loanAccountBindingSource;
            reportDataSource2.Name = "CooperativeSystem_Service_Presenters_Reports_IndividualLedgers_SavingsAccount";
            reportDataSource2.Value = this._savingsAccountBindingSource;
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "CooperativeSystem.UI.Views.Reports.IndividualLedgers.IndividualLedgerReport.rdlc";
            // 
            // _loanAccountBindingSource
            // 
            this._loanAccountBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Reports.IndividualLedgers.LoanAccount);
            // 
            // _savingsAccountBindingSource
            // 
            this._savingsAccountBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Reports.IndividualLedgers.SavingsAccount);
            // 
            // IndividualLedgerReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 266);
            this.Name = "IndividualLedgerReportView";
            this.Text = "Individual Ledger Report";
            this.Load += new System.EventHandler(this.IndividualLedgerReportView_Load);
            ((System.ComponentModel.ISupportInitialize)(this._loanAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._savingsAccountBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource _loanAccountBindingSource;
        private System.Windows.Forms.BindingSource _savingsAccountBindingSource;

    }
}