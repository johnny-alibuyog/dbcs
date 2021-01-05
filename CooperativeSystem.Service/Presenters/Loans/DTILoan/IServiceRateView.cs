
namespace CooperativeSystem.Service.Presenters.Loans.DTILoan
{
    public interface IServiceRateView
    {
        decimal ServiceFeeRate { get; set; }
        decimal CollectionFeeRate { get; set; }
        decimal LoanGuaranteeFundRate { get; set; }
        decimal CapitalBuildupRate { get; set; }
        decimal InterestRate { get; set; }
    }
}
