using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using System.Data.Linq;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.Loans
{
    public class PastLoansPresenter : PresenterTemplate
    {
        private IPastLoansView _view;

        #region Routine Helpers

        private void InitializeViewDisplay()
        {
            _view.LoanDate = null;
            _view.SettlementDate = null;
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
            _view.Amortization = null;

            _view.Transactions = null;
            _view.TotalTransaction = null;

            _view.Fines = null;
            _view.TotalFine = null;

            _view.Charges = null;
            _view.TotalCharge = null;

            _view.IsPopulatingPulldown = false;
            PopulateLoanPulldown();
        }

        private void PopulateLoanPulldown()
        {
            try
            {
                _view.IsPopulatingPulldown = true;
                var db = new DataContextFactory().CreateDataContext();
                var loansLookup = db.GetTable<Loan>()
                    .Where(l =>
                        l.MemberID == _view.MemberID &&
                        l.LoanServiceID == _view.LoanServiceID &&
                        l.Settled == true)
                    .OrderByDescending(l => l.LoanDate)
                    .Select(l => new LoanLookupModel()
                    {
                        LoanID = l.LoanID,
                        VoucherNumber = l.LoanDisbursements.Single()
                            .CashDisbursement.CashDisbursementVoucher
                    })
                    .ToList();

                _view.PopulateLoanPulldown(loansLookup);
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
            finally
            {
                _view.IsPopulatingPulldown = false;
            }
        }

        #endregion

        public PastLoansPresenter(IPastLoansView view)
        {
            _view = view;
        }

        public bool Load()
        {
            InitializeViewDisplay();
            return true;
        }

        public bool SelectLoan()
        {
            try
            {
                if (_view.SelectedLoanID == null)
                    return true;

                var loadOptions = new DataLoadOptions();

                loadOptions.LoadWith<Loan>(x => x.PaymentMode);
                loadOptions.LoadWith<Loan>(x => x.LoanDeductionType);

                loadOptions.LoadWith<Loan>(x => x.LoanReceipts);
                loadOptions.LoadWith<Loan>(x => x.LoanAdjustments);
                loadOptions.LoadWith<Loan>(x => x.LoanDividendAdjustments);
                loadOptions.LoadWith<Loan>(x => x.LatePaymentFineReceipts);
                loadOptions.LoadWith<Loan>(x => x.DelinquentFineReceipts);

                loadOptions.LoadWith<LoanReceipt>(x => x.CashReceipt);
                loadOptions.LoadWith<LoanAdjustment>(x => x.Adjustment);
                loadOptions.LoadWith<LoanDividendAdjustment>(x => x.Adjustment);
                loadOptions.LoadWith<LatePaymentFineReceipt>(x => x.CashReceipt);
                loadOptions.LoadWith<DelinquentFineReceipt>(x => x.CashReceipt);


                var db = new DataContextFactory().CreateDataContext();
                db.LoadOptions = loadOptions;

                var loan = db.GetTable<Loan>()
                    .Where(l => l.LoanID == _view.SelectedLoanID)
                    .Select(l => l)
                    .FirstOrDefault();

                if (loan == null)
                    return true;

                var transactions = loan.LoanReceipts
                    .Select(x => new TransactionModel()
                    {
                        Date = x.CashReceipt.ReceiptDate,
                        TransactionType = "Receipt",
                        ReferenceNumber = x.CashReceipt.OfficialReceiptNumber,
                        Amount = x.Amount,
                        Balance = x.Balance,
                    })
                    .Concat(loan.LoanAdjustments
                    .Select(x => new TransactionModel()
                    {
                        Date = x.Adjustment.AdjustmentDate,
                        TransactionType = "Adjustment",
                        ReferenceNumber = x.Adjustment.AdjustmentJournalVoucher,
                        Amount = x.Amount,
                        Balance = x.Balance
                    }))
                    .Concat(loan.LoanDividendAdjustments
                    .Select(x => new TransactionModel()
                    {
                        Date = x.Adjustment.AdjustmentDate,
                        TransactionType = "Dividend",
                        ReferenceNumber = x.Adjustment.AdjustmentJournalVoucher,
                        Amount = x.Amount,
                        Balance = x.Balance
                    }))
                    .ToList();

                var fines = loan.LatePaymentFineReceipts
                    .OrderBy(x => x.CashReceipt.ReceiptDate)
                    .Select(x => new ReceiptModel()
                    {
                        PaymentDate = x.CashReceipt.ReceiptDate,
                        ReceiptNumber = x.CashReceipt.OfficialReceiptNumber,
                        PaymentAmount = x.Amount
                    })
                    .ToList();

                var charges = loan.DelinquentFineReceipts
                    .OrderBy(x => x.CashReceipt.ReceiptDate)
                    .Select(x => new ReceiptModel()
                    {
                        PaymentDate = x.CashReceipt.ReceiptDate,
                        ReceiptNumber = x.CashReceipt.OfficialReceiptNumber,
                        PaymentAmount = x.Amount
                    })
                    .ToList();

                _view.LoanDate = loan.LoanDate;
                _view.SettlementDate = loan.SettlementDate.Value;
                _view.DueDate = loan.DueDate;
                _view.Terms = loan.Terms;
                _view.PaymentMode = loan.PaymentMode.ToString();
                _view.DeductionType = loan.LoanDeductionType.ToString();

                _view.ServiceFee = loan.ServiceFee;
                _view.CollectionFee = loan.CollectionFee;
                _view.CapitalBuildup = loan.CapitalBuildup;
                _view.LoanGuranteeFund = loan.LoanGuaranteeFund;
                _view.Interest = loan.Interest;
                _view.LoanAmount = loan.LoanAmount;
                _view.TotalPayableAmount = loan.GetTotalPayableAmount();
                _view.Amortization = loan.Amortization;

                _view.Transactions = transactions.OrderBy(x => x.Date).ToList();
                _view.TotalTransaction = transactions.Sum(x => x.Amount);

                _view.Fines = fines;
                _view.TotalFine = fines.Sum(x => x.PaymentAmount);

                _view.Charges = charges;
                _view.TotalCharge = charges.Sum(x => x.PaymentAmount);

                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }
    }
}
