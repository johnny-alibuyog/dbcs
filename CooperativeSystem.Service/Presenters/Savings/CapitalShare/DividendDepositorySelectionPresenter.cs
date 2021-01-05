using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Lookups.ServiceCategories;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare
{
    public class DividendDepositorySelectionPresenter : PresenterTemplate
    {
        private DataContext _db;
        private IRepository<YearlyDividend> _repository;
        private YearlyDividend _yearlyDividendEntity;
        private IDividendDepositorySelectionView _view;

        private IList<CooperativeSystem.Service.Models.Service> _services;

        public DividendDepositorySelectionPresenter(IDividendDepositorySelectionView view)
        {
            _view = view;

            var loadOptions = new DataLoadOptions();
            loadOptions.LoadWith<YearlyDividend>(yd => yd.DividendComputations);
            loadOptions.LoadWith<DividendComputation>(dc => dc.Member);

            _db = new DataContextFactory().CreateDataContext();
            _db.LoadOptions = loadOptions;

            _repository = new GenericRepository<YearlyDividend>(_db);

            var services = new string[] 
            { 
                ServiceCodes.ApplianceLoan,
                ServiceCodes.EasyLoan,
                ServiceCodes.EmergencyLoan,
                ServiceCodes.EquityLoan,
                ServiceCodes.PensionLoan,
                ServiceCodes.RegularLoan,
                ServiceCodes.CapitalShare,
                ServiceCodes.SavingsDeposit 
            };

            _services = _db.GetTable<CooperativeSystem.Service.Models.Service>()
                .Where(s => services.Contains(s.ServiceID))
                .ToList();
        }

        public bool Populate()
        {
            try
            {
                _yearlyDividendEntity = _repository.GetEntity(yd => yd.Year == _view.Year);

                if (_yearlyDividendEntity == null ||
                    _yearlyDividendEntity.DividendComputations == null ||
                    _yearlyDividendEntity.DividendComputations.Count < 1)
                {
                    RaiseErrorEvent(string.Format("Dividend for the year {0} is not distributed yet. You must distribute dividend first before assigning depository for members.", _view.Year.ToString()));
                    _view.AllowSave = false;
                    return false;
                }

                var itemIDToSelect = _yearlyDividendEntity.DividendComputations
                    .First().DividendComputationID;

                SelectItem(itemIDToSelect);

                _view.DividendComputations = _yearlyDividendEntity.DividendComputations
                    .OrderBy(x => x.Member.LastName)
                    .ThenBy(x => x.Member.FirstName)
                    .ThenBy(x => x.Member.MiddleName)
                    .ToList();

                _view.AllowSave = true;


                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                _view.AllowSave = false;
                return false;
            }
        }

        public bool ChangeDepository()
        {
            try
            {
                var dividendComputation = _yearlyDividendEntity.DividendComputations
                    .Where(dc => dc.Member.MemberID == _view.MemberID)
                    .FirstOrDefault();

                var depositoryService = _services
                    .Single(s => s.ServiceID == _view.DepositoryServiceID);

                if (dividendComputation.DepositoryServiceID == depositoryService.ServiceID)
                    return true;

                if (_view.DepositoryServiceID == ServiceCodes.ApplianceLoan ||
                    _view.DepositoryServiceID == ServiceCodes.EasyLoan ||
                    _view.DepositoryServiceID == ServiceCodes.EmergencyLoan ||
                    _view.DepositoryServiceID == ServiceCodes.EquityLoan ||
                    _view.DepositoryServiceID == ServiceCodes.PensionLoan ||
                    _view.DepositoryServiceID == ServiceCodes.RegularLoan ||
                    _view.DepositoryServiceID == ServiceCodes.DTILoan ||
                    _view.DepositoryServiceID == ServiceCodes.MEDPLoan)
                {
                    var hasLoan = dividendComputation.Member.Loans
                        .Any(l =>
                            l.LoanServiceID == _view.DepositoryServiceID &&
                            l.Settled == false);

                    if (!hasLoan)
                    {
                        RaiseErrorEvent(string.Format("Member {0} does not have a current loan in {1}.",
                            _view.Member, _services.Single(s => s.ServiceID == _view.DepositoryServiceID)));
                        return false;
                    }
                }
                else
                // if (_view.DepositoryServiceID == ServiceCodes.CapitalShare || 
                //_view.DepositoryServiceID == ServiceCodes.SavingsDeposit ||
                //_view.DepositoryServiceID == ServiceCodes.TimeDeposit)
                {
                    var isServiceAvailed = dividendComputation.Member.AvailedServices
                        .Any(s => s.ServiceID == _view.DepositoryServiceID);

                    if (!isServiceAvailed)
                    {
                        RaiseErrorEvent(string.Format("Member {0} has not availed service {1}.",
                            _view.Member, _services.Single(s => s.ServiceID == _view.DepositoryServiceID)));
                        return false;
                    }
                }

                // allow change of dividend depository
                dividendComputation.Service = depositoryService;
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool SelectItem(long dividendComputationID)
        {
            try
            {
                var dividendComputation = _yearlyDividendEntity.DividendComputations
                    .Single(dc => dc.DividendComputationID == dividendComputationID);

                var availedServiceIDs = dividendComputation.Member.AvailedServices
                    .Select(s => s.ServiceID);

                // populate pulldown based on member's availed services
                _view.PopulateDepositoryServicePulldown(_services
                    .Where(s => availedServiceIDs.Contains(s.ServiceID))
                    .ToList());

                _view.MemberID = dividendComputation.MemberID;
                _view.Member = dividendComputation.Member.ToString();
                _view.DepositoryServiceID = dividendComputation.DepositoryServiceID;

                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool Save()
        {
            try
            {
                _repository.SaveAll();
                RaiseSusccessEvent("Changes has been saved.");
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
