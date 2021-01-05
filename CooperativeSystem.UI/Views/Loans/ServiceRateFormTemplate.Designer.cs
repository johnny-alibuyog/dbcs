namespace CooperativeSystem.UI.Views.Loans
{
    partial class ServiceRateFormTemplate
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
            this._groupBox = new System.Windows.Forms.GroupBox();
            this._closeButton = new System.Windows.Forms.Button();
            this._updateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 242);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(336, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _groupBox
            // 
            this._groupBox.Location = new System.Drawing.Point(12, 2);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(312, 208);
            this._groupBox.TabIndex = 16;
            this._groupBox.TabStop = false;
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(249, 216);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 18;
            this._closeButton.TabStop = false;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = true;
            // 
            // _updateButton
            // 
            this._updateButton.Image = global::CooperativeSystem.UI.Properties.Resources.accept;
            this._updateButton.Location = new System.Drawing.Point(167, 216);
            this._updateButton.Name = "_updateButton";
            this._updateButton.Size = new System.Drawing.Size(75, 23);
            this._updateButton.TabIndex = 17;
            this._updateButton.TabStop = false;
            this._updateButton.Text = "&Update";
            this._updateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._updateButton.UseVisualStyleBackColor = true;
            // 
            // ServiceRateFormTemplate
            // 
            this.AcceptButton = this._updateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(336, 264);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._updateButton);
            this.Controls.Add(this._groupBox);
            this.Name = "ServiceRateFormTemplate";
            this.Text = "ServiceRateFormTemplate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        protected System.Windows.Forms.Button _closeButton;
        protected System.Windows.Forms.Button _updateButton;
        protected System.Windows.Forms.GroupBox _groupBox;
    }
}