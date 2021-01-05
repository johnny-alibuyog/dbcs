using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Utilities.SequenceGenerators;
using System.Data.Linq;

namespace CooperativeSystem.Service.Presenters.Loans
{
    public class InterestRebatePresenter : PresenterTemplate
    {
        private IInterestRebateView _view;

        private DataContext _db;
        //private LoanSetting _loanSetting;
        private AdjustmentVoucherGenerator _voucherGenerator;

        #region Routine Helpers

        private void InitializeViewDisplay()
        {
            _view.VoucherNumber = _voucherGenerator.Generate();

            _view.LoanDate = null;
            _view.SettlementDate = null;
            _view.DueDate = null;
            _view.PaymentMode = null;
            _view.Terms = null;
            _view.MonthsRebatable = null;
            _view.LoanAmount = null;
            _view.InterestRate = null;
            _view.Interest = null;
            _view.InterestRebate = null;
            _view.HasRebatableLoan = false;

            PopulateLoanPulldown();
        }

        private void PopulateLoanPulldown()
        {
            try
            {
                _view.IsPopulatingPulldown = true;

                if (_view.MemberID == 0M)
                {
                    RaiseErrorEvent("You did not perform customer search. Please select customer from custumer inquiry.");
                    return;
                }

                //var rebatableLoans = new string[] { ServiceCodes.EquityLoan, ServiceCodes.RegularLoan };
                //var loanSetting = _db.GetTable<LoanSetting>().Single();
                //var loansLookup = _db.GetTable<Loan>()
                //    .Where(l =>
                //        l.MemberID == _view.MemberID &&
                //        l.Settled == true && (
                //        l.DueDate - l.LoanReceipts.Max(lr => lr.CashReceipt.ReceiptDate)).Days / 30 > 0 &&
                //        rebatableLoans.Contains(l.LoanServiceID))
                //    .Select(l => new LoanLookupModel()
                //    {
                //        LoanID = l.LoanID,
                //        VoucherNumber = l.LoanDisbursements.Single()
                //            .CashDisbursement.CashDisbursementVoucher
                //    })
                //    .ToList();

                var rebatableLoans = new string[] { ServiceCodes.EquityLoan, ServiceCodes.RegularLoan };
                var loanSetting = _db.GetTable<LoanSetting>().Single();
                var loansLookup = _db.GetTable<Loan>()
                    .Where(l =>
                        l.MemberID == _view.MemberID &&
                        l.Settled == true &&
                        l.Terms > loanSetting.RebateExemptedTerms &&
                        (l.DueDate - l.SettlementDate.Value).Days / 30 > 0 &&
                        rebatableLoans.Contains(l.LoanServiceID))
                    .Select(l => new LoanLookupModel()
                    {
                        LoanID = l.LoanID,
                        VoucherNumber = l.LoanDisbursements.Single()
                            .CashDisbursement.CashDisbursementVoucher
                    })
                    .ToList();



                _view.PopulateLoanPulldown(loansLookup);
                _view.HasRebatableLoan = (loansLookup.Any());
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

        public InterestRebatePresenter(IInterestRebateView view)
        {
            _db = new DataContextFactory().CreateDataContext();
            _voucherGenerator = new AdjustmentVoucherGenerator(_db);

            _view = view;
        }

        public bool Load()
        {
            InitializeViewDisplay();
            return true;
        }

        public bool GenerateVoucherNumber()
        {
            var remarks = string.Empty;
            var voucher = _voucherGenerator.Generate(_view.Sequence, out remarks);
            if (string.IsNullOrEmpty(voucher))
            {
                RaiseErrorEvent(remarks);
                return false;
            }

            _view.VoucherNumber = voucher;
            return true;
        }

        public bool SelectLoan()
        {
            try
            {
                if (_view.SelectedLoanID == null)
                    return true;

                var loanSetting = _db.GetTable<LoanSetting>().Single();
                var rebate = _db.GetTable<Loan>()
                    .Where(x => 
                        x.Settled && 
                        x.LoanID == _view.SelectedLoanID
                    )
                    .Select(x => new InterestRebateModel()
                    {
                        LoanDate = x.LoanDate,
                        DueDate = x.DueDate,
                        SettlementDate = x.SettlementDate.Value, // l.LoanReceipts.Max(lr => lr.CashReceipt.ReceiptDate),
                        PaymentMode = x.PaymentMode.PaymentModeName,
                        Terms = x.Terms,
                        LoanAmount = x.LoanAmount,
                        InterestRate = x.InterestRate,
                        Interest = x.Interest,
                        RebateExemptedTerms = loanSetting.RebateExemptedTerms,
                    })
                    .FirstOrDefault();

                if (rebate != null)
                {
                    _view.LoanDate = rebate.LoanDate;
                    _view.SettlementDate = rebate.SettlementDate;
                    _view.DueDate = rebate.DueDate;
                    _view.PaymentMode = rebate.PaymentMode;
                    _view.Terms = rebate.Terms;
                    _view.MonthsRebatable = rebate.MonthsRebatable;
                    _view.LoanAmount = rebate.LoanAmount;
                    _view.InterestRate = rebate.InterestRate;
                    _view.Interest = rebate.Interest;
                    _view.InterestRebate = rebate.InterestRebate;
                }

                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool Accept()
        {
            try
            {
                if (_view.InterestRebate <= 0)
                {
                    RaiseErrorEvent("Not rebatable.");
                    return false;
                }

                var capitalShare = _db.GetTable<CapitalShare>()
                    .Where(m => m.MemberID == _view.MemberID)
                    .Single();

                var adjustment = new Adjustment()
                {
                    AdjustmentJournalVoucher = _view.VoucherNumber,
                    UserID = _view.UserID,
                    AdjustmentDate = _view.AdjustmentDate,
                    MemberID = _view.MemberID
                };

                var amount = _view.InterestRebate.Value;

                capitalShare.AddCapitalShareInterestRebateAdjustment(new CapitalShareInterestRebateAdjustment()
                {
                        Amount = _view.InterestRebate.Value,
                        Adjustment = adjustment
                });

                _db.SubmitChanges();
                RaiseSusccessEvent("Successful.");
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
