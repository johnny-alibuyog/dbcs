using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Reports.DelinquentAccounts;

namespace CooperativeSystem.Service.Presenters.Loans
{
    public class DelinquentLoanTask : ITask
    {
        public void Execute()
        {
            using (var context = new DataContextFactory().CreateDataContext())
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Loan>(x => x.LoanReceipts);
                loadOptions.LoadWith<Loan>(x => x.LoanAdjustments);
                loadOptions.LoadWith<Loan>(x => x.LoanDividendAdjustments);
                loadOptions.LoadWith<LoanReceipt>(x => x.CashReceipt);
                loadOptions.LoadWith<LoanDividendAdjustment>(x => x.Adjustment);
                context.LoadOptions = loadOptions;

                var period = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddDays(-1);
                var delinquentLoan = context.GetTable<DelinquentLoan>().FirstOrDefault(x => x.Period == period);
                if (delinquentLoan != null)
                    return;

                var rate = context.GetTable<FineComputationRate>().First();
                var items = context.GetTable<Loan>()
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

                delinquentLoan = new DelinquentLoan();
                delinquentLoan.Period = period;
                delinquentLoan.CreatedOn = DateTime.Today;
                delinquentLoan.DelinquentLoanItems.AddRange(items
                    .Select(x => new DelinquentLoanItem()
                    {
                        Name = x.Name,
                        LoanType = x.LoanType,
                        OutstandingBalance = x.OutstandingBalance,
                        DelinquentCharge = x.DelinquentCharge,
                        LatePaymentFine = x.LatePaymentFine,
                        CapitalShare = x.CapitalShare,
                        SavingsDeposit = x.SavingsDeposit,
                        TimeDeposit = x.TimeDeposit,
                        NetExposure = x.NetExposure,
                        LoanDate = x.LoanDate,
                        LastPayment = x.LastPayment,
                        DueDate = x.DueDate
                    })
                    .OrderBy(x => x.Name)
                );

                context.GetTable<DelinquentLoan>().InsertOnSubmit(delinquentLoan);
                context.SubmitChanges();
            }
        }
    }
}
