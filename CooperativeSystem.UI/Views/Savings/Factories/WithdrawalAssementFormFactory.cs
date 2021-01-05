using System;

namespace CooperativeSystem.UI.Views.Savings.Factories
{
    public class WithdrawalAssementFormFactory : CooperativeSystem.UI.Views.Savings.Factories.IWithdrawalAssementFormFactory
    {
        public WithdrawalAssessmentFormTemplate CreateForm(SavingsType savingsType)
        {
            switch (savingsType)
            {
                case SavingsType.CapitalShares:
                    return new CapitalShares.WithdrawalAssessmentView();
                case SavingsType.SavingsDeposit:
                    return new SavingsDeposit.WithdrawalAssessmentView();
                case SavingsType.TimeDeposit:
                    return new TimeDeposit.WidrawalAssessmentView();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
