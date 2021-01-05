
using CooperativeSystem.Service.Presenters.Members;
namespace CooperativeSystem.Service.Presenters.Lookups.Services
{
    public static class ServicesFetcherExtentions
    {
        public static void GetValuesFrom(this IServicesAdapter me, IServicesAdapter other)
        {
            if (me == null || other == null)
                return;

            // loans
            me.ApplianceLoan = other.ApplianceLoan;
            me.EasyLoan = other.EasyLoan;
            me.EmergencyLoan = other.EmergencyLoan;
            me.EquityLoan = other.EquityLoan;
            me.PensionLoan = other.PensionLoan;
            me.RegularLoan = other.RegularLoan; // TODO: review if regular loan will be included
            me.DTILoan = other.DTILoan;         // TODO: DTI Loan will not be included
            me.MEDPLoan = other.MEDPLoan;       // TODO: MEDP Loan will not be included

            // plans
            me.CollegeInsurancePlan = other.CollegeInsurancePlan;
            me.PensionPlan = other.PensionPlan;

            // savings
            me.CapitalShare = other.CapitalShare;
            me.SavingsDeposit = other.SavingsDeposit;
            me.TimeDeposit = other.TimeDeposit;

            // special funds
            me.DeathAidFund = other.DeathAidFund;
            me.TulunganFund = other.TulunganFund;
        }

        public static void SetValues(this IServicesAdapter view, bool value)
        {
            if (view == null)
                return;

            // loans
            view.ApplianceLoan = value;
            view.EasyLoan = value;
            view.EmergencyLoan = value;
            view.EquityLoan = value;
            view.PensionLoan = value;
            view.RegularLoan = value;   // TODO: review if regular loan will be included
            view.DTILoan = value;       // TODO: DTI Loan will not be included
            view.MEDPLoan = value;      // TODO: MEDP Loan will not be included

            // plans
            view.CollegeInsurancePlan = value;
            view.PensionPlan = value;

            // savings
            view.CapitalShare = value;
            view.SavingsDeposit = value;
            view.TimeDeposit = value;

            // special funds
            view.DeathAidFund = value;
            view.TulunganFund = value;
        }
    }
}
