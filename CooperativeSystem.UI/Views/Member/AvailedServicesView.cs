using System;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Members;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Models.Lookups.MembershipCategoryServices;

namespace CooperativeSystem.UI.Views.Member
{
    public partial class AvailedServicesView : UserControlTemplate, IAvailedServicesView
    {
        public AvailedServicesView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Implicit implementation of IAvailedServicesView for checking of CheckBox
        /// based on services availed
        /// </summary>
        #region IAvailedServicesView Members

        public bool ApplianceLoan
        {
            get { return _applianceLoanCheckBox.Checked; }
            set { _applianceLoanCheckBox.Checked = (value & _applianceLoanCheckBox.Enabled); }
        }

        public bool EasyLoan
        {
            get { return _easyLoanCheckBox.Checked; }
            set { _easyLoanCheckBox.Checked = (value & _easyLoanCheckBox.Enabled); }
        }

        public bool EmergencyLoan
        {
            get { return _emergencyLoanCheckBox.Checked; }
            set { _emergencyLoanCheckBox.Checked = (value & _emergencyLoanCheckBox.Enabled); }
        }

        public bool EquityLoan
        {
            get { return _equityLoanCheckBox.Checked; }
            set { _equityLoanCheckBox.Checked = (value & _equityLoanCheckBox.Enabled); }
        }

        public bool PensionLoan
        {
            get { return _pensionLoanCheckBox.Checked; }
            set { _pensionLoanCheckBox.Checked = (value & _pensionLoanCheckBox.Enabled); }
        }

        public bool RegularLoan
        {
            get { return _regularLoanCheckBox.Checked; }
            set { _regularLoanCheckBox.Checked = (value & _regularLoanCheckBox.Enabled); }
        }

        public bool DTILoan
        {
            get { return _DTILoanCheckBox.Checked; }
            set { _DTILoanCheckBox.Checked = (value & _DTILoanCheckBox.Enabled); }
        }

        public bool MEDPLoan
        {
            get { return _MEDPLoanCheckBox.Checked; }
            set { _MEDPLoanCheckBox.Checked = (value & _MEDPLoanCheckBox.Enabled); }
        }

        public bool CollegeInsurancePlan
        {
            get { return _collegeInsurancePlanCheckBox.Checked; }
            set { _collegeInsurancePlanCheckBox.Checked = (value & _collegeInsurancePlanCheckBox.Enabled); }
        }

        public bool PensionPlan
        {
            get { return _pensionPlanCheckBox.Checked; }
            set { _pensionPlanCheckBox.Checked = (value & _pensionPlanCheckBox.Enabled); }
        }

        public bool CapitalShare
        {
            get { return _capitalShareCheckBox.Checked; }
            set { _capitalShareCheckBox.Checked = (value & _capitalShareCheckBox.Enabled); }
        }

        public bool SavingsDeposit
        {
            get { return _savingsDepositCheckBox.Checked; }
            set { _savingsDepositCheckBox.Checked = (value & _savingsDepositCheckBox.Enabled); }
        }

        public bool TimeDeposit
        {
            get { return _timeDepositCheckBox.Checked; }
            set { _timeDepositCheckBox.Checked = (value & _timeDepositCheckBox.Enabled); }
        }

        public bool DeathAidFund
        {
            get { return _deathAidFundCheckBox.Checked; }
            set { _deathAidFundCheckBox.Checked = (value & _deathAidFundCheckBox.Enabled); }
        }

        public bool TulunganFund
        {
            get { return _tulunganFundCheckBox.Checked; }
            set { _tulunganFundCheckBox.Checked = (value & _tulunganFundCheckBox.Enabled); }
        }

        public void EnableServicesBasedOnMembershipCategoyAndServicesAvailed(IServicesAdapter allowableServices, IServicesAdapter availedServices)
        {
            EnableAndCheck(allowableServices, availedServices);
        }

        #endregion
        
        #region Routine Helpers

        private void EnableApplianceLoan(bool value)
        {
            _applianceLoanCheckBox.Enabled = value;
            if (!value) ApplianceLoan = false;
        }

