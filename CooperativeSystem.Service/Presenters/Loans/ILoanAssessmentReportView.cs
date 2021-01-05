using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Loans
{
    public interface ILoanAssessmentReportView
    {
        void Populate(IList<LoanAssessmentReportModel> items);
    }
}
