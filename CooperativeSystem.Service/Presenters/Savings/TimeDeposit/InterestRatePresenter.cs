using System;
using System.Linq;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Savings.TimeDeposit
{
    public class InterestRatePresenter : PresenterTemplate
    {
        private IRepository<TimeDepositInterestRate> _repository;
        private TimeDepositInterestRate _model;
        private IInterestRateView _view;

        public InterestRatePresenter(IInterestRateView view)
        {
            _repository = new GenericRepository<TimeDepositInterestRate>();
            _view = view;
        }

        public void Populate()
        {
            try
            {
                if (_repository.GetAll().Count() > 1)
                {
                    _repository.MarkForDeletion(_repository.GetAll());
                    _repository.SaveAll();
                }

                _model = _repository.GetEntity();
                if (_model == null)
                    _model = _repository.CreateEntity();

                _view.BelowFiftyThousand = _model.BelowFiftyThousand;
                _view.FiftyToNinetyNineThousand= _model.FiftyToNinetyNineThousand;
                _view.AboveNinetyNineThousand = _model.AboveNinetyNineThousand;
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
                _model.BelowFiftyThousand = _view.BelowFiftyThousand;
                _model.FiftyToNinetyNineThousand = _view.FiftyToNinetyNineThousand;
                _model.AboveNinetyNineThousand = _view.AboveNinetyNineThousand;

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