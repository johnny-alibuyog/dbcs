using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Plans.PensionPlan
{
    public interface IPensionPlanSettingsView
    {
        int Id { get; set; }
        int Terms { get; set; }
        int AgingPeriod { get; set; }
        decimal PaymentCompletionAmount { get; set; }
        decimal AmortizationDaily { get; set; }
        decimal AmortizationWeekly { get; set; }
        decimal AmortizationSemiMonthly { get; set; }
        decimal AmortizationMonthly { get; set; }
        decimal AmortizationYearly { get; set; }
    }
}
