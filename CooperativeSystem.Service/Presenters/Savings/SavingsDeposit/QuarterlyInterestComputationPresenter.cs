using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Utilities.SequenceGenerators;

namespace CooperativeSystem.Service.Presenters.Savings.SavingsDeposit
{
    public class QuarterlyInterestComputationPresenter : PresenterTemplate
    {
        private DataContext _db;
        private QuarterlyInterest _quarterlyInterestEntity;
        private IQuarterlyInterestComputationView _view;
        private IPostingView _postingView;

        #region Routine Helpers

        private IList<QuarterlyInterestComputationItem> GetQuarterlyInterests()
        {
            var loadOptions = new DataLoadOptions();
            loadOptions.LoadWith<QuarterlyInterest>(qi => qi.QuarterlyInterestComputations);
            loadOptions.LoadWith<QuarterlyInterestComputation>(qic => qic.AverageMonthlyBalances);

            // attach load options to data context
            _db = new DataContextFactory().CreateDataContext();
            _db.LoadOptions = loadOptions;

            _quarterlyInterestEntity = _db.GetTable<QuarterlyInterest>()
                .Single(qi => 
                    qi.Year == _view.Year &&
                    qi.QuarterID == _view.QuarterID);

            // flatten result for reports reflection
            return FlattenQuarterlyInterestComputation(_quarterlyInterestEntity);
        }

        private IList<QuarterlyInterestComputationItem> GenerateQuarterlyInterests()
        {
            // initialize load options
            var loadOptions = new DataLoadOptions();
            loadOptions.LoadWith<Member>(m => m.SavingsDeposit);
            loadOptions.LoadWith<Models.SavingsDeposit>(sd => sd.SavingsDepositReceipts);
            loadOptions.LoadWith<Models.SavingsDeposit>(sd => sd.SavingsDepositAdjustments);
            loadOptions.LoadWith<Models.SavingsDeposit>(sd => sd.SavingsDepositDisbursements);
            loadOptions.LoadWith<Models.SavingsDeposit>(sd => sd.SavingsDepositDividendAdjustments);
            loadOptions.LoadWith<Models.SavingsDeposit>(sd => sd.SavingsDepositInterestAdjustments);
            loadOptions.LoadWith<SavingsDepositReceipt>(sdr => sdr.CashReceipt);
            loadOptions.LoadWith<SavingsDepositAdjustment>(sdia => sdia.Adjustment);
            loadOptions.LoadWith<SavingsDepositDisbursement>(sdd => sdd.CashDisbursement);
            loadOptions.LoadWith<SavingsDepositDividendAdjustment>(sdia => sdia.Adjustment);
            loadOptions.LoadWith<SavingsDepositInterestAdjustment>(sdia => sdia.Adjustment);

            // attach load options to data context
            _db = new DataContextFactory().CreateDataContext();
            _db.LoadOptions = loadOptions;

            // get savings deposit interest rate
            var interestRate = _db.GetTable<SavingsDepositInterestRate>().Single().InterestRate;

            // quarter 
            var quarter = _db.GetTable<Quarter>()
                .Single(q => q.QuarterID == _view.QuarterID);

            // get all members entitled for quarterly interest
            var members = _db.GetTable<Member>()
                .Where(m =>
                    m.SavingsDeposit != null &&
                    m.AvailedServices.Any(a => a.ServiceID == ServiceCodes.SavingsDeposit))
                .ToList();

            // create quarterly interest
            _quarterlyInterestEntity = new QuarterlyInterest()
            {
                Year = _view.Year,
                Quarter = quarter,
                InterestRate = interestRate
            };

            // maintaining balance 
            var maintainingBalance = _db.GetTable<SavingsDepositMaintainingBalance>()
                .Single().Amount;
            
            // create quarterly interest computation for each member
            foreach (var member in members)
                _quarterlyInterestEntity.AddInterestComputationFor(member, maintainingBalance);

            return FlattenQuarterlyInterestComputation(_quarterlyInterestEntity);
        }

