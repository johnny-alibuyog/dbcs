namespace CooperativeSystem.UI.Views.Reports.Adjustments.MonthlyAdjustments
{
    partial class MonthlyAdjustmentReportView
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
            this._monthlyAdjustmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._monthlyAdjustmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _reportViewer
            // 
            reportDataSource1.Name = "CooperativeSystem_Service_Presenters_Reports_Adjustments_MonthlyAdjustments_Month" +
                "lyAdjustment";
            reportDataSource1.Value = this._monthlyAdjustmentBindingSource;
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "CooperativeSystem.UI.Views.Reports.Adjustments.MonthlyAdjustments.MonthlyAdjustme" +
                "ntReport.rdlc";
            // 
            // _monthlyAdjustmentBindingSource
            // 
            this._monthlyAdjustmentBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Reports.Adjustments.MonthlyAdjustments.MonthlyAdjustment);
            // 
            // MonthlyAdjustmentReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 266);
            this.Name = "MonthlyAdjustmentReportView";
            this.Text = "Monthly Adjustment Report";
            this.Load += new System.EventHandler(this.MonthlyAdjustmentReportView_Load);
            ((System.ComponentModel.ISupportInitialize)(this._monthlyAdjustmentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource _monthlyAdjustmentBindingSource;

    }
}