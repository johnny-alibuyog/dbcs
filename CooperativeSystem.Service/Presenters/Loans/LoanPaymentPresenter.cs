using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Loans.Calculators;

namespace CooperativeSystem.Service.Presenters.Loans
{
    // ToDo: To be deprecated
    public class LoanPaymentPresenter : PresenterTemplate
    {
        private readonly ILoanPaymentView _view;

        public LoanPaymentPresenter(ILoanPaymentView view)
        {
            _view = view;
        }

        public bool Load()
        {
            try
            {
                _view.Initialize();

                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Loan>(x => x.PaymentMode);
                loadOptions.LoadWith<Loan>(x => x.LoanReceipts);
                loadOptions.LoadWith<LoanReceipt>(x => x.CashReceipt);

                using (var db = new DataContextFactory().CreateDataContext())
                {
                    db.LoadOptions = loadOptions;

                    var unsettledLoan = db.GetTable<Loan>()
                        .Where(x =>
                            x.MemberID == _view.MemberID &&
                            x.LoanServiceID == _view.LoanServiceID &&
                            x.Settled == false
                        )
                        .FirstOrDefault();

                    if (unsettledLoan == null)
                    {
                        var service = db.GetTable<Models.Service>()
                            .Where(x => x.ServiceID == _view.LoanServiceID)
                            .Select(x => x.ServiceName)
                            .FirstOrDefault();
                        RaiseErrorEvent(string.Format("You do not have unsettled loan in {0}.", service));
                        return false;
                    }

                    var fineComputationRate = db.GetTable<FineComputationRate>().Single();

                    // late payment fine
                    var fine = unsettledLoan.ComputeDelayedPaymentFine(fineComputationRate);
                    if (unsettledLoan.IsDelayed() || fine > 0M)
                    {
                        _view.HasLatePaymentCharge = true;
                        _view.CondoneLatePaymentCharge = false;
                        _view.LatePaymentDueDate = unsettledLoan.NextPaymentDate;
                        _view.LatePaymentDaysDelayed = unsettledLoan.GetDaysDelayed();
                        _view.ComputedLatePaymentCharge = fine;
                        _view.PreviousUnpaidLatePaymentCharge = unsettledLoan.UnpaidLatePaymentCharge ?? 0M;
                        _view.LatePaymentCharge = fine;
                    }

                    // delinquent charge
                    var charge = unsettledLoan.ComputeDelinquentCharge(fineComputationRate);
                    if (unsettledLoan.IsDelinquent() || charge > 0M)
                    {
                        _view.HasDelinquentCharge = true;
                        _view.CondoneDelinquentCharge = false;
                        _view.DelinquentDueDate = unsettledLoan.DueDate;
                        _view.DelinquentDaysDelinquent = unsettledLoan.GetDaysDelinquent();
                        _view.PreviousUnpaidDelinquentCharge = unsettledLoan.UnpaidDelinquentCharge ?? 0M;
                        _view.ComputedDelinquentCharge = charge;
                        _view.DelinquentCharge = charge;
                    }

                    _view.LoanID = unsettledLoan.LoanID;

                    _view.PaymentMode = unsettledLoan.PaymentMode.ToString();
                    _view.PaymentDueDate = unsettledLoan.NextPaymentDate;
                    _view.LoanAmount = unsettledLoan.LoanAmount;
                    _view.OutstandingBalance = unsettledLoan.GetOutstandingBalance();
                    _view.Amortization = unsettledLoan.Amortization;
                    _view.PayableAmount = unsettledLoan.GetCurrentPayableAmount();
                    _view.PaymentAmount = unsettledLoan.GetCurrentPayableAmount();
                }
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
