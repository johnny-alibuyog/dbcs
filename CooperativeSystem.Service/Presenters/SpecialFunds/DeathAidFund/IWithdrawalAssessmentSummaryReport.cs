using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.SpecialFunds.DeathAidFund
{
    public interface IWithdrawalAssessmentSummaryReport
    {
        void PopulateReports(IList<DeathAidFundWithdrawalAssessmentItem> items);
    }
}
