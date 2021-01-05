using System;

namespace CooperativeSystem.UI.Views.Savings.Factories
{
    public class InterestRateFormFactory : IInterestRateFormFactory
    {
        public InterestRateFormTemplate CreateForm(SavingsType savingsType)
        {
            switch (savingsType)
            {
                case SavingsType.CapitalShares:
                    return null;
                case SavingsType.SavingsDeposit:
                    return new SavingsDeposit.InterestRateView();
                case SavingsType.TimeDeposit:
                    return new TimeDeposit.InterestRateView();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
