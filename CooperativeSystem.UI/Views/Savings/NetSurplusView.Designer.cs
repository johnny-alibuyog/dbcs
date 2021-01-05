namespace CooperativeSystem.UI.Views.Savings
{
    partial class NetSurplusView
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
            this._yearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._amountTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._saveButton = new System.Windows.Forms.Button();
            this._closeButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._yearNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._yearNumericUpDown);
            this.groupBox1.Controls.Add(this._amountTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 80);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // _yearNumericUpDown
            // 
            this._yearNumericUpDown.Location = new System.Drawing.Point(94, 20);
            this._yearNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this._yearNumericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._yearNumericUpDown.Name = "_yearNumericUpDown";
            this._yearNumericUpDown.Size = new System.Drawing.Size(100, 21);
            this._yearNumericUpDown.TabIndex = 5;
            this._yearNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._yearNumericUpDown.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this._yearNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._yearNumericUpDown.ValueChanged += new System.EventHandler(this.YearNumericUpDown_ValueChanged);
            // 
            // _amountTextBox
            // 
            this._amountTextBox.Location = new System.Drawing.Point(94, 47);
            this._amountTextBox.Name = "_amountTextBox";
            this._amountTextBox.Size = new System.Drawing.Size(100, 21);
            this._amountTextBox.TabIndex = 1;
            this._amountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Amount:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Year:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 124);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(276, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _saveButton
            // 
            this._saveButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._saveButton.Location = new System.Drawing.Point(108, 98);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(75, 23);
            this._saveButton.TabIndex = 6;
            this._saveButton.TabStop = false;
            this._saveButton.Text = "&Save";
            this._saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(189, 98);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 5;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = true;
            // 
            // NetSurplusView
            // 
            this.AcceptButton = this._saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(276, 146);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._closeButton);
            this.Name = "NetSurplusView";
            this.Text = "Net Surplus";
            this.Load += new System.EventHandler(this.NetSurplusView_Load);
            this.Shown += new System.EventHandler(this.NetSurplusView_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._yearNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _amountTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.NumericUpDown _yearNumericUpDown;
    }
}