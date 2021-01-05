namespace CooperativeSystem.UI.Views.Loans.DTILoan
{
    partial class ServiceRateView
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
            this._interestRateTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._capitalBuildupRateTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._loanGuaranteeFundRateTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._collectionFeeRateTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._serviceFeeRateTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _closeButton
            // 
            this._closeButton.Location = new System.Drawing.Point(264, 163);
            // 
            // _updateButton
            // 
            this._updateButton.Location = new System.Drawing.Point(183, 163);
            this._updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this._interestRateTextBox);
            this._groupBox.Controls.Add(this.label4);
            this._groupBox.Controls.Add(this._capitalBuildupRateTextBox);
            this._groupBox.Controls.Add(this.label5);
            this._groupBox.Controls.Add(this._loanGuaranteeFundRateTextBox);
            this._groupBox.Controls.Add(this.label3);
            this._groupBox.Controls.Add(this._collectionFeeRateTextBox);
            this._groupBox.Controls.Add(this.label2);
            this._groupBox.Controls.Add(this._serviceFeeRateTextBox);
            this._groupBox.Controls.Add(this.label1);
            this._groupBox.Size = new System.Drawing.Size(327, 155);
            // 
            // _interestRateTextBox
            // 
            this._interestRateTextBox.Location = new System.Drawing.Point(186, 128);
            this._interestRateTextBox.Name = "_interestRateTextBox";
            this._interestRateTextBox.Size = new System.Drawing.Size(100, 21);
            this._interestRateTextBox.TabIndex = 27;
            this._interestRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Interest Rate:";
            // 
            // _capitalBuildupRateTextBox
            // 
            this._capitalBuildupRateTextBox.Location = new System.Drawing.Point(186, 101);
            this._capitalBuildupRateTextBox.Name = "_capitalBuildupRateTextBox";
            this._capitalBuildupRateTextBox.Size = new System.Drawing.Size(100, 21);
            this._capitalBuildupRateTextBox.TabIndex = 25;
            this._capitalBuildupRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Capital Buildup Rate:";
            // 
            // _loanGuaranteeFundRateTextBox
            // 
            this._loanGuaranteeFundRateTextBox.Location = new System.Drawing.Point(186, 74);
            this._loanGuaranteeFundRateTextBox.Name = "_loanGuaranteeFundRateTextBox";
            this._loanGuaranteeFundRateTextBox.Size = new System.Drawing.Size(100, 21);
            this._loanGuaranteeFundRateTextBox.TabIndex = 24;
            this._loanGuaranteeFundRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Loan Guarantee Fund Rate:";
            // 
            // _collectionFeeRateTextBox
            // 
            this._collectionFeeRateTextBox.Location = new System.Drawing.Point(186, 47);
            this._collectionFeeRateTextBox.Name = "_collectionFeeRateTextBox";
            this._collectionFeeRateTextBox.Size = new System.Drawing.Size(100, 21);
            this._collectionFeeRateTextBox.TabIndex = 22;
            this._collectionFeeRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Collection Fee Rate:";
            // 
            // _serviceFeeRateTextBox
            // 
            this._serviceFeeRateTextBox.Location = new System.Drawing.Point(186, 20);
            this._serviceFeeRateTextBox.Name = "_serviceFeeRateTextBox";
            this._serviceFeeRateTextBox.Size = new System.Drawing.Size(100, 21);
            this._serviceFeeRateTextBox.TabIndex = 21;
            this._serviceFeeRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Service Fee Rate:";
            // 
            // ServiceRateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 211);
            this.Name = "ServiceRateView";
            this.Text = "DTI/MEDP Service Rates (%)";
            this.Shown += new System.EventHandler(this.ServiceRateView_Shown);
            this._groupBox.ResumeLayout(false);
            this._groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _interestRateTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _capitalBuildupRateTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _loanGuaranteeFundRateTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _collectionFeeRateTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _serviceFeeRateTextBox;
        private System.Windows.Forms.Label label1;



    }
}