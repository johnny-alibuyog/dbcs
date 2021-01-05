using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.Reports.IndividualLedgers
{
    public interface IIndividualLedgerView
    {
        string MembershipCategoryID { get; }
        FilterType FilterType { get; }
        string SelectedAccountNumber { get; set; }
        void PopulateMemberLookup(IList<MemberLookupModel> members);
        void PopulateReports(IList<SavingsAccount> savingsAccounts, IList<LoanAccount> loanAccounts, string membershipCategory);
    }
}
