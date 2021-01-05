using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models
{
    partial class QuarterlyInterestComputation
    {
        public void AddRangeAverageMonthlyBalance(IEnumerable<AverageMonthlyBalance> averageMonthlyBalances, decimal maintainingBalance)
        {
            var year = QuarterlyInterest.Year;
            var totalDaysInQuarter = QuarterlyInterest.Quarter.Months
                .Select(x => new { DaysInMonth = DateTime.DaysInMonth(QuarterlyInterest.Year, x.MonthID) })
                .Sum(x => Convert.ToDecimal(x.DaysInMonth));

            var totalDaysInYear = Month.GetAll()
                .Select(x => new { DaysInMonth = DateTime.DaysInMonth(year, x.MonthID) })
                .Sum(x => Convert.ToDecimal(x.DaysInMonth));

            LowestAverageMonthlyBalance = averageMonthlyBalances.Min(x => x.Amount);

            var hasMissedMaintainingBalance = averageMonthlyBalances.Any(x => x.Amount < maintainingBalance);
            if (hasMissedMaintainingBalance)
            {
                Interest = 0M;
            }
            else
            {
                Interest = (LowestAverageMonthlyBalance) * 
                    (QuarterlyInterest.InterestRate / 100) *
                    (totalDaysInQuarter / totalDaysInYear);
            }

            AverageMonthlyBalances.AddRange(averageMonthlyBalances.OrderByDescending(x => x.Date));

            //LowestAverageMonthlyBalance = averageMonthlyBalances.Min(x => x.Amount);
            //Interest = LowestAverageMonthlyBalance * QuarterlyInterest.InterestRate / 100;
            //AverageMonthlyBalances.AddRange(averageMonthlyBalances.OrderByDescending(x => x.Date));
        }
    }
}
