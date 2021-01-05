using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models
{
    public partial class LatePaymentFineReceipt
    {
        public virtual decimal GetUnpaidBalance()
        {
            if (this.Condone == true)
                return 0M;

            if (this.ComputedAmount == null)
                return 0M;

            if (this.Amount > this.ComputedAmount.Value)
                return 0M;

            return this.ComputedAmount.Value - this.Amount;
        }
    }
}
