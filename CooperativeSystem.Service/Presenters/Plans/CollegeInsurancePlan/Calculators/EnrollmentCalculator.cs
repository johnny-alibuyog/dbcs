using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan.Calculators
{
    internal class EnrollmentCalculator
    {
        private DateTime _applicationDate;
        private PaymentMode _paymentMode;

        // TODO: check with the client if should be considered to be included in configurations
        private const int PAYMENT_PERIOD_IN_YEARS = 5;
        private const int MATURITY_PERIOD_IN_YEARS = PAYMENT_PERIOD_IN_YEARS + 5;

        private const decimal PAYMENT_AMOUNT_PER_DAY = 10.00M;
        private const decimal AWARD_AMOUNT = 36000.00M;

        public EnrollmentCalculator(DateTime applicationDate, PaymentMode paymentMode)
        {
            _applicationDate = applicationDate;
            _paymentMode = paymentMode;
        }

        public void RenewComputation(DateTime applicationDate, PaymentMode paymentMode)
        {
            _applicationDate = applicationDate;
            _paymentMode = paymentMode;
        }

        public DateTime ComputeMaturityDate()
        {
            return _applicationDate.AddYears(MATURITY_PERIOD_IN_YEARS);
        }

        public decimal ComputeMaturityAmount()
        {
            var coveredPeriodInDays = (_applicationDate.AddYears(PAYMENT_PERIOD_IN_YEARS) - _applicationDate).Days;
            return PAYMENT_AMOUNT_PER_DAY * coveredPeriodInDays;
        }

        public decimal ComputeAmortization()
        {
            return PAYMENT_AMOUNT_PER_DAY * _paymentMode.Days;
        }

        public decimal ComputeAwardAmount()
        {
            return AWARD_AMOUNT;
        }
    }
}
