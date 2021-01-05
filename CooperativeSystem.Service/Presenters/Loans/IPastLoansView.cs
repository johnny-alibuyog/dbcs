using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.Loans
{
    public interface IPastLoansView
    {
        long MemberID { get; set; }
        string LoanServiceID { get; set; }

        Nullable<long> SelectedLoanID { get; }

        Nullable<DateTime> LoanDate { set; }
        Nullable<DateTime> SettlementDate { set; }
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
        Nullable<decimal> Amortization { set; }

        IList<TransactionModel> Transactions { set; }
        Nullable<decimal> TotalTransaction { set; }

        IList<ReceiptModel> Fines { set; }
        Nullable<decimal> TotalFine { set; }

        IList<ReceiptModel> Charges { set; }
        Nullable<decimal> TotalCharge { set; }

        bool IsPopulatingPulldown { get; set; }

        void PopulateLoanPulldown(IList<LoanLookupModel> loansLookup);
    }
}
