using System;

namespace CooperativeSystem.Service.Models.Projections
{
    [Serializable]
    public class LoanAssessmentModel
    {
        //public string AccountNumber { get; set; }
        //public string LoanServiceID { get; set; }
        //public string PaymentModeID { get; set; }
        //public int Terms { get; set; }

        public virtual int Terms { get; set; }
        public virtual decimal MaximumLoanAmount { get; set; }
        public virtual decimal LoanAmount { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual DateTime PaymentStartDate { get; set; }
        public virtual decimal OutstandingBalance { get; set; }
        public virtual long? OutstandngLoanId { get; set; }
        public virtual decimal ServiceFee { get; set; }
        public virtual decimal CollectionFee { get; set; }
        public virtual decimal CapitalBuildup { get; set; }
        public virtual decimal LoanGuaranteeFund { get; set; }
        public virtual decimal InterestRate { get; set; }
        public virtual decimal Interest { get; set; }
        public virtual decimal Amortization { get; set; }
        public virtual decimal NetAmountDue { get; set; }
    }
}
