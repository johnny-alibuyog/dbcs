using System;
using System.Collections.Generic;
using System.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.DeductionTypes;

namespace CooperativeSystem.Service.Presenters.Loans.EasyLoan
{
    public class ServiceRatePreseter : PresenterTemplate
    {
        private IRepository<EasyLoanServiceRate> _repository;
        private EasyLoanServiceRate _addOnModel;
        private EasyLoanServiceRate _deductedModel;
        private IServiceRateView _view;

        public ServiceRatePreseter(IServiceRateView view)
        {
            _repository = new GenericRepository<EasyLoanServiceRate>();
            _view = view;
        }

        public void Populate()
        {
            try
            {
                IList<EasyLoanServiceRate> models = new List<EasyLoanServiceRate>();
                if (_repository.GetAll().Any())
                    models = _repository.GetAll().ToList();

                _addOnModel = models
                    .Where(sr => sr.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn)
                    .FirstOrDefault();

                _deductedModel = models
                    .Where(sr => sr.LoanDeductionTypeID == LoanDeductionTypeCodes.Deducted)
                    .FirstOrDefault();

                if (_addOnModel == null)
                {
                    _addOnModel = _repository.CreateEntity();
                    _addOnModel.LoanDeductionTypeID = LoanDeductionTypeCodes.AddOn;
                }

                if (_deductedModel == null)
                {
                    _deductedModel = _repository.CreateEntity();
                    _addOnModel.LoanDeductionTypeID = LoanDeductionTypeCodes.Deducted;
                }

                _view.AddOnMaximumAmount = _addOnModel.MaximumAmount;
                _view.AddOnServiceFee = _addOnModel.ServiceFee;
                _view.AddOnCollectionFee = _addOnModel.CollectionFee;
                _view.AddOnCapitalBuildup = _addOnModel.CapitalBuildup;
                _view.AddOnInterest = _addOnModel.Interest;

                _view.DeductedMaximumAmount = _deductedModel.MaximumAmount;
                _view.DeductedServiceFee = _deductedModel.ServiceFee;
                _view.DeductedCollectionFee = _deductedModel.CollectionFee;
                _view.DeductedCapitalBuildup = _deductedModel.CapitalBuildup;
                _view.DeductedInterest = _deductedModel.Interest;                
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
                _addOnModel.MaximumAmount = _view.AddOnMaximumAmount;
                _addOnModel.ServiceFee = _view.AddOnServiceFee;
                _addOnModel.CollectionFee = _view.AddOnCollectionFee;
                _addOnModel.CapitalBuildup = _view.AddOnCapitalBuildup;
                _addOnModel.Interest = _view.AddOnInterest;

                _deductedModel.MaximumAmount = _view.DeductedMaximumAmount;
                _deductedModel.ServiceFee = _view.DeductedServiceFee;
                _deductedModel.CollectionFee = _view.DeductedCollectionFee;
                _deductedModel.CapitalBuildup = _view.DeductedCapitalBuildup;
                _deductedModel.Interest = _view.DeductedInterest;

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
