using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan
{
    public interface ICIPAdjustmentView
    {
        event EventHandler MakeAdjustment;
        bool HasAdjustment { get; set; }

        long MemberID { get; set; }
        IList<CIPAdjustmentItem> CIPAdjustments { get; set; }
        decimal TotalAmount { get; }
    }
}
