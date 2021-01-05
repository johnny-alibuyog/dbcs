using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Savings.TimeDeposit.Calculators
{
    internal class InterestRateCalculator
    {
        private TimeDepositInterestRate _timeDepositInterestRates;

        public InterestRateCalculator(TimeDepositInterestRate timeDepositInterestRates)
        {
            _timeDepositInterestRates = timeDepositInterestRates;
        }

        public decimal ComputeInterest(decimal amount)
        {
            var interestRate = 0M;
            if (amount < 50000M)
                interestRate = _timeDepositInterestRates.BelowFiftyThousand;
            else if (amount >= 50000M && amount <= 99000M)
                interestRate = _timeDepositInterestRates.FiftyToNinetyNineThousand;
            else
                interestRate = _timeDepositInterestRates.AboveNinetyNineThousand;
            return interestRate;
        }
    }
}
