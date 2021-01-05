namespace CooperativeSystem.UI.Views.Reports
{
    partial class ReportViewTemplate
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
            this._reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // _reportViewer
            // 
            this._reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._reportViewer.Location = new System.Drawing.Point(0, 0);
            this._reportViewer.Name = "_reportViewer";
            this._reportViewer.Size = new System.Drawing.Size(403, 266);
            this._reportViewer.TabIndex = 0;
            // 
            // ReportViewTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 266);
            this.Controls.Add(this._reportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "ReportViewTemplate";
            this.Text = "ReportViewTemplate";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportViewTemplate_Load);
            this.ResumeLayout(false);

        }

        #endregion

        protected Microsoft.Reporting.WinForms.ReportViewer _reportViewer;

    }
}