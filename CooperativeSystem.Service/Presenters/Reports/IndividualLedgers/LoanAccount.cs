using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Reports.IndividualLedgers
{
    public class LoanAccount
    {
        private Loan _loan;

        private string _member;
        private string _service;
        private DateTime? _loanDate;
        private DateTime? _dueDate;
        private string _jvNumber;
        private decimal? _principal;
        private decimal? _interest;
        private decimal? _paidAmount;
        private decimal? _latePaymentFines;
        private decimal? _delinquentCharges;
        private decimal? _outstandingBalance;

        public virtual string Member
        {
            get { return _member; }
            set { _member = value; }
        }

        public virtual string Service
        {
            get
            {
                if (_service == null)
                    _service = _loan.Service.ServiceName;
                return _service;
            }
        }

        public virtual DateTime? LoanDate
        {
            get
            {
                if (_loanDate == null)
                    _loanDate = _loan.LoanDate;
                return _loanDate;
            }
        }

        public virtual DateTime? DueDate
        {
            get
            {
                if (_dueDate == null)
                    _dueDate = _loan.DueDate;
                return _dueDate;
            }
        }

        public virtual string JVNumber
        {
            get
            {
                if (_jvNumber == null)
                    _jvNumber = _loan.LoanDisbursements.First().CashDisbursement.CashDisbursementVoucher;
                return _jvNumber;
            }
        }

        public virtual decimal? Principal
        {
            get
            {
                if (_principal == null)
                    _principal = _loan.LoanAmount;
                return _principal;
            }
        }

        public virtual decimal? Interest
        {
            get
            {
                if (_interest == null)
                    _interest = _loan.Interest;
                return _interest;
            }
        }

        public virtual decimal? PaidAmount
        {
            get
            {
                if (_paidAmount == null)
                    _paidAmount = _loan.GetPaidAmount();
                return _paidAmount;
            }
        }

        public virtual decimal? LatePaymentFines
        {
            get
            {
                if (_latePaymentFines == null)
                    _latePaymentFines = _loan.LatePaymentFineReceipts.Sum(r => r.Amount);
                return _latePaymentFines;
            }
        }

        public virtual decimal? DelinquentCharges
        {
            get
            {
                if (_delinquentCharges == null)
                    _delinquentCharges = _loan.DelinquentFineReceipts.Sum(r => r.Amount);
                return _delinquentCharges;
            }
        }

        public virtual decimal? OutstandingBalance
        {
            get
            {
                if (_outstandingBalance == null)
                    _outstandingBalance = _loan.GetOutstandingBalance();
                return _outstandingBalance;
            }
        }

        public LoanAccount(Loan loan)
        {
            _loan = loan;
        }
    }
}
