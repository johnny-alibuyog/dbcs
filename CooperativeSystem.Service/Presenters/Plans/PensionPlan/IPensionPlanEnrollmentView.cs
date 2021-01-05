using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Plans.PensionPlan
{
    public interface IPensionPlanEnrollmentView
    {
        event EventHandler Enrolled;

        long MemberID { get; set; }
        DateTime ApplicationDate { get; set; }
        PaymentMode PaymentMode { get; set; }
        int Terms { get; set; }
        int AgingPeriod { get; set; }
        decimal Amortization { get; set; }
        decimal PaymentCompletionAmount { get; set; }

        void PopulatePaymentMode(IList<PaymentMode> paymentModes);
    }
}
