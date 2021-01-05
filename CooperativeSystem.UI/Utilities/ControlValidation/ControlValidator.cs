using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CooperativeSystem.Service.Utilities.Logs;

namespace CooperativeSystem.UI.Views.Utilities.ControlValidation
{
    public class ControlValidator
    {
        public delegate void ErrorHandler(object sender, string message);
        public event ErrorHandler ErrorOccured;

        private List<IValidatable> _items;

        public ControlValidator()
        {
            _items = new List<IValidatable>();
        }

        #region Error Event

        protected void RaiseErrorEvent(string message)
        {
            OnError(this, message);
        }

        protected virtual void OnError(object sender, string message)
        {
            if (ErrorOccured != null)
                ErrorOccured(sender, message);
        }

        #endregion

        #region Control Registration Overload

        public void RegisterControl(Control control)
        {
            RegisterControl(control, InputType.Normal);
        }

        public void RegisterControl(Control control, InputType inputType)
        {
            RegisterControl(control, inputType, true);
        }

        public void RegisterControl(Control control, InputType inputType, bool compulsory)
        {
            RegisterControl(control, inputType, compulsory, string.Empty);
        }

        public void RegisterControl(Control control, InputType inputType, bool compulsory, string description)
        {
            RegisterControl(control, inputType, compulsory, description, 32767);
        }

        public void RegisterControl(Control control, InputType inputType, bool compulsory, string description, int maxLength)
        {
            RegisterControl(control, inputType, compulsory, description, maxLength, 0);
        }

        public void RegisterControl(Control contol, InputType inputType, bool compulsory, string description, int maxLength, int scales)
        {
            IValidatable item = new Factory().CreateDecoratedControl(contol);
            if (item != null)
            {
                item.InputType = inputType;
                item.Compulsory = compulsory;
                item.Description = description;
                item.MaxLength = maxLength;
                item.Scales = scales;
                _items.Add(item);
            }
            else
            {
                ErrorLogger logger = new ErrorLogger();
                logger.Log(string.Format("{0} not defined in control decorator factory.", contol.ToString()));
            }
        }

        #endregion

        public bool Validate()
        {
            foreach (var item in _items)
            {
                if (!item.ValidateContent())
                {
                    RaiseErrorEvent(item.ErrorMessage);
                    ((Control)item).Select();
                    return false;
                }
            }

            return true;
        }

        #region Static Routine Helpers

        public static bool ValidateStringInput(InputType inputType, string stringInput)
        {
            string pattern = string.Empty;
            switch (inputType)
            {
                case InputType.Normal:
                    return true;
                case InputType.Alphanumeric:
                    pattern = @"^[0-9a-zA-Z]+$";
                    return (new Regex(pattern, RegexOptions.IgnoreCase).IsMatch(stringInput));
                case InputType.AlphaOnly:
                    pattern = @"^[a-zA-Z]+$";
                    return (new Regex(pattern, RegexOptions.IgnoreCase).IsMatch(stringInput));
                case InputType.NumericOnly:
                    pattern = @"^[0-9]*$";
                    return (new Regex(pattern).IsMatch(stringInput));
                case InputType.DecimalOnly:
                    pattern = @"^[0-9.]*$";
                    return (new Regex(pattern).IsMatch(stringInput));
                case InputType.Currency:
                    pattern = @"^-[0-9\,.]+$|^[0-9\,.]+$";
                    return (new Regex(pattern).IsMatch(stringInput));
                case InputType.Email:
                    pattern = @"^([0-9a-z]([-.\w]*[0-9a-z])*@([0-9a-z][-\w]*[0-9a-z]\.)+[a-z]{2,3})$";
                    return (new Regex(pattern, RegexOptions.IgnoreCase).IsMatch(stringInput));
                case InputType.URL:
                    pattern = @"^(ht|f)tp(s?)\:\/\/[a-z0-9]([-.\w]*[a-z0-9])*(:(0-9)*)*(\/?)([a-z0-9\-\.\?\,\'\/\\\+&amp;%\$#_=]*)?$";
                    return (new Regex(pattern, RegexOptions.IgnoreCase).IsMatch(stringInput));
                default:
                    return true;
            }
        }

        public static bool ValidateCharInput(InputType inputType, char charInput)
        {
            string pattern = string.Empty;
            string s = charInput.ToString();
            switch (inputType)
            {
                case InputType.Normal:
                    return true;
                case InputType.Alphanumeric:
                    pattern = @"[0-9a-zA-Z]";
                    return (new Regex(pattern).IsMatch(s));
                case InputType.AlphaOnly:
                    pattern = @"[a-zA-Z]";
                    return (new Regex(pattern).IsMatch(s));
                case InputType.NumericOnly:
                    pattern = @"[0-9]";
                    return (new Regex(pattern).IsMatch(s));
                case InputType.DecimalOnly:
                    pattern = @"[0-9,.]";
                    return (new Regex(pattern).IsMatch(s));
                case InputType.Currency:
                    pattern = @"[\-\0-9,.]";
                    return (new Regex(pattern).IsMatch(s));
                case InputType.Email:
                    pattern = @"[a-zA-Z0-9_\-\.@]";
                    return (new Regex(pattern).IsMatch(s));
                case InputType.URL:
                    pattern = @"[a-z0-9-.?,'/\:\;%\$#_=()]";
                    return (new Regex(pattern).IsMatch(s));
                default:
                    return true;
            }
        }

        #endregion
    }
}
