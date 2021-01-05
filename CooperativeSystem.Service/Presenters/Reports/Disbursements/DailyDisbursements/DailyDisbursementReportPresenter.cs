using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Reports.Disbursements.DailyDisbursements
{
    public class DailyDisbursementReportPresenter : PresenterTemplate
    {
        private IDailyDisbursementReportView _view;

        public DailyDisbursementReportPresenter(IDailyDisbursementReportView view)
        {
            _view = view;
        }

        public bool PopulateReports()
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();
                var query = db.GetTable<CashDisbursement>()
                    .Where(x =>
                        x.DisbursementDate.Year == _view.Date.Year &&
                        x.DisbursementDate.Month == _view.Date.Month &&
                        x.DisbursementDate.Day == _view.Date.Day
                    )
                    .Select(x => new DailyDisbursement()
                    {
                        Member = x.Member != null
                            ? x.Member.LastName + ", " + x.Member.FirstName + " " + x.Member.MiddleName
                            : string.Empty,

                        User = x.User != null
                            ? x.User.LastName + ", " + x.User.FirstName + " " + x.User.MiddleName
                            : string.Empty,

                        JVNumber = x.CashDisbursementVoucher,

                        // loans
                        Loan = x.LoanDisbursements.Sum(l => l.Amount),

                        // plans
                        CollegeInsurancePlan = x.CollegeInsurancePlanDisbursements.Sum(cip => cip.Amount),
                        PensionPlan = x.PensionPlanDisbursements.Sum(pp => pp.Amount),

                        // savings
                        CapitalShare = (x.CapitalShareDisbursements.Any() ? x.CapitalShareDisbursements.Sum(cs => cs.Amount) : 0M) +
                            (x.CapitalShareBuildups.Any() ? x.CapitalShareBuildups.Sum(cs => cs.Amount) : 0M),
                        SavingsDeposit = x.SavingsDepositDisbursements.Sum(sd => sd.Amount),
                        TimeDeposit = x.TimeDepositDisbursements.Sum(td => td.Amount),

                        // special funds
                        DeathAidFund = x.DeathAidFundDisbursements.Sum(daf => daf.Amount),
                        TulunganFund = x.TulunganFundDisbursements.Sum(tf => tf.Amount),

                        // miscellaneous
                        MiscellaneousIncome = x.MiscellaneousIncomeDisbursement != null ? new Nullable<decimal>(x.MiscellaneousIncomeDisbursement.Amount) : null
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
