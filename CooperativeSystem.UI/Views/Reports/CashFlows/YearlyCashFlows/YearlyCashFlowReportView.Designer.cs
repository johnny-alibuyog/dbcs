namespace CooperativeSystem.UI.Views.Reports.CashFlows.YearlyCashFlows
{
    partial class YearlyCashFlowReportView
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
            this._yearlyCashFlowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._yearlyCashFlowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _reportViewer
            // 
            reportDataSource1.Name = "CooperativeSystem_Service_Presenters_Reports_CashFlows_YearlyCashFlows_YearlyCash" +
                "Flow";
            reportDataSource1.Value = this._yearlyCashFlowBindingSource;
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "CooperativeSystem.UI.Views.Reports.CashFlows.YearlyCashFlows.YearlyCashFlowReport" +
                ".rdlc";
            // 
            // _yearlyCashFlowBindingSource
            // 
            this._yearlyCashFlowBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Reports.CashFlows.YearlyCashFlows.YearlyCashFlow);
            // 
            // YearlyCashFlowReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 266);
            this.Name = "YearlyCashFlowReportView";
            this.Text = "Yearly Cash Flow Report";
            this.Load += new System.EventHandler(this.YearlyCashFlowReportView_Load);
            ((System.ComponentModel.ISupportInitialize)(this._yearlyCashFlowBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource _yearlyCashFlowBindingSource;

    }
}