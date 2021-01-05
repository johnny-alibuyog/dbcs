using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Presenters.Reports.Disbursements.MonthlyDisbursements
{
    public class MonthlyDisbursementReportPresenter : PresenterTemplate
    {
        private IMonthlyDisbursementReportView _view;

        public MonthlyDisbursementReportPresenter(IMonthlyDisbursementReportView view)
        {
            _view = view;
        }

        public bool PopulateReports()
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();
                var query = db.GetTable<CashDisbursement>()
                    .Where(cd =>
                        cd.DisbursementDate.Year == _view.Date.Year &&
                        cd.DisbursementDate.Month == _view.Date.Month)
                    .Select(cd => new MonthlyDisbursement()
                    {
                        Day = cd.DisbursementDate.Day,

                        // loans
                        Loan = cd.LoanDisbursements.Sum(l => l.Amount),

                        // plans
                        CollegeInsurancePlan = cd.CollegeInsurancePlanDisbursements.Sum(cip => cip.Amount),
                        PensionPlan = cd.PensionPlanDisbursements.Sum(pp => pp.Amount),

                        // savings
                        CapitalShare = (cd.CapitalShareDisbursements.Any() ? cd.CapitalShareDisbursements.Sum(cs => cs.Amount) : 0M) +
                            (cd.CapitalShareBuildups.Any() ? cd.CapitalShareBuildups.Sum(cs => cs.Amount) : 0M),
                        SavingsDeposit = cd.SavingsDepositDisbursements.Sum(sd => sd.Amount),
                        TimeDeposit = cd.TimeDepositDisbursements.Sum(td => td.Amount),

                        // special funds
                        DeathAidFund = cd.DeathAidFundDisbursements.Sum(daf => daf.Amount),
                        TulunganFund = cd.TulunganFundDisbursements.Sum(tf => tf.Amount),

                        // miscellaneous
                        MiscellaneousIncome = cd.MiscellaneousIncomeDisbursement != null ? new Nullable<decimal>(cd.MiscellaneousIncomeDisbursement.Amount) : null
                    });

                var tempList = query.ToList();
                var firstDayOfTheMonth = 1;
                var lastDayOfTheMonth = _view.Date.GetLastDayOfTheMonth();

                for (var i = firstDayOfTheMonth; i < lastDayOfTheMonth; i++)
                {
                    if (!tempList.Exists(l => l.Day == i))
                        tempList.Add(new MonthlyDisbursement() { Day = i });
                }

                var list = tempList.OrderBy(t => t.Day).ToList();
                _view.PopulateReports(list);
                return true;
            }
            catch(Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }
    }
}
