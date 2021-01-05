namespace CooperativeSystem.UI.Views.Member
{
    partial class EducationalAttainmentView
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this._yearTextBox = new System.Windows.Forms.TextBox();
            this._schoolTextBox = new System.Windows.Forms.TextBox();
            this._levelTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._acceptButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            firstNameLabel = new System.Windows.Forms.Label();
            lastNameLabel = new System.Windows.Forms.Label();
            middleNameLabel = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(59, 50);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new System.Drawing.Size(42, 13);
            firstNameLabel.TabIndex = 0;
            firstNameLabel.Text = "School:";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new System.Drawing.Point(59, 23);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new System.Drawing.Size(36, 13);
            lastNameLabel.TabIndex = 2;
            lastNameLabel.Text = "Level:";
            // 
            // middleNameLabel
            // 
            middleNameLabel.AutoSize = true;
            middleNameLabel.Location = new System.Drawing.Point(59, 77);
            middleNameLabel.Name = "middleNameLabel";
            middleNameLabel.Size = new System.Drawing.Size(33, 13);
            middleNameLabel.TabIndex = 4;
            middleNameLabel.Text = "Year:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this._yearTextBox);
            this.GroupBox1.Controls.Add(this._schoolTextBox);
            this.GroupBox1.Controls.Add(this._levelTextBox);
            this.GroupBox1.Controls.Add(firstNameLabel);
            this.GroupBox1.Controls.Add(lastNameLabel);
            this.GroupBox1.Controls.Add(middleNameLabel);
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(453, 101);
            this.GroupBox1.TabIndex = 6;
            this.GroupBox1.TabStop = false;
            // 
            // _yearTextBox
            // 
            this._yearTextBox.Location = new System.Drawing.Point(107, 74);
            this._yearTextBox.Name = "_yearTextBox";
            this._yearTextBox.Size = new System.Drawing.Size(277, 21);
            this._yearTextBox.TabIndex = 2;
            // 
            // _schoolTextBox
            // 
            this._schoolTextBox.Location = new System.Drawing.Point(107, 47);
            this._schoolTextBox.Name = "_schoolTextBox";
            this._schoolTextBox.Size = new System.Drawing.Size(277, 21);
            this._schoolTextBox.TabIndex = 1;
            // 
            // _levelTextBox
            // 
            this._levelTextBox.Location = new System.Drawing.Point(107, 20);
            this._levelTextBox.Name = "_levelTextBox";
            this._levelTextBox.Size = new System.Drawing.Size(277, 21);
            this._levelTextBox.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 145);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(477, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _acceptButton
            // 
            this._acceptButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._acceptButton.Location = new System.Drawing.Point(309, 119);
            this._acceptButton.Name = "_acceptButton";
            this._acceptButton.Size = new System.Drawing.Size(75, 23);
            this._acceptButton.TabIndex = 7;
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
            this._cancelButton.Location = new System.Drawing.Point(390, 119);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 8;
            this._cancelButton.TabStop = false;
            this._cancelButton.Text = "&Cancel";
            this._cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // EducationalAttainmentView
            // 
            this.AcceptButton = this._acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(477, 167);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._acceptButton);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this.GroupBox1);
            this.Name = "EducationalAttainmentView";
            this.Text = "Educational Attainment";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _acceptButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.TextBox _yearTextBox;
        private System.Windows.Forms.TextBox _schoolTextBox;
        private System.Windows.Forms.TextBox _levelTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}