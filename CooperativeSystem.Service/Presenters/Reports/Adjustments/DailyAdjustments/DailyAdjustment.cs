using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Adjustments.DailyAdjustments
{
    public class DailyAdjustment : AdjustmentTemplate
    {
        public virtual string Member { get; set; }
        public virtual string JVNumber { get; set; }
        public virtual string User { get; set; }
        //public virtual string ORNumber { get; set; }

        public DailyAdjustment()
        {
        }
    }
}
