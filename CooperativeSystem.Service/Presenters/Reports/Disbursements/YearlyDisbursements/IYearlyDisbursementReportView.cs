using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Disbursements.YearlyDisbursements
{
    public interface IYearlyDisbursementReportView
    {
        DateTime Date { get; set; }
        void PopulateReports(IList<YearlyDisbursement> disbursements);
    }
}
