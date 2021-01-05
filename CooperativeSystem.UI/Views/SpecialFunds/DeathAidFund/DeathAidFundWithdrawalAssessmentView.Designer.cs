namespace CooperativeSystem.UI.Views.SpecialFunds.DeathAidFund
{
    partial class DeathAidFundWithdrawalAssessmentView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._deathAidFundTypesComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._withdrawAmountTextBox = new System.Windows.Forms.TextBox();
            this._acceptButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._viewButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 113);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(360, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._viewButton);
            this.groupBox1.Controls.Add(this._deathAidFundTypesComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._withdrawAmountTextBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 74);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // _deathAidFundTypesComboBox
            // 
            this._deathAidFundTypesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._deathAidFundTypesComboBox.FormattingEnabled = true;
            this._deathAidFundTypesComboBox.Location = new System.Drawing.Point(155, 20);
            this._deathAidFundTypesComboBox.Name = "_deathAidFundTypesComboBox";
            this._deathAidFundTypesComboBox.Size = new System.Drawing.Size(99, 21);
            this._deathAidFundTypesComboBox.TabIndex = 4;
            this._deathAidFundTypesComboBox.SelectedIndexChanged += new System.EventHandler(this.DeathAidFundTypesComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Death Aid Fund Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Withdraw Amount:";
            // 
            // _withdrawAmountTextBox
            // 
            this._withdrawAmountTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._withdrawAmountTextBox.Location = new System.Drawing.Point(155, 47);
            this._withdrawAmountTextBox.Name = "_withdrawAmountTextBox";
            this._withdrawAmountTextBox.ReadOnly = true;
            this._withdrawAmountTextBox.Size = new System.Drawing.Size(100, 21);
            this._withdrawAmountTextBox.TabIndex = 0;
            this._withdrawAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _acceptButton
            // 
            this._acceptButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._acceptButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._acceptButton.Location = new System.Drawing.Point(191, 87);
            this._acceptButton.Name = "_acceptButton";
            this._acceptButton.Size = new System.Drawing.Size(75, 23);
            this._acceptButton.TabIndex = 10;
            this._acceptButton.Text = "&Accept";
            this._acceptButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._acceptButton.UseVisualStyleBackColor = true;
            this._acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._cancelButton.Location = new System.Drawing.Point(272, 87);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 9;
            this._cancelButton.Text = "&Cancel";
            this._cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _viewButton
            // 
            this._viewButton.Location = new System.Drawing.Point(261, 45);
            this._viewButton.Name = "_viewButton";
            this._viewButton.Size = new System.Drawing.Size(45, 23);
            this._viewButton.TabIndex = 5;
            this._viewButton.Text = "&View";
            this._viewButton.UseVisualStyleBackColor = true;
            this._viewButton.Click += new System.EventHandler(this.ViewButton_Click);
            // 
            // DeathAidFundWithdrawalAssessmentView
            // 
            this.AcceptButton = this._acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(360, 135);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._acceptButton);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "DeathAidFundWithdrawalAssessmentView";
            this.Text = "Death Aid Fund Withdrawal Assessment";
            this.Shown += new System.EventHandler(this.DeathAidFundWithdrawalAssessmentView_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button _acceptButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _withdrawAmountTextBox;
        private System.Windows.Forms.ComboBox _deathAidFundTypesComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _viewButton;
    }
}