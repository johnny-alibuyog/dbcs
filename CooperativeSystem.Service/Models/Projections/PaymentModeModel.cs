using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models.Projections
{
    [Serializable]
    public class PaymentModeModel
    {
        public virtual string PaymentModeID { get; set; }
        public virtual string PaymentModeName { get; set; }
        public virtual decimal InterestRate { get; set; }
    }
}
