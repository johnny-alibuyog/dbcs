namespace CooperativeSystem.UI.Views.Savings.CapitalShares
{
    partial class CapitalShareSummaryView
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
            this._totalShareTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._transactionsDataGridView = new System.Windows.Forms.DataGridView();
            this._recomputBalanceButton = new System.Windows.Forms.Button();
            this.dateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiptVoucherColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._transactionsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._recomputBalanceButton);
            this.groupBox2.Controls.Add(this._transactionsDataGridView);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this._totalShareTextBox);
            // 
            // _totalShareTextBox
            // 
            this._totalShareTextBox.Location = new System.Drawing.Point(580, 244);
            this._totalShareTextBox.Name = "_totalShareTextBox";
            this._totalShareTextBox.ReadOnly = true;
            this._totalShareTextBox.Size = new System.Drawing.Size(144, 21);
            this._totalShareTextBox.TabIndex = 1;
            this._totalShareTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(508, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Share:";
            // 
            // _transactionsDataGridView
            // 
            this._transactionsDataGridView.AllowUserToAddRows = false;
            this._transactionsDataGridView.AllowUserToDeleteRows = false;
            this._transactionsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._transactionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._transactionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateColumn,
            this.transactionTypeColumn,
            this.receiptVoucherColumn,
            this.amountColumn,
            this.balanceColumn});
            this._transactionsDataGridView.Location = new System.Drawing.Point(6, 20);
            this._transactionsDataGridView.MultiSelect = false;
            this._transactionsDataGridView.Name = "_transactionsDataGridView";
            this._transactionsDataGridView.ReadOnly = true;
            this._transactionsDataGridView.RowHeadersVisible = false;
            this._transactionsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._transactionsDataGridView.Size = new System.Drawing.Size(718, 218);
            this._transactionsDataGridView.TabIndex = 6;
            // 
            // _recomputBalanceButton
            // 
            this._recomputBalanceButton.Location = new System.Drawing.Point(6, 244);
            this._recomputBalanceButton.Name = "_recomputBalanceButton";
            this._recomputBalanceButton.Size = new System.Drawing.Size(105, 23);
            this._recomputBalanceButton.TabIndex = 11;
            this._recomputBalanceButton.Text = "Recomput Balance";
            this._recomputBalanceButton.UseVisualStyleBackColor = true;
            this._recomputBalanceButton.Click += new System.EventHandler(this.RecomputBalanceButton_Click);
            // 
            // dateColumn
            // 
            this.dateColumn.DataPropertyName = "Date";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "d";
            this.dateColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.dateColumn.HeaderText = "Date";
            this.dateColumn.Name = "dateColumn";
            this.dateColumn.ReadOnly = true;
            this.dateColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.amountColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.amountColumn.HeaderText = "Amount";
            this.amountColumn.Name = "amountColumn";
            this.amountColumn.ReadOnly = true;
            // 
            // balanceColumn
            // 
            this.balanceColumn.DataPropertyName = "Balance";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.balanceColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.balanceColumn.HeaderText = "Balance";
            this.balanceColumn.Name = "balanceColumn";
            this.balanceColumn.ReadOnly = true;
            // 
            // CapitalShareSummaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CapitalShareSummaryView";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._transactionsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _totalShareTextBox;
        private System.Windows.Forms.DataGridView _transactionsDataGridView;
        private System.Windows.Forms.Button _recomputBalanceButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptVoucherColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceColumn;
    }
}
