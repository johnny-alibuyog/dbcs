using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.PensionPlanAvailOptions;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Presenters.Plans.PensionPlan
{
    public class PensionPlanWithdrawalAssessmentModel
    {
        private PensionPlanAvailOption _availOption;
        private bool _consumed;
        private Nullable<DateTime> _applicationDate;
        private Nullable<DateTime> _paymentCompeletionDate;
        private Nullable<DateTime> _maturityDate;
        private Nullable<decimal> _paymentCompletionAmount;
        private Nullable<decimal> _awardAmount;
        private Nullable<decimal> _paidAmount;
        private Nullable<decimal> _interests;
        private Nullable<decimal> _disbursedAmount;
        private Nullable<decimal> _monthlyPension;

        public virtual PensionPlanAvailOption AvailOption 
        {
            get { return _availOption; }
            internal set { _availOption = value; }
        }

        public virtual bool Consumed
        {
            get { return _consumed; }
            internal set { _consumed = value; }
        }

        public virtual Nullable<DateTime> ApplicationDate
        {
            get { return _applicationDate; }
            internal set { _applicationDate = value; }
        }

        public virtual Nullable<DateTime> PaymentCompeletionDate
        {
            get { return _paymentCompeletionDate; }
            internal set { _paymentCompeletionDate = value; }
        }

        public virtual Nullable<DateTime> MaturityDate
        {
            get { return _maturityDate; }
            internal set { _maturityDate = value; }
        }

        public virtual Nullable<decimal> PaymentCompletionAmount
        {
            get { return _paymentCompletionAmount; }
            internal set { _paymentCompletionAmount = value; }
        }

        public virtual Nullable<decimal> AwardAmount
        {
            get { return _awardAmount; }
            internal set { _awardAmount = value; }
        }

        public virtual Nullable<decimal> PaidAmount
        {
            get { return _paidAmount; }
            internal set { _paidAmount = value ?? 0M; }
        }

        public virtual Nullable<decimal> Interests
        {
            get { return _interests; }
            internal set { _interests = value ?? 0M; }
        }

        public virtual Nullable<decimal> DisbursedAmount
        {
            get { return _disbursedAmount; }
            internal set { _disbursedAmount = value ?? 0M; }
        }

        public virtual Nullable<decimal> MonthlyPension
        {
            get { return _monthlyPension; }
            internal set { _monthlyPension = value; }
        }

        public virtual bool IsMatured
        {
            get 
            {
                if (MaturityDate == null)
                    return false;

                if (MaturityDate.Value.TruncateTime() > DateTime.Today)
                    return false;

                return true;
            }
        }

        public virtual Nullable<decimal> MaximumWithdrawableAmount
        {
            get
            {
                var value = (IsMatured)
                    ? AwardAmount.Value
                    : PaidAmount.Value;

                return value + Interests.Value - DisbursedAmount.Value;
            }
        }
        
        public virtual Nullable<decimal> WithdrawAmount 
        {
            get 
            {
                var amount = 0M;
                if (IsMatured)
                {
                    var isDisbursedMonthly = (AvailOption.AvailOptionID == PensionPlanAvailOptionCodes.Option2);
                    if (isDisbursedMonthly && MonthlyPension != null && MaximumWithdrawableAmount > MonthlyPension.Value)
                        amount = MonthlyPension.Value;
                    else
                        amount = MaximumWithdrawableAmount.Value;
                }
                else
                {
                    amount = MaximumWithdrawableAmount.Value;
                }
                return amount;
            }
        }
    }
}
