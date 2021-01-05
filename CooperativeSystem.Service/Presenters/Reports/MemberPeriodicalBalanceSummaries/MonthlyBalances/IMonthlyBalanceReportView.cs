using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.MemberPeriodicalBalanceSummaries.MonthlyBalances
{
    public interface IMonthlyBalanceReportView
    {
        DateTime Date { get; set; }
        void PopulateReports(IList<PeriodicalBalance> balances);

    }
}
