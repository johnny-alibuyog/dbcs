using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan.Calculators;

namespace CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan
{
    public interface ICIPPaymentView
    {
        event EventHandler ReceiptAdd;
        bool HasPlan { get; set; }

        long MemberID { get; set; }
        IList<PayablePlanDetails> PayablePlans { get; set; }
        IList<PayablePlanDetails> PayablePlansToPay { get; set; }
        decimal TotalPaymentAmount { get; }
    }
}
