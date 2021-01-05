using System;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Savings.SavingsDeposit
{
    public class InterestRatePresenter : PresenterTemplate
    {
        private IRepository<SavingsDepositInterestRate> _repository;
        private SavingsDepositInterestRate _model;
        private IInterestRateView _view;

        public InterestRatePresenter(IInterestRateView view)
        {
            _repository = new GenericRepository<SavingsDepositInterestRate>();
            _view = view;
        }

        public void Populate()
        {
            try
            {
                _model = _repository.GetEntity();
                if (_model == null)
                    _model = _repository.CreateEntity();

                _view.InterestRate = _model.InterestRate;
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
                _model.InterestRate = _view.InterestRate;
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
