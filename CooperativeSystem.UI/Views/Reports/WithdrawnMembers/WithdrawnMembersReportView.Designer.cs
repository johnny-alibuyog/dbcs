namespace CooperativeSystem.UI.Views.Reports.WithdrawnMembers
{
    partial class WithdrawnMembersReportView
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
            this._withdrawnMemberModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._withdrawnMemberModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _reportViewer
            // 
            reportDataSource1.Name = "WithdrawnMembersDataSet";
            reportDataSource1.Value = this._withdrawnMemberModelBindingSource;
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "CooperativeSystem.UI.Views.Reports.WithdrawnMembers.WithdrawnMembersReport.rdlc";
            this._reportViewer.Size = new System.Drawing.Size(403, 320);
            // 
            // _withdrawnMemberModelBindingSource
            // 
            this._withdrawnMemberModelBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Reports.WithdrawnMembers.WithdrawnMemberModel);
            // 
            // WithdrawnMembersReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 320);
            this.Name = "WithdrawnMembersReportView";
            this.Text = "Withdrawn Members Report";
            this.Load += new System.EventHandler(this.WithdrawnMembersReportView_Load);
            ((System.ComponentModel.ISupportInitialize)(this._withdrawnMemberModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource _withdrawnMemberModelBindingSource;

    }
}