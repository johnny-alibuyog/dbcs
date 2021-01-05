using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Loans.Calculators.FineCalculators;
using CooperativeSystem.Service.Presenters.Lookups.PaymentModes;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.FineCalculators
{
    internal class DelayedPaymentFineCalculator : IFineCalculator
    {
        public FineComputationRate FineComputationRate { get; set; }

        public DelayedPaymentFineCalculator(FineComputationRate fineComputationRate)
        {
            FineComputationRate = fineComputationRate;
        }

        #region IFineCalculator Members

        public FineDetails ComputeFine(Loan loan)
        {
            loan.FineComputationRate = FineComputationRate;

            if (loan.Settled)
                return null;

            if (!loan.IsDelayed)
                return null;

            var fineDetials = new FineDetails();
            fineDetials.Loan = loan;
            fineDetials.DueDate = loan.NextPaymentDueDate;
            fineDetials.Days = loan.DaysDelayed;
            fineDetials.Amount = loan.DelayedPaymentFine;
            return fineDetials;

            //FineDetails fineDetials = null;
            ////var consumedPeriod = (DateTime.Now - loan.NextPaymentDueDate).Days;
            ////var gracePeriod = loan.PaymentMode.GracePeriod;
            ////var isDelayed = (consumedPeriod > gracePeriod && loan.Settled == false);
            //if (loan.IsDelayed)
            //{
            //    var fine = 0M;
            //    var daysInAMonth = 30;
            //    var paymentIntervalInDays = loan.PaymentMode.Days;
            //    var fineComputationRatePerMonth = FineComputationRate.Rate;
            //    var paymentModeRate = (fineComputationRatePerMonth / 100) / (daysInAMonth / paymentIntervalInDays);
            //    //var accumulation = loan.Amortization;

            //    //var loopDate = loan.NextPaymentDueDate;
            //    //var endDate = (DateTime.Now > loan.DueDate ? loan.DueDate : DateTime.Now).TruncateTime();

            //    //var i = 1;
            //    //while (endDate > loopDate)
            //    //{
            //    //    fine += accumulation * paymentModeRate;
            //    //    //Console.WriteLine("Payment for {0}: Accumulation Amount {1}: Fine {2}",
            //    //    //    loopDate.ToShortDateString(), accumulation.ToString(), fine.ToString());
            //    //    accumulation += loan.Amortization;
            //    //    loopDate = loopDate.AddDays(paymentIntervalInDays);
            //    //    Console.WriteLine(i);
            //    //    i++;
            //    //}

            //    var accumulation = 0M;
            //    var finableAmount = outstandingBalance;
            //    var endDate = DateTime.Now > loan.DueDate ? loan.DueDate : DateTime.Now;
            //    var i = 1;
            //    while (finableAmount > 0M)
            //    {
            //        var temp = finableAmount > loan.Amortization
            //            ? loan.Amortization
            //            : finableAmount;

            //        accumulation += temp;
            //        finableAmount -= temp;
            //        fine += accumulation * paymentModeRate;
            //        Console.WriteLine(i);
            //        i++;
            //    }

            //    fineDetials = new FineDetails();
            //    fineDetials.Loan = loan;
            //    fineDetials.DueDate = loan.NextPaymentDueDate;
            //    fineDetials.Days = (endDate - loan.NextPaymentDueDate).Days;
            //    fineDetials.Amount = fine;
            //}
            //return fineDetials;
        }

        //public IList<FineDetails> ComputeFine(IList<Loan> loans)
        //{
        //    IList<FineDetails> finesDetails = null;
        //    var passDueLoans = loans
        //        .Where(l => l.IsDelayed)
        //        .ToList();

        //    foreach (var loan in passDueLoans)
        //    {
        //        if (finesDetails == null)
        //            finesDetails = new List<FineDetails>();
        //        finesDetails.Add(ComputeFine(loan));
        //    }

        //    return finesDetails;
        //}

        #endregion
    }
}
