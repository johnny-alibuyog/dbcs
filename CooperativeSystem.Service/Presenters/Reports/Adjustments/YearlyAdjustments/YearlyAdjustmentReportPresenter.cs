using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Reports.Adjustments.YearlyAdjustments
{
    public class YearlyAdjustmentReportPresenter : PresenterTemplate
    {
        private IYearlyAdjustmentReportView _view;

        public YearlyAdjustmentReportPresenter(IYearlyAdjustmentReportView view)
        {
            _view = view;
        }

        public bool PopulateReports()
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();
                var query = db.GetTable<Adjustment>()
                    .Where(x => x.AdjustmentDate.Year == _view.Date.Year)
                    .Select(x => new YearlyAdjustment()
                    {
                        Date = x.AdjustmentDate,

                        // loans
                        Loan = x.LoanAdjustments.Sum(o => o.Amount),

                        // plans
                        CollegeInsurancePlan = x.CollegeInsurancePlanAdjustments.Sum(o => o.Amount),
                        PensionPlan = x.PensionPlanAdjustments.Sum(o => o.Amount),

                        // savings
                        CapitalShare = x.CapitalShareAdjustments.Sum(o => o.Amount),
                        SavingsDeposit = x.SavingsDepositAdjustments.Sum(o => o.Amount),
                        TimeDeposit = x.TimeDepositAdjustments.Sum(o => o.Amount),

                        // special funds
                        DeathAidFund = x.DeathAidFundAdjustments.Sum(o => o.Amount),
                        TulunganFund = x.TulunganFundAdjustments.Sum(o => o.Amount),

                        // misc
                        MiscellaneousIncome = x.MiscellaneousIncomeAdjustment != null ? new Nullable<decimal>(x.MiscellaneousIncomeAdjustment.Amount) : null
                    });

                var tempList = query.ToList();
                var firstMonthOfTheYear = 1;
                var lastMonthOfTheYear = 12;

                for (var i = firstMonthOfTheYear; i <= lastMonthOfTheYear; i++)
                {
                    if (!tempList.Exists(l => l.Date.Month == i))
                        tempList.Add(new YearlyAdjustment() { Date = new DateTime(_view.Date.Year, i, 1) });
                }

                var list = tempList.OrderBy(t => t.Date).ToList();
                _view.PopulateReports(list);
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
