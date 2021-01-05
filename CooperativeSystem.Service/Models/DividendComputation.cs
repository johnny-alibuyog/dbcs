using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Presenters.Lookups.Services;

namespace CooperativeSystem.Service.Models
{
    partial class DividendComputation
    {
        partial void OnCreated()
        {
            _DepositoryServiceID = ServiceCodes.CapitalShare;
        }

        ///// <summary>
        ///// Get dividend computation for a member
        ///// </summary>
        ///// <param name="yearlyDividend"></param>
        ///// <param name="member"></param>
        ///// <returns></returns>
        //public static DividendComputation GetDividendComputation(YearlyDividend yearlyDividend, Member member)
        //{
        //    // initialize relations
        //    var dividendComputation = new DividendComputation()
        //    {
        //        YearlyDividend = yearlyDividend,
        //        Member = member
        //    };

        //    // consolidate all share transactions
        //    var dividendShareItems = member.CapitalShare.CapitalShareReceipts
        //        .Select(csr => new DividendShareItem()
        //        {
        //            Date = csr.CashReceipt.ReceiptDate,
        //            TransactionType = "Receipt",
        //            Amount = csr.Amount,
        //            Balance = csr.Balance,
        //        })
        //        .Union(member.CapitalShare.CapitalShareDisbursements
        //        .Select(csd => new DividendShareItem()
        //        {
        //            Date = csd.CashDisbursement.DisbursementDate,
        //            TransactionType = "Disbursement",
        //            Amount = csd.Amount,
        //            Balance = csd.Balance,
        //        })
        //        .Union(member.CapitalShare.PatronageRefundAdjustments
        //        .Select(pra => new DividendShareItem()
        //        {
        //            Date = pra.Adjustment.AdjustmentDate,
        //            TransactionType = "Adjustment",
        //            Amount = pra.Amount,
        //            Balance = pra.Balance,
        //        })
        //        .Union(member.CapitalShare.DividendAdjustments
        //        .Select(da => new DividendShareItem()
        //        {
        //            Date = da.Adjustment.AdjustmentDate,
        //            TransactionType = "Adjustment",
        //            Amount = da.Amount,
        //            Balance = da.Balance,
        //        }))))
        //        .OrderBy(dsi => dsi.Date);


        //    // get share of the year
        //    var sharesOfTheYear = dividendShareItems
        //        .Where(cs => cs.Date.Year == yearlyDividend.Year)
        //        .OrderBy(cs => cs.Date)
        //        .ToList();

        //    // get first share of the year
        //    var firstShareOfTheYear = sharesOfTheYear.FirstOrDefault();

        //    // get last share befor the year
        //    var lastShareBeforeTheYear = dividendShareItems
        //        .Where(cs => cs.Date.Year < yearlyDividend.Year)
        //        .OrderBy(cs => cs.Date)
        //        .FirstOrDefault();

        //    var firstDateOfTheYear = new DateTime(yearlyDividend.Year, 1, 1);
        //    var lastDateOfTheYear = new DateTime(yearlyDividend.Year, 12, 31);

        //    // initial share
        //    var initialShare = new DividendShareItem()
        //    {
        //        Date = firstDateOfTheYear,
        //        TransactionType = "Initial",
        //        Amount = 0M,
        //        Balance = (lastShareBeforeTheYear != null) ? lastShareBeforeTheYear.Balance : 0M
        //    };

        //    // insert initial share
        //    sharesOfTheYear.Insert(0, initialShare);

        //    // initialize computational fields
        //    for (var i = 0; i < sharesOfTheYear.Count; i++)
        //    {
        //        var isFirst = (i == 0);
        //        var isLast = (i == sharesOfTheYear.Count - 1);

        //        //var previous = (!isFirst) ? sharesOfTheYear[i - 1] : lastShareBeforeThisYear;
        //        var current = sharesOfTheYear[i];
        //        var next = (!isLast) ? sharesOfTheYear[i + 1] : null;

        //        // computational fields
        //        current.NumberOfDaysUnchanged = ((next != null ? next.Date : lastDateOfTheYear) - current.Date).TotalDays;
        //        current.MoneyValue = Convert.ToDecimal(current.NumberOfDaysUnchanged) * current.Balance;
        //    }
        //    dividendComputation.DividendShareItems.AddRange(sharesOfTheYear);
        //    dividendComputation.AverageShare = dividendComputation.DividendShareItems
        //        .Sum(dsi => dsi.MoneyValue);

        //    return dividendComputation;
        //}
    }
}
