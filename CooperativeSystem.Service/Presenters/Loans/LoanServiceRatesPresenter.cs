using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.DeductionTypes;
using System.Transactions;

namespace CooperativeSystem.Service.Presenters.Loans
{
    public class LoanServiceRatesPresenter : PresenterTemplate 
    {
        // DataContext
        private DataContext _db;

        // repositories
        private IRepository<LoanCapitalBuildupRate> _capitalBuildupRateRepository;
        private IRepository<LoanCollectionFeeRate> _collectionFeeRateRepository;
        private IRepository<LoanGuaranteeFundRate> _guaranteeFundRateRepository;
        private IRepository<LoanInterestRate> _interestRatesRepository;
        private IRepository<LoanServiceFeeRate> _serviceFeeRateRepository;

        // models
        private LoanCapitalBuildupRate _addOnCapitalBuildupRateModel;
        private LoanCollectionFeeRate _addOnCollectionFeeRateModel;
        private LoanGuaranteeFundRate _addOnGuaranteeFundRateModel;
        private LoanInterestRateAdapter _addOnInterestRatesAdapter;
        private LoanServiceFeeRate _addOnServiceFeeRateModel;

        private LoanCapitalBuildupRate _deductedCapitalBuildupRateModel;
        private LoanCollectionFeeRate _deductedCollectionFeeRateModel;
        private LoanGuaranteeFundRate _deductedGuaranteeFundRateModel;
        private LoanInterestRateAdapter _deductedInterestRatesAdapter;
        private LoanServiceFeeRate _deductedServiceFeeRateModel;

        // views
        private ILoanCapitalBuildupRateView _capitalBuildupRateView;
        private ILoanCollectionFeeRateView _collectionFeeRateView;
        private ILoanGuaranteeFundRateView _guaranteeFundRateView;
        private ILoanInterestRateView _interestRateView;
        private ILoanServiceFeeRateView _serviceFeeRateView;

        public LoanServiceRatesPresenter(ILoanServiceRateView view)
        {
            // DataContext
            _db = new DataContextFactory().CreateDataContext();

            _capitalBuildupRateRepository = new GenericRepository<LoanCapitalBuildupRate>(_db);
            _collectionFeeRateRepository = new GenericRepository<LoanCollectionFeeRate>(_db);
            _guaranteeFundRateRepository = new GenericRepository<LoanGuaranteeFundRate>(_db);
            _interestRatesRepository = new GenericRepository<LoanInterestRate>(_db);
            _serviceFeeRateRepository = new GenericRepository<LoanServiceFeeRate>(_db);

            // views
            _capitalBuildupRateView = (ILoanCapitalBuildupRateView)view;
            _collectionFeeRateView = (ILoanCollectionFeeRateView)view;
            _guaranteeFundRateView = (ILoanGuaranteeFundRateView)view;
            _interestRateView = (ILoanInterestRateView)view;
            _serviceFeeRateView = (ILoanServiceFeeRateView)view;
        }

