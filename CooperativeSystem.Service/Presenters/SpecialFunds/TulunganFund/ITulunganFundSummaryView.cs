using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.SpecialFunds.TulunganFund
{
    public interface ITulunganFundSummaryView : ISummaryView
    {
        IList<TulunganFundTransaction> Transactions { set; }
        Nullable<decimal> Total { set; }
    }
}
