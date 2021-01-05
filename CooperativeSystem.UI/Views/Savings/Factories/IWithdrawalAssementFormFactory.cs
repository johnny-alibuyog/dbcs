
namespace CooperativeSystem.UI.Views.Savings.Factories
{
    public interface IWithdrawalAssementFormFactory
    {
        WithdrawalAssessmentFormTemplate CreateForm(SavingsType savingsType);
    }
}
