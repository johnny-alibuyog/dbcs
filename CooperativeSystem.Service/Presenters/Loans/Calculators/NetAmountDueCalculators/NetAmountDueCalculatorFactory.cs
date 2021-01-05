using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Presenters.Lookups.DeductionTypes;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.NetAmountDueCalculators
{
    internal class NetAmountDueCalculatorFactory
    {
        public INetAmountDueCalculator CreateNetAmountDueCalculator(string loanDeductionTypeID)
        {
            INetAmountDueCalculator calculator = null;
            switch (loanDeductionTypeID)
            {
                case LoanDeductionTypeCodes.AddOn:
                    calculator = new AddOnCalculator();
                    break;
                case LoanDeductionTypeCodes.Deducted:
                    calculator = new DeductedCalculator();
                    break;
            }
            return calculator;
        }
    }
}
