namespace CooperativeSystem.UI.Views
{
    partial class CashDisbursementView
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
            this._timeDepositAssessButton = new System.Windows.Forms.Button();
            this._timeDepositTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._capitalShareAssessButton = new System.Windows.Forms.Button();
            this._capitalShareTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._savingsDepositAssessButton = new System.Windows.Forms.Button();
            this._savingsDepositTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._disbursementDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._collegeInsurancePlanAssessButton = new System.Windows.Forms.Button();
            this._collegeInsurancePlanTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._pensionPlanAssessButton = new System.Windows.Forms.Button();
            this._pensionPlanTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._regularLoanAssessButton = new System.Windows.Forms.Button();
            this._regularLoanTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this._pensionLoanAssessButton = new System.Windows.Forms.Button();
            this._pensionLoanTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this._equityLoanAssessButton = new System.Windows.Forms.Button();
            this._equityLoanTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this._emergencyLoanAssessButton = new System.Windows.Forms.Button();
            this._emergencyLoanTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._easyLoanAssessButton = new System.Windows.Forms.Button();
            this._easyLoanTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this._applienceLoanAssessButton = new System.Windows.Forms.Button();
            this._applianceLoanTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._deathAidFundAssessButton = new System.Windows.Forms.Button();
            this._deathAidFundTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this._tulunganFundAssessButton = new System.Windows.Forms.Button();
            this._tulunganFundTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this._voucherNumberTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._closeButton = new System.Windows.Forms.Button();
            this._acceptButton = new System.Windows.Forms.Button();
            this._clearButton = new System.Windows.Forms.Button();
            this._sequenceTextBox = new System.Windows.Forms.TextBox();
            this._restartVoucherCheckBox = new System.Windows.Forms.CheckBox();
            this._generateVoucherButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._timeDepositAssessButton);
            this.groupBox1.Controls.Add(this._timeDepositTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._capitalShareAssessButton);
            this.groupBox1.Controls.Add(this._capitalShareTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._savingsDepositAssessButton);
            this.groupBox1.Controls.Add(this._savingsDepositTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Savings";
            // 
            // _timeDepositAssessButton
            // 
            this._timeDepositAssessButton.Location = new System.Drawing.Point(270, 76);
            this._timeDepositAssessButton.Name = "_timeDepositAssessButton";
            this._timeDepositAssessButton.Size = new System.Drawing.Size(75, 23);
            this._timeDepositAssessButton.TabIndex = 8;
            this._timeDepositAssessButton.TabStop = false;
            this._timeDepositAssessButton.Text = "Assess";
            this._timeDepositAssessButton.UseVisualStyleBackColor = true;
            this._timeDepositAssessButton.Click += new System.EventHandler(this.SavingsAddButton_Click);
            // 
            // _timeDepositTextBox
            // 
            this._timeDepositTextBox.Location = new System.Drawing.Point(164, 78);
            this._timeDepositTextBox.Name = "_timeDepositTextBox";
            this._timeDepositTextBox.ReadOnly = true;
            this._timeDepositTextBox.Size = new System.Drawing.Size(100, 21);
            this._timeDepositTextBox.TabIndex = 2;
            this._timeDepositTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._timeDepositTextBox.Enter += new System.EventHandler(this.InputTextBox_Enter);
            this._timeDepositTextBox.Leave += new System.EventHandler(this.InputTextBox_Leave);
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
            // _capitalShareAssessButton
            // 
            this._capitalShareAssessButton.Location = new System.Drawing.Point(270, 22);
            this._capitalShareAssessButton.Name = "_capitalShareAssessButton";
            this._capitalShareAssessButton.Size = new System.Drawing.Size(75, 23);
            this._capitalShareAssessButton.TabIndex = 5;
            this._capitalShareAssessButton.TabStop = false;
            this._capitalShareAssessButton.Text = "Assess";
            this._capitalShareAssessButton.UseVisualStyleBackColor = true;
            this._capitalShareAssessButton.Click += new System.EventHandler(this.SavingsAddButton_Click);
            // 
            // _capitalShareTextBox
            // 
            this._capitalShareTextBox.Location = new System.Drawing.Point(164, 24);
            this._capitalShareTextBox.Name = "_capitalShareTextBox";
            this._capitalShareTextBox.ReadOnly = true;
            this._capitalShareTextBox.Size = new System.Drawing.Size(100, 21);
            this._capitalShareTextBox.TabIndex = 1;
            this._capitalShareTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._capitalShareTextBox.Enter += new System.EventHandler(this.InputTextBox_Enter);
            this._capitalShareTextBox.Leave += new System.EventHandler(this.InputTextBox_Leave);
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
            // _savingsDepositAssessButton
            // 
            this._savingsDepositAssessButton.Location = new System.Drawing.Point(270, 49);
            this._savingsDepositAssessButton.Name = "_savingsDepositAssessButton";
            this._savingsDepositAssessButton.Size = new System.Drawing.Size(75, 23);
            this._savingsDepositAssessButton.TabIndex = 2;
            this._savingsDepositAssessButton.TabStop = false;
            this._savingsDepositAssessButton.Text = "Assess";
            this._savingsDepositAssessButton.UseVisualStyleBackColor = true;
            this._savingsDepositAssessButton.Click += new System.EventHandler(this.SavingsAddButton_Click);
            // 
            // _savingsDepositTextBox
            // 
            this._savingsDepositTextBox.Location = new System.Drawing.Point(164, 51);
            this._savingsDepositTextBox.Name = "_savingsDepositTextBox";
            this._savingsDepositTextBox.ReadOnly = true;
            this._savingsDepositTextBox.Size = new System.Drawing.Size(100, 21);
            this._savingsDepositTextBox.TabIndex = 0;
            this._savingsDepositTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._savingsDepositTextBox.Enter += new System.EventHandler(this.InputTextBox_Enter);
            this._savingsDepositTextBox.Leave += new System.EventHandler(this.InputTextBox_Leave);
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
            // _disbursementDateDateTimePicker
            // 
            this._disbursementDateDateTimePicker.CustomFormat = " MMMM dd, yyyy";
            this._disbursementDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._disbursementDateDateTimePicker.Location = new System.Drawing.Point(646, 12);
            this._disbursementDateDateTimePicker.Name = "_disbursementDateDateTimePicker";
            this._disbursementDateDateTimePicker.Size = new System.Drawing.Size(156, 21);
            this._disbursementDateDateTimePicker.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(538, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Disbursement Date:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._collegeInsurancePlanAssessButton);
            this.groupBox2.Controls.Add(this._collegeInsurancePlanTextBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this._pensionPlanAssessButton);
            this.groupBox2.Controls.Add(this._pensionPlanTextBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(410, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 116);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Plans";
            // 
            // _collegeInsurancePlanAssessButton
            // 
            this._collegeInsurancePlanAssessButton.Location = new System.Drawing.Point(270, 22);
            this._collegeInsurancePlanAssessButton.Name = "_collegeInsurancePlanAssessButton";
            this._collegeInsurancePlanAssessButton.Size = new System.Drawing.Size(75, 23);
            this._collegeInsurancePlanAssessButton.TabIndex = 5;
            this._collegeInsurancePlanAssessButton.TabStop = false;
            this._collegeInsurancePlanAssessButton.Text = "Assess";
            this._collegeInsurancePlanAssessButton.UseVisualStyleBackColor = true;
            this._collegeInsurancePlanAssessButton.Click += new System.EventHandler(this.PlansAddButton_Click);
            // 
            // _collegeInsurancePlanTextBox
            // 
            this._collegeInsurancePlanTextBox.Location = new System.Drawing.Point(164, 24);
            this._collegeInsurancePlanTextBox.Name = "_collegeInsurancePlanTextBox";
            this._collegeInsurancePlanTextBox.ReadOnly = true;
            this._collegeInsurancePlanTextBox.Size = new System.Drawing.Size(100, 21);
            this._collegeInsurancePlanTextBox.TabIndex = 0;
            this._collegeInsurancePlanTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._collegeInsurancePlanTextBox.Enter += new System.EventHandler(this.InputTextBox_Enter);
            this._collegeInsurancePlanTextBox.Leave += new System.EventHandler(this.InputTextBox_Leave);
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
            // _pensionPlanAssessButton
            // 
            this._pensionPlanAssessButton.Location = new System.Drawing.Point(270, 49);
            this._pensionPlanAssessButton.Name = "_pensionPlanAssessButton";
            this._pensionPlanAssessButton.Size = new System.Drawing.Size(75, 23);
            this._pensionPlanAssessButton.TabIndex = 2;
            this._pensionPlanAssessButton.TabStop = false;
            this._pensionPlanAssessButton.Text = "Assess";
            this._pensionPlanAssessButton.UseVisualStyleBackColor = true;
            this._pensionPlanAssessButton.Click += new System.EventHandler(this.PlansAddButton_Click);
            // 
            // _pensionPlanTextBox
            // 
            this._pensionPlanTextBox.Location = new System.Drawing.Point(164, 51);
            this._pensionPlanTextBox.Name = "_pensionPlanTextBox";
            this._pensionPlanTextBox.ReadOnly = true;
            this._pensionPlanTextBox.Size = new System.Drawing.Size(100, 21);
            this._pensionPlanTextBox.TabIndex = 1;
            this._pensionPlanTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._pensionPlanTextBox.Enter += new System.EventHandler(this.InputTextBox_Enter);
            this._pensionPlanTextBox.Leave += new System.EventHandler(this.InputTextBox_Leave);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._regularLoanAssessButton);
            this.groupBox3.Controls.Add(this._regularLoanTextBox);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this._pensionLoanAssessButton);
            this.groupBox3.Controls.Add(this._pensionLoanTextBox);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this._equityLoanAssessButton);
            this.groupBox3.Controls.Add(this._equityLoanTextBox);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this._emergencyLoanAssessButton);
            this.groupBox3.Controls.Add(this._emergencyLoanTextBox);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this._easyLoanAssessButton);
            this.groupBox3.Controls.Add(this._easyLoanTextBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this._applienceLoanAssessButton);
            this.groupBox3.Controls.Add(this._applianceLoanTextBox);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(12, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(392, 196);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Loans";
            // 
            // _regularLoanAssessButton
            // 
            this._regularLoanAssessButton.Location = new System.Drawing.Point(270, 157);
            this._regularLoanAssessButton.Name = "_regularLoanAssessButton";
            this._regularLoanAssessButton.Size = new System.Drawing.Size(75, 23);
            this._regularLoanAssessButton.TabIndex = 17;
            this._regularLoanAssessButton.TabStop = false;
            this._regularLoanAssessButton.Text = "Assess";
            this._regularLoanAssessButton.UseVisualStyleBackColor = true;
            this._regularLoanAssessButton.Click += new System.EventHandler(this.LoanAddButton_Click);
            // 
            // _regularLoanTextBox
            // 
            this._regularLoanTextBox.Location = new System.Drawing.Point(164, 159);
            this._regularLoanTextBox.Name = "_regularLoanTextBox";
            this._regularLoanTextBox.ReadOnly = true;
            this._regularLoanTextBox.Size = new System.Drawing.Size(100, 21);
            this._regularLoanTextBox.TabIndex = 5;
            this._regularLoanTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._regularLoanTextBox.Enter += new System.EventHandler(this.InputTextBox_Enter);
            this._regularLoanTextBox.Leave += new System.EventHandler(this.InputTextBox_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(88, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Regular Loan:";
            // 
            // _pensionLoanAssessButton
            // 
            this._pensionLoanAssessButton.Location = new System.Drawing.Point(270, 130);
            this._pensionLoanAssessButton.Name = "_pensionLoanAssessButton";
            this._pensionLoanAssessButton.Size = new System.Drawing.Size(75, 23);
            this._pensionLoanAssessButton.TabIndex = 14;
            this._pensionLoanAssessButton.TabStop = false;
            this._pensionLoanAssessButton.Text = "Assess";
            this._pensionLoanAssessButton.UseVisualStyleBackColor = true;
            this._pensionLoanAssessButton.Click += new System.EventHandler(this.LoanAddButton_Click);
            // 
            // _pensionLoanTextBox
            // 
            this._pensionLoanTextBox.Location = new System.Drawing.Point(164, 132);
            this._pensionLoanTextBox.Name = "_pensionLoanTextBox";
            this._pensionLoanTextBox.ReadOnly = true;
            this._pensionLoanTextBox.Size = new System.Drawing.Size(100, 21);
            this._pensionLoanTextBox.TabIndex = 4;
            this._pensionLoanTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._pensionLoanTextBox.Enter += new System.EventHandler(this.InputTextBox_Enter);
            this._pensionLoanTextBox.Leave += new System.EventHandler(this.InputTextBox_Leave);
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
            // _equityLoanAssessButton
            // 
            this._equityLoanAssessButton.Location = new System.Drawing.Point(270, 103);
            this._equityLoanAssessButton.Name = "_equityLoanAssessButton";
            this._equityLoanAssessButton.Size = new System.Drawing.Size(75, 23);
            this._equityLoanAssessButton.TabIndex = 11;
            this._equityLoanAssessButton.TabStop = false;
            this._equityLoanAssessButton.Text = "Assess";
            this._equityLoanAssessButton.UseVisualStyleBackColor = true;
            this._equityLoanAssessButton.Click += new System.EventHandler(this.LoanAddButton_Click);
            // 
            // _equityLoanTextBox
            // 
            this._equityLoanTextBox.Location = new System.Drawing.Point(164, 105);
            this._equityLoanTextBox.Name = "_equityLoanTextBox";
            this._equityLoanTextBox.ReadOnly = true;
            this._equityLoanTextBox.Size = new System.Drawing.Size(100, 21);
            this._equityLoanTextBox.TabIndex = 3;
            this._equityLoanTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._equityLoanTextBox.Enter += new System.EventHandler(this.InputTextBox_Enter);
            this._equityLoanTextBox.Leave += new System.EventHandler(this.InputTextBox_Leave);
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
            // _emergencyLoanAssessButton
            // 
            this._emergencyLoanAssessButton.Location = new System.Drawing.Point(270, 76);
            this._emergencyLoanAssessButton.Name = "_emergencyLoanAssessButton";
            this._emergencyLoanAssessButton.Size = new System.Drawing.Size(75, 23);
            this._emergencyLoanAssessButton.TabIndex = 8;
            this._emergencyLoanAssessButton.TabStop = false;
            this._emergencyLoanAssessButton.Text = "Assess";
            this._emergencyLoanAssessButton.UseVisualStyleBackColor = true;
            this._emergencyLoanAssessButton.Click += new System.EventHandler(this.LoanAddButton_Click);
            // 
            // _emergencyLoanTextBox
            // 
            this._emergencyLoanTextBox.Location = new System.Drawing.Point(164, 78);
            this._emergencyLoanTextBox.Name = "_emergencyLoanTextBox";
            this._emergencyLoanTextBox.ReadOnly = true;
            this._emergencyLoanTextBox.Size = new System.Drawing.Size(100, 21);
            this._emergencyLoanTextBox.TabIndex = 2;
            this._emergencyLoanTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._emergencyLoanTextBox.Enter += new System.EventHandler(this.InputTextBox_Enter);
            this._emergencyLoanTextBox.Leave += new System.EventHandler(this.InputTextBox_Leave);
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
            // _easyLoanAssessButton
            // 
            this._easyLoanAssessButton.Location = new System.Drawing.Point(270, 49);
            this._easyLoanAssessButton.Name = "_easyLoanAssessButton";
            this._easyLoanAssessButton.Size = new System.Drawing.Size(75, 23);
            this._easyLoanAssessButton.TabIndex = 5;
            this._easyLoanAssessButton.TabStop = false;
            this._easyLoanAssessButton.Text = "Assess";
            this._easyLoanAssessButton.UseVisualStyleBackColor = true;
            this._easyLoanAssessButton.Click += new System.EventHandler(this.LoanAddButton_Click);
            // 
            // _easyLoanTextBox
            // 
            this._easyLoanTextBox.Location = new System.Drawing.Point(164, 51);
            this._easyLoanTextBox.Name = "_easyLoanTextBox";
            this._easyLoanTextBox.ReadOnly = true;
            this._easyLoanTextBox.Size = new System.Drawing.Size(100, 21);
            this._easyLoanTextBox.TabIndex = 1;
            this._easyLoanTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._easyLoanTextBox.Enter += new System.EventHandler(this.InputTextBox_Enter);
            this._easyLoanTextBox.Leave += new System.EventHandler(this.InputTextBox_Leave);
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
            // _applienceLoanAssessButton
            // 
            this._applienceLoanAssessButton.Location = new System.Drawing.Point(270, 23);
            this._applienceLoanAssessButton.Name = "_applienceLoanAssessButton";
            this._applienceLoanAssessButton.Size = new System.Drawing.Size(75, 23);
            this._applienceLoanAssessButton.TabIndex = 2;
            this._applienceLoanAssessButton.TabStop = false;
            this._applienceLoanAssessButton.Text = "Assess";
            this._applienceLoanAssessButton.UseVisualStyleBackColor = true;
            this._applienceLoanAssessButton.Click += new System.EventHandler(this.LoanAddButton_Click);
            // 
            // _applianceLoanTextBox
            // 
            this._applianceLoanTextBox.Location = new System.Drawing.Point(164, 25);
            this._applianceLoanTextBox.Name = "_applianceLoanTextBox";
            this._applianceLoanTextBox.ReadOnly = true;
            this._applianceLoanTextBox.Size = new System.Drawing.Size(100, 21);
            this._applianceLoanTextBox.TabIndex = 0;
            this._applianceLoanTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._applianceLoanTextBox.Enter += new System.EventHandler(this.InputTextBox_Enter);
            this._applianceLoanTextBox.Leave += new System.EventHandler(this.InputTextBox_Leave);
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._deathAidFundAssessButton);
            this.groupBox4.Controls.Add(this._deathAidFundTextBox);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this._tulunganFundAssessButton);
            this.groupBox4.Controls.Add(this._tulunganFundTextBox);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(410, 160);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(392, 196);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Special Funds:";
            // 
            // _deathAidFundAssessButton
            // 
            this._deathAidFundAssessButton.Location = new System.Drawing.Point(270, 49);
            this._deathAidFundAssessButton.Name = "_deathAidFundAssessButton";
            this._deathAidFundAssessButton.Size = new System.Drawing.Size(75, 23);
            this._deathAidFundAssessButton.TabIndex = 5;
            this._deathAidFundAssessButton.TabStop = false;
            this._deathAidFundAssessButton.Text = "Assess";
            this._deathAidFundAssessButton.UseVisualStyleBackColor = true;
            this._deathAidFundAssessButton.Click += new System.EventHandler(this.SpecialFundsAddButton_Click);
            // 
            // _deathAidFundTextBox
            // 
            this._deathAidFundTextBox.Location = new System.Drawing.Point(164, 51);
            this._deathAidFundTextBox.Name = "_deathAidFundTextBox";
            this._deathAidFundTextBox.ReadOnly = true;
            this._deathAidFundTextBox.Size = new System.Drawing.Size(100, 21);
            this._deathAidFundTextBox.TabIndex = 1;
            this._deathAidFundTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._deathAidFundTextBox.Enter += new System.EventHandler(this.InputTextBox_Enter);
            this._deathAidFundTextBox.Leave += new System.EventHandler(this.InputTextBox_Leave);
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
            // _tulunganFundAssessButton
            // 
            this._tulunganFundAssessButton.Location = new System.Drawing.Point(270, 23);
            this._tulunganFundAssessButton.Name = "_tulunganFundAssessButton";
            this._tulunganFundAssessButton.Size = new System.Drawing.Size(75, 23);
            this._tulunganFundAssessButton.TabIndex = 2;
            this._tulunganFundAssessButton.TabStop = false;
            this._tulunganFundAssessButton.Text = "Assess";
            this._tulunganFundAssessButton.UseVisualStyleBackColor = true;
            this._tulunganFundAssessButton.Click += new System.EventHandler(this.SpecialFundsAddButton_Click);
            // 
            // _tulunganFundTextBox
            // 
            this._tulunganFundTextBox.Location = new System.Drawing.Point(164, 25);
            this._tulunganFundTextBox.Name = "_tulunganFundTextBox";
            this._tulunganFundTextBox.ReadOnly = true;
            this._tulunganFundTextBox.Size = new System.Drawing.Size(100, 21);
            this._tulunganFundTextBox.TabIndex = 0;
            this._tulunganFundTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._tulunganFundTextBox.Enter += new System.EventHandler(this.InputTextBox_Enter);
            this._tulunganFundTextBox.Leave += new System.EventHandler(this.InputTextBox_Leave);
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
            // _voucherNumberTextBox
            // 
            this._voucherNumberTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._voucherNumberTextBox.Location = new System.Drawing.Point(108, 12);
            this._voucherNumberTextBox.Name = "_voucherNumberTextBox";
            this._voucherNumberTextBox.ReadOnly = true;
            this._voucherNumberTextBox.Size = new System.Drawing.Size(100, 22);
            this._voucherNumberTextBox.TabIndex = 12;
            this._voucherNumberTextBox.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Voucher Number:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 388);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(814, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(727, 362);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 14;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "&Close";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = true;
            // 
            // _acceptButton
            // 
            this._acceptButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._acceptButton.Location = new System.Drawing.Point(565, 362);
            this._acceptButton.Name = "_acceptButton";
            this._acceptButton.Size = new System.Drawing.Size(75, 23);
            this._acceptButton.TabIndex = 15;
            this._acceptButton.TabStop = false;
            this._acceptButton.Text = "&Accept";
            this._acceptButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._acceptButton.UseVisualStyleBackColor = true;
            this._acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // _clearButton
            // 
            this._clearButton.Location = new System.Drawing.Point(646, 362);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(75, 23);
            this._clearButton.TabIndex = 16;
            this._clearButton.TabStop = false;
            this._clearButton.Text = "Cle&ar";
            this._clearButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._clearButton.UseVisualStyleBackColor = true;
            this._clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // _sequenceTextBox
            // 
            this._sequenceTextBox.Enabled = false;
            this._sequenceTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._sequenceTextBox.Location = new System.Drawing.Point(279, 12);
            this._sequenceTextBox.Name = "_sequenceTextBox";
            this._sequenceTextBox.Size = new System.Drawing.Size(100, 22);
            this._sequenceTextBox.TabIndex = 17;
            this._sequenceTextBox.TabStop = false;
            // 
            // _restartVoucherCheckBox
            // 
            this._restartVoucherCheckBox.AutoSize = true;
            this._restartVoucherCheckBox.Location = new System.Drawing.Point(214, 15);
            this._restartVoucherCheckBox.Name = "_restartVoucherCheckBox";
            this._restartVoucherCheckBox.Size = new System.Drawing.Size(62, 17);
            this._restartVoucherCheckBox.TabIndex = 18;
            this._restartVoucherCheckBox.Text = "Restart";
            this._restartVoucherCheckBox.UseVisualStyleBackColor = true;
            this._restartVoucherCheckBox.CheckedChanged += new System.EventHandler(this.RestartVoucherCheckBox_CheckedChanged);
            // 
            // _generateVoucherButton
            // 
            this._generateVoucherButton.Enabled = false;
            this._generateVoucherButton.Location = new System.Drawing.Point(385, 11);
            this._generateVoucherButton.Name = "_generateVoucherButton";
            this._generateVoucherButton.Size = new System.Drawing.Size(75, 23);
            this._generateVoucherButton.TabIndex = 19;
            this._generateVoucherButton.TabStop = false;
            this._generateVoucherButton.Text = "Generate";
            this._generateVoucherButton.UseVisualStyleBackColor = true;
            this._generateVoucherButton.Click += new System.EventHandler(this.GenerateVoucherButton_Click);
            // 
            // CashDisbursementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(814, 410);
            this.Controls.Add(this._generateVoucherButton);
            this.Controls.Add(this._restartVoucherCheckBox);
            this.Controls.Add(this._sequenceTextBox);
            this.Controls.Add(this._clearButton);
            this.Controls.Add(this._acceptButton);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._voucherNumberTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._disbursementDateDateTimePicker);
            this.Controls.Add(this.groupBox1);
            this.Name = "CashDisbursementView";
            this.Text = "Cash Disbursement";
            this.Shown += new System.EventHandler(this.CashDisbursementView_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _savingsDepositAssessButton;
        private System.Windows.Forms.TextBox _savingsDepositTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _timeDepositAssessButton;
        private System.Windows.Forms.TextBox _timeDepositTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _capitalShareAssessButton;
        private System.Windows.Forms.TextBox _capitalShareTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker _disbursementDateDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button _collegeInsurancePlanAssessButton;
        private System.Windows.Forms.TextBox _collegeInsurancePlanTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button _pensionPlanAssessButton;
        private System.Windows.Forms.TextBox _pensionPlanTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button _emergencyLoanAssessButton;
        private System.Windows.Forms.TextBox _emergencyLoanTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button _easyLoanAssessButton;
        private System.Windows.Forms.TextBox _easyLoanTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button _applienceLoanAssessButton;
        private System.Windows.Forms.TextBox _applianceLoanTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button _deathAidFundAssessButton;
        private System.Windows.Forms.TextBox _deathAidFundTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button _tulunganFundAssessButton;
        private System.Windows.Forms.TextBox _tulunganFundTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button _pensionLoanAssessButton;
        private System.Windows.Forms.TextBox _pensionLoanTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button _equityLoanAssessButton;
        private System.Windows.Forms.TextBox _equityLoanTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox _voucherNumberTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.Button _acceptButton;
        private System.Windows.Forms.Button _clearButton;
        private System.Windows.Forms.TextBox _sequenceTextBox;
        private System.Windows.Forms.CheckBox _restartVoucherCheckBox;
        private System.Windows.Forms.Button _generateVoucherButton;
        private System.Windows.Forms.Button _regularLoanAssessButton;
        private System.Windows.Forms.TextBox _regularLoanTextBox;
        private System.Windows.Forms.Label label11;
    }
}