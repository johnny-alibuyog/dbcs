using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare
{
    public interface IPatronageRefundView
    {
        string UserID { get; set; }

        int Year { get; }
        decimal TotalPatronageForRefund { set; }
        decimal TotalPatronage { set; }
        decimal TotalAveragePatronage { set; }
        bool AllowSummary { set; }
        bool AllowSave { set; }
        bool AllowPost { set; }

        void PopulateReports(IList<PatronageRefundItem> patronageRefundItems);
    }
}
