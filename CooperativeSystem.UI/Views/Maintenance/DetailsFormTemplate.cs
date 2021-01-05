using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CooperativeSystem.UI.Views.Maintenance
{
    public partial class DetailsFormTemplate : FormTemplate
    {
        private ActionType _actionType;

        public event EventHandler ItemAdded;
        public event EventHandler ItemModified;
        public event EventHandler ItemDeleted;

        public ActionType ActionType
        {
            get 
            { 
                return _actionType; 
            }
            set 
            { 
                SetActionTypeAndInitializeSaveButton(value);
            }
        }

        #region Routine Helpers

        protected virtual void OnItemAdded(EventArgs e)
        {
            RaiseItemAddedEvent(this, e);
        }

        protected virtual void OnItemModified(EventArgs e)
        {
            RaiseItemModifiedEvent(this, e);
        }

        protected virtual void OnItemDeleted(EventArgs e)
        {
            RaiseItemDeletedEvent(this, e);
        }

        private void RaiseItemAddedEvent(object sender, EventArgs e)
        {
            if (ItemAdded != null)
                ItemAdded.Invoke(sender, e);
        }

        private void RaiseItemModifiedEvent(object sender, EventArgs e)
        {
            if (ItemModified != null)
                ItemModified.Invoke(sender, e);
        }

        private void RaiseItemDeletedEvent(object sender, EventArgs e)
        {
            if (ItemDeleted != null)
                ItemDeleted.Invoke(sender, e);
        }

        private void SetActionTypeAndInitializeSaveButton(ActionType actionType)
        {
            _actionType = actionType;
            switch (actionType)
            {
                case ActionType.Insert:
                    _saveButton.Text = "&Add";
                    _saveButton.ImageIndex = 0;
                    break;
                case ActionType.Update:
                    _saveButton.Text = "&Edit";
                    _saveButton.ImageIndex = 1;
                    break;
                case ActionType.Delete:
                    _saveButton.Text = "&Delete";
                    _saveButton.ImageIndex = 2;
                    break;
            }
        }

        #endregion

        public DetailsFormTemplate()
        {
            InitializeComponent();
        }


    }
}
