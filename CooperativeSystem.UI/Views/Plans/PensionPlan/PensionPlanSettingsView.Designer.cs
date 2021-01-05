namespace CooperativeSystem.UI.Views.Plans.PensionPlan
{
    partial class PensionPlanSettingsView
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
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            this._closeButton = new System.Windows.Forms.Button();
            this._updateButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._aginPeriodNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._termsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._paymentCompletionAmountTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._amortizationYearlyTextBox = new System.Windows.Forms.TextBox();
            this._amortizationMonthlyTextBox = new System.Windows.Forms.TextBox();
            this._amortizationSemiMonthlyTextBox = new System.Windows.Forms.TextBox();
            this._amortizationWeeklyTextBox = new System.Windows.Forms.TextBox();
            this._amortizationDailyTextBox = new System.Windows.Forms.TextBox();
            label13 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._aginPeriodNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._termsNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(152, 22);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(40, 13);
            label13.TabIndex = 41;
            label13.Text = "Terms:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(43, 77);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(149, 13);
            label1.TabIndex = 33;
            label1.Text = "Payment Completion Amount:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(121, 49);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(71, 13);
            label6.TabIndex = 31;
            label6.Text = "Aging Period:";
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(282, 271);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 32;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = true;
            // 
            // _updateButton
            // 
            this._updateButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._updateButton.Location = new System.Drawing.Point(201, 271);
            this._updateButton.Name = "_updateButton";
            this._updateButton.Size = new System.Drawing.Size(75, 23);
            this._updateButton.TabIndex = 31;
            this._updateButton.TabStop = false;
            this._updateButton.Text = "&Update";
            this._updateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._updateButton.UseVisualStyleBackColor = true;
            this._updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._aginPeriodNumericUpDown);
            this.groupBox2.Controls.Add(this._termsNumericUpDown);
            this.groupBox2.Controls.Add(label13);
            this.groupBox2.Controls.Add(this._paymentCompletionAmountTextBox);
            this.groupBox2.Controls.Add(label1);
            this.groupBox2.Controls.Add(label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 101);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // _aginPeriodNumericUpDown
            // 
            this._aginPeriodNumericUpDown.Location = new System.Drawing.Point(198, 47);
            this._aginPeriodNumericUpDown.Name = "_aginPeriodNumericUpDown";
            this._aginPeriodNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._aginPeriodNumericUpDown.Size = new System.Drawing.Size(100, 21);
            this._aginPeriodNumericUpDown.TabIndex = 1;
            // 
            // _termsNumericUpDown
            // 
            this._termsNumericUpDown.Location = new System.Drawing.Point(198, 20);
            this._termsNumericUpDown.Name = "_termsNumericUpDown";
            this._termsNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._termsNumericUpDown.Size = new System.Drawing.Size(100, 21);
            this._termsNumericUpDown.TabIndex = 0;
            // 
            // _paymentCompletionAmountTextBox
            // 
            this._paymentCompletionAmountTextBox.Location = new System.Drawing.Point(198, 74);
            this._paymentCompletionAmountTextBox.Name = "_paymentCompletionAmountTextBox";
            this._paymentCompletionAmountTextBox.Size = new System.Drawing.Size(100, 21);
            this._paymentCompletionAmountTextBox.TabIndex = 2;
            this._paymentCompletionAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 297);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(369, 22);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._amortizationYearlyTextBox);
            this.groupBox1.Controls.Add(label8);
            this.groupBox1.Controls.Add(this._amortizationMonthlyTextBox);
            this.groupBox1.Controls.Add(label7);
            this.groupBox1.Controls.Add(this._amortizationSemiMonthlyTextBox);
            this.groupBox1.Controls.Add(label5);
            this.groupBox1.Controls.Add(this._amortizationWeeklyTextBox);
            this.groupBox1.Controls.Add(label4);
            this.groupBox1.Controls.Add(this._amortizationDailyTextBox);
            this.groupBox1.Controls.Add(label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 155);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Amortization";
            // 
            // _amortizationYearlyTextBox
            // 
            this._amortizationYearlyTextBox.Location = new System.Drawing.Point(197, 128);
            this._amortizationYearlyTextBox.Name = "_amortizationYearlyTextBox";
            this._amortizationYearlyTextBox.Size = new System.Drawing.Size(100, 21);
            this._amortizationYearlyTextBox.TabIndex = 4;
            this._amortizationYearlyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(87, 131);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(104, 13);
            label8.TabIndex = 47;
            label8.Text = "Amortization Yearly:";
            // 
            // _amortizationMonthlyTextBox
            // 
            this._amortizationMonthlyTextBox.Location = new System.Drawing.Point(197, 101);
            this._amortizationMonthlyTextBox.Name = "_amortizationMonthlyTextBox";
            this._amortizationMonthlyTextBox.Size = new System.Drawing.Size(100, 21);
            this._amortizationMonthlyTextBox.TabIndex = 3;
            this._amortizationMonthlyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(79, 104);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(112, 13);
            label7.TabIndex = 45;
            label7.Text = "Amortization Monthly:";
            // 
            // _amortizationSemiMonthlyTextBox
            // 
            this._amortizationSemiMonthlyTextBox.Location = new System.Drawing.Point(197, 74);
            this._amortizationSemiMonthlyTextBox.Name = "_amortizationSemiMonthlyTextBox";
            this._amortizationSemiMonthlyTextBox.Size = new System.Drawing.Size(100, 21);
            this._amortizationSemiMonthlyTextBox.TabIndex = 2;
            this._amortizationSemiMonthlyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(53, 77);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(138, 13);
            label5.TabIndex = 43;
            label5.Text = "Amortization Semi-Monthly:";
            // 
            // _amortizationWeeklyTextBox
            // 
            this._amortizationWeeklyTextBox.Location = new System.Drawing.Point(197, 47);
            this._amortizationWeeklyTextBox.Name = "_amortizationWeeklyTextBox";
            this._amortizationWeeklyTextBox.Size = new System.Drawing.Size(100, 21);
            this._amortizationWeeklyTextBox.TabIndex = 1;
            this._amortizationWeeklyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(82, 50);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(109, 13);
            label4.TabIndex = 41;
            label4.Text = "Amortization Weekly:";
            // 
            // _amortizationDailyTextBox
            // 
            this._amortizationDailyTextBox.Location = new System.Drawing.Point(197, 20);
            this._amortizationDailyTextBox.Name = "_amortizationDailyTextBox";
            this._amortizationDailyTextBox.Size = new System.Drawing.Size(100, 21);
            this._amortizationDailyTextBox.TabIndex = 0;
            this._amortizationDailyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(94, 23);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(97, 13);
            label3.TabIndex = 39;
            label3.Text = "Amortization Daily:";
            // 
            // PensionPlanSettingsView
            // 
            this.AcceptButton = this._updateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(369, 319);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._updateButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Name = "PensionPlanSettingsView";
            this.Text = "Pension Plan Settings";
            this.Shown += new System.EventHandler(this.PensionPlanSettingsView_Shown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._aginPeriodNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._termsNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.Button _updateButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown _aginPeriodNumericUpDown;
        private System.Windows.Forms.NumericUpDown _termsNumericUpDown;
        private System.Windows.Forms.TextBox _paymentCompletionAmountTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _amortizationYearlyTextBox;
        private System.Windows.Forms.TextBox _amortizationMonthlyTextBox;
        private System.Windows.Forms.TextBox _amortizationSemiMonthlyTextBox;
        private System.Windows.Forms.TextBox _amortizationWeeklyTextBox;
        private System.Windows.Forms.TextBox _amortizationDailyTextBox;
    }
}