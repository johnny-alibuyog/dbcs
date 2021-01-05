using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models.Projections
{
    [Serializable]
    public class TimeDepositModel
    {
        public virtual long TimeDepositID { get; set; }
        public virtual DateTime MaturityDate { get; set; }
        public virtual decimal Interest { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal TotalAmount { get { return Interest + Amount; } }
    }
}
