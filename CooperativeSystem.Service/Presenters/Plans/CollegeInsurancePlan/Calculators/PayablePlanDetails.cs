using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Presenters.Lookups.PaymentModes;

namespace CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan.Calculators
{
    [Serializable]
    public class PayablePlanDetails
    {
        public virtual long CollegeInsurancePlanID { get; internal set; }
        public virtual string UserName { get; internal set; }
        public virtual string PaymentMode { get; internal set; }
        public virtual decimal UnpaidAmortization { get; internal set; }
        public virtual decimal Amortization { get; internal set; }
        public virtual decimal PaymentAmount { get; set; }

        //public PayablePlanDetails(Models.CollegeInsurancePlan plan, Models.CollegeInsurancePlanSetting settings)
        //{
        //    //_plan = plan;

        //    CollegeInsurancePlanID = plan.CollegeInsurancePlanID;
        //    UserName = plan.UserLastName + ", " + plan.UserFirstName + " " + plan.UserMiddleName;
        //    PaymentMode = plan.PaymentMode.PaymentModeName;
        //    Amortization = plan.Amortization;
        //    UnpaidAmortization =
        //        ((plan.Amortization * (((DateTime.Today - plan.ApplicationDate).Days / plan.PaymentMode.Days) + 1)) < plan.PaymentCompletionAmount
        //            ? (plan.Amortization * (((DateTime.Today - plan.ApplicationDate).Days / plan.PaymentMode.Days) + 1))
        //            : plan.PaymentCompletionAmount)
        //        - plan.CollegeInsurancePlanReceipts.Sum(r => r.Amount);
        //}
    }
}
