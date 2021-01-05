using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models
{
    partial class QuarterlyInterest
    {
        public void AddInterestComputationFor(Member member, decimal maintainingBalance)
        {
            // initialize relations
            var quarterlyInterestComputation = new QuarterlyInterestComputation()
            {
                QuarterlyInterest = this,
                Member = member
            };

            // consolidate saving's quarterly transactions
            var savings = member.SavingsDeposit.SavingsDepositReceipts
                .Select(r => new
                {
                    Date = r.CashReceipt.ReceiptDate,
                    Amount = r.Amount,
                    Balance = r.Balance
                })
                .Concat(member.SavingsDeposit.SavingsDepositAdjustments
                .Select(d => new
                {
                    Date = d.Adjustment.AdjustmentDate,
                    Amount = d.Amount,
                    Balance = d.Balance
                }))
                .Concat(member.SavingsDeposit.SavingsDepositDisbursements
                .Select(d => new
                {
                    Date = d.CashDisbursement.DisbursementDate,
                    Amount = d.Amount,
                    Balance = d.Balance
                }))
                .Concat(member.SavingsDeposit.SavingsDepositDividendAdjustments
                .Select(d => new
                {
                    Date = d.Adjustment.AdjustmentDate,
                    Amount = d.Amount,
                    Balance = d.Balance
                }))
                .Concat(member.SavingsDeposit.SavingsDepositInterestAdjustments
                .Select(d => new
                {
                    Date = d.Adjustment.AdjustmentDate,
                    Amount = d.Amount,
                    Balance = d.Balance
                }))
                .OrderByDescending(x => x.Date);

            // get average monthly balances
            var averageMonthlyBalances = savings
                .Where(x => 
                    x.Date.Year == Year && 
                    Quarter.Months.Any(y => y.MonthID == x.Date.Month))
                .GroupBy(x => x.Date.Month)
                .Select(x => new AverageMonthlyBalance()
                {
                    Date = x.First().Date,
                    Amount = x.First().Balance
                })
                .ToList();

            var months = Quarter.Months
                .OrderByDescending(x => x.MonthID)
                .Select(x => x.MonthID);

            // just to fill in the gaps
            foreach (var month in months)
            {
                var doesntExists = !averageMonthlyBalances.Any(x => x.Date.Month == month);
                if (doesntExists)
                {
                    var date = new DateTime(Year, month, 1);
                    var previousBalance = savings.FirstOrDefault(x => x.Date < date);

                    // check for the previous balance. assign 0M if none
                    var averageMonthlyBalance = new AverageMonthlyBalance();
                    averageMonthlyBalance.Date = date;
                    averageMonthlyBalance.Amount = previousBalance != null ? previousBalance.Balance : 0M;

                    averageMonthlyBalances.Add(averageMonthlyBalance);
                }
            }

            // add the average monthly balances
            quarterlyInterestComputation.AddRangeAverageMonthlyBalance(averageMonthlyBalances, maintainingBalance);

            // add quarterly computation entity
            QuarterlyInterestComputations.Add(quarterlyInterestComputation);
        }
    }
}
