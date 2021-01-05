using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Reports.Adjustments.DailyAdjustments
{
    public class DailyAdjustmentReportPresenter : PresenterTemplate
    {
        private IDailyAdjustmentReportView _view;

        public DailyAdjustmentReportPresenter(IDailyAdjustmentReportView view)
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
                        x.AdjustmentDate.Month == _view.Date.Month &&
                        x.AdjustmentDate.Day == _view.Date.Day
                    )
                    .Select(x => new DailyAdjustment()
                    {
                        Member = x.Member != null
                            ? x.Member.LastName + ", " + x.Member.FirstName + " " + x.Member.MiddleName
                            : string.Empty,

                        JVNumber = x.AdjustmentJournalVoucher,

                        User = x.User != null
                            ? x.User.LastName + ", " + x.User.FirstName + " " + x.User.MiddleName
                            : string.Empty,

                        //ORNumber = x.CashReceipt.OfficialReceiptNumber,

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

                _view.PopulateReports(query.ToList());
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
