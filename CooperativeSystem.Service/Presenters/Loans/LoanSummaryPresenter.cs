using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.Loans
{
    public class LoanSummaryPresenter : PresenterTemplate
    {
        private ILoanSummaryView _view;

        public LoanSummaryPresenter(ILoanSummaryView view)
        {
            _view = view;
        }

        public bool Load(long memberID)
        {
            try
            {
                Clear();
                
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Loan>(x => x.LoanDeductionType);
                loadOptions.LoadWith<Loan>(x => x.PaymentMode);
                loadOptions.LoadWith<Loan>(x => x.LoanDisbursements);
                loadOptions.LoadWith<Loan>(x => x.LoanReceipts);
                loadOptions.LoadWith<Loan>(x => x.LoanAdjustments);
                loadOptions.LoadWith<Loan>(x => x.LoanDividendAdjustments);
                loadOptions.LoadWith<Loan>(x => x.LatePaymentFineReceipts);
                loadOptions.LoadWith<Loan>(x => x.DelinquentFineReceipts);
                loadOptions.LoadWith<LoanDisbursement>(x => x.CashDisbursement);
                loadOptions.LoadWith<LoanReceipt>(x => x.CashReceipt);
                loadOptions.LoadWith<LoanAdjustment>(x => x.Adjustment);
                loadOptions.LoadWith<LoanDividendAdjustment>(x => x.Adjustment);
                loadOptions.LoadWith<LatePaymentFineReceipt>(x => x.CashReceipt);
                loadOptions.LoadWith<DelinquentFineReceipt>(x => x.CashReceipt);

                var db = new DataContextFactory().CreateDataContext();
                db.LoadOptions = loadOptions;

                var repository = new GenericRepository<Loan>(db);
                var outstandingLoan = repository.GetEntity(x =>
                    x.MemberID == memberID &&
                    x.LoanServiceID == _view.LoanServiceID &&
                    x.Settled == false
                );

                if (outstandingLoan == null)
                    return true;

                var transactions = outstandingLoan.LoanReceipts
                    .Select(x => new TransactionModel()
                    {
                        Date = x.CashReceipt.ReceiptDate,
                        TransactionType = "Receipt",
                        ReferenceNumber = x.CashReceipt.OfficialReceiptNumber,
                        Amount = x.Amount,
                        Balance = x.Balance,
                    })
                    .Concat(outstandingLoan.LoanAdjustments
                    .Select(x => new TransactionModel()
                    {
                        Date = x.Adjustment.AdjustmentDate,
                        TransactionType = "Adjustment",
                        ReferenceNumber = x.Adjustment.AdjustmentJournalVoucher,
                        Amount = x.Amount,
                        Balance = x.Balance
                    }))
                    .Concat(outstandingLoan.LoanDividendAdjustments
                    .Select(x => new TransactionModel()
                    {
                        Date = x.Adjustment.AdjustmentDate,
                        TransactionType = "Dividend",
                        ReferenceNumber = x.Adjustment.AdjustmentJournalVoucher,
                        Amount = x.Amount,
                        Balance = x.Balance
                    }))
                    .OrderBy(x => x.Date)
                    .ToList();

                var fines = outstandingLoan.LatePaymentFineReceipts
                    .OrderBy(x => x.CashReceipt.ReceiptDate)
                    .Select(x => new ReceiptModel()
                    {
                        PaymentDate = x.CashReceipt.ReceiptDate,
                        ReceiptNumber = x.CashReceipt.OfficialReceiptNumber,
                        Condoned = (x.Condone == true) ? (x.ComputedAmount ?? 0M) - x.Amount : 0M,
                        PaymentAmount = x.Amount
                    })
                    .OrderBy(x => x.PaymentDate)
                    .ToList();

                var charges = outstandingLoan.DelinquentFineReceipts
                    .OrderBy(x => x.CashReceipt.ReceiptDate)
                    .Select(x => new ReceiptModel()
                    {
                        PaymentDate = x.CashReceipt.ReceiptDate,
                        ReceiptNumber = x.CashReceipt.OfficialReceiptNumber,
                        Condoned = (x.Condone == true) ? (x.ComputedAmount ?? 0M) - x.Amount : 0M,
                        PaymentAmount = x.Amount
                    })
                    .OrderBy(x => x.PaymentDate)
                    .ToList();

                var disbursement = outstandingLoan.LoanDisbursements.First();
                _view.CashDisbursementVoucher = disbursement.CashDisbursement.CashDisbursementVoucher;

                _view.Transactions = transactions;
                _view.TotalTransaction = transactions.Sum(r => r.Amount);

                _view.Fines = fines;
                _view.TotalFine = fines.Sum(r => r.PaymentAmount);

                _view.Charges = charges;
                _view.TotalCharge = charges.Sum(r => r.PaymentAmount);

                _view.LoanDate = outstandingLoan.LoanDate;
                _view.NextPaymentDue = outstandingLoan.NextPaymentDate;
                _view.Terms = outstandingLoan.Terms;
                _view.DueDate = outstandingLoan.DueDate;
                _view.PaymentMode = outstandingLoan.PaymentMode.ToString();
                _view.DeductionType = outstandingLoan.LoanDeductionType.ToString();

                _view.ServiceFee = outstandingLoan.ServiceFee;
                _view.CollectionFee = outstandingLoan.CollectionFee;
                _view.CapitalBuildup = outstandingLoan.CapitalBuildup;
                _view.LoanGuranteeFund = outstandingLoan.LoanGuaranteeFund;
                _view.Interest = outstandingLoan.Interest;
                _view.LoanAmount = outstandingLoan.LoanAmount;

                _view.TotalPayableAmount = outstandingLoan.GetTotalPayableAmount();
                _view.OutstandingBalance = outstandingLoan.GetOutstandingBalance();
                _view.Amortization = outstandingLoan.Amortization;

                var fineComputationRate = db.GetTable<FineComputationRate>().Single();

                var fine = outstandingLoan.ComputeDelayedPaymentFine(fineComputationRate);
                if (outstandingLoan.IsDelayed() || fine > 0M)
                {
                    _view.DelayedPaymentDueDate = outstandingLoan.NextPaymentDate;
                    _view.DelayedPaymentDaysDelayed = outstandingLoan.GetDaysDelayed();
                    _view.DelayedPaymentFine = fine;
                    _view.DelayedPaymentRemarks = "Payment Delayed!";
                }

                var charge = outstandingLoan.ComputeDelinquentCharge(fineComputationRate);
                if (outstandingLoan.IsDelinquent() || charge > 0M)
                {
                    _view.DelinquentDueDate = outstandingLoan.DueDate;
                    _view.DelinquentDaysDelinquent = outstandingLoan.GetDaysDelinquent();
                    _view.DelinquentCharge = charge;
                    _view.DelinquentRemarks = "Delinquent!";
                }
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
            _view.CashDisbursementVoucher = null;

            _view.Transactions = null;
            _view.TotalTransaction = null;

            _view.Fines = null;
            _view.TotalFine = null;

            _view.Charges = null;
            _view.TotalCharge = null;

            _view.LoanDate = null;
            _view.NextPaymentDue = null;
            _view.DueDate = null;
            _view.Terms = null;
            _view.PaymentMode = null;
            _view.DeductionType = null;

            _view.ServiceFee = null;
            _view.CollectionFee = null;
            _view.CapitalBuildup = null;
            _view.LoanGuranteeFund = null;
            _view.Interest = null;
            _view.LoanAmount = null;

            _view.TotalPayableAmount = null;
            _view.OutstandingBalance = null;
            _view.Amortization = null;

            _view.DelayedPaymentDueDate = null;
            _view.DelayedPaymentDaysDelayed = null;
            _view.DelayedPaymentFine = null;
            _view.DelayedPaymentRemarks = string.Empty;

            _view.DelinquentDueDate = null;
            _view.DelinquentDaysDelinquent = null;
            _view.DelinquentCharge = null;
            _view.DelinquentRemarks = string.Empty;

            return true;
        }
    }
}
