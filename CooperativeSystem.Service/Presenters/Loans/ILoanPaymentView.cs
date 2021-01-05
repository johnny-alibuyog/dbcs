using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Loans
{
    public interface ILoanPaymentView
    {
        event EventHandler ReceiptAdd;
        bool HasLoan { get; set; }

        long MemberID { get; set; }
        long LoanID { get; set; }
        string LoanServiceID { get; set; }
        
        // payment
        bool FullyPayOutstandingBalance { get; }
        bool FullyPayPayableAmount { get; }
        string PaymentMode { get; set; }
        Nullable<DateTime> PaymentDueDate { get; set; }
        decimal LoanAmount { get; set; }
        decimal OutstandingBalance { get; set; }
        decimal Amortization { get; set; }
        decimal PayableAmount { get; set; }
        decimal PaymentAmount { get; set; }

        // late payment charge
        bool HasLatePaymentCharge { get; set; }
        bool CondoneLatePaymentCharge { get; set; }
        bool FullyPayLatePaymentCharge { get; }
        Nullable<DateTime> LatePaymentDueDate { get; set; }
        int LatePaymentDaysDelayed { get; set; }
        decimal PreviousUnpaidLatePaymentCharge { get; set; }
        decimal ComputedLatePaymentCharge { get; set; }
        decimal LatePaymentCharge { get; set; }

        // delinquent charge
        bool HasDelinquentCharge { get; set; }
        bool CondoneDelinquentCharge { get; set; }
        bool FullyPayDelinquentCharge { get; }
        Nullable<DateTime> DelinquentDueDate { get; set; }
        int DelinquentDaysDelinquent { get; set; }
        decimal PreviousUnpaidDelinquentCharge { get; set; }
        decimal ComputedDelinquentCharge { get; set; }
        decimal DelinquentCharge { get; set; }

        // 
        decimal TotalPaymentAmount { get; set; }

        void Initialize();
    }
}
