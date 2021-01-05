using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.SpecialFunds.TulunganFund
{
    public interface ITulunganFundWithdrawalAssessmentView
    {
        event EventHandler AssessmentAdd;
        bool IsAssessed { get; set; }

        long MemberID { get; set; }
        decimal Amount { get; set; }
    }
}
