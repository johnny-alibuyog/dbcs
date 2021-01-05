using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare
{
    public class CapitalShareMinimumAmountPresenter : PresenterTemplate
    {
        private ICapitalShareMinimumAmountView _view;
        private IRepository<CapitalShareMinimumAmount> _repository;
        private CapitalShareMinimumAmount _entity;

        public CapitalShareMinimumAmountPresenter(ICapitalShareMinimumAmountView view)
        {
            _view = view;

            _repository = new GenericRepository<CapitalShareMinimumAmount>();
            //_entity = new CapitalShareMinimumAmount();
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
