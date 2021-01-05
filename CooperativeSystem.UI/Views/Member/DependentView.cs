using System;
using System.Collections.Generic;
using CooperativeSystem.Service.Models.Lookups;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Members;
using CooperativeSystem.UI.Views.Maintenance;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.UI.Views.Member
{
    public partial class DependentView : FormTemplate, IDependentView
    {
        private DependentPresenter _presenter;
        private ActionType _actionType;

        public ActionType ActionType 
        {
            set 
            {
                if (value != ActionType.Insert && value != ActionType.Update && value != ActionType.Delete)
                    throw new ArgumentException(string.Format("Action {0} not supported.", value.ToString()));

                _actionType = value;
            } 
        }

        public DependentView()
        {
            InitializeComponent();

            _presenter = new DependentPresenter(this);
            _presenter.Success += new SuccessHandler(NotifyInformation);
            _presenter.Error += new ErrorHandler(NotifyError);

            // register controls to validate
            ControlValidator.RegisterControl(_lastNameTextBox, InputType.Normal, true, "Last Name", 30);
            ControlValidator.RegisterControl(_firstNameTextBox, InputType.Normal, true, "First Name", 30);
            ControlValidator.RegisterControl(_middleNameTextBox, InputType.Normal, false, "Middle Name", 30);
            ControlValidator.RegisterControl(_relationComboBox, InputType.Normal, false, "Relation");
        }

        #region IDependentView Members

        public event EventHandler AddingDependent;

        public event EventHandler ModifyingDependent;

        public event EventHandler RemovingDependent;

        public long MemberID { get; set; }
        
        public int LineNumber { get; set; }

        public string LastName
        {
            get { return _lastNameTextBox.Text; }
            set { _lastNameTextBox.Text = value; }
        }

        public string FirstName
        {
            get { return _firstNameTextBox.Text; }
            set { _firstNameTextBox.Text = value; }
        }

        public string MiddleName
        {
            get { return _middleNameTextBox.Text; }
            set { _middleNameTextBox.Text = value; }
        }

        public int RelationID
        {
            get { return Convert.ToInt32(_relationComboBox.SelectedValue); }
            set { _relationComboBox.SelectedValue = value; }
        }

        public string RelationName
        {
            get { return _relationComboBox.Text;  }
        }

        public void PopulateRelationPulldown(IList<Relation> relations)
        {
            _relationComboBox.DataSource = relations;
            _relationComboBox.ValueMember = "RelationID";
            _relationComboBox.DisplayMember = "RelationName";
        }

        #endregion

        #region Routine Helpers

        protected virtual void OnAddingDependent(EventArgs e)
        {
            RaiseAddingDependentEvent(this, e);
        }

        protected virtual void OnModifyingDependent(EventArgs e)
        {
            RaiseModifyingDependentEvent(this, e);
        }

        protected virtual void OnRemovingDependent(EventArgs e)
        {
            RaiseRemovingDependentEvent(this, e);
        }

        private void RaiseAddingDependentEvent(object sender, EventArgs e)
        {
            if (AddingDependent != null)
                AddingDependent.Invoke(sender, e);
        }

        private void RaiseModifyingDependentEvent(object sender, EventArgs e)
        {
            if (ModifyingDependent != null)
                ModifyingDependent.Invoke(sender, e);
        }

        protected virtual void RaiseRemovingDependentEvent(object sender, EventArgs e)
        {
            if (RemovingDependent != null)
                RemovingDependent.Invoke(sender, e);
        }

        #endregion

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (!ControlValidator.Validate())
                return;

            switch (_actionType)
            {
                case ActionType.Insert:
                    OnAddingDependent(new EventArgs());
                    break;
                case ActionType.Update:
                    OnModifyingDependent(new EventArgs());
                    break;
                case ActionType.Delete:
                    OnRemovingDependent(new EventArgs());
                    break;
            }
            Close();
        }
    }
}
