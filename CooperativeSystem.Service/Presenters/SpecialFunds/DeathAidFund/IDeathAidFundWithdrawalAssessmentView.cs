using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.SpecialFunds.DeathAidFund
{
    public interface IDeathAidFundWithdrawalAssessmentView
    {
        event EventHandler AssessmentAdd;
        bool IsAssessed { get; set; }

        long MemberID { get; set; }
        char DeathAidFundTypeId { get; set; }
        decimal WithdrawAmount { get; set; }

        void PopulateDeathAidFundTypes(IList<DeathAidFundType> deathAidFundTypes);
    }
}
