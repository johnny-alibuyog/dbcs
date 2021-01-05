using System;

namespace CooperativeSystem.UI.Views.Savings.Factories
{
    public class DepositFormFactory : CooperativeSystem.UI.Views.Savings.Factories.IDepositFormFactory
    {
        public DepositFormTemplate CreateForm(SavingsType savingsType)
        {
            switch (savingsType)
            {
                case SavingsType.CapitalShares:
                    return new CapitalShares.DepositView();
                case SavingsType.SavingsDeposit:
                    return new SavingsDeposit.DepositView();
                //case SavingsType.TimeDeposit:
                //    return new TimeDeposit.DepositView();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
