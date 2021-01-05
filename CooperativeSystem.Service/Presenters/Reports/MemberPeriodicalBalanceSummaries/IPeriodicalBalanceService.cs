using System;
using System.Collections.Generic;

namespace CooperativeSystem.Service.Presenters.Reports.MemberPeriodicalBalanceSummaries
{
    interface IPeriodicalBalanceService
    {
        IList<PeriodicalBalance> GenerateBalancesFor(DateTime cutOffDate);
    }
}
