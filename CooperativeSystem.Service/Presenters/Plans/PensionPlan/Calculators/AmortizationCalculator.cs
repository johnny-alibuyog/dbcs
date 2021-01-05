using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Presenters.Lookups.PaymentModes;

namespace CooperativeSystem.Service.Presenters.Plans.PensionPlan.Calculators
{
    internal class AmortizationCalculator
    {
        private Models.PensionPlanSetting _settings;

        public AmortizationCalculator(Models.PensionPlanSetting settings)
        {
            _settings = settings;
        }

        public decimal CalculateAmortization(string paymentModeID)
        {
            switch (paymentModeID)
            {
                case PaymentModeCodes.Daily:
                    return _settings.AmortizationDaily;
                case PaymentModeCodes.Weekly:
                    return _settings.AmortizationWeekly;
                case PaymentModeCodes.SemiMonthly:
                    return _settings.AmortizationSemiMonthly;
                case PaymentModeCodes.Monthly:
                    return _settings.AmortizationMonthly;
                case PaymentModeCodes.Yearly:
                    return _settings.AmortizationYearly;
                default:
                    return 0M;
            }
        }
    }
}
