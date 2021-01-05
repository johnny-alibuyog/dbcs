using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models.Projections
{
    public class CIPModel
    {
        public virtual long CollegeInsurancePlanID { get; set; }
        public virtual string Status { get; set; }
        public virtual string UserName { get; set; }
        public virtual Nullable<DateTime> MaturityDate { get; set; }
    }
}
