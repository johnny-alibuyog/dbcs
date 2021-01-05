namespace CooperativeSystem.UI.Views.Reports.Notices
{
    partial class NoticeReportView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._generateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._noticeTypeComboBox = new System.Windows.Forms.ComboBox();
            this._reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._generateButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._noticeTypeComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(854, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // _generateButton
            // 
            this._generateButton.Location = new System.Drawing.Point(309, 18);
            this._generateButton.Name = "_generateButton";
            this._generateButton.Size = new System.Drawing.Size(75, 23);
            this._generateButton.TabIndex = 2;
            this._generateButton.Text = "Generate";
            this._generateButton.UseVisualStyleBackColor = true;
            this._generateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Notice Type:";
            // 
            // _noticeTypeComboBox
            // 
            this._noticeTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._noticeTypeComboBox.FormattingEnabled = true;
            this._noticeTypeComboBox.Items.AddRange(new object[] {
            "First Notice",
            "Second Notice",
            "Final Notice"});
            this._noticeTypeComboBox.Location = new System.Drawing.Point(107, 20);
            this._noticeTypeComboBox.Name = "_noticeTypeComboBox";
            this._noticeTypeComboBox.Size = new System.Drawing.Size(196, 21);
            this._noticeTypeComboBox.TabIndex = 0;
            // 
            // _reportViewer
            // 
            this._reportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._reportViewer.Location = new System.Drawing.Point(12, 73);
            this._reportViewer.Name = "_reportViewer";
            this._reportViewer.Size = new System.Drawing.Size(854, 378);
            this._reportViewer.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 454);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(878, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // NoticeReportView
            // 
            this.AcceptButton = this._generateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 476);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._reportViewer);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NoticeReportView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Notice Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _generateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _noticeTypeComboBox;
        private Microsoft.Reporting.WinForms.ReportViewer _reportViewer;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}