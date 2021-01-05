using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.Services;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.MaxLoanAmountCalculators
{
    internal class MaxLoanAmountCalculatorFactory
    {
        public MaxLoanAmountCalculatorTemplate CreateMaxLoanAmountCalculator(string loanServiceID, DataContext db, Member member)
        {
            MaxLoanAmountCalculatorTemplate calculator = null;
            switch (loanServiceID)
            {
                case ServiceCodes.ApplianceLoan:
                    calculator = new ApplianceLoanCalculator(db, member);
                    break;
                case ServiceCodes.EasyLoan:
                    calculator = new EasyLoanCalculator(db, member);
                    break;
                case ServiceCodes.EmergencyLoan:
                    calculator = new EmergencyLoanCalculator(db, member); ;
                    break;
                case ServiceCodes.EquityLoan:
                    calculator = new EquityLoanCalculator(db, member); ;
                    break;
                case ServiceCodes.PensionLoan:
                    calculator = new PensionLoanCalculator(db, member);
                    break;
                case ServiceCodes.RegularLoan:
                    calculator = new RegularLoanCalculator(db, member);
                    break;
            }
            return calculator;
        }
    }
}
