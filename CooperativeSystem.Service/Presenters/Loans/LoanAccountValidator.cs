using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Loans.Calculators;
using CooperativeSystem.Service.Presenters.Loans.Calculators.FineCalculators;

namespace CooperativeSystem.Service.Presenters.Loans
{
    internal class LoanAccountValidator
    {
        private Member _member;
        private string _loanServiceID;

        public LoanAccountValidator(Member member, string loanServiceID)
        {
            _member = member;
            _loanServiceID = loanServiceID;
        }

        public bool IsGoodPayor(out string remarks)
        {
            remarks = string.Empty;

            var delinquentFine = new DelinquentFineCalculator().ComputeFine(_member.Loans);
            if (delinquentFine != null)
            {
                remarks = string.Format("Delinquent account. Please settle your {0}.",
                    delinquentFine.Loan.Service.ServiceName);
                return false;
            }

            var delayedPaymentFine = new DelayedPaymentFineCalculator().ComputeFine(_member.Loans);
            if (delayedPaymentFine != null)
            {
                remarks = string.Format("You have late payment. Please settle your {0}.",
                    delayedPaymentFine.Loan.Service.ServiceName);
                return false;
            }

            return true;
        }

        internal bool IsQualifiedForNewLoan(out decimal outstandingBalance, out string remarks)
        {
            var result = true;

            outstandingBalance = 0M;
            remarks = string.Empty;

            // get current loan details
            var query = (from loan in _member.Loans
                         where loan.LoanServiceID == _loanServiceID
                         select new
                         {
                             LoanAmount = loan.LoanAmount,
                             PayedAmount = loan.LoanReceipts.Sum(lr => lr.Amount),
                             Deductions = loan.ServiceFee + loan.CollectionFee + loan.CapitalBuildup 
                                + loan.LoanGuaranteeFund + loan.Interest
                         });

            // there are no current loan, qualified to apply for new loan
            if (query.Any())
            {
                var currentLoan = query.First();
                outstandingBalance = currentLoan.LoanAmount - currentLoan.PayedAmount - currentLoan.Deductions;

                if ((outstandingBalance / currentLoan.LoanAmount) * 100 > 25)
                {
                    remarks = "Your outstanding balance is over 25%. You have to have payed at least 75 percent of your current loan.";
                    result = false;
                }
            }

            return result;
        }
    }
}
