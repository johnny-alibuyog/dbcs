using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare
{
    public class RefundRatioPresenter : PresenterTemplate
    {
        private IRepository<DividendPatronageRatio> _repository;
        private DividendPatronageRatio _model;
        private IRefundRatioView _view;

        public RefundRatioPresenter(IRefundRatioView view)
        {
            _repository = new GenericRepository<DividendPatronageRatio>();
            _view = view;
        }

        public bool Populate()
        {
            try
            {
                _model = _repository.GetEntity();
                if (_model == null)
                    _model = _repository.CreateEntity();

                _view.DividendRatio = _model.DividendRatio;
                _view.PatronageRatio = _model.PatronageRatio;

                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                _model.DividendRatio = _view.DividendRatio;
                _model.PatronageRatio = _view.PatronageRatio;
                _repository.SaveAll();
                RaiseSusccessEvent("Successful saving.");
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
