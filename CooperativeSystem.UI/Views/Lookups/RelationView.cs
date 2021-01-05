using System;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Lookups.Relations;
using CooperativeSystem.UI.Views.Maintenance;

namespace CooperativeSystem.UI.Views.Lookups
{
    public partial class RelationView : DetailsFormTemplate, IRelationView
    {
        private RelationPresenter _presenter;

        public RelationView()
        {
            InitializeComponent();

            _presenter = new RelationPresenter(this);
            _presenter.Success += new SuccessHandler(NotifyInformation);
            _presenter.Error += new ErrorHandler(NotifyError);
        }

        #region IRelationView Members

        public int RelationID { get; set; }

        public string RelationName
        {
            get { return _relationNameTextBox.Text; }
            set { _relationNameTextBox.Text = value; }
        }

        public void NewRelation()
        {
            _presenter.NewRelation();
        }

        public void LoadRelation(int relationID)
        {
            _presenter.LoadRelation(relationID);
        }

        #endregion

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ActionType == ActionType.Insert)
            {
                if (AskConfirmation(this, "Do you want to add new relation?") == DialogResult.Yes)
                {
                    if (_presenter.Insert())
                    {
                        OnItemAdded(new EventArgs());
                        Close();
                    }
                }
            }
            else if (ActionType == ActionType.Update)
            {
                if (AskConfirmation(this, "Do you want to modify relation information?") == DialogResult.Yes)
                {
                    if (_presenter.Update())
                    {
                        OnItemModified(new EventArgs());
                        Close();
                    }
                }
            }
            else if (ActionType == ActionType.Delete)
            {
                if (AskConfirmation(this, "Do you want to delete user?") == DialogResult.Yes)
                {
                    if (_presenter.Delete())
                    {
                        OnItemDeleted(new EventArgs());
                        Close();
                    }
                }
            }
        }
    }
}
