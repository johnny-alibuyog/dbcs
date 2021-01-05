using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Presenters.Lookups.ServiceCategories;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Presenters.Reports.MemberBalanceSummaries
{
    public class MemberBalanceSummariesPresenter : PresenterTemplate
    {
        private IMemberBalanceSummariesView _view;

        public MemberBalanceSummariesPresenter(IMemberBalanceSummariesView view)
        {
            _view = view;
        }

        public bool PopulateMemberLookup()
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();

                var query = db.GetTable<Member>()
                    .Where(m => m.MembershipCategoryID == _view.MembershipCategoryID)
                    .Select(m => new MemberLookupModel()
                    {
                        AccountNumber = m.AccountNumber,
                        Name = m.LastName + ", " + m.FirstName + " " + m.MiddleName
                    })
                    .OrderBy(x => x.Name);

                _view.PopulateMemberLookup(query.ToList());
                _view.SelectedAccountNumber = null;
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool PopulateReports()
        {
            try
            {
                if (_view.FilterType == FilterType.ByMember && string.IsNullOrEmpty(_view.SelectedAccountNumber))
                    throw new Exception("You must select a member.");

                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Loan>(x => x.LoanReceipts);
                loadOptions.LoadWith<Loan>(x => x.LoanAdjustments);
                loadOptions.LoadWith<Loan>(x => x.LoanDividendAdjustments);
                loadOptions.LoadWith<Loan>(x => x.LoanDisbursements);
                loadOptions.LoadWith<Loan>(x => x.LatePaymentFineReceipts);
                loadOptions.LoadWith<Loan>(x => x.DelinquentFineReceipts);

                loadOptions.LoadWith<LoanReceipt>(x => x.CashReceipt);
                loadOptions.LoadWith<LoanAdjustment>(x => x.Adjustment);
                loadOptions.LoadWith<LoanDividendAdjustment>(x => x.Adjustment);
                loadOptions.LoadWith<LoanDisbursement>(x => x.CashDisbursement);
                loadOptions.LoadWith<LatePaymentFineReceipt>(x => x.CashReceipt);
                loadOptions.LoadWith<DelinquentFineReceipt>(x => x.CashReceipt);

                var db = new DataContextFactory().CreateDataContext();
                db.LoadOptions = loadOptions;

                var serviceCategoryTable = db.GetTable<ServiceCategory>();
                var serviceTable = db.GetTable<CooperativeSystem.Service.Models.Service>();

                var accountNumber = _view.SelectedAccountNumber ?? string.Empty;
                var membershipCategoryID = _view.MembershipCategoryID ?? string.Empty;

                // PredicateBuilder is not applicable on this Meyn!
                //var predicate = PredicateBuilder.True<Member>();
                //if (_view.FilterType == FilterType.ByMember)
                //    predicate = predicate.And(m => m.AccountNumber.StartsWith(accountNumber));
                //else
                //    predicate = predicate.And(m => m.MembershipCategoryID.Equals(membershipCategoryID));

                var query = db.GetTable<Loan>()
                    .Where(x => 
                        x.Member.AccountNumber.StartsWith(accountNumber) && 
                        x.Member.MembershipCategoryID.Equals(membershipCategoryID) &&
                        x.Settled == false
                    )
                    .Select(x => new MemberBalanceSummaryItem()
                    {
                        Member = x.Member.LastName + ", " + x.Member.FirstName + " " + x.Member.MiddleName,
                        ServiceCategory = x.Service.ServiceCategory.ServiceCategoryName,
                        Service = x.Service.ServiceName,
                        Balance = x.GetOutstandingBalance()
                    })
                    .ToList() // eagerly load Loan because l.GetOutstandingBalance() is a computational
                    .Concat(db.GetTable<CooperativeSystem.Service.Models.CollegeInsurancePlan>()
                    .Where(x => 
                        x.Member.AccountNumber.StartsWith(accountNumber) && 
                        x.Member.MembershipCategoryID.Equals(membershipCategoryID) &&
                        x.Consumed == false
                    )
                    .Select(x => new MemberBalanceSummaryItem()
                    {
                        Member = x.Member.LastName + ", " + x.Member.FirstName + " " + x.Member.MiddleName,
                        ServiceCategory = serviceCategoryTable.Single(o => o.ServiceCategoryID == ServiceCategoryCodes.Plans).ServiceCategoryName,
                        Service = serviceTable.Single(o => o.ServiceID == ServiceCodes.CollegeInsurancePlan).ServiceName,
                        Balance = x.CurrentBalance,
                    }))
                    .Concat(db.GetTable<PensionPlan>()
                    .Where(x =>
                        x.Member.AccountNumber.StartsWith(accountNumber) &&
                        x.Member.MembershipCategoryID.Equals(membershipCategoryID) &&
                        x.Consumed == false
                    )
                    .Select(x => new MemberBalanceSummaryItem()
                    {
                        Member = x.Member.LastName + ", " + x.Member.FirstName + " " + x.Member.MiddleName,
                        ServiceCategory = serviceCategoryTable.Single(o => o.ServiceCategoryID == ServiceCategoryCodes.Plans).ServiceCategoryName,
                        Service = serviceTable.Single(o => o.ServiceID == ServiceCodes.PensionPlan).ServiceName,
                        Balance = x.CurrentBalance
                    }))
                    .Concat(db.GetTable<CapitalShare>()
                    .Where(x => 
                        x.Member.AccountNumber.StartsWith(accountNumber) && 
                        x.Member.MembershipCategoryID.Equals(membershipCategoryID)
                    )
                    .Select(x => new MemberBalanceSummaryItem()
                    {
                        Member = x.Member.LastName + ", " + x.Member.FirstName + " " + x.Member.MiddleName,
                        ServiceCategory = serviceCategoryTable.Single(o => o.ServiceCategoryID == ServiceCategoryCodes.Savings).ServiceCategoryName,
                        Service = serviceTable.Single(o => o.ServiceID == ServiceCodes.CapitalShare).ServiceName,
                        Balance = x.CurrentBalance
                    }))
                    .Concat(db.GetTable<SavingsDeposit>()
                    .Where(x => 
                        x.Member.AccountNumber.StartsWith(accountNumber) && 
                        x.Member.MembershipCategoryID.Equals(membershipCategoryID)
                    )
                    .Select(x => new MemberBalanceSummaryItem()
                    {
                        Member = x.Member.LastName + ", " + x.Member.FirstName + " " + x.Member.MiddleName,
                        ServiceCategory = serviceCategoryTable.Single(o => o.ServiceCategoryID == ServiceCategoryCodes.Savings).ServiceCategoryName,
                        Service = serviceTable.Single(o => o.ServiceID == ServiceCodes.SavingsDeposit).ServiceName,
                        Balance = x.CurrentBalance
                    }))
                    .Concat(db.GetTable<TimeDeposit>()
                    .Where(x =>
                        x.Member.AccountNumber.StartsWith(accountNumber) &&
                        x.Member.MembershipCategoryID.Equals(membershipCategoryID) &&
                        x.Consumed == false
                    )
                    .Select(x => new MemberBalanceSummaryItem()
                    {
                        Member = x.Member.LastName + ", " + x.Member.FirstName + " " + x.Member.MiddleName,
                        ServiceCategory = serviceCategoryTable.Single(o => o.ServiceCategoryID == ServiceCategoryCodes.Savings).ServiceCategoryName,
                        Service = serviceTable.Single(o => o.ServiceID == ServiceCodes.TimeDeposit).ServiceName,
                        Balance = x.CurrentBalance,
                    }))
                    .Concat(db.GetTable<DeathAidFund>()
                    .Where(x => 
                        x.Member.AccountNumber.StartsWith(accountNumber) && 
                        x.Member.MembershipCategoryID.Equals(membershipCategoryID)
                    )
                    .Select(x => new MemberBalanceSummaryItem()
                    {
                        Member = x.Member.LastName + ", " + x.Member.FirstName + " " + x.Member.MiddleName,
                        ServiceCategory = serviceCategoryTable.Single(o => o.ServiceCategoryID == ServiceCategoryCodes.SpecialFunds).ServiceCategoryName,
                        Service = serviceTable.Single(o => o.ServiceID == ServiceCodes.DeathAidFund).ServiceName,
                        Balance = x.DeathAidFundReceipts.Sum(o => o.Amount)
                    }))
                    .Concat(db.GetTable<TulunganFund>()
                    .Where(x => 
                        x.Member.AccountNumber.StartsWith(accountNumber) && 
                        x.Member.MembershipCategoryID.Equals(membershipCategoryID)
                    )
                    .Select(x => new MemberBalanceSummaryItem()
                    {
                        Member = x.Member.LastName + ", " + x.Member.FirstName + " " + x.Member.MiddleName,
                        ServiceCategory = serviceCategoryTable.Single(o => o.ServiceCategoryID == ServiceCategoryCodes.SpecialFunds).ServiceCategoryName,
                        Service = serviceTable.Single(o => o.ServiceID == ServiceCodes.TulunganFund).ServiceName,
                        Balance = x.CurrentBalance
                    }))
                    .OrderBy(o => o.Member)
                    .ThenBy(o => o.ServiceCategory)
                    .ThenBy(o => o.Service)
                    .ThenBy(o => o.Balance);

                var membershipCategory = db.GetTable<MembershipCategory>()
                    .Single(x => x.MembershipCategoryID.Equals(membershipCategoryID))
                    .MembershipCategoryName;

                _view.PopulateReports(query.ToList(), membershipCategory);
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
