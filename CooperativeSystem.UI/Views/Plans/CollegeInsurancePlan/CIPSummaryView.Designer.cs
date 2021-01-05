namespace CooperativeSystem.UI.Views.Plans.CollegeInsurancePlan
{
    partial class CIPSummaryView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._totalBalanceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._receiptsDataGridView = new System.Windows.Forms.DataGridView();
            this._dateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._trasactionTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._referenceNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._amountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._balanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._collegeInsurancePlansDataGridView = new System.Windows.Forms.DataGridView();
            this.statusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maturityDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._addressLabel = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this._relationLabel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this._dateOfBirthLabel = new System.Windows.Forms.Label();
            this._userNameLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._agingPeriodLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._paymentCompletionDateLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._awardAmountLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._maturityAmountLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._paymentModeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._amortizationLabel = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this._maturityDateLabel = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this._termsLabel = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this._applicationDateLabel = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this._modifyButton = new System.Windows.Forms.Button();
            this._enrollButton = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._receiptsDataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._collegeInsurancePlansDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._totalBalanceTextBox);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this._receiptsDataGridView);
            this.groupBox4.Location = new System.Drawing.Point(3, 116);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(421, 158);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "CIP Payment Details";
            // 
            // _totalBalanceTextBox
            // 
            this._totalBalanceTextBox.Location = new System.Drawing.Point(292, 131);
            this._totalBalanceTextBox.Name = "_totalBalanceTextBox";
            this._totalBalanceTextBox.ReadOnly = true;
            this._totalBalanceTextBox.Size = new System.Drawing.Size(123, 21);
            this._totalBalanceTextBox.TabIndex = 7;
            this._totalBalanceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Total:";
            // 
            // _receiptsDataGridView
            // 
            this._receiptsDataGridView.AllowUserToAddRows = false;
            this._receiptsDataGridView.AllowUserToDeleteRows = false;
            this._receiptsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._receiptsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._receiptsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._dateColumn,
            this._trasactionTypeColumn,
            this._referenceNumberColumn,
            this._amountColumn,
            this._balanceColumn});
            this._receiptsDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this._receiptsDataGridView.Location = new System.Drawing.Point(3, 17);
            this._receiptsDataGridView.MultiSelect = false;
            this._receiptsDataGridView.Name = "_receiptsDataGridView";
            this._receiptsDataGridView.ReadOnly = true;
            this._receiptsDataGridView.RowHeadersVisible = false;
            this._receiptsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._receiptsDataGridView.Size = new System.Drawing.Size(415, 108);
            this._receiptsDataGridView.TabIndex = 5;
            // 
            // _dateColumn
            // 
            this._dateColumn.DataPropertyName = "Date";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this._dateColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this._dateColumn.HeaderText = "Date";
            this._dateColumn.Name = "_dateColumn";
            this._dateColumn.ReadOnly = true;
            // 
            // _trasactionTypeColumn
            // 
            this._trasactionTypeColumn.DataPropertyName = "TransactionType";
            this._trasactionTypeColumn.HeaderText = "Type";
            this._trasactionTypeColumn.Name = "_trasactionTypeColumn";
            this._trasactionTypeColumn.ReadOnly = true;
            // 
            // _referenceNumberColumn
            // 
            this._referenceNumberColumn.DataPropertyName = "ReferenceNumber";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this._referenceNumberColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this._referenceNumberColumn.HeaderText = "Receipt";
            this._referenceNumberColumn.Name = "_referenceNumberColumn";
            this._referenceNumberColumn.ReadOnly = true;
            // 
            // _amountColumn
            // 
            this._amountColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this._amountColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this._amountColumn.HeaderText = "Amount";
            this._amountColumn.Name = "_amountColumn";
            this._amountColumn.ReadOnly = true;
            // 
            // _balanceColumn
            // 
            this._balanceColumn.DataPropertyName = "Balance";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this._balanceColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this._balanceColumn.HeaderText = "Balance";
            this._balanceColumn.Name = "_balanceColumn";
            this._balanceColumn.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._collegeInsurancePlansDataGridView);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(421, 107);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CIP List";
            // 
            // _collegeInsurancePlansDataGridView
            // 
            this._collegeInsurancePlansDataGridView.AllowUserToAddRows = false;
            this._collegeInsurancePlansDataGridView.AllowUserToDeleteRows = false;
            this._collegeInsurancePlansDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._collegeInsurancePlansDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._collegeInsurancePlansDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statusColumn,
            this.userNameColumn,
            this.maturityDateColumn});
            this._collegeInsurancePlansDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._collegeInsurancePlansDataGridView.Location = new System.Drawing.Point(3, 17);
            this._collegeInsurancePlansDataGridView.MultiSelect = false;
            this._collegeInsurancePlansDataGridView.Name = "_collegeInsurancePlansDataGridView";
            this._collegeInsurancePlansDataGridView.ReadOnly = true;
            this._collegeInsurancePlansDataGridView.RowHeadersVisible = false;
            this._collegeInsurancePlansDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._collegeInsurancePlansDataGridView.Size = new System.Drawing.Size(415, 87);
            this._collegeInsurancePlansDataGridView.TabIndex = 56;
            this._collegeInsurancePlansDataGridView.SelectionChanged += new System.EventHandler(this.CollegeInsurancePlansDataGridView_SelectionChanged);
            // 
            // statusColumn
            // 
            this.statusColumn.DataPropertyName = "Status";
            this.statusColumn.FillWeight = 99.47188F;
            this.statusColumn.HeaderText = "Status";
            this.statusColumn.Name = "statusColumn";
            this.statusColumn.ReadOnly = true;
            // 
            // userNameColumn
            // 
            this.userNameColumn.DataPropertyName = "UserName";
            this.userNameColumn.FillWeight = 152.2843F;
            this.userNameColumn.HeaderText = "User Name";
            this.userNameColumn.Name = "userNameColumn";
            this.userNameColumn.ReadOnly = true;
            // 
            // maturityDateColumn
            // 
            this.maturityDateColumn.DataPropertyName = "MaturityDate";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "d";
            this.maturityDateColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.maturityDateColumn.FillWeight = 48.24385F;
            this.maturityDateColumn.HeaderText = "Maturity";
            this.maturityDateColumn.Name = "maturityDateColumn";
            this.maturityDateColumn.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._addressLabel);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this._relationLabel);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this._dateOfBirthLabel);
            this.groupBox2.Controls.Add(this._userNameLabel);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(430, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 92);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Details";
            // 
            // _addressLabel
            // 
            this._addressLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._addressLabel.Location = new System.Drawing.Point(109, 58);
            this._addressLabel.Name = "_addressLabel";
            this._addressLabel.Size = new System.Drawing.Size(175, 31);
            this._addressLabel.TabIndex = 69;
            this._addressLabel.Text = "Ocean Street Virgina Summer Ville, Mayamot, Antipolo City";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(47, 59);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 13);
            this.label21.TabIndex = 67;
            this.label21.Text = "Address:";
            // 
            // _relationLabel
            // 
            this._relationLabel.AutoSize = true;
            this._relationLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._relationLabel.Location = new System.Drawing.Point(110, 44);
            this._relationLabel.Name = "_relationLabel";
            this._relationLabel.Size = new System.Drawing.Size(28, 14);
            this._relationLabel.TabIndex = 66;
            this._relationLabel.Text = "Son";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(47, 45);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 13);
            this.label15.TabIndex = 65;
            this.label15.Text = "Relation:";
            // 
            // _dateOfBirthLabel
            // 
            this._dateOfBirthLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dateOfBirthLabel.Location = new System.Drawing.Point(110, 31);
            this._dateOfBirthLabel.Name = "_dateOfBirthLabel";
            this._dateOfBirthLabel.Size = new System.Drawing.Size(73, 13);
            this._dateOfBirthLabel.TabIndex = 64;
            this._dateOfBirthLabel.Text = "06/24/1994";
            // 
            // _userNameLabel
            // 
            this._userNameLabel.AutoSize = true;
            this._userNameLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._userNameLabel.Location = new System.Drawing.Point(110, 17);
            this._userNameLabel.Name = "_userNameLabel";
            this._userNameLabel.Size = new System.Drawing.Size(126, 14);
            this._userNameLabel.TabIndex = 63;
            this._userNameLabel.Text = "Chavez, Julio Cesar Jr.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(23, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 62;
            this.label10.Text = "Date of Birth:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(33, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 61;
            this.label11.Text = "User Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._agingPeriodLabel);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this._paymentCompletionDateLabel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this._awardAmountLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._maturityAmountLabel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this._paymentModeLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._amortizationLabel);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this._maturityDateLabel);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this._termsLabel);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this._applicationDateLabel);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Location = new System.Drawing.Point(430, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 144);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Details";
            // 
            // _agingPeriodLabel
            // 
            this._agingPeriodLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._agingPeriodLabel.Location = new System.Drawing.Point(211, 83);
            this._agingPeriodLabel.Name = "_agingPeriodLabel";
            this._agingPeriodLabel.Size = new System.Drawing.Size(73, 13);
            this._agingPeriodLabel.TabIndex = 104;
            this._agingPeriodLabel.Text = "5";
            this._agingPeriodLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(124, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 103;
            this.label8.Text = "Aging Period:";
            // 
            // _paymentCompletionDateLabel
            // 
            this._paymentCompletionDateLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._paymentCompletionDateLabel.Location = new System.Drawing.Point(210, 30);
            this._paymentCompletionDateLabel.Name = "_paymentCompletionDateLabel";
            this._paymentCompletionDateLabel.Size = new System.Drawing.Size(73, 13);
            this._paymentCompletionDateLabel.TabIndex = 102;
            this._paymentCompletionDateLabel.Text = "06/24/1994";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 13);
            this.label6.TabIndex = 101;
            this.label6.Text = "Payment Completion Date:";
            // 
            // _awardAmountLabel
            // 
            this._awardAmountLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._awardAmountLabel.Location = new System.Drawing.Point(211, 122);
            this._awardAmountLabel.Name = "_awardAmountLabel";
            this._awardAmountLabel.Size = new System.Drawing.Size(73, 13);
            this._awardAmountLabel.TabIndex = 100;
            this._awardAmountLabel.Text = "36,000.00";
            this._awardAmountLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(111, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 99;
            this.label3.Text = "Award Amount:";
            // 
            // _maturityAmountLabel
            // 
            this._maturityAmountLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._maturityAmountLabel.Location = new System.Drawing.Point(211, 109);
            this._maturityAmountLabel.Name = "_maturityAmountLabel";
            this._maturityAmountLabel.Size = new System.Drawing.Size(73, 13);
            this._maturityAmountLabel.TabIndex = 98;
            this._maturityAmountLabel.Text = "18,000.00";
            this._maturityAmountLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 13);
            this.label5.TabIndex = 97;
            this.label5.Text = "Payment Completion Amount:";
            // 
            // _paymentModeLabel
            // 
            this._paymentModeLabel.AutoSize = true;
            this._paymentModeLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._paymentModeLabel.Location = new System.Drawing.Point(211, 56);
            this._paymentModeLabel.Name = "_paymentModeLabel";
            this._paymentModeLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._paymentModeLabel.Size = new System.Drawing.Size(50, 14);
            this._paymentModeLabel.TabIndex = 96;
            this._paymentModeLabel.Text = "Monthly";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(110, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Payment Mode:";
            // 
            // _amortizationLabel
            // 
            this._amortizationLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._amortizationLabel.Location = new System.Drawing.Point(211, 96);
            this._amortizationLabel.Name = "_amortizationLabel";
            this._amortizationLabel.Size = new System.Drawing.Size(73, 13);
            this._amortizationLabel.TabIndex = 94;
            this._amortizationLabel.Text = "10";
            this._amortizationLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(121, 97);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(84, 13);
            this.label23.TabIndex = 93;
            this.label23.Text = "Amortization:";
            // 
            // _maturityDateLabel
            // 
            this._maturityDateLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._maturityDateLabel.Location = new System.Drawing.Point(211, 43);
            this._maturityDateLabel.Name = "_maturityDateLabel";
            this._maturityDateLabel.Size = new System.Drawing.Size(73, 13);
            this._maturityDateLabel.TabIndex = 92;
            this._maturityDateLabel.Text = "06/24/1994";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(116, 44);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(89, 13);
            this.label27.TabIndex = 91;
            this.label27.Text = "Maturity Date:";
            // 
            // _termsLabel
            // 
            this._termsLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._termsLabel.Location = new System.Drawing.Point(211, 70);
            this._termsLabel.Name = "_termsLabel";
            this._termsLabel.Size = new System.Drawing.Size(73, 13);
            this._termsLabel.TabIndex = 90;
            this._termsLabel.Text = "5";
            this._termsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(159, 71);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 13);
            this.label17.TabIndex = 89;
            this.label17.Text = "Terms:";
            // 
            // _applicationDateLabel
            // 
            this._applicationDateLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._applicationDateLabel.Location = new System.Drawing.Point(210, 17);
            this._applicationDateLabel.Name = "_applicationDateLabel";
            this._applicationDateLabel.Size = new System.Drawing.Size(73, 13);
            this._applicationDateLabel.TabIndex = 88;
            this._applicationDateLabel.Text = "08/23/2000";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(102, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(103, 13);
            this.label20.TabIndex = 87;
            this.label20.Text = "Application Date:";
            // 
            // _modifyButton
            // 
            this._modifyButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._modifyButton.Image = global::CooperativeSystem.UI.Properties.Resources.edit;
            this._modifyButton.Location = new System.Drawing.Point(658, 251);
            this._modifyButton.Name = "_modifyButton";
            this._modifyButton.Size = new System.Drawing.Size(75, 23);
            this._modifyButton.TabIndex = 73;
            this._modifyButton.Text = "&Modify";
            this._modifyButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._modifyButton.UseVisualStyleBackColor = true;
            this._modifyButton.Click += new System.EventHandler(this.ActionButton_Click);
            // 
            // _enrollButton
            // 
            this._enrollButton.Image = global::CooperativeSystem.UI.Properties.Resources.add;
            this._enrollButton.Location = new System.Drawing.Point(577, 251);
            this._enrollButton.Name = "_enrollButton";
            this._enrollButton.Size = new System.Drawing.Size(75, 23);
            this._enrollButton.TabIndex = 72;
            this._enrollButton.Text = "&Enroll";
            this._enrollButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._enrollButton.UseVisualStyleBackColor = true;
            this._enrollButton.Click += new System.EventHandler(this.ActionButton_Click);
            // 
            // CIPSummaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._modifyButton);
            this.Controls.Add(this._enrollButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "CIPSummaryView";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._receiptsDataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._collegeInsurancePlansDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox _totalBalanceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView _receiptsDataGridView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView _collegeInsurancePlansDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maturityDateColumn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label _addressLabel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label _relationLabel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label _dateOfBirthLabel;
        private System.Windows.Forms.Label _userNameLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label _agingPeriodLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label _paymentCompletionDateLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label _awardAmountLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label _maturityAmountLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label _paymentModeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _amortizationLabel;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label _maturityDateLabel;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label _termsLabel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label _applicationDateLabel;
        private System.Windows.Forms.Label label20;
        protected System.Windows.Forms.Button _modifyButton;
        protected System.Windows.Forms.Button _enrollButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _trasactionTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _referenceNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _amountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _balanceColumn;
    }
}
