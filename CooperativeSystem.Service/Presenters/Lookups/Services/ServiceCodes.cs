
namespace CooperativeSystem.Service.Presenters.Lookups.Services
{
    public sealed class ServiceCodes
    {
        // loans
        public const string ApplianceLoan = "AL";
        public const string EasyLoan = "EsL";
        public const string EmergencyLoan = "EmL";   
        public const string EquityLoan = "EqL";
        public const string PensionLoan = "PL";
        public const string RegularLoan = "RL";
        public const string DTILoan = "DTIL";       // TODO: remove this code soon
        public const string MEDPLoan = "MEDPL";       // TODO: remove this code soon

        // plans
        public const string CollegeInsurancePlan = "CIP";
        public const string PensionPlan = "PP";

        // savings
        public const string CapitalShare = "CS";
        public const string SavingsDeposit = "SD";
        public const string TimeDeposit = "TD";

        // special funds
        public const string DeathAidFund = "DAF";
        public const string TulunganFund = "TF";
    }
}
