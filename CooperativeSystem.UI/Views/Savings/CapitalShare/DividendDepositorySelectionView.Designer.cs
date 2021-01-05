namespace CooperativeSystem.UI.Views.Savings.CapitalShare
{
    partial class DividendDepositorySelectionView
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
            this._dividendComputationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._saveButton = new System.Windows.Forms.Button();
            this._closeButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this.memberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dividendDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this._changeButton = new System.Windows.Forms.Button();
            this._depositoryComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._memberTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this._yearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._selectYearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._dividendComputationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._yearNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // _dividendComputationBindingSource
            // 
            this._dividendComputationBindingSource.DataSource = typeof(CooperativeSystem.Service.Models.DividendComputation);
            this._dividendComputationBindingSource.CurrentChanged += new System.EventHandler(this.DividendComputationBindingSource_CurrentChanged);
            // 
            // _saveButton
            // 
            this._saveButton.Enabled = false;
            this._saveButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._saveButton.Location = new System.Drawing.Point(345, 364);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(75, 23);
            this._saveButton.TabIndex = 4;
            this._saveButton.TabStop = false;
            this._saveButton.Text = "&Save";
            this._saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(426, 364);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 5;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 390);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(513, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToDeleteRows = false;
            this._dataGridView.AutoGenerateColumns = false;
            this._dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.memberDataGridViewTextBoxColumn,
            this.serviceDataGridViewTextBoxColumn,
            this.dividendDataGridViewTextBoxColumn});
            this._dataGridView.DataSource = this._dividendComputationBindingSource;
            this._dataGridView.Location = new System.Drawing.Point(12, 150);
            this._dataGridView.MultiSelect = false;
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.ReadOnly = true;
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridView.Size = new System.Drawing.Size(489, 208);
            this._dataGridView.TabIndex = 2;
            this._dataGridView.TabStop = false;
            // 
            // memberDataGridViewTextBoxColumn
            // 
            this.memberDataGridViewTextBoxColumn.DataPropertyName = "Member";
            this.memberDataGridViewTextBoxColumn.HeaderText = "Member";
            this.memberDataGridViewTextBoxColumn.Name = "memberDataGridViewTextBoxColumn";
            this.memberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serviceDataGridViewTextBoxColumn
            // 
            this.serviceDataGridViewTextBoxColumn.DataPropertyName = "Service";
            this.serviceDataGridViewTextBoxColumn.HeaderText = "Depository";
            this.serviceDataGridViewTextBoxColumn.Name = "serviceDataGridViewTextBoxColumn";
            this.serviceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dividendDataGridViewTextBoxColumn
            // 
            this.dividendDataGridViewTextBoxColumn.DataPropertyName = "Dividend";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.dividendDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.dividendDataGridViewTextBoxColumn.HeaderText = "Dividend";
            this.dividendDataGridViewTextBoxColumn.Name = "dividendDataGridViewTextBoxColumn";
            this.dividendDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this._changeButton);
            this.groupBox2.Controls.Add(this._depositoryComboBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this._memberTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(489, 79);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Depository:";
            // 
            // _changeButton
            // 
            this._changeButton.Location = new System.Drawing.Point(310, 45);
            this._changeButton.Name = "_changeButton";
            this._changeButton.Size = new System.Drawing.Size(75, 23);
            this._changeButton.TabIndex = 3;
            this._changeButton.TabStop = false;
            this._changeButton.Text = "&Change";
            this._changeButton.UseVisualStyleBackColor = true;
            this._changeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // _depositoryComboBox
            // 
            this._depositoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._depositoryComboBox.FormattingEnabled = true;
            this._depositoryComboBox.Location = new System.Drawing.Point(103, 47);
            this._depositoryComboBox.Name = "_depositoryComboBox";
            this._depositoryComboBox.Size = new System.Drawing.Size(201, 21);
            this._depositoryComboBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Member:";
            // 
            // _memberTextBox
            // 
            this._memberTextBox.Location = new System.Drawing.Point(103, 20);
            this._memberTextBox.Name = "_memberTextBox";
            this._memberTextBox.ReadOnly = true;
            this._memberTextBox.Size = new System.Drawing.Size(201, 21);
            this._memberTextBox.TabIndex = 0;
            this._memberTextBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._yearNumericUpDown);
            this.groupBox1.Controls.Add(this._selectYearButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Year:";
            // 
            // _yearNumericUpDown
            // 
            this._yearNumericUpDown.Location = new System.Drawing.Point(103, 20);
            this._yearNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this._yearNumericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._yearNumericUpDown.Name = "_yearNumericUpDown";
            this._yearNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._yearNumericUpDown.Size = new System.Drawing.Size(201, 21);
            this._yearNumericUpDown.TabIndex = 1;
            this._yearNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // _selectYearButton
            // 
            this._selectYearButton.Location = new System.Drawing.Point(310, 18);
            this._selectYearButton.Name = "_selectYearButton";
            this._selectYearButton.Size = new System.Drawing.Size(75, 23);
            this._selectYearButton.TabIndex = 0;
            this._selectYearButton.TabStop = false;
            this._selectYearButton.Text = "&Select Year";
            this._selectYearButton.UseVisualStyleBackColor = true;
            this._selectYearButton.Click += new System.EventHandler(this.SelectYearButton_Click);
            // 
            // DividendDepositorySelectionView
            // 
            this.AcceptButton = this._saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(513, 412);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._dataGridView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DividendDepositorySelectionView";
            this.Text = "Dividend Depository Selection";
            ((System.ComponentModel.ISupportInitialize)(this._dividendComputationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._yearNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _yearNumericUpDown;
        private System.Windows.Forms.Button _selectYearButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox _memberTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _changeButton;
        private System.Windows.Forms.ComboBox _depositoryComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.BindingSource _dividendComputationBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn memberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dividendDataGridViewTextBoxColumn;
    }
}