using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Savings.TimeDeposit
{
    public class TimeDepositMinimumAmountPresenter : PresenterTemplate
    {
        private ITimeDepositMinimumAmountView _view;
        private IRepository<TimeDepositMinimumAmount> _repository;
        private TimeDepositMinimumAmount _entity;

        public TimeDepositMinimumAmountPresenter(ITimeDepositMinimumAmountView view)
        {
            _view = view;
            _repository = new GenericRepository<TimeDepositMinimumAmount>();
            //_entity = new TimeDepositMinimumAmount();
        }

        public void Populate()
        {
            try
            {
                _entity = _repository.GetEntity();
                if (_entity == null)
                    _entity = _repository.CreateEntity();

                _view.Id = _entity.Id;
                _view.Amount = _entity.Amount;
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
                _entity.Amount = _view.Amount;
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
