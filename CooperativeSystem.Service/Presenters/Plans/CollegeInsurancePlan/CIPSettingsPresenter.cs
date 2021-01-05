using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan
{
    public class CIPSettingsPresenter : PresenterTemplate
    {
        private ICIPSettingsView _view;
        private IRepository<CollegeInsurancePlanSetting> _repository;
        private CollegeInsurancePlanSetting _entity;

        public CIPSettingsPresenter(ICIPSettingsView view)
        {
            _view = view;
            _repository = new GenericRepository<CollegeInsurancePlanSetting>();
            //_entity = new CollegeInsurancePlanSetting();
        }

        public void Populate()
        {
            try
            {
                _entity = _repository.GetEntity();
                if (_entity == null)
                    _entity = _repository.CreateEntity();

                _view.Id = _entity.Id;
                _view.Terms = _entity.Terms;
                _view.AgingPeriod = _entity.AgingPeriod;
                _view.PaymentCompletionAmount = _entity.PaymentCompletionAmount;
                _view.AwardAmount = _entity.AwardAmount;
                _view.AmortizationDaily = _entity.AmortizationDaily;
                _view.AmortizationWeekly = _entity.AmortizationWeekly;
                _view.AmortizationSemiMonthly  = _entity.AmortizationSemiMonthly;
                _view.AmortizationMonthly  = _entity.AmortizationMonthly;
                _view.AmortizationYearly  = _entity.AmortizationYearly;

            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
        }

        public bool Update()
        {
            try
            {
                _entity.Id = _view.Id;
                _entity.Terms = _view.Terms;
                _entity.AgingPeriod = _view.AgingPeriod;
                _entity.PaymentCompletionAmount = _view.PaymentCompletionAmount;
                _entity.AwardAmount = _view.AwardAmount;
                _entity.AmortizationDaily = _view.AmortizationDaily;
                _entity.AmortizationWeekly = _view.AmortizationWeekly;
                _entity.AmortizationSemiMonthly = _view.AmortizationSemiMonthly;
                _entity.AmortizationMonthly = _view.AmortizationMonthly;
                _entity.AmortizationYearly = _view.AmortizationYearly;

                _repository.SaveAll();
                RaiseSusccessEvent("Successfull saving.");
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
