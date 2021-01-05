using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Presenters.Reports.Adjustments.MonthlyAdjustments
{
    public class MonthlyAdjustmentReportPresenter : PresenterTemplate
    {
        private IMonthlyAdjustmentReportView _view;

        public MonthlyAdjustmentReportPresenter(IMonthlyAdjustmentReportView view)
        {
            _view = view;
        }

        public bool PopulateReports()
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();
                var query = db.GetTable<Adjustment>()
                    .Where(x =>
                        x.AdjustmentDate.Year == _view.Date.Year &&
                        x.AdjustmentDate.Month == _view.Date.Month
                    )
                    .Select(x => new MonthlyAdjustment()
                    {
                        Day = x.AdjustmentDate.Day,

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
                var firstDayOfTheMonth = 1;
                var lastDayOfTheMonth = _view.Date.GetLastDayOfTheMonth();

                for (var i = firstDayOfTheMonth; i < lastDayOfTheMonth; i++)
                {
                    if (!tempList.Exists(l => l.Day == i))
                        tempList.Add(new MonthlyAdjustment() { Day = i });
                }

                var list = tempList.OrderBy(t => t.Day).ToList();
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
