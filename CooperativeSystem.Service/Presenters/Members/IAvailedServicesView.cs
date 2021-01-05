using CooperativeSystem.Service.Models.Lookups.MembershipCategoryServices;
using CooperativeSystem.Service.Presenters.Lookups.Services;

namespace CooperativeSystem.Service.Presenters.Members
{
    public interface IAvailedServicesView : IServicesAdapter
    {
        // methods
        void EnableServicesBasedOnMembershipCategoyAndServicesAvailed(IServicesAdapter allowableServices, IServicesAdapter availedServices);
    }
}
