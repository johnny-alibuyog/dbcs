using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Plans.PensionPlan
{
    public class PensionPlanSettingsPresenter : PresenterTemplate
    {
        private IPensionPlanSettingsView _view;
        private IRepository<PensionPlanSetting> _repository;
        private PensionPlanSetting _entity;

        public PensionPlanSettingsPresenter(IPensionPlanSettingsView view)
        {
            _view = view;
            _repository = new GenericRepository<PensionPlanSetting>();
            //_entity = new PensionPlanSetting();
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
                _view.AmortizationDaily = _entity.AmortizationDaily;
                _view.AmortizationWeekly = _entity.AmortizationWeekly;
                _view.AmortizationSemiMonthly = _entity.AmortizationSemiMonthly;
                _view.AmortizationMonthly = _entity.AmortizationMonthly;
                _view.AmortizationYearly = _entity.AmortizationYearly;
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
