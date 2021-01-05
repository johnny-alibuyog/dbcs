using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models.Projections
{
    [Serializable]
    public class ReceiptModel
    {
        public virtual DateTime PaymentDate { get; set; }
        public virtual string ReceiptNumber { get; set; }
        public virtual decimal Condoned { get; set; }
        public virtual decimal PaymentAmount { get; set; }
        public virtual decimal Balance { get; set; }
    }
}
