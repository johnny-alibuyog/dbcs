namespace CooperativeSystem.UI.Views.SpecialFunds.TulunganFund
{
    partial class TulunganFundSummaryView
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
            this.label1 = new System.Windows.Forms.Label();
            this._totalTextBox = new System.Windows.Forms.TextBox();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._transactionTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._receiptVoucherDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._totalTextBox);
            this.groupBox1.Controls.Add(this._dataGridView);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Total:";
            // 
            // _totalTextBox
            // 
            this._totalTextBox.Location = new System.Drawing.Point(544, 244);
            this._totalTextBox.Name = "_totalTextBox";
            this._totalTextBox.ReadOnly = true;
            this._totalTextBox.Size = new System.Drawing.Size(180, 21);
            this._totalTextBox.TabIndex = 7;
            this._totalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToDeleteRows = false;
            this._dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._dateDataGridViewTextBoxColumn,
            this._transactionTypeDataGridViewTextBoxColumn,
            this._receiptVoucherDataGridViewTextBoxColumn,
            this._amountDataGridViewTextBoxColumn});
            this._dataGridView.Location = new System.Drawing.Point(6, 20);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.ReadOnly = true;
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridView.Size = new System.Drawing.Size(718, 218);
            this._dataGridView.TabIndex = 6;
            // 
            // _dateDataGridViewTextBoxColumn
            // 
            this._dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this._dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this._dateDataGridViewTextBoxColumn.Name = "_dateDataGridViewTextBoxColumn";
            this._dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _transactionTypeDataGridViewTextBoxColumn
            // 
            this._transactionTypeDataGridViewTextBoxColumn.DataPropertyName = "TransactionType";
            this._transactionTypeDataGridViewTextBoxColumn.HeaderText = "Transaction Type";
            this._transactionTypeDataGridViewTextBoxColumn.Name = "_transactionTypeDataGridViewTextBoxColumn";
            this._transactionTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _receiptVoucherDataGridViewTextBoxColumn
            // 
            this._receiptVoucherDataGridViewTextBoxColumn.DataPropertyName = "ReceiptVoucher";
            this._receiptVoucherDataGridViewTextBoxColumn.HeaderText = "Receipt/ Voucher";
            this._receiptVoucherDataGridViewTextBoxColumn.Name = "_receiptVoucherDataGridViewTextBoxColumn";
            this._receiptVoucherDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _amountDataGridViewTextBoxColumn
            // 
            this._amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this._amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this._amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this._amountDataGridViewTextBoxColumn.Name = "_amountDataGridViewTextBoxColumn";
            this._amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TulunganFundSummaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TulunganFundSummaryView";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _totalTextBox;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _transactionTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _receiptVoucherDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _amountDataGridViewTextBoxColumn;
    }
}
