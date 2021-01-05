using System;

namespace CooperativeSystem.UI.Views.SpecialFunds.Factories
{
    public class ContributionFormFactory : IContributionFormFactory
    {
        #region IContributionFormFactory Members

        public ContributionFormTemplate CreateForm(SpecialFundType specialFundType)
        {
            switch (specialFundType)
            {
                case SpecialFundType.DeathAidFund:
                    return new DeathAidFund.ContributionView();
                case SpecialFundType.TulunganFund:
                    return new TulunganFund.ContributionView();
                default:
                    throw new ArgumentException();
            }
        }

        #endregion
    }
}
