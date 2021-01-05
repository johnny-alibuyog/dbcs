using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Collections
{
    public abstract class CollectionTemplate : ServicesTemplate
    {
        // loan
        private Nullable<decimal> _latePaymentFine;
        private Nullable<decimal> _delinquentFine;

        // misc
        private Nullable<decimal> _otherReceipt;
        private Nullable<decimal> _miscellaneousIncomeReceipt;
        private Nullable<decimal> _membershipFeeReceipt;

        private Nullable<decimal> _total;

        // loans
        public virtual Nullable<decimal> LatePaymentFine
        {
            get { return _latePaymentFine; }
            set { _latePaymentFine = value != null ? value.Value : 0M; }
        }

        public virtual Nullable<decimal> DelinquentFine
        {
            get { return _delinquentFine; }
            set { _delinquentFine = value != null ? value.Value : 0M; }
        }

        // misc
        public virtual Nullable<decimal> OtherReceipt
        {
            get { return _otherReceipt; }
            set { _otherReceipt = value != null ? value.Value : 0M; }
        }

        public virtual Nullable<decimal> MiscellaneousIncome
        {
            get { return _miscellaneousIncomeReceipt; }
            set { _miscellaneousIncomeReceipt = value != null ? value.Value : 0M; }
        }

        public virtual Nullable<decimal> MembershipFee  
        {
            get { return _membershipFeeReceipt; }
            set { _membershipFeeReceipt = value != null ? value.Value : 0M; }
        }

        public override decimal Total
        {
            get
            {
                if (_total == null)
                {
                    _total = new Nullable<decimal>(
                        (base.Total) +
                        // loans
                        (LatePaymentFine ?? 0M) +
                        (DelinquentFine ?? 0M) +
                        // misc
                        (OtherReceipt ?? 0M) +
                        (MiscellaneousIncome ?? 0M) +
                        (MembershipFee ?? 0M));
                }
                return _total.Value;
            }
        }

        public CollectionTemplate()
            : base()
        {
            // loans
            LatePaymentFine = 0M;
            DelinquentFine = 0M;

            // misc
            OtherReceipt = 0M;
            MiscellaneousIncome = 0M;
            MembershipFee = 0M;
        }
    }
}
