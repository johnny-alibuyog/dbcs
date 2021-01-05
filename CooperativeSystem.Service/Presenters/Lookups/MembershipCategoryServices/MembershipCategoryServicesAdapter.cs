using System;
using System.Collections.Generic;
using System.Linq;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Lookups.Services;

namespace CooperativeSystem.Service.Models.Lookups.MembershipCategoryServices
{
    [Serializable]
    public class MembershipCategoryServicesAdapter : IServicesAdapter
    {
        private IEnumerable<MembershipCategoryService> _list;

        #region IServicesAdapter Members

        public bool ApplianceLoan
        {
            get { return _list.Any(s => s.ServiceID == ServiceCodes.ApplianceLoan); }
            set { }
        }

        public bool EasyLoan
        {
            get { return _list.Any(s => s.ServiceID == ServiceCodes.EasyLoan); }
            set { }
        }

        public bool EmergencyLoan
        {
            get { return _list.Any(s => s.ServiceID == ServiceCodes.EmergencyLoan); }
            set { }
        }

        public bool EquityLoan
        {
            get { return _list.Any(s => s.ServiceID == ServiceCodes.EquityLoan); }
            set { }
        }

        public bool PensionLoan
        {
            get { return _list.Any(s => s.ServiceID == ServiceCodes.PensionLoan); }
            set { }
        }

        public bool RegularLoan // TODO: review if regular loan will be included
        {
            get { return _list.Any(s => s.ServiceID == ServiceCodes.RegularLoan); }
            set { }
        }

        public bool DTILoan // TODO: DTI Loan will not be included
        {
            get { return _list.Any(s => s.ServiceID == ServiceCodes.DTILoan); }
            set { }
        }

        public bool MEDPLoan // TODO: MEDP Loan will not be included
        {
            get { return _list.Any(s => s.ServiceID == ServiceCodes.MEDPLoan); }
            set { }
        }

        public bool CollegeInsurancePlan
        {
            get { return _list.Any(s => s.ServiceID == ServiceCodes.CollegeInsurancePlan); }
            set { }
        }

        public bool PensionPlan
        {
            get { return _list.Any(s => s.ServiceID == ServiceCodes.PensionPlan); }
            set { }
        }

        public bool DeathAidFund
        {
            get { return _list.Any(s => s.ServiceID == ServiceCodes.DeathAidFund); }
            set { }
        }

        public bool TulunganFund
        {
            get { return _list.Any(s => s.ServiceID == ServiceCodes.TulunganFund); }
            set { }
        }

        public bool CapitalShare
        {
            get { return _list.Any(s => s.ServiceID == ServiceCodes.CapitalShare); }
            set { }
        }

        public bool SavingsDeposit
        {
            get { return _list.Any(s => s.ServiceID == ServiceCodes.SavingsDeposit); }
            set { }
        }

        public bool TimeDeposit
        {
            get { return _list.Any(s => s.ServiceID == ServiceCodes.TimeDeposit); }
            set { }
        }

        #endregion

        #region Constructor

        public MembershipCategoryServicesAdapter(string membershipCategoryID)
            : this(membershipCategoryID, new GenericRepository<MembershipCategoryService>()) { }

        internal MembershipCategoryServicesAdapter(string membershipCategoryID, IRepository<MembershipCategoryService> repository)
            : this(repository.GetAll(s => s.MembershipCategoryID == membershipCategoryID)) { }

        internal MembershipCategoryServicesAdapter(IEnumerable<MembershipCategoryService> query)
        {
            _list = query;
        }

        #endregion
    }
}
