namespace CooperativeSystem.UI.Views
{
    partial class ProgressView
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
            this._pictureBox = new System.Windows.Forms.PictureBox();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _pictureBox
            // 
            this._pictureBox.Image = global::CooperativeSystem.UI.Properties.Resources.loader;
            this._pictureBox.Location = new System.Drawing.Point(12, 12);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(53, 41);
            this._pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._pictureBox.TabIndex = 0;
            this._pictureBox.TabStop = false;
            this._pictureBox.UseWaitCursor = true;
            // 
            // _progressBar
            // 
            this._progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._progressBar.Location = new System.Drawing.Point(0, 59);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(458, 12);
            this._progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this._progressBar.TabIndex = 1;
            // 
            // _statusLabel
            // 
            this._statusLabel.AutoSize = true;
            this._statusLabel.Font = new System.Drawing.Font("Tahoma", 12F);
            this._statusLabel.ForeColor = System.Drawing.Color.Green;
            this._statusLabel.Location = new System.Drawing.Point(91, 25);
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(270, 19);
            this._statusLabel.TabIndex = 5;
            this._statusLabel.Text = "Loading. Please wait for a moment...";
            // 
            // ProgressView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 71);
            this.Controls.Add(this._statusLabel);
            this.Controls.Add(this._progressBar);
            this.Controls.Add(this._pictureBox);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgressView";
            this.Text = "Progress";
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _pictureBox;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.Label _statusLabel;
    }
}