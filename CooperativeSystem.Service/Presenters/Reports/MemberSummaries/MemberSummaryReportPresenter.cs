using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.AccountStatuses;
using CooperativeSystem.Service.Presenters.Lookups.MembershipCategories;

namespace CooperativeSystem.Service.Presenters.Reports.MemberSummaries
{
    public class MemberSummaryReportPresenter : PresenterTemplate
    {
        private IMemberSummaryReportView _view;

        public MemberSummaryReportPresenter(IMemberSummaryReportView view)
        {
            _view = view;
        }

        public bool PopulateReports()
        {
            try
            {
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    var minimumAmount = db.GetTable<CapitalShareMinimumAmount>().Single();

                    var members = db.GetTable<Member>()
                        .Where(x => 
                            x.MembershipCategory.MembershipCategoryID == MembershipCategoryCodes.Associate ||
                            x.MembershipCategory.MembershipCategoryID == MembershipCategoryCodes.Regular
                                ? x.CapitalShare.CurrentBalance > 0
                                : true
                        )
                        .Select(x => new MemberSummaryItem()
                        {
                            IsActive = x.AccountStatusID == AccountStatusCodes.Active,
                            Status = x.AccountStatus.AccountStatusName,
                            Category = x.MembershipCategory.MembershipCategoryName +
                                (x.MembershipCategoryID == MembershipCategoryCodes.Regular
                                    ? (x.CapitalShare.CurrentBalance >= minimumAmount.Amount
                                        ? " " + minimumAmount.Amount.ToString("N2") + " and above " : " below " + minimumAmount.Amount.ToString("N2"))
                                    : string.Empty),
                            Gender = x.SexType.SexTypeName,
                            Name = x.LastName + ", " + x.FirstName + " " + x.MiddleName,
                            IsGood = x.Loans.Count == 0 || x.Loans.All(y => y.Settled) ? 1 : 0,
                            IsBorrower = x.Loans.Any(y => y.Settled == false) ? 1 : 0,
                            IsDelinquent = x.Loans.Any(y => y.Settled == false && y.DueDate < DateTime.Today) ? 1 : 0,
                            IsDelayed = x.Loans.Any(y => y.Settled == false && y.NextPaymentDate.Value.AddDays(y.PaymentMode.GracePeriod) < DateTime.Today) ? 1 : 0,
                        })
                        .OrderBy(x => x.Status)
                        .ThenBy(x => x.Gender)
                        .ToList();

                    _view.PopulateReports(members);
                }

                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }
    }
}
