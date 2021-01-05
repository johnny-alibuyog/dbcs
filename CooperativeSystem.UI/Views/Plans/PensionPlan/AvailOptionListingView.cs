using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Plans.PensionPlan;
using CooperativeSystem.UI.Views.Maintenance;
using CooperativeSystem.UI.Views.Utilities;

namespace CooperativeSystem.UI.Views.Plans.PensionPlan
{
    public partial class AvailOptionListingView : ListingFormTemplate, IAvailOptionListingView
    {
        private AvailOptionListingPresenter _presenter;
        private AvailOptionView _availOptionView;

        public AvailOptionListingView()
        {
            InitializeComponent();

            _dataGridView.AutoGenerateColumns = false;
            _dataGridView.Columns.AddRange(
                new DataGridViewTextBoxColumn() { DataPropertyName = "AvailOptionName", FillWeight = Width * .2F, HeaderText = "Avail Option Name", ReadOnly = true },
                new DataGridViewTextBoxColumn() { DataPropertyName = "AvailOptionDescription", FillWeight = Width * .8F, HeaderText = "Avail Option Descxription", ReadOnly = true });

            _presenter = new AvailOptionListingPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
            _presenter.PopulateListing();

            AddNewClick += new EventHandler(AvailOptionListingView_AddNewClick);
            ModifyClick += new EventHandler(AvailOptionListingView_ModifyClick);
            DeleteClick += new EventHandler(AvailOptionListingView_DeleteClick);
            RefreshListClick += new EventHandler(AvailOptionListingView_RefreshListClick);

            _availOptionView = new AvailOptionView();
            _availOptionView.ItemAdded += new EventHandler(AvailOptionView_ItemAdded);
            _availOptionView.ItemModified += new EventHandler(AvailOptionView_ItemModified);
            _availOptionView.ItemDeleted += new EventHandler(AvailOptionView_ItemDeleted);

            ListingModelType = typeof(PensionPlanAvailOption);
        }

        private void AvailOptionListingView_AddNewClick(object sender, EventArgs e)
        {
            _availOptionView.ActionType = ActionType.Insert;
            _availOptionView.NewAvailOption();
            _availOptionView.ShowDialog(this);
        }

        private void AvailOptionListingView_ModifyClick(object sender, EventArgs e)
        {
            var availOptionID = ((PensionPlanAvailOption)CurrentItem).AvailOptionID;

            _availOptionView.ActionType = ActionType.Update;
            _availOptionView.LoadAvailOption(availOptionID);
            _availOptionView.ShowDialog(this);
        }

        private void AvailOptionListingView_DeleteClick(object sender, EventArgs e)
        {
            var availOptionID = ((PensionPlanAvailOption)CurrentItem).AvailOptionID;

            _availOptionView.ActionType = ActionType.Delete;
            _availOptionView.LoadAvailOption(availOptionID);
            _availOptionView.ShowDialog(this);
        }

        void AvailOptionListingView_RefreshListClick(object sender, EventArgs e)
        {
            _presenter.PopulateListing();
        }

        private void AvailOptionView_ItemAdded(object sender, EventArgs e)
        {
            var items = (SearchableSortableBindingList<PensionPlanAvailOption>)DataSource;
            var item = new PensionPlanAvailOption()
            {
                AvailOptionID = _availOptionView.AvailOptionID,
                AvailOptionName = _availOptionView.AvailOptionName,
                AvailOptionDescription = _availOptionView.AvailOptionDescription,
                AwardAmount = _availOptionView.AwardAmount,
                AgingPeriod = _availOptionView.AgingPeriod,
                WithMonthlyPension = _availOptionView.WithMonthlyPension
            };
            items.Add(item);
        }

        private void AvailOptionView_ItemModified(object sender, EventArgs e)
        {
            var item = (PensionPlanAvailOption)CurrentItem;
            item.AvailOptionID = _availOptionView.AvailOptionID;
            item.AvailOptionName = _availOptionView.AvailOptionName;
            item.AvailOptionDescription = _availOptionView.AvailOptionDescription;
            item.AwardAmount = _availOptionView.AwardAmount;
            item.AgingPeriod = _availOptionView.AgingPeriod;
            item.WithMonthlyPension = _availOptionView.WithMonthlyPension;
        }

        private void AvailOptionView_ItemDeleted(object sender, EventArgs e)
        {
            var items = (SearchableSortableBindingList<PensionPlanAvailOption>)DataSource;
            var item = (PensionPlanAvailOption)CurrentItem;
            items.Remove(item);
        }

        #region IAvailOptionListingView Members

        public void PopulateListing(IList<PensionPlanAvailOption> modelList)
        {
            DataSource = new SearchableSortableBindingList<PensionPlanAvailOption>(modelList);
        }

        #endregion
    }
}
