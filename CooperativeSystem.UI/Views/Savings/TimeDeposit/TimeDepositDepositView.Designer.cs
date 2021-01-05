namespace CooperativeSystem.UI.Views.Savings.TimeDeposit
{
    partial class TimeDepositDepositView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._termsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this._amountTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._maturityDateTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._cancelButton = new System.Windows.Forms.Button();
            this._acceptButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._termsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._termsNumericUpDown);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this._amountTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this._maturityDateTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 111);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // _termsNumericUpDown
            // 
            this._termsNumericUpDown.Location = new System.Drawing.Point(129, 47);
            this._termsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._termsNumericUpDown.Name = "_termsNumericUpDown";
            this._termsNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._termsNumericUpDown.Size = new System.Drawing.Size(101, 21);
            this._termsNumericUpDown.TabIndex = 1;
            this._termsNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this._termsNumericUpDown.ValueChanged += new System.EventHandler(this.TermsNumericUpDown_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Amount:";
            // 
            // _amountTextBox
            // 
            this._amountTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._amountTextBox.Location = new System.Drawing.Point(130, 20);
            this._amountTextBox.Name = "_amountTextBox";
            this._amountTextBox.Size = new System.Drawing.Size(100, 21);
            this._amountTextBox.TabIndex = 0;
            this._amountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Maturity Date:";
            // 
            // _maturityDateTextBox
            // 
            this._maturityDateTextBox.Location = new System.Drawing.Point(130, 74);
            this._maturityDateTextBox.Name = "_maturityDateTextBox";
            this._maturityDateTextBox.ReadOnly = true;
            this._maturityDateTextBox.Size = new System.Drawing.Size(100, 21);
            this._maturityDateTextBox.TabIndex = 2;
            this._maturityDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Terms:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 155);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(300, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._cancelButton.Location = new System.Drawing.Point(213, 129);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 12;
            this._cancelButton.TabStop = false;
            this._cancelButton.Text = "&Cancel";
            this._cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _acceptButton
            // 
            this._acceptButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._acceptButton.Location = new System.Drawing.Point(132, 129);
            this._acceptButton.Name = "_acceptButton";
            this._acceptButton.Size = new System.Drawing.Size(75, 23);
            this._acceptButton.TabIndex = 11;
            this._acceptButton.TabStop = false;
            this._acceptButton.Text = "&Accept";
            this._acceptButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._acceptButton.UseVisualStyleBackColor = true;
            this._acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // TimeDepositDepositView
            // 
            this.AcceptButton = this._acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(300, 177);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._acceptButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "TimeDepositDepositView";
            this.Text = "Time Deposit";
            this.Shown += new System.EventHandler(this.TimeDepositDepositView_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._termsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button _cancelButton;
        protected System.Windows.Forms.Button _acceptButton;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.TextBox _amountTextBox;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox _maturityDateTextBox;
        protected System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown _termsNumericUpDown;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}