using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Sandbox.Models.QuarterlyInterestModels
{
    public class Quarter
    {
        public virtual int QuarterId { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Month> Months {get; set;}
    }
}
