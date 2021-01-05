using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Reports.Collections.DailyCollections
{
    public class DailyCollectionReportPresenter : PresenterTemplate
    {
        private IDailyCollectionReportView _view;

        public DailyCollectionReportPresenter(IDailyCollectionReportView view)
        {
            _view = view;
        }

        public bool PopulateReports()
        {
            try
            {
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    var query = db.GetTable<CashReceipt>()
                        .Where(x =>
                            x.ReceiptDate.Year == _view.Date.Year &&
                            x.ReceiptDate.Month == _view.Date.Month &&
                            x.ReceiptDate.Day == _view.Date.Day
                        )
                        .Select(x => new DailyCollection()
                        {
                            Member = x.Member != null
                                ? x.Member.LastName + ", " + x.Member.FirstName + " " + x.Member.MiddleName
                                : string.Empty,

                            User = x.User != null
                                ? x.User.LastName + ", " + x.User.FirstName + " " + x.User.MiddleName
                                : string.Empty,

                            ORNumber = x.OfficialReceiptNumber,

                            // loans
                            Loan = x.LoanReceipts.Sum(o => o.Amount),
                            LatePaymentFine = x.LatePaymentFineReceipts.Sum(o => o.Amount),
                            DelinquentFine = x.DelinquentFineReceipts.Sum(o => o.Amount),

                            // plans
                            CollegeInsurancePlan = x.CollegeInsurancePlanReceipts.Sum(o => o.Amount),
                            PensionPlan = x.PensionPlanReceipts.Sum(o => o.Amount),

                            // savings
                            CapitalShare = x.CapitalShareReceipts.Sum(o => o.Amount),
                            SavingsDeposit = x.SavingsDepositReceipts.Sum(o => o.Amount),
                            TimeDeposit = x.TimeDepositReceipts.Sum(o => o.Amount),

                            // special funds
                            DeathAidFund = x.DeathAidFundReceipts.Sum(o => o.Amount),
                            TulunganFund = x.TulunganFundReceipts.Sum(o => o.Amount),

                            // misc
                            OtherReceipt = x.OtherReceipt != null ? new Nullable<decimal>(x.OtherReceipt.Amount) : null,
                            MiscellaneousIncome = x.MiscellaneousIncomeReceipt != null ? new Nullable<decimal>(x.MiscellaneousIncomeReceipt.Amount) : null,
                            MembershipFee = x.MembershipFeeReceipt != null ? new Nullable<decimal>(x.MembershipFeeReceipt.Amount) : null
                        });

                    _view.PopulateReports(query.ToList());
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
