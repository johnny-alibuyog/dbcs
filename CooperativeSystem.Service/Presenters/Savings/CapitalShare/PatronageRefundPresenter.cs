using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Lookups.AccountStatuses;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare
{
    public class PatronageRefundPresenter : PresenterTemplate
    {
        private DataContext _db;
        private YearlyPatronage _yearlyPatronageEntity;
        private IPatronageRefundView _view;
        private IPostingView _postingView;

        #region Routine Helpers

        private IList<PatronageRefundItem> GetPatronageRefund()
        {
            var loadOptions = new DataLoadOptions();
            loadOptions.LoadWith<YearlyPatronage>(x => x.PatronageComputations);
            loadOptions.LoadWith<PatronageComputation>(x => x.PatronageItems);

            // attach load options to data context
            _db = new DataContextFactory().CreateDataContext();
            _db.LoadOptions = loadOptions;

            _yearlyPatronageEntity = _db.GetTable<YearlyPatronage>()
                .Single(yd => yd.Year == _view.Year);

            // flatten result for reports reflection
            return FlattenPatronageRefund(_yearlyPatronageEntity);
        }

        private IList<PatronageRefundItem> GeneratePatronageRefund()
        {
            // initialize load options
            var loadOptions = new DataLoadOptions();
            loadOptions.LoadWith<Member>(m => m.Loans);

            // attach load options to data context
            _db = new DataContextFactory().CreateDataContext();
            _db.LoadOptions = loadOptions;

            // get refund ration
            var refundRatio = _db.GetTable<DividendPatronageRatio>().Single();

            // get net surplus
            var netSurplus = _db.GetTable<NetSurplus>()
                .Where(ns => ns.Year == _view.Year)
                .FirstOrDefault();

            // patronage refundable loans
            var refundableLoans = new List<string>()
            { 
                ServiceCodes.RegularLoan, 
                ServiceCodes.EquityLoan 
            };

            //// get all members entitled for patronage refund
            var members = _db.GetTable<Member>()
                .Where(x =>
                    x.WithdrawalDate.HasValue
                        ? x.WithdrawalDate.Value.Year > _view.Year
                        : true
                )
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ThenBy(x => x.MiddleName);

            // create yearly dividend
            _yearlyPatronageEntity = new YearlyPatronage()
            {
                Year = _view.Year,
                PatronageRatio = refundRatio.PatronageRatio,
                TotalPatronageForRefund = (refundRatio.PatronageRatio / 100M) * netSurplus.Amount
            };

            // create patronage computation for each members
            foreach (var member in members)
            {
                var patronageRefundableLoans = member.Loans
                    .Where(x =>
                        x.Settled &&
                        x.SettlementDate != null &&
                        x.SettlementDate <= x.DueDate &&
                        x.SettlementDate.Value.Year == _view.Year &&
                        (refundableLoans.Contains(x.LoanServiceID))
                    );

                if (patronageRefundableLoans != null && patronageRefundableLoans.Count() > 0)
                    _yearlyPatronageEntity.AddPatronageComputation(member, patronageRefundableLoans);
            }

            // distribute patronageRefund to each member
            _yearlyPatronageEntity.DistributePatronageRefunds();

            // flatten result for reports reflection
            return FlattenPatronageRefund(_yearlyPatronageEntity);
        }

        /// <summary>
        /// Flatten result for reports reflection
        /// </summary>
        /// <param name="yearlyPatronage"></param>
        /// <returns></returns>
        private IList<PatronageRefundItem> FlattenPatronageRefund(YearlyPatronage yearlyPatronage)
        {
            var services = _db.GetTable<Models.Service>();

            var items = yearlyPatronage.PatronageComputations
                .SelectMany(pc => pc.PatronageItems)
                .Select(pi => new PatronageRefundItem()
                {
                    Member = pi.PatronageComputation.Member.ToString(),
                    Service = services.Single(x => x.ServiceID == pi.LoanServiceID).ServiceName,
                    Date = pi.Date,
                    Amount = pi.Amount,
                    Balance = pi.Balance,
                    MoneyValue = pi.MoneyValue,
                    NumberOfDaysUnchanged = pi.NumberOfDaysUnchanged,
                    AveragePatronage = pi.PatronageComputation.AveragePatronage,
                    PatronageRefund = pi.PatronageComputation.PatronageRefund
                })
                .ToList();

            return items;
        }

        private IList<PatronageRefundSummaryItem> FlattenPatronageRefundSummary(YearlyPatronage yearlyPatronage)
        {
            var items = yearlyPatronage.PatronageComputations
                .Select(x => new PatronageRefundSummaryItem()
                {
                    Member = x.Member.LastName + ", " + x.Member.FirstName,
                    Amount = x.PatronageRefund
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

        public PatronageRefundPresenter(IPatronageRefundView view, IPostingView postingView)
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
                    .Any(ns => ns.Year == _view.Year);

                if (!hasNetSurplus)
                {
                    RaiseErrorEvent(string.Format("Net surplus for year {0} has not been submitted yet. Please input net surplus first.", _view.Year.ToString()));
                    return false;
                }

                var isGenerated = _db.GetTable<YearlyPatronage>()
                    .Any(yd => yd.Year == _view.Year);

                IList<PatronageRefundItem> items;
                if (isGenerated)
                {
                    items = GetPatronageRefund();
                    _view.AllowSave = false;
                }
                else
                {
                    items = GeneratePatronageRefund();
                    _view.AllowSave = true;
                }

                // reflect to view
                _view.AllowSummary = true;
                _view.AllowPost = !_yearlyPatronageEntity.Posted;
                _view.TotalPatronageForRefund = _yearlyPatronageEntity.TotalPatronageForRefund;
                _view.TotalPatronage = _yearlyPatronageEntity.PatronageComputations.Sum(x => x.PatronageRefund);
                _view.TotalAveragePatronage = _yearlyPatronageEntity.PatronageComputations.Sum(x => x.AveragePatronage);
                
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
                if (_yearlyPatronageEntity == null || _db == null)
                {
                    RaiseErrorEvent("You have not generated patronage refund. Please compute first.");
                    return false;
                }

                _db.GetTable<YearlyPatronage>().InsertOnSubmit(_yearlyPatronageEntity);
                _db.SubmitChanges();
                _view.AllowSave = false;
                RaiseSusccessEvent("Patronage refund has been saved.");
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
                if (_yearlyPatronageEntity == null || _db == null)
                {
                    RaiseErrorEvent("You have not generated patronage refund. Please compute first.");
                    return false;
                }

                var adjustment = new Adjustment()
                {
                    AdjustmentJournalVoucher = voucherNumber,
                    UserID = _view.UserID,
                    AdjustmentDate = DateTime.Now
                };

                // Post patronage
                foreach (var patronageComputation in _yearlyPatronageEntity.PatronageComputations)
                {
                    var capitalShare = patronageComputation.Member.CapitalShare;
                    var amount = patronageComputation.PatronageRefund;
                    capitalShare.AddCapitalSharePatronageRefundAdjustment(new CapitalSharePatronageRefundAdjustment()
                    {
                        Adjustment = adjustment,
                        Amount = amount
                    });
                }

                _db.SubmitChanges();
                _view.AllowSave = false;
                _view.AllowPost = false;
                RaiseSusccessEvent("Patronage refund has been posted.");
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                Generate(); // reset
                return false;
            }
        }

        public IList<PatronageRefundSummaryItem> GetSummary()
        {
            if (_yearlyPatronageEntity == null)
            {
                RaiseErrorEvent(string.Format("No computation for patronage yet."));
                return null;
            }

            return FlattenPatronageRefundSummary(_yearlyPatronageEntity);
        }
    }
}
