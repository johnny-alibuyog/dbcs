using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.SpecialFunds.DeathAidFund
{
    public interface IDeathAidFundSummaryView : ISummaryView
    {
        IList<DeathAidFundTransaction> Transactions { set; }
        Nullable<decimal> Total { set; }
    }
}