        public void Populate()
        {
            string state = string.Empty;
            try
            {
                state = "capital buildup rates";
                IList<LoanCapitalBuildupRate> capitalBuildupRates = _capitalBuildupRateRepository.GetAll().ToList();
                _deductedCapitalBuildupRateModel = capitalBuildupRates
                    .Where(r => r.LoanDeductionTypeID == LoanDeductionTypeCodes.Deducted)
                    .FirstOrDefault();

                _addOnCapitalBuildupRateModel = capitalBuildupRates
                    .Where(r => r.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn)
                    .FirstOrDefault();

                if (_deductedCapitalBuildupRateModel == null)
                {
                    _deductedCapitalBuildupRateModel = _capitalBuildupRateRepository.CreateEntity();
                    _deductedCapitalBuildupRateModel.LoanDeductionTypeID = LoanDeductionTypeCodes.Deducted;
                }

                if (_addOnCapitalBuildupRateModel == null)
                {
                    _addOnCapitalBuildupRateModel = _capitalBuildupRateRepository.CreateEntity();
                    _addOnCapitalBuildupRateModel.LoanDeductionTypeID = LoanDeductionTypeCodes.AddOn;
                }
                
                _capitalBuildupRateView.DeductedBelowFiveThousand = _deductedCapitalBuildupRateModel.BelowFiveThousand;
                _capitalBuildupRateView.DeductedFiveThousandAndAbove = _deductedCapitalBuildupRateModel.FiveThousandAndAbove;
                _capitalBuildupRateView.AddOnBelowFiveThousand = _addOnCapitalBuildupRateModel.BelowFiveThousand;
                _capitalBuildupRateView.AddOnFiveThousandAndAbove = _addOnCapitalBuildupRateModel.FiveThousandAndAbove;

                _capitalBuildupRateView.DeductedShareBelowFifteenThousand = _deductedCapitalBuildupRateModel.ShareBelowFifteenThousand;
                _capitalBuildupRateView.DeductedShareFifteenThousandAndAbove = _deductedCapitalBuildupRateModel.ShareFifteenThousandAndAbove;
                _capitalBuildupRateView.AddOnShareBelowFifteenThousand = _addOnCapitalBuildupRateModel.ShareBelowFifteenThousand;
                _capitalBuildupRateView.AddOnShareFifteenThousandAndAbove = _addOnCapitalBuildupRateModel.ShareFifteenThousandAndAbove;

                state = "collection fee rates";
                IList<LoanCollectionFeeRate> collectionFeeRates = _collectionFeeRateRepository.GetAll().ToList();
                _deductedCollectionFeeRateModel = collectionFeeRates
                    .Where(r => r.LoanDeductionTypeID == LoanDeductionTypeCodes.Deducted)
                    .FirstOrDefault();

                _addOnCollectionFeeRateModel = collectionFeeRates
                    .Where(r => r.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn)
                    .FirstOrDefault();

                if (_deductedCollectionFeeRateModel == null)
                {
                    _deductedCollectionFeeRateModel = _collectionFeeRateRepository.CreateEntity();
                    _deductedCollectionFeeRateModel.LoanDeductionTypeID = LoanDeductionTypeCodes.Deducted;
                }

                if (_addOnCollectionFeeRateModel == null)
                {
                    _addOnCollectionFeeRateModel = _collectionFeeRateRepository.CreateEntity();
                    _addOnCollectionFeeRateModel.LoanDeductionTypeID = LoanDeductionTypeCodes.AddOn;
                }

                _collectionFeeRateView.DeductedOneToFiveMonths = _deductedCollectionFeeRateModel.OneToFiveMonths;
                _collectionFeeRateView.DeductedSixToTenMonths = _deductedCollectionFeeRateModel.SixToTenMonths;
                _collectionFeeRateView.AddOnOneToFiveMonths = _addOnCollectionFeeRateModel.OneToFiveMonths;
                _collectionFeeRateView.AddOnSixToTenMonths = _addOnCollectionFeeRateModel.SixToTenMonths;


                state = "guarantee fund rates";
                IList<LoanGuaranteeFundRate> guaranteeFundRates = _guaranteeFundRateRepository.GetAll().ToList();
                _deductedGuaranteeFundRateModel = guaranteeFundRates
                    .Where(r => r.LoanDeductionTypeID == LoanDeductionTypeCodes.Deducted)
                    .FirstOrDefault();

                _addOnGuaranteeFundRateModel = guaranteeFundRates
                    .Where(r => r.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn)
                    .FirstOrDefault();

                if (_deductedGuaranteeFundRateModel == null)
                {
                    _deductedGuaranteeFundRateModel = _guaranteeFundRateRepository.CreateEntity();
                    _deductedGuaranteeFundRateModel.LoanDeductionTypeID = LoanDeductionTypeCodes.Deducted;
                }

                if (_addOnGuaranteeFundRateModel == null)
                {
                    _addOnGuaranteeFundRateModel = _guaranteeFundRateRepository.CreateEntity();
                    _addOnGuaranteeFundRateModel.LoanDeductionTypeID = LoanDeductionTypeCodes.AddOn;
                }

                _guaranteeFundRateView.DeductedOneToFiveMonths = _deductedGuaranteeFundRateModel.OneToFiveMonths;
                _guaranteeFundRateView.DeductedSixToTenMonths = _deductedGuaranteeFundRateModel.SixToTenMonths;
                _guaranteeFundRateView.AddOnOneToFiveMonths = _addOnGuaranteeFundRateModel.OneToFiveMonths;
                _guaranteeFundRateView.AddOnSixToTenMonths = _addOnGuaranteeFundRateModel.SixToTenMonths;


                state = "interest rates.";
                IList<LoanInterestRate> interestRates = _interestRatesRepository.GetAll().ToList();
                var deductedInterestRates = interestRates
                    .Where(r => r.LoanDeductionTypeID == LoanDeductionTypeCodes.Deducted)
                    .ToList();

                _deductedInterestRatesAdapter = new LoanInterestRateAdapter(deductedInterestRates);

                var addOnInterestRates = interestRates
                    .Where(r => r.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn)
                    .ToList();

                _addOnInterestRatesAdapter = new LoanInterestRateAdapter(addOnInterestRates);

                _interestRateView.DeductedDaily = _deductedInterestRatesAdapter.Daily;
                _interestRateView.DeductedWeekly = _deductedInterestRatesAdapter.Weekly;
                _interestRateView.DeductedSemiMonthly = _deductedInterestRatesAdapter.SemiMonthly;
                _interestRateView.DeductedMonthly = _deductedInterestRatesAdapter.Monthly;

                _interestRateView.AddOnDaily = _addOnInterestRatesAdapter.Daily;
                _interestRateView.AddOnWeekly = _addOnInterestRatesAdapter.Weekly;
                _interestRateView.AddOnSemiMonthly = _addOnInterestRatesAdapter.SemiMonthly;
                _interestRateView.AddOnMonthly = _addOnInterestRatesAdapter.Monthly;


                state = "service fee rates.";
                IList<LoanServiceFeeRate> serviceFeeRates = _serviceFeeRateRepository.GetAll().ToList();
                _deductedServiceFeeRateModel = serviceFeeRates
                    .Where(r => r.LoanDeductionTypeID == LoanDeductionTypeCodes.Deducted)
                    .FirstOrDefault();

                _addOnServiceFeeRateModel = serviceFeeRates
                    .Where(r => r.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn)
                    .FirstOrDefault();

                if (_deductedServiceFeeRateModel == null)
                {
                    _deductedServiceFeeRateModel = _serviceFeeRateRepository.CreateEntity();
                    _deductedServiceFeeRateModel.LoanDeductionTypeID = LoanDeductionTypeCodes.Deducted;
                }

                if (_addOnServiceFeeRateModel == null)
                {
                    _addOnServiceFeeRateModel = _serviceFeeRateRepository.CreateEntity();
                    _addOnServiceFeeRateModel.LoanDeductionTypeID = LoanDeductionTypeCodes.AddOn;
                } 
                
                _serviceFeeRateView.DeductedOneToFiveMonths = _deductedServiceFeeRateModel.OneToFiveMonths;
                _serviceFeeRateView.DeductedSixToTenMonths = _deductedServiceFeeRateModel.SixToTenMonths;
                _serviceFeeRateView.AddOnOneToFiveMonths = _addOnServiceFeeRateModel.OneToFiveMonths;
                _serviceFeeRateView.AddOnSixToTenMonths = _addOnServiceFeeRateModel.SixToTenMonths;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(string.Format("Error loading {0}.", state), ex);
            }
        }

