using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare
{
    public interface IDividendDistributionView
    {
        string UserID { get; set; }

        int Year { get; }
        decimal TotalDividendForDistribution { set; }
        decimal TotalDividend { set; }
        decimal TotalAverageShare { set; }
        bool AllowSummary { set; }
        bool AllowSave { set; }
        bool AllowPost { set; }

        void PopulateReports(IList<DividendDistributionItem> dividendDistributionItems);
    }
}
