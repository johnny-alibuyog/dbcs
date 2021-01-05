using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.IndividualLedgersRevision
{
    public class Account
    {
        public virtual string Member { get; set; }
        public virtual string Service { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string TransactionType { get; set; }
        public virtual string ORJVNumber { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal Balance { get; set; }
    }
}
