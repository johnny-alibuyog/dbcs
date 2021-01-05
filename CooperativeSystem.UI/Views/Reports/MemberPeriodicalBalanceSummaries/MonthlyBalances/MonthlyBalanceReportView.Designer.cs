namespace CooperativeSystem.UI.Views.Reports.MemberPeriodicalBalanceSummaries.MonthlyBalances
{
    partial class MonthlyBalanceReportView
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
            this._periodicalBalanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._periodicalBalanceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _reportViewer
            // 
            reportDataSource1.Name = "PeriodicalBalanceDataSet";
            reportDataSource1.Value = this._periodicalBalanceBindingSource;
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "CooperativeSystem.UI.Views.Reports.MemberPeriodicalBalanceSummaries.MonthlyBalanc" +
    "es.MonthlyBalanceReport.rdlc";
            // 
            // _periodicalBalanceBindingSource
            // 
            this._periodicalBalanceBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Reports.MemberPeriodicalBalanceSummaries.PeriodicalBalance);
            // 
            // MonthlyBalanceReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 266);
            this.Name = "MonthlyBalanceReportView";
            this.Text = "MonthlyBalanceReportView";
            this.Load += new System.EventHandler(this.MonthlyBalanceReportView_Load);
            this.Shown += new System.EventHandler(this.MonthlyBalanceReportView_Shown);
            ((System.ComponentModel.ISupportInitialize)(this._periodicalBalanceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource _periodicalBalanceBindingSource;
    }
}