using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.IndividualLedgersRevision
{
    public interface IIndividualLedgerRevisionReportView
    {
        DateTime Date { get; set; }
        string MembershipCategory { get; set; }
        IList<Account> Accounts { get; set; }
    }
}
