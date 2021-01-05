using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.SavingsDeposit
{
    public interface ISavingsDepositWithdrawalAssessmentView
    {
        event EventHandler AssessmentAdd;
        bool IsAssessed { get; set; }

        long MemberID { get; set; }
        //decimal ReceivedAmount { get; set; }
        //decimal DividendAmount { get; set; }
        //decimal DisbursedAmount { get; set; }
        decimal CurrentBalance { get; set; }
        decimal WithdrawAmount { get; set; }
    }
}
