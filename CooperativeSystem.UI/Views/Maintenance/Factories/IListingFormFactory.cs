using System;

namespace CooperativeSystem.UI.Views.Maintenance.Factories
{
    interface IListingFormFactory
    {
        ListingFormTemplate CreateForm(RegistrationType registrationType);
    }
}
