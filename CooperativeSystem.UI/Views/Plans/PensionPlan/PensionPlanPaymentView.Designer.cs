namespace CooperativeSystem.UI.Views.Plans.PensionPlan
{
    partial class PensionPlanPaymentView
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
            this.label5 = new System.Windows.Forms.Label();
            this._paymentAmountTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._amortizationTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._paymentModeTextBox = new System.Windows.Forms.TextBox();
            this._unpaidAmortizationTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(265, 146);
            // 
            // _acceptButton
            // 
            this._acceptButton.Location = new System.Drawing.Point(184, 146);
            this._acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._unpaidAmortizationTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this._paymentAmountTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._amortizationTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._paymentModeTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Size = new System.Drawing.Size(328, 128);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Unpaid Amortization:";
            // 
            // _paymentAmountTextBox
            // 
            this._paymentAmountTextBox.Location = new System.Drawing.Point(172, 101);
            this._paymentAmountTextBox.Name = "_paymentAmountTextBox";
            this._paymentAmountTextBox.Size = new System.Drawing.Size(100, 21);
            this._paymentAmountTextBox.TabIndex = 34;
            this._paymentAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Amortization:";
            // 
            // _amortizationTextBox
            // 
            this._amortizationTextBox.Location = new System.Drawing.Point(172, 47);
            this._amortizationTextBox.Name = "_amortizationTextBox";
            this._amortizationTextBox.ReadOnly = true;
            this._amortizationTextBox.Size = new System.Drawing.Size(100, 21);
            this._amortizationTextBox.TabIndex = 28;
            this._amortizationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Payment Mode:";
            // 
            // _paymentModeTextBox
            // 
            this._paymentModeTextBox.Location = new System.Drawing.Point(172, 20);
            this._paymentModeTextBox.Name = "_paymentModeTextBox";
            this._paymentModeTextBox.ReadOnly = true;
            this._paymentModeTextBox.Size = new System.Drawing.Size(100, 21);
            this._paymentModeTextBox.TabIndex = 26;
            this._paymentModeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _unpaidAmortizationTextBox
            // 
            this._unpaidAmortizationTextBox.Location = new System.Drawing.Point(172, 74);
            this._unpaidAmortizationTextBox.Name = "_unpaidAmortizationTextBox";
            this._unpaidAmortizationTextBox.ReadOnly = true;
            this._unpaidAmortizationTextBox.Size = new System.Drawing.Size(100, 21);
            this._unpaidAmortizationTextBox.TabIndex = 36;
            this._unpaidAmortizationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Payment Amount:";
            // 
            // PensionPlanPaymentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 194);
            this.Name = "PensionPlanPaymentView";
            this.Text = "Pension Plan Payment";
            this.Shown += new System.EventHandler(this.PensionPlanPaymentView_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.TextBox _paymentAmountTextBox;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox _amortizationTextBox;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox _paymentModeTextBox;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox _unpaidAmortizationTextBox;

    }
}