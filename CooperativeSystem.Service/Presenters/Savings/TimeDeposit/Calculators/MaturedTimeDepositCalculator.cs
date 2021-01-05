using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Presenters.Savings.TimeDeposit.Calculators
{
    internal class MaturedTimeDepositCalculator
    {
        private Member _member;

        public MaturedTimeDepositCalculator(Member member)
        {
            _member = member;
        }

        public IList<MaturedTimeDeposit> GetMaturedTimeDeposits(out string remarks)
        {
            const decimal DAYS_IN_A_MONTH = 30;
            const decimal DAYS_IN_A_YEAR = 365; //365;

            remarks = string.Empty;
            if (_member.TimeDeposits == null)
            {
                remarks = "You do not have time deposit.";
                return null;
            }

            /********************************************************
             * interest = principal x interest rate x terms covered
             ********************************************************/

            var maturedTimeDepositQuery = _member.TimeDeposits
            .Where(td => 
                //td.MaturityDate <= DateTime.Today && 
                td.Consumed == false)
            .Select(td => new MaturedTimeDeposit()
            {
                TimeDepositID = td.TimeDepositID,
                TimeDeposit = td,
                MaturityDate = td.MaturityDate,
                PrincipalAmount = td.TimeDepositAmount,
                Interest = td.TimeDepositAmount *                                               // principal
                    (td.InterestRate / 100) *                                                   // interest rate
                    (td.Terms * DAYS_IN_A_MONTH / DAYS_IN_A_YEAR) *                             // terms
                    (((DateTime.Today - td.DepositDate).Days / DAYS_IN_A_MONTH) / td.Terms)     // number of terms covered
            });

            if (!maturedTimeDepositQuery.Any())
            {
                remarks = "You do not have any time deposit that pass maturity date.";
                return null;
            }

            return maturedTimeDepositQuery.ToList();
        }
    }
}
