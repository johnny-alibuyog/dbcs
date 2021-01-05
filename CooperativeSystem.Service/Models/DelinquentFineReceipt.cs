using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models
{
    public partial class DelinquentFineReceipt
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

        public virtual decimal GetCreditedAmount()
        {
            if (this.Condone == true)
                return this.ComputedAmount ?? 0M;
            else
                return this.Amount;
        }

        //public virtual decimal GetCondonedAmount()
        //{
        //    if (this.Condone != true)
        //        return 0M;

        //    var value = (this.PreviousAmount ?? 0M) + (this.ComputedAmount ?? 0M) - this.Amount;
        //    if (value > 0M)
        //        return 0M;

        //    return value;
        //}
    }
}
