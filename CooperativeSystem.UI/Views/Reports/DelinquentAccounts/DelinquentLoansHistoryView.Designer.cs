namespace CooperativeSystem.UI.Views.Reports.DelinquentAccounts
{
    partial class DelinquentLoansHistoryView
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
            this._generateButton = new System.Windows.Forms.Button();
            this._closeButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this._periodComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 102);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(434, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _generateButton
            // 
            this._generateButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._generateButton.Location = new System.Drawing.Point(262, 77);
            this._generateButton.Name = "_generateButton";
            this._generateButton.Size = new System.Drawing.Size(79, 23);
            this._generateButton.TabIndex = 15;
            this._generateButton.Text = "&Generate";
            this._generateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._generateButton.UseVisualStyleBackColor = true;
            this._generateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(347, 77);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 16;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._periodComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 59);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Period Covered:";
            // 
            // _periodComboBox
            // 
            this._periodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._periodComboBox.FormattingEnabled = true;
            this._periodComboBox.Location = new System.Drawing.Point(115, 27);
            this._periodComboBox.Name = "_periodComboBox";
            this._periodComboBox.Size = new System.Drawing.Size(271, 21);
            this._periodComboBox.TabIndex = 0;
            // 
            // DelinquentLoansHistoryView
            // 
            this.AcceptButton = this._generateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(434, 124);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._generateButton);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "DelinquentLoansHistoryView";
            this.Text = "Delinquent Loan History";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button _generateButton;
        protected System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _periodComboBox;

    }
}