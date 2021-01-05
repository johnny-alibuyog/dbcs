using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.OutstandingLoanCalculators
{
    [Serializable]
    internal class OutstandingLoan
    {
        public virtual Loan Loan { get; set; }
        public virtual decimal TotalLoanAmount { get; set; }
        public virtual decimal TotalPayedAmount { get; set; }
        public virtual decimal OutstandingBalance { get; set; }
        public virtual FineDetails DelayedPaymentFine { get; set; }
        public virtual FineDetails DelinquentFine { get; set; }
        public virtual decimal PaymentAmount { get; set; }
        public virtual decimal PercentagePaid { get { return (TotalPayedAmount / TotalLoanAmount) * 100; } }
    }
}
