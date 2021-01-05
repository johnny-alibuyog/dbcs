using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Presenters.Loans.Calculators;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.Loans
{
    public interface ILoanSummaryView : ISummaryView
    {
        string LoanServiceID { get; }

        string CashDisbursementVoucher { get; set; }

        IList<TransactionModel> Transactions { set; }
        Nullable<decimal> TotalTransaction { set; }

        IList<ReceiptModel> Fines { set; }
        Nullable<decimal> TotalFine { set; }

        IList<ReceiptModel> Charges { set; }
        Nullable<decimal> TotalCharge { set; }

        Nullable<DateTime> LoanDate { set; }
        Nullable<DateTime> NextPaymentDue { set; }
        Nullable<DateTime> DueDate { set; }
        Nullable<int> Terms { set; }
        string PaymentMode { set; }
        string DeductionType { set; }

        Nullable<decimal> ServiceFee { set; }
        Nullable<decimal> CollectionFee { set; }
        Nullable<decimal> CapitalBuildup { set; }
        Nullable<decimal> LoanGuranteeFund { set; }
        Nullable<decimal> Interest { set; }
        Nullable<decimal> LoanAmount { set; }

        Nullable<decimal> TotalPayableAmount { set; }
        Nullable<decimal> OutstandingBalance { set; }
        Nullable<decimal> Amortization { set; }

        // delayed payment account details
        Nullable<DateTime> DelayedPaymentDueDate { set; }
        Nullable<int> DelayedPaymentDaysDelayed { set; }
        Nullable<decimal> DelayedPaymentFine { set; }
        string DelayedPaymentRemarks { set; }

        // delinquent account details
        Nullable<DateTime> DelinquentDueDate { set; }
        Nullable<int> DelinquentDaysDelinquent { set; }
        Nullable<decimal> DelinquentCharge { set; }
        string DelinquentRemarks { set; }

        //FineDetails DelayedPaymentFine { set; }
        //FineDetails DelinquentFine { set; }
    }
}
