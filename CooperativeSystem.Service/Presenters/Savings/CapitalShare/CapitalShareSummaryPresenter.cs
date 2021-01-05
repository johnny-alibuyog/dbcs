using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Savings.CapitalShare.Calculators;
using System.Data.Linq;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare
{
    public class CapitalShareSummaryPresenter : PresenterTemplate
    {
        private ICapitalShareSummaryView _view;
        private Nullable<long> _memberID;

        public CapitalShareSummaryPresenter(ICapitalShareSummaryView view)
        {
            _view = view;
        }

        public bool Load(long memberID)
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();

                var transactionsQuery = db.GetTable<CapitalShareReceipt>()
                    .Where(r => r.MemberID == memberID)
                    .Select(r => new CapitalShareTransaction()
                    {
                        Date = r.CashReceipt.ReceiptDate,
                        TransactionType = "Receipt",
                        ReceiptVoucher = r.CashReceipt.OfficialReceiptNumber,
                        Amount = r.Amount,
                        Balance = r.Balance
                    })
                    .Concat(db.GetTable<CapitalShareBuildup>()
                    .Where(b => b.MemberID == memberID)
                    .Select(b => new CapitalShareTransaction()
                    {
                        Date = b.CashDisbursement.DisbursementDate,
                        TransactionType = "Capital Buildup",
                        ReceiptVoucher = b.CashDisbursement.CashDisbursementVoucher,
                        Amount = b.Amount,
                        Balance = b.Balance
                    }))
                    .Concat(db.GetTable<CapitalShareDisbursement>()
                    .Where(d => d.MemberID == memberID)
                    .Select(d => new CapitalShareTransaction()
                    {
                        Date = d.CashDisbursement.DisbursementDate,
                        TransactionType = "Disbursement",
                        ReceiptVoucher = d.CashDisbursement.CashDisbursementVoucher,
                        Amount = d.Amount,
                        Balance = d.Balance
                    }))
                    .Concat(db.GetTable<CapitalShareDividendAdjustment>()
                    .Where(a => a.MemberID == memberID)
                    .Select(a => new CapitalShareTransaction()
                    {
                        Date = a.Adjustment.AdjustmentDate,
                        TransactionType = "Dividend",
                        ReceiptVoucher = a.Adjustment.AdjustmentJournalVoucher,
                        Amount = a.Amount,
                        Balance = a.Balance
                    }))
                    .Concat(db.GetTable<CapitalShareInterestRebateAdjustment>()
                    .Where(a => a.MemberID == memberID)
                    .Select(a => new CapitalShareTransaction()
                    {
                        Date = a.Adjustment.AdjustmentDate,
                        TransactionType = "Interest Rebate",
                        ReceiptVoucher = a.Adjustment.AdjustmentJournalVoucher,
                        Amount = a.Amount,
                        Balance = a.Balance
                    }))
                    .Concat(db.GetTable<CapitalSharePatronageRefundAdjustment>()
                    .Where(a => a.MemberID == memberID)
                    .Select(a => new CapitalShareTransaction()
                    {
                        Date = a.Adjustment.AdjustmentDate,
                        TransactionType = "Patronage Refund",
                        ReceiptVoucher = a.Adjustment.AdjustmentJournalVoucher,
                        Amount = a.Amount,
                        Balance = a.Balance
                    }))
                    .Concat(db.GetTable<CapitalShareAdjustment>()
                    .Where(a => a.MemberID == memberID)
                    .Select(a => new CapitalShareTransaction()
                    {
                        Date = a.Adjustment.AdjustmentDate,
                        TransactionType = "Adjustment",
                        ReceiptVoucher = a.Adjustment.AdjustmentJournalVoucher,
                        Amount = a.Amount,
                        Balance = a.Balance
                    }))
                    .OrderBy(i => i.Date);

                var capitalShareQuery = db.GetTable<Models.CapitalShare>()
                    .FirstOrDefault(cs => cs.MemberID == memberID);

                _view.Transactions = transactionsQuery.ToList();
                _view.TotalShare = capitalShareQuery != null ? capitalShareQuery.CurrentBalance : 0M;

                _memberID = memberID;
                return true;
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
            _view.TotalShare = null;
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

                    loadOptions.LoadWith<CooperativeSystem.Service.Models.CapitalShare>(x => x.CapitalShareReceipts);
                    loadOptions.LoadWith<CooperativeSystem.Service.Models.CapitalShare>(x => x.CapitalShareAdjustments);
                    loadOptions.LoadWith<CooperativeSystem.Service.Models.CapitalShare>(x => x.CapitalShareBuildups);
                    loadOptions.LoadWith<CooperativeSystem.Service.Models.CapitalShare>(x => x.CapitalShareDividendAdjustments);
                    loadOptions.LoadWith<CooperativeSystem.Service.Models.CapitalShare>(x => x.CapitalShareInterestRebateAdjustments);
                    loadOptions.LoadWith<CooperativeSystem.Service.Models.CapitalShare>(x => x.CapitalSharePatronageRefundAdjustments);
                    loadOptions.LoadWith<CooperativeSystem.Service.Models.CapitalShare>(x => x.CapitalShareDisbursements);

                    loadOptions.LoadWith<CapitalShareReceipt>(x => x.CashReceipt);
                    loadOptions.LoadWith<CapitalShareAdjustment>(x => x.Adjustment);
                    loadOptions.LoadWith<CapitalShareBuildup>(x => x.CashDisbursement);
                    loadOptions.LoadWith<CapitalShareDividendAdjustment>(x => x.Adjustment);
                    loadOptions.LoadWith<CapitalShareInterestRebateAdjustment>(x => x.Adjustment);
                    loadOptions.LoadWith<CapitalSharePatronageRefundAdjustment>(x => x.Adjustment);
                    loadOptions.LoadWith<CapitalShareDisbursement>(x => x.CashDisbursement);

                    db.LoadOptions = loadOptions;

                    var capitalShare = db.GetTable<CooperativeSystem.Service.Models.CapitalShare>()
                        .Where(x => x.MemberID == _memberID.Value)
                        .FirstOrDefault();

                    capitalShare.RecomputeBalance();
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
