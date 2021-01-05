using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.MaxLoanAmountCalculators
{
    internal class EmergencyLoanCalculator : MaxLoanAmountCalculatorTemplate
    {
        private EmergencyLoanServiceRate _serviceRate;

        private EmergencyLoanServiceRate ServiceRate
        {
            get
            {
                if (_serviceRate == null)
                    _serviceRate = Db.GetTable<EmergencyLoanServiceRate>().FirstOrDefault();
                return _serviceRate;
            }
        }

        public EmergencyLoanCalculator(DataContext db, Member member)
            : base(db, member) { }

        internal override decimal ComputeMaxLoanAmount(out string remarks)
        {
            remarks = string.Empty;
            return ServiceRate.MaximumAmount;
        }
    }
}
