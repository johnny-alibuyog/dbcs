using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Savings.CapitalShare;
using CooperativeSystem.UI.Views.Utilities;

namespace CooperativeSystem.UI.Views.Savings.CapitalShare
{
    public partial class DividendDepositorySelectionView : FormTemplate, IDividendDepositorySelectionView
    {
        private DividendDepositorySelectionPresenter _presenter;

        public DividendDepositorySelectionView()
        {
            InitializeComponent();

            _presenter = new DividendDepositorySelectionPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            _yearNumericUpDown.Value = DateTime.Today.Year;
        }
        
        #region IDividendDepositorySelectionView Members
		
        public int Year
        {
            get { return Convert.ToInt16(_yearNumericUpDown.Value); }
        }

        public bool AllowSave
        {
            get { return _saveButton.Enabled; }
            set { _saveButton.Enabled = value; }
        }

        public long MemberID { get; set; }

        public string Member
        {
            get { return _memberTextBox.Text; }
            set { _memberTextBox.Text = value; }
        }

        public string DepositoryServiceID
        {
            get { return _depositoryComboBox.SelectedValue.ToString(); }
            set { _depositoryComboBox.SelectedValue = value; }
        }

        public IList<Service.Models.DividendComputation> DividendComputations
        {
            set 
            { 
                var list = value != null
                    ? new SearchableSortableBindingList<Service.Models.DividendComputation>(value)
                    : new SearchableSortableBindingList<Service.Models.DividendComputation>();
                var bindingList = new SearchableSortableBindingList<Service.Models.DividendComputation>(list);
                _dividendComputationBindingSource.DataSource = bindingList;
            }
        }

        public void PopulateDepositoryServicePulldown(IList<Service.Models.Service> services)
        {
            _depositoryComboBox.DataSource = services;
            _depositoryComboBox.ValueMember = "ServiceID";
            _depositoryComboBox.DisplayMember = "ServiceName";
        }
 
	    #endregion    

        private void SelectYearButton_Click(object sender, EventArgs e)
        {
            _presenter.Populate();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            _presenter.ChangeDepository();
        }

        private void DividendComputationBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var itemToSelect = _dividendComputationBindingSource.Current as Service.Models.DividendComputation;
            if (itemToSelect != null)
                _presenter.SelectItem(itemToSelect.DividendComputationID);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //if (!ControlValidator.Validate())
            //    return;

            if (AskConfirmation(this, "Do you want to save?") != DialogResult.Yes)
                return;

            _presenter.Save();
        }

        private void Post_Click(object sender, EventArgs e)
        {
            
        }    
    }
}
