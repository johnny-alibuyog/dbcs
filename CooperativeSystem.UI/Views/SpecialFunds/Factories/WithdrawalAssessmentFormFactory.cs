using System;

namespace CooperativeSystem.UI.Views.SpecialFunds.Factories
{
    public class WithdrawalAssessmentFormFactory : CooperativeSystem.UI.Views.SpecialFunds.Factories.IWithdrawalAssessmentFormFactory
    {
        public WithdrawalAssessmentFormTemplate CreateForm(SpecialFundType specialFundType)
        {
            switch (specialFundType)
            {
                case SpecialFundType.DeathAidFund:
                    return new DeathAidFund.DeathAidFundWithdrawalAssessmentView();
                case SpecialFundType.TulunganFund:
                    return new TulunganFund.TulunganFundWithdrawalAssessmentView();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
