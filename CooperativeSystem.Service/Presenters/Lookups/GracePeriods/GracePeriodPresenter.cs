using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Lookups;

namespace CooperativeSystem.Service.Presenters.Lookups.GracePeriods
{
    public class GracePeriodPresenter : PresenterTemplate
    {
        private IRepository<PaymentMode> _repository;
        private GracePeriodAdapter _model;
        private IGracePeriodView _view;

        public GracePeriodPresenter(IGracePeriodView view)
        {
            _repository = new GenericRepository<PaymentMode>();
            _view = view;
        }

        public void Populate()
        {
            try
            {
                _model = new GracePeriodAdapter(_repository);

                _view.Daily = _model.Daily;
                _view.Weekly = _model.Weekly;
                _view.SemiMonthly = _model.SemiMonthly;
                _view.Monthly = _model.Monthly;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
        }

        public bool Update()
        {
            bool result = false;
            try
            {
                _model.Daily = _view.Daily;
                _model.Weekly = _view.Weekly;
                _model.SemiMonthly = _view.SemiMonthly;
                _model.Monthly = _view.Monthly;

                _repository.SaveAll();
                RaiseSusccessEvent("Successful saving.");
                result = true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
            return result;
        }

    }
}
