using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.Loans
{
    public interface IInterestRebateView
    {
        string UserID { get; }
        DateTime AdjustmentDate { get; }
        string VoucherNumber { get; set; }
        string Sequence { get; }

        long MemberID { get; }
        Nullable<long> SelectedLoanID { get; }

        Nullable<DateTime> LoanDate { set; }
        Nullable<DateTime> SettlementDate { set; }
        Nullable<DateTime> DueDate { set; }
        string PaymentMode { set; }
        Nullable<int> Terms { set; }
        Nullable<decimal> LoanAmount { set; }
        Nullable<decimal> InterestRate { set; }
        Nullable<decimal> Interest { set; }
        Nullable<int> MonthsRebatable { set; }
        Nullable<decimal> InterestRebate { get; set; }

        bool IsPopulatingPulldown { get; set; }
        bool HasRebatableLoan { get; set; }

        void PopulateLoanPulldown(IList<LoanLookupModel> loansLookup);
    }
}
