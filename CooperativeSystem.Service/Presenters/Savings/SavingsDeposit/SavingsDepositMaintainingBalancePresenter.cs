using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Savings.SavingsDeposit
{
    public class SavingsDepositMaintainingBalancePresenter : PresenterTemplate
    {
        private ISavingsDepositMaintainingBalanceView _view;
        private IRepository<SavingsDepositMaintainingBalance> _repository;
        private SavingsDepositMaintainingBalance _entity;

        public SavingsDepositMaintainingBalancePresenter(ISavingsDepositMaintainingBalanceView view)
        {
            _view = view;
            _repository = new GenericRepository<SavingsDepositMaintainingBalance>();
            //_entity = new SavingsDepositMaintainingBalance();
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
