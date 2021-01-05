using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.SpecialFunds.TulunganFund
{
    public interface ITulunganFundSettingsView
    {
        decimal PerMemberYearlyContribution { get; set; }
        decimal RequiredMinimumShare { get; set; }
        decimal AwardForShareBelowFifteenThousand { get; set; }
        decimal AwardForShareFifteenThousandAndAbove { get; set; }
    }
}
