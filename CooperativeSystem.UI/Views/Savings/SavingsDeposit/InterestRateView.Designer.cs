namespace CooperativeSystem.UI.Views.Savings.SavingsDeposit
{
    partial class InterestRateView
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
            this.label1 = new System.Windows.Forms.Label();
            this._interestRateTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _closeButton
            // 
            this._closeButton.Location = new System.Drawing.Point(212, 65);
            // 
            // _updateButton
            // 
            this._updateButton.Location = new System.Drawing.Point(131, 65);
            this._updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._interestRateTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Size = new System.Drawing.Size(275, 47);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Interest Rate:";
            // 
            // _interestRateTextBox
            // 
            this._interestRateTextBox.Location = new System.Drawing.Point(126, 20);
            this._interestRateTextBox.Name = "_interestRateTextBox";
            this._interestRateTextBox.Size = new System.Drawing.Size(100, 21);
            this._interestRateTextBox.TabIndex = 2;
            this._interestRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // InterestRateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 113);
            this.Name = "InterestRateView";
            this.Text = "Interest Rate";
            this.Shown += new System.EventHandler(this.InterestRateView_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _interestRateTextBox;

    }
}