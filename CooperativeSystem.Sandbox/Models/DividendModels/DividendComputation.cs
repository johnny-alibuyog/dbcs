using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Sandbox.Models.DividendModels
{
    public class DividendComputation
    {
        private Member _member;
        private IList<DividendShareItem> _dividendShareItems;
        private Nullable<decimal> _averageShare;
        private Nullable<decimal> _totalAverageShare;
        private Nullable<decimal> _totalDividendForDistribution;
        private Nullable<decimal> _dividend;

        public DividendComputation(int year, Member member, decimal totalDividendForDistribution)
        {
            _member = member;
            _totalDividendForDistribution = new Nullable<decimal>(totalDividendForDistribution);
            _dividendShareItems = new List<DividendShareItem>();

            var sharesThisYear = _member.CapitalShares
                .Where(cs => cs.Date.Value.Year == year)
                .OrderBy(cs => cs.Date.Value)
                .ToList();

            var firstShareThisYear = sharesThisYear.FirstOrDefault();

            var lastShareBeforeThisYear = _member.CapitalShares
                .Where(cs => cs.Date.Value.Year < year)
                .OrderBy(cs => cs.Date)
                .FirstOrDefault();

            var firstDateOfTheYear = new DateTime(year, 1, 1);
            var lastDateOfTheYear = new DateTime(year, 12, 31);

            if (firstShareThisYear == null)
                return;

            // initial share
            var initialShare = new CapitalShare()
            {
                Date = firstDateOfTheYear,
                Amount = 0M,
                Balance = (lastShareBeforeThisYear != null) ? lastShareBeforeThisYear.Balance : 0M
            };
            sharesThisYear.Insert(0, initialShare);

            for (var i = 0; i < sharesThisYear.Count; i++)
            {
                var isFirst = (i == 0);
                var isLast = (i == sharesThisYear.Count -1);

                var previous = (!isFirst) ? sharesThisYear[i - 1] : lastShareBeforeThisYear;
                var current = sharesThisYear[i];
                var next = (!isLast) ? sharesThisYear[i + 1] : null;

                var item = new DividendShareItem();

                item.Date = current.Date.Value;
                item.AmountReceived = current.Amount.Value;
                item.Balance = current.Balance.Value;
                item.NumberOfDaysUnchanged = ((next != null ? next.Date.Value : lastDateOfTheYear) - item.Date).TotalDays;

                //if (isLast)
                //{
                //    item.Date = current.Date.Value;
                //    item.AmountReceived = current.Amount.Value;
                //    item.Balance = current.Balance.Value;
                //    item.NumberOfDaysUnchanged = ((next != null ? next.Date.Value : lastDateOfTheYear) - item.Date).TotalDays;
                //}
                //else
                //{
                //    item.Date = current.Date.Value;
                //    item.AmountReceived = current.Amount.Value;
                //    item.Balance = current.Balance.Value;
                //    item.NumberOfDaysUnchanged = ((next != null ? next.Date.Value : lastDateOfTheYear) - item.Date).TotalDays;
                //}
                _dividendShareItems.Add(item);
            }
        }

        public virtual Member Member
        {
            get { return _member; }
            //set { _member = value; }
        }

        public virtual IList<DividendShareItem> DividendShareItems
        {
            get { return _dividendShareItems; }
            //set { _dividendShareItems = value; }
        }

        public virtual Nullable<decimal> AverageShare
        {
            get 
            {
                if (_averageShare == null)
                    _averageShare = DividendShareItems.Sum(dsi => dsi.PesoValue) * 12;
                return _averageShare;
            }
            //set { _averageShare = value; }
        }

        public virtual Nullable<decimal> TotalAverageShare
        {
            get { return _totalAverageShare; }
            set { _totalAverageShare = value; }
        }

        public virtual Nullable<decimal> TotalDividendForDistribution
        {
            get { return _totalDividendForDistribution; }
            //set { _totalDividendForDistribution = value; }
        }

        public virtual Nullable<decimal> Dividend
        {
            get 
            { 
                if (_dividend == null)
                    _dividend = _averageShare * _totalDividendForDistribution / _totalAverageShare;
                return _dividend; 
            }
            //set { _dividend = value; }
        }
    }
}
