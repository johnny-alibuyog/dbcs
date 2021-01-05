namespace CooperativeSystem.UI.Views.Plans.PensionPlan
{
    partial class PensionPlanWithdrawalAssessmentView
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
            this.label7 = new System.Windows.Forms.Label();
            this._payedAmountTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._withdrawAmountTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this._interestsTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this._awardAmountTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this._paymentCompletionAmountTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this._maturityDateTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this._applicationDateTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._paymentCompletionDateTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._availOptionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._disbursedAmountTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._maximumWithdrawableAmountTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(266, 347);
            this._cancelButton.TabStop = false;
            // 
            // _acceptButton
            // 
            this._acceptButton.Location = new System.Drawing.Point(185, 347);
            this._acceptButton.TabStop = false;
            this._acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this._maximumWithdrawableAmountTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._disbursedAmountTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._availOptionTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._paymentCompletionDateTextBox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this._applicationDateTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this._payedAmountTextBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this._withdrawAmountTextBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this._interestsTextBox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this._awardAmountTextBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this._paymentCompletionAmountTextBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this._maturityDateTextBox);
            this.groupBox1.Size = new System.Drawing.Size(329, 329);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(102, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Payed Amount:";
            // 
            // _payedAmountTextBox
            // 
            this._payedAmountTextBox.Location = new System.Drawing.Point(189, 192);
            this._payedAmountTextBox.Name = "_payedAmountTextBox";
            this._payedAmountTextBox.ReadOnly = true;
            this._payedAmountTextBox.Size = new System.Drawing.Size(100, 21);
            this._payedAmountTextBox.TabIndex = 38;
            this._payedAmountTextBox.TabStop = false;
            this._payedAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(86, 305);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Withdraw Amount:";
            // 
            // _withdrawAmountTextBox
            // 
            this._withdrawAmountTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._withdrawAmountTextBox.Location = new System.Drawing.Point(189, 302);
            this._withdrawAmountTextBox.Name = "_withdrawAmountTextBox";
            this._withdrawAmountTextBox.Size = new System.Drawing.Size(100, 21);
            this._withdrawAmountTextBox.TabIndex = 36;
            this._withdrawAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(128, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Interests:";
            // 
            // _interestsTextBox
            // 
            this._interestsTextBox.Location = new System.Drawing.Point(189, 221);
            this._interestsTextBox.Name = "_interestsTextBox";
            this._interestsTextBox.ReadOnly = true;
            this._interestsTextBox.Size = new System.Drawing.Size(100, 21);
            this._interestsTextBox.TabIndex = 34;
            this._interestsTextBox.TabStop = false;
            this._interestsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(101, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Award Amount:";
            // 
            // _awardAmountTextBox
            // 
            this._awardAmountTextBox.Location = new System.Drawing.Point(189, 165);
            this._awardAmountTextBox.Name = "_awardAmountTextBox";
            this._awardAmountTextBox.ReadOnly = true;
            this._awardAmountTextBox.Size = new System.Drawing.Size(100, 21);
            this._awardAmountTextBox.TabIndex = 32;
            this._awardAmountTextBox.TabStop = false;
            this._awardAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(149, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Payment Completion Amount:";
            // 
            // _paymentCompletionAmountTextBox
            // 
            this._paymentCompletionAmountTextBox.Location = new System.Drawing.Point(189, 138);
            this._paymentCompletionAmountTextBox.Name = "_paymentCompletionAmountTextBox";
            this._paymentCompletionAmountTextBox.ReadOnly = true;
            this._paymentCompletionAmountTextBox.Size = new System.Drawing.Size(100, 21);
            this._paymentCompletionAmountTextBox.TabIndex = 30;
            this._paymentCompletionAmountTextBox.TabStop = false;
            this._paymentCompletionAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(106, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Maturity Date:";
            // 
            // _maturityDateTextBox
            // 
            this._maturityDateTextBox.Location = new System.Drawing.Point(189, 111);
            this._maturityDateTextBox.Name = "_maturityDateTextBox";
            this._maturityDateTextBox.ReadOnly = true;
            this._maturityDateTextBox.Size = new System.Drawing.Size(100, 21);
            this._maturityDateTextBox.TabIndex = 28;
            this._maturityDateTextBox.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(97, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 13);
            this.label13.TabIndex = 41;
            this.label13.Text = "Application Date:";
            // 
            // _applicationDateTextBox
            // 
            this._applicationDateTextBox.Location = new System.Drawing.Point(189, 57);
            this._applicationDateTextBox.Name = "_applicationDateTextBox";
            this._applicationDateTextBox.ReadOnly = true;
            this._applicationDateTextBox.Size = new System.Drawing.Size(100, 21);
            this._applicationDateTextBox.TabIndex = 40;
            this._applicationDateTextBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Payment Completion Date:";
            // 
            // _paymentCompletionDateTextBox
            // 
            this._paymentCompletionDateTextBox.Location = new System.Drawing.Point(189, 84);
            this._paymentCompletionDateTextBox.Name = "_paymentCompletionDateTextBox";
            this._paymentCompletionDateTextBox.ReadOnly = true;
            this._paymentCompletionDateTextBox.Size = new System.Drawing.Size(100, 21);
            this._paymentCompletionDateTextBox.TabIndex = 42;
            this._paymentCompletionDateTextBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Avail Option:";
            // 
            // _availOptionTextBox
            // 
            this._availOptionTextBox.Location = new System.Drawing.Point(189, 30);
            this._availOptionTextBox.Name = "_availOptionTextBox";
            this._availOptionTextBox.ReadOnly = true;
            this._availOptionTextBox.Size = new System.Drawing.Size(100, 21);
            this._availOptionTextBox.TabIndex = 44;
            this._availOptionTextBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Disbursed Amount:";
            // 
            // _disbursedAmountTextBox
            // 
            this._disbursedAmountTextBox.Location = new System.Drawing.Point(189, 248);
            this._disbursedAmountTextBox.Name = "_disbursedAmountTextBox";
            this._disbursedAmountTextBox.ReadOnly = true;
            this._disbursedAmountTextBox.Size = new System.Drawing.Size(100, 21);
            this._disbursedAmountTextBox.TabIndex = 46;
            this._disbursedAmountTextBox.TabStop = false;
            this._disbursedAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Maximum Withdrawable Amount:";
            // 
            // _maximumWithdrawableAmountTextBox
            // 
            this._maximumWithdrawableAmountTextBox.Location = new System.Drawing.Point(189, 275);
            this._maximumWithdrawableAmountTextBox.Name = "_maximumWithdrawableAmountTextBox";
            this._maximumWithdrawableAmountTextBox.ReadOnly = true;
            this._maximumWithdrawableAmountTextBox.Size = new System.Drawing.Size(100, 21);
            this._maximumWithdrawableAmountTextBox.TabIndex = 48;
            this._maximumWithdrawableAmountTextBox.TabStop = false;
            this._maximumWithdrawableAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PensionPlanWithdrawalAssessmentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 395);
            this.Name = "PensionPlanWithdrawalAssessmentView";
            this.Text = "Pension Plan Withdrawal Assessment";
            this.Shown += new System.EventHandler(this.PensionPlanWithdrawalAssessmentView_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.TextBox _payedAmountTextBox;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.TextBox _withdrawAmountTextBox;
        protected System.Windows.Forms.Label label9;
        protected System.Windows.Forms.TextBox _interestsTextBox;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.TextBox _awardAmountTextBox;
        protected System.Windows.Forms.Label label11;
        protected System.Windows.Forms.TextBox _paymentCompletionAmountTextBox;
        protected System.Windows.Forms.Label label12;
        protected System.Windows.Forms.TextBox _maturityDateTextBox;
        protected System.Windows.Forms.Label label13;
        protected System.Windows.Forms.TextBox _applicationDateTextBox;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox _paymentCompletionDateTextBox;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox _availOptionTextBox;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox _disbursedAmountTextBox;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox _maximumWithdrawableAmountTextBox;
    }
}