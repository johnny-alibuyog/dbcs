using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Reports.Collections.YearlyCollections
{
    public class YearlyCollectionReportPresenter : PresenterTemplate
    {
        private IYearlyCollectionReportView _view;

        public YearlyCollectionReportPresenter(IYearlyCollectionReportView view)
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
                        .Where(x => x.ReceiptDate.Year == _view.Date.Year)
                        .Select(x => new YearlyCollection()
                        {
                            Date = x.ReceiptDate,

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
                    var firstMonthOfTheYear = 1;
                    var lastMonthOfTheYear = 12;

                    for (var i = firstMonthOfTheYear; i <= lastMonthOfTheYear; i++)
                    {
                        if (!tempList.Exists(l => l.Date.Month == i))
                            tempList.Add(new YearlyCollection() { Date = new DateTime(_view.Date.Year, i, 1) });
                    }

                    var list = tempList.OrderBy(t => t.Date).ToList();
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
