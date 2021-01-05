namespace CooperativeSystem.UI.Views.Plans.CollegeInsurancePlan
{
    partial class CIPPaymentView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this._paymentAmountTextBox = new System.Windows.Forms.TextBox();
            this._payablePlansToPayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._removeButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this._totalPaymentAmountTextBox = new System.Windows.Forms.TextBox();
            this._cipsToPayDataGridView = new System.Windows.Forms.DataGridView();
            this.userNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unpaidAmortizationDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amortizationDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._allButton = new System.Windows.Forms.Button();
            this._cipsDataGridView = new System.Windows.Forms.DataGridView();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unpaidAmortizationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amortizationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._payablePlansBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._addButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._payablePlansToPayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._cipsToPayDataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._cipsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._payablePlansBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(684, 371);
            // 
            // _acceptButton
            // 
            this._acceptButton.Location = new System.Drawing.Point(603, 371);
            this._acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Size = new System.Drawing.Size(747, 359);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this._paymentAmountTextBox);
            this.groupBox4.Controls.Add(this._removeButton);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this._totalPaymentAmountTextBox);
            this.groupBox4.Controls.Add(this._cipsToPayDataGridView);
            this.groupBox4.Location = new System.Drawing.Point(6, 165);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(735, 188);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Payment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(441, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Payment Ammount:";
            // 
            // _paymentAmountTextBox
            // 
            this._paymentAmountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._payablePlansToPayBindingSource, "PaymentAmount", true));
            this._paymentAmountTextBox.Location = new System.Drawing.Point(548, 134);
            this._paymentAmountTextBox.Name = "_paymentAmountTextBox";
            this._paymentAmountTextBox.Size = new System.Drawing.Size(100, 21);
            this._paymentAmountTextBox.TabIndex = 5;
            this._paymentAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._paymentAmountTextBox.TextChanged += new System.EventHandler(this.PaymentAmountTextBox_TextChanged);
            // 
            // _payablePlansToPayBindingSource
            // 
            this._payablePlansToPayBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan.Calculators.PayablePlanDetails);
            this._payablePlansToPayBindingSource.CurrentItemChanged += new System.EventHandler(this.PayablePlansToPayBindingSource_CurrentItemChanged);
            this._payablePlansToPayBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.PayablePlansToPayBindingSource_ListChanged);
            // 
            // _removeButton
            // 
            this._removeButton.Location = new System.Drawing.Point(654, 20);
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
            this.label6.Location = new System.Drawing.Point(414, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Total Payment Ammount:";
            // 
            // _totalPaymentAmountTextBox
            // 
            this._totalPaymentAmountTextBox.Location = new System.Drawing.Point(548, 161);
            this._totalPaymentAmountTextBox.Name = "_totalPaymentAmountTextBox";
            this._totalPaymentAmountTextBox.ReadOnly = true;
            this._totalPaymentAmountTextBox.Size = new System.Drawing.Size(100, 21);
            this._totalPaymentAmountTextBox.TabIndex = 1;
            this._totalPaymentAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _cipsToPayDataGridView
            // 
            this._cipsToPayDataGridView.AllowUserToAddRows = false;
            this._cipsToPayDataGridView.AllowUserToDeleteRows = false;
            this._cipsToPayDataGridView.AutoGenerateColumns = false;
            this._cipsToPayDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._cipsToPayDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._cipsToPayDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.unpaidAmortizationDataGridViewTextBoxColumn1,
            this.amortizationDataGridViewTextBoxColumn1,
            this.paymentAmountDataGridViewTextBoxColumn});
            this._cipsToPayDataGridView.DataSource = this._payablePlansToPayBindingSource;
            this._cipsToPayDataGridView.Location = new System.Drawing.Point(7, 20);
            this._cipsToPayDataGridView.Name = "_cipsToPayDataGridView";
            this._cipsToPayDataGridView.RowHeadersVisible = false;
            this._cipsToPayDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._cipsToPayDataGridView.Size = new System.Drawing.Size(641, 108);
            this._cipsToPayDataGridView.TabIndex = 0;
            // 
            // userNameDataGridViewTextBoxColumn1
            // 
            this.userNameDataGridViewTextBoxColumn1.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn1.HeaderText = "User Name";
            this.userNameDataGridViewTextBoxColumn1.Name = "userNameDataGridViewTextBoxColumn1";
            this.userNameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PaymentMode";
            this.dataGridViewTextBoxColumn1.HeaderText = "Payment Mode";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // unpaidAmortizationDataGridViewTextBoxColumn1
            // 
            this.unpaidAmortizationDataGridViewTextBoxColumn1.DataPropertyName = "UnpaidAmortization";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.unpaidAmortizationDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.unpaidAmortizationDataGridViewTextBoxColumn1.HeaderText = "Unpaid Amortization";
            this.unpaidAmortizationDataGridViewTextBoxColumn1.Name = "unpaidAmortizationDataGridViewTextBoxColumn1";
            this.unpaidAmortizationDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // amortizationDataGridViewTextBoxColumn1
            // 
            this.amortizationDataGridViewTextBoxColumn1.DataPropertyName = "Amortization";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.amortizationDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.amortizationDataGridViewTextBoxColumn1.HeaderText = "Amortization";
            this.amortizationDataGridViewTextBoxColumn1.Name = "amortizationDataGridViewTextBoxColumn1";
            this.amortizationDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // paymentAmountDataGridViewTextBoxColumn
            // 
            this.paymentAmountDataGridViewTextBoxColumn.DataPropertyName = "PaymentAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.paymentAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.paymentAmountDataGridViewTextBoxColumn.HeaderText = "Payment Amount";
            this.paymentAmountDataGridViewTextBoxColumn.Name = "paymentAmountDataGridViewTextBoxColumn";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._allButton);
            this.groupBox3.Controls.Add(this._cipsDataGridView);
            this.groupBox3.Controls.Add(this._addButton);
            this.groupBox3.Location = new System.Drawing.Point(6, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(735, 139);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Plans";
            // 
            // _allButton
            // 
            this._allButton.Location = new System.Drawing.Point(654, 20);
            this._allButton.Name = "_allButton";
            this._allButton.Size = new System.Drawing.Size(75, 23);
            this._allButton.TabIndex = 2;
            this._allButton.Text = "&All";
            this._allButton.UseVisualStyleBackColor = true;
            this._allButton.Click += new System.EventHandler(this.AddAllButton_Click);
            // 
            // _cipsDataGridView
            // 
            this._cipsDataGridView.AllowUserToAddRows = false;
            this._cipsDataGridView.AllowUserToDeleteRows = false;
            this._cipsDataGridView.AutoGenerateColumns = false;
            this._cipsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._cipsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._cipsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.PaymentMode,
            this.unpaidAmortizationDataGridViewTextBoxColumn,
            this.amortizationDataGridViewTextBoxColumn});
            this._cipsDataGridView.DataSource = this._payablePlansBindingSource;
            this._cipsDataGridView.Location = new System.Drawing.Point(7, 20);
            this._cipsDataGridView.Name = "_cipsDataGridView";
            this._cipsDataGridView.ReadOnly = true;
            this._cipsDataGridView.RowHeadersVisible = false;
            this._cipsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._cipsDataGridView.Size = new System.Drawing.Size(641, 112);
            this._cipsDataGridView.TabIndex = 1;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "User Name";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // PaymentMode
            // 
            this.PaymentMode.DataPropertyName = "PaymentMode";
            this.PaymentMode.HeaderText = "Payment Mode";
            this.PaymentMode.Name = "PaymentMode";
            this.PaymentMode.ReadOnly = true;
            // 
            // unpaidAmortizationDataGridViewTextBoxColumn
            // 
            this.unpaidAmortizationDataGridViewTextBoxColumn.DataPropertyName = "UnpaidAmortization";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.unpaidAmortizationDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.unpaidAmortizationDataGridViewTextBoxColumn.HeaderText = "Unpaid Amortization";
            this.unpaidAmortizationDataGridViewTextBoxColumn.Name = "unpaidAmortizationDataGridViewTextBoxColumn";
            this.unpaidAmortizationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amortizationDataGridViewTextBoxColumn
            // 
            this.amortizationDataGridViewTextBoxColumn.DataPropertyName = "Amortization";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.amortizationDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.amortizationDataGridViewTextBoxColumn.HeaderText = "Amortization";
            this.amortizationDataGridViewTextBoxColumn.Name = "amortizationDataGridViewTextBoxColumn";
            this.amortizationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _payablePlansBindingSource
            // 
            this._payablePlansBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan.Calculators.PayablePlanDetails);
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(654, 49);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(75, 23);
            this._addButton.TabIndex = 0;
            this._addButton.Text = "A&dd";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CIPPaymentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 419);
            this.Name = "CIPPaymentView";
            this.Text = "College Insurance Plan Payment";
            this.Shown += new System.EventHandler(this.CIPPaymentView_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._payablePlansToPayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._cipsToPayDataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._cipsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._payablePlansBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button _removeButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _totalPaymentAmountTextBox;
        private System.Windows.Forms.DataGridView _cipsToPayDataGridView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView _cipsDataGridView;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.BindingSource _payablePlansBindingSource;
        private System.Windows.Forms.BindingSource _payablePlansToPayBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn unpaidAmortizationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amortizationDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _paymentAmountTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn unpaidAmortizationDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn amortizationDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button _allButton;

    }
}