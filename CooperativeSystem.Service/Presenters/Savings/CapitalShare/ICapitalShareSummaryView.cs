using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Presenters.Savings.CapitalShare.Calculators;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare
{
    public interface ICapitalShareSummaryView : ISummaryView
    {
        IList<CapitalShareTransaction> Transactions { set; }
        Nullable<decimal> TotalShare { set; }
    }
}
