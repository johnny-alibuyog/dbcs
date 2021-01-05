
namespace CooperativeSystem.UI.Views.Loans.Factories
{
    public interface IPaymentFormFactory
    {
        LoanPaymentView CreateForm(LoanType loanType);
    }
}
