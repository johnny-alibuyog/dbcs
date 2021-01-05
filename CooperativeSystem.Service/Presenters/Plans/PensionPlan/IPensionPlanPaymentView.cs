using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Plans.PensionPlan
{
    public interface IPensionPlanPaymentView
    {
        event EventHandler ReceiptAdd;
        bool HasPlan { get; set; }
        long MemberID { get; set; }
        string PaymentMode { set; }
        decimal Amortization { set; }
        decimal UnpaidAmortization { set; }
        decimal PaymentAmount { get; set; }
    }
}
