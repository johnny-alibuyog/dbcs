namespace CooperativeSystem.UI.Views.Savings.CapitalShare
{
    partial class PatronageRefundSummaryReportView
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
            this._patronageRefundSummaryItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._patronageRefundSummaryItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _reportViewer
            // 
            reportDataSource1.Name = "PatronageRefundSummaryItemDataSet";
            reportDataSource1.Value = this._patronageRefundSummaryItemBindingSource;
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "CooperativeSystem.UI.Views.Savings.CapitalShare.PatronageRefundSummaryReport.rdlc" +
    "";
            this._reportViewer.Size = new System.Drawing.Size(284, 262);
            // 
            // _patronageRefundSummaryItemBindingSource
            // 
            this._patronageRefundSummaryItemBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Savings.CapitalShare.PatronageRefundSummaryItem);
            // 
            // PatronageRefundSummaryReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "PatronageRefundSummaryReportView";
            this.Text = "Patronage Refund Summary Report";
            this.Load += new System.EventHandler(this.PatronageRefundSummaryReportView_Load);
            ((System.ComponentModel.ISupportInitialize)(this._patronageRefundSummaryItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource _patronageRefundSummaryItemBindingSource;
    }
}