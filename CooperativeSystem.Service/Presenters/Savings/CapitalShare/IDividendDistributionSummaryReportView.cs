using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare
{
    public interface IDividendDistributionSummaryReportView
    {
        void Populate(IList<DividendDistributionSummaryItem> items, int year);
    }
}
