using System.Windows.Forms;

namespace CooperativeSystem.UI.Views.Utilities.ControlValidation
{
    public class ComboBoxDecorator : ComboBox, IValidatable
    {
        private ComboBox _combBox;

        private InputType _inputTextType;
        private string _description;
        private bool _compulsory;
        private int _scales;

        #region IValidatable Members

        public InputType InputType
        {
            get { return _inputTextType; }
            set { _inputTextType = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string ErrorMessage
        {
            get
            {
                if (_combBox.Text.Trim() == string.Empty)
                {
                    if (!string.IsNullOrEmpty(Description))
                        return "Please specify " + Description + ".";
                    else
                        return "Please specify input.";
                }
                else
                {
                    if (!string.IsNullOrEmpty(Description))
                        return "Invalid " + Description + ".";
                    else
                        return "Invalid input.";
                }
            }
        }

        public bool Compulsory
        {
            get { return _compulsory; }
            set { _compulsory = value; }
        }

        public new int MaxLength
        {
            get { return _combBox.MaxLength; }
            set { _combBox.MaxLength = value; }
        }

        public int Scales
        {
            get { return _scales; }
            set { _scales = value; }
        }

        public bool ValidateContent()
        {
            // not enabled
            if (!_combBox.Enabled)
                return true;

            // has input
            if ((_combBox.Text.Trim() != string.Empty) || (_combBox.SelectedIndex != -1))
                return true;

            // allow empty inputs for optional fields.
            if (!Compulsory)
                return true;

            // compulsory feild not inputed.
            return false;
        }

        #endregion

        public ComboBoxDecorator(ComboBox comboBox)
        {
            _combBox = comboBox;

            _inputTextType = InputType.Normal;
            _description = string.Empty;
            _compulsory = true;
            _scales = 0;
        }

        protected override void Select(bool directed, bool forward)
        {
            base.Select(directed, forward);
            _combBox.Select();
        }
    }
}
