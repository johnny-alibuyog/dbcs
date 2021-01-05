using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan
{
    public interface ICIPSummaryView : ISummaryView
    {
        long MemberID { get; set; }

        IList<CIPModel> CollegeInsurancePlans { get; set; }
        IList<TransactionModel> Receipts { get; set; }

        Nullable<decimal> TotalBalance { set; }

        string UserName { set; }
        Nullable<DateTime> DateOfBirth { set; }
        string Relation { set; }
        string Address { set; }

        Nullable<DateTime> ApplicationDate { set; }
        Nullable<DateTime> PaymentCompletionDate { set; }
        Nullable<DateTime> MaturityDate { set; }
        string PaymentMode { set; }
        Nullable<int> Terms { set; }
        Nullable<int> AgingPeriod { set; }
        Nullable<decimal> Amortization { set; }
        Nullable<decimal> PaymentCompletionAmount { set; }
        Nullable<decimal> AwardAmount { set; }
    }
}
