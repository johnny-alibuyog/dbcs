using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.PaymentModes;
using CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan.Calculators;

namespace CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan
{
    public class CIPEnrollmentPresenter : PresenterTemplate
    {
        private ICIPEnrollmentView _view;

        #region Routine Helpers

        private void ClearView()
        {
            _view.CollegeInsurancePlanID = 0;
            _view.UserLastName = string.Empty;
            _view.UserFirstName = string.Empty;
            _view.UserMiddleName = string.Empty;
            _view.DateOfBirth = DateTime.Today;
            _view.Relation = null;
            _view.Address = string.Empty;

            _view.ApplicationDate = DateTime.Today;
            _view.PaymentMode = new PaymentMode() { PaymentModeID = PaymentModeCodes.Daily };
            _view.Terms = 5;
            _view.AgingPeriod = 5;
            _view.PaymentCompletionAmount = 0M;
            _view.AwardAmount = 0M;
        }

        private void PopulateView(Models.CollegeInsurancePlan entity)
        {
            _view.CollegeInsurancePlanID = entity.CollegeInsurancePlanID;
            _view.MemberID = entity.MemberID;

            _view.UserLastName = entity.UserLastName;
            _view.UserFirstName = entity.UserFirstName;
            _view.UserMiddleName = entity.UserMiddleName;
            _view.DateOfBirth = entity.DateOfBirth;
            _view.Relation = entity.Relation;
            _view.Address = entity.Address;

            _view.ApplicationDate = entity.ApplicationDate;
            _view.PaymentMode = entity.PaymentMode;
            _view.Terms = entity.Terms;
            _view.AgingPeriod = entity.AgingPeriod;
            _view.Amortization = entity.Amortization;
            _view.PaymentCompletionAmount = entity.PaymentCompletionAmount;
            _view.AwardAmount = entity.AwardAmount;
        }

        #endregion

        public CIPEnrollmentPresenter(ICIPEnrollmentView view)
        {
            _view = view;
        }

        public void Clear()
        {
            ClearView();
            LoadDefaults();
        }

        public void Load(decimal collegeInsurancePlanID)
        {
            var repository = new GenericRepository<Models.CollegeInsurancePlan>();
            var entity = repository.GetEntity(x => x.CollegeInsurancePlanID == collegeInsurancePlanID);
            PopulateView(entity);
        }

        private void LoadDefaults()
        {
            var repository = new GenericRepository<Models.CollegeInsurancePlanSetting>();
            var entity = repository.GetEntity();

            _view.PaymentCompletionAmount = entity.PaymentCompletionAmount;
            _view.AwardAmount = entity.AwardAmount;
            _view.Terms = entity.Terms;
            _view.AgingPeriod = entity.AgingPeriod;

            SyncronizeAmortization(entity);
        }

        public void SyncronizeAmortization()
        {
            var repository = new GenericRepository<Models.CollegeInsurancePlanSetting>();
            var entity = repository.GetEntity();

            SyncronizeAmortization(entity);
        }

        private void SyncronizeAmortization(CollegeInsurancePlanSetting entity)
        {
            var calculator = new AmortizationCalculator(entity);
            _view.Amortization = calculator.CalculateAmortization(_view.PaymentMode.PaymentModeID);
        }
    }
}
