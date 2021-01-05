
namespace CooperativeSystem.UI.Views.SpecialFunds.Factories
{
    public interface IContributionFormFactory
    {
        ContributionFormTemplate CreateForm(SpecialFundType specialFundType);
    }
}
