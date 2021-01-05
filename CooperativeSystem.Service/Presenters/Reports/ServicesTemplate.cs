using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CooperativeSystem.Service.Presenters.Reports
{
    [DataContract]
    public abstract class ServicesTemplate
    {
        #region Fields

        // loan
        private Nullable<decimal> _loan;

        // plans
        private Nullable<decimal> _collegeInsurancePlan;
        private Nullable<decimal> _pensionPlan;

        // savings
        private Nullable<decimal> _capitalShare;
        private Nullable<decimal> _savingsDeposit;
        private Nullable<decimal> _timeDeposit;

        // special funds
        private Nullable<decimal> _deathAidFund;
        private Nullable<decimal> _tulunganFund;

        private Nullable<decimal> _total;

        #endregion

        #region Properties

        // loans
        [DataMember]
        public virtual Nullable<decimal> Loan
        {
            get { return _loan; }
            set { _loan = value != null ? value.Value : 0M; }
        }

        // plans
        [DataMember]
        public virtual Nullable<decimal> CollegeInsurancePlan
        {
            get { return _collegeInsurancePlan; }
            set { _collegeInsurancePlan = value != null ? value.Value : 0M; }
        }

        [DataMember]
        public virtual Nullable<decimal> PensionPlan
        {
            get { return _pensionPlan; }
            set { _pensionPlan = value != null ? value.Value : 0M; }
        }


        // savings
        [DataMember]
        public virtual Nullable<decimal> CapitalShare
        {
            get { return _capitalShare; }
            set { _capitalShare = value != null ? value.Value : 0M; }
        }

        [DataMember]
        public virtual Nullable<decimal> SavingsDeposit
        {
            get { return _savingsDeposit; }
            set { _savingsDeposit = value != null ? value.Value : 0M; }
        }

        [DataMember]
        public virtual Nullable<decimal> TimeDeposit
        {
            get { return _timeDeposit; }
            set { _timeDeposit = value != null ? value.Value : 0M; }
        }


        // special funds
        [DataMember]
        public virtual Nullable<decimal> DeathAidFund
        {
            get { return _deathAidFund; }
            set { _deathAidFund = value != null ? value.Value : 0M; }
        }

        [DataMember]
        public virtual Nullable<decimal> TulunganFund
        {
            get { return _tulunganFund; }
            set { _tulunganFund = value != null ? value.Value : 0M; }
        }

        [DataMember]
        public virtual decimal Total
        {
            get
            {
                if (_total == null)
                {
                    _total = new Nullable<decimal>(
                        (Loan ?? 0M) +
                        (CollegeInsurancePlan ?? 0M) +
                        (PensionPlan ?? 0M) +
                        (CapitalShare ?? 0M) +
                        (SavingsDeposit ?? 0M) +
                        (TimeDeposit ?? 0M) +
                        (DeathAidFund ?? 0M) +
                        (TulunganFund ?? 0M));
                }
                return _total.Value;
            }
        }

        #endregion

        #region Constructor

        public ServicesTemplate()
        {
            // loans
            Loan = 0M;

            // plans
            CollegeInsurancePlan = 0M;
            PensionPlan = 0M;

            // savings
            CapitalShare = 0M;
            SavingsDeposit = 0M;
            TimeDeposit = 0M;

            // special funds
            DeathAidFund = 0M;
            TulunganFund = 0M;
        }

        #endregion
    }
}
