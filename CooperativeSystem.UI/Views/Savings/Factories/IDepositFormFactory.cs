using System;

namespace CooperativeSystem.UI.Views.Savings.Factories
{
    interface IDepositFormFactory
    {
        DepositFormTemplate CreateForm(SavingsType savingsType);
    }
}
