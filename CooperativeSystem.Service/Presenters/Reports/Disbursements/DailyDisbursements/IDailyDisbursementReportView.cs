using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Disbursements.DailyDisbursements
{
    public interface IDailyDisbursementReportView
    {
        DateTime Date { get; set; }
        void PopulateReports(IList<DailyDisbursement> disbursements);
    }
}
