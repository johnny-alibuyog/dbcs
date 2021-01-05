
namespace CooperativeSystem.Service.Presenters.Lookups.Services
{
    public interface IServicesAdapter
    {
        // loans
        bool ApplianceLoan { get; set; }
        bool EasyLoan { get; set; }
        bool EmergencyLoan { get; set; }
        bool EquityLoan { get; set; }
        bool PensionLoan { get; set; }
        bool RegularLoan { get; set; }
        bool DTILoan { get; set; }      // TODO: DTI Loan will not be included
        bool MEDPLoan { get; set; }     // TODO: MEDP Loan will not be included

        // plans
        bool CollegeInsurancePlan { get; set; }
        bool PensionPlan { get; set; }

        // savings
        bool CapitalShare { get; set; }
        bool SavingsDeposit { get; set; }
        bool TimeDeposit { get; set; }

        // special funds
        bool DeathAidFund { get; set; }
        bool TulunganFund { get; set; }
    }
}
