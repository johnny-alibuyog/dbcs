namespace CooperativeSystem.UI.Views.Plans.CollegeInsurancePlan
{
    partial class CIPWithdrawalAssessmentView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._cipAssessmentsDataGridView = new System.Windows.Forms.DataGridView();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maturityDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalContributionAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.awardAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WithdrawAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._cipAssessmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._viewButton = new System.Windows.Forms.Button();
            this._addButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._removeButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this._totalWithdrawAmountTextBox = new System.Windows.Forms.TextBox();
            this._cipAssessmentsToWithdrawDataGridView = new System.Windows.Forms.DataGridView();
            this.userNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maturityDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalContributionAmountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.awardAmountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._cipAssessmentsToWithdrawBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._cipAssessmentsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._cipAssessmentsBindingSource)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._cipAssessmentsToWithdrawDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._cipAssessmentsToWithdrawBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(627, 332);
            // 
            // _acceptButton
            // 
            this._acceptButton.Location = new System.Drawing.Point(546, 332);
            this._acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Size = new System.Drawing.Size(690, 314);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._cipAssessmentsDataGridView);
            this.groupBox3.Controls.Add(this._viewButton);
            this.groupBox3.Controls.Add(this._addButton);
            this.groupBox3.Location = new System.Drawing.Point(6, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(678, 139);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Plans";
            // 
            // _cipAssessmentsDataGridView
            // 
            this._cipAssessmentsDataGridView.AllowUserToAddRows = false;
            this._cipAssessmentsDataGridView.AllowUserToDeleteRows = false;
            this._cipAssessmentsDataGridView.AutoGenerateColumns = false;
            this._cipAssessmentsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._cipAssessmentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._cipAssessmentsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.maturityDateDataGridViewTextBoxColumn,
            this.totalContributionAmountDataGridViewTextBoxColumn,
            this.awardAmountDataGridViewTextBoxColumn,
            this.WithdrawAmount});
            this._cipAssessmentsDataGridView.DataSource = this._cipAssessmentsBindingSource;
            this._cipAssessmentsDataGridView.Location = new System.Drawing.Point(6, 20);
            this._cipAssessmentsDataGridView.MultiSelect = false;
            this._cipAssessmentsDataGridView.Name = "_cipAssessmentsDataGridView";
            this._cipAssessmentsDataGridView.ReadOnly = true;
            this._cipAssessmentsDataGridView.RowHeadersVisible = false;
            this._cipAssessmentsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._cipAssessmentsDataGridView.Size = new System.Drawing.Size(585, 113);
            this._cipAssessmentsDataGridView.TabIndex = 3;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "User";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // maturityDateDataGridViewTextBoxColumn
            // 
            this.maturityDateDataGridViewTextBoxColumn.DataPropertyName = "MaturityDate";
            dataGridViewCellStyle5.Format = "d";
            this.maturityDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.maturityDateDataGridViewTextBoxColumn.HeaderText = "Maturity Date";
            this.maturityDateDataGridViewTextBoxColumn.Name = "maturityDateDataGridViewTextBoxColumn";
            this.maturityDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalContributionAmountDataGridViewTextBoxColumn
            // 
            this.totalContributionAmountDataGridViewTextBoxColumn.DataPropertyName = "TotalContributionAmount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.totalContributionAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.totalContributionAmountDataGridViewTextBoxColumn.HeaderText = "Total Contribution";
            this.totalContributionAmountDataGridViewTextBoxColumn.Name = "totalContributionAmountDataGridViewTextBoxColumn";
            this.totalContributionAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // awardAmountDataGridViewTextBoxColumn
            // 
            this.awardAmountDataGridViewTextBoxColumn.DataPropertyName = "AwardAmount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.awardAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.awardAmountDataGridViewTextBoxColumn.HeaderText = "Award Amount";
            this.awardAmountDataGridViewTextBoxColumn.Name = "awardAmountDataGridViewTextBoxColumn";
            this.awardAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // WithdrawAmount
            // 
            this.WithdrawAmount.DataPropertyName = "WithdrawAmount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.WithdrawAmount.DefaultCellStyle = dataGridViewCellStyle8;
            this.WithdrawAmount.HeaderText = "Withdraw Amount";
            this.WithdrawAmount.Name = "WithdrawAmount";
            this.WithdrawAmount.ReadOnly = true;
            // 
            // _cipAssessmentsBindingSource
            // 
            this._cipAssessmentsBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan.CIPWithdrawalAssessmentModel);
            // 
            // _viewButton
            // 
            this._viewButton.Location = new System.Drawing.Point(597, 49);
            this._viewButton.Name = "_viewButton";
            this._viewButton.Size = new System.Drawing.Size(75, 23);
            this._viewButton.TabIndex = 2;
            this._viewButton.Text = "&View";
            this._viewButton.UseVisualStyleBackColor = true;
            this._viewButton.Click += new System.EventHandler(this.ViewButton_Click);
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(597, 20);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(75, 23);
            this._addButton.TabIndex = 0;
            this._addButton.Text = "&Add";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._removeButton);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this._totalWithdrawAmountTextBox);
            this.groupBox4.Controls.Add(this._cipAssessmentsToWithdrawDataGridView);
            this.groupBox4.Location = new System.Drawing.Point(6, 165);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(678, 142);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Withdraw";
            // 
            // _removeButton
            // 
            this._removeButton.Location = new System.Drawing.Point(597, 21);
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
            this.label6.Location = new System.Drawing.Point(353, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Total Withdraw Ammount:";
            // 
            // _totalWithdrawAmountTextBox
            // 
            this._totalWithdrawAmountTextBox.Location = new System.Drawing.Point(491, 115);
            this._totalWithdrawAmountTextBox.Name = "_totalWithdrawAmountTextBox";
            this._totalWithdrawAmountTextBox.ReadOnly = true;
            this._totalWithdrawAmountTextBox.Size = new System.Drawing.Size(100, 21);
            this._totalWithdrawAmountTextBox.TabIndex = 1;
            this._totalWithdrawAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _cipAssessmentsToWithdrawDataGridView
            // 
            this._cipAssessmentsToWithdrawDataGridView.AllowUserToAddRows = false;
            this._cipAssessmentsToWithdrawDataGridView.AllowUserToDeleteRows = false;
            this._cipAssessmentsToWithdrawDataGridView.AutoGenerateColumns = false;
            this._cipAssessmentsToWithdrawDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._cipAssessmentsToWithdrawDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._cipAssessmentsToWithdrawDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn1,
            this.maturityDateDataGridViewTextBoxColumn1,
            this.totalContributionAmountDataGridViewTextBoxColumn1,
            this.awardAmountDataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn1});
            this._cipAssessmentsToWithdrawDataGridView.DataSource = this._cipAssessmentsToWithdrawBindingSource;
            this._cipAssessmentsToWithdrawDataGridView.Location = new System.Drawing.Point(7, 21);
            this._cipAssessmentsToWithdrawDataGridView.MultiSelect = false;
            this._cipAssessmentsToWithdrawDataGridView.Name = "_cipAssessmentsToWithdrawDataGridView";
            this._cipAssessmentsToWithdrawDataGridView.ReadOnly = true;
            this._cipAssessmentsToWithdrawDataGridView.RowHeadersVisible = false;
            this._cipAssessmentsToWithdrawDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._cipAssessmentsToWithdrawDataGridView.Size = new System.Drawing.Size(584, 88);
            this._cipAssessmentsToWithdrawDataGridView.TabIndex = 0;
            this._cipAssessmentsToWithdrawDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CIPsAssessmentsToWithdrawDataGridView_CellContentClick);
            // 
            // userNameDataGridViewTextBoxColumn1
            // 
            this.userNameDataGridViewTextBoxColumn1.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn1.HeaderText = "User";
            this.userNameDataGridViewTextBoxColumn1.Name = "userNameDataGridViewTextBoxColumn1";
            this.userNameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // maturityDateDataGridViewTextBoxColumn1
            // 
            this.maturityDateDataGridViewTextBoxColumn1.DataPropertyName = "MaturityDate";
            dataGridViewCellStyle1.Format = "d";
            this.maturityDateDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.maturityDateDataGridViewTextBoxColumn1.HeaderText = "Maturity Date";
            this.maturityDateDataGridViewTextBoxColumn1.Name = "maturityDateDataGridViewTextBoxColumn1";
            this.maturityDateDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // totalContributionAmountDataGridViewTextBoxColumn1
            // 
            this.totalContributionAmountDataGridViewTextBoxColumn1.DataPropertyName = "TotalContributionAmount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.totalContributionAmountDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.totalContributionAmountDataGridViewTextBoxColumn1.HeaderText = "Total Contribution";
            this.totalContributionAmountDataGridViewTextBoxColumn1.Name = "totalContributionAmountDataGridViewTextBoxColumn1";
            this.totalContributionAmountDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // awardAmountDataGridViewTextBoxColumn1
            // 
            this.awardAmountDataGridViewTextBoxColumn1.DataPropertyName = "AwardAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.awardAmountDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.awardAmountDataGridViewTextBoxColumn1.HeaderText = "Award Amount";
            this.awardAmountDataGridViewTextBoxColumn1.Name = "awardAmountDataGridViewTextBoxColumn1";
            this.awardAmountDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "WithdrawAmount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn1.HeaderText = "Withdraw Amount";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // _cipAssessmentsToWithdrawBindingSource
            // 
            this._cipAssessmentsToWithdrawBindingSource.DataSource = typeof(CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan.CIPWithdrawalAssessmentModel);
            // 
            // CIPWithdrawalAssessmentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 380);
            this.Name = "CIPWithdrawalAssessmentView";
            this.Text = "College Insurance Plan Withdrawal Assessment";
            this.Shown += new System.EventHandler(this.CIPWithdrawalAssessmentView_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._cipAssessmentsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._cipAssessmentsBindingSource)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._cipAssessmentsToWithdrawDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._cipAssessmentsToWithdrawBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _removeButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _totalWithdrawAmountTextBox;
        private System.Windows.Forms.Button _viewButton;
        private System.Windows.Forms.DataGridView _cipAssessmentsToWithdrawDataGridView;
        private System.Windows.Forms.DataGridView _cipAssessmentsDataGridView;
        private System.Windows.Forms.BindingSource _cipAssessmentsBindingSource;
        private System.Windows.Forms.BindingSource _cipAssessmentsToWithdrawBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn maturityDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalContributionAmountDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn awardAmountDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maturityDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalContributionAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn awardAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WithdrawAmount;

    }
}