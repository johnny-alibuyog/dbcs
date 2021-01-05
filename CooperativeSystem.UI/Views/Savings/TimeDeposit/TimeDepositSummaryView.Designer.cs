namespace CooperativeSystem.UI.Views.Savings.TimeDeposit
{
    partial class TimeDepositSummaryView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._detailsDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._maturityDateLabel = new System.Windows.Forms.Label();
            this._disbursementDateLabel = new System.Windows.Forms.Label();
            this._disbursedAmountLabel = new System.Windows.Forms.Label();
            this._interestLabel = new System.Windows.Forms.Label();
            this._interestRateLabel = new System.Windows.Forms.Label();
            this._termsLabel = new System.Windows.Forms.Label();
            this._depoistDateLabel = new System.Windows.Forms.Label();
            this._depoistAmountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depositDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depositAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._detailsDataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._detailsDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(6, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 245);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deposits:";
            // 
            // _detailsDataGridView
            // 
            this._detailsDataGridView.AllowUserToAddRows = false;
            this._detailsDataGridView.AllowUserToDeleteRows = false;
            this._detailsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._detailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._detailsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status,
            this.depositDateColumn,
            this.depositAmountColumn,
            this.Balance});
            this._detailsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._detailsDataGridView.Location = new System.Drawing.Point(3, 17);
            this._detailsDataGridView.MultiSelect = false;
            this._detailsDataGridView.Name = "_detailsDataGridView";
            this._detailsDataGridView.ReadOnly = true;
            this._detailsDataGridView.RowHeadersVisible = false;
            this._detailsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._detailsDataGridView.Size = new System.Drawing.Size(417, 225);
            this._detailsDataGridView.TabIndex = 11;
            this._detailsDataGridView.SelectionChanged += new System.EventHandler(this.DetailsDataGridView_SelectionChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._maturityDateLabel);
            this.groupBox3.Controls.Add(this._disbursementDateLabel);
            this.groupBox3.Controls.Add(this._disbursedAmountLabel);
            this.groupBox3.Controls.Add(this._interestLabel);
            this.groupBox3.Controls.Add(this._interestRateLabel);
            this.groupBox3.Controls.Add(this._termsLabel);
            this.groupBox3.Controls.Add(this._depoistDateLabel);
            this.groupBox3.Controls.Add(this._depoistAmountLabel);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(435, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(289, 245);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Details";
            // 
            // _maturityDateLabel
            // 
            this._maturityDateLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._maturityDateLabel.Location = new System.Drawing.Point(165, 87);
            this._maturityDateLabel.Name = "_maturityDateLabel";
            this._maturityDateLabel.Size = new System.Drawing.Size(73, 14);
            this._maturityDateLabel.TabIndex = 34;
            this._maturityDateLabel.Text = "00/00/0000";
            this._maturityDateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _disbursementDateLabel
            // 
            this._disbursementDateLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._disbursementDateLabel.Location = new System.Drawing.Point(165, 101);
            this._disbursementDateLabel.Name = "_disbursementDateLabel";
            this._disbursementDateLabel.Size = new System.Drawing.Size(73, 14);
            this._disbursementDateLabel.TabIndex = 33;
            this._disbursementDateLabel.Text = "00/00/0000";
            this._disbursementDateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _disbursedAmountLabel
            // 
            this._disbursedAmountLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._disbursedAmountLabel.Location = new System.Drawing.Point(165, 115);
            this._disbursedAmountLabel.Name = "_disbursedAmountLabel";
            this._disbursedAmountLabel.Size = new System.Drawing.Size(73, 14);
            this._disbursedAmountLabel.TabIndex = 32;
            this._disbursedAmountLabel.Text = "00/00/0000";
            this._disbursedAmountLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _interestLabel
            // 
            this._interestLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._interestLabel.Location = new System.Drawing.Point(165, 73);
            this._interestLabel.Name = "_interestLabel";
            this._interestLabel.Size = new System.Drawing.Size(73, 14);
            this._interestLabel.TabIndex = 30;
            this._interestLabel.Text = "00/00/0000";
            this._interestLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _interestRateLabel
            // 
            this._interestRateLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._interestRateLabel.Location = new System.Drawing.Point(165, 59);
            this._interestRateLabel.Name = "_interestRateLabel";
            this._interestRateLabel.Size = new System.Drawing.Size(73, 14);
            this._interestRateLabel.TabIndex = 31;
            this._interestRateLabel.Text = "00/00/0000";
            this._interestRateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _termsLabel
            // 
            this._termsLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._termsLabel.Location = new System.Drawing.Point(165, 45);
            this._termsLabel.Name = "_termsLabel";
            this._termsLabel.Size = new System.Drawing.Size(73, 14);
            this._termsLabel.TabIndex = 29;
            this._termsLabel.Text = "00/00/0000";
            this._termsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _depoistDateLabel
            // 
            this._depoistDateLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._depoistDateLabel.Location = new System.Drawing.Point(165, 17);
            this._depoistDateLabel.Name = "_depoistDateLabel";
            this._depoistDateLabel.Size = new System.Drawing.Size(73, 14);
            this._depoistDateLabel.TabIndex = 28;
            this._depoistDateLabel.Text = "00/00/0000";
            this._depoistDateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _depoistAmountLabel
            // 
            this._depoistAmountLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._depoistAmountLabel.Location = new System.Drawing.Point(165, 31);
            this._depoistAmountLabel.Name = "_depoistAmountLabel";
            this._depoistAmountLabel.Size = new System.Drawing.Size(73, 14);
            this._depoistAmountLabel.TabIndex = 27;
            this._depoistAmountLabel.Text = "00/00/0000";
            this._depoistAmountLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Maturity Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Disbursement Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(45, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Disbursed Amount:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(102, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Interest:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(72, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Interest Rate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(113, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Terms:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(76, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Deposit Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Deposit Amount:";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // depositDateColumn
            // 
            this.depositDateColumn.DataPropertyName = "DepositDate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "d";
            this.depositDateColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.depositDateColumn.HeaderText = "Deposit Date";
            this.depositDateColumn.Name = "depositDateColumn";
            this.depositDateColumn.ReadOnly = true;
            // 
            // depositAmountColumn
            // 
            this.depositAmountColumn.DataPropertyName = "DepositAmount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.depositAmountColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.depositAmountColumn.HeaderText = "Amount";
            this.depositAmountColumn.Name = "depositAmountColumn";
            this.depositAmountColumn.ReadOnly = true;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Balance";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.Balance.DefaultCellStyle = dataGridViewCellStyle3;
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // TimeDepositSummaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TimeDepositSummaryView";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._detailsDataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView _detailsDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _maturityDateLabel;
        private System.Windows.Forms.Label _disbursementDateLabel;
        private System.Windows.Forms.Label _disbursedAmountLabel;
        private System.Windows.Forms.Label _interestLabel;
        private System.Windows.Forms.Label _interestRateLabel;
        private System.Windows.Forms.Label _termsLabel;
        private System.Windows.Forms.Label _depoistDateLabel;
        private System.Windows.Forms.Label _depoistAmountLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn depositDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn depositAmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;

    }
}