        private IList<QuarterlyInterestComputationItem> FlattenQuarterlyInterestComputation(QuarterlyInterest quarterlyInterestEntity)
        {
            var items = quarterlyInterestEntity.QuarterlyInterestComputations
                .Select(amb => new QuarterlyInterestComputationItem()
                {
                    Member = amb.Member.LastName + ", " + amb.Member.FirstName + " " + amb.Member.MiddleName,
                    FirstMonthName = amb.AverageMonthlyBalances[2].Date.ToString("MMMM"),
                    SecondMonthName = amb.AverageMonthlyBalances[1].Date.ToString("MMMM"),
                    ThirdMonthName = amb.AverageMonthlyBalances[0].Date.ToString("MMMM"),
                    FirstMonthAMB = amb.AverageMonthlyBalances[2].Amount,
                    SecondMonthAMB = amb.AverageMonthlyBalances[1].Amount,
                    ThirdMonthAMB = amb.AverageMonthlyBalances[0].Amount,
                    LowestAverageMonthlyBalance = amb.LowestAverageMonthlyBalance,
                    InterestRate = amb.QuarterlyInterest.InterestRate,
                    Interest = amb.Interest
                })
                .OrderBy(x => x.Member)
                .ToList();


            return items;
        }

        private void PostingView_Posting(object sender, EventArgs e)
        {
            var voucher = _postingView.VoucherNumber;
            Post(voucher);
        }

        #endregion

        public QuarterlyInterestComputationPresenter(IQuarterlyInterestComputationView view, IPostingView postingView)
        {
            _db = new DataContextFactory().CreateDataContext();

            _view = view;
            _view.AllowSave = false;
            _view.AllowPost = false;
            _view.PopulateQuaterPulldown(_db.GetTable<Quarter>().ToList());

            _postingView = postingView;
            _postingView.Posting += new EventHandler(PostingView_Posting);

        }

        public bool Compute()
        {
            try
            {
                _db = new DataContextFactory().CreateDataContext();

                var isGenerated = _db.GetTable<QuarterlyInterest>()
                    .Any(x => 
                        x.Year == _view.Year &&
                        x.QuarterID == _view.QuarterID);

                IList<QuarterlyInterestComputationItem> items;
                if (isGenerated)
                {
                    items = GetQuarterlyInterests();
                    _view.AllowSave = false;
                }
                else
                {
                    items = GenerateQuarterlyInterests();
                    _view.AllowSave = true;
                }

                // reflect to view
                _view.AllowPost = !_quarterlyInterestEntity.Posted;
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
                if (_quarterlyInterestEntity == null || _db == null)
                {
                    RaiseErrorEvent("You haven't computed quaterly interest. Please compute first.");
                    return false;
                }

                _db.GetTable<QuarterlyInterest>().InsertOnSubmit(_quarterlyInterestEntity);
                _db.SubmitChanges();
                _view.AllowSave = false;
                RaiseSusccessEvent("Quaterly interests has been saved.");
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
                if (_quarterlyInterestEntity == null || _db == null)
                {
                    RaiseErrorEvent("You have not generated quarterly interest. Please compute first.");
                    return false;
                }

                var adjustment = new Adjustment()
                {
                    AdjustmentJournalVoucher = voucherNumber,
                    UserID = _view.UserID,
                    AdjustmentDate = DateTime.Now
                };

                // Post interest
                foreach (var quarterlyInterestComputation in _quarterlyInterestEntity.QuarterlyInterestComputations)
                {
                    var savingsDeposit = quarterlyInterestComputation.Member.SavingsDeposit;
                    var amount = quarterlyInterestComputation.Interest;
                    savingsDeposit.AddSavingsDepositInterestAdjustment(new SavingsDepositInterestAdjustment()
                    {
                        Adjustment = adjustment,
                        Amount = amount
                    });
                }

                _db.SubmitChanges();
                _view.AllowSave = false;
                _view.AllowPost = false;
                RaiseSusccessEvent("Quarterly interest has been posted.");
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                Compute(); // reset
                return false;
            }
        }
    }
}
