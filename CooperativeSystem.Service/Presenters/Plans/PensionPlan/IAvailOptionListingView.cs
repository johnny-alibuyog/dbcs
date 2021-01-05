using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Plans.PensionPlan
{
    public interface IAvailOptionListingView
    {
        void PopulateListing(IList<PensionPlanAvailOption> modelList);
    }
}
