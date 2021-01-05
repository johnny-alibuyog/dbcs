namespace CooperativeSystem.UI.Views.Reports.Disbursements.DailyDisbursements
{
    partial class DailyDisbursementReportView
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
            this._dailyDisbursementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._dailyDisbursementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _reportViewer
            // 
            reportDataSource1.Name = "CooperativeSystem_Service_Presenters_Reports_Disbursements_DailyDisbursements_DailyDisbursement";
            reportDataSource1.Value = this._dailyDisbursementBindingSource;
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "CooperativeSystem.UI.Views.Reports.Disbursements.DailyDisbursements.DailyDisbursementReport.rdlc";
            // 
            // _dailyDisbursementBindingSource
            // 
            this._dailyDisbursementBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Reports.Disbursements.DailyDisbursements.DailyDisbursement);
            // 
            // DailyDisbursementReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 266);
            this.Name = "DailyDisbursementReportView";
            this.Text = "Daily Disbursement Report";
            this.Load += new System.EventHandler(this.DailyDisbursementReportView_Load);
            ((System.ComponentModel.ISupportInitialize)(this._dailyDisbursementBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource _dailyDisbursementBindingSource;




    }
}