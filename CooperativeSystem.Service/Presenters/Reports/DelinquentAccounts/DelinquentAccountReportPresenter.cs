using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using System.Data.Linq;

namespace CooperativeSystem.Service.Presenters.Reports.DelinquentAccounts
{
    public class DelinquentAccountReportPresenter : PresenterTemplate
    {
        private IDelinquentAccountReportView _view;

        public DelinquentAccountReportPresenter(IDelinquentAccountReportView view)
        {
            _view = view;
        }

        public bool PopulateReports()
        {
            try
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Loan>(x => x.LoanReceipts);
                loadOptions.LoadWith<Loan>(x => x.LoanAdjustments);
                loadOptions.LoadWith<Loan>(x => x.LoanDividendAdjustments);
                loadOptions.LoadWith<LoanReceipt>(x => x.CashReceipt);
                loadOptions.LoadWith<LoanDividendAdjustment>(x => x.Adjustment);

                var db = new DataContextFactory().CreateDataContext();
                db.LoadOptions = loadOptions;

                var rate = db.GetTable<FineComputationRate>().First();

                var delinquentAccounts = db.GetTable<Loan>()
                    .Where(x =>
                        x.Settled == false &&
                        x.DueDate < DateTime.Today
                    )
                    .Select(x => new DelinquentAccount(x, rate)
                    {
                        Name = x.Member.LastName + ", " + x.Member.FirstName + " " + x.Member.MiddleName,
                        CapitalShare = x.Member.CapitalShare != null ? x.Member.CapitalShare.CurrentBalance : 0M,
                        SavingsDeposit = x.Member.SavingsDeposit != null ? x.Member.SavingsDeposit.CurrentBalance : 0M,
                        TimeDeposit = x.Member.TimeDeposits.Where(o => !o.Consumed).Sum(o => o.CurrentBalance),
                        LastPayment = x.LoanReceipts.Max(o => o.CashReceipt.ReceiptDate),
                    })
                    .OrderBy(da => da.Name)
                    .ToList();

                var totalCapitalShare = delinquentAccounts
                    .GroupBy(x => x.Name)
                    .Sum(x => x.First().CapitalShare ?? 0M);

                var totalSavingsDeposit = delinquentAccounts
                    .GroupBy(x => x.Name)
                    .Sum(x => x.First().SavingsDeposit ?? 0M);

                var totalTimeDeposit = delinquentAccounts
                    .GroupBy(x => x.Name)
                    .Sum(x => x.First().TimeDeposit ?? 0M);

                var totalOutstandingBalance = delinquentAccounts
                    .Sum(x => x.OutstandingBalance ?? 0M);

                var totalNetExposure = delinquentAccounts
                    .GroupBy(x => x.Name)
                    .Sum(x =>
                        (x.First().CapitalShare ?? 0M) +
                        (x.First().SavingsDeposit ?? 0M) +
                        (x.First().TimeDeposit ?? 0M) -
                        (x.Sum(o => o.OutstandingBalance ?? 0M))
                    );

                _view.PopulateReports(delinquentAccounts, totalCapitalShare, totalSavingsDeposit, totalTimeDeposit, totalOutstandingBalance, totalNetExposure);

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
