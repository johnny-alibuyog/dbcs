using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Presenters.Lookups.Services;

namespace CooperativeSystem.Service.Models
{
    partial class YearlyPatronage
    {
        #region Routine Helpers

        private void InitializeComputationalFields(IEnumerable<PatronageItem> patronagesOfTheYear)
        {
            var firstDateOfTheYear = new DateTime(Year, 1, 1);
            var lastDateOfTheYear = new DateTime(Year, 12, 31);

            var periodicalBalance = 0M;

            // initialize computational fields
            for (var i = 0; i < patronagesOfTheYear.Count(); i++)
            {
                var isFirst = (i == 0);
                var isLast = (i == patronagesOfTheYear.Count() - 1);

                //var current = patronagesOfTheYear[i];
                //var next = (!isLast) ? patronagesOfTheYear[i + 1] : null;
                var current = patronagesOfTheYear.Skip(i).Take(1).Single();
                var next = (!isLast) ? patronagesOfTheYear.Skip(i + 1).Take(1).Single() : null;

                // computational fields
                periodicalBalance += current.Amount;
                current.Balance = periodicalBalance;
                current.NumberOfDaysUnchanged = ((next != null ? next.Date : lastDateOfTheYear) - current.Date).TotalDays;
                current.MoneyValue = Convert.ToDecimal(current.NumberOfDaysUnchanged) * current.Balance;
            }
        }

        #endregion

        internal void AddPatronageComputation(Member member, IEnumerable<Loan> loans)
        {
            // initialize relations
            var patronageComputation = new PatronageComputation()
            {
                YearlyPatronage = this,
                Member = member
            };

            // consolidate equity loan patronages of the year
            var patronagesOfTheYear = loans
                .OrderBy(x => x.LoanServiceID)
                .ThenBy(x => x.SettlementDate)
                .Select(x => new PatronageItem()
                {
                    Date = x.SettlementDate.Value,
                    LoanServiceID = x.LoanServiceID,
                    Amount = x.Interest // x.LoanAmount
                })
                .ToList();

            var equtiyPatronagesOfTheYear = patronagesOfTheYear
                .Where(x => x.LoanServiceID == ServiceCodes.EquityLoan);

            var regularPatronagesOfTheYear = patronagesOfTheYear
                .Where(x => x.LoanServiceID == ServiceCodes.RegularLoan);

            InitializeComputationalFields(equtiyPatronagesOfTheYear);
            InitializeComputationalFields(regularPatronagesOfTheYear);

            patronageComputation.PatronageItems.AddRange(patronagesOfTheYear);
            patronageComputation.AveragePatronage = patronageComputation.PatronageItems
                .Sum(dsi => dsi.MoneyValue);

            PatronageComputations.Add(patronageComputation);
        }

        internal void DistributePatronageRefunds()
        {
            // compute for total average patronage
            TotalAveragePatronage = PatronageComputations.Sum(dc => dc.AveragePatronage);

            // distribute patronage refund
            foreach (var patronageComputation in PatronageComputations)
            {
                patronageComputation.PatronageRefund =
                    (patronageComputation.AveragePatronage * TotalPatronageForRefund) / TotalAveragePatronage;
            }
        }
    }
}
