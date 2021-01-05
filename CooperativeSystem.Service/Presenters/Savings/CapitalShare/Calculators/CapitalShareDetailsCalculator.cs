using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using System.Data.Linq;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare.Calculators
{
    internal class CapitalShareDetailsCalculator
    {
        private CooperativeSystem.Service.Models.CapitalShare _capitalShare;

        public static DataLoadOptions GetDataLoadOptions()
        {
            var options = new DataLoadOptions();
            options.LoadWith<CooperativeSystem.Service.Models.CapitalShare>(cs => cs.CapitalShareReceipts);
            options.LoadWith<CooperativeSystem.Service.Models.CapitalShare>(cs => cs.CapitalShareDisbursements);
            options.LoadWith<CooperativeSystem.Service.Models.CapitalShare>(cs => cs.DividendDisbursements);
            options.LoadWith<CooperativeSystem.Service.Models.CapitalShare>(cs => cs.PatronageRefundDisbursements);
            options.LoadWith<CapitalShareReceipt>(r => r.CashReceipt);
            options.LoadWith<CapitalShareDisbursement>(d => d.CashDisbursement);
            options.LoadWith<DividendDisbursement>(d => d.CashDisbursement);
            options.LoadWith<PatronageRefundDisbursement>(d => d.CashDisbursement);
            return options;
        }

        public CapitalShareDetailsCalculator(CooperativeSystem.Service.Models.CapitalShare capitalShare)
        {
            _capitalShare = capitalShare;
        }

        public decimal ComputeReceipts()
        {
            return _capitalShare.CapitalShareReceipts.Sum(r => r.Amount);
        }

        public decimal ComputeDisbursements()
        {
            return _capitalShare.CapitalShareDisbursements.Sum(d => d.Amount);
        }

        public decimal ComputeDividends()
        {
            return _capitalShare.DividendDisbursements.Sum(d => d.Amount);
        }

        public decimal ComputePatronages()
        {
            return _capitalShare.PatronageRefundDisbursements.Sum(d => d.Amount);
        }

        public decimal ComputeShare()
        {
            var receipts = ComputeReceipts();
            var disbursements = ComputeDisbursements();
            var dividends = ComputeDividends();
            var patronages = ComputePatronages();

            return receipts + dividends + patronages - disbursements;
            //_view.DisbursedAmount = disbursements;
        }

        public IList<CapitalShareDetailsItem> GetCapitalShareDetails()
        {
            var details = _capitalShare.CapitalShareReceipts
                .Select(r => new CapitalShareDetailsItem()
                {
                    Date = r.CashReceipt.ReceiptDate,
                    TransactionType = "Receipt",
                    ReceiptVoucher = r.CashReceipt.OfficialReceiptNumber,
                    Amount = r.Amount,
                    Balance = r.Balance
                })
                .Union(_capitalShare.CapitalShareDisbursements
                .Select(d => new CapitalShareDetailsItem()
                {
                    Date = d.CashDisbursement.DisbursementDate,
                    TransactionType = "Disbursement",
                    ReceiptVoucher = d.CashDisbursement.CashDisbursementVoucher,
                    Amount = d.Amount,
                    Balance = d.Balance
                })
                .Union(_capitalShare.DividendDisbursements
                .Select(d => new CapitalShareDetailsItem()
                {
                    Date = d.CashDisbursement.DisbursementDate,
                    TransactionType = "Dividend",
                    ReceiptVoucher = d.CashDisbursement.CashDisbursementVoucher,
                    Amount = d.Amount,
                    Balance = d.Balance
                })
                .Union(_capitalShare.PatronageRefundDisbursements
                .Select(d => new CapitalShareDetailsItem()
                {
                    Date = d.CashDisbursement.DisbursementDate,
                    TransactionType = "Patronage Refund",
                    ReceiptVoucher = d.CashDisbursement.CashDisbursementVoucher,
                    Amount = d.Amount,
                    Balance = d.Balance
                }))))
                .OrderBy(i => i.Date)
                .ToList();

            return details;
        }
    }
}
