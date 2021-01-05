using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Adjustments
{
    public abstract class AdjustmentTemplate : ServicesTemplate 
            {
        private Nullable<decimal> _miscellaneousIncomeAdjustment;
        private Nullable<decimal> _total;

        public virtual Nullable<decimal> MiscellaneousIncome
        {
            get { return _miscellaneousIncomeAdjustment; }
            set { _miscellaneousIncomeAdjustment = value != null ? value.Value : 0M; }
        }

        public override decimal Total
        {
            get
            {
                if (_total == null)
                {
                    _total = new Nullable<decimal>(
                        (base.Total) +
                        (MiscellaneousIncome ?? 0M));
                }
                return _total.Value;
            }
        }

        public AdjustmentTemplate()
        {
            MiscellaneousIncome = 0M;
        }
    }

}
