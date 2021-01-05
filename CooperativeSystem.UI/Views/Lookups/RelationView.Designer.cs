namespace CooperativeSystem.UI.Views.Lookups
{
    partial class RelationView
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
            this._relationNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _saveButton
            // 
            this._saveButton.Location = new System.Drawing.Point(172, 66);
            this._saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // _closeButton
            // 
            this._closeButton.Location = new System.Drawing.Point(248, 66);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._relationNameTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 47);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // _relationNameTextBox
            // 
            this._relationNameTextBox.Location = new System.Drawing.Point(127, 20);
            this._relationNameTextBox.Name = "_relationNameTextBox";
            this._relationNameTextBox.Size = new System.Drawing.Size(146, 21);
            this._relationNameTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Realation Name:";
            // 
            // RelationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 114);
            this.Controls.Add(this.groupBox1);
            this.Name = "RelationView";
            this.Text = "Relation";
            this.Controls.SetChildIndex(this._closeButton, 0);
            this.Controls.SetChildIndex(this._saveButton, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _relationNameTextBox;
        private System.Windows.Forms.Label label2;
    }
}