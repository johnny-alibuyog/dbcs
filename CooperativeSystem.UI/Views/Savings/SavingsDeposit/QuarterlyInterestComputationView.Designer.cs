namespace CooperativeSystem.UI.Views.Savings.SavingsDeposit
{
    partial class QuarterlyInterestComputationView
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
            this._quarterlyInterestComputationItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this._quarterComboBox = new System.Windows.Forms.ComboBox();
            this._yearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this._computeButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._saveButton = new System.Windows.Forms.Button();
            this._closeButton = new System.Windows.Forms.Button();
            this._postButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._quarterlyInterestComputationItemBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._yearNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // _quarterlyInterestComputationItemBindingSource
            // 
            this._quarterlyInterestComputationItemBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Savings.SavingsDeposit.QuarterlyInterestComputationItem);
            // 
            // _reportViewer
            // 
            this._reportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource2.Name = "QuarterlyInterestComputationDataSet";
            reportDataSource2.Value = this._quarterlyInterestComputationItemBindingSource;
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "CooperativeSystem.UI.Views.Savings.SavingsDeposit.QuarterlyInterestComputationRep" +
                "ort.rdlc";
            this._reportViewer.Location = new System.Drawing.Point(11, 93);
            this._reportViewer.Name = "_reportViewer";
            this._reportViewer.Size = new System.Drawing.Size(547, 263);
            this._reportViewer.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._quarterComboBox);
            this.groupBox1.Controls.Add(this._yearNumericUpDown);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._computeButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 75);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Quarter:";
            // 
            // _quarterComboBox
            // 
            this._quarterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._quarterComboBox.FormattingEnabled = true;
            this._quarterComboBox.Location = new System.Drawing.Point(84, 48);
            this._quarterComboBox.Name = "_quarterComboBox";
            this._quarterComboBox.Size = new System.Drawing.Size(153, 21);
            this._quarterComboBox.TabIndex = 5;
            // 
            // _yearNumericUpDown
            // 
            this._yearNumericUpDown.Location = new System.Drawing.Point(84, 20);
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
            this.label1.Location = new System.Drawing.Point(45, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Year:";
            // 
            // _computeButton
            // 
            this._computeButton.Location = new System.Drawing.Point(243, 46);
            this._computeButton.Name = "_computeButton";
            this._computeButton.Size = new System.Drawing.Size(75, 23);
            this._computeButton.TabIndex = 0;
            this._computeButton.TabStop = false;
            this._computeButton.Text = "&Compute";
            this._computeButton.UseVisualStyleBackColor = true;
            this._computeButton.Click += new System.EventHandler(this.ComputeButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 388);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(570, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _saveButton
            // 
            this._saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._saveButton.Enabled = false;
            this._saveButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._saveButton.Location = new System.Drawing.Point(402, 362);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(75, 23);
            this._saveButton.TabIndex = 6;
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
            this._closeButton.Location = new System.Drawing.Point(483, 362);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 5;
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
            this._postButton.Location = new System.Drawing.Point(321, 362);
            this._postButton.Name = "_postButton";
            this._postButton.Size = new System.Drawing.Size(75, 23);
            this._postButton.TabIndex = 9;
            this._postButton.TabStop = false;
            this._postButton.Text = "&Post";
            this._postButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._postButton.UseVisualStyleBackColor = true;
            this._postButton.Click += new System.EventHandler(this.PostButton_Click);
            // 
            // QuarterlyInterestComputationView
            // 
            this.AcceptButton = this._computeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(570, 410);
            this.Controls.Add(this._postButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._reportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "QuarterlyInterestComputationView";
            this.Text = "Quarterly Interest Computation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QuarterlyInterestComputationView_Load);
            ((System.ComponentModel.ISupportInitialize)(this._quarterlyInterestComputationItemBindingSource)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _computeButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _quarterComboBox;
        private System.Windows.Forms.BindingSource _quarterlyInterestComputationItemBindingSource;
        private System.Windows.Forms.Button _postButton;
    }
}