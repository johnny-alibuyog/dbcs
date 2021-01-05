namespace CooperativeSystem.UI.Views.Reports.Adjustments
{
    partial class AdjustmentsView
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._yearlyAdjustmentRadioButton = new System.Windows.Forms.RadioButton();
            this._monthlyAdjustmentRadioButton = new System.Windows.Forms.RadioButton();
            this._dailyAdjustmentRadioButton = new System.Windows.Forms.RadioButton();
            this._generateButton = new System.Windows.Forms.Button();
            this._closeButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 244);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(481, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._monthCalendar);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 200);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // _monthCalendar
            // 
            this._monthCalendar.Location = new System.Drawing.Point(218, 26);
            this._monthCalendar.Name = "_monthCalendar";
            this._monthCalendar.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._yearlyAdjustmentRadioButton);
            this.groupBox2.Controls.Add(this._monthlyAdjustmentRadioButton);
            this.groupBox2.Controls.Add(this._dailyAdjustmentRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(6, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 168);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adjustment Type";
            // 
            // _yearlyAdjustmentRadioButton
            // 
            this._yearlyAdjustmentRadioButton.AutoSize = true;
            this._yearlyAdjustmentRadioButton.Location = new System.Drawing.Point(54, 107);
            this._yearlyAdjustmentRadioButton.Name = "_yearlyAdjustmentRadioButton";
            this._yearlyAdjustmentRadioButton.Size = new System.Drawing.Size(113, 17);
            this._yearlyAdjustmentRadioButton.TabIndex = 3;
            this._yearlyAdjustmentRadioButton.TabStop = true;
            this._yearlyAdjustmentRadioButton.Text = "Yearly Adjustment";
            this._yearlyAdjustmentRadioButton.UseVisualStyleBackColor = true;
            // 
            // _monthlyAdjustmentRadioButton
            // 
            this._monthlyAdjustmentRadioButton.AutoSize = true;
            this._monthlyAdjustmentRadioButton.Location = new System.Drawing.Point(54, 70);
            this._monthlyAdjustmentRadioButton.Name = "_monthlyAdjustmentRadioButton";
            this._monthlyAdjustmentRadioButton.Size = new System.Drawing.Size(121, 17);
            this._monthlyAdjustmentRadioButton.TabIndex = 2;
            this._monthlyAdjustmentRadioButton.TabStop = true;
            this._monthlyAdjustmentRadioButton.Text = "Monthly Adjustment";
            this._monthlyAdjustmentRadioButton.UseVisualStyleBackColor = true;
            // 
            // _dailyAdjustmentRadioButton
            // 
            this._dailyAdjustmentRadioButton.AutoSize = true;
            this._dailyAdjustmentRadioButton.Location = new System.Drawing.Point(54, 33);
            this._dailyAdjustmentRadioButton.Name = "_dailyAdjustmentRadioButton";
            this._dailyAdjustmentRadioButton.Size = new System.Drawing.Size(106, 17);
            this._dailyAdjustmentRadioButton.TabIndex = 1;
            this._dailyAdjustmentRadioButton.TabStop = true;
            this._dailyAdjustmentRadioButton.Text = "Daily Adjustment";
            this._dailyAdjustmentRadioButton.UseVisualStyleBackColor = true;
            // 
            // _generateButton
            // 
            this._generateButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._generateButton.Location = new System.Drawing.Point(309, 218);
            this._generateButton.Name = "_generateButton";
            this._generateButton.Size = new System.Drawing.Size(79, 23);
            this._generateButton.TabIndex = 8;
            this._generateButton.TabStop = false;
            this._generateButton.Text = "&Generate";
            this._generateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._generateButton.UseVisualStyleBackColor = true;
            this._generateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(394, 218);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 9;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // AdjustmentsView
            // 
            this.AcceptButton = this._generateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(481, 266);
            this.Controls.Add(this._generateButton);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdjustmentsView";
            this.Text = "Adjustments";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _generateButton;
        protected System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton _yearlyAdjustmentRadioButton;
        private System.Windows.Forms.RadioButton _monthlyAdjustmentRadioButton;
        private System.Windows.Forms.RadioButton _dailyAdjustmentRadioButton;
        private System.Windows.Forms.MonthCalendar _monthCalendar;
    }
}