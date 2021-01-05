using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CooperativeSystem.Service.Presenters.Lookups.AccountStatuses;
using CooperativeSystem.Service.Presenters.Lookups.MaritalStatuses;
using CooperativeSystem.Service.Presenters.Lookups.MembershipCategories;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Lookups.SexTypes;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Models
{
    partial class Member
    {
        public override string ToString()
        {
            return (LastName + ", " + FirstName + " " + MiddleName).Trim();
        }

        partial void OnApplicationDateChanged()
        {
            _ApplicationDate = _ApplicationDate.TruncateTime();
        }

        partial void OnDateOfBirthChanged()
        {
            _DateOfBirth = _DateOfBirth.TruncateTime();
        }

        partial void OnWithdrawalDateChanged()
        {
            if (_WithdrawalDate != null)
                _WithdrawalDate = _WithdrawalDate.Value.TruncateTime();
        }

        partial void OnCreated()
        {
            AccountNumber = string.Empty;
            AccountStatusID = AccountStatusCodes.Active;
            MembershipCategoryID = MembershipCategoryCodes.Regular;
            ApplicationDate = DateTime.Today;
            WithdrawalDate = null;
            LastName = string.Empty;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            DateOfBirth = DateTime.Today;
            PlaceOfBirth = string.Empty;
            MaritalStatusID = MaritalStatusCodes.Single;
            SexTypeID = SexTypeCodes.Female;
            Address = string.Empty;
            HomePhone = string.Empty;
            MobilePhone = string.Empty;
            Occupation = string.Empty;
            Employer = string.Empty;
            MonthlySalary = 0M;
            OfficeAddress = string.Empty;
            OfficePhone = string.Empty;
            SpouseLastName = string.Empty;
            SpouseFirstName = string.Empty;
            SpouseMiddleName = string.Empty;
            SpouseOccupation = string.Empty;
            SpouseContactNumber = string.Empty;
            NearestRelativeLastName = string.Empty;
            NearestRelativeFirstName = string.Empty;
            NearestRelativeMiddleName = string.Empty;
            NearestRelativeContactNumber = string.Empty;
            Picture = new Picture();

            // create this aggregates by default
            CapitalShare = new CapitalShare();
            SavingsDeposit = new SavingsDeposit();
            TulunganFund = new TulunganFund();
            DeathAidFund = new DeathAidFund();
        }

        partial void OnValidate(ChangeAction action)
        {
            if (action == ChangeAction.Delete || action == ChangeAction.None)
                return;

            if (MembershipCategoryID == MembershipCategoryCodes.JuniorSaver)
            {
                const decimal DAYS_IN_A_YEAR = 365.25M;
                var ageUponApplication = (ApplicationDate - DateOfBirth).Days / DAYS_IN_A_YEAR;
                if (ageUponApplication > 17)
                    throw new Exception("You are over 17 years old. Junior Savers are for 17 years old and below.");
            }
        }

        public virtual bool IsEntitledForDividendCredit(int year)
        {
            var hasUnsettledLoan = Loans
                .Where(x => x.DueDate.Year <= year)
                .Any(o => 
                    o.SettlementDate == null ||
                    o.SettlementDate.Value.Year > year
                );

            if (hasUnsettledLoan)
                return false;

            return true;

            ///// members with delinquent loans for the current
            ///// year is not entitlement for dividend 
            //var withDelinquentLoansThisYear = Loans
            //    .Where(x => x.DueDate.Year == year)
            //    .Any(x =>
            //        x.LastPaymentDate != null &&
            //        x.LastPaymentDate.Value.TruncateTime() > x.DueDate.TruncateTime()
            //    );

            //if (withDelinquentLoansThisYear)
            //    return false;

            ///// members with delinquent loans from previous years that
            ///// is still delinquent is not entitlement for dividend 
            //var withDelinquentLoansOnPreviousYears = Loans
            //    .Where(x => x.DueDate.Year < year)
            //    .Any(x => x.IsDelinquent());

            //if (withDelinquentLoansOnPreviousYears)
            //    return false;

            //return true;
        }

        #region PredicateBuilder

        // TODO: Check why predicate builder is not working.
        public static Expression<Func<Member, bool>> TheMembersEntitledForDeathAidFund()
        {
            var predicate = PredicateBuilder.False<Member>();

            predicate.And(x =>
                x.DeathAidFund != null &&
                x.AccountStatusID != AccountStatusCodes.Closed &&
                x.AvailedServices.Any(o => o.ServiceID == ServiceCodes.DeathAidFund)
            );

            return predicate;
        }

        public static Expression<Func<Member, bool>> TheMembersEntitledForTulunganFund()
        {
            var predicate = PredicateBuilder.False<Member>();

            predicate.And(x =>
                x.TulunganFund != null &&
                x.AccountStatusID != AccountStatusCodes.Closed &&
                x.AvailedServices.Any(o => o.ServiceID == ServiceCodes.TulunganFund)
            );

            return predicate;
        }

        #endregion
    }
}
