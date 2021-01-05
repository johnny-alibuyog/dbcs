namespace CooperativeSystem.UI.Views.Savings.TimeDeposit
{
    partial class InterestRateView
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
            this.label3 = new System.Windows.Forms.Label();
            this._above99000TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._50000to99000TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._below50000TextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _closeButton
            // 
            this._closeButton.Location = new System.Drawing.Point(197, 108);
            // 
            // _updateButton
            // 
            this._updateButton.Location = new System.Drawing.Point(116, 108);
            this._updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._above99000TextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._50000to99000TextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._below50000TextBox);
            this.groupBox1.Size = new System.Drawing.Size(260, 99);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Above 99,000:";
            // 
            // _above99000TextBox
            // 
            this._above99000TextBox.Location = new System.Drawing.Point(128, 72);
            this._above99000TextBox.Name = "_above99000TextBox";
            this._above99000TextBox.Size = new System.Drawing.Size(100, 21);
            this._above99000TextBox.TabIndex = 10;
            this._above99000TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "50,000 - 99,000:";
            // 
            // _50000to99000TextBox
            // 
            this._50000to99000TextBox.Location = new System.Drawing.Point(128, 45);
            this._50000to99000TextBox.Name = "_50000to99000TextBox";
            this._50000to99000TextBox.Size = new System.Drawing.Size(100, 21);
            this._50000to99000TextBox.TabIndex = 8;
            this._50000to99000TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Below 50,000:";
            // 
            // _below50000TextBox
            // 
            this._below50000TextBox.Location = new System.Drawing.Point(128, 18);
            this._below50000TextBox.Name = "_below50000TextBox";
            this._below50000TextBox.Size = new System.Drawing.Size(100, 21);
            this._below50000TextBox.TabIndex = 6;
            this._below50000TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // InterestRateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 156);
            this.Name = "InterestRateView";
            this.Text = "InterestRateView";
            this.Shown += new System.EventHandler(this.InterestRateView_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _above99000TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _50000to99000TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _below50000TextBox;

    }
}