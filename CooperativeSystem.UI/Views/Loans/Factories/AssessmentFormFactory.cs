using System;

namespace CooperativeSystem.UI.Views.Loans.Factories
{
    public class AssessmentFormFactory : IAssessmentFormFactory
    {
        public LoanAssessmentView CreateView(LoanType loanType)
        {
            switch (loanType)
            {
                case LoanType.ApplianceLoan:
                    return new ApplianceLoan.AssessmentView();
                case LoanType.EasyLoan:
                    return new EasyLoan.AssessmentView();
                case LoanType.EmergencyLoan:
                    return new EmergencyLoan.AssessmentView();
                case LoanType.EquityLoan:
                    return new EquityLoan.AssessmentView();
                case LoanType.PensionLoan:
                    return new PensionLoan.AssessmentView();
                case LoanType.RegularLoan:
                    throw new NotImplementedException(string.Format("Implementation for {0} not yet definded.", loanType));
                default:
                    throw new ArgumentException();
            }
        }
    }
}
