namespace CooperativeSystem.UI.Views.MiscellaneousIncomes
{
    partial class MiscellaneousIncomeAdjustmentView
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
            this.label4 = new System.Windows.Forms.Label();
            this._adjustmentDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._generateVoucherButton = new System.Windows.Forms.Button();
            this._restartVoucherCheckBox = new System.Windows.Forms.CheckBox();
            this._clearButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this._voucherNumberTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._sequenceTextBox = new System.Windows.Forms.TextBox();
            this._acceptButton = new System.Windows.Forms.Button();
            this._closeButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this._remarksTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this._amountTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Adjustment Date:";
            // 
            // _adjustmentDateTimePicker
            // 
            this._adjustmentDateTimePicker.CustomFormat = " MMMM dd, yyyy";
            this._adjustmentDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._adjustmentDateTimePicker.Location = new System.Drawing.Point(340, 12);
            this._adjustmentDateTimePicker.Name = "_adjustmentDateTimePicker";
            this._adjustmentDateTimePicker.Size = new System.Drawing.Size(156, 21);
            this._adjustmentDateTimePicker.TabIndex = 3;
            // 
            // _generateVoucherButton
            // 
            this._generateVoucherButton.Enabled = false;
            this._generateVoucherButton.Location = new System.Drawing.Point(242, 40);
            this._generateVoucherButton.Name = "_generateVoucherButton";
            this._generateVoucherButton.Size = new System.Drawing.Size(75, 23);
            this._generateVoucherButton.TabIndex = 62;
            this._generateVoucherButton.TabStop = false;
            this._generateVoucherButton.Text = "Generate";
            this._generateVoucherButton.UseVisualStyleBackColor = true;
            this._generateVoucherButton.Click += new System.EventHandler(this.GenerateVoucherButton_Click);
            // 
            // _restartVoucherCheckBox
            // 
            this._restartVoucherCheckBox.AutoSize = true;
            this._restartVoucherCheckBox.Location = new System.Drawing.Point(47, 44);
            this._restartVoucherCheckBox.Name = "_restartVoucherCheckBox";
            this._restartVoucherCheckBox.Size = new System.Drawing.Size(62, 17);
            this._restartVoucherCheckBox.TabIndex = 61;
            this._restartVoucherCheckBox.Text = "Restart";
            this._restartVoucherCheckBox.UseVisualStyleBackColor = true;
            this._restartVoucherCheckBox.CheckedChanged += new System.EventHandler(this.RestartVoucherCheckBox_CheckedChanged);
            // 
            // _clearButton
            // 
            this._clearButton.Location = new System.Drawing.Point(338, 201);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(75, 23);
            this._clearButton.TabIndex = 59;
            this._clearButton.TabStop = false;
            this._clearButton.Text = "Cle&ar";
            this._clearButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._clearButton.UseVisualStyleBackColor = true;
            this._clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Voucher Number:";
            // 
            // _voucherNumberTextBox
            // 
            this._voucherNumberTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._voucherNumberTextBox.Location = new System.Drawing.Point(115, 14);
            this._voucherNumberTextBox.Name = "_voucherNumberTextBox";
            this._voucherNumberTextBox.ReadOnly = true;
            this._voucherNumberTextBox.Size = new System.Drawing.Size(121, 22);
            this._voucherNumberTextBox.TabIndex = 55;
            this._voucherNumberTextBox.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 227);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(509, 22);
            this.statusStrip1.TabIndex = 56;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _sequenceTextBox
            // 
            this._sequenceTextBox.Enabled = false;
            this._sequenceTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._sequenceTextBox.Location = new System.Drawing.Point(115, 41);
            this._sequenceTextBox.Name = "_sequenceTextBox";
            this._sequenceTextBox.Size = new System.Drawing.Size(121, 22);
            this._sequenceTextBox.TabIndex = 1;
            this._sequenceTextBox.TabStop = false;
            // 
            // _acceptButton
            // 
            this._acceptButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._acceptButton.Location = new System.Drawing.Point(257, 201);
            this._acceptButton.Name = "_acceptButton";
            this._acceptButton.Size = new System.Drawing.Size(75, 23);
            this._acceptButton.TabIndex = 58;
            this._acceptButton.TabStop = false;
            this._acceptButton.Text = "&Accept";
            this._acceptButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(421, 201);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 57;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this._remarksTextBox);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this._amountTextBox);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Location = new System.Drawing.Point(12, 69);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(484, 126);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            // 
            // _remarksTextBox
            // 
            this._remarksTextBox.Location = new System.Drawing.Point(103, 47);
            this._remarksTextBox.Multiline = true;
            this._remarksTextBox.Name = "_remarksTextBox";
            this._remarksTextBox.ReadOnly = true;
            this._remarksTextBox.Size = new System.Drawing.Size(274, 73);
            this._remarksTextBox.TabIndex = 1;
            this._remarksTextBox.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(45, 50);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "Remarks:";
            // 
            // _amountTextBox
            // 
            this._amountTextBox.Location = new System.Drawing.Point(103, 20);
            this._amountTextBox.Name = "_amountTextBox";
            this._amountTextBox.Size = new System.Drawing.Size(100, 21);
            this._amountTextBox.TabIndex = 0;
            this._amountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._amountTextBox.TextChanged += new System.EventHandler(this.AmountTextBox_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(49, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Amount:";
            // 
            // MiscellaneousIncomeAdjustmentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(509, 249);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._adjustmentDateTimePicker);
            this.Controls.Add(this._acceptButton);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._generateVoucherButton);
            this.Controls.Add(this._restartVoucherCheckBox);
            this.Controls.Add(this._clearButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._voucherNumberTextBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._sequenceTextBox);
            this.Name = "MiscellaneousIncomeAdjustmentView";
            this.Text = "Miscellaneous Income Adjustment";
            this.Shown += new System.EventHandler(this.MiscellaneousIncomeAdjustmentView_Shown);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker _adjustmentDateTimePicker;
        private System.Windows.Forms.Button _acceptButton;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.Button _generateVoucherButton;
        private System.Windows.Forms.CheckBox _restartVoucherCheckBox;
        private System.Windows.Forms.Button _clearButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _voucherNumberTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox _sequenceTextBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox _remarksTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox _amountTextBox;
        private System.Windows.Forms.Label label16;
    }
}