using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Presenters.Savings.TimeDeposit
{
    public class TimeDepositWithdrawalAssessmentModel
    {
        private long _timeDepositID;
        private DateTime _depositDate;
        private DateTime _maturityDate;
        private int _terms;
        private Nullable<decimal> _interest;
        private decimal _interestRate;
        private decimal _principalAmount;

        #region Routine Helpers

        private decimal ComputeInterest()
        {
            const decimal DAYS_IN_A_MONTH = 30;
            const decimal DAYS_IN_A_YEAR = 365;

            return PrincipalAmount *
                (InterestRate / 100) *                                             // interest rate
                (Terms * DAYS_IN_A_MONTH / DAYS_IN_A_YEAR) *                       // terms
                (((DateTime.Today - DepositDate).Days / DAYS_IN_A_MONTH) / Terms); // number of terms covered
        }

        #endregion

        public virtual long TimeDepositID 
        {
            get { return _timeDepositID; }
            internal set { _timeDepositID = value; } 
        }

        public virtual DateTime DepositDate
        {
            get { return _depositDate; }
            internal set { _depositDate = value; }
        }

        public virtual DateTime MaturityDate
        {
            get { return _maturityDate; }
            internal set { _maturityDate = value; }
        }

        public virtual int Terms
        {
            get { return _terms; }
            internal set { _terms = value; }
        }

        public virtual decimal InterestRate
        {
            get { return _interestRate; }
            internal set { _interestRate = value; }
        }

        public virtual decimal PrincipalAmount
        {
            get { return _principalAmount; }
            internal set { _principalAmount = value; }
        }


        public virtual bool IsMatured
        {
            get
            {
                if (MaturityDate == null)
                    return false;

                if (MaturityDate.TruncateTime() > DateTime.Today)
                    return false;

                return true;
            }
        }

        public virtual decimal Interest 
        {
            get 
            {
                if (_interest == null)
                {
                    if (IsMatured)
                        _interest = ComputeInterest();
                    else
                        _interest = 0M;
                }
                return _interest.Value;
            }
        }

        public virtual decimal WithdrawAmount 
        {
            get { return PrincipalAmount + Interest; } 
        }
    }
}
