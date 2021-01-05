using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Lookups.AccountStatuses;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare
{
    public class DividendDistributionPresenter : PresenterTemplate
    {
        private DataContext _db;
        private YearlyDividend _yearlyDividendEntity;
        private IDividendDistributionView _view;
        private IPostingView _postingView;

        #region Routine Helpers

        private IList<DividendDistributionItem> GetDividendDistribution()
        {
            var loadOptions = new DataLoadOptions();
            loadOptions.LoadWith<YearlyDividend>(x => x.DividendComputations);
            loadOptions.LoadWith<DividendComputation>(x => x.DividendShareItems);

            // attach load options to data context
            _db = new DataContextFactory().CreateDataContext();
            _db.LoadOptions = loadOptions;

            _yearlyDividendEntity = _db.GetTable<YearlyDividend>()
                .Single(yd => yd.Year == _view.Year);

            // flatten result for reports reflection
            return FlattenYearlyDividend(_yearlyDividendEntity);
        }

        private IList<DividendDistributionItem> GenerateDividendDistribution()
        {
            // initialize load options
            var loadOptions = new DataLoadOptions();
            loadOptions.LoadWith<Member>(x => x.CapitalShare);
            loadOptions.LoadWith<Member>(x => x.AccountStatus);
            loadOptions.LoadWith<CooperativeSystem.Service.Models.CapitalShare>(x => x.CapitalShareReceipts);
            loadOptions.LoadWith<CooperativeSystem.Service.Models.CapitalShare>(x => x.CapitalShareAdjustments);
            loadOptions.LoadWith<CooperativeSystem.Service.Models.CapitalShare>(x => x.CapitalShareBuildups);
            loadOptions.LoadWith<CooperativeSystem.Service.Models.CapitalShare>(x => x.CapitalShareDisbursements);
            loadOptions.LoadWith<CooperativeSystem.Service.Models.CapitalShare>(x => x.CapitalSharePatronageRefundAdjustments);
            loadOptions.LoadWith<CooperativeSystem.Service.Models.CapitalShare>(x => x.CapitalShareDividendAdjustments);
            loadOptions.LoadWith<CapitalShareReceipt>(x => x.CashReceipt);
            loadOptions.LoadWith<CapitalShareAdjustment>(x => x.Adjustment);
            loadOptions.LoadWith<CapitalShareBuildup>(x => x.CashDisbursement);
            loadOptions.LoadWith<CapitalShareDisbursement>(x => x.CashDisbursement);
            loadOptions.LoadWith<CapitalSharePatronageRefundAdjustment>(x => x.Adjustment);
            loadOptions.LoadWith<CapitalShareDividendAdjustment>(x => x.Adjustment);

            // attach load options to data context
            _db = new DataContextFactory().CreateDataContext();
            _db.LoadOptions = loadOptions;

            // get refund ration
            var refundRatio = _db.GetTable<DividendPatronageRatio>().Single();

            // get capital share minimum amount
            var minimum = _db.GetTable<CapitalShareMinimumAmount>().Single();

            // get net surplus
            var netSurplus = _db.GetTable<NetSurplus>()
                .Where(x => x.Year == _view.Year)
                .FirstOrDefault();

            // get all members entitled for dividend
            var members = _db.GetTable<Member>()
                .Where(x => x.WithdrawalDate.HasValue
                    ? x.WithdrawalDate.Value.Year > _view.Year
                    : true
                )
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ThenBy(x => x.MiddleName)
                .ToList();

            // create yearly dividend
            _yearlyDividendEntity = new YearlyDividend()
            {
                Year = _view.Year,
                DividendRatio = refundRatio.DividendRatio,
                TotalDividendForDistribution = (refundRatio.DividendRatio / 100M) * netSurplus.Amount
            };

            // create dividend computatation for each members
            foreach (var member in members)
                _yearlyDividendEntity.AddDividendComputation(member, minimum.Amount);

            // distribute dividend to each member
            _yearlyDividendEntity.DistributeDividends();

            // flatten result for reports reflection
            return FlattenYearlyDividend(_yearlyDividendEntity);
        }

        /// <summary>
        /// Flatten result for reports reflection
        /// </summary>
        /// <param name="yearlyDividend"></param>
        /// <returns></returns>
        private IList<DividendDistributionItem> FlattenYearlyDividend(YearlyDividend yearlyDividend)
        {
            var services = _db.GetTable<Models.Service>();

            var items = yearlyDividend.DividendComputations
                .SelectMany(x => x.DividendShareItems)
                .Select(x => new DividendDistributionItem()
                {
                    Member = x.DividendComputation.Member.ToString(),
                    DepositoryService = services.Single(s => s.ServiceID == x.DividendComputation.DepositoryServiceID).ServiceName,
                    TransactionType = x.TransactionType,
                    Date = x.Date,
                    Amount = x.Amount,
                    Balance = x.Balance,
                    MoneyValue = x.MoneyValue,
                    NumberOfDaysUnchanged = x.NumberOfDaysUnchanged,
                    AverageShare = x.DividendComputation.AverageShare,
                    Dividend = x.DividendComputation.Dividend
                })
                .ToList();

            return items;
        }

        private IList<DividendDistributionSummaryItem> FlattenYearlyDividendSummary(YearlyDividend yearlyDividend)
        {
            var services = _db.GetTable<Models.Service>();

            var items = yearlyDividend.DividendComputations
                .Select(x => new DividendDistributionSummaryItem()
                {
                    Member = x.Member.LastName + ", " + x.Member.FirstName,
                    Dipository = x.Service != null
                        ? x.Service.ServiceName
                        : string.Empty, // services.Single(o => o.ServiceID == x.DepositoryServiceID).ServiceName,
                    DistributionRemarks = x.Creditable == null || x.Creditable.Value
                        ? "For Distribution"
                        : "For Miscelaneous Income (Delinquent Accounts)",
                    Amount = x.Dividend,

                })
                .ToList();

            return items;
        }

        private void PostingView_Posting(object sender, EventArgs e)
        {
            var voucher = _postingView.VoucherNumber;
            Post(voucher);
        }

        #endregion

        public DividendDistributionPresenter(IDividendDistributionView view, IPostingView postingView)
        {
            _view = view;
            _view.AllowSummary = false;
            _view.AllowSave = false;
            _view.AllowPost = false;

            _postingView = postingView;
            _postingView.Posting += new EventHandler(PostingView_Posting);
        }

        public bool Generate()
        {
            try
            {
                _db = new DataContextFactory().CreateDataContext();

                var hasNetSurplus = _db.GetTable<NetSurplus>()
                    .Any(x => x.Year == _view.Year);

                if (!hasNetSurplus)
                {
                    RaiseErrorEvent(string.Format("Net surplus for year {0} has not been submitted yet. Please input net surplus first.", _view.Year.ToString()));
                    return false;
                }

                var isGenerated = _db.GetTable<YearlyDividend>()
                    .Any(x => x.Year == _view.Year);

                var items = (IList<DividendDistributionItem>)null;
                if (isGenerated)
                {
                    items = GetDividendDistribution();
                    _view.AllowSave = false;
                }
                else
                {
                    items = GenerateDividendDistribution();
                    _view.AllowSave = true;
                }

                // reflect to view
                _view.AllowSummary = true;
                _view.AllowPost = !_yearlyDividendEntity.Posted;
                _view.TotalDividendForDistribution = _yearlyDividendEntity.TotalDividendForDistribution;
                _view.TotalDividend = _yearlyDividendEntity.DividendComputations.Sum(x => x.Dividend);
                _view.TotalAverageShare = _yearlyDividendEntity.DividendComputations.Sum(x => x.AverageShare);

                _view.PopulateReports(items);
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
                if (_yearlyDividendEntity == null || _db == null)
                {
                    RaiseErrorEvent("You have not distributed dividend. Please distribute dividend first.");
                    return false;
                }

                _db.GetTable<YearlyDividend>().InsertOnSubmit(_yearlyDividendEntity);
                _db.SubmitChanges();
                _view.AllowSave = false;
                RaiseSusccessEvent("Dividend has been saved.");
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool Post(string voucherNumber)
        {
            try
            {
                if (_yearlyDividendEntity == null || _db == null)
                {
                    RaiseErrorEvent("You have not distributed dividend. Please distribute dividend first.");
                    return false;
                }

                _yearlyDividendEntity.Posted = true;

                var adjustment = new Adjustment()
                {
                    AdjustmentJournalVoucher = voucherNumber,
                    UserID = _view.UserID,
                    AdjustmentDate = DateTime.Now
                };

                var _services = _db.GetTable<Models.Service>();
                var miscelaneousAdjustment = (MiscellaneousIncomeAdjustment)null;

                // Post dividend
                foreach (var dividendComputation in _yearlyDividendEntity.DividendComputations)
                {
                    var member = dividendComputation.Member;
                    var amount = dividendComputation.Dividend;
                    var serviceID = dividendComputation.DepositoryServiceID;

                    // the dividend computation is creditable to member
                    if (dividendComputation.Creditable.HasValue && dividendComputation.Creditable.Value)
                    {
                        switch (serviceID)
                        {
                            case ServiceCodes.ApplianceLoan:
                            case ServiceCodes.EasyLoan:
                            case ServiceCodes.EmergencyLoan:
                            case ServiceCodes.EquityLoan:
                            case ServiceCodes.PensionLoan:
                            case ServiceCodes.RegularLoan:
                                var loan = member.Loans
                                    .Where(x =>
                                        x.Settled == false &&
                                        x.LoanServiceID == serviceID)
                                    .FirstOrDefault();

                                if (loan == null)
                                {
                                    throw new Exception(string.Format("{0} does not have unsettled {1}. Please change his/her dividend depository.",
                                        member.ToString(), _services.Single(x => x.ServiceID == serviceID)));
                                }

                                loan.AddLoanDividendAdjustment(new LoanDividendAdjustment()
                                {
                                    Amount = amount,
                                    Adjustment = adjustment
                                });
                                break;
                            case ServiceCodes.CapitalShare:
                                var capitalShare = member.CapitalShare;
                                capitalShare.AddCapitalShareDividendAdjustment(new CapitalShareDividendAdjustment()
                                {
                                    Amount = amount,
                                    Adjustment = adjustment
                                });
                                break;
                            case ServiceCodes.SavingsDeposit:
                                var savingsDeposit = member.SavingsDeposit;
                                savingsDeposit.AddSavingsDepositDividendAdjustment(new SavingsDepositDividendAdjustment()
                                {
                                    Amount = amount,
                                    Adjustment = adjustment
                                });
                                break;
                            default:
                                throw new Exception(string.Format("{0} is assigned with invalid depository {1}. Please change his/her dividend depository.",
                                    member.ToString(), _services.Single(x => x.ServiceID == serviceID)));
                            //break;
                        }
                    }
                    // the dividend computation is not creditable to user, save to miscellaneous income instead
                    else
                    {
                        if (miscelaneousAdjustment == null)
                        {
                            miscelaneousAdjustment = new MiscellaneousIncomeAdjustment();
                            miscelaneousAdjustment.Adjustment = adjustment;

                            _db.GetTable<MiscellaneousIncomeAdjustment>().InsertOnSubmit(miscelaneousAdjustment);
                        }

                        miscelaneousAdjustment.Amount += amount;
                    }
                }

                _db.SubmitChanges();
                _view.AllowSave = false;
                _view.AllowPost = false;
                RaiseSusccessEvent("Dividend has been posted.");
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                Generate(); // reset
                return false;
            }
        }

        public IList<DividendDistributionSummaryItem> GetSummary()
        {
            if (_yearlyDividendEntity == null)
            {
                RaiseErrorEvent(string.Format("No computation for yearly dividend yet."));
                return null;
            }

            return FlattenYearlyDividendSummary(_yearlyDividendEntity);
        }
    }
}
