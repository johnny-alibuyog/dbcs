namespace CooperativeSystem.UI.Views.Savings.CapitalShare
{
    partial class DividendDistributionSummaryReportView
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
            this._dividendDistributionSummaryItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._dividendDistributionSummaryItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _reportViewer
            // 
            reportDataSource1.Name = "DividendDistributionSummaryItemDataSet";
            reportDataSource1.Value = this._dividendDistributionSummaryItemBindingSource;
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "CooperativeSystem.UI.Views.Savings.CapitalShare.DividendDistributionSummaryReport" +
    ".rdlc";
            // 
            // _dividendDistributionSummaryItemBindingSource
            // 
            this._dividendDistributionSummaryItemBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Savings.CapitalShare.DividendDistributionSummaryItem);
            // 
            // DividendDistributionSummaryReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 266);
            this.Name = "DividendDistributionSummaryReportView";
            this.Text = "Dividend Distribution Summary Report";
            this.Load += new System.EventHandler(this.DividendDistributionSummaryReportView_Load);
            ((System.ComponentModel.ISupportInitialize)(this._dividendDistributionSummaryItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource _dividendDistributionSummaryItemBindingSource;
    }
}