        public bool Update()
        {
            bool result = false;
            try
            {
                _deductedCapitalBuildupRateModel.BelowFiveThousand = _capitalBuildupRateView.DeductedBelowFiveThousand;
                _deductedCapitalBuildupRateModel.FiveThousandAndAbove = _capitalBuildupRateView.DeductedFiveThousandAndAbove;
                _addOnCapitalBuildupRateModel.BelowFiveThousand = _capitalBuildupRateView.AddOnBelowFiveThousand;
                _addOnCapitalBuildupRateModel.FiveThousandAndAbove = _capitalBuildupRateView.AddOnFiveThousandAndAbove;

                _deductedCapitalBuildupRateModel.ShareBelowFifteenThousand = _capitalBuildupRateView.DeductedShareBelowFifteenThousand;
                _deductedCapitalBuildupRateModel.ShareFifteenThousandAndAbove = _capitalBuildupRateView.DeductedShareFifteenThousandAndAbove;
                _addOnCapitalBuildupRateModel.ShareBelowFifteenThousand = _capitalBuildupRateView.AddOnShareBelowFifteenThousand;
                _addOnCapitalBuildupRateModel.ShareFifteenThousandAndAbove = _capitalBuildupRateView.AddOnShareFifteenThousandAndAbove;

                _deductedCollectionFeeRateModel.OneToFiveMonths = _collectionFeeRateView.DeductedOneToFiveMonths;
                _deductedCollectionFeeRateModel.SixToTenMonths = _collectionFeeRateView.DeductedSixToTenMonths;
                _addOnCollectionFeeRateModel.OneToFiveMonths = _collectionFeeRateView.AddOnOneToFiveMonths;
                _addOnCollectionFeeRateModel.SixToTenMonths = _collectionFeeRateView.AddOnSixToTenMonths;

                _deductedGuaranteeFundRateModel.OneToFiveMonths = _guaranteeFundRateView.DeductedOneToFiveMonths;
                _deductedGuaranteeFundRateModel.SixToTenMonths = _guaranteeFundRateView.DeductedSixToTenMonths;
                _addOnGuaranteeFundRateModel.OneToFiveMonths = _guaranteeFundRateView.AddOnOneToFiveMonths;
                _addOnGuaranteeFundRateModel.SixToTenMonths = _guaranteeFundRateView.AddOnSixToTenMonths;

                _deductedInterestRatesAdapter.Daily = _interestRateView.DeductedDaily;
                _deductedInterestRatesAdapter.Weekly = _interestRateView.DeductedWeekly;
                _deductedInterestRatesAdapter.SemiMonthly = _interestRateView.DeductedSemiMonthly;
                _deductedInterestRatesAdapter.Monthly = _interestRateView.DeductedMonthly;

                _addOnInterestRatesAdapter.Daily = _interestRateView.AddOnDaily;
                _addOnInterestRatesAdapter.Weekly = _interestRateView.AddOnWeekly;
                _addOnInterestRatesAdapter.SemiMonthly = _interestRateView.AddOnSemiMonthly;
                _addOnInterestRatesAdapter.Monthly = _interestRateView.AddOnMonthly;

                _addOnServiceFeeRateModel.OneToFiveMonths = _serviceFeeRateView.AddOnOneToFiveMonths;
                _addOnServiceFeeRateModel.SixToTenMonths = _serviceFeeRateView.AddOnSixToTenMonths;
                _deductedServiceFeeRateModel.OneToFiveMonths = _serviceFeeRateView.DeductedOneToFiveMonths;
                _deductedServiceFeeRateModel.SixToTenMonths = _serviceFeeRateView.DeductedSixToTenMonths;

                _db.SubmitChanges();
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