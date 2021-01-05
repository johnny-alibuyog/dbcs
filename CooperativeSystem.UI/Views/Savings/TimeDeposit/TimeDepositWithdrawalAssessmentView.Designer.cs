namespace CooperativeSystem.UI.Views.Savings.TimeDeposit
{
    partial class TimeDepositWithdrawalAssessmentView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this._cancelButton = new System.Windows.Forms.Button();
            this._acceptButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._totalWithdrawAmountTextBox = new System.Windows.Forms.TextBox();
            this._timeDepositsToAvailDataGridView = new System.Windows.Forms.DataGridView();
            this._removeButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._timeDepositDataGridView = new System.Windows.Forms.DataGridView();
            this._addButton = new System.Windows.Forms.Button();
            this._assessmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._assessmentsToWithdrawBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.maturityDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.principalAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.withdrawAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maturityDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.principalAmountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interestDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.withdrawAmountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._timeDepositsToAvailDataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._timeDepositDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._assessmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._assessmentsToWithdrawBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._cancelButton.Location = new System.Drawing.Point(505, 327);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 8;
            this._cancelButton.Text = "&Cancel";
            this._cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _acceptButton
            // 
            this._acceptButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._acceptButton.Location = new System.Drawing.Point(424, 328);
            this._acceptButton.Name = "_acceptButton";
            this._acceptButton.Size = new System.Drawing.Size(75, 23);
            this._acceptButton.TabIndex = 7;
            this._acceptButton.Text = "&Accept";
            this._acceptButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._acceptButton.UseVisualStyleBackColor = true;
            this._acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 353);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(592, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._totalWithdrawAmountTextBox);
            this.groupBox4.Controls.Add(this._timeDepositsToAvailDataGridView);
            this.groupBox4.Controls.Add(this._removeButton);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(12, 157);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(568, 165);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Withdraw";
            // 
            // _totalWithdrawAmountTextBox
            // 
            this._totalWithdrawAmountTextBox.Location = new System.Drawing.Point(381, 138);
            this._totalWithdrawAmountTextBox.Name = "_totalWithdrawAmountTextBox";
            this._totalWithdrawAmountTextBox.ReadOnly = true;
            this._totalWithdrawAmountTextBox.Size = new System.Drawing.Size(100, 21);
            this._totalWithdrawAmountTextBox.TabIndex = 5;
            this._totalWithdrawAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _timeDepositsToAvailDataGridView
            // 
            this._timeDepositsToAvailDataGridView.AllowUserToAddRows = false;
            this._timeDepositsToAvailDataGridView.AllowUserToDeleteRows = false;
            this._timeDepositsToAvailDataGridView.AutoGenerateColumns = false;
            this._timeDepositsToAvailDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._timeDepositsToAvailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._timeDepositsToAvailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maturityDateDataGridViewTextBoxColumn1,
            this.principalAmountDataGridViewTextBoxColumn1,
            this.interestDataGridViewTextBoxColumn1,
            this.withdrawAmountDataGridViewTextBoxColumn1});
            this._timeDepositsToAvailDataGridView.DataSource = this._assessmentsToWithdrawBindingSource;
            this._timeDepositsToAvailDataGridView.Location = new System.Drawing.Point(6, 20);
            this._timeDepositsToAvailDataGridView.MultiSelect = false;
            this._timeDepositsToAvailDataGridView.Name = "_timeDepositsToAvailDataGridView";
            this._timeDepositsToAvailDataGridView.ReadOnly = true;
            this._timeDepositsToAvailDataGridView.RowHeadersVisible = false;
            this._timeDepositsToAvailDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._timeDepositsToAvailDataGridView.Size = new System.Drawing.Size(475, 112);
            this._timeDepositsToAvailDataGridView.TabIndex = 4;
            this._timeDepositsToAvailDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TimeDepositsToAvailDataGridView_CellContentDoubleClick);
            // 
            // _removeButton
            // 
            this._removeButton.Location = new System.Drawing.Point(487, 20);
            this._removeButton.Name = "_removeButton";
            this._removeButton.Size = new System.Drawing.Size(75, 23);
            this._removeButton.TabIndex = 3;
            this._removeButton.Text = "&Remove";
            this._removeButton.UseVisualStyleBackColor = true;
            this._removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Total Withdraw Ammount:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._timeDepositDataGridView);
            this.groupBox3.Controls.Add(this._addButton);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(568, 139);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Deposits";
            // 
            // _timeDepositDataGridView
            // 
            this._timeDepositDataGridView.AllowUserToAddRows = false;
            this._timeDepositDataGridView.AllowUserToDeleteRows = false;
            this._timeDepositDataGridView.AutoGenerateColumns = false;
            this._timeDepositDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._timeDepositDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._timeDepositDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maturityDateDataGridViewTextBoxColumn,
            this.principalAmountDataGridViewTextBoxColumn,
            this.interestDataGridViewTextBoxColumn,
            this.withdrawAmountDataGridViewTextBoxColumn});
            this._timeDepositDataGridView.DataSource = this._assessmentsBindingSource;
            this._timeDepositDataGridView.Location = new System.Drawing.Point(6, 20);
            this._timeDepositDataGridView.MultiSelect = false;
            this._timeDepositDataGridView.Name = "_timeDepositDataGridView";
            this._timeDepositDataGridView.ReadOnly = true;
            this._timeDepositDataGridView.RowHeadersVisible = false;
            this._timeDepositDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._timeDepositDataGridView.Size = new System.Drawing.Size(475, 112);
            this._timeDepositDataGridView.TabIndex = 1;
            this._timeDepositDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TimeDepositDataGridView_CellContentDoubleClick);
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(487, 20);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(75, 23);
            this._addButton.TabIndex = 0;
            this._addButton.Text = "&Add";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // _assessmentsBindingSource
            // 
            this._assessmentsBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Savings.TimeDeposit.TimeDepositWithdrawalAssessmentModel);
            // 
            // _assessmentsToWithdrawBindingSource
            // 
            this._assessmentsToWithdrawBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Savings.TimeDeposit.TimeDepositWithdrawalAssessmentModel);
            // 
            // maturityDateDataGridViewTextBoxColumn
            // 
            this.maturityDateDataGridViewTextBoxColumn.DataPropertyName = "MaturityDate";
            dataGridViewCellStyle13.Format = "d";
            this.maturityDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.maturityDateDataGridViewTextBoxColumn.HeaderText = "Maturity Date";
            this.maturityDateDataGridViewTextBoxColumn.Name = "maturityDateDataGridViewTextBoxColumn";
            this.maturityDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // principalAmountDataGridViewTextBoxColumn
            // 
            this.principalAmountDataGridViewTextBoxColumn.DataPropertyName = "PrincipalAmount";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            this.principalAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.principalAmountDataGridViewTextBoxColumn.HeaderText = "Principal Amount";
            this.principalAmountDataGridViewTextBoxColumn.Name = "principalAmountDataGridViewTextBoxColumn";
            this.principalAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // interestDataGridViewTextBoxColumn
            // 
            this.interestDataGridViewTextBoxColumn.DataPropertyName = "Interest";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N2";
            this.interestDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.interestDataGridViewTextBoxColumn.HeaderText = "Interest";
            this.interestDataGridViewTextBoxColumn.Name = "interestDataGridViewTextBoxColumn";
            this.interestDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // withdrawAmountDataGridViewTextBoxColumn
            // 
            this.withdrawAmountDataGridViewTextBoxColumn.DataPropertyName = "WithdrawAmount";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N2";
            this.withdrawAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.withdrawAmountDataGridViewTextBoxColumn.HeaderText = "Withdraw Amount";
            this.withdrawAmountDataGridViewTextBoxColumn.Name = "withdrawAmountDataGridViewTextBoxColumn";
            this.withdrawAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // maturityDateDataGridViewTextBoxColumn1
            // 
            this.maturityDateDataGridViewTextBoxColumn1.DataPropertyName = "MaturityDate";
            dataGridViewCellStyle9.Format = "d";
            this.maturityDateDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            this.maturityDateDataGridViewTextBoxColumn1.HeaderText = "Maturity Date";
            this.maturityDateDataGridViewTextBoxColumn1.Name = "maturityDateDataGridViewTextBoxColumn1";
            this.maturityDateDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // principalAmountDataGridViewTextBoxColumn1
            // 
            this.principalAmountDataGridViewTextBoxColumn1.DataPropertyName = "PrincipalAmount";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.principalAmountDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle10;
            this.principalAmountDataGridViewTextBoxColumn1.HeaderText = "Principal Amount";
            this.principalAmountDataGridViewTextBoxColumn1.Name = "principalAmountDataGridViewTextBoxColumn1";
            this.principalAmountDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // interestDataGridViewTextBoxColumn1
            // 
            this.interestDataGridViewTextBoxColumn1.DataPropertyName = "Interest";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.interestDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle11;
            this.interestDataGridViewTextBoxColumn1.HeaderText = "Interest";
            this.interestDataGridViewTextBoxColumn1.Name = "interestDataGridViewTextBoxColumn1";
            this.interestDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // withdrawAmountDataGridViewTextBoxColumn1
            // 
            this.withdrawAmountDataGridViewTextBoxColumn1.DataPropertyName = "WithdrawAmount";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            this.withdrawAmountDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle12;
            this.withdrawAmountDataGridViewTextBoxColumn1.HeaderText = "Withdraw Amount";
            this.withdrawAmountDataGridViewTextBoxColumn1.Name = "withdrawAmountDataGridViewTextBoxColumn1";
            this.withdrawAmountDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // TimeDepositWithdrawalAssessmentView
            // 
            this.AcceptButton = this._acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(592, 375);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._acceptButton);
            this.Name = "TimeDepositWithdrawalAssessmentView";
            this.Text = "Time Deposit Widrawal Assessment";
            this.Shown += new System.EventHandler(this.TimeDepositWithdrawalAssessmentView_Shown);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._timeDepositsToAvailDataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._timeDepositDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._assessmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._assessmentsToWithdrawBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button _cancelButton;
        protected System.Windows.Forms.Button _acceptButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button _removeButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView _timeDepositDataGridView;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.DataGridView _timeDepositsToAvailDataGridView;
        private System.Windows.Forms.TextBox _totalWithdrawAmountTextBox;
        private System.Windows.Forms.BindingSource _assessmentsToWithdrawBindingSource;
        private System.Windows.Forms.BindingSource _assessmentsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn maturityDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn principalAmountDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn interestDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn withdrawAmountDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn maturityDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn principalAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn interestDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn withdrawAmountDataGridViewTextBoxColumn;
    }
}