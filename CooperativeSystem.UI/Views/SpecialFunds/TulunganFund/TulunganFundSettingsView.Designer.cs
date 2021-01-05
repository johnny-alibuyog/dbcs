namespace CooperativeSystem.UI.Views.SpecialFunds.TulunganFund
{
    partial class TulunganFundSettingsView
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
            this._requiredMinimumShareTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._perMemberYearlyContributionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._awardForShareBelowFifteenThousandTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._awardForShareFifteenThousandAndAboveTextBox = new System.Windows.Forms.TextBox();
            this._groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 172);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(437, 22);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(350, 146);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 22;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = true;
            // 
            // _updateButton
            // 
            this._updateButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._updateButton.Location = new System.Drawing.Point(269, 146);
            this._updateButton.Name = "_updateButton";
            this._updateButton.Size = new System.Drawing.Size(75, 23);
            this._updateButton.TabIndex = 21;
            this._updateButton.TabStop = false;
            this._updateButton.Text = "&Update";
            this._updateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._updateButton.UseVisualStyleBackColor = true;
            this._updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this._awardForShareFifteenThousandAndAboveTextBox);
            this._groupBox.Controls.Add(this.label3);
            this._groupBox.Controls.Add(this._awardForShareBelowFifteenThousandTextBox);
            this._groupBox.Controls.Add(this.label4);
            this._groupBox.Controls.Add(this._requiredMinimumShareTextBox);
            this._groupBox.Controls.Add(this.label2);
            this._groupBox.Controls.Add(this._perMemberYearlyContributionTextBox);
            this._groupBox.Controls.Add(this.label1);
            this._groupBox.Location = new System.Drawing.Point(12, 12);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(413, 128);
            this._groupBox.TabIndex = 20;
            this._groupBox.TabStop = false;
            // 
            // _requiredMinimumShareTextBox
            // 
            this._requiredMinimumShareTextBox.Location = new System.Drawing.Point(277, 47);
            this._requiredMinimumShareTextBox.Name = "_requiredMinimumShareTextBox";
            this._requiredMinimumShareTextBox.Size = new System.Drawing.Size(100, 21);
            this._requiredMinimumShareTextBox.TabIndex = 5;
            this._requiredMinimumShareTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Required Minimum Share:";
            // 
            // _perMemberYearlyContributionTextBox
            // 
            this._perMemberYearlyContributionTextBox.Location = new System.Drawing.Point(277, 20);
            this._perMemberYearlyContributionTextBox.Name = "_perMemberYearlyContributionTextBox";
            this._perMemberYearlyContributionTextBox.Size = new System.Drawing.Size(100, 21);
            this._perMemberYearlyContributionTextBox.TabIndex = 3;
            this._perMemberYearlyContributionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Per-Member Yearly Contribution:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Award For Share Below Fifteen Thousand:";
            // 
            // _awardForShareBelowFifteenThousandTextBox
            // 
            this._awardForShareBelowFifteenThousandTextBox.Location = new System.Drawing.Point(277, 74);
            this._awardForShareBelowFifteenThousandTextBox.Name = "_awardForShareBelowFifteenThousandTextBox";
            this._awardForShareBelowFifteenThousandTextBox.Size = new System.Drawing.Size(100, 21);
            this._awardForShareBelowFifteenThousandTextBox.TabIndex = 7;
            this._awardForShareBelowFifteenThousandTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Award For Share Fifteen Thousand And Above:";
            // 
            // _awardForShareFifteenThousandAndAboveTextBox
            // 
            this._awardForShareFifteenThousandAndAboveTextBox.Location = new System.Drawing.Point(277, 101);
            this._awardForShareFifteenThousandAndAboveTextBox.Name = "_awardForShareFifteenThousandAndAboveTextBox";
            this._awardForShareFifteenThousandAndAboveTextBox.Size = new System.Drawing.Size(100, 21);
            this._awardForShareFifteenThousandAndAboveTextBox.TabIndex = 9;
            this._awardForShareFifteenThousandAndAboveTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TulunganFundSettingsView
            // 
            this.AcceptButton = this._updateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(437, 194);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._updateButton);
            this.Controls.Add(this._groupBox);
            this.Name = "TulunganFundSettingsView";
            this.Text = "Tulungan Fund Settings";
            this.Shown += new System.EventHandler(this.TulunganFundSettingsView_Shown);
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
        private System.Windows.Forms.TextBox _requiredMinimumShareTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _perMemberYearlyContributionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _awardForShareFifteenThousandAndAboveTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _awardForShareBelowFifteenThousandTextBox;
        private System.Windows.Forms.Label label4;
    }
}