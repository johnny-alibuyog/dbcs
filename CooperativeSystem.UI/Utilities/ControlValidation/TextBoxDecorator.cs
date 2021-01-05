using System;
using System.Text;
using System.Windows.Forms;

namespace CooperativeSystem.UI.Views.Utilities.ControlValidation
{
    public class TextBoxDecorator : TextBox, IValidatable
    {
        private TextBox _textBox;

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
                if (_textBox.Text.Trim() == string.Empty)
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
            get { return _textBox.MaxLength; }
            set { _textBox.MaxLength = value; }
        }

        public int Scales
        {
            get { return _scales; }
            set { _scales = value; }
        }

        public bool ValidateContent()
        {
            if (!_textBox.Enabled)
                return true;

            if (_textBox.ReadOnly)
                return true;

            if (_textBox.Text.Trim() == string.Empty)
            {
                if (Compulsory)
                    return false; // compulsory feild not inputed.
                else
                    return true;  // allow empty inputs for optional fields.
            }
            else
            {
                if (InputType == InputType.Normal)
                    return true;  // no specific pattern
                else
                    return ControlValidator.ValidateStringInput(
                        InputType, _textBox.Text); // check if pattern matches
            }
        }

        #endregion

        public TextBoxDecorator(TextBox textBox)
        {
            _textBox = textBox;
            _textBox.Enter += new EventHandler(TextBox_Enter);
            _textBox.Leave += new EventHandler(TextBox_Leave);
            _textBox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);

            _inputTextType = InputType.Normal;
            _description = string.Empty;
            _compulsory = true;
            _scales = 0;
        }

        protected override void Select(bool directed, bool forward)
        {
            base.Select(directed, forward);
            _textBox.Select();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int keyAscii = (int)(e.KeyChar);

            const int CUT = 3;
            const int COPY = 22;
            const int PASTE = 24;
            const int BACK_SPACE = 8;

            // allow cut, copy, paste and back space
            if (keyAscii == CUT || keyAscii == COPY || keyAscii == PASTE || keyAscii == BACK_SPACE)
                return;

            e.Handled = !ControlValidator.ValidateCharInput(InputType, e.KeyChar);
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                StringBuilder format;
                if (InputType == InputType.DecimalOnly)
                {
                    // build format
                    format = new StringBuilder("#0");
                    if (Scales > 0)
                        format.Append(".").Append('0', (int)Scales);

                    decimal newValue;
                    if (decimal.TryParse(_textBox.Text, out newValue))
                        _textBox.Text = newValue.ToString(format.ToString());
                }
                else if (InputType == InputType.Currency)
                {
                    // build currenty format
                    format = new StringBuilder("N");
                    if (Scales > 0)
                        format.Append(((int)Scales).ToString());

                    decimal newValue;
                    if (decimal.TryParse(_textBox.Text, out newValue))
                        _textBox.Text = newValue.ToString(format.ToString());
                }
            }
            catch { } // ignore error and push through
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            _textBox.SelectAll(); // highlight text on select
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            ResumeLayout(false);

        }
    }
}