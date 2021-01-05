namespace CooperativeSystem.UI.Views.MiscellaneousIncomes
{
    partial class MiscellaneousIncomeCashReceiptView
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
            this._generateReceiptButton = new System.Windows.Forms.Button();
            this._restartReceiptCheckBox = new System.Windows.Forms.CheckBox();
            this._sequenceTextBox = new System.Windows.Forms.TextBox();
            this._clearButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this._remarksTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this._amountTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this._officialReceiptNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._receiptDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._acceptButton = new System.Windows.Forms.Button();
            this._closeButton = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // _generateReceiptButton
            // 
            this._generateReceiptButton.Enabled = false;
            this._generateReceiptButton.Location = new System.Drawing.Point(255, 41);
            this._generateReceiptButton.Name = "_generateReceiptButton";
            this._generateReceiptButton.Size = new System.Drawing.Size(75, 23);
            this._generateReceiptButton.TabIndex = 44;
            this._generateReceiptButton.TabStop = false;
            this._generateReceiptButton.Text = "Generate";
            this._generateReceiptButton.UseVisualStyleBackColor = true;
            this._generateReceiptButton.Click += new System.EventHandler(this.GenerateReceiptButton_Click);
            // 
            // _restartReceiptCheckBox
            // 
            this._restartReceiptCheckBox.AutoSize = true;
            this._restartReceiptCheckBox.Location = new System.Drawing.Point(81, 45);
            this._restartReceiptCheckBox.Name = "_restartReceiptCheckBox";
            this._restartReceiptCheckBox.Size = new System.Drawing.Size(62, 17);
            this._restartReceiptCheckBox.TabIndex = 43;
            this._restartReceiptCheckBox.Text = "Restart";
            this._restartReceiptCheckBox.UseVisualStyleBackColor = true;
            this._restartReceiptCheckBox.CheckedChanged += new System.EventHandler(this.RestartReceiptCheckBox_CheckedChanged);
            // 
            // _sequenceTextBox
            // 
            this._sequenceTextBox.Enabled = false;
            this._sequenceTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._sequenceTextBox.Location = new System.Drawing.Point(149, 42);
            this._sequenceTextBox.Name = "_sequenceTextBox";
            this._sequenceTextBox.Size = new System.Drawing.Size(100, 22);
            this._sequenceTextBox.TabIndex = 0;
            this._sequenceTextBox.TabStop = false;
            // 
            // _clearButton
            // 
            this._clearButton.Location = new System.Drawing.Point(348, 202);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(75, 23);
            this._clearButton.TabIndex = 41;
            this._clearButton.TabStop = false;
            this._clearButton.Text = "Cle&ar";
            this._clearButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._clearButton.UseVisualStyleBackColor = true;
            this._clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this._remarksTextBox);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this._amountTextBox);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Location = new System.Drawing.Point(12, 70);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(492, 126);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.TabStop = false;
            // 
            // _remarksTextBox
            // 
            this._remarksTextBox.Location = new System.Drawing.Point(137, 47);
            this._remarksTextBox.Multiline = true;
            this._remarksTextBox.Name = "_remarksTextBox";
            this._remarksTextBox.Size = new System.Drawing.Size(274, 73);
            this._remarksTextBox.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(79, 50);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "Remarks:";
            // 
            // _amountTextBox
            // 
            this._amountTextBox.Location = new System.Drawing.Point(137, 20);
            this._amountTextBox.Name = "_amountTextBox";
            this._amountTextBox.Size = new System.Drawing.Size(100, 21);
            this._amountTextBox.TabIndex = 0;
            this._amountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(83, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Amount:";
            // 
            // _officialReceiptNumber
            // 
            this._officialReceiptNumber.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._officialReceiptNumber.Location = new System.Drawing.Point(149, 14);
            this._officialReceiptNumber.Name = "_officialReceiptNumber";
            this._officialReceiptNumber.ReadOnly = true;
            this._officialReceiptNumber.Size = new System.Drawing.Size(100, 22);
            this._officialReceiptNumber.TabIndex = 38;
            this._officialReceiptNumber.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Official Receipt Number:";
            // 
            // _receiptDateTimePicker
            // 
            this._receiptDateTimePicker.CustomFormat = " MMMM dd, yyyy";
            this._receiptDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._receiptDateTimePicker.Location = new System.Drawing.Point(348, 12);
            this._receiptDateTimePicker.Name = "_receiptDateTimePicker";
            this._receiptDateTimePicker.Size = new System.Drawing.Size(156, 21);
            this._receiptDateTimePicker.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Receipt Date:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 228);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(516, 22);
            this.statusStrip1.TabIndex = 45;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _acceptButton
            // 
            this._acceptButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._acceptButton.Location = new System.Drawing.Point(267, 202);
            this._acceptButton.Name = "_acceptButton";
            this._acceptButton.Size = new System.Drawing.Size(75, 23);
            this._acceptButton.TabIndex = 40;
            this._acceptButton.TabStop = false;
            this._acceptButton.Text = "&Accept";
            this._acceptButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._acceptButton.UseVisualStyleBackColor = true;
            this._acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(429, 202);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 39;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = true;
            // 
            // MiscellaneousIncomeCashReceiptView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(516, 250);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._generateReceiptButton);
            this.Controls.Add(this._restartReceiptCheckBox);
            this.Controls.Add(this._sequenceTextBox);
            this.Controls.Add(this._clearButton);
            this.Controls.Add(this._acceptButton);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this._officialReceiptNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._receiptDateTimePicker);
            this.Controls.Add(this.label4);
            this.Name = "MiscellaneousIncomeCashReceiptView";
            this.Text = "Miscellaneous Income Cash Receipt";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _generateReceiptButton;
        private System.Windows.Forms.CheckBox _restartReceiptCheckBox;
        private System.Windows.Forms.TextBox _sequenceTextBox;
        private System.Windows.Forms.Button _clearButton;
        private System.Windows.Forms.Button _acceptButton;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox _remarksTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox _amountTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox _officialReceiptNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker _receiptDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}