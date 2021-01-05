using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.PaymentModes;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.FineCalculators
{
    internal class DelinquentFineCalculator : IFineCalculator
    {
        public FineComputationRate FineComputationRate { get; set; }

        public DelinquentFineCalculator(FineComputationRate fineComputationRate)
        {
            FineComputationRate = fineComputationRate;
        }

        #region FineCalculator Members

        public FineDetails ComputeFine(Loan loan)
        {
            loan.FineComputationRate = FineComputationRate;

            if (loan.Settled)
                return null;

            if (!loan.IsDelinquent)
                return null;

            var fineDetials = new FineDetails();
            fineDetials.Loan = loan;
            fineDetials.DueDate = loan.DueDate;
            fineDetials.Days = loan.DaysDelinquent;
            fineDetials.Amount = loan.DelinquentCharge;
            return fineDetials;

            //FineDetails fineDetails = null;
            //if (loan.IsDelinquent)
            //{
            //    var daysInAMonth = 30;
            //    var paymentIntervalsInDays = loan.PaymentMode.Days;
            //    var daysDelinquent = (DateTime.Now - loan.DueDate).Days;
            //    var termsDelinquent = (daysDelinquent / paymentIntervalsInDays);
            //    var fineComputationRatePerMonth = FineComputationRate.Rate;
            //    var paymentModeRate = (fineComputationRatePerMonth / 100) / (daysInAMonth / paymentIntervalsInDays);
            //    var charge = paymentModeRate * outstandingBalance * termsDelinquent;

            //    //var daysInAMonth = 30;
            //    //var monthsDelinquent = (DateTime.Now - loan.DueDate).Days / daysInAMonth;
            //    //var amortizationPerMonth = loan.Amortization * (daysInAMonth / loan.PaymentMode.Days);
            //    //var fineComputationRatePerMonth = _db.GetTable<FineComputationRate>()
            //    //    .Select(fcr => fcr.Rate)
            //    //    .FirstOrDefault();                
            //    //var charge = monthsDelinquent * (fineComputationRatePerMonth / 100) * amortizationPerMonth;
                
            //    //var daysDelinquent = (DateTime.Now - loan.DueDate).Days;
            //    //var termsDelinquent = (daysDelinquent / paymentIntervalsInDays);
            //    //var fineComputationRatePerMonth = _db.GetTable<FineComputationRate>()
            //    //    .Select(fcr => fcr.Rate)
            //    //    .FirstOrDefault();
            //    //var paymentModeRate = (fineComputationRatePerMonth / 100) / (daysInAMonth / paymentIntervalsInDays);
            //    //var charge = paymentModeRate * loan.Amortization * termsDelinquent;

            //    fineDetails = new FineDetails();
            //    fineDetails.Loan = loan;
            //    fineDetails.DueDate = loan.DueDate;
            //    fineDetails.Days = daysDelinquent;
            //    fineDetails.Amount = charge;
            //}
            //return fineDetails;
        }

        //public IList<FineDetails> ComputeFine(IList<Loan> loans)
        //{
        //    IList<FineDetails> finesDetails = null;
        //    var delinquentLoans = loans
        //        .Where(l => l.IsDelinquent)
        //        .ToList();

        //    foreach (var loan in delinquentLoans)
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
