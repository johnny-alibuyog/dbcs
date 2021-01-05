using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Lookups.Relations;
using CooperativeSystem.UI.Views.Maintenance;
using CooperativeSystem.UI.Views.Utilities;

namespace CooperativeSystem.UI.Views.Lookups
{
    public partial class RelationListingView : ListingFormTemplate, IRelationListingView 
    {
        private RelationListingPresenter _presenter;
        private RelationView _relationView;

        public RelationListingView()
        {
            InitializeComponent();

            _dataGridView.AutoGenerateColumns = false;
            _dataGridView.Columns.AddRange(
                new DataGridViewTextBoxColumn() { DataPropertyName = "RelationName", FillWeight = Width * 1F, HeaderText = "Relation", ReadOnly = true });

            _presenter = new RelationListingPresenter(this);
            _presenter.Success += new SuccessHandler(NotifyInformation);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.PopulateListing();

            AddNewClick += new EventHandler(RelationListingView_AddNewClick);
            ModifyClick += new EventHandler(RelationListingView_ModifyClick);
            DeleteClick += new EventHandler(RelationListingView_DeleteClick);
            RefreshListClick += new EventHandler(RelationListingView_RefreshListClick);

            _relationView = new RelationView();
            _relationView.ItemAdded += new EventHandler(RelationView_ItemAdded);
            _relationView.ItemDeleted += new EventHandler(RelationView_ItemDeleted);
            _relationView.ItemModified += new EventHandler(RelationView_ItemModified);

            ListingModelType = typeof(RelationListingModel);
        }

        private void RelationListingView_AddNewClick(object sender, EventArgs e)
        {
            _relationView.ActionType = ActionType.Insert;
            _relationView.NewRelation();
            _relationView.ShowDialog(this);
        }

        private void RelationListingView_ModifyClick(object sender, EventArgs e)
        {
            var relationID = ((RelationListingModel)CurrentItem).RelationID;

            _relationView.ActionType = ActionType.Update;
            _relationView.LoadRelation(relationID);
            _relationView.ShowDialog(this);
        }

        private void RelationListingView_DeleteClick(object sender, EventArgs e)
        {
            var relationID = ((RelationListingModel)CurrentItem).RelationID;

            _relationView.ActionType = ActionType.Delete;
            _relationView.LoadRelation(relationID);
            _relationView.ShowDialog(this);
        }

        private void RelationListingView_RefreshListClick(object sender, EventArgs e)
        {
            _presenter.PopulateListing();
        }

        private void RelationView_ItemAdded(object sender, EventArgs e)
        {
            var items = (SearchableSortableBindingList<RelationListingModel>)DataSource;
            var item = new RelationListingModel()
            {
                RelationID = _relationView.RelationID,
                RelationName = _relationView.RelationName
            };
            items.Add(item);
        }

        private void RelationView_ItemModified(object sender, EventArgs e)
        {
            var item = (RelationListingModel)CurrentItem;
            item.RelationID = _relationView.RelationID;
            item.RelationName = _relationView.RelationName;
        }

        private void RelationView_ItemDeleted(object sender, EventArgs e)
        {
            var items = (SearchableSortableBindingList<RelationListingModel>)DataSource;
            var item = (RelationListingModel)CurrentItem;
            items.Remove(item);
        }

        #region IRelationListingView Members

        public void PopulateListing(IList<RelationListingModel> modelList)
        {
            DataSource = new SearchableSortableBindingList<RelationListingModel>(modelList);
        }

        #endregion
    }
}
