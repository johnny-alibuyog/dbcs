using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Reports.MiscellaneousIncomes
{
    public class MiscellaneousIncomeReportPresenter : PresenterTemplate
    {
        private readonly IMiscellaneousIncomeReportView _view;

        public MiscellaneousIncomeReportPresenter(IMiscellaneousIncomeReportView view)
        {
            _view = view;
            _view.PopulateTypePulldown(MiscellaneousIncomeType.All);
            _view.Type = MiscellaneousIncomeType.None;
            _view.FromDate = DateTime.Today;
            _view.ToDate = DateTime.Today;
        }

        public virtual void Populate()
        {
            try
            {
                var items = (IList<MiscellaneousIncomeItem>)null;
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    var query = db.GetTable<OtherReceipt>()
                        .Select(x => new MiscellaneousIncomeItem()
                        {
                            TransactionDate = x.CashReceipt.ReceiptDate,
                            Type = MiscellaneousIncomeType.OtherReceipt.Name,
                            User = x.CashReceipt.User.FirstName + " " + x.CashReceipt.User.LastName,
                            Amount = x.Amount,
                            Remarks = x.Remarks
                        })
                        .Concat(db.GetTable<OtherDisbursement>()
                        .Select(x => new MiscellaneousIncomeItem()
                        {
                            TransactionDate = x.CashDisbursement.DisbursementDate,
                            Type = MiscellaneousIncomeType.OtherDisbursement.Name,
                            User = x.CashDisbursement.User.FirstName + " " + x.CashDisbursement.User.LastName,
                            Amount = x.Amount * -1,
                            Remarks = x.Remarks
                        }))
                        .Concat(db.GetTable<OtherAdjustment>()
                        .Select(x => new MiscellaneousIncomeItem()
                        {
                            TransactionDate = x.Adjustment.AdjustmentDate,
                            Type = MiscellaneousIncomeType.OtherAdjustment.Name,
                            User = x.Adjustment.User.FirstName + " " + x.Adjustment.User.LastName,
                            Amount = x.Amount,
                            Remarks = x.Remarks
                        }))
                        .Concat(db.GetTable<MiscellaneousIncomeReceipt>()
                        .Select(x => new MiscellaneousIncomeItem()
                        {
                            TransactionDate = x.CashReceipt.ReceiptDate,
                            Type = MiscellaneousIncomeType.MiscellaneousIncomeReceipt.Name,
                            User = x.CashReceipt.User.FirstName + " " + x.CashReceipt.User.LastName,
                            Amount = x.Amount,
                            Remarks = x.Remarks
                        }))
                        .Concat(db.GetTable<MiscellaneousIncomeDisbursement>()
                        .Select(x => new MiscellaneousIncomeItem()
                        {
                            TransactionDate = x.CashDisbursement.DisbursementDate,
                            Type = MiscellaneousIncomeType.MiscellaneousIncomeDisbursement.Name,
                            User = x.CashDisbursement.User.FirstName + " " + x.CashDisbursement.User.LastName,
                            Amount = x.Amount * -1,
                            Remarks = x.Remarks
                        }))
                        .Concat(db.GetTable<MiscellaneousIncomeAdjustment>()
                        .Select(x => new MiscellaneousIncomeItem()
                        {
                            TransactionDate = x.Adjustment.AdjustmentDate,
                            Type = MiscellaneousIncomeType.MiscellaneousIncomeAdjustment.Name,
                            User = x.Adjustment.User.FirstName + " " + x.Adjustment.User.LastName,
                            Amount = x.Amount,
                            Remarks = x.Remarks
                        }))
                        .Concat(db.GetTable<MembershipFeeReceipt>()
                        .Select(x => new MiscellaneousIncomeItem()
                        {
                            TransactionDate = x.CashReceipt.ReceiptDate,
                            Type = MiscellaneousIncomeType.MembershipFeeReceipt.Name,
                            User = x.CashReceipt.User.FirstName + " " + x.CashReceipt.User.LastName,
                            Amount = x.Amount,
                            Remarks = MiscellaneousIncomeType.MembershipFeeReceipt.Name
                        }));

                    if (this._view.ToDate >= this._view.FromDate)
                    {
                        query = query.Where(x =>
                            x.TransactionDate >= _view.FromDate &&
                            x.TransactionDate <= _view.ToDate
                        );
                    }

                    if (this._view.Type != MiscellaneousIncomeType.None)
                    {
                        query = query.Where(x => x.Type == this._view.Type.Name);
                    }

                    query = query.OrderBy(x => x.TransactionDate);

                    items = query.ToList();
                }
                _view.PopulateReport(items);
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
        }
    }
}
