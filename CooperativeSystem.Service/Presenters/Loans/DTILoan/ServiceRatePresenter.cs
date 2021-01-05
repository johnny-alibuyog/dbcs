using System;
using System.Linq;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Loans.DTILoan
{
    public class ServiceRatePresenter : PresenterTemplate
    {
        private IRepository<DTIMEDPLoanServiceRate> _repository;
        private DTIMEDPLoanServiceRate _model;
        private IServiceRateView _view;

        public ServiceRatePresenter(IServiceRateView view)
        {
            _repository = new GenericRepository<DTIMEDPLoanServiceRate>();
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
                
                _view.ServiceFeeRate = _model.ServiceFeeRate;
                _view.CollectionFeeRate = _model.CollectionFeeRate;
                _view.LoanGuaranteeFundRate = _model.LoanGuaranteeFundRate;
                _view.CapitalBuildupRate = _model.CapitalBuildupRate;
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
                _model.ServiceFeeRate = _view.ServiceFeeRate;
                _model.CollectionFeeRate = _view.CollectionFeeRate;
                _model.LoanGuaranteeFundRate = _view.LoanGuaranteeFundRate;
                _model.CapitalBuildupRate = _view.CapitalBuildupRate;
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
