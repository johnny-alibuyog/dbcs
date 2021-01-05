using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.TimeDeposit
{
    [Serializable]
    public class TimeDepositTransaction
    {
        public virtual string Status { get; set; }
        public virtual DateTime DepositDate { get; set; }
        public virtual decimal DepositAmount { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual int Terms { get; set; }
        public virtual decimal InterestRate { get; set; }
        public virtual Nullable<decimal> Interest { get; set; }
        public virtual DateTime MaturityDate { get; set; }
        public virtual Nullable<DateTime> DisbursementDate { get; set; }
        public virtual Nullable<decimal> DisbursementAmount { get; set; }
        public virtual bool Consumed { get; set; }
    }
}
