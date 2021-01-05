namespace CooperativeSystem.UI.Views.Loans
{
    partial class InterestRebateView
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
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            this._closeButton = new System.Windows.Forms.Button();
            this._generateReceiptButton = new System.Windows.Forms.Button();
            this._restartVoucherCheckBox = new System.Windows.Forms.CheckBox();
            this._sequenceTextBox = new System.Windows.Forms.TextBox();
            this._voucherNumberTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this._receiptDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this._groupBox = new System.Windows.Forms.GroupBox();
            this._monthsPaidTextBox = new System.Windows.Forms.TextBox();
            this._dueDateTextBox = new System.Windows.Forms.TextBox();
            this._settlementDateTextBox = new System.Windows.Forms.TextBox();
            this._interestRebateTextBox = new System.Windows.Forms.TextBox();
            this._interestTextBox = new System.Windows.Forms.TextBox();
            this._interestRateTextBox = new System.Windows.Forms.TextBox();
            this._loanAmountTextBox = new System.Windows.Forms.TextBox();
            this._paymentModeTextBox = new System.Windows.Forms.TextBox();
            this._termsTextBox = new System.Windows.Forms.TextBox();
            this._loanDateTextBox = new System.Windows.Forms.TextBox();
            this._acceptButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label11 = new System.Windows.Forms.Label();
            this._loansComboBox = new System.Windows.Forms.ComboBox();
            label10 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this._groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(80, 77);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(56, 13);
            label10.TabIndex = 55;
            label10.Text = "Due Date:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(47, 50);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(89, 13);
            label1.TabIndex = 53;
            label1.Text = "Settlement Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(297, 131);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(88, 13);
            label5.TabIndex = 51;
            label5.Text = "Interest Rebate:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(335, 77);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(50, 13);
            label6.TabIndex = 50;
            label6.Text = "Interest:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(311, 23);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(74, 13);
            label7.TabIndex = 47;
            label7.Text = "Loan Amount:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(309, 50);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(76, 13);
            label8.TabIndex = 46;
            label8.Text = "Interest Rate:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(54, 104);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(82, 13);
            label4.TabIndex = 42;
            label4.Text = "Payment Mode:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(96, 131);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(40, 13);
            label9.TabIndex = 39;
            label9.Text = "Terms:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(76, 23);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(60, 13);
            label3.TabIndex = 35;
            label3.Text = "Loan Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(287, 104);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(98, 13);
            label2.TabIndex = 57;
            label2.Text = "Months Rebatable:";
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(462, 229);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 86;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = true;
            // 
            // _generateReceiptButton
            // 
            this._generateReceiptButton.Enabled = false;
            this._generateReceiptButton.Location = new System.Drawing.Point(462, 39);
            this._generateReceiptButton.Name = "_generateReceiptButton";
            this._generateReceiptButton.Size = new System.Drawing.Size(75, 23);
            this._generateReceiptButton.TabIndex = 85;
            this._generateReceiptButton.TabStop = false;
            this._generateReceiptButton.Text = "Generate";
            this._generateReceiptButton.UseVisualStyleBackColor = true;
            this._generateReceiptButton.Click += new System.EventHandler(this.GenerateReceiptButton_Click);
            // 
            // _restartVoucherCheckBox
            // 
            this._restartVoucherCheckBox.AutoSize = true;
            this._restartVoucherCheckBox.Location = new System.Drawing.Point(288, 43);
            this._restartVoucherCheckBox.Name = "_restartVoucherCheckBox";
            this._restartVoucherCheckBox.Size = new System.Drawing.Size(62, 17);
            this._restartVoucherCheckBox.TabIndex = 84;
            this._restartVoucherCheckBox.Text = "Restart";
            this._restartVoucherCheckBox.UseVisualStyleBackColor = true;
            this._restartVoucherCheckBox.CheckedChanged += new System.EventHandler(this.RestartVoucherCheckBox_CheckedChanged);
            // 
            // _sequenceTextBox
            // 
            this._sequenceTextBox.Enabled = false;
            this._sequenceTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._sequenceTextBox.Location = new System.Drawing.Point(356, 40);
            this._sequenceTextBox.Name = "_sequenceTextBox";
            this._sequenceTextBox.Size = new System.Drawing.Size(100, 22);
            this._sequenceTextBox.TabIndex = 79;
            this._sequenceTextBox.TabStop = false;
            // 
            // _voucherNumberTextBox
            // 
            this._voucherNumberTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._voucherNumberTextBox.Location = new System.Drawing.Point(124, 40);
            this._voucherNumberTextBox.Name = "_voucherNumberTextBox";
            this._voucherNumberTextBox.ReadOnly = true;
            this._voucherNumberTextBox.Size = new System.Drawing.Size(121, 22);
            this._voucherNumberTextBox.TabIndex = 83;
            this._voucherNumberTextBox.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 82;
            this.label12.Text = "Voucher Number:";
            // 
            // _receiptDateTimePicker
            // 
            this._receiptDateTimePicker.CustomFormat = " MMMM dd, yyyy";
            this._receiptDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._receiptDateTimePicker.Location = new System.Drawing.Point(356, 13);
            this._receiptDateTimePicker.Name = "_receiptDateTimePicker";
            this._receiptDateTimePicker.Size = new System.Drawing.Size(181, 21);
            this._receiptDateTimePicker.TabIndex = 80;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(277, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 13);
            this.label13.TabIndex = 81;
            this.label13.Text = "Receipt Date:";
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this._monthsPaidTextBox);
            this._groupBox.Controls.Add(label2);
            this._groupBox.Controls.Add(this._dueDateTextBox);
            this._groupBox.Controls.Add(label10);
            this._groupBox.Controls.Add(this._settlementDateTextBox);
            this._groupBox.Controls.Add(label1);
            this._groupBox.Controls.Add(this._interestRebateTextBox);
            this._groupBox.Controls.Add(label5);
            this._groupBox.Controls.Add(this._interestTextBox);
            this._groupBox.Controls.Add(label6);
            this._groupBox.Controls.Add(this._interestRateTextBox);
            this._groupBox.Controls.Add(label7);
            this._groupBox.Controls.Add(this._loanAmountTextBox);
            this._groupBox.Controls.Add(label8);
            this._groupBox.Controls.Add(this._paymentModeTextBox);
            this._groupBox.Controls.Add(label4);
            this._groupBox.Controls.Add(this._termsTextBox);
            this._groupBox.Controls.Add(label9);
            this._groupBox.Controls.Add(this._loanDateTextBox);
            this._groupBox.Controls.Add(label3);
            this._groupBox.Location = new System.Drawing.Point(12, 68);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(525, 155);
            this._groupBox.TabIndex = 78;
            this._groupBox.TabStop = false;
            this._groupBox.Text = "Late Payment Charge";
            // 
            // _monthsPaidTextBox
            // 
            this._monthsPaidTextBox.Location = new System.Drawing.Point(391, 101);
            this._monthsPaidTextBox.Name = "_monthsPaidTextBox";
            this._monthsPaidTextBox.ReadOnly = true;
            this._monthsPaidTextBox.Size = new System.Drawing.Size(100, 21);
            this._monthsPaidTextBox.TabIndex = 56;
            this._monthsPaidTextBox.TabStop = false;
            this._monthsPaidTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _dueDateTextBox
            // 
            this._dueDateTextBox.Location = new System.Drawing.Point(142, 74);
            this._dueDateTextBox.Name = "_dueDateTextBox";
            this._dueDateTextBox.ReadOnly = true;
            this._dueDateTextBox.Size = new System.Drawing.Size(100, 21);
            this._dueDateTextBox.TabIndex = 54;
            this._dueDateTextBox.TabStop = false;
            this._dueDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _settlementDateTextBox
            // 
            this._settlementDateTextBox.Location = new System.Drawing.Point(142, 47);
            this._settlementDateTextBox.Name = "_settlementDateTextBox";
            this._settlementDateTextBox.ReadOnly = true;
            this._settlementDateTextBox.Size = new System.Drawing.Size(100, 21);
            this._settlementDateTextBox.TabIndex = 52;
            this._settlementDateTextBox.TabStop = false;
            this._settlementDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _interestRebateTextBox
            // 
            this._interestRebateTextBox.Location = new System.Drawing.Point(391, 128);
            this._interestRebateTextBox.Name = "_interestRebateTextBox";
            this._interestRebateTextBox.ReadOnly = true;
            this._interestRebateTextBox.Size = new System.Drawing.Size(100, 21);
            this._interestRebateTextBox.TabIndex = 49;
            this._interestRebateTextBox.TabStop = false;
            this._interestRebateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _interestTextBox
            // 
            this._interestTextBox.Location = new System.Drawing.Point(391, 74);
            this._interestTextBox.Name = "_interestTextBox";
            this._interestTextBox.ReadOnly = true;
            this._interestTextBox.Size = new System.Drawing.Size(100, 21);
            this._interestTextBox.TabIndex = 48;
            this._interestTextBox.TabStop = false;
            this._interestTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _interestRateTextBox
            // 
            this._interestRateTextBox.Location = new System.Drawing.Point(391, 47);
            this._interestRateTextBox.Name = "_interestRateTextBox";
            this._interestRateTextBox.ReadOnly = true;
            this._interestRateTextBox.Size = new System.Drawing.Size(100, 21);
            this._interestRateTextBox.TabIndex = 45;
            this._interestRateTextBox.TabStop = false;
            this._interestRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _loanAmountTextBox
            // 
            this._loanAmountTextBox.Location = new System.Drawing.Point(391, 20);
            this._loanAmountTextBox.Name = "_loanAmountTextBox";
            this._loanAmountTextBox.ReadOnly = true;
            this._loanAmountTextBox.Size = new System.Drawing.Size(100, 21);
            this._loanAmountTextBox.TabIndex = 44;
            this._loanAmountTextBox.TabStop = false;
            this._loanAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _paymentModeTextBox
            // 
            this._paymentModeTextBox.Location = new System.Drawing.Point(142, 101);
            this._paymentModeTextBox.Name = "_paymentModeTextBox";
            this._paymentModeTextBox.ReadOnly = true;
            this._paymentModeTextBox.Size = new System.Drawing.Size(100, 21);
            this._paymentModeTextBox.TabIndex = 40;
            this._paymentModeTextBox.TabStop = false;
            this._paymentModeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _termsTextBox
            // 
            this._termsTextBox.Location = new System.Drawing.Point(142, 128);
            this._termsTextBox.Name = "_termsTextBox";
            this._termsTextBox.ReadOnly = true;
            this._termsTextBox.Size = new System.Drawing.Size(100, 21);
            this._termsTextBox.TabIndex = 1;
            this._termsTextBox.TabStop = false;
            this._termsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _loanDateTextBox
            // 
            this._loanDateTextBox.Location = new System.Drawing.Point(142, 20);
            this._loanDateTextBox.Name = "_loanDateTextBox";
            this._loanDateTextBox.ReadOnly = true;
            this._loanDateTextBox.Size = new System.Drawing.Size(100, 21);
            this._loanDateTextBox.TabIndex = 0;
            this._loanDateTextBox.TabStop = false;
            this._loanDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _acceptButton
            // 
            this._acceptButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._acceptButton.Location = new System.Drawing.Point(381, 229);
            this._acceptButton.Name = "_acceptButton";
            this._acceptButton.Size = new System.Drawing.Size(75, 23);
            this._acceptButton.TabIndex = 76;
            this._acceptButton.TabStop = false;
            this._acceptButton.Text = "&Accept";
            this._acceptButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._acceptButton.UseVisualStyleBackColor = true;
            this._acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 255);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(549, 22);
            this.statusStrip1.TabIndex = 75;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(79, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 73;
            this.label11.Text = "Loans:";
            // 
            // _loansComboBox
            // 
            this._loansComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._loansComboBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this._loansComboBox.FormattingEnabled = true;
            this._loansComboBox.Location = new System.Drawing.Point(124, 12);
            this._loansComboBox.Name = "_loansComboBox";
            this._loansComboBox.Size = new System.Drawing.Size(121, 22);
            this._loansComboBox.TabIndex = 72;
            this._loansComboBox.SelectedValueChanged += new System.EventHandler(this.LoansComboBox_SelectedValueChanged);
            // 
            // InterestRebateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(549, 277);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._generateReceiptButton);
            this.Controls.Add(this._restartVoucherCheckBox);
            this.Controls.Add(this._sequenceTextBox);
            this.Controls.Add(this._voucherNumberTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this._receiptDateTimePicker);
            this.Controls.Add(this.label13);
            this.Controls.Add(this._groupBox);
            this.Controls.Add(this._acceptButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this._loansComboBox);
            this.Name = "InterestRebateView";
            this.Text = "Interest Rebate";
            this.Shown += new System.EventHandler(this.InterestRebateView_Shown);
            this._groupBox.ResumeLayout(false);
            this._groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox _loansComboBox;
        private System.Windows.Forms.Button _acceptButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox _groupBox;
        private System.Windows.Forms.TextBox _settlementDateTextBox;
        private System.Windows.Forms.TextBox _interestRebateTextBox;
        private System.Windows.Forms.TextBox _interestTextBox;
        private System.Windows.Forms.TextBox _interestRateTextBox;
        private System.Windows.Forms.TextBox _loanAmountTextBox;
        private System.Windows.Forms.TextBox _paymentModeTextBox;
        private System.Windows.Forms.TextBox _termsTextBox;
        private System.Windows.Forms.TextBox _loanDateTextBox;
        private System.Windows.Forms.TextBox _dueDateTextBox;
        private System.Windows.Forms.Button _generateReceiptButton;
        private System.Windows.Forms.CheckBox _restartVoucherCheckBox;
        private System.Windows.Forms.TextBox _sequenceTextBox;
        private System.Windows.Forms.TextBox _voucherNumberTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker _receiptDateTimePicker;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.TextBox _monthsPaidTextBox;
    }
}