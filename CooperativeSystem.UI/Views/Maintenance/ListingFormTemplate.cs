using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace CooperativeSystem.UI.Views.Maintenance
{
    public partial class ListingFormTemplate : FormTemplate
    {
        private Type _listingModelType;

        protected event EventHandler AddNewClick;
        protected event EventHandler ModifyClick;
        protected event EventHandler DeleteClick;
        protected event EventHandler RefreshListClick;

        private BindingSource _bindingSource;

        #region Event Routine Helpers

        protected virtual void OnAddNewClick(EventArgs e)
        {
            RaiseAddNewClickEvent(this, e);
        }

        protected void OnModifyClick(EventArgs e)
        {
            RaiseModifyClickEvent(this, e);            
        }

        protected void OnDeleteClick(EventArgs e)
        {
            RaiseDeleteClickEvent(this, e);
        }

        protected void OnRefreshListClick(EventArgs e)
        {
            RaiseRefreshListClickEvent(this, e);
        }

        private void RaiseAddNewClickEvent(object sender, EventArgs e)
        {
            if (AddNewClick != null)
                AddNewClick.Invoke(sender, e);
        }

        private void RaiseModifyClickEvent(object sender, EventArgs e)
        {
            if (ModifyClick != null)
                ModifyClick.Invoke(sender, e);
        }

        private void RaiseDeleteClickEvent(object sender, EventArgs e)
        {
            if (DeleteClick != null)
                DeleteClick.Invoke(sender, e);
        }

        private void RaiseRefreshListClickEvent(object sender, EventArgs e)
        {
            if (RefreshListClick != null)
                RefreshListClick.Invoke(sender, e);
        }

        #endregion

        #region Search Routine Helpers

        private void PopulateSearchCategoryComboBox(Type listingModelType)
        {
            _listingModelType = listingModelType;
            var properties = _listingModelType.GetProperties();

            if (properties.Count() > 0)
            {
                var selectedIndex = 0;

                for (int i = 0; i < properties.Count(); i++)
			    {
                    _searchCategoryComboBox.Items.Add(properties[i].Name);
                    if (properties[i].Name.Equals("Name", StringComparison.InvariantCultureIgnoreCase) ||
                        properties[i].Name.Equals("Description", StringComparison.InvariantCultureIgnoreCase))
                    {
                        selectedIndex = i;
                    }
			    }

                _searchCategoryComboBox.SelectedIndex = selectedIndex;


                //foreach (var property in properties)
                //{
                //    int index = _searchCategoryComboBox.Items.Count;
                //    _searchCategoryComboBox.Items.Insert(index, property.Name);

                //    if (property.Name == "Name" || property.Name = "Description")
                        

                //}
                //_searchCategoryComboBox.SelectedIndex = selectedIndex;
            }

            //if (_searchCategoryComboBox.Items.Count > 1)
            //    _searchCategoryComboBox.SelectedIndex = 1;
            //else if (_searchCategoryComboBox.Items.Count > 0)             // Select first column name in list, if column names were added
            //    _searchCategoryComboBox.SelectedIndex = 0;



            //var list = _dataGridView.Columns.Cast<DataGridViewColumn>()
            //    .Select(c => new { ValueMember = c.DataPropertyName, DisplayMember = c.HeaderText })
            //    .ToList();

            //_searchCategoryComboBox.DataSource = list;
            //_searchCategoryComboBox.ValueMember = "ValueMember";
            //_searchCategoryComboBox.DisplayMember = "DisplayMember";
        }

        private void Search()
        {
            // Don't search if nothing specified to look for
            var value = _searchValueTextBox.Text;
            if (string.IsNullOrEmpty(value))
                return;

            // Don’t search of a column isn’t specified to search in
            var category = _searchCategoryComboBox.Text;
            if (string.IsNullOrEmpty(category))
                return;

            if (DataSource == null)
                return;

            var property = _listingModelType.GetProperty(category);
            if (property == null)
                return;

            var index = _bindingSource.Find(property.Name, value);
            if (index != -1)
                _bindingSource.Position = index;
        }

        #endregion

        public Type ListingModelType 
        {
            set { PopulateSearchCategoryComboBox(value); }
        }

        public object DataSource
        {
            get { return _bindingSource.DataSource; }
            set { _bindingSource.DataSource = value; }
        }

        public object CurrentItem
        {
            get { return _bindingSource.Current; }
        }

        public ListingFormTemplate()
        {
            InitializeComponent();

            _bindingSource = new BindingSource();
            _dataGridView.DataSource = _bindingSource;
        }

        private void ListingFormTemplate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                OnAddNewClick(new EventArgs());
            else if (e.KeyCode == Keys.F2)
                OnModifyClick(new EventArgs());
            else if (e.KeyCode == Keys.F3)
                OnDeleteClick(new EventArgs());
            else if (e.KeyCode == Keys.F4)
                OnRefreshListClick(new EventArgs());
        }

        private void AddNewItemToolStripButton_Click(object sender, EventArgs e)
        {
            OnAddNewClick(e);
        }

        private void ModifyItemToolStripButton_Click(object sender, EventArgs e)
        {
            OnModifyClick(e);
        }

        private void DeleteItemToolStripButton_Click(object sender, EventArgs e)
        {
            OnDeleteClick(e);
        }

        private void RefreshListToolStripButton_Click(object sender, EventArgs e)
        {
            OnRefreshListClick(e);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void SearchValueTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void SearchCategoryComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            _searchValueTextBox.SelectAll();
        }
    }
}