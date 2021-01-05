using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare
{
    public interface ICapitalShareWithdrawalAssessmentView
    {
        event EventHandler AssessmentAdd;
        bool IsAssessed { get; set; }

        long MemberID { get; set; }
        decimal CurrentBalance { get; set; }
        decimal WithdrawAmount { get; set; }
    }
}
