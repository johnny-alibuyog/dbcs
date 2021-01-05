
namespace CooperativeSystem.Service.Presenters.Savings.TimeDeposit
{
    public interface IInterestRateView
    {
        decimal BelowFiftyThousand { get; set; }
        decimal FiftyToNinetyNineThousand { get; set; }
        decimal AboveNinetyNineThousand { get; set; }
    }
}
