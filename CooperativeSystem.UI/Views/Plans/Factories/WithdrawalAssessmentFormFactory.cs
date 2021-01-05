using System;

namespace CooperativeSystem.UI.Views.Plans.Factories
{
    public class WithdrawalAssessmentFormFactory : IWithdrawalAssessmentFormFactory
    {
        public WithdrawalAssessmentFormTemplate CreateForm(PlanType planType)
        {
            switch (planType)
            {
                case PlanType.CollegeInsurancePlan:
                    return new CollegeInsurancePlan.CIPWithdrawalAssessmentView();
                case PlanType.PensionPlan:
                    return new PensionPlan.PensionPlanWithdrawalAssessmentView();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
