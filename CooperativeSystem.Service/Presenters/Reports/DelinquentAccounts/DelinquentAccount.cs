using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Presenters.Reports.DelinquentAccounts
{
    public class DelinquentAccount
    {
        #region Fields

        private Loan _loan;
        private FineComputationRate _fineComputationRate;

        private string _name;
        private string _loanType;
        private Nullable<decimal> _outstandingBalance;
        private Nullable<decimal> _delinquentCharge;
        private Nullable<decimal> _latePaymentFine;
        private Nullable<decimal> _capitalShare;
        private Nullable<decimal> _savingsDeposit;
        private Nullable<decimal> _timeDeposit;
        private Nullable<decimal> _netExposure;
        private Nullable<DateTime> _loanDate;
        private Nullable<DateTime> _lastPayment;
        private Nullable<DateTime> _dueDate;

        #endregion

        public DelinquentAccount() { }

        public DelinquentAccount(Loan loan, FineComputationRate rate)
        {
            this._loan = loan;
            this._fineComputationRate = rate;
        }

        #region Properties

        public virtual string Name 
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual string LoanType
        {
            get
            {
                if (string.IsNullOrEmpty(_loanType))
                    _loanType = _loan.Service.ServiceName;
                return _loanType;
            }
        }

        public virtual Nullable<decimal> OutstandingBalance 
        { 
            get 
            {
                if (_outstandingBalance == null)
                {
                    _outstandingBalance = new Nullable<decimal>();
                    _outstandingBalance = _loan.GetOutstandingBalance();
                }
                return _outstandingBalance; 
            } 
        }

        public virtual Nullable<decimal> DelinquentCharge 
        { 
            get 
            {
                if (_delinquentCharge == null)
                {
                    _delinquentCharge = new Nullable<decimal>();
                    _delinquentCharge = _loan.ComputeDelinquentCharge(_fineComputationRate);
                }
                return _delinquentCharge; 
            } 
        }

        public virtual Nullable<decimal> LatePaymentFine
        {
            get 
            {
                if (_latePaymentFine == null)
                {
                    _latePaymentFine = new Nullable<decimal>();
                    _latePaymentFine = _loan.ComputeDelayedPaymentFine(_fineComputationRate);
                }
                return _latePaymentFine;
            }
            set 
            {
            }
        }

        public virtual Nullable<decimal> CapitalShare 
        {
            get { return _capitalShare; }
            set { _capitalShare = value; }
        }

        public virtual Nullable<decimal> SavingsDeposit
        {
            get { return _savingsDeposit; }
            set { _savingsDeposit = value; }
        }

        public virtual Nullable<decimal> TimeDeposit
        {
            get { return _timeDeposit; }
            set { _timeDeposit = value; }
        }

        public virtual Nullable<decimal> NetExposure 
        {
            get 
            {
                if (_netExposure == null)
                {
                    _netExposure = new Nullable<decimal>();
                    _netExposure = CapitalShare + SavingsDeposit + TimeDeposit - OutstandingBalance;
                }
                return _netExposure; 
            }
        }

        public virtual Nullable<DateTime> LoanDate
        {
            get 
            {
                if (_loanDate == null)
                {
                    _loanDate = new Nullable<DateTime>();
                    _loanDate = _loan.LoanDate;
                }
                return _loanDate;
            }
        }

        public virtual Nullable<DateTime> LastPayment
        {
            get { return _lastPayment; }
            set { _lastPayment = value; }
        }

        public virtual Nullable<DateTime> DueDate 
        {
            get 
            {
                if (_dueDate == null)
                {
                    _dueDate = new Nullable<DateTime>();
                    _dueDate = _loan.DueDate;
                }
                return _dueDate;
            }
        }

        #endregion
    }
}
