namespace CooperativeSystem.UI.Views
{
    partial class PostingView
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
            this._generateVoucherButton = new System.Windows.Forms.Button();
            this._restartVoucherCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this._voucherNumberTextBox = new System.Windows.Forms.TextBox();
            this._sequenceTextBox = new System.Windows.Forms.TextBox();
            this._postButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._generateVoucherButton);
            this.groupBox1.Controls.Add(this._restartVoucherCheckBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this._voucherNumberTextBox);
            this.groupBox1.Controls.Add(this._sequenceTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // _generateVoucherButton
            // 
            this._generateVoucherButton.Enabled = false;
            this._generateVoucherButton.Location = new System.Drawing.Point(250, 46);
            this._generateVoucherButton.Name = "_generateVoucherButton";
            this._generateVoucherButton.Size = new System.Drawing.Size(75, 23);
            this._generateVoucherButton.TabIndex = 67;
            this._generateVoucherButton.TabStop = false;
            this._generateVoucherButton.Text = "Generate";
            this._generateVoucherButton.UseVisualStyleBackColor = true;
            this._generateVoucherButton.Click += new System.EventHandler(this.GenerateVoucherButton_Click);
            // 
            // _restartVoucherCheckBox
            // 
            this._restartVoucherCheckBox.AutoSize = true;
            this._restartVoucherCheckBox.Location = new System.Drawing.Point(55, 50);
            this._restartVoucherCheckBox.Name = "_restartVoucherCheckBox";
            this._restartVoucherCheckBox.Size = new System.Drawing.Size(60, 17);
            this._restartVoucherCheckBox.TabIndex = 66;
            this._restartVoucherCheckBox.Text = "Restart";
            this._restartVoucherCheckBox.UseVisualStyleBackColor = true;
            this._restartVoucherCheckBox.CheckedChanged += new System.EventHandler(this.RestartVoucherCheckBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "Voucher Number:";
            // 
            // _voucherNumberTextBox
            // 
            this._voucherNumberTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._voucherNumberTextBox.Location = new System.Drawing.Point(123, 20);
            this._voucherNumberTextBox.Name = "_voucherNumberTextBox";
            this._voucherNumberTextBox.ReadOnly = true;
            this._voucherNumberTextBox.Size = new System.Drawing.Size(121, 22);
            this._voucherNumberTextBox.TabIndex = 65;
            this._voucherNumberTextBox.TabStop = false;
            // 
            // _sequenceTextBox
            // 
            this._sequenceTextBox.Enabled = false;
            this._sequenceTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._sequenceTextBox.Location = new System.Drawing.Point(123, 48);
            this._sequenceTextBox.Name = "_sequenceTextBox";
            this._sequenceTextBox.Size = new System.Drawing.Size(121, 22);
            this._sequenceTextBox.TabIndex = 63;
            this._sequenceTextBox.TabStop = false;
            // 
            // _postButton
            // 
            this._postButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._postButton.Location = new System.Drawing.Point(226, 94);
            this._postButton.Name = "_postButton";
            this._postButton.Size = new System.Drawing.Size(75, 23);
            this._postButton.TabIndex = 6;
            this._postButton.TabStop = false;
            this._postButton.Text = "&Post";
            this._postButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._postButton.UseVisualStyleBackColor = true;
            this._postButton.Click += new System.EventHandler(this.PostButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._cancelButton.Location = new System.Drawing.Point(307, 94);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 7;
            this._cancelButton.TabStop = false;
            this._cancelButton.Text = "&Cancel";
            this._cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 120);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(385, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // PostingView
            // 
            this.AcceptButton = this._postButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(385, 142);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._postButton);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "PostingView";
            this.Text = "Posting";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _generateVoucherButton;
        private System.Windows.Forms.CheckBox _restartVoucherCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _voucherNumberTextBox;
        private System.Windows.Forms.TextBox _sequenceTextBox;
        private System.Windows.Forms.Button _postButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}