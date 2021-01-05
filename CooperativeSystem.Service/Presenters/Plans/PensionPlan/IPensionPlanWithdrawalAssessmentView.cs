using System;

namespace CooperativeSystem.Service.Presenters.Plans.PensionPlan
{
    public interface IPensionPlanWithdrawalAssessmentView
    {
        event EventHandler AssessmentAdd;
        bool IsAssessed { get; set; }

        //long MemberID { get; set; }
        //DateTime MaturityDate { get; set; }
        //decimal MaturityAmount { get; set; }
        //decimal AwardAmount { get; set; }
        //decimal TotalContributionAmount { get; set; }
        //decimal AvailedAmount { get; set; }
        //decimal WithdrawAmount { get; set; }
        //something is should be done here man! you should revice pension withdrawal assessment

        long MemberID { get; set; }
        string AvailOption { set; }
        Nullable<DateTime> ApplicationDate { set; }
        Nullable<DateTime> PaymentCompeletionDate { set; }
        Nullable<DateTime> MaturityDate { get; set; }
        decimal PaymentCompletionAmount { get; set; }
        decimal AwardAmount { set; }
        decimal PayedAmount { get; set; }
        decimal Interests { set; }
        decimal DisbursedAmount { set; }
        decimal MaximumWithdrawableAmount { get; set; }
        decimal WithdrawAmount { get; set; }
    }
}
