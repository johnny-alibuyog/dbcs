using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Models
{
    partial class YearlyDividend
    {
        internal void AddDividendComputation(Member member, decimal capitalShareMinimumAmount)
        {
            // consolidate all share transactions
            var dividendShareItems = member.CapitalShare.CapitalShareReceipts
                .Select(x => new DividendShareItem()
                {
                    Date = x.CashReceipt.ReceiptDate,
                    TransactionType = "Receipt",
                    Amount = x.Amount,
                    Balance = x.Balance,
                })
                .Concat(member.CapitalShare.CapitalShareAdjustments
                .Select(x => new DividendShareItem()
                {
                    Date = x.Adjustment.AdjustmentDate,
                    TransactionType = "Adjustment",
                    Amount = x.Amount,
                    Balance = x.Balance,
                }))
                .Concat(member.CapitalShare.CapitalShareBuildups
                .Select(x => new DividendShareItem()
                {
                    Date = x.CashDisbursement.DisbursementDate,
                    TransactionType = "Buildup",
                    Amount = x.Amount,
                    Balance = x.Balance,
                }))
                .Concat(member.CapitalShare.CapitalShareDisbursements
                .Select(x => new DividendShareItem()
                {
                    Date = x.CashDisbursement.DisbursementDate,
                    TransactionType = "Disbursement",
                    Amount = x.Amount,
                    Balance = x.Balance,
                }))
                .Concat(member.CapitalShare.CapitalSharePatronageRefundAdjustments
                .Select(x => new DividendShareItem()
                {
                    Date = x.Adjustment.AdjustmentDate,
                    TransactionType = "Patronage",
                    Amount = x.Amount,
                    Balance = x.Balance,
                }))
                .Concat(member.CapitalShare.CapitalShareDividendAdjustments
                .Select(x => new DividendShareItem()
                {
                    Date = x.Adjustment.AdjustmentDate,
                    TransactionType = "Dividend",
                    Amount = x.Amount,
                    Balance = x.Balance,
                }))
                .OrderBy(x => x.Date);

            // get share of the year
            var sharesOfTheYear = dividendShareItems
                .Where(x => x.Date.Year == this.Year)
                .OrderBy(x => x.Date)
                .ToList();

            // get first share of the year
            var firstShareOfTheYear = sharesOfTheYear.FirstOrDefault();

            // get last share befor the year
            var lastShareBeforeTheYear = dividendShareItems
                .Where(x => x.Date.Year < this.Year)
                .OrderBy(x => x.Date)
                .LastOrDefault();

            var firstDateOfTheYear = new DateTime(this.Year, 1, 1);
            var lastDateOfTheYear = new DateTime(this.Year, 12, 31);

            // initial share
            var initialShare = new DividendShareItem()
            {
                Date = firstDateOfTheYear,
                TransactionType = "Initial",
                Amount = 0M,
                Balance = (lastShareBeforeTheYear != null) ? lastShareBeforeTheYear.Balance : 0M
            };

            // insert initial share
            sharesOfTheYear.Insert(0, initialShare);

            // check qualification
            var balanceOfTheYear = sharesOfTheYear.Last().Balance;
            if (balanceOfTheYear < capitalShareMinimumAmount)
                return;

            // initialize computational fields
            for (var i = 0; i < sharesOfTheYear.Count; i++)
            {
                var isFirst = (i == 0);
                var isLast = (i == sharesOfTheYear.Count - 1);

                //var previous = (!isFirst) ? sharesOfTheYear[i - 1] : lastShareBeforeThisYear;
                var current = sharesOfTheYear[i];
                var next = (!isLast) ? sharesOfTheYear[i + 1] : null;

                // computational fields
                current.NumberOfDaysUnchanged = ((next != null ? next.Date : lastDateOfTheYear) - current.Date).TotalDays;
                current.MoneyValue = Convert.ToDecimal(current.NumberOfDaysUnchanged) * current.Balance;
            }

            var loansThisYear = member.Loans.Where(x => x.DueDate.Year <= this.Year);

            // initialize relations
            var dividendComputation = new DividendComputation()
            {
                YearlyDividend = this,
                Member = member,
                Creditable = member.IsEntitledForDividendCredit(this.Year)
            };

            dividendComputation.DividendShareItems.AddRange(sharesOfTheYear);
            dividendComputation.AverageShare = dividendComputation.DividendShareItems.Sum(x => x.MoneyValue);

            DividendComputations.Add(dividendComputation);
        }

        internal void DistributeDividends()
        {
            // compute for total average share
            TotalAverageShare = DividendComputations.Sum(dc => dc.AverageShare);

            // distribute dividends
            foreach (var dividendComputation in DividendComputations)
            {
                dividendComputation.Dividend = (dividendComputation.AverageShare * TotalDividendForDistribution) / TotalAverageShare;
            }
        }
    }
}
