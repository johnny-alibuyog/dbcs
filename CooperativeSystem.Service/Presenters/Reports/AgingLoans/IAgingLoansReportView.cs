using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.AgingLoans
{
    public interface IAgingLoansReportView
    {
        void PopulateReports(IList<AgingLoanModel> agingLoans);
    }
}
