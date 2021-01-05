using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.MiscellaneousIncomes
{
    public class MiscellaneousIncomeItem
    {
        public virtual DateTime TransactionDate { get; set; }
        public virtual string Type { get; set; }
        public virtual string User { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string Remarks { get; set; }
    }
}
