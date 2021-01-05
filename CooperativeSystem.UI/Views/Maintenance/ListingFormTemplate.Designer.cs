namespace CooperativeSystem.UI.Views.Maintenance
{
    partial class ListingFormTemplate
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
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._searchCategoryComboBox = new System.Windows.Forms.ComboBox();
            this._searchValueTextBox = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._addNewItemToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._modifyItemToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._deleteItemToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._refreshListToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._searchButton = new System.Windows.Forms.Button();
            this._closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _statusStrip
            // 
            this._statusStrip.Location = new System.Drawing.Point(0, 377);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(660, 22);
            this._statusStrip.TabIndex = 24;
            this._statusStrip.Text = "statusStrip1";
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToDeleteRows = false;
            this._dataGridView.AllowUserToResizeRows = false;
            this._dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Location = new System.Drawing.Point(12, 57);
            this._dataGridView.MultiSelect = false;
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.ReadOnly = true;
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridView.Size = new System.Drawing.Size(636, 288);
            this._dataGridView.TabIndex = 23;
            // 
            // _searchCategoryComboBox
            // 
            this._searchCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._searchCategoryComboBox.FormattingEnabled = true;
            this._searchCategoryComboBox.Location = new System.Drawing.Point(482, 30);
            this._searchCategoryComboBox.Name = "_searchCategoryComboBox";
            this._searchCategoryComboBox.Size = new System.Drawing.Size(166, 21);
            this._searchCategoryComboBox.TabIndex = 22;
            this._searchCategoryComboBox.SelectedValueChanged += new System.EventHandler(this.SearchCategoryComboBox_SelectedValueChanged);
            // 
            // _searchValueTextBox
            // 
            this._searchValueTextBox.Location = new System.Drawing.Point(91, 30);
            this._searchValueTextBox.Name = "_searchValueTextBox";
            this._searchValueTextBox.Size = new System.Drawing.Size(166, 21);
            this._searchValueTextBox.TabIndex = 21;
            this._searchValueTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchValueTextBox_KeyDown);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(384, 33);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(92, 13);
            this.Label2.TabIndex = 20;
            this.Label2.Text = "Search Category:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 33);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(73, 13);
            this.Label1.TabIndex = 19;
            this.Label1.Text = "Search Value:";
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._addNewItemToolStripButton,
            this._modifyItemToolStripButton,
            this._deleteItemToolStripButton,
            this.toolStripSeparator1,
            this._refreshListToolStripButton});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this._toolStrip.Size = new System.Drawing.Size(660, 25);
            this._toolStrip.TabIndex = 17;
            this._toolStrip.Text = "toolStrip";
            // 
            // _addNewItemToolStripButton
            // 
            this._addNewItemToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._addNewItemToolStripButton.Image = global::CooperativeSystem.UI.Properties.Resources.add;
            this._addNewItemToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._addNewItemToolStripButton.Name = "_addNewItemToolStripButton";
            this._addNewItemToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._addNewItemToolStripButton.Text = "Add New Item";
            this._addNewItemToolStripButton.Click += new System.EventHandler(this.AddNewItemToolStripButton_Click);
            // 
            // _modifyItemToolStripButton
            // 
            this._modifyItemToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._modifyItemToolStripButton.Image = global::CooperativeSystem.UI.Properties.Resources.edit;
            this._modifyItemToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._modifyItemToolStripButton.Name = "_modifyItemToolStripButton";
            this._modifyItemToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._modifyItemToolStripButton.Text = "Modify Item";
            this._modifyItemToolStripButton.Click += new System.EventHandler(this.ModifyItemToolStripButton_Click);
            // 
            // _deleteItemToolStripButton
            // 
            this._deleteItemToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._deleteItemToolStripButton.Image = global::CooperativeSystem.UI.Properties.Resources.delete;
            this._deleteItemToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._deleteItemToolStripButton.Name = "_deleteItemToolStripButton";
            this._deleteItemToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._deleteItemToolStripButton.Text = "Delete Item";
            this._deleteItemToolStripButton.Click += new System.EventHandler(this.DeleteItemToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _refreshListToolStripButton
            // 
            this._refreshListToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._refreshListToolStripButton.Image = global::CooperativeSystem.UI.Properties.Resources.refresh;
            this._refreshListToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._refreshListToolStripButton.Name = "_refreshListToolStripButton";
            this._refreshListToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._refreshListToolStripButton.Text = "Refresh List";
            this._refreshListToolStripButton.Click += new System.EventHandler(this.RefreshListToolStripButton_Click);
            // 
            // _searchButton
            // 
            this._searchButton.Image = global::CooperativeSystem.UI.Properties.Resources.find;
            this._searchButton.Location = new System.Drawing.Point(263, 28);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(75, 23);
            this._searchButton.TabIndex = 18;
            this._searchButton.TabStop = false;
            this._searchButton.Text = "&Search";
            this._searchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._searchButton.UseVisualStyleBackColor = true;
            this._searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // _closeButton
            // 
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Image = global::CooperativeSystem.UI.Properties.Resources.close;
            this._closeButton.Location = new System.Drawing.Point(573, 351);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 25;
            this._closeButton.Text = "Cl&ose";
            this._closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._closeButton.UseVisualStyleBackColor = true;
            // 
            // ListingFormTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._closeButton;
            this.ClientSize = new System.Drawing.Size(660, 399);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._dataGridView);
            this.Controls.Add(this._searchCategoryComboBox);
            this.Controls.Add(this._searchValueTextBox);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this._searchButton);
            this.Controls.Add(this._toolStrip);
            this.KeyPreview = true;
            this.Name = "ListingFormTemplate";
            this.Text = "ListingViewTemplate";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListingFormTemplate_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.ComboBox _searchCategoryComboBox;
        private System.Windows.Forms.TextBox _searchValueTextBox;
        private System.Windows.Forms.Button _searchButton;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _refreshListToolStripButton;
        private System.Windows.Forms.ToolStripButton _modifyItemToolStripButton;
        private System.Windows.Forms.ToolStripButton _deleteItemToolStripButton;
        private System.Windows.Forms.ToolStripButton _addNewItemToolStripButton;
        protected System.Windows.Forms.DataGridView _dataGridView;
        protected internal System.Windows.Forms.ToolStrip _toolStrip;
    }
}