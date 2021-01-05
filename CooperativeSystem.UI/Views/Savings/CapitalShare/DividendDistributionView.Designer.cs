namespace CooperativeSystem.UI.Views.Savings.CapitalShare
{
    partial class DividendDistributionView
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this._dividendDistributionItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._closeButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._generateButton = new System.Windows.Forms.Button();
            this._yearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._totalAverageShareTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._totalDividendForDistributionTextBox = new System.Windows.Forms.TextBox();
            this._totalDividendTextBox = new System.Windows.Forms.TextBox();
            this._postButton = new System.Windows.Forms.Button();
            this._reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._saveButton = new System.Windows.Forms.Button();
            this._summaryButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._dividendDistributionItemBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._yearNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // _dividendDistributionItemBindingSource
            // 
            this._dividendDistributionItemBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Savings.CapitalShare.DividendDistributionItem);
            // 
            // _closeButton
            // 
            this._closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(792, 367);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 1;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this._generateButton);
            this.groupBox2.Controls.Add(this._yearNumericUpDown);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this._totalAverageShareTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this._totalDividendForDistributionTextBox);
            this.groupBox2.Controls.Add(this._totalDividendTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(855, 60);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // _generateButton
            // 
            this._generateButton.Location = new System.Drawing.Point(199, 31);
            this._generateButton.Name = "_generateButton";
            this._generateButton.Size = new System.Drawing.Size(75, 23);
            this._generateButton.TabIndex = 7;
            this._generateButton.TabStop = false;
            this._generateButton.Text = "&Generate";
            this._generateButton.UseVisualStyleBackColor = true;
            this._generateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // _yearNumericUpDown
            // 
            this._yearNumericUpDown.Location = new System.Drawing.Point(40, 33);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Year";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(557, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total Dividend";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Total Dividend for Distribution";
            // 
            // _totalAverageShareTextBox
            // 
            this._totalAverageShareTextBox.Location = new System.Drawing.Point(656, 33);
            this._totalAverageShareTextBox.Name = "_totalAverageShareTextBox";
            this._totalAverageShareTextBox.ReadOnly = true;
            this._totalAverageShareTextBox.Size = new System.Drawing.Size(153, 21);
            this._totalAverageShareTextBox.TabIndex = 5;
            this._totalAverageShareTextBox.TabStop = false;
            this._totalAverageShareTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(703, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total Average Share";
            // 
            // _totalDividendForDistributionTextBox
            // 
            this._totalDividendForDistributionTextBox.Location = new System.Drawing.Point(299, 33);
            this._totalDividendForDistributionTextBox.Name = "_totalDividendForDistributionTextBox";
            this._totalDividendForDistributionTextBox.ReadOnly = true;
            this._totalDividendForDistributionTextBox.Size = new System.Drawing.Size(153, 21);
            this._totalDividendForDistributionTextBox.TabIndex = 2;
            this._totalDividendForDistributionTextBox.TabStop = false;
            this._totalDividendForDistributionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _totalDividendTextBox
            // 
            this._totalDividendTextBox.Location = new System.Drawing.Point(479, 33);
            this._totalDividendTextBox.Name = "_totalDividendTextBox";
            this._totalDividendTextBox.ReadOnly = true;
            this._totalDividendTextBox.Size = new System.Drawing.Size(153, 21);
            this._totalDividendTextBox.TabIndex = 2;
            this._totalDividendTextBox.TabStop = false;
            this._totalDividendTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _postButton
            // 
            this._postButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._postButton.Enabled = false;
            this._postButton.Image = global::CooperativeSystem.UI.Properties.Resources.edit;
            this._postButton.Location = new System.Drawing.Point(630, 367);
            this._postButton.Name = "_postButton";
            this._postButton.Size = new System.Drawing.Size(75, 23);
            this._postButton.TabIndex = 7;
            this._postButton.TabStop = false;
            this._postButton.Text = "&Post";
            this._postButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._postButton.UseVisualStyleBackColor = true;
            this._postButton.Click += new System.EventHandler(this.PostButton_Click);
            // 
            // _reportViewer
            // 
            this._reportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource2.Name = "DividendDistributionItemDataSet";
            reportDataSource2.Value = this._dividendDistributionItemBindingSource;
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "CooperativeSystem.UI.Views.Savings.CapitalShare.DividendDistributionReport.rdlc";
            this._reportViewer.Location = new System.Drawing.Point(12, 78);
            this._reportViewer.Name = "_reportViewer";
            this._reportViewer.Size = new System.Drawing.Size(855, 283);
            this._reportViewer.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 393);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(879, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _saveButton
            // 
            this._saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._saveButton.Enabled = false;
            this._saveButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._saveButton.Location = new System.Drawing.Point(711, 367);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(75, 23);
            this._saveButton.TabIndex = 2;
            this._saveButton.TabStop = false;
            this._saveButton.Text = "&Save";
            this._saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // _summaryButton
            // 
            this._summaryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._summaryButton.Enabled = false;
            this._summaryButton.Image = global::CooperativeSystem.UI.Properties.Resources.find;
            this._summaryButton.Location = new System.Drawing.Point(549, 367);
            this._summaryButton.Name = "_summaryButton";
            this._summaryButton.Size = new System.Drawing.Size(75, 23);
            this._summaryButton.TabIndex = 9;
            this._summaryButton.TabStop = false;
            this._summaryButton.Text = "Su&mmary";
            this._summaryButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._summaryButton.UseVisualStyleBackColor = true;
            this._summaryButton.Click += new System.EventHandler(this.SummaryButton_Click);
            // 
            // DividendDistributionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(879, 415);
            this.Controls.Add(this._summaryButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this._postButton);
            this.Controls.Add(this._reportViewer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "DividendDistributionView";
            this.Text = "Dividend Distribution";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DividendDistributionView_Load);
            ((System.ComponentModel.ISupportInitialize)(this._dividendDistributionItemBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._yearNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource _dividendDistributionItemBindingSource;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox _totalDividendForDistributionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown _yearNumericUpDown;
        private Microsoft.Reporting.WinForms.ReportViewer _reportViewer;
        private System.Windows.Forms.Button _postButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button _generateButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _totalAverageShareTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _totalDividendTextBox;
        private System.Windows.Forms.Button _summaryButton;
    }
}