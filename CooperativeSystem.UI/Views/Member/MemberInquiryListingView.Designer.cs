namespace CooperativeSystem.UI.Views.Member
{
    partial class MemberInquiryListingView
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
            System.Windows.Forms.Label accountNumberLabel;
            System.Windows.Forms.Label firstNameLabel;
            System.Windows.Forms.Label lastNameLabel;
            System.Windows.Forms.Label middleNameLabel;
            System.Windows.Forms.Label label1;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._membershipCategoryComboBox = new System.Windows.Forms.ComboBox();
            this._accountNumberTextBox = new System.Windows.Forms.TextBox();
            this._middleNameTextBox = new System.Windows.Forms.TextBox();
            this._firstNameTextBox = new System.Windows.Forms.TextBox();
            this._lastNameTextBox = new System.Windows.Forms.TextBox();
            this._clearButton = new System.Windows.Forms.Button();
            this._searchButton = new System.Windows.Forms.Button();
            this._membersDataGridView = new System.Windows.Forms.DataGridView();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this._resultCountToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            accountNumberLabel = new System.Windows.Forms.Label();
            firstNameLabel = new System.Windows.Forms.Label();
            lastNameLabel = new System.Windows.Forms.Label();
            middleNameLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._membersDataGridView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // accountNumberLabel
            // 
            accountNumberLabel.AutoSize = true;
            accountNumberLabel.Location = new System.Drawing.Point(306, 23);
            accountNumberLabel.Name = "accountNumberLabel";
            accountNumberLabel.Size = new System.Drawing.Size(90, 13);
            accountNumberLabel.TabIndex = 0;
            accountNumberLabel.Text = "Account Number:";
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(42, 50);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new System.Drawing.Size(62, 13);
            firstNameLabel.TabIndex = 2;
            firstNameLabel.Text = "First Name:";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new System.Drawing.Point(43, 23);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new System.Drawing.Size(61, 13);
            lastNameLabel.TabIndex = 4;
            lastNameLabel.Text = "Last Name:";
            // 
            // middleNameLabel
            // 
            middleNameLabel.AutoSize = true;
            middleNameLabel.Location = new System.Drawing.Point(33, 77);
            middleNameLabel.Name = "middleNameLabel";
            middleNameLabel.Size = new System.Drawing.Size(71, 13);
            middleNameLabel.TabIndex = 6;
            middleNameLabel.Text = "Middle Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(340, 50);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 13);
            label1.TabIndex = 8;
            label1.Text = "Category:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this._membershipCategoryComboBox);
            this.groupBox1.Controls.Add(this._accountNumberTextBox);
            this.groupBox1.Controls.Add(this._middleNameTextBox);
            this.groupBox1.Controls.Add(this._firstNameTextBox);
            this.groupBox1.Controls.Add(this._lastNameTextBox);
            this.groupBox1.Controls.Add(this._clearButton);
            this.groupBox1.Controls.Add(this._searchButton);
            this.groupBox1.Controls.Add(accountNumberLabel);
            this.groupBox1.Controls.Add(firstNameLabel);
            this.groupBox1.Controls.Add(lastNameLabel);
            this.groupBox1.Controls.Add(middleNameLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 113);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // _membershipCategoryComboBox
            // 
            this._membershipCategoryComboBox.FormattingEnabled = true;
            this._membershipCategoryComboBox.Location = new System.Drawing.Point(402, 47);
            this._membershipCategoryComboBox.Name = "_membershipCategoryComboBox";
            this._membershipCategoryComboBox.Size = new System.Drawing.Size(162, 21);
            this._membershipCategoryComboBox.TabIndex = 7;
            // 
            // _accountNumberTextBox
            // 
            this._accountNumberTextBox.Location = new System.Drawing.Point(402, 20);
            this._accountNumberTextBox.Name = "_accountNumberTextBox";
            this._accountNumberTextBox.Size = new System.Drawing.Size(162, 21);
            this._accountNumberTextBox.TabIndex = 3;
            // 
            // _middleNameTextBox
            // 
            this._middleNameTextBox.Location = new System.Drawing.Point(110, 74);
            this._middleNameTextBox.Name = "_middleNameTextBox";
            this._middleNameTextBox.Size = new System.Drawing.Size(162, 21);
            this._middleNameTextBox.TabIndex = 2;
            // 
            // _firstNameTextBox
            // 
            this._firstNameTextBox.Location = new System.Drawing.Point(110, 47);
            this._firstNameTextBox.Name = "_firstNameTextBox";
            this._firstNameTextBox.Size = new System.Drawing.Size(162, 21);
            this._firstNameTextBox.TabIndex = 1;
            // 
            // _lastNameTextBox
            // 
            this._lastNameTextBox.Location = new System.Drawing.Point(110, 20);
            this._lastNameTextBox.Name = "_lastNameTextBox";
            this._lastNameTextBox.Size = new System.Drawing.Size(162, 21);
            this._lastNameTextBox.TabIndex = 0;
            // 
            // _clearButton
            // 
            this._clearButton.Location = new System.Drawing.Point(489, 72);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(75, 23);
            this._clearButton.TabIndex = 5;
            this._clearButton.TabStop = false;
            this._clearButton.Text = "Cle&ar";
            this._clearButton.UseVisualStyleBackColor = true;
            this._clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // _searchButton
            // 
            this._searchButton.Image = global::CooperativeSystem.UI.Properties.Resources.find;
            this._searchButton.Location = new System.Drawing.Point(408, 72);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(75, 23);
            this._searchButton.TabIndex = 4;
            this._searchButton.TabStop = false;
            this._searchButton.Text = "&Search";
            this._searchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._searchButton.UseVisualStyleBackColor = true;
            this._searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // _membersDataGridView
            // 
            this._membersDataGridView.AllowUserToAddRows = false;
            this._membersDataGridView.AllowUserToDeleteRows = false;
            this._membersDataGridView.AllowUserToResizeColumns = false;
            this._membersDataGridView.AllowUserToResizeRows = false;
            this._membersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._membersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._membersDataGridView.Location = new System.Drawing.Point(12, 132);
            this._membersDataGridView.MultiSelect = false;
            this._membersDataGridView.Name = "_membersDataGridView";
            this._membersDataGridView.ReadOnly = true;
            this._membersDataGridView.RowHeadersVisible = false;
            this._membersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._membersDataGridView.Size = new System.Drawing.Size(597, 223);
            this._membersDataGridView.TabIndex = 2;
            this._membersDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MembersDataGridView_CellContentDoubleClick);
            // 
            // _okButton
            // 
            this._okButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._okButton.Location = new System.Drawing.Point(453, 361);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 3;
            this._okButton.TabStop = false;
            this._okButton.Text = "&OK";
            this._okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._cancelButton.Location = new System.Drawing.Point(534, 361);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 4;
            this._cancelButton.TabStop = false;
            this._cancelButton.Text = "&Cancel";
            this._cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this._resultCountToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 387);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(621, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(78, 17);
            this.toolStripStatusLabel1.Text = "Result Count:";
            // 
            // _resultCountToolStripStatusLabel
            // 
            this._resultCountToolStripStatusLabel.Name = "_resultCountToolStripStatusLabel";
            this._resultCountToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MemberInquiryListingView
            // 
            this.AcceptButton = this._searchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(621, 409);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._membersDataGridView);
            this.Controls.Add(this.groupBox1);
            this.Name = "MemberInquiryListingView";
            this.Text = "Member Inquiry";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._membersDataGridView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button _clearButton;
        internal System.Windows.Forms.Button _searchButton;
        private System.Windows.Forms.DataGridView _membersDataGridView;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.TextBox _lastNameTextBox;
        private System.Windows.Forms.TextBox _accountNumberTextBox;
        private System.Windows.Forms.TextBox _middleNameTextBox;
        private System.Windows.Forms.TextBox _firstNameTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ComboBox _membershipCategoryComboBox;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel _resultCountToolStripStatusLabel;
    }
}