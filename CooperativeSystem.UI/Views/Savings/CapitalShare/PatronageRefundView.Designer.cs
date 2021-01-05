namespace CooperativeSystem.UI.Views.Savings.CapitalShare
{
    partial class PatronageRefundView
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
            this._patronageRefundItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this._totalAveragePatronageTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._totalPatronageTextBox = new System.Windows.Forms.TextBox();
            this._yearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._totalPatronageForRefundTextBox = new System.Windows.Forms.TextBox();
            this._generateButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._saveButton = new System.Windows.Forms.Button();
            this._closeButton = new System.Windows.Forms.Button();
            this._postButton = new System.Windows.Forms.Button();
            this._summaryButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._patronageRefundItemBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._yearNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // _patronageRefundItemBindingSource
            // 
            this._patronageRefundItemBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Savings.CapitalShare.PatronageRefundItem);
            // 
            // _reportViewer
            // 
            this._reportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "PatronageRefundDataSet";
            reportDataSource1.Value = this._patronageRefundItemBindingSource;
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "CooperativeSystem.UI.Views.Savings.CapitalShare.PatronageRefundReport.rdlc";
            this._reportViewer.Location = new System.Drawing.Point(12, 78);
            this._reportViewer.Name = "_reportViewer";
            this._reportViewer.Size = new System.Drawing.Size(815, 283);
            this._reportViewer.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this._totalAveragePatronageTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._totalPatronageTextBox);
            this.groupBox1.Controls.Add(this._yearNumericUpDown);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._totalPatronageForRefundTextBox);
            this.groupBox1.Controls.Add(this._generateButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(815, 60);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(652, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Total Average Patronage";
            // 
            // _totalAveragePatronageTextBox
            // 
            this._totalAveragePatronageTextBox.Location = new System.Drawing.Point(627, 32);
            this._totalAveragePatronageTextBox.Name = "_totalAveragePatronageTextBox";
            this._totalAveragePatronageTextBox.ReadOnly = true;
            this._totalAveragePatronageTextBox.Size = new System.Drawing.Size(153, 21);
            this._totalAveragePatronageTextBox.TabIndex = 7;
            this._totalAveragePatronageTextBox.TabStop = false;
            this._totalAveragePatronageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(524, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Total Patronage";
            // 
            // _totalPatronageTextBox
            // 
            this._totalPatronageTextBox.Location = new System.Drawing.Point(455, 32);
            this._totalPatronageTextBox.Name = "_totalPatronageTextBox";
            this._totalPatronageTextBox.ReadOnly = true;
            this._totalPatronageTextBox.Size = new System.Drawing.Size(153, 21);
            this._totalPatronageTextBox.TabIndex = 5;
            this._totalPatronageTextBox.TabStop = false;
            this._totalPatronageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _yearNumericUpDown
            // 
            this._yearNumericUpDown.Location = new System.Drawing.Point(9, 33);
            this._yearNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this._yearNumericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._yearNumericUpDown.Name = "_yearNumericUpDown";
            this._yearNumericUpDown.Size = new System.Drawing.Size(153, 21);
            this._yearNumericUpDown.TabIndex = 0;
            this._yearNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._yearNumericUpDown.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this._yearNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Total Patronage for Refund";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Year";
            // 
            // _totalPatronageForRefundTextBox
            // 
            this._totalPatronageForRefundTextBox.Location = new System.Drawing.Point(280, 33);
            this._totalPatronageForRefundTextBox.Name = "_totalPatronageForRefundTextBox";
            this._totalPatronageForRefundTextBox.ReadOnly = true;
            this._totalPatronageForRefundTextBox.Size = new System.Drawing.Size(153, 21);
            this._totalPatronageForRefundTextBox.TabIndex = 2;
            this._totalPatronageForRefundTextBox.TabStop = false;
            this._totalPatronageForRefundTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _generateButton
            // 
            this._generateButton.Location = new System.Drawing.Point(168, 31);
            this._generateButton.Name = "_generateButton";
            this._generateButton.Size = new System.Drawing.Size(75, 23);
            this._generateButton.TabIndex = 0;
            this._generateButton.TabStop = false;
            this._generateButton.Text = "&Generate";
            this._generateButton.UseVisualStyleBackColor = true;
            this._generateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 393);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(839, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _saveButton
            // 
            this._saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._saveButton.Enabled = false;
            this._saveButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._saveButton.Location = new System.Drawing.Point(671, 367);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(75, 23);
            this._saveButton.TabIndex = 7;
            this._saveButton.TabStop = false;
            this._saveButton.Text = "&Save";
            this._saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // _closeButton
            // 
            this._closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(752, 367);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 6;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = true;
            // 
            // _postButton
            // 
            this._postButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._postButton.Enabled = false;
            this._postButton.Image = global::CooperativeSystem.UI.Properties.Resources.edit;
            this._postButton.Location = new System.Drawing.Point(590, 367);
            this._postButton.Name = "_postButton";
            this._postButton.Size = new System.Drawing.Size(75, 23);
            this._postButton.TabIndex = 11;
            this._postButton.TabStop = false;
            this._postButton.Text = "&Post";
            this._postButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._postButton.UseVisualStyleBackColor = true;
            this._postButton.Click += new System.EventHandler(this.PostButton_Click);
            // 
            // _summaryButton
            // 
            this._summaryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._summaryButton.Enabled = false;
            this._summaryButton.Image = global::CooperativeSystem.UI.Properties.Resources.find;
            this._summaryButton.Location = new System.Drawing.Point(509, 367);
            this._summaryButton.Name = "_summaryButton";
            this._summaryButton.Size = new System.Drawing.Size(75, 23);
            this._summaryButton.TabIndex = 12;
            this._summaryButton.TabStop = false;
            this._summaryButton.Text = "Su&mmary";
            this._summaryButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._summaryButton.UseVisualStyleBackColor = true;
            this._summaryButton.Click += new System.EventHandler(this.SummaryButton_Click);
            // 
            // PatronageRefundView
            // 
            this.AcceptButton = this._generateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(839, 415);
            this.Controls.Add(this._summaryButton);
            this.Controls.Add(this._postButton);
            this.Controls.Add(this._reportViewer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "PatronageRefundView";
            this.Text = "Patronage Refund";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PatronageRefundView_Load);
            ((System.ComponentModel.ISupportInitialize)(this._patronageRefundItemBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._yearNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer _reportViewer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown _yearNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _totalPatronageForRefundTextBox;
        private System.Windows.Forms.Button _generateButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.BindingSource _patronageRefundItemBindingSource;
        private System.Windows.Forms.Button _postButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _totalAveragePatronageTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _totalPatronageTextBox;
        private System.Windows.Forms.Button _summaryButton;

    }
}