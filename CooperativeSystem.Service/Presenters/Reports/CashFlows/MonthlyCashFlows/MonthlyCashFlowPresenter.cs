using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Reports.Collections.MonthlyCollections;
using CooperativeSystem.Service.Presenters.Reports.Collections.YearlyCollections;
using CooperativeSystem.Service.Presenters.Reports.Disbursements.MonthlyDisbursements;
using CooperativeSystem.Service.Presenters.Reports.Disbursements.YearlyDisbursements;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Presenters.Reports.CashFlows.MonthlyCashFlows
{
    public class MonthlyCashFlowPresenter : PresenterTemplate
    {
        private IMonthlyCashFlowView _view;

        public MonthlyCashFlowPresenter(IMonthlyCashFlowView view)
        {
            _view = view;
        }

        public bool PopulateReports()
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();

                var collectionQuery = db.GetTable<CashReceipt>()
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

                var disbursementQuery = db.GetTable<CashDisbursement>()
                    .Where(x =>
                        x.DisbursementDate.Year == _view.Date.Year &&
                        x.DisbursementDate.Month == _view.Date.Month
                    )
                    .Select(x => new MonthlyDisbursement()
                    {
                        Day = x.DisbursementDate.Day,

                        // loans
                        Loan = x.LoanDisbursements.Sum(o => o.Amount),

                        // plans
                        CollegeInsurancePlan = x.CollegeInsurancePlanDisbursements.Sum(o => o.Amount),
                        PensionPlan = x.PensionPlanDisbursements.Sum(o => o.Amount),

                        // savings
                        CapitalShare = x.CapitalShareDisbursements.Sum(o => o.Amount),
                        SavingsDeposit = x.SavingsDepositDisbursements.Sum(o => o.Amount),
                        TimeDeposit = x.TimeDepositDisbursements.Sum(o => o.Amount),

                        // special funds
                        DeathAidFund = x.DeathAidFundDisbursements.Sum(o => o.Amount),
                        TulunganFund = x.TulunganFundDisbursements.Sum(o => o.Amount),

                        // misc
                        MiscellaneousIncome = x.MiscellaneousIncomeDisbursement != null ? new Nullable<decimal>(x.MiscellaneousIncomeDisbursement.Amount) : null,
                    });

                var collections = collectionQuery.ToList();
                var disbursements = disbursementQuery.ToList();

                var firstDayOfTheMonth = 1;
                var lastDayOfTheMonth = _view.Date.GetLastDayOfTheMonth();

                /* 
                 * just fill in the gaps if there is any, to complete the days in a month
                 * displayed in the reports
                 */
                for (var i = firstDayOfTheMonth; i < lastDayOfTheMonth; i++)
                {
                    if (!collections.Exists(l => l.Day == i))
                        collections.Add(new MonthlyCollection() { Day = i });

                    if (!disbursements.Exists(l => l.Day == i))
                        disbursements.Add(new MonthlyDisbursement() { Day = i });
                }

                //var disbursementSummary =
                //    from disbursement in disbursements
                //    orderby disbursement.Day
                //    group disbursement by disbursement.Day into disbursementPerDay
                //    select new
                //    {
                //        Day = disbursementPerDay.Key,
                //        TotalDisbursement = disbursementPerDay.Sum(d => d.Total)
                //    };

                //var collectionSummary =
                //    from collection in collections
                //    orderby collection.Day
                //    group collection by collection.Day into collectionPerDay
                //    select new
                //    {
                //        Day = collectionPerDay.Key,
                //        TotalCollection = collectionPerDay.Sum(c => c.Total)
                //    };

                //var consolidatedSummary =
                //    from collection in collectionSummary
                //    join disbursement in disbursementSummary
                //        on collection.Day equals disbursement.Day
                //    select new MonthlyCashFlow()
                //    {
                //        Day = collection.Day,
                //        TotalCollection = collection.TotalCollection,
                //        TotalDisbursement = disbursement.TotalDisbursement
                //    };


                var disbursementSummary = disbursements
                    .GroupBy(x => x.Day)
                    .Select(x => new
                    {
                        Day = x.Key,
                        TotalDisbursement = x.Sum(d => d.Total)
                    });

                var collectionSummary = collections
                    .GroupBy(x => x.Day)
                    .Select(x => new
                    {
                        Day = x.Key,
                        TotalCollection = x.Sum(c => c.Total)
                    });

                var consolidatedSummary = collectionSummary
                    .Join(disbursementSummary,
                        (x) => x.Day,
                        (x) => x.Day,
                        (x, y) => new { Day = x.Day, Collections = x, Disbursements = y }
                    )
                    .Select(x => new MonthlyCashFlow()
                    {
                        Day = x.Day,
                        TotalCollection = x.Collections.TotalCollection,
                        TotalDisbursement = x.Disbursements.TotalDisbursement
                    });

                var cashFlows = consolidatedSummary.ToList();
                _view.PopulateReports(cashFlows);
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
