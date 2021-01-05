namespace CooperativeSystem.UI.Views.Maintenance
{
    partial class DetailsFormTemplate
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailsFormTemplate));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._closeButton = new System.Windows.Forms.Button();
            this._saveButton = new System.Windows.Forms.Button();
            this._imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 221);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(335, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(248, 195);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 3;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // _saveButton
            // 
            this._saveButton.ImageKey = "add.ico";
            this._saveButton.ImageList = this._imageList;
            this._saveButton.Location = new System.Drawing.Point(172, 195);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(70, 23);
            this._saveButton.TabIndex = 2;
            this._saveButton.Text = "&Save";
            this._saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // _imageList
            // 
            this._imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageList.ImageStream")));
            this._imageList.TransparentColor = System.Drawing.Color.Transparent;
            this._imageList.Images.SetKeyName(0, "add.ico");
            this._imageList.Images.SetKeyName(1, "edit.ico");
            this._imageList.Images.SetKeyName(2, "delete.ico");
            // 
            // DetailsFormTemplate
            // 
            this.AcceptButton = this._saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(335, 243);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._saveButton);
            this.Name = "DetailsFormTemplate";
            this.Text = "DetailsFormTemplate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button _saveButton;
        protected System.Windows.Forms.Button _closeButton;
        protected System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ImageList _imageList;

    }
}