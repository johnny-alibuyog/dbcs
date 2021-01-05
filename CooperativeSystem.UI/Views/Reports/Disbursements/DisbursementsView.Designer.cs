namespace CooperativeSystem.UI.Views.Reports.Disbursements
{
    partial class DisbursementsView
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
            this._yearlyDisbursementRadioButton = new System.Windows.Forms.RadioButton();
            this._monthlyDisbursementRadioButton = new System.Windows.Forms.RadioButton();
            this._dailyDisbursementRadioButton = new System.Windows.Forms.RadioButton();
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
            this._monthCalendar.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._yearlyDisbursementRadioButton);
            this.groupBox2.Controls.Add(this._monthlyDisbursementRadioButton);
            this.groupBox2.Controls.Add(this._dailyDisbursementRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(6, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 168);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Disbursement Type";
            // 
            // _yearlyDisbursementRadioButton
            // 
            this._yearlyDisbursementRadioButton.AutoSize = true;
            this._yearlyDisbursementRadioButton.Location = new System.Drawing.Point(54, 107);
            this._yearlyDisbursementRadioButton.Name = "_yearlyDisbursementRadioButton";
            this._yearlyDisbursementRadioButton.Size = new System.Drawing.Size(123, 17);
            this._yearlyDisbursementRadioButton.TabIndex = 3;
            this._yearlyDisbursementRadioButton.TabStop = true;
            this._yearlyDisbursementRadioButton.Text = "Yearly Disbursement";
            this._yearlyDisbursementRadioButton.UseVisualStyleBackColor = true;
            // 
            // _monthlyDisbursementRadioButton
            // 
            this._monthlyDisbursementRadioButton.AutoSize = true;
            this._monthlyDisbursementRadioButton.Location = new System.Drawing.Point(54, 70);
            this._monthlyDisbursementRadioButton.Name = "_monthlyDisbursementRadioButton";
            this._monthlyDisbursementRadioButton.Size = new System.Drawing.Size(131, 17);
            this._monthlyDisbursementRadioButton.TabIndex = 2;
            this._monthlyDisbursementRadioButton.TabStop = true;
            this._monthlyDisbursementRadioButton.Text = "Monthly Disbursement";
            this._monthlyDisbursementRadioButton.UseVisualStyleBackColor = true;
            // 
            // _dailyDisbursementRadioButton
            // 
            this._dailyDisbursementRadioButton.AutoSize = true;
            this._dailyDisbursementRadioButton.Location = new System.Drawing.Point(54, 33);
            this._dailyDisbursementRadioButton.Name = "_dailyDisbursementRadioButton";
            this._dailyDisbursementRadioButton.Size = new System.Drawing.Size(116, 17);
            this._dailyDisbursementRadioButton.TabIndex = 1;
            this._dailyDisbursementRadioButton.TabStop = true;
            this._dailyDisbursementRadioButton.Text = "Daily Disbursement";
            this._dailyDisbursementRadioButton.UseVisualStyleBackColor = true;
            // 
            // _generateButton
            // 
            this._generateButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._generateButton.Location = new System.Drawing.Point(309, 218);
            this._generateButton.Name = "_generateButton";
            this._generateButton.Size = new System.Drawing.Size(79, 23);
            this._generateButton.TabIndex = 8;
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
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // DisbursementsView
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
            this.Name = "DisbursementsView";
            this.Text = "Disbursements";
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
        private System.Windows.Forms.MonthCalendar _monthCalendar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton _yearlyDisbursementRadioButton;
        private System.Windows.Forms.RadioButton _monthlyDisbursementRadioButton;
        private System.Windows.Forms.RadioButton _dailyDisbursementRadioButton;
    }
}