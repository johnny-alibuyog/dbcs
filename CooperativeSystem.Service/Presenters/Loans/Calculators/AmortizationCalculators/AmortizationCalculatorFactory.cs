using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Presenters.Lookups.DeductionTypes;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.AmortizationCalculators
{
    internal class AmortizationCalculatorFactory
    {
        public IAmortizationCalculator CreateAmortizationCalculator(string loanDeductionTypeID)
        {
            IAmortizationCalculator calculator = null;
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
