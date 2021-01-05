using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.SavingsDeposit
{
    public interface ISavingsDepositSummaryView : ISummaryView
    {
        IList<SavingsDepositTransaction> Transactions { set; }
        Nullable<decimal> TotalSavings { set; }
    }
}
