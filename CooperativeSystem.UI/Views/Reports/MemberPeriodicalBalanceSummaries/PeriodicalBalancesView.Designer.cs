namespace CooperativeSystem.UI.Views.Reports.MemberPeriodicalBalanceSummaries
{
    partial class PeriodicalBalancesView
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
            this._tabControl = new System.Windows.Forms.TabControl();
            this._monthlyBalancesTabPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._monthlyBalanceDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this._quarterlyBalancesTabPage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._quarterlyBalanceQuarterComboBox = new System.Windows.Forms.ComboBox();
            this._quarterlyBalanceYearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._yearlyBalancesTabPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._yearlyBalanceYearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._generateButton = new System.Windows.Forms.Button();
            this._closeButton = new System.Windows.Forms.Button();
            this._tabControl.SuspendLayout();
            this._monthlyBalancesTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this._quarterlyBalancesTabPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._quarterlyBalanceYearNumericUpDown)).BeginInit();
            this._yearlyBalancesTabPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._yearlyBalanceYearNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._monthlyBalancesTabPage);
            this._tabControl.Controls.Add(this._quarterlyBalancesTabPage);
            this._tabControl.Controls.Add(this._yearlyBalancesTabPage);
            this._tabControl.Location = new System.Drawing.Point(12, 12);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(304, 169);
            this._tabControl.TabIndex = 0;
            // 
            // _monthlyBalancesTabPage
            // 
            this._monthlyBalancesTabPage.Controls.Add(this.groupBox1);
            this._monthlyBalancesTabPage.Location = new System.Drawing.Point(4, 22);
            this._monthlyBalancesTabPage.Name = "_monthlyBalancesTabPage";
            this._monthlyBalancesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._monthlyBalancesTabPage.Size = new System.Drawing.Size(296, 143);
            this._monthlyBalancesTabPage.TabIndex = 0;
            this._monthlyBalancesTabPage.Text = "Monthly";
            this._monthlyBalancesTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._monthlyBalanceDateTimePicker);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // _monthlyBalanceDateTimePicker
            // 
            this._monthlyBalanceDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._monthlyBalanceDateTimePicker.Location = new System.Drawing.Point(106, 40);
            this._monthlyBalanceDateTimePicker.Name = "_monthlyBalanceDateTimePicker";
            this._monthlyBalanceDateTimePicker.Size = new System.Drawing.Size(107, 21);
            this._monthlyBalanceDateTimePicker.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Date:";
            // 
            // _quarterlyBalancesTabPage
            // 
            this._quarterlyBalancesTabPage.Controls.Add(this.groupBox3);
            this._quarterlyBalancesTabPage.Location = new System.Drawing.Point(4, 22);
            this._quarterlyBalancesTabPage.Name = "_quarterlyBalancesTabPage";
            this._quarterlyBalancesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._quarterlyBalancesTabPage.Size = new System.Drawing.Size(296, 143);
            this._quarterlyBalancesTabPage.TabIndex = 1;
            this._quarterlyBalancesTabPage.Text = "Quarterly";
            this._quarterlyBalancesTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._quarterlyBalanceQuarterComboBox);
            this.groupBox3.Controls.Add(this._quarterlyBalanceYearNumericUpDown);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(284, 131);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // _quarterlyBalanceQuarterComboBox
            // 
            this._quarterlyBalanceQuarterComboBox.FormattingEnabled = true;
            this._quarterlyBalanceQuarterComboBox.Location = new System.Drawing.Point(106, 67);
            this._quarterlyBalanceQuarterComboBox.Name = "_quarterlyBalanceQuarterComboBox";
            this._quarterlyBalanceQuarterComboBox.Size = new System.Drawing.Size(107, 21);
            this._quarterlyBalanceQuarterComboBox.TabIndex = 2;
            // 
            // _quarterlyBalanceYearNumericUpDown
            // 
            this._quarterlyBalanceYearNumericUpDown.Location = new System.Drawing.Point(106, 40);
            this._quarterlyBalanceYearNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this._quarterlyBalanceYearNumericUpDown.Minimum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this._quarterlyBalanceYearNumericUpDown.Name = "_quarterlyBalanceYearNumericUpDown";
            this._quarterlyBalanceYearNumericUpDown.Size = new System.Drawing.Size(107, 21);
            this._quarterlyBalanceYearNumericUpDown.TabIndex = 10;
            this._quarterlyBalanceYearNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._quarterlyBalanceYearNumericUpDown.Value = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Quarter:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Year:";
            // 
            // _yearlyBalancesTabPage
            // 
            this._yearlyBalancesTabPage.Controls.Add(this.groupBox2);
            this._yearlyBalancesTabPage.Location = new System.Drawing.Point(4, 22);
            this._yearlyBalancesTabPage.Name = "_yearlyBalancesTabPage";
            this._yearlyBalancesTabPage.Size = new System.Drawing.Size(296, 143);
            this._yearlyBalancesTabPage.TabIndex = 2;
            this._yearlyBalancesTabPage.Text = "Yearly";
            this._yearlyBalancesTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._yearlyBalanceYearNumericUpDown);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 131);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // _yearlyBalanceYearNumericUpDown
            // 
            this._yearlyBalanceYearNumericUpDown.Location = new System.Drawing.Point(106, 40);
            this._yearlyBalanceYearNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this._yearlyBalanceYearNumericUpDown.Minimum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this._yearlyBalanceYearNumericUpDown.Name = "_yearlyBalanceYearNumericUpDown";
            this._yearlyBalanceYearNumericUpDown.Size = new System.Drawing.Size(107, 21);
            this._yearlyBalanceYearNumericUpDown.TabIndex = 12;
            this._yearlyBalanceYearNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._yearlyBalanceYearNumericUpDown.Value = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Year:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 213);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(328, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _generateButton
            // 
            this._generateButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._generateButton.Location = new System.Drawing.Point(156, 187);
            this._generateButton.Name = "_generateButton";
            this._generateButton.Size = new System.Drawing.Size(79, 23);
            this._generateButton.TabIndex = 10;
            this._generateButton.TabStop = false;
            this._generateButton.Text = "&Generate";
            this._generateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._generateButton.UseVisualStyleBackColor = true;
            this._generateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(241, 187);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 11;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // PeriodicalBalancesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 235);
            this.Controls.Add(this._generateButton);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._tabControl);
            this.Name = "PeriodicalBalancesView";
            this.Text = "PeriodicalBalances";
            this.Load += new System.EventHandler(this.PeriodicalBalancesView_Load);
            this._tabControl.ResumeLayout(false);
            this._monthlyBalancesTabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this._quarterlyBalancesTabPage.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._quarterlyBalanceYearNumericUpDown)).EndInit();
            this._yearlyBalancesTabPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._yearlyBalanceYearNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _monthlyBalancesTabPage;
        private System.Windows.Forms.TabPage _quarterlyBalancesTabPage;
        private System.Windows.Forms.TabPage _yearlyBalancesTabPage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker _monthlyBalanceDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox _quarterlyBalanceQuarterComboBox;
        private System.Windows.Forms.NumericUpDown _quarterlyBalanceYearNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown _yearlyBalanceYearNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _generateButton;
        protected System.Windows.Forms.Button _closeButton;
    }
}