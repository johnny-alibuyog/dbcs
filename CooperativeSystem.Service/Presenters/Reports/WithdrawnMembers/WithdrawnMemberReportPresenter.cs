using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.AccountStatuses;

namespace CooperativeSystem.Service.Presenters.Reports.WithdrawnMembers
{
    public class WithdrawnMemberReportPresenter : PresenterTemplate
    {
        private IWithdrawnMembersReportView _view;

        public WithdrawnMemberReportPresenter(IWithdrawnMembersReportView view)
        {
            _view = view;
        }

        public bool PopulateReports()
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();
                var withdrawnMembers = db.GetTable<Member>()
                    .Where(x => 
                        x.AccountStatusID == AccountStatusCodes.Closed &&
                        x.WithdrawalDate != null)
                    .Select(x => new WithdrawnMemberModel()
                    {
                        Name = x.LastName + ", " + x.FirstName + " " + x.MiddleName,
                        MembershipCategory = x.MembershipCategory.MembershipCategoryName,
                        ApplicationDate = x.ApplicationDate,
                        WithdrawalDate = x.WithdrawalDate.Value,
                        Amount = x.CapitalShare.CapitalShareDisbursements.Sum(y => y.Amount)
                    });

                _view.PopulateReports(withdrawnMembers.ToList());
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return true;
            }
        }
    }
}
