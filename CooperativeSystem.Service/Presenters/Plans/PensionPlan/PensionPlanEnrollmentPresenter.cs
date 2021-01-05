using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.PaymentModes;
using CooperativeSystem.Service.Utilities.Logs;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Plans.PensionPlan.Calculators;

namespace CooperativeSystem.Service.Presenters.Plans.PensionPlan
{
    public class PensionPlanEnrollmentPresenter : PresenterTemplate
    {
        private IPensionPlanEnrollmentView _view;
        private PensionPlanSetting _settings;

        public PensionPlanEnrollmentPresenter(IPensionPlanEnrollmentView view)
        {
            _view = view;
        }

        public void LoadDefaults()
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();
                var repository = new GenericRepository<PensionPlanSetting>(db);
                _settings = repository.GetEntity();

                var paymentModes = db.GetTable<ServicePaymentMode>()
                    .Where(x => x.ServiceID == ServiceCodes.PensionPlan)
                    .Select(x => x.PaymentMode);

                _view.PopulatePaymentMode(paymentModes.ToList());
                _view.ApplicationDate = DateTime.Today;
                _view.PaymentMode = new PaymentMode() { PaymentModeID = PaymentModeCodes.Daily };
                _view.Terms = _settings.Terms;
                _view.AgingPeriod = _settings.AgingPeriod;
                _view.PaymentCompletionAmount = _settings.PaymentCompletionAmount;

                SyncronizeAmortization();
            }
            catch (Exception ex)
            {
                ErrorLogger logger = new ErrorLogger();
                logger.Log(ex.ToString());
            }
        }

        public void SyncronizeAmortization()
        {
            var calculator = new AmortizationCalculator(_settings);
            _view.Amortization = calculator.CalculateAmortization(_view.PaymentMode.PaymentModeID);
        }

        public bool Enroll()
        {
            try
            {
                var repository = new GenericRepository<CooperativeSystem.Service.Models.PensionPlan>();
                var plan = repository.CreateEntity();

                plan.MemberID = _view.MemberID;
                plan.ApplicationDate = _view.ApplicationDate;
                plan.PaymentModeID = _view.PaymentMode.PaymentModeID;
                plan.Terms = _view.Terms;
                plan.AgingPeriod = _view.AgingPeriod;
                plan.Amortization = _view.Amortization;
                plan.PaymentCompletionAmount = _view.PaymentCompletionAmount;

                repository.SaveAll();
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
