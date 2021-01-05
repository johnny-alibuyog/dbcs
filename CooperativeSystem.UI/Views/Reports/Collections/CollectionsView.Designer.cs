namespace CooperativeSystem.UI.Views.Reports.Collections
{
    partial class CollectionsView
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._yearlyCollectionRadioButton = new System.Windows.Forms.RadioButton();
            this._monthlyCollectionRadioButton = new System.Windows.Forms.RadioButton();
            this._dailyCollectionRadioButton = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._closeButton = new System.Windows.Forms.Button();
            this._generateButton = new System.Windows.Forms.Button();
            this._monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._monthCalendar);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._yearlyCollectionRadioButton);
            this.groupBox2.Controls.Add(this._monthlyCollectionRadioButton);
            this.groupBox2.Controls.Add(this._dailyCollectionRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(6, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 168);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Collection Type";
            // 
            // _yearlyCollectionRadioButton
            // 
            this._yearlyCollectionRadioButton.AutoSize = true;
            this._yearlyCollectionRadioButton.Location = new System.Drawing.Point(54, 107);
            this._yearlyCollectionRadioButton.Name = "_yearlyCollectionRadioButton";
            this._yearlyCollectionRadioButton.Size = new System.Drawing.Size(104, 17);
            this._yearlyCollectionRadioButton.TabIndex = 3;
            this._yearlyCollectionRadioButton.TabStop = true;
            this._yearlyCollectionRadioButton.Text = "Yearly Collection";
            this._yearlyCollectionRadioButton.UseVisualStyleBackColor = true;
            // 
            // _monthlyCollectionRadioButton
            // 
            this._monthlyCollectionRadioButton.AutoSize = true;
            this._monthlyCollectionRadioButton.Location = new System.Drawing.Point(54, 70);
            this._monthlyCollectionRadioButton.Name = "_monthlyCollectionRadioButton";
            this._monthlyCollectionRadioButton.Size = new System.Drawing.Size(112, 17);
            this._monthlyCollectionRadioButton.TabIndex = 2;
            this._monthlyCollectionRadioButton.TabStop = true;
            this._monthlyCollectionRadioButton.Text = "Monthly Collection";
            this._monthlyCollectionRadioButton.UseVisualStyleBackColor = true;
            // 
            // _dailyCollectionRadioButton
            // 
            this._dailyCollectionRadioButton.AutoSize = true;
            this._dailyCollectionRadioButton.Location = new System.Drawing.Point(54, 33);
            this._dailyCollectionRadioButton.Name = "_dailyCollectionRadioButton";
            this._dailyCollectionRadioButton.Size = new System.Drawing.Size(97, 17);
            this._dailyCollectionRadioButton.TabIndex = 1;
            this._dailyCollectionRadioButton.TabStop = true;
            this._dailyCollectionRadioButton.Text = "Daily Collection";
            this._dailyCollectionRadioButton.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 244);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(481, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(394, 218);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 5;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // _generateButton
            // 
            this._generateButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._generateButton.Location = new System.Drawing.Point(309, 218);
            this._generateButton.Name = "_generateButton";
            this._generateButton.Size = new System.Drawing.Size(79, 23);
            this._generateButton.TabIndex = 5;
            this._generateButton.Text = "&Generate";
            this._generateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._generateButton.UseVisualStyleBackColor = true;
            this._generateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // _monthCalendar
            // 
            this._monthCalendar.Location = new System.Drawing.Point(218, 26);
            this._monthCalendar.Name = "_monthCalendar";
            this._monthCalendar.TabIndex = 3;
            // 
            // CollectionsView
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
            this.Name = "CollectionsView";
            this.Text = "Collections";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton _yearlyCollectionRadioButton;
        private System.Windows.Forms.RadioButton _monthlyCollectionRadioButton;
        private System.Windows.Forms.RadioButton _dailyCollectionRadioButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        protected System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.Button _generateButton;
        private System.Windows.Forms.MonthCalendar _monthCalendar;
    }
}