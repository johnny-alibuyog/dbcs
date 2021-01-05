using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan.Calculators
{
    internal class PayablePlanCalculator
    {
        private IList<Models.CollegeInsurancePlan> _plans;
        private Models.CollegeInsurancePlanSetting _settings;

        public PayablePlanCalculator(IList<Models.CollegeInsurancePlan> plans, Models.CollegeInsurancePlanSetting settings)
        {
            _plans = plans;
            _settings = settings;
        }

        public IList<PayablePlanDetails> GetPayablePlans(out string remarks)
        {
            remarks = string.Empty;
            if (_plans == null || _plans.Count == 0)
            {
                remarks = "You do not have College Insurance Plan.";
                return null;
            }

            var payablePlanQuery = _plans
                .Where(x =>
                    x.Consumed == false &&
                    x.IsPaymentCompleted() == false
                )
                .Select(x => new PayablePlanDetails()
                {
                    CollegeInsurancePlanID = x.CollegeInsurancePlanID,
                    UserName = x.UserLastName + ", " + x.UserFirstName + " " + x.UserMiddleName,
                    PaymentMode = x.PaymentMode.PaymentModeName,
                    Amortization = x.Amortization,
                    UnpaidAmortization = x.GetCurrentPayableAmount()
                });

            if (!payablePlanQuery.Any())
            {
                remarks = "You do not have payable College Insurance Plan.";
                return null;
            }

            return payablePlanQuery.ToList();
        }
    }
}
