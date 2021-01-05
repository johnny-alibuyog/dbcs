using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Loans.Calculators.FineCalculators;
using CooperativeSystem.Service.Presenters.Loans.Calculators.ServiceFeeCalculators;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.OutstandingLoanCalculators
{
    internal abstract class OutstandingLoanCalculatorTemplate
    {
        private DataContext _db;
        private Loan _loan;
        private FineComputationRate _fineComputationRate;

        #region Routine Helpers

        protected Loan Loan
        {
            get { return _loan; }
        }

        protected decimal GetLoanAmount()
        {
            return _loan.LoanAmount;
        }

        protected decimal GetPayedAmount()
        {
            return _loan.LoanReceipts.Sum(lr => lr.Amount);
        }

        protected decimal GetPaymentAmount()
        {
            //var unpaidScheduleCount = 1;
            //var delayedPaymentFine = GetDelayedPaymentFine();
            //if (delayedPaymentFine != null)
            //    unpaidScheduleCount = (delayedPaymentFine.Days / _loan.PaymentMode.Days);

            //return _loan.Amortization * unpaidScheduleCount;

            //return (_loan.Amortization * 
            //    ((((DateTime.Now < _loan.DueDate ? DateTime.Now : _loan.DueDate) - _loan.LoanDate).Days / _loan.PaymentMode.Days) + 1)) -
            //    _loan.LoanReceipts.Sum(r => r.Amount);

            var amortization = _loan.Amortization;
            var loanDate = _loan.LoanDate;
            var dueDate = DateTime.Now < _loan.DueDate ? DateTime.Now : _loan.DueDate;
            var paymentModeDays = _loan.PaymentMode.Days;
            var consumedPeriod = ((dueDate - loanDate).Days / paymentModeDays) + 1;
            var supposedPayedAmount = consumedPeriod * amortization;
            var totalPayedAmount = GetPayedAmount();

            return supposedPayedAmount - totalPayedAmount;

        }

        protected ServiceFees GetServiceFees()
        {
            return new ServiceFees()
            {
                ServiceFee = _loan.ServiceFee,
                CollectionFee = _loan.CollectionFee,
                CapitalBuildup = _loan.CapitalBuildup,
                LoanGuaranteeFund = _loan.LoanGuaranteeFund,
                Interest = _loan.Interest
            };
        }

        protected FineDetails GetDelayedPaymentFine(decimal outstandingBalance)
        {
            return new DelayedPaymentFineCalculator(GetFineComputationRate()).ComputeFine(_loan, outstandingBalance);
        }

        protected FineDetails GetDelinquentFine(decimal outstandingBalance)
        {
            return new DelinquentFineCalculator(GetFineComputationRate()).ComputeFine(_loan, outstandingBalance);
        }

        protected FineComputationRate GetFineComputationRate()
        {
            if (_fineComputationRate == null)
                _fineComputationRate = _db.GetTable<FineComputationRate>().FirstOrDefault();
            return _fineComputationRate;
        }

        #endregion

        public abstract OutstandingLoan CalculateOutstandingLoan();

        public OutstandingLoanCalculatorTemplate(DataContext db, Loan loan)
        {
            _db = db;
            _loan = loan;
        }
    }
}
