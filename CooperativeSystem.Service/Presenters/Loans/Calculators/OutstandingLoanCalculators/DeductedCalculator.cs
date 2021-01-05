using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.OutstandingLoanCalculators
{
    internal class DeductedCalculator : OutstandingLoanCalculatorTemplate
    {
        public DeductedCalculator(DataContext db, Loan loan)
            : base(db, loan) { }

        public override OutstandingLoan CalculateOutstandingLoan()
        {
            var ol = new OutstandingLoan();
            ol.Loan = Loan;
            ol.TotalLoanAmount = GetLoanAmount() - GetServiceFees().Total;
            ol.TotalPayedAmount = GetPayedAmount();
            ol.OutstandingBalance = ol.TotalLoanAmount - ol.TotalPayedAmount;
            ol.PaymentAmount = GetPaymentAmount();
            ol.DelayedPaymentFine = GetDelayedPaymentFine(ol.OutstandingBalance);
            ol.DelinquentFine = GetDelinquentFine(ol.OutstandingBalance);
            return ol;
        }
    }
}
