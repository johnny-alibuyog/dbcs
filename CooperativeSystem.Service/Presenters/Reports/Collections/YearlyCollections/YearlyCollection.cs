using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Collections.YearlyCollections
{
    public class YearlyCollection : CollectionTemplate
    {
        public virtual DateTime Date { get; set; }
        public virtual string Month { get { return Date.ToString("MMMM"); } }
    }
}
