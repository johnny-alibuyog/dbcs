using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Loans.Calculators.ServiceFeeCalculators;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.AmortizationCalculators
{
    interface IAmortizationCalculator
    {
        decimal CalculateAmortization(decimal loanAmount, ServiceFees serviceFees, PaymentMode paymentMode, int terms);
    }
}
