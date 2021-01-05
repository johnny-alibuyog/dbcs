using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Reports.Collections.YearlyCollections;
using CooperativeSystem.Service.Presenters.Reports.Disbursements.YearlyDisbursements;

namespace CooperativeSystem.Service.Presenters.Reports.CashFlows.YearlyCashFlows
{
    public class YearlyCashFlowReportPresenter : PresenterTemplate
    {
        private IYearlyCashFlowReportView _view;

        public YearlyCashFlowReportPresenter(IYearlyCashFlowReportView view)
        {
            _view = view;
        }

        public bool PopulateReports()
        {
            try
            {
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    var collectionQuery = db.GetTable<CashReceipt>()
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

                    var disbursementQuery = db.GetTable<CashDisbursement>()
                        .Where(x => x.DisbursementDate.Year == _view.Date.Year)
                        .Select(x => new YearlyDisbursement()
                        {
                            Date = x.DisbursementDate,

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
                    var firstMonthOfTheYear = 1;
                    var lastMonthOfTheYear = 12;

                    /* 
                     * just fill in the gaps if there is any, to complete the month in a year 
                     * displayed in the reports
                     */
                    for (var i = firstMonthOfTheYear; i <= lastMonthOfTheYear; i++)
                    {
                        if (!collections.Exists(l => l.Date.Month == i))
                            collections.Add(new YearlyCollection() { Date = new DateTime(_view.Date.Year, i, 1) });

                        if (!disbursements.Exists(l => l.Date.Month == i))
                            disbursements.Add(new YearlyDisbursement() { Date = new DateTime(_view.Date.Year, i, 1) });
                    }

                    //var disbursementSummary =
                    //    from disbursement in disbursements
                    //    orderby disbursement.Date
                    //    group disbursement by disbursement.Month into disbursementPerMonth
                    //    select new
                    //    {
                    //        Month = disbursementPerMonth.Key,
                    //        TotalDisbursement = disbursementPerMonth.Sum(d => d.Total)
                    //    };

                    //var collectionSummary =
                    //    from collection in collections
                    //    orderby collection.Date
                    //    group collection by collection.Month into collectionPerMonth
                    //    select new
                    //    {
                    //        Month = collectionPerMonth.Key,
                    //        TotalCollection = collectionPerMonth.Sum(c => c.Total)
                    //    };

                    //var consolidatedSummary =
                    //    from collection in collectionSummary
                    //    join disbursement in disbursementSummary
                    //        on collection.Month equals disbursement.Month
                    //    select new YearlyCashFlow()
                    //    {
                    //        Month = collection.Month,
                    //        TotalCollection = collection.TotalCollection,
                    //        TotalDisbursement = disbursement.TotalDisbursement
                    //    };

                    ////// "GroupBy" query operator is not readable
                    ////var collectionSummary = collections
                    ////    .GroupBy(d => 
                    ////        d.Month, 
                    ////        d => new { Month = d.Month, Total = d.Total })
                    ////    .Select(g => new
                    ////    {
                    ////        Month = g.Key,
                    ////        TotalDisbursement = g.Sum(d => d.Total)
                    ////    });


                    var disbursementSummary = disbursements
                        .OrderBy(x => x.Date)
                        .GroupBy(x => x.Month)
                        .Select(x => new
                        {
                            Month = x.Key,
                            TotalDisbursement = x.Sum(d => d.Total)
                        });

                    var collectionSummary = collections
                        .OrderBy(x => x.Date)
                        .GroupBy(x => x.Month)
                        .Select(x => new
                        {
                            Month = x.Key,
                            TotalCollection = x.Sum(c => c.Total)
                        });

                    var consolidatedSummary = collectionSummary
                        .Join(disbursementSummary,
                            (x) => x.Month,
                            (x) => x.Month,
                            (x, y) => new { Month = x.Month, Collections = x, Disbursements = y }
                        )
                        .Select(x => new YearlyCashFlow()
                        {
                            Month = x.Month,
                            TotalCollection = x.Collections.TotalCollection,
                            TotalDisbursement = x.Disbursements.TotalDisbursement
                        });

                    var cashFlows = consolidatedSummary.ToList();
                    _view.PopulateReports(cashFlows);
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
