using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using System.Data.Linq;

namespace CooperativeSystem.Service.Presenters.Reports.AgingLoans
{
    public class AgingLoansHistoryPresenter : PresenterTemplate
    {
        private IAgingLoansHistoryView _view;

        public AgingLoansHistoryPresenter(IAgingLoansHistoryView view)
        {
            _view = view;
            this.PopulatePeriods();
        }

        public virtual void PopulatePeriods()
        {
            using (var context = new DataContextFactory().CreateDataContext())
            {
                var query = context.GetTable<AgingLoan>()
                    .OrderByDescending(x => x.Period)
                    .Select(x => x.Period);

                _view.PopulatePeriods(query.ToList());
            }
        }

        public virtual IList<AgingLoanModel> Generate()
        {
            var result = new List<AgingLoanModel>();

            using (var context = new DataContextFactory().CreateDataContext())
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<AgingLoan>(x => x.AgingLoanItems);

                var agingLoan = context.GetTable<AgingLoan>()
                    .FirstOrDefault(x => x.Period == _view.Period);

                if (agingLoan != null)
                {
                    result = agingLoan.AgingLoanItems
                        .Select(x => new AgingLoanModel(x))
                        .ToList();
                }
            }

            return result;
        }
    }
}
