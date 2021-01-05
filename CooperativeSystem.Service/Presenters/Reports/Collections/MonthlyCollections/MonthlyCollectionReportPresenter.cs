using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Presenters.Reports.Collections.MonthlyCollections
{
    public class MonthlyCollectionReportPresenter : PresenterTemplate
    {
        private IMonthlyCollectionReportView _view;

        public MonthlyCollectionReportPresenter(IMonthlyCollectionReportView view)
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
                            x.ReceiptDate.Month == _view.Date.Month
                        )
                        .Select(x => new MonthlyCollection()
                        {
                            Day = x.ReceiptDate.Day,

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

                    var tempList = query.ToList();
                    var firstDayOfTheMonth = 1;
                    var lastDayOfTheMonth = _view.Date.GetLastDayOfTheMonth();

                    for (var i = firstDayOfTheMonth; i < lastDayOfTheMonth; i++)
                    {
                        if (!tempList.Exists(l => l.Day == i))
                            tempList.Add(new MonthlyCollection() { Day = i });
                    }

                    var list = tempList.OrderBy(t => t.Day).ToList();
                    _view.PopulateReports(list);
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
