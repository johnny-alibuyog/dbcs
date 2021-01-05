using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.DeductionTypes;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.OutstandingLoanCalculators
{
    internal class OutstandingLoanCalculatorFactory
    {
        public OutstandingLoanCalculatorTemplate CreateOutstandingLoanCalculator(DataContext db, Member member, string loanServiceID)
        {
            OutstandingLoanCalculatorTemplate calculator = null;

            var loan = GetCurrentLoan(member, loanServiceID);
            var loanDeductionTypeID = loan != null ? loan.LoanDeductionTypeID : string.Empty;
            switch (loanDeductionTypeID)
            {
                case LoanDeductionTypeCodes.AddOn:
                    calculator = new AddOnCalculator(db, loan);
                    break;
                case LoanDeductionTypeCodes.Deducted:
                    calculator = new DeductedCalculator(db, loan);
                    break;
            }
            return calculator;
        }

        private Loan GetCurrentLoan(Member member, string loanServiceID)
        {
            return member.Loans
                .Where(l =>
                    l.LoanServiceID == loanServiceID &&
                    l.Settled == false)
                .FirstOrDefault();
        }
    }
}
