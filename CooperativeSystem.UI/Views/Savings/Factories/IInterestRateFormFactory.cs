using System;

namespace CooperativeSystem.UI.Views.Savings.Factories
{
    interface IInterestRateFormFactory
    {
        InterestRateFormTemplate CreateForm(SavingsType savingsType);
    }
}
