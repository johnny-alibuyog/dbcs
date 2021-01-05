
namespace CooperativeSystem.UI.Views.Plans.Factories
{
    public interface IPaymentFormFactory
    {
        PaymentFormTemplate CreateForm(PlanType planType);
    }
}
