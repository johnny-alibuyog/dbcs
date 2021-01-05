namespace CooperativeSystem.UI.Views.Plans.PensionPlan
{
    partial class AvailOptionView
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
            this._withMonthlyPensionCheckBox = new System.Windows.Forms.CheckBox();
            this._agingPeriodNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._availOptionNameTextBox = new System.Windows.Forms.TextBox();
            this._availOptionDescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this._awardAmountTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._agingPeriodNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // _saveButton
            // 
            this._saveButton.Location = new System.Drawing.Point(172, 260);
            this._saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // _closeButton
            // 
            this._closeButton.Location = new System.Drawing.Point(248, 260);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._withMonthlyPensionCheckBox);
            this.groupBox1.Controls.Add(this._agingPeriodNumericUpDown);
            this.groupBox1.Controls.Add(this._availOptionNameTextBox);
            this.groupBox1.Controls.Add(this._availOptionDescriptionRichTextBox);
            this.groupBox1.Controls.Add(this._awardAmountTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 241);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // _withMonthlyPensionCheckBox
            // 
            this._withMonthlyPensionCheckBox.AutoSize = true;
            this._withMonthlyPensionCheckBox.Location = new System.Drawing.Point(169, 101);
            this._withMonthlyPensionCheckBox.Name = "_withMonthlyPensionCheckBox";
            this._withMonthlyPensionCheckBox.Size = new System.Drawing.Size(95, 17);
            this._withMonthlyPensionCheckBox.TabIndex = 3;
            this._withMonthlyPensionCheckBox.Text = "(Check if true)";
            // 
            // _agingPeriodNumericUpDown
            // 
            this._agingPeriodNumericUpDown.Location = new System.Drawing.Point(169, 74);
            this._agingPeriodNumericUpDown.Name = "_agingPeriodNumericUpDown";
            this._agingPeriodNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._agingPeriodNumericUpDown.Size = new System.Drawing.Size(100, 21);
            this._agingPeriodNumericUpDown.TabIndex = 2;
            // 
            // _availOptionNameTextBox
            // 
            this._availOptionNameTextBox.Location = new System.Drawing.Point(169, 20);
            this._availOptionNameTextBox.Name = "_availOptionNameTextBox";
            this._availOptionNameTextBox.Size = new System.Drawing.Size(100, 21);
            this._availOptionNameTextBox.TabIndex = 0;
            // 
            // _availOptionDescriptionRichTextBox
            // 
            this._availOptionDescriptionRichTextBox.Location = new System.Drawing.Point(42, 145);
            this._availOptionDescriptionRichTextBox.Name = "_availOptionDescriptionRichTextBox";
            this._availOptionDescriptionRichTextBox.Size = new System.Drawing.Size(229, 85);
            this._availOptionDescriptionRichTextBox.TabIndex = 4;
            this._availOptionDescriptionRichTextBox.Text = "";
            // 
            // _awardAmountTextBox
            // 
            this._awardAmountTextBox.Location = new System.Drawing.Point(169, 47);
            this._awardAmountTextBox.Name = "_awardAmountTextBox";
            this._awardAmountTextBox.Size = new System.Drawing.Size(100, 21);
            this._awardAmountTextBox.TabIndex = 1;
            this._awardAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 139;
            this.label5.Text = "With Monthly Pension:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 138;
            this.label6.Text = "Aging Period:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 137;
            this.label4.Text = "Avail Option Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 136;
            this.label3.Text = "Award Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 134;
            this.label2.Text = "Avail Option Name:";
            // 
            // AvailOptionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 308);
            this.Controls.Add(this.groupBox1);
            this.Name = "AvailOptionView";
            this.Text = "AvailOptionView";
            this.Controls.SetChildIndex(this._saveButton, 0);
            this.Controls.SetChildIndex(this._closeButton, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._agingPeriodNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox _withMonthlyPensionCheckBox;
        private System.Windows.Forms.NumericUpDown _agingPeriodNumericUpDown;
        private System.Windows.Forms.TextBox _availOptionNameTextBox;
        private System.Windows.Forms.RichTextBox _availOptionDescriptionRichTextBox;
        private System.Windows.Forms.TextBox _awardAmountTextBox;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}