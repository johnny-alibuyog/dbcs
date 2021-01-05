namespace CooperativeSystem.UI.Views.Reports.MemberBalanceSummaries
{
    partial class MemberBalanceSummariesView
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
            this._generateButton = new System.Windows.Forms.Button();
            this._closeButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._filterTypeGroupBox = new System.Windows.Forms.GroupBox();
            this._byMemberRadioButton = new System.Windows.Forms.RadioButton();
            this._allMembersRadioButton = new System.Windows.Forms.RadioButton();
            this._membershipCategoryGroupBox = new System.Windows.Forms.GroupBox();
            this._regularRadioButton = new System.Windows.Forms.RadioButton();
            this._juniorSaverRadioButton = new System.Windows.Forms.RadioButton();
            this._associateRadioButton = new System.Windows.Forms.RadioButton();
            this._byMemberGroupBox = new System.Windows.Forms.GroupBox();
            this._memberComboBox = new System.Windows.Forms.ComboBox();
            this._filterTypeGroupBox.SuspendLayout();
            this._membershipCategoryGroupBox.SuspendLayout();
            this._byMemberGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _generateButton
            // 
            this._generateButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._generateButton.Location = new System.Drawing.Point(143, 166);
            this._generateButton.Name = "_generateButton";
            this._generateButton.Size = new System.Drawing.Size(79, 23);
            this._generateButton.TabIndex = 3;
            this._generateButton.TabStop = false;
            this._generateButton.Text = "&Generate";
            this._generateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._generateButton.UseVisualStyleBackColor = true;
            this._generateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(228, 166);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 4;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 192);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(315, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _filterTypeGroupBox
            // 
            this._filterTypeGroupBox.Controls.Add(this._byMemberRadioButton);
            this._filterTypeGroupBox.Controls.Add(this._allMembersRadioButton);
            this._filterTypeGroupBox.Location = new System.Drawing.Point(12, 61);
            this._filterTypeGroupBox.Name = "_filterTypeGroupBox";
            this._filterTypeGroupBox.Size = new System.Drawing.Size(291, 43);
            this._filterTypeGroupBox.TabIndex = 1;
            this._filterTypeGroupBox.TabStop = false;
            this._filterTypeGroupBox.Text = "Filter Type";
            // 
            // _byMemberRadioButton
            // 
            this._byMemberRadioButton.AutoSize = true;
            this._byMemberRadioButton.Location = new System.Drawing.Point(150, 20);
            this._byMemberRadioButton.Name = "_byMemberRadioButton";
            this._byMemberRadioButton.Size = new System.Drawing.Size(78, 17);
            this._byMemberRadioButton.TabIndex = 1;
            this._byMemberRadioButton.TabStop = true;
            this._byMemberRadioButton.Text = "By Member";
            this._byMemberRadioButton.UseVisualStyleBackColor = true;
            this._byMemberRadioButton.CheckedChanged += new System.EventHandler(this.FilterTypeRadioButton_CheckedChanged);
            // 
            // _allMembersRadioButton
            // 
            this._allMembersRadioButton.AutoSize = true;
            this._allMembersRadioButton.Location = new System.Drawing.Point(62, 20);
            this._allMembersRadioButton.Name = "_allMembersRadioButton";
            this._allMembersRadioButton.Size = new System.Drawing.Size(82, 17);
            this._allMembersRadioButton.TabIndex = 0;
            this._allMembersRadioButton.TabStop = true;
            this._allMembersRadioButton.Text = "All Members";
            this._allMembersRadioButton.UseVisualStyleBackColor = true;
            this._allMembersRadioButton.CheckedChanged += new System.EventHandler(this.FilterTypeRadioButton_CheckedChanged);
            // 
            // _membershipCategoryGroupBox
            // 
            this._membershipCategoryGroupBox.Controls.Add(this._regularRadioButton);
            this._membershipCategoryGroupBox.Controls.Add(this._juniorSaverRadioButton);
            this._membershipCategoryGroupBox.Controls.Add(this._associateRadioButton);
            this._membershipCategoryGroupBox.Location = new System.Drawing.Point(12, 12);
            this._membershipCategoryGroupBox.Name = "_membershipCategoryGroupBox";
            this._membershipCategoryGroupBox.Size = new System.Drawing.Size(291, 43);
            this._membershipCategoryGroupBox.TabIndex = 0;
            this._membershipCategoryGroupBox.TabStop = false;
            this._membershipCategoryGroupBox.Text = "Membership Category";
            // 
            // _regularRadioButton
            // 
            this._regularRadioButton.AutoSize = true;
            this._regularRadioButton.Location = new System.Drawing.Point(188, 20);
            this._regularRadioButton.Name = "_regularRadioButton";
            this._regularRadioButton.Size = new System.Drawing.Size(62, 17);
            this._regularRadioButton.TabIndex = 2;
            this._regularRadioButton.Text = "Regular";
            this._regularRadioButton.UseVisualStyleBackColor = true;
            this._regularRadioButton.CheckedChanged += new System.EventHandler(this.MembershipCategoryRadioButton_CheckedChanged);
            // 
            // _juniorSaverRadioButton
            // 
            this._juniorSaverRadioButton.AutoSize = true;
            this._juniorSaverRadioButton.Location = new System.Drawing.Point(97, 20);
            this._juniorSaverRadioButton.Name = "_juniorSaverRadioButton";
            this._juniorSaverRadioButton.Size = new System.Drawing.Size(85, 17);
            this._juniorSaverRadioButton.TabIndex = 1;
            this._juniorSaverRadioButton.Text = "Junior Saver";
            this._juniorSaverRadioButton.UseVisualStyleBackColor = true;
            this._juniorSaverRadioButton.CheckedChanged += new System.EventHandler(this.MembershipCategoryRadioButton_CheckedChanged);
            // 
            // _associateRadioButton
            // 
            this._associateRadioButton.AutoSize = true;
            this._associateRadioButton.Location = new System.Drawing.Point(20, 20);
            this._associateRadioButton.Name = "_associateRadioButton";
            this._associateRadioButton.Size = new System.Drawing.Size(71, 17);
            this._associateRadioButton.TabIndex = 0;
            this._associateRadioButton.Text = "Associate";
            this._associateRadioButton.UseVisualStyleBackColor = true;
            this._associateRadioButton.CheckedChanged += new System.EventHandler(this.MembershipCategoryRadioButton_CheckedChanged);
            // 
            // _byMemberGroupBox
            // 
            this._byMemberGroupBox.Controls.Add(this._memberComboBox);
            this._byMemberGroupBox.Location = new System.Drawing.Point(12, 110);
            this._byMemberGroupBox.Name = "_byMemberGroupBox";
            this._byMemberGroupBox.Size = new System.Drawing.Size(291, 50);
            this._byMemberGroupBox.TabIndex = 2;
            this._byMemberGroupBox.TabStop = false;
            this._byMemberGroupBox.Text = "By Member";
            // 
            // _memberComboBox
            // 
            this._memberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._memberComboBox.FormattingEnabled = true;
            this._memberComboBox.Location = new System.Drawing.Point(6, 20);
            this._memberComboBox.Name = "_memberComboBox";
            this._memberComboBox.Size = new System.Drawing.Size(279, 21);
            this._memberComboBox.TabIndex = 0;
            // 
            // MemberBalanceSummariesView
            // 
            this.AcceptButton = this._generateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(315, 214);
            this.Controls.Add(this._byMemberGroupBox);
            this.Controls.Add(this._filterTypeGroupBox);
            this.Controls.Add(this._membershipCategoryGroupBox);
            this.Controls.Add(this._generateButton);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MemberBalanceSummariesView";
            this.Text = "Member Balance Summaries";
            this.Shown += new System.EventHandler(this.MemberBalanceSummariesView_Shown);
            this._filterTypeGroupBox.ResumeLayout(false);
            this._filterTypeGroupBox.PerformLayout();
            this._membershipCategoryGroupBox.ResumeLayout(false);
            this._membershipCategoryGroupBox.PerformLayout();
            this._byMemberGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _generateButton;
        protected System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox _filterTypeGroupBox;
        private System.Windows.Forms.RadioButton _byMemberRadioButton;
        private System.Windows.Forms.RadioButton _allMembersRadioButton;
        private System.Windows.Forms.GroupBox _membershipCategoryGroupBox;
        private System.Windows.Forms.RadioButton _regularRadioButton;
        private System.Windows.Forms.RadioButton _juniorSaverRadioButton;
        private System.Windows.Forms.RadioButton _associateRadioButton;
        private System.Windows.Forms.GroupBox _byMemberGroupBox;
        private System.Windows.Forms.ComboBox _memberComboBox;
    }
}