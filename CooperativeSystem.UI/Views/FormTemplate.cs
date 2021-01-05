using System.Windows.Forms;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views
{
    public partial class FormTemplate: Form
    {
        private ControlValidator _controlValidator;

        protected ControlValidator ControlValidator
        {
            get { return _controlValidator; }
        }

        public FormTemplate()
        {
            InitializeComponent();

            _controlValidator = new ControlValidator();
            _controlValidator.ErrorOccured += new ControlValidator.ErrorHandler(NotifyError);
        }

        internal virtual void NotifyInformation(object sender, string message)
        {
            if (Visible)
                MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal virtual void NotifyWarning(object sender, string message)
        {
            if (Visible)
                MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        internal virtual void NotifyError(object sender, string message)
        {
            if (Visible)
                MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal virtual DialogResult AskConfirmation(object sender, string message)
        {
            DialogResult result = DialogResult.No;
            if (Visible)
                result = MessageBox.Show(this, message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result;
        }

        internal virtual DialogResult AskConfirmation(object sender, string message, MessageBoxIcon messageBoxIcon)
        {
            DialogResult result = DialogResult.No;
            if (Visible)
                result = MessageBox.Show(this, message, Text, MessageBoxButtons.YesNo, messageBoxIcon);
            return result;
        }
    }
}
