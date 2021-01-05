using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CooperativeSystem.UI.Views
{
    public partial class UserControlTemplate : UserControl
    {
        public UserControlTemplate()
        {
            InitializeComponent();
        }

        internal virtual void NotifyInformation(object sender, string message)
        {
            var parentForm = this.ParentForm as FormTemplate;
            if (parentForm != null)
                parentForm.NotifyInformation(sender, message);
        }

        internal virtual void NotifyWarning(object sender, string message)
        {
            var parentForm = this.ParentForm as FormTemplate;
            if (parentForm != null)
                parentForm.NotifyWarning(sender, message);
        }

        internal virtual void NotifyError(object sender, string message)
        {
            var parentForm = this.ParentForm as FormTemplate;
            if (parentForm != null)
                parentForm.NotifyError(sender, message);
        }
    }
}
