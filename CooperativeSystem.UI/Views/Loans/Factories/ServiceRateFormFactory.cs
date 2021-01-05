using System;
using System.Windows.Forms;

namespace CooperativeSystem.UI.Views.Loans.Factories
{
    public class ServiceRateFormFactory : IServiceRateFormFactory
    {
        public Form CreateForm(LoanType loanType)
        {
            switch (loanType)
            {
                case LoanType.ApplianceLoan:
                    return new ApplianceLoan.ServiceRateView();
                case LoanType.EasyLoan:
                    return new EasyLoan.ServiceRateView();
                case LoanType.EmergencyLoan:
                    return new EmergencyLoan.ServiceRateView();
                case LoanType.EquityLoan:
                case LoanType.PensionLoan:
                case LoanType.RegularLoan:
                    return new LoanServiceRateView();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
