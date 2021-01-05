using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.DelinquentAccounts
{
    public interface IDelinquentAccountReportView
    {
        void PopulateReports(IList<DelinquentAccount> delinquentAccounts, decimal totalCapitalShare, decimal totalSavingsDeposit, decimal totalTimeDeposit, decimal totalOutstandingBalance, decimal totalNetExposure);
    }
}
