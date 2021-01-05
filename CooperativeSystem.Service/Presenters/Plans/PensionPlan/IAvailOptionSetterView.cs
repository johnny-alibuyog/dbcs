using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Plans.PensionPlan
{
    public interface IAvailOptionSetterView
    {
        event EventHandler Changed;

        long MemberID { get; set; }
        PensionPlanAvailOption AvailOption { get; set; }
        bool WithMonthlyPension { get; set; }
        Nullable<decimal> MonthlyPension { get; set; }
        decimal AwardAmount { get; set; }
        int AgingPeriod { get; set; }
        string AvailOptionDescription { get; set; }

        void PopulateAvailOption(IList<PensionPlanAvailOption> availOptions);
    }
}
