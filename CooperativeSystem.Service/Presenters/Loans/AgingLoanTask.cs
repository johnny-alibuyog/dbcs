using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CooperativeSystem.Service.Models;
using System.Data.Linq;
using CooperativeSystem.Service.Presenters.Reports.AgingLoans;

namespace CooperativeSystem.Service.Presenters.Loans
{
    public class AgingLoanTask : ITask
    {
        public void Execute()
        {
            using (var dataContext = new DataContextFactory().CreateDataContext())
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Loan>(x => x.LoanReceipts);
                loadOptions.LoadWith<Loan>(x => x.LoanAdjustments);
                loadOptions.LoadWith<Loan>(x => x.LoanDividendAdjustments);
                loadOptions.LoadWith<Loan>(x => x.Service);
                loadOptions.LoadWith<LoanReceipt>(x => x.CashReceipt);
                loadOptions.LoadWith<LoanDividendAdjustment>(x => x.Adjustment);
                dataContext.LoadOptions = loadOptions;

                var period = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddDays(-1);
                var agingLoan = dataContext.GetTable<AgingLoan>().FirstOrDefault(x => x.Period == period);
                if (agingLoan != null)
                    return;

                var rate = dataContext.GetTable<FineComputationRate>().First();
                var items = dataContext.GetTable<Loan>()
                    .Where(x => x.Settled == false)
                    .Select(x => new AgingLoanModel(x, rate))
                    .ToList();

                agingLoan = new AgingLoan();
                agingLoan.Period = period;
                agingLoan.CreatedOn = DateTime.Today;
                agingLoan.AgingLoanItems.AddRange(items
                    .Select(x => new AgingLoanItem()
                    {
                        Name = x.Name,
                        AgeInDays = x.AgeInDays,
                        AgeInMonths = x.AgeInMonths,
                        AgeGroupInDays = x.AgeGroupInDays,
                        LoanType = x.LoanType,
                        LoanHasAged = x.LoanHasAged,
                        CurrentPayables = x.CurrentPayables,
                        OutstandingBalance = x.OutstandingBalance,
                        AgedPayables = x.AgedPayables,
                        GoodPayables = x.GoodPayables,
                        LatePaymentFine = x.LatePaymentFine,
                        DelinquentCharge = x.DelinquentCharge,
                        LoanDate = x.LoanDate,
                        LastPaymentDate = x.LastPaymentDate,
                        DueDate = x.DueDate,
                    })
                    .OrderBy(x => x.Name)
                );

                dataContext.GetTable<AgingLoan>().InsertOnSubmit(agingLoan);
                dataContext.SubmitChanges();
            }
        }
    }
}
