namespace CooperativeSystem.UI.Views.Member
{
    partial class DependentView
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
            System.Windows.Forms.Label firstNameLabel;
            System.Windows.Forms.Label lastNameLabel;
            System.Windows.Forms.Label middleNameLabel;
            System.Windows.Forms.Label relationLabel;
            this._acceptButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this._relationComboBox = new System.Windows.Forms.ComboBox();
            this._middleNameTextBox = new System.Windows.Forms.TextBox();
            this._firstNameTextBox = new System.Windows.Forms.TextBox();
            this._lastNameTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            firstNameLabel = new System.Windows.Forms.Label();
            lastNameLabel = new System.Windows.Forms.Label();
            middleNameLabel = new System.Windows.Forms.Label();
            relationLabel = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(44, 50);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new System.Drawing.Size(62, 13);
            firstNameLabel.TabIndex = 0;
            firstNameLabel.Text = "First Name:";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new System.Drawing.Point(44, 23);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new System.Drawing.Size(61, 13);
            lastNameLabel.TabIndex = 2;
            lastNameLabel.Text = "Last Name:";
            // 
            // middleNameLabel
            // 
            middleNameLabel.AutoSize = true;
            middleNameLabel.Location = new System.Drawing.Point(44, 77);
            middleNameLabel.Name = "middleNameLabel";
            middleNameLabel.Size = new System.Drawing.Size(71, 13);
            middleNameLabel.TabIndex = 4;
            middleNameLabel.Text = "Middle Name:";
            // 
            // relationLabel
            // 
            relationLabel.AutoSize = true;
            relationLabel.Location = new System.Drawing.Point(44, 104);
            relationLabel.Name = "relationLabel";
            relationLabel.Size = new System.Drawing.Size(50, 13);
            relationLabel.TabIndex = 6;
            relationLabel.Text = "Relation:";
            // 
            // _acceptButton
            // 
            this._acceptButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._acceptButton.Location = new System.Drawing.Point(166, 154);
            this._acceptButton.Name = "_acceptButton";
            this._acceptButton.Size = new System.Drawing.Size(75, 23);
            this._acceptButton.TabIndex = 4;
            this._acceptButton.TabStop = false;
            this._acceptButton.Text = "&Accept";
            this._acceptButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._acceptButton.UseVisualStyleBackColor = true;
            this._acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._cancelButton.Location = new System.Drawing.Point(247, 154);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 5;
            this._cancelButton.TabStop = false;
            this._cancelButton.Text = "&Cancel";
            this._cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this._relationComboBox);
            this.GroupBox1.Controls.Add(this._middleNameTextBox);
            this.GroupBox1.Controls.Add(this._firstNameTextBox);
            this.GroupBox1.Controls.Add(this._lastNameTextBox);
            this.GroupBox1.Controls.Add(firstNameLabel);
            this.GroupBox1.Controls.Add(lastNameLabel);
            this.GroupBox1.Controls.Add(middleNameLabel);
            this.GroupBox1.Controls.Add(relationLabel);
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(310, 136);
            this.GroupBox1.TabIndex = 3;
            this.GroupBox1.TabStop = false;
            // 
            // _relationComboBox
            // 
            this._relationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._relationComboBox.FormattingEnabled = true;
            this._relationComboBox.Location = new System.Drawing.Point(121, 101);
            this._relationComboBox.Name = "_relationComboBox";
            this._relationComboBox.Size = new System.Drawing.Size(157, 21);
            this._relationComboBox.TabIndex = 3;
            // 
            // _middleNameTextBox
            // 
            this._middleNameTextBox.Location = new System.Drawing.Point(121, 74);
            this._middleNameTextBox.Name = "_middleNameTextBox";
            this._middleNameTextBox.Size = new System.Drawing.Size(157, 21);
            this._middleNameTextBox.TabIndex = 2;
            // 
            // _firstNameTextBox
            // 
            this._firstNameTextBox.Location = new System.Drawing.Point(122, 47);
            this._firstNameTextBox.Name = "_firstNameTextBox";
            this._firstNameTextBox.Size = new System.Drawing.Size(157, 21);
            this._firstNameTextBox.TabIndex = 1;
            // 
            // _lastNameTextBox
            // 
            this._lastNameTextBox.Location = new System.Drawing.Point(122, 20);
            this._lastNameTextBox.Name = "_lastNameTextBox";
            this._lastNameTextBox.Size = new System.Drawing.Size(157, 21);
            this._lastNameTextBox.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 180);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(334, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // DependentView
            // 
            this.AcceptButton = this._acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(334, 202);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._acceptButton);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this.GroupBox1);
            this.Name = "DependentView";
            this.Text = "Beneficiary";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _lastNameTextBox;
        private System.Windows.Forms.ComboBox _relationComboBox;
        private System.Windows.Forms.TextBox _middleNameTextBox;
        private System.Windows.Forms.TextBox _firstNameTextBox;
        private System.Windows.Forms.Button _acceptButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}