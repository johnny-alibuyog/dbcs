using System.Windows.Forms;

namespace CooperativeSystem.UI.Views.Utilities.ControlValidation
{
    public class Factory
    {
        public IValidatable CreateDecoratedControl(Control control)
        {
            if (control is TextBox)
                return new TextBoxDecorator((TextBox)control);
            else if (control is ComboBox)
                return new ComboBoxDecorator((ComboBox)control);
            else if (control is MaskedTextBox)
                return new MaskedTextBoxDecorator((MaskedTextBox)control);
            else
                return null;
        }
    }
}
