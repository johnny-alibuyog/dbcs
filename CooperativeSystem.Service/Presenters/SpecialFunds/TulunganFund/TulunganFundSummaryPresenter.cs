using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.SpecialFunds.TulunganFund
{
    public class TulunganFundSummaryPresenter : PresenterTemplate
    {
        private ITulunganFundSummaryView _view;

        public TulunganFundSummaryPresenter(ITulunganFundSummaryView view)
        {
            _view = view;
        }

        public bool Load(long memberID)
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();
                var transactionsQuery = db.GetTable<TulunganFundReceipt>()
                    .Where(x => x.MemberID == memberID)
                    .Select(x => new TulunganFundTransaction()
                    {
                        Date = x.CashReceipt.ReceiptDate,
                        TransactionType = "Receipt",
                        ReceiptVoucher = x.CashReceipt.OfficialReceiptNumber,
                        Amount = x.Amount
                    })
                    .Concat(db.GetTable<TulunganFundDisbursement>()
                    .Where(x => x.MemberID == memberID)
                    .Select(x => new TulunganFundTransaction()
                    {
                        Date = x.CashDisbursement.DisbursementDate,
                        TransactionType = "Disbursement",
                        ReceiptVoucher = x.CashDisbursement.CashDisbursementVoucher,
                        Amount = x.Amount
                    }))
                    .Concat(db.GetTable<TulunganFundAdjustment>()
                    .Where(x => x.MemberID == memberID)
                    .Select(x => new TulunganFundTransaction()
                    {
                        Date = x.Adjustment.AdjustmentDate,
                        TransactionType = "Adjustment",
                        ReceiptVoucher = x.Adjustment.AdjustmentJournalVoucher,
                        Amount = x.Amount
                    }))
                    .OrderBy(i => i.Date);

                var dafQuery = db.GetTable<CooperativeSystem.Service.Models.TulunganFund>()
                    .FirstOrDefault(daf => daf.MemberID == memberID);

                _view.Transactions = transactionsQuery.ToList();
                _view.Total = (dafQuery != null) ? dafQuery.CurrentBalance : 0M;

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
            _view.Transactions = null;
            _view.Total = 0M;
            return true;
        }
    }
}
