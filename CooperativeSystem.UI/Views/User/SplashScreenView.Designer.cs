namespace CooperativeSystem.UI.Views.User
{
    partial class SplashScreenView
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
            this._statusLabel = new System.Windows.Forms.Label();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _statusLabel
            // 
            this._statusLabel.AutoSize = true;
            this._statusLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._statusLabel.ForeColor = System.Drawing.Color.Green;
            this._statusLabel.Location = new System.Drawing.Point(12, 351);
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(107, 19);
            this._statusLabel.TabIndex = 4;
            this._statusLabel.Text = "Status Update";
            // 
            // _progressBar
            // 
            this._progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._progressBar.Location = new System.Drawing.Point(0, 373);
            this._progressBar.MarqueeAnimationSpeed = 50;
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(409, 12);
            this._progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this._progressBar.TabIndex = 3;
            // 
            // _pictureBox
            // 
            this._pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._pictureBox.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this._pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pictureBox.Image = global::CooperativeSystem.UI.Properties.Resources.CooperativeLog;
            this._pictureBox.Location = new System.Drawing.Point(0, 0);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(409, 373);
            this._pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pictureBox.TabIndex = 5;
            this._pictureBox.TabStop = false;
            // 
            // SplashScreenView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(409, 385);
            this.Controls.Add(this._statusLabel);
            this.Controls.Add(this._pictureBox);
            this.Controls.Add(this._progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreenView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SplashScreenView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _statusLabel;
        private System.Windows.Forms.PictureBox _pictureBox;
        private System.Windows.Forms.ProgressBar _progressBar;
    }
}