        private void EnableEasyLoan(bool value)
        {
            _easyLoanCheckBox.Enabled = value;
            if (!value) EasyLoan = false;
        }

        private void EnableEquityLoan(bool value)
        {
            _equityLoanCheckBox.Enabled = value;
            if (!value) EquityLoan = false;
        }

        private void EnableEmergencyLoan(bool value)
        {
            _emergencyLoanCheckBox.Enabled = value;
            if (!value) EmergencyLoan = false;
        }

        private void EnablePensionLoan(bool value)
        {
            _pensionLoanCheckBox.Enabled = value;
            if (!value) PensionLoan = false;
        }

        private void EnableRegularLoan(bool value) // TODO: review if regular loan will be included
        {
            _regularLoanCheckBox.Enabled = value;
            if (!value) RegularLoan = false;
        }

        private void EnableDTILoan(bool value) // TODO: DTI Loan will not be included
        {
            _DTILoanCheckBox.Enabled = value;
            if (!value) DTILoan = false;
        }

        private void EnableMEDPLoan(bool value) // TODO: MEDP Loan will not be included
        {
            _MEDPLoanCheckBox.Enabled = value;
            if (!value) MEDPLoan = false;
        }

        private void EnableCollegeInsurancePlan(bool value)
        {
            _collegeInsurancePlanCheckBox.Enabled = value;
            if (!value) CollegeInsurancePlan = false;
        }

        private void EnablePensionPlan(bool value)
        {
            _pensionPlanCheckBox.Enabled = value;
            if (!value) PensionPlan = false;
        }

        private void EnableCapitalShare(bool value)
        {
            _capitalShareCheckBox.Enabled = value;
            if (!value) CapitalShare = false;
        }

        private void EnableSavingsDeposit(bool value)
        {
            _savingsDepositCheckBox.Enabled = value;
            if (!value) SavingsDeposit = false;
        }

        private void EnableTimeDeposit(bool value)
        {
            _timeDepositCheckBox.Enabled = value;
            if (!value) TimeDeposit = false;
        }

        private void EnableDeathAidFund(bool value)
        {
            _deathAidFundCheckBox.Enabled = value;
            if (!value) DeathAidFund = false;
        }

        private void EnableTulunganFund(bool value)
        {
            _tulunganFundCheckBox.Enabled = value;
            if (!value) TulunganFund = false;
        }

        #endregion

        private void EnableAndCheck(IServicesAdapter allowableServices, IServicesAdapter availedServices)
        {
            // enables/disables Services based on MembershipCategory
            //((IServicesAdapter)this).GetValuesFrom(allowableServices);
            
            // checks Services based on Availed services
            //((IAvailedServicesView)this).GetValuesFrom(availedServices);

            // enables/disables Services based on MembershipCategory
            EnableApplianceLoan(allowableServices.ApplianceLoan);
            EnableEasyLoan(allowableServices.ApplianceLoan);
            EnableEquityLoan(allowableServices.EquityLoan);
            EnableEmergencyLoan(allowableServices.EmergencyLoan);
            EnablePensionLoan(allowableServices.PensionLoan);
            EnableRegularLoan(allowableServices.RegularLoan);   // TODO: review if regular loan will be included
            EnableDTILoan(allowableServices.DTILoan);           // TODO: DTI Loan will not be included
            EnableMEDPLoan(allowableServices.MEDPLoan);         // TODO: MEDP Loan will not be included
            EnableCollegeInsurancePlan(allowableServices.CollegeInsurancePlan);
            EnablePensionPlan(allowableServices.PensionPlan);
            EnableCapitalShare(allowableServices.CapitalShare);
            EnableSavingsDeposit(allowableServices.SavingsDeposit);
            EnableTimeDeposit(allowableServices.TimeDeposit);
            EnableDeathAidFund(allowableServices.DeathAidFund);
            EnableTulunganFund(allowableServices.TulunganFund);

            // checks Services based on Availed services
            if (availedServices != null)
                this.GetValuesFrom(availedServices);
            else
                this.SetValues(true);
        }

        private void AvailedServiceView_ParentChanged(object sender, EventArgs e)
        {
        }
    }
}
