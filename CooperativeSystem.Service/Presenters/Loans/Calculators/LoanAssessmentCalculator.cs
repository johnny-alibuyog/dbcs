using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Presenters.Loans.Calculators.AmortizationCalculators;
using CooperativeSystem.Service.Presenters.Loans.Calculators.MaxLoanAmountCalculators;
using CooperativeSystem.Service.Presenters.Loans.Calculators.NetAmountDueCalculators;
using CooperativeSystem.Service.Presenters.Loans.Calculators.ServiceFeeCalculators;
using CooperativeSystem.Service.Presenters.Lookups.PaymentModes;
using CooperativeSystem.Service.Utilities.ConfigurationUtilities;
using CooperativeSystem.Service.Presenters.Lookups.Services;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators
{
    internal class LoanAssessmentCalculator
    {
        #region Fields

        private Member _member;
        private DataContext _db;
        private string _loanServiceID;
        private FineComputationRate _fineComputationRate;
        private DateTime _loanDate;
        private LoanSetting _loanSetting;
        
        private Loan _outstandingLoan;
		
	    #endregion        
        
        #region Field Accessors

        private decimal OutstandingBalance
        {
            get {  return _outstandingLoan != null ? _outstandingLoan.GetOutstandingBalance() : 0M; }
        }

        #endregion

        #region Routine Helpers

        private bool ValidateLoanApplication(out string remarks)
        {
            remarks = string.Empty;

            //if (_outstandingLoan == null)
            //    return true;

            var unsettledLoans = _member.Loans
                .Where(x => !x.Settled)
                .ToList();

            // check if member is delinquent
            var delinquentLoans = unsettledLoans
                .Where(x => x.IsDelinquent())
                .ToList();

            if (delinquentLoans != null && delinquentLoans.Count > 0)
            {
                remarks = string.Format("Delinquent account. Please settle your {0}.",
                    delinquentLoans.First().Service.ServiceName);
                return false;
            }

            // advised by ate Lissa to not apply this rule
            //// check if member has current loan with delayed payment
            //var delayedLoans = unsettledLoans
            //    .Where(l => l.IsDelayed)
            //    .ToList();

            //if (delayedLoans != null && delayedLoans.Count > 0)
            //{
            //    remarks = string.Format("You have late payment. Please settle your {0}.",
            //        delayedLoans.First().Service.ServiceName);
            //    return false;
            //}

            // check the percentage paid. if less than 75 percent, do not allow to renew loan
            if (_outstandingLoan != null && _outstandingLoan.GetPercentagePaid() < _loanSetting.RenewablePaidPercentage)
            {
                var paidPercentage = _loanSetting.RenewablePaidPercentage;
                var outstandingPrecentage = 100 - paidPercentage;
                remarks = string.Format(
                    "Your outstanding balance is over {0}%." + Environment.NewLine +
                    "You have to have paid at least {1}% of your current loan.",
                    outstandingPrecentage,
                    paidPercentage);
                return false;
            }

            return true;
        }

        private DateTime ComputeDueDate(int terms)
        {
            return _loanDate.AddMonths(terms);
        }

        private DateTime ComputePaymentStartDate(int paymentIntervalsInDays)
        {
            return _loanDate.AddDays(paymentIntervalsInDays);
        }

        #endregion

        public LoanAssessmentCalculator(DataContext db, long memberID, string loanServiceID, DateTime loanDate)
        {
            _db = db;
            _member = _db.GetTable<Member>().Single(m => m.MemberID == memberID);
            _fineComputationRate = _db.GetTable<FineComputationRate>().Single();
            _loanSetting = db.GetTable<LoanSetting>().Single();

            _loanServiceID = loanServiceID;
            _loanDate = loanDate;

            // get outstanding loan if there is any
            _outstandingLoan = _member.Loans
                .Where(l => !l.Settled && l.LoanServiceID == _loanServiceID)
                .FirstOrDefault();

            //if (_outstandingLoan != null)
            //    _outstandingLoan.FineComputationRate = _fineComputationRate;
        }

        public LoanAssessmentModel AssessLoan(string paymentModeID, string loanDeductionTypeID, 
            int terms, decimal interestRate, decimal loanAmount, out string remarks)
        {
            remarks = string.Empty;

            if (ConfigurationHelper.ApplyBusinessRules)
            {
                if (!ValidateLoanApplication(out remarks))
                    return null;
            }

            var paymentMode = _db.GetTable<PaymentMode>()
                .FirstOrDefault(pm => pm.PaymentModeID == paymentModeID);

            /*
             * create calculators
             */
            var serviceFeeCalculator = new ServiceFeeCalculatorFactory()
                .CreateServiceFeeCalculator(_loanServiceID, _db, _member);

            var maxLoanAmountCalculator = new MaxLoanAmountCalculatorFactory()
                .CreateMaxLoanAmountCalculator(_loanServiceID, _db, _member);

            var netAmountDueCalculator = new NetAmountDueCalculatorFactory()
                .CreateNetAmountDueCalculator(loanDeductionTypeID);

            var amortizationCalculator = new AmortizationCalculatorFactory()
                .CreateAmortizationCalculator(loanDeductionTypeID);

            // compute for the maximum loanable amount
            var maxLoanAmount = maxLoanAmountCalculator.ComputeMaxLoanAmount(out remarks);
            if (maxLoanAmount == 0)
                return null;

            // assign values to loan amount if not assigned
            if (_loanServiceID == ServiceCodes.EmergencyLoan)
            {
                if (loanAmount == 0M)
                    loanAmount = maxLoanAmount;
            }
            else
            {
                if (loanAmount > maxLoanAmount || loanAmount == 0M)
                    loanAmount = maxLoanAmount;
            }

            // compute for the service fees
            var fees = serviceFeeCalculator
                .ComputeServiceFees(paymentModeID, loanDeductionTypeID, loanAmount, terms, ref interestRate);

            // compute for due date
            var dueDate = ComputeDueDate(terms);

            // compute for net amount due
            var netAmountDue = netAmountDueCalculator
                .CalculateNetAmountDue(loanAmount, fees, OutstandingBalance);

            // get payment intervals in days
            var paymentIntervalInDays = paymentMode.Days;

            // compute for payment start date
            var paymentStartDate = ComputePaymentStartDate(paymentIntervalInDays);

            // compute for amortization
            var amortization = amortizationCalculator.CalculateAmortization(loanAmount, fees, paymentMode, terms);

            var assessment = new LoanAssessmentModel()
            {
                Terms = terms,
                MaximumLoanAmount = maxLoanAmount,
                LoanAmount = loanAmount,
                DueDate = dueDate,
                PaymentStartDate = paymentStartDate,
                OutstandingBalance = OutstandingBalance,
                OutstandngLoanId = _outstandingLoan != null 
                    ? new Nullable<long>(_outstandingLoan.LoanID) : null,
                ServiceFee = fees.ServiceFee,
                CollectionFee = fees.CollectionFee,
                CapitalBuildup = fees.CapitalBuildup,
                LoanGuaranteeFund = fees.LoanGuaranteeFund,
                InterestRate = interestRate,
                Interest = fees.Interest,
                Amortization = amortization,
                NetAmountDue = netAmountDue
            };

            return assessment;
        }
    }
}
