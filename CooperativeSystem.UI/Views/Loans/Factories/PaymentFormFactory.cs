using System;

namespace CooperativeSystem.UI.Views.Loans.Factories
{
    public class PaymentFormFactory : IPaymentFormFactory
    {
        public LoanPaymentView CreateForm(LoanType loanType)
        {
            switch (loanType)
            {
                case LoanType.ApplianceLoan:
                    return new ApplianceLoan.PaymentView();
                case LoanType.EasyLoan:
                    return new EasyLoan.PaymentView();
                case LoanType.EmergencyLoan:
                    return new EmergencyLoan.PaymentView();
                case LoanType.EquityLoan:
                    return new EquityLoan.PaymentView();
                case LoanType.PensionLoan:
                    throw new NotImplementedException(string.Format("Implementation for {0} not yet definded.", loanType));
                case LoanType.RegularLoan:
                    throw new NotImplementedException(string.Format("Implementation for {0} not yet definded.", loanType));
                default:
                    throw new ArgumentException();
            }
        }
    }
}
