namespace CooperativeSystem.UI.Views.Plans.CollegeInsurancePlan
{
    partial class CIPAdjustmentView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._changeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._amountTextBox = new System.Windows.Forms.TextBox();
            this._cipAdjustmentItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this._totalAmountTextBox = new System.Windows.Forms.TextBox();
            this._cipsAdjustmentsDataGridView = new System.Windows.Forms.DataGridView();
            this._statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._cancelButton = new System.Windows.Forms.Button();
            this._acceptButton = new System.Windows.Forms.Button();
            this._userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._cipAdjustmentItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._cipsAdjustmentsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._changeButton);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this._amountTextBox);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this._totalAmountTextBox);
            this.groupBox4.Controls.Add(this._cipsAdjustmentsDataGridView);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(420, 264);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            // 
            // _changeButton
            // 
            this._changeButton.Location = new System.Drawing.Point(361, 208);
            this._changeButton.Name = "_changeButton";
            this._changeButton.Size = new System.Drawing.Size(53, 23);
            this._changeButton.TabIndex = 25;
            this._changeButton.TabStop = false;
            this._changeButton.Text = "Ch&ange";
            this._changeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._changeButton.UseVisualStyleBackColor = true;
            this._changeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ammount:";
            // 
            // _amountTextBox
            // 
            this._amountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._cipAdjustmentItemBindingSource, "Amount", true));
            this._amountTextBox.Location = new System.Drawing.Point(255, 210);
            this._amountTextBox.Name = "_amountTextBox";
            this._amountTextBox.Size = new System.Drawing.Size(100, 21);
            this._amountTextBox.TabIndex = 5;
            this._amountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _cipAdjustmentItemBindingSource
            // 
            this._cipAdjustmentItemBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan.CIPAdjustmentItem);
            this._cipAdjustmentItemBindingSource.CurrentItemChanged += new System.EventHandler(this.CIPAdjustmentItemBindingSource_CurrentItemChanged);
            this._cipAdjustmentItemBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.CIPAdjustmentItemBindingSource_ListChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(166, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Total Ammount:";
            // 
            // _totalAmountTextBox
            // 
            this._totalAmountTextBox.Location = new System.Drawing.Point(255, 237);
            this._totalAmountTextBox.Name = "_totalAmountTextBox";
            this._totalAmountTextBox.ReadOnly = true;
            this._totalAmountTextBox.Size = new System.Drawing.Size(100, 21);
            this._totalAmountTextBox.TabIndex = 1;
            this._totalAmountTextBox.TabStop = false;
            this._totalAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _cipsAdjustmentsDataGridView
            // 
            this._cipsAdjustmentsDataGridView.AllowUserToAddRows = false;
            this._cipsAdjustmentsDataGridView.AllowUserToDeleteRows = false;
            this._cipsAdjustmentsDataGridView.AutoGenerateColumns = false;
            this._cipsAdjustmentsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._cipsAdjustmentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._cipsAdjustmentsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._userNameDataGridViewTextBoxColumn,
            this._amountDataGridViewTextBoxColumn});
            this._cipsAdjustmentsDataGridView.DataSource = this._cipAdjustmentItemBindingSource;
            this._cipsAdjustmentsDataGridView.Location = new System.Drawing.Point(6, 20);
            this._cipsAdjustmentsDataGridView.Name = "_cipsAdjustmentsDataGridView";
            this._cipsAdjustmentsDataGridView.RowHeadersVisible = false;
            this._cipsAdjustmentsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._cipsAdjustmentsDataGridView.Size = new System.Drawing.Size(408, 184);
            this._cipsAdjustmentsDataGridView.TabIndex = 0;
            this._cipsAdjustmentsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CIPsAdjustmentsDataGridView_CellClick);
            this._cipsAdjustmentsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._cipsAdjustmentsDataGridView_CellContentClick);
            // 
            // _statusStrip1
            // 
            this._statusStrip1.Location = new System.Drawing.Point(0, 308);
            this._statusStrip1.Name = "_statusStrip1";
            this._statusStrip1.Size = new System.Drawing.Size(442, 22);
            this._statusStrip1.TabIndex = 23;
            this._statusStrip1.Text = "statusStrip1";
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._cancelButton.Location = new System.Drawing.Point(357, 282);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 25;
            this._cancelButton.TabStop = false;
            this._cancelButton.Text = "&Cancel";
            this._cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _acceptButton
            // 
            this._acceptButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._acceptButton.Location = new System.Drawing.Point(276, 282);
            this._acceptButton.Name = "_acceptButton";
            this._acceptButton.Size = new System.Drawing.Size(75, 23);
            this._acceptButton.TabIndex = 24;
            this._acceptButton.TabStop = false;
            this._acceptButton.Text = "&Accept";
            this._acceptButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._acceptButton.UseVisualStyleBackColor = true;
            this._acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // _userNameDataGridViewTextBoxColumn
            // 
            this._userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this._userNameDataGridViewTextBoxColumn.HeaderText = "User Name";
            this._userNameDataGridViewTextBoxColumn.Name = "_userNameDataGridViewTextBoxColumn";
            // 
            // _amountDataGridViewTextBoxColumn
            // 
            this._amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this._amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this._amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this._amountDataGridViewTextBoxColumn.Name = "_amountDataGridViewTextBoxColumn";
            // 
            // CIPAdjustmentView
            // 
            this.AcceptButton = this._changeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(442, 330);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._acceptButton);
            this.Controls.Add(this._statusStrip1);
            this.Controls.Add(this.groupBox4);
            this.Name = "CIPAdjustmentView";
            this.Text = "College Insurance Plan Adjustment";
            this.Load += new System.EventHandler(this.CIPAdjustmentView_Load);
            this.Shown += new System.EventHandler(this.CIPAdjustmentView_Shown);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._cipAdjustmentItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._cipsAdjustmentsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _amountTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _totalAmountTextBox;
        private System.Windows.Forms.DataGridView _cipsAdjustmentsDataGridView;
        private System.Windows.Forms.BindingSource _cipAdjustmentItemBindingSource;
        private System.Windows.Forms.StatusStrip _statusStrip1;
        protected System.Windows.Forms.Button _cancelButton;
        protected System.Windows.Forms.Button _acceptButton;
        protected System.Windows.Forms.Button _changeButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn _userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _amountDataGridViewTextBoxColumn;

    }
}