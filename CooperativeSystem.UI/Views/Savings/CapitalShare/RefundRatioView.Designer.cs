namespace CooperativeSystem.UI.Views.Savings.CapitalShare
{
    partial class RefundRatioView
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
            this.label2 = new System.Windows.Forms.Label();
            this._patronageRatioTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._dividendRatioTextBox = new System.Windows.Forms.TextBox();
            this._closeButton = new System.Windows.Forms.Button();
            this._updateButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._patronageRatioTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._dividendRatioTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Patronage Ratio:";
            // 
            // _patronageRatioTextBox
            // 
            this._patronageRatioTextBox.Location = new System.Drawing.Point(147, 47);
            this._patronageRatioTextBox.Name = "_patronageRatioTextBox";
            this._patronageRatioTextBox.Size = new System.Drawing.Size(100, 21);
            this._patronageRatioTextBox.TabIndex = 1;
            this._patronageRatioTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dividend Ratio:";
            // 
            // _dividendRatioTextBox
            // 
            this._dividendRatioTextBox.Location = new System.Drawing.Point(147, 20);
            this._dividendRatioTextBox.Name = "_dividendRatioTextBox";
            this._dividendRatioTextBox.Size = new System.Drawing.Size(100, 21);
            this._dividendRatioTextBox.TabIndex = 0;
            this._dividendRatioTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(229, 92);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 16;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = true;
            // 
            // _updateButton
            // 
            this._updateButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._updateButton.Location = new System.Drawing.Point(149, 92);
            this._updateButton.Name = "_updateButton";
            this._updateButton.Size = new System.Drawing.Size(75, 23);
            this._updateButton.TabIndex = 15;
            this._updateButton.TabStop = false;
            this._updateButton.Text = "&Update";
            this._updateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._updateButton.UseVisualStyleBackColor = true;
            this._updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 118);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(316, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // RefundRatioView
            // 
            this.AcceptButton = this._updateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(316, 140);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._updateButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Name = "RefundRatioView";
            this.Text = "Refund Ratio";
            this.Shown += new System.EventHandler(this.RefundRatioView_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _dividendRatioTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _patronageRatioTextBox;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Button _closeButton;
        protected System.Windows.Forms.Button _updateButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}