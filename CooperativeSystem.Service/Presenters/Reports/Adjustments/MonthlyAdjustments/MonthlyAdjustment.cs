using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Adjustments.MonthlyAdjustments
{
    public class MonthlyAdjustment : AdjustmentTemplate
    {
        public virtual int Day { get; set; }
    }
}
