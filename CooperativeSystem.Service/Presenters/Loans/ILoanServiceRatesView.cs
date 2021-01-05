
namespace CooperativeSystem.Service.Presenters.Loans
{
    public interface ILoanCapitalBuildupRateView
    {
        decimal AddOnBelowFiveThousand { get; set; }
        decimal AddOnFiveThousandAndAbove { get; set; }

        decimal DeductedBelowFiveThousand { get; set; }
        decimal DeductedFiveThousandAndAbove { get; set; }

        decimal AddOnShareBelowFifteenThousand { get; set; }
        decimal AddOnShareFifteenThousandAndAbove { get; set; }

        decimal DeductedShareBelowFifteenThousand { get; set; }
        decimal DeductedShareFifteenThousandAndAbove { get; set; }
    }

    public interface ILoanCollectionFeeRateView
    {
        decimal AddOnOneToFiveMonths { get; set; }
        decimal AddOnSixToTenMonths { get; set; }

        decimal DeductedOneToFiveMonths { get; set; }
        decimal DeductedSixToTenMonths { get; set; }
    }

    public interface ILoanGuaranteeFundRateView
    {
        decimal AddOnOneToFiveMonths { get; set; }
        decimal AddOnSixToTenMonths { get; set; }

        decimal DeductedOneToFiveMonths { get; set; }
        decimal DeductedSixToTenMonths { get; set; }
    }

    public interface ILoanInterestRateView
    {
        decimal AddOnDaily { get; set; }
        decimal AddOnWeekly { get; set; }
        decimal AddOnSemiMonthly { get; set; }
        decimal AddOnMonthly { get; set; }

        decimal DeductedDaily { get; set; }
        decimal DeductedWeekly { get; set; }
        decimal DeductedSemiMonthly { get; set; }
        decimal DeductedMonthly { get; set; }
    }

    public interface ILoanServiceFeeRateView
    {
        decimal AddOnOneToFiveMonths { get; set; }
        decimal AddOnSixToTenMonths { get; set; }

        decimal DeductedOneToFiveMonths { get; set; }
        decimal DeductedSixToTenMonths { get; set; }
    }

    public interface ILoanServiceRateView : 
        ILoanCapitalBuildupRateView,
        ILoanCollectionFeeRateView,
        ILoanGuaranteeFundRateView,
        ILoanInterestRateView,
        ILoanServiceFeeRateView { }
}
