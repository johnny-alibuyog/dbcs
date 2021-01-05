using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Sandbox.Models.DividendModels
{
    public class YearlyDividends
    {
        private int _year;
        private IList<DividendComputation> _dividendComputations;

        private YearlyDividends(int year)
        {
            _year = year;
            _dividendComputations = new List<DividendComputation>();
        }

        public virtual int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public virtual IList<DividendComputation> DividendComputations
        {
            get { return _dividendComputations; }
            set { _dividendComputations = value; }
        }
    }
}
