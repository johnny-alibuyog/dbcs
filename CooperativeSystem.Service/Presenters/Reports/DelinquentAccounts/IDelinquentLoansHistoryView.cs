using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.DelinquentAccounts
{
    public interface IDelinquentLoansHistoryView
    {
        Nullable<DateTime> Period { get; }
        void PopulatePeriods(IList<Nullable<DateTime>> periods);
    }
}
