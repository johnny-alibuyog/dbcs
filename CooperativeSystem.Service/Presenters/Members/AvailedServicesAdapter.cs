using System;
using System.Collections.Generic;
using System.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.Services;

namespace CooperativeSystem.Service.Presenters.Members
{
    [Serializable]
    public class AvailedServicesAdapter : IServicesAdapter
    {
        private IList<AvailedService> _availedServices;

        #region Routine Helper

        private bool GetFromField(string serviceID)
        {
            return _availedServices.Any(s => s.ServiceID == serviceID);
        }

        private void SetToField(string serviceID, bool avail)
        {
            var exist = _availedServices.Any(s => s.ServiceID == serviceID);

            if (avail && !exist)
                _availedServices.Add(new AvailedService() { ServiceID = serviceID });
            else if (!avail && exist)
                _availedServices.Remove(_availedServices.Single(s => s.ServiceID == serviceID));
        }

        #endregion

        #region IAvailedServicesAdapter Members

        public bool ApplianceLoan
        {
            get { return GetFromField(ServiceCodes.ApplianceLoan); }
            set { SetToField(ServiceCodes.ApplianceLoan, value); }
        }

        public bool EasyLoan
        {
            get { return GetFromField(ServiceCodes.EasyLoan); }
            set { SetToField(ServiceCodes.EasyLoan, value); }
        }

        public bool EmergencyLoan
        {
            get { return GetFromField(ServiceCodes.EmergencyLoan); }
            set { SetToField(ServiceCodes.EmergencyLoan, value); }
        }

        public bool EquityLoan
        {
            get { return GetFromField(ServiceCodes.EquityLoan); }
            set { SetToField(ServiceCodes.EquityLoan, value); }
        }

        public bool PensionLoan
        {
            get { return GetFromField(ServiceCodes.PensionLoan); }
            set { SetToField(ServiceCodes.PensionLoan, value); }
        }

        public bool RegularLoan // TODO: review if regular loan will be included
        {
            get { return GetFromField(ServiceCodes.RegularLoan); }
            set { SetToField(ServiceCodes.RegularLoan, value); }
        }

        public bool DTILoan // TODO: DTI Loan will not be included
        {
            get { return GetFromField(ServiceCodes.DTILoan); }
            set { SetToField(ServiceCodes.DTILoan, value); }
        }

        public bool MEDPLoan // TODO: MEDP Loan will not be included
        {
            get { return GetFromField(ServiceCodes.MEDPLoan); }
            set { SetToField(ServiceCodes.MEDPLoan, value); }
        }

        public bool CollegeInsurancePlan
        {
            get { return GetFromField(ServiceCodes.CollegeInsurancePlan); }
            set { SetToField(ServiceCodes.CollegeInsurancePlan, value); }
        }

        public bool PensionPlan
        {
            get { return GetFromField(ServiceCodes.PensionPlan); }
            set { SetToField(ServiceCodes.PensionPlan, value); }
        }

        public bool CapitalShare
        {
            get { return GetFromField(ServiceCodes.CapitalShare); }
            set { SetToField(ServiceCodes.CapitalShare, value); }
        }

        public bool SavingsDeposit
        {
            get { return GetFromField(ServiceCodes.SavingsDeposit); }
            set { SetToField(ServiceCodes.SavingsDeposit, value); }
        }

        public bool TimeDeposit
        {
            get { return GetFromField(ServiceCodes.TimeDeposit); }
            set { SetToField(ServiceCodes.TimeDeposit, value); }
        }

        public bool DeathAidFund
        {
            get { return GetFromField(ServiceCodes.DeathAidFund); }
            set { SetToField(ServiceCodes.DeathAidFund, value); }
        }

        public bool TulunganFund
        {
            get { return GetFromField(ServiceCodes.TulunganFund); }
            set { SetToField(ServiceCodes.TulunganFund, value); }
        }

        #endregion

        #region Constructor

        public AvailedServicesAdapter() { }

        public AvailedServicesAdapter(IList<AvailedService> availedServices)
        {
            _availedServices = availedServices;
        } 

        #endregion

    }
}
