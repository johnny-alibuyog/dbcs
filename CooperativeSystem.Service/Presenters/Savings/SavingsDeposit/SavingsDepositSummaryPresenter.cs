using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using System.Data.Linq;

namespace CooperativeSystem.Service.Presenters.Savings.SavingsDeposit
{
    public class SavingsDepositSummaryPresenter : PresenterTemplate
    {
        private ISavingsDepositSummaryView _view;
        private Nullable<long> _memberID;

        public SavingsDepositSummaryPresenter(ISavingsDepositSummaryView view)
        {
            _view = view;
        }

        public bool Load(long memberID)
        {
            try
            {
                using (var db = new DataContextFactory().CreateDataContext())
                {

                    var transactionsQuery = db.GetTable<SavingsDepositReceipt>()
                        .Where(x => x.MemberID == memberID)
                        .Select(x => new SavingsDepositTransaction()
                        {
                            ID = x.ID,
                            Date = x.CashReceipt.ReceiptDate,
                            TransactionType = "Receipt",
                            ReceiptVoucher = x.CashReceipt.OfficialReceiptNumber,
                            Amount = x.Amount,
                            Balance = x.Balance
                        })
                        .Concat(db.GetTable<SavingsDepositDisbursement>()
                        .Where(x => x.MemberID == memberID)
                        .Select(x => new SavingsDepositTransaction()
                        {
                            ID = x.ID,
                            Date = x.CashDisbursement.DisbursementDate,
                            TransactionType = "Disbursement",
                            ReceiptVoucher = x.CashDisbursement.CashDisbursementVoucher,
                            Amount = x.Amount,
                            Balance = x.Balance
                        }))
                        .Concat(db.GetTable<SavingsDepositDividendAdjustment>()
                        .Where(x => x.MemberID == memberID)
                        .Select(x => new SavingsDepositTransaction()
                        {
                            ID = x.ID,
                            Date = x.Adjustment.AdjustmentDate,
                            TransactionType = "Dividend",
                            ReceiptVoucher = x.Adjustment.AdjustmentJournalVoucher,
                            Amount = x.Amount,
                            Balance = x.Balance
                        }))
                        .Concat(db.GetTable<SavingsDepositInterestAdjustment>()
                        .Where(x => x.MemberID == memberID)
                        .Select(x => new SavingsDepositTransaction()
                        {
                            ID = x.ID,
                            Date = x.Adjustment.AdjustmentDate,
                            TransactionType = "Interest",
                            ReceiptVoucher = x.Adjustment.AdjustmentJournalVoucher,
                            Amount = x.Amount,
                            Balance = x.Balance
                        }))
                        .Concat(db.GetTable<SavingsDepositAdjustment>()
                        .Where(x => x.MemberID == memberID)
                        .Select(x => new SavingsDepositTransaction()
                        {
                            ID = x.ID,
                            Date = x.Adjustment.AdjustmentDate,
                            TransactionType = "Adjustment",
                            ReceiptVoucher = x.Adjustment.AdjustmentJournalVoucher,
                            Amount = x.Amount,
                            Balance = x.Balance
                        }))
                        .OrderBy(x => x.Date);

                    var savingsDepositQuery = db.GetTable<CooperativeSystem.Service.Models.SavingsDeposit>()
                        .FirstOrDefault(x => x.MemberID == memberID);

                    _view.Transactions = transactionsQuery.ToList();
                    _view.TotalSavings = savingsDepositQuery != null ? savingsDepositQuery.CurrentBalance : 0M;

                    _memberID = memberID;
                    return true;
                }
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool Clear()
        {
            //_memberID = null;

            _view.Transactions = null;
            _view.TotalSavings = null;
            return true;
        }

        public void RecomputeBalance()
        {
            try
            {
                if (_memberID == null)
                    return;

                using (var db = new DataContextFactory().CreateDataContext())
                {
                    var loadOptions = new DataLoadOptions();

                    loadOptions.LoadWith<CooperativeSystem.Service.Models.SavingsDeposit>(x => x.SavingsDepositReceipts);
                    loadOptions.LoadWith<CooperativeSystem.Service.Models.SavingsDeposit>(x => x.SavingsDepositAdjustments);
                    loadOptions.LoadWith<CooperativeSystem.Service.Models.SavingsDeposit>(x => x.SavingsDepositDisbursements);
                    loadOptions.LoadWith<CooperativeSystem.Service.Models.SavingsDeposit>(x => x.SavingsDepositDividendAdjustments);
                    loadOptions.LoadWith<CooperativeSystem.Service.Models.SavingsDeposit>(x => x.SavingsDepositInterestAdjustments);

                    loadOptions.LoadWith<SavingsDepositReceipt>(x => x.CashReceipt);
                    loadOptions.LoadWith<SavingsDepositAdjustment>(x => x.Adjustment);
                    loadOptions.LoadWith<SavingsDepositDisbursement>(x => x.CashDisbursement);
                    loadOptions.LoadWith<SavingsDepositDividendAdjustment>(x => x.Adjustment);
                    loadOptions.LoadWith<SavingsDepositInterestAdjustment>(x => x.Adjustment);

                    db.LoadOptions = loadOptions;

                    var savingsDeposit = db.GetTable<CooperativeSystem.Service.Models.SavingsDeposit>()
                        .Where(x => x.MemberID == _memberID.Value)
                        .FirstOrDefault();

                    savingsDeposit.RecomputeBalance();
                    db.SubmitChanges();
                }

                Clear();
                Load(_memberID.Value);
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
        }
    }
}
