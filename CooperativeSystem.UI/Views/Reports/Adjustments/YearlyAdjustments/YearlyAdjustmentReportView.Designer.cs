namespace CooperativeSystem.UI.Views.Reports.Adjustments.YearlyAdjustments
{
    partial class YearlyAdjustmentReportView
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
            this._yearlyAdjustmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._yearlyAdjustmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _reportViewer
            // 
            reportDataSource1.Name = "CooperativeSystem_Service_Presenters_Reports_Adjustments_YearlyAdjustments_Yearly" +
                "Adjustment";
            reportDataSource1.Value = this._yearlyAdjustmentBindingSource;
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "CooperativeSystem.UI.Views.Reports.Adjustments.YearlyAdjustments.YearlyAdjustment" +
                "Report.rdlc";
            // 
            // _yearlyAdjustmentBindingSource
            // 
            this._yearlyAdjustmentBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Reports.Adjustments.YearlyAdjustments.YearlyAdjustment);
            // 
            // YearlyAdjustmentReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 266);
            this.Name = "YearlyAdjustmentReportView";
            this.Text = "Yearly Adjustment Report";
            this.Load += new System.EventHandler(this.YearlyAdjustmentReportView_Load);
            ((System.ComponentModel.ISupportInitialize)(this._yearlyAdjustmentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource _yearlyAdjustmentBindingSource;

    }
}