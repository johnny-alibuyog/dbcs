using System;
using System.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;
using System.Data.Linq;
using CooperativeSystem.Service.Presenters.Lookups.ServiceCategories;
using System.Collections.Generic;
using CooperativeSystem.Service.Presenters.Loans.Calculators;

namespace CooperativeSystem.Service.Presenters.Loans
{
    internal class LoanAssessmentRepository : GenericRepository<Member>, IRepository<Member>
    {
        private readonly LoanAssessmentCalculator _calculator;

        internal LoanAssessmentRepository(DataContext db, long memberId, string loanServiceId, DateTime loanDate) 
            : base(db)
        {
            _calculator = new LoanAssessmentCalculator(Db, memberId, loanServiceId, loanDate);
        }

        internal LoanAssessmentModel GetAssessment(string paymentModeId, string deductionTypeId, int terms, decimal interestRate, decimal loanAmount, out string remarks)
        {
            return _calculator.AssessLoan(paymentModeId, deductionTypeId, terms, interestRate, loanAmount, out remarks);
        }
    }
}