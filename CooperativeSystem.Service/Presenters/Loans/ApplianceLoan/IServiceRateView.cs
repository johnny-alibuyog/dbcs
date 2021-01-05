
namespace CooperativeSystem.Service.Presenters.Loans.ApplianceLoan
{
    public interface IServiceRateView
    {
        decimal AddOnMaximumAmount { get; set; }
        decimal AddOnServiceFee { get; set; }
        decimal AddOnCollectionFee { get; set; }
        decimal AddOnCapitalBuildup { get; set; }
        decimal AddOnInterest { get; set; }

        decimal DeductedMaximumAmount { get; set; }
        decimal DeductedServiceFee { get; set; }
        decimal DeductedCollectionFee { get; set; }
        decimal DeductedCapitalBuildup { get; set; }
        decimal DeductedInterest { get; set; }
    }
}
