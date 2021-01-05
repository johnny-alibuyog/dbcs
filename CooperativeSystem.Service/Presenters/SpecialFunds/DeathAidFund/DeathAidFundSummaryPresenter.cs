using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.SpecialFunds.DeathAidFund
{
    public class DeathAidFundSummaryPresenter : PresenterTemplate
    {
        private IDeathAidFundSummaryView _view;

        public DeathAidFundSummaryPresenter(IDeathAidFundSummaryView view)
        {
            _view = view;
        }

        public bool Load(long memberID)
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();
                var transactionsQuery = db.GetTable<DeathAidFundReceipt>()
                    .Where(x => x.MemberID == memberID)
                    .Select(x => new DeathAidFundTransaction()
                    {
                        Date = x.CashReceipt.ReceiptDate,
                        TransactionType = "Receipt",
                        ReceiptVoucher = x.CashReceipt.OfficialReceiptNumber,
                        Amount = x.Amount,
                        Balance = x.Balance,
                    })
                    .Concat(db.GetTable<DeathAidFundDisbursement>()
                    .Where(x => x.MemberID == memberID)
                    .Select(x => new DeathAidFundTransaction()
                    {
                        Date = x.CashDisbursement.DisbursementDate,
                        TransactionType = "Disbursement",
                        ReceiptVoucher = x.CashDisbursement.CashDisbursementVoucher,
                        Amount = x.Amount,
                        Balance = x.Balance,
                    }))
                    .Concat(db.GetTable<DeathAidFundAdjustment>()
                    .Where(x => x.MemberID == memberID)
                    .Select(x => new DeathAidFundTransaction()
                    {
                        Date = x.Adjustment.AdjustmentDate,
                        TransactionType = "Adjustment",
                        ReceiptVoucher = x.Adjustment.AdjustmentJournalVoucher,
                        Amount = x.Amount,
                        Balance = x.Balance,
                    }))
                    .OrderBy(x => x.Date);

                var dafQuery = db.GetTable<CooperativeSystem.Service.Models.DeathAidFund>()
                    .FirstOrDefault(x => x.MemberID == memberID);

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
