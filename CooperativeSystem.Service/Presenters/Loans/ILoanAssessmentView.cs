using System;
using System.Collections.Generic;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.Loans
{
    public interface ILoanAssessmentView
    {
        event EventHandler AssessmentAdd;
        bool IsAssessed { get; set; }

        long MemberID { get; set; }
        string LoanServiceID { get; set; }
        string PaymentModeID { get; }
        string LoanDeductionTypeID { get; }
        DateTime LoanDate { get; set; }
        int Terms { get; set; }
        decimal InterestRate { get; set; }

        DateTime DueDate { get; set; }
        DateTime PaymentStartDate { get; set; }
        decimal LoanAmount { get; set; }
        decimal MaximumLoanAmount { get; set; }
        decimal OutstandingBalance { get; set; }
        long? OutstandingLoanId { get; set; }
        decimal ServiceFee { get; set; }
        decimal CollectionFee { get; set; }
        decimal CapitalBuildup { get; set; }
        decimal LoanGuaranteeFund { get; set; }
        decimal Interest { get; set; }
        decimal Amortization { get; set; }
        decimal NetAmountDue { get; set; }

        // pulldown menu methods
        void Initialize();
        void ViewReport(LoanAssessmentReportModel model);
        void PopulatePaymentMode(IList<PaymentMode> paymentModes);
        void PopulateLoanDeductionType(IList<LoanDeductionType> loanDeductionTypes);
    }
}
