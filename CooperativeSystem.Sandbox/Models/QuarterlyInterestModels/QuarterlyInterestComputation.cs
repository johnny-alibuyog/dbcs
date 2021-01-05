using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Sandbox.Models.QuarterlyInterestModels
{
    public class QuarterlyInterestComputation
    {
        public virtual Quarter Quarter { get; set; }
        public virtual Member Member { get; set; }
        public virtual IList<AverageDailyBalance> AverageDailyBalances { get; set; }
    }
}
