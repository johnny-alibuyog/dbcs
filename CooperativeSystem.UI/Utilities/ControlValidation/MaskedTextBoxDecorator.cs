using System.Windows.Forms;

namespace CooperativeSystem.UI.Views.Utilities.ControlValidation
{
    public class MaskedTextBoxDecorator : MaskedTextBox, IValidatable
    {
        private MaskedTextBox _maskedTextBox;

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
            get { return "Unspecified."; } // TODO: specify error message algorithm
        }

        public bool Compulsory
        {
            get { return _compulsory; }
            set { _compulsory = value; }
        }

        public new int MaxLength
        {
            get { return _maskedTextBox.MaxLength; }
            set { _maskedTextBox.MaxLength = value; }
        }

        public int Scales
        {
            get { return _scales; }
            set { _scales = value; }
        }

        public bool ValidateContent()
        {
            return true; // TODO: specify error validation algorithm
        }

        #endregion

        public MaskedTextBoxDecorator(MaskedTextBox maskedTextBox)
        {
            _maskedTextBox = maskedTextBox;

            _inputTextType = InputType.Normal;
            _description = string.Empty;
            _compulsory = true;
            _scales = 0;
        }

        protected override void Select(bool directed, bool forward)
        {
            base.Select(directed, forward);
            _maskedTextBox.Select();
        }
    }
}
