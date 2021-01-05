using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.Services;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.ServiceFeeCalculators
{
    internal class ServiceFeeCalculatorFactory
    {
        public ServiceFeeCalculatorTemplate CreateServiceFeeCalculator(string loanServiceID, DataContext db, Member member)
        {
            ServiceFeeCalculatorTemplate serviceFeeCalculator = null;
            switch (loanServiceID)
            {
                case ServiceCodes.ApplianceLoan:
                    serviceFeeCalculator = new ApplianceLoanCalculator(db, member);
                    break;
                case ServiceCodes.EasyLoan:
                    serviceFeeCalculator = new EasyLoanCalculator(db, member);
                    break;
                case ServiceCodes.EmergencyLoan:
                    serviceFeeCalculator = new EmergencyLoanCalculator(db, member);
                    break;
                case ServiceCodes.EquityLoan:
                    serviceFeeCalculator = new EquityLoanCalculator(db, member);
                    break;
                case ServiceCodes.PensionLoan:
                    serviceFeeCalculator = new PensionLoanCalculator(db, member);
                    break;
                case ServiceCodes.RegularLoan:
                    serviceFeeCalculator = new RegularLoanCalculator(db, member);
                    break;
            }
            return serviceFeeCalculator;
        }
    }
}
