using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Loans
{
    public class LoanAssessmentReportModel
    {
        public virtual string Member { get; set; }
        public virtual string LoanService { get; set; }
        public virtual string PaymentMode { get; set; }
        public virtual string LoanDeductionType { get; set; }
        public virtual DateTime LoanDate { get; set; }
        public virtual int Terms { get; set; }
        public virtual decimal InterestRate { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual DateTime PaymentStartDate { get; set; }
        public virtual decimal LoanAmount { get; set; }
        public virtual decimal MaximumLoanAmount { get; set; }
        public virtual decimal OutstandingBalance { get; set; }
        public virtual decimal ServiceFee { get; set; }
        public virtual decimal CollectionFee { get; set; }
        public virtual decimal CapitalBuildup { get; set; }
        public virtual decimal LoanGuaranteeFund { get; set; }
        public virtual decimal Interest { get; set; }
        public virtual decimal Amortization { get; set; }
        public virtual decimal NetAmountDue { get; set; }
    }
}
