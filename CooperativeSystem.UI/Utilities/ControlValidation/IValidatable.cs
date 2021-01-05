
namespace CooperativeSystem.UI.Views.Utilities.ControlValidation
{
    public enum InputType
    {
        Normal,
        Alphanumeric,
        AlphaOnly,
        NumericOnly,
        DecimalOnly,
        Currency,
        Email,
        URL,
    }

    public interface IValidatable
    {
        InputType InputType { get; set; }
        string Description { get; set; }
        string ErrorMessage { get; }
        bool Compulsory { get; set; }
        int MaxLength { get; set; }
        int Scales { get; set; }

        bool ValidateContent();
    }
}
