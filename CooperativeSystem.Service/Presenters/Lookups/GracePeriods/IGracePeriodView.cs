
namespace CooperativeSystem.Service.Presenters.Lookups.GracePeriods
{
    public interface IGracePeriodView
    {
        int Daily { get; set; }
        int Weekly { get; set; }
        int SemiMonthly { get; set; }
        int Monthly { get; set; }
    }
}
