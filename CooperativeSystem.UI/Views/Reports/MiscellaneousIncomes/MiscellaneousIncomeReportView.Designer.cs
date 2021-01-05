namespace CooperativeSystem.UI.Views.Reports.MiscellaneousIncomes
{
    partial class MiscellaneousIncomeReportView
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
            this._reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._toDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this._fromDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this._generateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._typeComboBox = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._miscellaneousIncomeItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._miscellaneousIncomeItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _reportViewer
            // 
            this._reportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource2.Name = "ItemDataSet";
            reportDataSource2.Value = this._miscellaneousIncomeItemBindingSource;
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "CooperativeSystem.UI.Views.Reports.MiscellaneousIncomes.MiscellaneousIncomeReport" +
    ".rdlc";
            this._reportViewer.Location = new System.Drawing.Point(12, 92);
            this._reportViewer.Name = "_reportViewer";
            this._reportViewer.Size = new System.Drawing.Size(857, 370);
            this._reportViewer.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._toDateDateTimePicker);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._fromDateDateTimePicker);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._generateButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._typeComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(857, 74);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // _toDateDateTimePicker
            // 
            this._toDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._toDateDateTimePicker.Location = new System.Drawing.Point(144, 47);
            this._toDateDateTimePicker.Name = "_toDateDateTimePicker";
            this._toDateDateTimePicker.Size = new System.Drawing.Size(200, 21);
            this._toDateDateTimePicker.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "To Date:";
            // 
            // _fromDateDateTimePicker
            // 
            this._fromDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._fromDateDateTimePicker.Location = new System.Drawing.Point(144, 20);
            this._fromDateDateTimePicker.Name = "_fromDateDateTimePicker";
            this._fromDateDateTimePicker.Size = new System.Drawing.Size(200, 21);
            this._fromDateDateTimePicker.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "From Date:";
            // 
            // _generateButton
            // 
            this._generateButton.Location = new System.Drawing.Point(690, 20);
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
            this.label1.Location = new System.Drawing.Point(443, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type:";
            // 
            // _typeComboBox
            // 
            this._typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._typeComboBox.FormattingEnabled = true;
            this._typeComboBox.Items.AddRange(new object[] {
            "First Notice",
            "Second Notice",
            "Final Notice"});
            this._typeComboBox.Location = new System.Drawing.Point(484, 20);
            this._typeComboBox.Name = "_typeComboBox";
            this._typeComboBox.Size = new System.Drawing.Size(200, 21);
            this._typeComboBox.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 465);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(881, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _miscellaneousIncomeItemBindingSource
            // 
            this._miscellaneousIncomeItemBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Reports.MiscellaneousIncomes.MiscellaneousIncomeItem);
            // 
            // MiscellaneousIncomeReportView
            // 
            this.AcceptButton = this._generateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 487);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._reportViewer);
            this.Controls.Add(this.groupBox1);
            this.Name = "MiscellaneousIncomeReportView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Miscellaneous Income Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._miscellaneousIncomeItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer _reportViewer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker _toDateDateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker _fromDateDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _generateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _typeComboBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.BindingSource _miscellaneousIncomeItemBindingSource;
    }
}