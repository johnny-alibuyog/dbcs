using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.MemberPeriodicalBalanceSummaries.YearlyBalances
{
    public interface IYearlyBalanceReportView
    {
        int Year { get; set; }
        void PopulateReports(IList<PeriodicalBalance> balances);
    }
}
