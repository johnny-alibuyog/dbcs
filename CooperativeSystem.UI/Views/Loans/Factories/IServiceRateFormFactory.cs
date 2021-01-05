using System.Windows.Forms;

namespace CooperativeSystem.UI.Views.Loans.Factories
{
    public interface IServiceRateFormFactory
    {
        Form CreateForm(LoanType loanType);
    }
}