using System;

namespace CooperativeSystem.UI.Views.Plans.Factories
{
    public class PaymentFormFactory : IPaymentFormFactory
    {
        #region IPaymentFormFactory Members

        public PaymentFormTemplate CreateForm(PlanType planType)
        {
            switch (planType)
            {
                case PlanType.CollegeInsurancePlan:
                    return new CollegeInsurancePlan.CIPPaymentView();
                case PlanType.PensionPlan:
                    return new PensionPlan.PaymentView();
                default:
                    throw new ArgumentException();
            }
        }

        #endregion
    }
}
