using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using System.Data.Linq;

namespace CooperativeSystem.Service.Presenters.Reports.DelinquentAccounts
{
    public class DelinquentLoansHistoryPresenter : PresenterTemplate
    {
        private IDelinquentLoansHistoryView _view;

        public DelinquentLoansHistoryPresenter(IDelinquentLoansHistoryView view)
        {
            _view = view;
            this.PopulatePeriods();
        }

        public virtual void PopulatePeriods()
        {
            using (var context = new DataContextFactory().CreateDataContext())
            {
                var query = context.GetTable<DelinquentLoan>()
                    .OrderByDescending(x => x.Period)
                    .Select(x => x.Period);

                _view.PopulatePeriods(query.ToList());
            }
        }

        public virtual IList<DelinquentAccount> Generate()
        {
            var result = new List<DelinquentAccount>();

            using (var context = new DataContextFactory().CreateDataContext())
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

                result = db.GetTable<Loan>()
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
                    .OrderBy(x => x.Name)
                    .ToList();
            }

            return result;
        }
    }
}
