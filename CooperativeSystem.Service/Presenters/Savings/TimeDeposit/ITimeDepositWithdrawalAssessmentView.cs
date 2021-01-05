using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Presenters.Savings.TimeDeposit.Calculators;

namespace CooperativeSystem.Service.Presenters.Savings.TimeDeposit
{
    public interface ITimeDepositWithdrawalAssessmentView
    {
        event EventHandler AssessmentAdd;
        bool IsAssessed { get; set; }

        long MemberID { get; set; }
        IList<TimeDepositWithdrawalAssessmentModel> TimeDeposits { get; set; }
        IList<TimeDepositWithdrawalAssessmentModel> TimeDepositsToWithdraw { get; set; }
        decimal TotalWithdrawAmount { get; }
    }
}
