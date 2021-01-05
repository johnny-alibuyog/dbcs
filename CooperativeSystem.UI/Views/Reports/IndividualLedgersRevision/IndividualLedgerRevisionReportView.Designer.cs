namespace CooperativeSystem.UI.Views.Reports.IndividualLedgersRevision
{
    partial class IndividualLedgerRevisionReportView
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this._accountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this._accountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _accountBindingSource
            // 
            this._accountBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Reports.IndividualLedgersRevision.Account);
            // 
            // _reportViewer
            // 
            this._reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "IndividualLedgerRevisionDataSet";
            reportDataSource3.Value = this._accountBindingSource;
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource3);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "CooperativeSystem.UI.Views.Reports.IndividualLedgersRevision.IndividualLedgerRevi" +
                "sionReport.rdlc";
            this._reportViewer.Location = new System.Drawing.Point(0, 0);
            this._reportViewer.Name = "_reportViewer";
            this._reportViewer.Size = new System.Drawing.Size(412, 266);
            this._reportViewer.TabIndex = 0;
            // 
            // IndividualLedgerRevisionReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 266);
            this.Controls.Add(this._reportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "IndividualLedgerRevisionReportView";
            this.Text = "Individual Ledger Revision Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.IndividualLedgerRevisionReportView_Load);
            ((System.ComponentModel.ISupportInitialize)(this._accountBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer _reportViewer;
        private System.Windows.Forms.BindingSource _accountBindingSource;
    }
}