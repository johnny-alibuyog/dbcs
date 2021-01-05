using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Collections.MonthlyCollections
{
    public class MonthlyCollection : CollectionTemplate
    {
        public virtual int Day { get; set; }
    }
}
