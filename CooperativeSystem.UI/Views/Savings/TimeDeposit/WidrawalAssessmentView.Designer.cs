namespace CooperativeSystem.UI.Views.Savings.TimeDeposit
{
    partial class WidrawalAssessmentView
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
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this._cancelButton.Location = new System.Drawing.Point(266, 336);
            // 
            // button1
            // 
            this._acceptButton.Location = new System.Drawing.Point(185, 336);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Size = new System.Drawing.Size(329, 318);
            this.groupBox1.Controls.SetChildIndex(this.label6, 0);
            this.groupBox1.Controls.SetChildIndex(this.textBox5, 0);
            this.groupBox1.Controls.SetChildIndex(this.button3, 0);
            this.groupBox1.Controls.SetChildIndex(this.label5, 0);
            this.groupBox1.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.Controls.SetChildIndex(this.textBox6, 0);
            this.groupBox1.Controls.SetChildIndex(this.textBox1, 0);
            this.groupBox1.Controls.SetChildIndex(this.label1, 0);
            this.groupBox1.Controls.SetChildIndex(this.textBox2, 0);
            this.groupBox1.Controls.SetChildIndex(this.label2, 0);
            this.groupBox1.Controls.SetChildIndex(this.textBox3, 0);
            this.groupBox1.Controls.SetChildIndex(this.label3, 0);
            this.groupBox1.Controls.SetChildIndex(this.textBox4, 0);
            this.groupBox1.Controls.SetChildIndex(this.label4, 0);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(201, 182);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(34, 211);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(98, 158);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(201, 155);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(201, 128);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(100, 21);
            this.textBox6.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(118, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Maturity Date:";
            // 
            // WidrawalAssessmentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 384);
            this.Name = "WidrawalAssessmentView";
            this.Text = "Time Deposit Widrawal Assessment";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;

    }
}