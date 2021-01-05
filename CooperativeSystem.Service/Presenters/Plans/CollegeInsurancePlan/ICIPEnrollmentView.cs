using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan
{
    public interface ICIPEnrollmentView
    {
        event EventHandler Enroll;
        event EventHandler Modify;

        long CollegeInsurancePlanID { get; set; }
        long MemberID { get; set; }
        string UserLastName { get; set; }
        string UserFirstName { get; set; }
        string UserMiddleName { get; set; }
        DateTime? DateOfBirth { get; set; }
        Relation Relation { get; set; }
        string Address { get; set; }

        DateTime ApplicationDate { get; set; }
        PaymentMode PaymentMode { get; set; }
        int Terms { get; set; }
        int AgingPeriod { get; set; }
        decimal Amortization { get; set; }
        decimal PaymentCompletionAmount { get; set; }
        decimal AwardAmount { get; set; }

        void PopulateRelationPulldown(IList<Relation> relations);
        void PopulatePaymentModePulldown(IList<PaymentMode> paymentModes);
    }
}
