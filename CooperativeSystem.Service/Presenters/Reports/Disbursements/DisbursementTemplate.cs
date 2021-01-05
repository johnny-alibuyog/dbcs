using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CooperativeSystem.Service.Presenters.Reports.Disbursements
{
    [DataContract]
    public abstract class DisbursementTemplate : ServicesTemplate 
    {
        private Nullable<decimal> _miscellaneousIncomeDisbursement;
        private Nullable<decimal> _total;

        [DataMember]
        public virtual Nullable<decimal> MiscellaneousIncome
        {
            get { return _miscellaneousIncomeDisbursement; }
            set { _miscellaneousIncomeDisbursement = value != null ? value.Value : 0M; }
        }

        [DataMember]
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

        public DisbursementTemplate()
        {
            MiscellaneousIncome = 0M;
        }
    }
}
