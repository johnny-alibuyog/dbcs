using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.IndividualLedgers
{
    public interface IIndividualLedgerReportView
    {
        DateTime Date { get; set; }
        string MembershipCategory { get; set; }
        IList<LoanAccount> LoanAccounts { get; set; }
        IList<SavingsAccount> SavingsAccounts { get; set; }
    }
}
