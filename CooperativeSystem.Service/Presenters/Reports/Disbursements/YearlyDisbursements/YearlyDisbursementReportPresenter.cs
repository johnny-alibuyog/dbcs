using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Reports.Disbursements.YearlyDisbursements
{
    public class YearlyDisbursementReportPresenter : PresenterTemplate
    {
        private IYearlyDisbursementReportView _view;

        public YearlyDisbursementReportPresenter(IYearlyDisbursementReportView view)
        {
            _view = view;
        }

        public bool PopulateReports()
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();
                var query = db.GetTable<CashDisbursement>()
                    .Where(cd => cd.DisbursementDate.Year == _view.Date.Year)
                    .Select(cd => new YearlyDisbursement()
                    {
                        Date = cd.DisbursementDate,

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
                var firstMonthOfTheYear = 1;
                var lastMonthOfTheYear = 12;

                for (var i = firstMonthOfTheYear; i <= lastMonthOfTheYear; i++)
                {
                    if (!tempList.Exists(l => l.Date.Month == i))
                        tempList.Add(new YearlyDisbursement() { Date = new DateTime(_view.Date.Year, i, 1) });
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
