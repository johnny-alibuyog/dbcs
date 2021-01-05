namespace CooperativeSystem.UI.Views.User
{
    partial class LoginView
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
            this._passwordTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this._userIDTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._closeButton = new System.Windows.Forms.Button();
            this._loginButton = new System.Windows.Forms.Button();
            this._changePasswordGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this._newPasswordConfirmationTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._newPasswordTextBox = new System.Windows.Forms.TextBox();
            this._changePasswordCheckBox = new System.Windows.Forms.CheckBox();
            this._changePasswordButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this._changePasswordGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._passwordTextBox);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._userIDTextBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // _passwordTextBox
            // 
            this._passwordTextBox.Location = new System.Drawing.Point(149, 47);
            this._passwordTextBox.Name = "_passwordTextBox";
            this._passwordTextBox.PasswordChar = '*';
            this._passwordTextBox.Size = new System.Drawing.Size(142, 21);
            this._passwordTextBox.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CooperativeSystem.UI.Properties.Resources.secrecy_icon;
            this.pictureBox1.Location = new System.Drawing.Point(20, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User ID:";
            // 
            // _userIDTextBox
            // 
            this._userIDTextBox.Location = new System.Drawing.Point(149, 20);
            this._userIDTextBox.Name = "_userIDTextBox";
            this._userIDTextBox.Size = new System.Drawing.Size(142, 21);
            this._userIDTextBox.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 244);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(346, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(259, 101);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 2;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = true;
            this._closeButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // _loginButton
            // 
            this._loginButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._loginButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._loginButton.Location = new System.Drawing.Point(178, 101);
            this._loginButton.Name = "_loginButton";
            this._loginButton.Size = new System.Drawing.Size(75, 23);
            this._loginButton.TabIndex = 1;
            this._loginButton.TabStop = false;
            this._loginButton.Text = "&Login";
            this._loginButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._loginButton.UseVisualStyleBackColor = true;
            this._loginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // _changePasswordGroupBox
            // 
            this._changePasswordGroupBox.Controls.Add(this.label3);
            this._changePasswordGroupBox.Controls.Add(this._newPasswordConfirmationTextBox);
            this._changePasswordGroupBox.Controls.Add(this.label4);
            this._changePasswordGroupBox.Controls.Add(this._newPasswordTextBox);
            this._changePasswordGroupBox.Location = new System.Drawing.Point(12, 130);
            this._changePasswordGroupBox.Name = "_changePasswordGroupBox";
            this._changePasswordGroupBox.Size = new System.Drawing.Size(321, 82);
            this._changePasswordGroupBox.TabIndex = 4;
            this._changePasswordGroupBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password Confirmation:";
            // 
            // _newPasswordConfirmationTextBox
            // 
            this._newPasswordConfirmationTextBox.Location = new System.Drawing.Point(149, 47);
            this._newPasswordConfirmationTextBox.Name = "_newPasswordConfirmationTextBox";
            this._newPasswordConfirmationTextBox.PasswordChar = '*';
            this._newPasswordConfirmationTextBox.Size = new System.Drawing.Size(142, 21);
            this._newPasswordConfirmationTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "New Password:";
            // 
            // _newPasswordTextBox
            // 
            this._newPasswordTextBox.Location = new System.Drawing.Point(149, 20);
            this._newPasswordTextBox.Name = "_newPasswordTextBox";
            this._newPasswordTextBox.PasswordChar = '*';
            this._newPasswordTextBox.Size = new System.Drawing.Size(142, 21);
            this._newPasswordTextBox.TabIndex = 0;
            // 
            // _changePasswordCheckBox
            // 
            this._changePasswordCheckBox.AutoSize = true;
            this._changePasswordCheckBox.Location = new System.Drawing.Point(13, 105);
            this._changePasswordCheckBox.Name = "_changePasswordCheckBox";
            this._changePasswordCheckBox.Size = new System.Drawing.Size(112, 17);
            this._changePasswordCheckBox.TabIndex = 3;
            this._changePasswordCheckBox.TabStop = false;
            this._changePasswordCheckBox.Text = "Change Password";
            this._changePasswordCheckBox.UseVisualStyleBackColor = true;
            this._changePasswordCheckBox.CheckedChanged += new System.EventHandler(this.ChangePasswordCheckBox_CheckedChanged);
            // 
            // _changePasswordButton
            // 
            this._changePasswordButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._changePasswordButton.Location = new System.Drawing.Point(259, 218);
            this._changePasswordButton.Name = "_changePasswordButton";
            this._changePasswordButton.Size = new System.Drawing.Size(75, 23);
            this._changePasswordButton.TabIndex = 5;
            this._changePasswordButton.TabStop = false;
            this._changePasswordButton.Text = "Chan&ge";
            this._changePasswordButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._changePasswordButton.UseVisualStyleBackColor = true;
            this._changePasswordButton.Click += new System.EventHandler(this.ChangePasswordButton_Click);
            // 
            // LoginView
            // 
            this.AcceptButton = this._loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(346, 266);
            this.Controls.Add(this._changePasswordButton);
            this.Controls.Add(this._changePasswordCheckBox);
            this.Controls.Add(this._changePasswordGroupBox);
            this.Controls.Add(this._loginButton);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Name = "LoginView";
            this.ShowInTaskbar = true;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginView_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this._changePasswordGroupBox.ResumeLayout(false);
            this._changePasswordGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _userIDTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _passwordTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.Button _loginButton;
        private System.Windows.Forms.GroupBox _changePasswordGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _newPasswordConfirmationTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _newPasswordTextBox;
        private System.Windows.Forms.CheckBox _changePasswordCheckBox;
        private System.Windows.Forms.Button _changePasswordButton;
    }
}