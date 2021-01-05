using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Reports.MemberPeriodicalBalanceSummaries
{
    public interface IPeriodicalBalancesView
    {
        // monthly balance
        DateTime MonthlyBalanceDate { get; set; }

        // quarterly balance
        int QuarterlyBalanceYear { get; set; }
        Quarter QuarterlyBalanceQuarter { get; set; }

        // yearly balance
        int YearlyBalanceYear { get; set; }

        void PopulateQuarters(IList<Quarter> quarters);
    }
}
