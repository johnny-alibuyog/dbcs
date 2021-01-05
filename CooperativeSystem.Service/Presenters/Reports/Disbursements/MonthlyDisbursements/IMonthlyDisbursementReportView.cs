using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Disbursements.MonthlyDisbursements
{
    public interface IMonthlyDisbursementReportView
    {
        DateTime Date { get; set; }
        void PopulateReports(IList<MonthlyDisbursement> disbursements);
    }
}
