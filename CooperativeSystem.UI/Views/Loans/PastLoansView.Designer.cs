namespace CooperativeSystem.UI.Views.Loans
{
    partial class PastLoansView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this._closeButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this._transactionsTabPage = new System.Windows.Forms.TabPage();
            this._totalPaymentTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this._paymentsDataGridView = new System.Windows.Forms.DataGridView();
            this._finesTabPage = new System.Windows.Forms.TabPage();
            this._totalFineTextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this._finesDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._chargesTabPage = new System.Windows.Forms.TabPage();
            this._chargesDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._totalChargeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._totalPayableAmountLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._settlementDateLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._interestLabel = new System.Windows.Forms.Label();
            this._loanGuaranteeFundLabel = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this._capitalBuildupLabel = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this._collectionFeeLabel = new System.Windows.Forms.Label();
            this._serviceFeeLabel = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this._amortizationLabel = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this._loanAmountLabel = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this._dueDateLabel = new System.Windows.Forms.Label();
            this._termsLabel = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this._deductionTypeLabel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this._paymentModeLabel = new System.Windows.Forms.Label();
            this._loanDateLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this._loansComboBox = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._dateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._transactionTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._referenceNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._amountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._balanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this._transactionsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._paymentsDataGridView)).BeginInit();
            this._finesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._finesDataGridView)).BeginInit();
            this._chargesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._chargesDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(458, 467);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 69;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this._transactionsTabPage);
            this.tabControl1.Controls.Add(this._finesTabPage);
            this.tabControl1.Controls.Add(this._chargesTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 190);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(521, 271);
            this.tabControl1.TabIndex = 72;
            // 
            // _transactionsTabPage
            // 
            this._transactionsTabPage.Controls.Add(this._totalPaymentTextBox);
            this._transactionsTabPage.Controls.Add(this.label18);
            this._transactionsTabPage.Controls.Add(this._paymentsDataGridView);
            this._transactionsTabPage.Location = new System.Drawing.Point(4, 22);
            this._transactionsTabPage.Name = "_transactionsTabPage";
            this._transactionsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._transactionsTabPage.Size = new System.Drawing.Size(513, 245);
            this._transactionsTabPage.TabIndex = 0;
            this._transactionsTabPage.Text = "Transactions";
            this._transactionsTabPage.UseVisualStyleBackColor = true;
            // 
            // _totalPaymentTextBox
            // 
            this._totalPaymentTextBox.Location = new System.Drawing.Point(370, 218);
            this._totalPaymentTextBox.Name = "_totalPaymentTextBox";
            this._totalPaymentTextBox.ReadOnly = true;
            this._totalPaymentTextBox.Size = new System.Drawing.Size(137, 21);
            this._totalPaymentTextBox.TabIndex = 9;
            this._totalPaymentTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(329, 223);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 8;
            this.label18.Text = "Total:";
            // 
            // _paymentsDataGridView
            // 
            this._paymentsDataGridView.AllowUserToAddRows = false;
            this._paymentsDataGridView.AllowUserToDeleteRows = false;
            this._paymentsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._paymentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._paymentsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._dateColumn,
            this._transactionTypeColumn,
            this._referenceNumberColumn,
            this._amountColumn,
            this._balanceColumn});
            this._paymentsDataGridView.Location = new System.Drawing.Point(6, 6);
            this._paymentsDataGridView.MultiSelect = false;
            this._paymentsDataGridView.Name = "_paymentsDataGridView";
            this._paymentsDataGridView.ReadOnly = true;
            this._paymentsDataGridView.RowHeadersVisible = false;
            this._paymentsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._paymentsDataGridView.Size = new System.Drawing.Size(501, 206);
            this._paymentsDataGridView.TabIndex = 7;
            // 
            // _finesTabPage
            // 
            this._finesTabPage.Controls.Add(this._totalFineTextBox);
            this._finesTabPage.Controls.Add(this.label19);
            this._finesTabPage.Controls.Add(this._finesDataGridView);
            this._finesTabPage.Location = new System.Drawing.Point(4, 22);
            this._finesTabPage.Name = "_finesTabPage";
            this._finesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._finesTabPage.Size = new System.Drawing.Size(513, 245);
            this._finesTabPage.TabIndex = 1;
            this._finesTabPage.Text = "Fines";
            this._finesTabPage.UseVisualStyleBackColor = true;
            // 
            // _totalFineTextBox
            // 
            this._totalFineTextBox.Location = new System.Drawing.Point(370, 218);
            this._totalFineTextBox.Name = "_totalFineTextBox";
            this._totalFineTextBox.ReadOnly = true;
            this._totalFineTextBox.Size = new System.Drawing.Size(137, 21);
            this._totalFineTextBox.TabIndex = 11;
            this._totalFineTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(329, 223);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 10;
            this.label19.Text = "Total:";
            // 
            // _finesDataGridView
            // 
            this._finesDataGridView.AllowUserToAddRows = false;
            this._finesDataGridView.AllowUserToDeleteRows = false;
            this._finesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._finesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._finesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this._finesDataGridView.Location = new System.Drawing.Point(6, 6);
            this._finesDataGridView.MultiSelect = false;
            this._finesDataGridView.Name = "_finesDataGridView";
            this._finesDataGridView.ReadOnly = true;
            this._finesDataGridView.RowHeadersVisible = false;
            this._finesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._finesDataGridView.Size = new System.Drawing.Size(501, 206);
            this._finesDataGridView.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PaymentDate";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "d";
            dataGridViewCellStyle11.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn1.HeaderText = "Payment Date";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ReceiptNumber";
            this.dataGridViewTextBoxColumn2.HeaderText = "Receipt Number";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PaymentAmount";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn3.HeaderText = "Fine";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // _chargesTabPage
            // 
            this._chargesTabPage.Controls.Add(this._chargesDataGridView);
            this._chargesTabPage.Controls.Add(this._totalChargeTextBox);
            this._chargesTabPage.Controls.Add(this.label3);
            this._chargesTabPage.Location = new System.Drawing.Point(4, 22);
            this._chargesTabPage.Name = "_chargesTabPage";
            this._chargesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._chargesTabPage.Size = new System.Drawing.Size(513, 245);
            this._chargesTabPage.TabIndex = 2;
            this._chargesTabPage.Text = "Charges";
            this._chargesTabPage.UseVisualStyleBackColor = true;
            // 
            // _chargesDataGridView
            // 
            this._chargesDataGridView.AllowUserToAddRows = false;
            this._chargesDataGridView.AllowUserToDeleteRows = false;
            this._chargesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._chargesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._chargesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this._chargesDataGridView.Location = new System.Drawing.Point(6, 6);
            this._chargesDataGridView.MultiSelect = false;
            this._chargesDataGridView.Name = "_chargesDataGridView";
            this._chargesDataGridView.ReadOnly = true;
            this._chargesDataGridView.RowHeadersVisible = false;
            this._chargesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._chargesDataGridView.Size = new System.Drawing.Size(501, 206);
            this._chargesDataGridView.TabIndex = 12;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PaymentDate";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "d";
            dataGridViewCellStyle13.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn4.HeaderText = "Payment Date";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ReceiptNumber";
            this.dataGridViewTextBoxColumn5.HeaderText = "Receipt Number";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PaymentAmount";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn6.HeaderText = "Charge";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // _totalChargeTextBox
            // 
            this._totalChargeTextBox.Location = new System.Drawing.Point(370, 218);
            this._totalChargeTextBox.Name = "_totalChargeTextBox";
            this._totalChargeTextBox.ReadOnly = true;
            this._totalChargeTextBox.Size = new System.Drawing.Size(137, 21);
            this._totalChargeTextBox.TabIndex = 11;
            this._totalChargeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._totalPayableAmountLabel);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this._settlementDateLabel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this._interestLabel);
            this.groupBox2.Controls.Add(this._loanGuaranteeFundLabel);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this._capitalBuildupLabel);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this._collectionFeeLabel);
            this.groupBox2.Controls.Add(this._serviceFeeLabel);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Controls.Add(this._amortizationLabel);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this._loanAmountLabel);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this._dueDateLabel);
            this.groupBox2.Controls.Add(this._termsLabel);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this._deductionTypeLabel);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this._paymentModeLabel);
            this.groupBox2.Controls.Add(this._loanDateLabel);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(521, 144);
            this.groupBox2.TabIndex = 71;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loan Details";
            // 
            // _totalPayableAmountLabel
            // 
            this._totalPayableAmountLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._totalPayableAmountLabel.Location = new System.Drawing.Point(406, 101);
            this._totalPayableAmountLabel.Name = "_totalPayableAmountLabel";
            this._totalPayableAmountLabel.Size = new System.Drawing.Size(73, 14);
            this._totalPayableAmountLabel.TabIndex = 62;
            this._totalPayableAmountLabel.Text = "100,000.00";
            this._totalPayableAmountLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(265, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Total Payable Amount:";
            // 
            // _settlementDateLabel
            // 
            this._settlementDateLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._settlementDateLabel.Location = new System.Drawing.Point(147, 31);
            this._settlementDateLabel.Name = "_settlementDateLabel";
            this._settlementDateLabel.Size = new System.Drawing.Size(73, 14);
            this._settlementDateLabel.TabIndex = 60;
            this._settlementDateLabel.Text = "00/00/0000";
            this._settlementDateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Settlement Date:";
            // 
            // _interestLabel
            // 
            this._interestLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._interestLabel.Location = new System.Drawing.Point(406, 73);
            this._interestLabel.Name = "_interestLabel";
            this._interestLabel.Size = new System.Drawing.Size(73, 14);
            this._interestLabel.TabIndex = 58;
            this._interestLabel.Text = "1,000.00";
            this._interestLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _loanGuaranteeFundLabel
            // 
            this._loanGuaranteeFundLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._loanGuaranteeFundLabel.Location = new System.Drawing.Point(406, 59);
            this._loanGuaranteeFundLabel.Name = "_loanGuaranteeFundLabel";
            this._loanGuaranteeFundLabel.Size = new System.Drawing.Size(73, 14);
            this._loanGuaranteeFundLabel.TabIndex = 57;
            this._loanGuaranteeFundLabel.Text = "1,000.00";
            this._loanGuaranteeFundLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(343, 74);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(57, 13);
            this.label28.TabIndex = 56;
            this.label28.Text = "Interest:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(270, 60);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(130, 13);
            this.label29.TabIndex = 55;
            this.label29.Text = "Loan Guarantee Fund:";
            // 
            // _capitalBuildupLabel
            // 
            this._capitalBuildupLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._capitalBuildupLabel.Location = new System.Drawing.Point(406, 45);
            this._capitalBuildupLabel.Name = "_capitalBuildupLabel";
            this._capitalBuildupLabel.Size = new System.Drawing.Size(73, 14);
            this._capitalBuildupLabel.TabIndex = 54;
            this._capitalBuildupLabel.Text = "1,000.00";
            this._capitalBuildupLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(307, 46);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(93, 13);
            this.label31.TabIndex = 53;
            this.label31.Text = "Capital Buildup:";
            // 
            // _collectionFeeLabel
            // 
            this._collectionFeeLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._collectionFeeLabel.Location = new System.Drawing.Point(406, 31);
            this._collectionFeeLabel.Name = "_collectionFeeLabel";
            this._collectionFeeLabel.Size = new System.Drawing.Size(73, 14);
            this._collectionFeeLabel.TabIndex = 52;
            this._collectionFeeLabel.Text = "1,000.00";
            this._collectionFeeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _serviceFeeLabel
            // 
            this._serviceFeeLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._serviceFeeLabel.Location = new System.Drawing.Point(406, 17);
            this._serviceFeeLabel.Name = "_serviceFeeLabel";
            this._serviceFeeLabel.Size = new System.Drawing.Size(73, 14);
            this._serviceFeeLabel.TabIndex = 51;
            this._serviceFeeLabel.Text = "1,000.00";
            this._serviceFeeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(312, 31);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(88, 13);
            this.label34.TabIndex = 50;
            this.label34.Text = "Collection Fee:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(325, 17);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(75, 13);
            this.label35.TabIndex = 49;
            this.label35.Text = "Service Fee:";
            // 
            // _amortizationLabel
            // 
            this._amortizationLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._amortizationLabel.Location = new System.Drawing.Point(406, 115);
            this._amortizationLabel.Name = "_amortizationLabel";
            this._amortizationLabel.Size = new System.Drawing.Size(73, 14);
            this._amortizationLabel.TabIndex = 45;
            this._amortizationLabel.Text = "100,000.00";
            this._amortizationLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(316, 116);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(84, 13);
            this.label27.TabIndex = 43;
            this.label27.Text = "Amortization:";
            // 
            // _loanAmountLabel
            // 
            this._loanAmountLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._loanAmountLabel.Location = new System.Drawing.Point(406, 87);
            this._loanAmountLabel.Name = "_loanAmountLabel";
            this._loanAmountLabel.Size = new System.Drawing.Size(73, 14);
            this._loanAmountLabel.TabIndex = 42;
            this._loanAmountLabel.Text = "100,000.00";
            this._loanAmountLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(315, 88);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 13);
            this.label17.TabIndex = 41;
            this.label17.Text = "Loan Amount:";
            // 
            // _dueDateLabel
            // 
            this._dueDateLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dueDateLabel.Location = new System.Drawing.Point(147, 45);
            this._dueDateLabel.Name = "_dueDateLabel";
            this._dueDateLabel.Size = new System.Drawing.Size(73, 14);
            this._dueDateLabel.TabIndex = 40;
            this._dueDateLabel.Text = "00/00/0000";
            this._dueDateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _termsLabel
            // 
            this._termsLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._termsLabel.Location = new System.Drawing.Point(147, 59);
            this._termsLabel.Name = "_termsLabel";
            this._termsLabel.Size = new System.Drawing.Size(73, 14);
            this._termsLabel.TabIndex = 39;
            this._termsLabel.Text = "8";
            this._termsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(79, 46);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 13);
            this.label20.TabIndex = 38;
            this.label20.Text = "Due Date:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(95, 60);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 13);
            this.label21.TabIndex = 37;
            this.label21.Text = "Terms:";
            // 
            // _deductionTypeLabel
            // 
            this._deductionTypeLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._deductionTypeLabel.Location = new System.Drawing.Point(147, 87);
            this._deductionTypeLabel.Name = "_deductionTypeLabel";
            this._deductionTypeLabel.Size = new System.Drawing.Size(73, 14);
            this._deductionTypeLabel.TabIndex = 36;
            this._deductionTypeLabel.Text = "Add-on";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(43, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "Deduction Type:";
            // 
            // _paymentModeLabel
            // 
            this._paymentModeLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._paymentModeLabel.Location = new System.Drawing.Point(147, 73);
            this._paymentModeLabel.Name = "_paymentModeLabel";
            this._paymentModeLabel.Size = new System.Drawing.Size(73, 14);
            this._paymentModeLabel.TabIndex = 34;
            this._paymentModeLabel.Text = "Monthly";
            // 
            // _loanDateLabel
            // 
            this._loanDateLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._loanDateLabel.Location = new System.Drawing.Point(147, 17);
            this._loanDateLabel.Name = "_loanDateLabel";
            this._loanDateLabel.Size = new System.Drawing.Size(73, 14);
            this._loanDateLabel.TabIndex = 33;
            this._loanDateLabel.Text = "00/00/0000";
            this._loanDateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(46, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Payment Mode:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Loan Date:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 70;
            this.label11.Text = "Loans:";
            // 
            // _loansComboBox
            // 
            this._loansComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._loansComboBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this._loansComboBox.FormattingEnabled = true;
            this._loansComboBox.Location = new System.Drawing.Point(63, 12);
            this._loansComboBox.Name = "_loansComboBox";
            this._loansComboBox.Size = new System.Drawing.Size(121, 22);
            this._loansComboBox.TabIndex = 65;
            this._loansComboBox.SelectedValueChanged += new System.EventHandler(this.LoansComboBox_SelectedValueChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 493);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(545, 22);
            this.statusStrip1.TabIndex = 68;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _dateColumn
            // 
            this._dateColumn.DataPropertyName = "Date";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this._dateColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this._dateColumn.HeaderText = "Date";
            this._dateColumn.Name = "_dateColumn";
            this._dateColumn.ReadOnly = true;
            // 
            // _transactionTypeColumn
            // 
            this._transactionTypeColumn.DataPropertyName = "TransactionType";
            this._transactionTypeColumn.HeaderText = "Type";
            this._transactionTypeColumn.Name = "_transactionTypeColumn";
            this._transactionTypeColumn.ReadOnly = true;
            // 
            // _referenceNumberColumn
            // 
            this._referenceNumberColumn.DataPropertyName = "ReferenceNumber";
            this._referenceNumberColumn.HeaderText = "Reference";
            this._referenceNumberColumn.Name = "_referenceNumberColumn";
            this._referenceNumberColumn.ReadOnly = true;
            // 
            // _amountColumn
            // 
            this._amountColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this._amountColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this._amountColumn.HeaderText = "Amount";
            this._amountColumn.Name = "_amountColumn";
            this._amountColumn.ReadOnly = true;
            // 
            // _balanceColumn
            // 
            this._balanceColumn.DataPropertyName = "Balance";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this._balanceColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this._balanceColumn.HeaderText = "Balance";
            this._balanceColumn.Name = "_balanceColumn";
            this._balanceColumn.ReadOnly = true;
            // 
            // PastLoansView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(545, 515);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this._loansComboBox);
            this.Controls.Add(this.statusStrip1);
            this.Name = "PastLoansView";
            this.Text = "Past Loans";
            this.Shown += new System.EventHandler(this.PastLoansView_Shown);
            this.tabControl1.ResumeLayout(false);
            this._transactionsTabPage.ResumeLayout(false);
            this._transactionsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._paymentsDataGridView)).EndInit();
            this._finesTabPage.ResumeLayout(false);
            this._finesTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._finesDataGridView)).EndInit();
            this._chargesTabPage.ResumeLayout(false);
            this._chargesTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._chargesDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox _loansComboBox;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label _interestLabel;
        private System.Windows.Forms.Label _loanGuaranteeFundLabel;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label _capitalBuildupLabel;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label _collectionFeeLabel;
        private System.Windows.Forms.Label _serviceFeeLabel;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label _amortizationLabel;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label _loanAmountLabel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label _dueDateLabel;
        private System.Windows.Forms.Label _termsLabel;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label _deductionTypeLabel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label _paymentModeLabel;
        private System.Windows.Forms.Label _loanDateLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage _transactionsTabPage;
        private System.Windows.Forms.TextBox _totalPaymentTextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView _paymentsDataGridView;
        private System.Windows.Forms.TabPage _finesTabPage;
        private System.Windows.Forms.TextBox _totalFineTextBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridView _finesDataGridView;
        private System.Windows.Forms.TabPage _chargesTabPage;
        private System.Windows.Forms.TextBox _totalChargeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView _chargesDataGridView;
        private System.Windows.Forms.Label _settlementDateLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Label _totalPayableAmountLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _transactionTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _referenceNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _amountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _balanceColumn;
    }
}