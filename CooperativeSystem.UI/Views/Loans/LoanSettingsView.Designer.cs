namespace CooperativeSystem.UI.Views.Loans
{
    partial class LoanSettingsView
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
            this._groupBox = new System.Windows.Forms.GroupBox();
            this._regularLoanMaxPrecentageTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._renewablePaidRecentageTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this._closeButton = new System.Windows.Forms.Button();
            this._updateButton = new System.Windows.Forms.Button();
            this._rebateExcemptedTermsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 145);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(337, 22);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this._rebateExcemptedTermsTextBox);
            this._groupBox.Controls.Add(this.label2);
            this._groupBox.Controls.Add(this._regularLoanMaxPrecentageTextBox);
            this._groupBox.Controls.Add(this.label1);
            this._groupBox.Controls.Add(this._renewablePaidRecentageTextBox);
            this._groupBox.Controls.Add(this.label10);
            this._groupBox.Location = new System.Drawing.Point(12, 12);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(312, 101);
            this._groupBox.TabIndex = 20;
            this._groupBox.TabStop = false;
            // 
            // _regularLoanMaxPrecentageTextBox
            // 
            this._regularLoanMaxPrecentageTextBox.Location = new System.Drawing.Point(176, 47);
            this._regularLoanMaxPrecentageTextBox.Name = "_regularLoanMaxPrecentageTextBox";
            this._regularLoanMaxPrecentageTextBox.Size = new System.Drawing.Size(100, 21);
            this._regularLoanMaxPrecentageTextBox.TabIndex = 4;
            this._regularLoanMaxPrecentageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Regular Loan Max Precentage:";
            // 
            // _renewablePaidRecentageTextBox
            // 
            this._renewablePaidRecentageTextBox.Location = new System.Drawing.Point(176, 20);
            this._renewablePaidRecentageTextBox.Name = "_renewablePaidRecentageTextBox";
            this._renewablePaidRecentageTextBox.Size = new System.Drawing.Size(100, 21);
            this._renewablePaidRecentageTextBox.TabIndex = 2;
            this._renewablePaidRecentageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(145, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Renewable Paid Percentage:";
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(249, 119);
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
            this._updateButton.Location = new System.Drawing.Point(168, 119);
            this._updateButton.Name = "_updateButton";
            this._updateButton.Size = new System.Drawing.Size(75, 23);
            this._updateButton.TabIndex = 21;
            this._updateButton.TabStop = false;
            this._updateButton.Text = "&Update";
            this._updateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._updateButton.UseVisualStyleBackColor = true;
            this._updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // _rebateExcemptedTermsTextBox
            // 
            this._rebateExcemptedTermsTextBox.Location = new System.Drawing.Point(176, 74);
            this._rebateExcemptedTermsTextBox.Name = "_rebateExcemptedTermsTextBox";
            this._rebateExcemptedTermsTextBox.Size = new System.Drawing.Size(100, 21);
            this._rebateExcemptedTermsTextBox.TabIndex = 6;
            this._rebateExcemptedTermsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Rebate Exempted Terms:";
            // 
            // LoanSettingsView
            // 
            this.AcceptButton = this._updateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(337, 167);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._updateButton);
            this.Controls.Add(this._groupBox);
            this.Name = "LoanSettingsView";
            this.Text = "Loan Settings";
            this.Load += new System.EventHandler(this.LoanSettingsView_Load);
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
        private System.Windows.Forms.TextBox _renewablePaidRecentageTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox _regularLoanMaxPrecentageTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _rebateExcemptedTermsTextBox;
        private System.Windows.Forms.Label label2;
    }
}