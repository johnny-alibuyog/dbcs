using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Loans.Calculators.ServiceFeeCalculators;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.AmortizationCalculators
{
    internal class DeductedCalculator : IAmortizationCalculator
    {
        #region IAmortizationCalculator Members

        public decimal CalculateAmortization(decimal loanAmount, ServiceFees serviceFees, PaymentMode paymentMode, int terms)
        {
            //var payableAmount = loanAmount - outstandingBalance - serviceFees.Total;
            //var totalCoveredPeriodInDays = (dueDate - loanDate).Days;
            //var totalNumberOfPayments = (totalCoveredPeriodInDays / paymentIntervalsInDays);
            //return payableAmount / totalNumberOfPayments;

            var payableAmount = loanAmount;
            var totalNumberOfPayments = paymentMode.LoanPaymentsPerMonth * terms;
            return payableAmount / totalNumberOfPayments;
        }

        #endregion
    }
}
