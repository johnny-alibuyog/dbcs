using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models.Projections
{
    [Serializable]
    public class DisbursementModel
    {
        public virtual DateTime DisbursementDate { get; set; }
        public virtual string VoucherNumber { get; set; }
        public virtual decimal DisbursementAmount { get; set; }
    }
}
