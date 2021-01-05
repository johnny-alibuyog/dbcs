using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Reports.MemberPeriodicalBalanceSummaries
{
    public class PeriodicalBalancePresenter : PresenterTemplate
    {
        private IPeriodicalBalancesView _view;

        public PeriodicalBalancePresenter(IPeriodicalBalancesView view)
        {
            _view = view;
        }

        public void InitializeView()
        {
            var loadOptions = new DataLoadOptions();
            loadOptions.LoadWith<Quarter>(x => x.Months);

            var db = new DataContextFactory().CreateDataContext();
            db.LoadOptions = loadOptions;

            var quarters = db.GetTable<Quarter>().ToList();

            _view.PopulateQuarters(quarters);
            _view.MonthlyBalanceDate = DateTime.Today;
            _view.QuarterlyBalanceYear = DateTime.Today.Year;
            _view.QuarterlyBalanceQuarter = quarters.FirstOrDefault();
            _view.YearlyBalanceYear = DateTime.Today.Year;
        }
    }
}
