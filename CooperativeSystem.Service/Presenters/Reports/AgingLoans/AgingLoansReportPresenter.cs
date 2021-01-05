using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Reports.AgingLoans
{
    public class AgingLoansReportPresenter : PresenterTemplate
    {
        private IAgingLoansReportView _view;

        public AgingLoansReportPresenter(IAgingLoansReportView view)
        {
            _view = view;
        }

        public bool PopulateReports()
        {
            try
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Loan>(x => x.LoanReceipts);
                loadOptions.LoadWith<Loan>(x => x.LoanAdjustments);
                loadOptions.LoadWith<Loan>(x => x.LoanDividendAdjustments);
                loadOptions.LoadWith<Loan>(x => x.Service);
                loadOptions.LoadWith<LoanReceipt>(x => x.CashReceipt);
                loadOptions.LoadWith<LoanDividendAdjustment>(x => x.Adjustment);

                var db = new DataContextFactory().CreateDataContext();
                db.LoadOptions = loadOptions;

                var fineComputationRate = db.GetTable<FineComputationRate>().First();

                //var query = db.GetTable<Loan>()
                //    .Where(x =>
                //        x.Settled == false &&
                //        x.NextPaymentDate != null &&
                //        x.NextPaymentDate.Value < DateTime.Today
                //    )
                //    .Select(x => new AgingLoanModel()
                //    {
                //        Loan = x,
                //        FineComputationRate = fineComputationRate,
                //        Name = x.Member.LastName + ", " + x.Member.FirstName + " " + x.Member.MiddleName
                //    });

                var query = db.GetTable<Loan>()
                    .Where(x => x.Settled == false)
                    .Select(x => new AgingLoanModel(x, fineComputationRate))
                    .ToList();

                _view.PopulateReports(query.OrderBy(x => x.Name).ToList());
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }
    }
}
