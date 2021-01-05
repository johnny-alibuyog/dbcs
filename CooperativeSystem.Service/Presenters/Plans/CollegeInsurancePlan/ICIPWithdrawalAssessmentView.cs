using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan
{
    public interface ICIPWithdrawalAssessmentView
    {
        event EventHandler ReceiptAdd;
        bool IsAssessed { get; set; }

        long MemberID { get; set; }
        IList<CIPWithdrawalAssessmentModel> CIPAssessments { get; set; }
        IList<CIPWithdrawalAssessmentModel> CIPAssessmentsToWithdraw { get; set; }
        decimal TotalWithdrawAmount { get; }
    }
}
