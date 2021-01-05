using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan
{
    public class CIPAdjustmentItem
    {
        public virtual long CollegeInsurancePlanID { get; set; }
        public virtual string UserName { get; set; }
        public virtual decimal Amount { get; set; }
    }
}
