using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Sandbox.Models.QuarterlyInterestModels
{
    public class AverageDailyBalance
    {
        public virtual Month Month { get; set; }
        public virtual decimal Value { get; set; }
    }
}
