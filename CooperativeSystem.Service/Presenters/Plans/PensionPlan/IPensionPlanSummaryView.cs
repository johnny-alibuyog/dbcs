using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.Plans.PensionPlan
{
    public interface IPensionPlanSummaryView : ISummaryView
    {
        Nullable<bool> HasEnrolled { get; set; }

        IList<TransactionDetail> TransactionDetails { set; }
        Nullable<decimal> TotalBalance { set; }

        Nullable<DateTime> ApplicationDate { set; }
        Nullable<DateTime> PaymentCompletionDate { set; }
        Nullable<DateTime> MaturityDate { set; }
        string PaymentMode { set; }
        Nullable<int> Terms { set; }
        Nullable<decimal> Amortization { set; }
        Nullable<decimal> PaymentCompletionAmount { set; }

        string AvailOption { set; }
        Nullable<int> AgingPeriod { set; }
        Nullable<decimal> AwardAmount { set; }
        Nullable<decimal> MonthlyPension { set; }
        string OptionDescription { set; }
    }
}
