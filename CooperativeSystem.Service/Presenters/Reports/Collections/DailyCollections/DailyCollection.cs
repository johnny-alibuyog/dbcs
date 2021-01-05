using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Collections.DailyCollections
{
    public class DailyCollection : CollectionTemplate
    {
        public virtual string Member { get; set; }
        public virtual string User { get; set; }
        public virtual string ORNumber { get; set; }
    }
}
