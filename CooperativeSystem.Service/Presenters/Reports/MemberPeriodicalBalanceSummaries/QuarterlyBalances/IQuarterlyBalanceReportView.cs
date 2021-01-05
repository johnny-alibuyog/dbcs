using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Reports.MemberPeriodicalBalanceSummaries.QuarterlyBalances
{
    public interface IQuarterlyBalanceReportView
    {
        int Year { get; set; }
        Quarter Quarter { get; set; }

        void PopulateReports(IList<PeriodicalBalance> balances);
    }
}
