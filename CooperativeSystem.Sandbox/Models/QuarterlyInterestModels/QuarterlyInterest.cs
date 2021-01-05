using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Sandbox.Models.QuarterlyInterestModels
{
    public class QuarterlyInterest
    {
        public virtual int Year { get; set; }
        public virtual IList<QuarterlyInterestComputation> QuarterlyInterestComputations { get; set; }
    }
}
