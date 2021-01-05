namespace CooperativeSystem.UI.Views.Savings.SavingsDeposit
{
    partial class SavingsDepositSummaryView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this._totalShareTextBox = new System.Windows.Forms.TextBox();
            this._detailsDataGridView = new System.Windows.Forms.DataGridView();
            this.dateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiptVoucherColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._recomputBalanceButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._detailsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._recomputBalanceButton);
            this.groupBox2.Controls.Add(this._detailsDataGridView);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this._totalShareTextBox);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(499, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Total Savings:";
            // 
            // _totalShareTextBox
            // 
            this._totalShareTextBox.Location = new System.Drawing.Point(580, 244);
            this._totalShareTextBox.Name = "_totalShareTextBox";
            this._totalShareTextBox.ReadOnly = true;
            this._totalShareTextBox.Size = new System.Drawing.Size(144, 21);
            this._totalShareTextBox.TabIndex = 7;
            this._totalShareTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _detailsDataGridView
            // 
            this._detailsDataGridView.AllowUserToAddRows = false;
            this._detailsDataGridView.AllowUserToDeleteRows = false;
            this._detailsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._detailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._detailsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateColumn,
            this.transactionTypeColumn,
            this.receiptVoucherColumn,
            this.amountColumn,
            this.balanceColumn});
            this._detailsDataGridView.Location = new System.Drawing.Point(6, 20);
            this._detailsDataGridView.MultiSelect = false;
            this._detailsDataGridView.Name = "_detailsDataGridView";
            this._detailsDataGridView.ReadOnly = true;
            this._detailsDataGridView.RowHeadersVisible = false;
            this._detailsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._detailsDataGridView.Size = new System.Drawing.Size(718, 218);
            this._detailsDataGridView.TabIndex = 9;
            // 
            // dateColumn
            // 
            this.dateColumn.DataPropertyName = "Date";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "d";
            this.dateColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.dateColumn.HeaderText = "Date";
            this.dateColumn.Name = "dateColumn";
            this.dateColumn.ReadOnly = true;
            // 
            // transactionTypeColumn
            // 
            this.transactionTypeColumn.DataPropertyName = "TransactionType";
            this.transactionTypeColumn.HeaderText = "Transaction Type";
            this.transactionTypeColumn.Name = "transactionTypeColumn";
            this.transactionTypeColumn.ReadOnly = true;
            // 
            // receiptVoucherColumn
            // 
            this.receiptVoucherColumn.DataPropertyName = "ReceiptVoucher";
            this.receiptVoucherColumn.HeaderText = "Receipt/ Voucher";
            this.receiptVoucherColumn.Name = "receiptVoucherColumn";
            this.receiptVoucherColumn.ReadOnly = true;
            // 
            // amountColumn
            // 
            this.amountColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.amountColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.amountColumn.HeaderText = "Amount";
            this.amountColumn.Name = "amountColumn";
            this.amountColumn.ReadOnly = true;
            // 
            // balanceColumn
            // 
            this.balanceColumn.DataPropertyName = "Balance";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.balanceColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.balanceColumn.HeaderText = "Balance";
            this.balanceColumn.Name = "balanceColumn";
            this.balanceColumn.ReadOnly = true;
            // 
            // _recomputBalanceButton
            // 
            this._recomputBalanceButton.Location = new System.Drawing.Point(7, 245);
            this._recomputBalanceButton.Name = "_recomputBalanceButton";
            this._recomputBalanceButton.Size = new System.Drawing.Size(105, 23);
            this._recomputBalanceButton.TabIndex = 10;
            this._recomputBalanceButton.Text = "Recomput Balance";
            this._recomputBalanceButton.UseVisualStyleBackColor = true;
            this._recomputBalanceButton.Click += new System.EventHandler(this.RecomputBalanceButton_Click);
            // 
            // SavingsDepositSummaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "SavingsDepositSummaryView";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._detailsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _totalShareTextBox;
        private System.Windows.Forms.DataGridView _detailsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptVoucherColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceColumn;
        private System.Windows.Forms.Button _recomputBalanceButton;
    }
}
