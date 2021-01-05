using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare
{
    public interface IPatronageRefundSummaryReportView
    {
        void Populate(IList<PatronageRefundSummaryItem> items, int year);
    }
}
