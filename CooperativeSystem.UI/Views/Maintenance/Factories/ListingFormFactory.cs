using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.UI.Views.Maintenance.Factories
{
    public class ListingFormFactory : CooperativeSystem.UI.Views.Maintenance.Factories.IListingFormFactory
    {
        public ListingFormTemplate CreateForm(RegistrationType registrationType)
        {
            switch (registrationType)
            {
                case RegistrationType.Member:
                    return new Member.MemberListingView();
                case RegistrationType.PensionPlanAvailOption:
                    return new Plans.PensionPlan.AvailOptionListingView();
                case RegistrationType.Relation:
                    return new Lookups.RelationListingView();
                case RegistrationType.User:
                    return new User.UserListingView();
                default:
                    return null;
            }
        }
    }
}
