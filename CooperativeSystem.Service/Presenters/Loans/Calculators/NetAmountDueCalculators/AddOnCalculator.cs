using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Loans.Calculators.ServiceFeeCalculators;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.NetAmountDueCalculators
{
    internal class AddOnCalculator : INetAmountDueCalculator
    {
        #region ICalculator Members

        public decimal CalculateNetAmountDue(decimal loanAmount, ServiceFees serviceFees, decimal outstandingBalance)
        {
            return loanAmount - outstandingBalance;
        }

        #endregion
    }
}
