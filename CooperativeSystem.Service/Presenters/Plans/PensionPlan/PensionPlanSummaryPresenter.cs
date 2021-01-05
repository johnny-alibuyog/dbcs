using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.Plans.PensionPlan
{
    public class PensionPlanSummaryPresenter : PresenterTemplate
    {
        private IPensionPlanSummaryView _view;
        private Nullable<long> _memberID;

        public PensionPlanSummaryPresenter(IPensionPlanSummaryView view)
        {
            _view = view;
        }

        public bool Load(long memberID)
        {
            try
            {
                Clear();

                _memberID = memberID;

                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Member>(x => x.PensionPlan);
                loadOptions.LoadWith<Models.PensionPlan>(x => x.PensionPlanReceipts);
                loadOptions.LoadWith<Models.PensionPlan>(x => x.PensionPlanAdjustments);
                loadOptions.LoadWith<Models.PensionPlan>(x => x.PensionPlanInterestAdjustments);
                loadOptions.LoadWith<Models.PensionPlan>(x => x.PensionPlanDisbursements);
                loadOptions.LoadWith<Models.PensionPlanReceipt>(x => x.CashReceipt);
                loadOptions.LoadWith<Models.PensionPlanAdjustment>(x => x.Adjustment);
                loadOptions.LoadWith<Models.PensionPlanInterestAdjustment>(x => x.Adjustment);
                loadOptions.LoadWith<Models.PensionPlanDisbursement>(x => x.CashDisbursement);

                var member = (Member)null;
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    db.LoadOptions = loadOptions;

                    member = db.GetTable<Member>()
                        .Where(m => m.MemberID == _memberID)
                        .FirstOrDefault();

                    if (member == null)
                        return false;

                    _view.HasEnrolled = (member.PensionPlan != null);
                    if (_view.HasEnrolled.Value)
                    {
                        var plan = member.PensionPlan;

                        var transactionDetails = plan.PensionPlanReceipts
                            .Select(x => new TransactionDetail()
                            {
                                Date = x.CashReceipt.ReceiptDate,
                                TransactionType = "Receipt",
                                ReceiptVoucher = x.CashReceipt.OfficialReceiptNumber,
                                Balance = x.Balance,
                                Amount = x.Amount,
                            })
                            .Concat(plan.PensionPlanAdjustments
                            .Select(x => new TransactionDetail()
                            {
                                Date = x.Adjustment.AdjustmentDate,
                                TransactionType = "Adjustment",
                                ReceiptVoucher = x.Adjustment.AdjustmentJournalVoucher,
                                Balance = x.Balance,
                                Amount = x.Amount,
                            }))
                            .Concat(plan.PensionPlanInterestAdjustments
                            .Select(x => new TransactionDetail()
                            {
                                Date = x.Adjustment.AdjustmentDate,
                                TransactionType = "Interest",
                                ReceiptVoucher = x.Adjustment.AdjustmentJournalVoucher,
                                Balance = x.Balance,
                                Amount = x.Amount,
                            }))
                            .Concat(plan.PensionPlanDisbursements
                            .Select(x => new TransactionDetail()
                            {
                                Date = x.CashDisbursement.DisbursementDate,
                                TransactionType = "Disbursement",
                                ReceiptVoucher = x.CashDisbursement.CashDisbursementVoucher,
                                Balance = x.Balance,
                                Amount = x.Amount,
                            }))
                            .OrderBy(x => x.Date)
                            .ToList();

                        _view.TransactionDetails = transactionDetails;
                        _view.TotalBalance = plan.GetBalance();

                        _view.ApplicationDate = plan.ApplicationDate;
                        _view.PaymentCompletionDate = plan.PaymentCompletionDate;
                        _view.MaturityDate = plan.MaturityDate;
                        _view.PaymentMode = plan.PaymentMode.ToString();
                        _view.Terms = plan.Terms;
                        _view.Amortization = plan.Amortization;
                        _view.PaymentCompletionAmount = plan.PaymentCompletionAmount;

                        _view.AvailOption = plan.PensionPlanAvailOption != null ? plan.PensionPlanAvailOption.ToString() : string.Empty;
                        _view.AgingPeriod = plan.AgingPeriod;
                        _view.AwardAmount = plan.AwardAmount;
                        _view.MonthlyPension = plan.MonthlyPension;
                        _view.OptionDescription = plan.PensionPlanAvailOption != null ? plan.PensionPlanAvailOption.AvailOptionDescription : string.Empty;
                    }
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
            _memberID = null;

            _view.HasEnrolled = null;

            _view.TransactionDetails = null;
            _view.TotalBalance = null;

            _view.ApplicationDate = null;
            _view.PaymentCompletionDate = null;
            _view.MaturityDate = null;
            _view.PaymentMode = string.Empty;
            _view.Terms = null;
            _view.Amortization = null;
            _view.PaymentCompletionAmount = null;

            _view.AvailOption = string.Empty;
            _view.AgingPeriod = null;
            _view.AwardAmount = null;
            _view.MonthlyPension = null;
            _view.OptionDescription = string.Empty;

            return true;
        }

        public bool CheckQualification()
        {
            try
            {
                var hasRequiredMinimumShare = false;
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    hasRequiredMinimumShare = db.GetTable<CapitalShare>()
                        .Where(x =>
                            x.MemberID == _memberID &&
                            x.CurrentBalance >= db.GetTable<CapitalShareMinimumAmount>().FirstOrDefault().Amount
                        )
                        .Any();
                }

                if (!hasRequiredMinimumShare)
                {
                    RaiseErrorEvent("You must have the required minimum share to avail this service.");
                    return false;
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
