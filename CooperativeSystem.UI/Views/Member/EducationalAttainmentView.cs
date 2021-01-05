using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters.Members;
using CooperativeSystem.UI.Views.Maintenance;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.Member
{
    public partial class EducationalAttainmentView : FormTemplate, IEducationalAttainmentView
    {
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

        public EducationalAttainmentView()
        {
            InitializeComponent();

            // register controls to validate
            ControlValidator.RegisterControl(_levelTextBox, InputType.Normal, true, "Level", 100);
            ControlValidator.RegisterControl(_schoolTextBox, InputType.Normal, true, "School", 250);
            ControlValidator.RegisterControl(_yearTextBox, InputType.Normal, false, "Year", 50);
        }

        #region IEducationalAttainmentView Members

        public event EventHandler AddingEducationalAttainment;

        public event EventHandler ModifyingEducationalAttainment;

        public event EventHandler RemovingEducationalAttainment;

        public long MemberID
        {
            get;
            set;
        }

        public int LineNumber
        {
            get;
            set;
        }

        public string Level
        {
            get { return _levelTextBox.Text; }
            set { _levelTextBox.Text = value; }
        }

        public string School
        {
            get { return _schoolTextBox.Text; }
            set { _schoolTextBox.Text = value; }
        }

        public string Year
        {
            get { return _yearTextBox.Text; }
            set { _yearTextBox.Text = value; }
        }

        #endregion

        #region Routine Helpers

        protected virtual void OnAddingEducationalAttainment(object sender, EventArgs e)
        {
            if (AddingEducationalAttainment != null)
                AddingEducationalAttainment.Invoke(sender, e);
        }

        protected virtual void OnModifyingEducationalAttainment(object sender, EventArgs e)
        {
            if (ModifyingEducationalAttainment != null)
                ModifyingEducationalAttainment.Invoke(sender, e);
        }

        protected virtual void OnRemovingEducationalAttainment(object sender, EventArgs e)
        {
            if (RemovingEducationalAttainment != null)
                RemovingEducationalAttainment.Invoke(sender, e);
        }

        private void RaiseAddingEducationalAttainmentEvent(EventArgs e)
        {
            OnAddingEducationalAttainment(this, e);
        }

        private void RaiseModifyingEducationalAttainmentEvent(EventArgs e)
        {
            OnModifyingEducationalAttainment(this, e);
        }

        private void RaiseRemovingEducationalAttainmentEvent(EventArgs e)
        {
            OnRemovingEducationalAttainment(this, e);
        }

        #endregion

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (!ControlValidator.Validate())
                return;

            switch (_actionType)
            {
                case ActionType.Insert:
                    RaiseAddingEducationalAttainmentEvent(new EventArgs());
                    break;
                case ActionType.Update:
                    RaiseModifyingEducationalAttainmentEvent(new EventArgs());
                    break;
                case ActionType.Delete:
                    RaiseRemovingEducationalAttainmentEvent(new EventArgs());
                    break;
            }
            Close();
        }
    }
}
