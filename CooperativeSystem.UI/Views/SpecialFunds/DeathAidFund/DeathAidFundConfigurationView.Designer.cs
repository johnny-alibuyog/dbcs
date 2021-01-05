namespace CooperativeSystem.UI.Views.SpecialFunds.DeathAidFund
{
    partial class DeathAidFundConfigurationView
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._closeButton = new System.Windows.Forms.Button();
            this._updateButton = new System.Windows.Forms.Button();
            this._groupBox = new System.Windows.Forms.GroupBox();
            this._memberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._beneficiaryTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 118);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(298, 22);
            this.statusStrip1.TabIndex = 27;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(211, 92);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 26;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = true;
            // 
            // _updateButton
            // 
            this._updateButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._updateButton.Location = new System.Drawing.Point(130, 92);
            this._updateButton.Name = "_updateButton";
            this._updateButton.Size = new System.Drawing.Size(75, 23);
            this._updateButton.TabIndex = 25;
            this._updateButton.TabStop = false;
            this._updateButton.Text = "&Update";
            this._updateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._updateButton.UseVisualStyleBackColor = true;
            this._updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this._memberTextBox);
            this._groupBox.Controls.Add(this.label2);
            this._groupBox.Controls.Add(this._beneficiaryTextBox);
            this._groupBox.Controls.Add(this.label1);
            this._groupBox.Location = new System.Drawing.Point(12, 12);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(274, 74);
            this._groupBox.TabIndex = 24;
            this._groupBox.TabStop = false;
            this._groupBox.Text = "Per-member Contribution";
            // 
            // _memberTextBox
            // 
            this._memberTextBox.Location = new System.Drawing.Point(127, 47);
            this._memberTextBox.Name = "_memberTextBox";
            this._memberTextBox.Size = new System.Drawing.Size(100, 21);
            this._memberTextBox.TabIndex = 5;
            this._memberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Member:";
            // 
            // _beneficiaryTextBox
            // 
            this._beneficiaryTextBox.Location = new System.Drawing.Point(127, 20);
            this._beneficiaryTextBox.Name = "_beneficiaryTextBox";
            this._beneficiaryTextBox.Size = new System.Drawing.Size(100, 21);
            this._beneficiaryTextBox.TabIndex = 3;
            this._beneficiaryTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Beneficiary:";
            // 
            // DeathAidFundConfigurationView
            // 
            this.AcceptButton = this._updateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(298, 140);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._updateButton);
            this.Controls.Add(this._groupBox);
            this.Name = "DeathAidFundConfigurationView";
            this.Text = "Death Aid Fund Configuration";
            this.Shown += new System.EventHandler(this.DeathAidFundConfigurationView_Shown);
            this._groupBox.ResumeLayout(false);
            this._groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        protected System.Windows.Forms.Button _closeButton;
        protected System.Windows.Forms.Button _updateButton;
        protected System.Windows.Forms.GroupBox _groupBox;
        private System.Windows.Forms.TextBox _memberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _beneficiaryTextBox;
        private System.Windows.Forms.Label label1;
    }
}