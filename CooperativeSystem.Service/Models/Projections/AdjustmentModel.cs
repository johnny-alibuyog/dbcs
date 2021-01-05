using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models.Projections
{
    [Serializable]
    public class AdjustmentModel
    {
        public virtual DateTime AdjustmentDate { get; set; }
        public virtual string VoucherNumber { get; set; }
        public virtual decimal AdjustmentAmount { get; set; }
        public virtual decimal Balance { get; set; }
    }
}
