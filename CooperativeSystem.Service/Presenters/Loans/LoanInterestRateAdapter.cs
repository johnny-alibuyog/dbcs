using System;
using System.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.PaymentModes;
using System.Collections.Generic;

namespace CooperativeSystem.Service.Presenters.Loans
{
    [Serializable]
    public class LoanInterestRateAdapter
    {
        private LoanInterestRate _daily;
        private LoanInterestRate _weekly;
        private LoanInterestRate _semiMonthly;
        private LoanInterestRate _monthly;

        #region Properties

        public decimal Daily
        {
            get { return _daily.InterestRate; }
            set { _daily.InterestRate = value; }
        }

        public decimal Weekly
        {
            get { return _weekly.InterestRate; }
            set { _weekly.InterestRate = value; }
        }

        public decimal SemiMonthly
        {
            get { return _semiMonthly.InterestRate; }
            set { _semiMonthly.InterestRate = value; }
        }

        public decimal Monthly
        {
            get { return _monthly.InterestRate; }
            set { _monthly.InterestRate = value; }
        }

        #endregion

        #region Constructor

        internal LoanInterestRateAdapter(IList<LoanInterestRate> rates)
        {
            Initialize(rates);
        }

        #endregion

        internal void Initialize(IList<LoanInterestRate> rates)
        {
            _daily = rates.FirstOrDefault(rate => rate.PaymentModeID == PaymentModeCodes.Daily);
            _weekly = rates.FirstOrDefault(rate => rate.PaymentModeID == PaymentModeCodes.Weekly);
            _semiMonthly = rates.FirstOrDefault(rate => rate.PaymentModeID == PaymentModeCodes.SemiMonthly);
            _monthly = rates.FirstOrDefault(rate => rate.PaymentModeID == PaymentModeCodes.Monthly);

            if (_daily == null)
            {
                _daily = new LoanInterestRate();
                _daily.PaymentModeID = PaymentModeCodes.Daily;
                rates.Add(_daily);
            }

            if (_weekly == null)
            {
                _weekly = new LoanInterestRate();
                _weekly.PaymentModeID = PaymentModeCodes.Weekly;
                rates.Add(_weekly);
            }

            if (_semiMonthly == null)
            {
                _semiMonthly = new LoanInterestRate();
                _semiMonthly.PaymentModeID = PaymentModeCodes.SemiMonthly;
                rates.Add(_semiMonthly);
            }

            if (_monthly == null)
            {
                _monthly = new LoanInterestRate();
                _monthly.PaymentModeID = PaymentModeCodes.Monthly;
                rates.Add(_monthly);
            }
        }
    }
}
