namespace CooperativeSystem.UI.Views
{
    partial class AdjustmentView
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
            this._timeDepositTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._capitalShareTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._savingsDepositTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._collegeInsurancePlanTextBox = new System.Windows.Forms.TextBox();
            this._adjustmentDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._pensionPlanTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._collegeInsurancePlanAdjustButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this._regularLoanTextBox = new System.Windows.Forms.TextBox();
            this._generateVoucherButton = new System.Windows.Forms.Button();
            this._pensionLoanTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this._restartVoucherCheckBox = new System.Windows.Forms.CheckBox();
            this._equityLoanTextBox = new System.Windows.Forms.TextBox();
            this._clearButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this._emergencyLoanTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._voucherNumberTextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._deathAidFundTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this._tulunganFundTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._easyLoanTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._applianceLoanTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this._sequenceTextBox = new System.Windows.Forms.TextBox();
            this._closeButton = new System.Windows.Forms.Button();
            this._acceptButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._timeDepositTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._capitalShareTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._savingsDepositTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Savings";
            // 
            // _timeDepositTextBox
            // 
            this._timeDepositTextBox.Location = new System.Drawing.Point(164, 78);
            this._timeDepositTextBox.Name = "_timeDepositTextBox";
            this._timeDepositTextBox.Size = new System.Drawing.Size(100, 21);
            this._timeDepositTextBox.TabIndex = 3;
            this._timeDepositTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._timeDepositTextBox.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Time Deposit:";
            // 
            // _capitalShareTextBox
            // 
            this._capitalShareTextBox.Location = new System.Drawing.Point(164, 24);
            this._capitalShareTextBox.Name = "_capitalShareTextBox";
            this._capitalShareTextBox.Size = new System.Drawing.Size(100, 21);
            this._capitalShareTextBox.TabIndex = 0;
            this._capitalShareTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._capitalShareTextBox.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Capital Share:";
            // 
            // _savingsDepositTextBox
            // 
            this._savingsDepositTextBox.BackColor = System.Drawing.SystemColors.Window;
            this._savingsDepositTextBox.Location = new System.Drawing.Point(164, 51);
            this._savingsDepositTextBox.Name = "_savingsDepositTextBox";
            this._savingsDepositTextBox.Size = new System.Drawing.Size(100, 21);
            this._savingsDepositTextBox.TabIndex = 2;
            this._savingsDepositTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._savingsDepositTextBox.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Savings Deposit:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(548, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Adjustment Date:";
            // 
            // _collegeInsurancePlanTextBox
            // 
            this._collegeInsurancePlanTextBox.Location = new System.Drawing.Point(164, 24);
            this._collegeInsurancePlanTextBox.Name = "_collegeInsurancePlanTextBox";
            this._collegeInsurancePlanTextBox.ReadOnly = true;
            this._collegeInsurancePlanTextBox.Size = new System.Drawing.Size(100, 21);
            this._collegeInsurancePlanTextBox.TabIndex = 0;
            this._collegeInsurancePlanTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._collegeInsurancePlanTextBox.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // _adjustmentDateTimePicker
            // 
            this._adjustmentDateTimePicker.CustomFormat = " MMMM dd, yyyy";
            this._adjustmentDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._adjustmentDateTimePicker.Location = new System.Drawing.Point(646, 12);
            this._adjustmentDateTimePicker.Name = "_adjustmentDateTimePicker";
            this._adjustmentDateTimePicker.Size = new System.Drawing.Size(156, 21);
            this._adjustmentDateTimePicker.TabIndex = 39;
            // 
            // _pensionPlanTextBox
            // 
            this._pensionPlanTextBox.Location = new System.Drawing.Point(164, 51);
            this._pensionPlanTextBox.Name = "_pensionPlanTextBox";
            this._pensionPlanTextBox.Size = new System.Drawing.Size(100, 21);
            this._pensionPlanTextBox.TabIndex = 1;
            this._pensionPlanTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._pensionPlanTextBox.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "College Insurance Plan:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._collegeInsurancePlanAdjustButton);
            this.groupBox2.Controls.Add(this._collegeInsurancePlanTextBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this._pensionPlanTextBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(410, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 116);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Plans";
            // 
            // _collegeInsurancePlanAdjustButton
            // 
            this._collegeInsurancePlanAdjustButton.Location = new System.Drawing.Point(270, 22);
            this._collegeInsurancePlanAdjustButton.Name = "_collegeInsurancePlanAdjustButton";
            this._collegeInsurancePlanAdjustButton.Size = new System.Drawing.Size(75, 23);
            this._collegeInsurancePlanAdjustButton.TabIndex = 6;
            this._collegeInsurancePlanAdjustButton.TabStop = false;
            this._collegeInsurancePlanAdjustButton.Text = "Ad&just";
            this._collegeInsurancePlanAdjustButton.UseVisualStyleBackColor = true;
            this._collegeInsurancePlanAdjustButton.Click += new System.EventHandler(this.CollegeInsurancePlanChangeButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(87, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Pension Plan:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(88, 162);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 13);
            this.label18.TabIndex = 18;
            this.label18.Text = "Regular Loan:";
            // 
            // _regularLoanTextBox
            // 
            this._regularLoanTextBox.Location = new System.Drawing.Point(164, 159);
            this._regularLoanTextBox.Name = "_regularLoanTextBox";
            this._regularLoanTextBox.Size = new System.Drawing.Size(100, 21);
            this._regularLoanTextBox.TabIndex = 5;
            this._regularLoanTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._regularLoanTextBox.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // _generateVoucherButton
            // 
            this._generateVoucherButton.Enabled = false;
            this._generateVoucherButton.Location = new System.Drawing.Point(421, 11);
            this._generateVoucherButton.Name = "_generateVoucherButton";
            this._generateVoucherButton.Size = new System.Drawing.Size(75, 23);
            this._generateVoucherButton.TabIndex = 49;
            this._generateVoucherButton.TabStop = false;
            this._generateVoucherButton.Text = "Generate";
            this._generateVoucherButton.UseVisualStyleBackColor = true;
            this._generateVoucherButton.Click += new System.EventHandler(this.GenerateVoucherButton_Click);
            // 
            // _pensionLoanTextBox
            // 
            this._pensionLoanTextBox.Location = new System.Drawing.Point(164, 132);
            this._pensionLoanTextBox.Name = "_pensionLoanTextBox";
            this._pensionLoanTextBox.Size = new System.Drawing.Size(100, 21);
            this._pensionLoanTextBox.TabIndex = 4;
            this._pensionLoanTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._pensionLoanTextBox.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(88, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Pension Loan:";
            // 
            // _restartVoucherCheckBox
            // 
            this._restartVoucherCheckBox.AutoSize = true;
            this._restartVoucherCheckBox.Location = new System.Drawing.Point(247, 15);
            this._restartVoucherCheckBox.Name = "_restartVoucherCheckBox";
            this._restartVoucherCheckBox.Size = new System.Drawing.Size(62, 17);
            this._restartVoucherCheckBox.TabIndex = 48;
            this._restartVoucherCheckBox.Text = "Restart";
            this._restartVoucherCheckBox.UseVisualStyleBackColor = true;
            this._restartVoucherCheckBox.CheckedChanged += new System.EventHandler(this.RestartVoucherCheckBox_CheckedChanged);
            // 
            // _equityLoanTextBox
            // 
            this._equityLoanTextBox.Location = new System.Drawing.Point(164, 105);
            this._equityLoanTextBox.Name = "_equityLoanTextBox";
            this._equityLoanTextBox.Size = new System.Drawing.Size(100, 21);
            this._equityLoanTextBox.TabIndex = 3;
            this._equityLoanTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._equityLoanTextBox.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // _clearButton
            // 
            this._clearButton.Location = new System.Drawing.Point(646, 364);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(75, 23);
            this._clearButton.TabIndex = 46;
            this._clearButton.TabStop = false;
            this._clearButton.Text = "Cle&ar";
            this._clearButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._clearButton.UseVisualStyleBackColor = true;
            this._clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(94, 108);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Equity Loan:";
            // 
            // _emergencyLoanTextBox
            // 
            this._emergencyLoanTextBox.Location = new System.Drawing.Point(164, 78);
            this._emergencyLoanTextBox.Name = "_emergencyLoanTextBox";
            this._emergencyLoanTextBox.Size = new System.Drawing.Size(100, 21);
            this._emergencyLoanTextBox.TabIndex = 2;
            this._emergencyLoanTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._emergencyLoanTextBox.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(71, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Emergency Loan:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Voucher Number:";
            // 
            // _voucherNumberTextBox
            // 
            this._voucherNumberTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._voucherNumberTextBox.Location = new System.Drawing.Point(141, 12);
            this._voucherNumberTextBox.Name = "_voucherNumberTextBox";
            this._voucherNumberTextBox.ReadOnly = true;
            this._voucherNumberTextBox.Size = new System.Drawing.Size(100, 22);
            this._voucherNumberTextBox.TabIndex = 42;
            this._voucherNumberTextBox.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._deathAidFundTextBox);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this._tulunganFundTextBox);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(410, 162);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(392, 196);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Special Funds:";
            // 
            // _deathAidFundTextBox
            // 
            this._deathAidFundTextBox.Location = new System.Drawing.Point(164, 51);
            this._deathAidFundTextBox.Name = "_deathAidFundTextBox";
            this._deathAidFundTextBox.Size = new System.Drawing.Size(100, 21);
            this._deathAidFundTextBox.TabIndex = 1;
            this._deathAidFundTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._deathAidFundTextBox.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(73, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Death Aid Fund:";
            // 
            // _tulunganFundTextBox
            // 
            this._tulunganFundTextBox.Location = new System.Drawing.Point(164, 25);
            this._tulunganFundTextBox.Name = "_tulunganFundTextBox";
            this._tulunganFundTextBox.Size = new System.Drawing.Size(100, 21);
            this._tulunganFundTextBox.TabIndex = 0;
            this._tulunganFundTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._tulunganFundTextBox.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(76, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Tulungan Fund:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(102, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Easy Loan:";
            // 
            // _easyLoanTextBox
            // 
            this._easyLoanTextBox.Location = new System.Drawing.Point(164, 51);
            this._easyLoanTextBox.Name = "_easyLoanTextBox";
            this._easyLoanTextBox.Size = new System.Drawing.Size(100, 21);
            this._easyLoanTextBox.TabIndex = 1;
            this._easyLoanTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._easyLoanTextBox.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 390);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(814, 22);
            this.statusStrip1.TabIndex = 43;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._regularLoanTextBox);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this._pensionLoanTextBox);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this._equityLoanTextBox);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this._emergencyLoanTextBox);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this._easyLoanTextBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this._applianceLoanTextBox);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(12, 162);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(392, 196);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Loans";
            // 
            // _applianceLoanTextBox
            // 
            this._applianceLoanTextBox.Location = new System.Drawing.Point(164, 25);
            this._applianceLoanTextBox.Name = "_applianceLoanTextBox";
            this._applianceLoanTextBox.Size = new System.Drawing.Size(100, 21);
            this._applianceLoanTextBox.TabIndex = 0;
            this._applianceLoanTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._applianceLoanTextBox.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(78, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Appliance Loan:";
            // 
            // _sequenceTextBox
            // 
            this._sequenceTextBox.Enabled = false;
            this._sequenceTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._sequenceTextBox.Location = new System.Drawing.Point(315, 12);
            this._sequenceTextBox.Name = "_sequenceTextBox";
            this._sequenceTextBox.Size = new System.Drawing.Size(100, 22);
            this._sequenceTextBox.TabIndex = 47;
            this._sequenceTextBox.TabStop = false;
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(727, 364);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 44;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = true;
            // 
            // _acceptButton
            // 
            this._acceptButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._acceptButton.Location = new System.Drawing.Point(565, 364);
            this._acceptButton.Name = "_acceptButton";
            this._acceptButton.Size = new System.Drawing.Size(75, 23);
            this._acceptButton.TabIndex = 45;
            this._acceptButton.TabStop = false;
            this._acceptButton.Text = "&Accept";
            this._acceptButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // AdjustmentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(814, 412);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._adjustmentDateTimePicker);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this._acceptButton);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._generateVoucherButton);
            this.Controls.Add(this._restartVoucherCheckBox);
            this.Controls.Add(this._clearButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._voucherNumberTextBox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this._sequenceTextBox);
            this.Name = "AdjustmentView";
            this.Text = "Adjustment";
            this.Load += new System.EventHandler(this.AdjustmentView_Load);
            this.Shown += new System.EventHandler(this.AdjustmentView_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _timeDepositTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _capitalShareTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _savingsDepositTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _collegeInsurancePlanTextBox;
        private System.Windows.Forms.DateTimePicker _adjustmentDateTimePicker;
        private System.Windows.Forms.TextBox _pensionPlanTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button _acceptButton;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox _regularLoanTextBox;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.Button _generateVoucherButton;
        private System.Windows.Forms.TextBox _pensionLoanTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox _restartVoucherCheckBox;
        private System.Windows.Forms.TextBox _equityLoanTextBox;
        private System.Windows.Forms.Button _clearButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox _emergencyLoanTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _voucherNumberTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox _deathAidFundTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _tulunganFundTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox _easyLoanTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox _applianceLoanTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox _sequenceTextBox;
        private System.Windows.Forms.Button _collegeInsurancePlanAdjustButton;
    }
}