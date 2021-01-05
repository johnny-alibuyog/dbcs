using System;
using System.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.PaymentModes;

namespace CooperativeSystem.Service.Presenters.Lookups.GracePeriods
{
    [Serializable]
    public class GracePeriodAdapter
    {
        private IRepository<PaymentMode> _repository;

        private PaymentMode _daily;
        private PaymentMode _weekly;
        private PaymentMode _semiMonthly;
        private PaymentMode _monthly;

        #region Properties

        public int Daily 
        {
            get { return _daily.GracePeriod; }
            set { _daily.GracePeriod = value; }
        }

        public int Weekly
        {
            get { return _weekly.GracePeriod; }
            set { _weekly.GracePeriod = value; }
        }

        public int SemiMonthly
        {
            get { return _semiMonthly.GracePeriod; }
            set { _semiMonthly.GracePeriod = value; }
        }

        public int Monthly
        {
            get { return _monthly.GracePeriod; }
            set { _monthly.GracePeriod = value; }
        }

        #endregion

        #region Constructor

        public GracePeriodAdapter()
            : this(new GenericRepository<PaymentMode>()) { }

        internal GracePeriodAdapter(IRepository<PaymentMode> repository)
        {
            Initialize(repository);
        }

        #endregion

        internal void Initialize(IRepository<PaymentMode> repository)
        {
            _repository = repository;
            var paymentModes = repository.GetAll();

            _daily = paymentModes.FirstOrDefault(mode => mode.PaymentModeID == PaymentModeCodes.Daily);
            _weekly = paymentModes.FirstOrDefault(mode => mode.PaymentModeID == PaymentModeCodes.Weekly);
            _semiMonthly = paymentModes.FirstOrDefault(mode => mode.PaymentModeID == PaymentModeCodes.SemiMonthly);
            _monthly = paymentModes.FirstOrDefault(mode => mode.PaymentModeID == PaymentModeCodes.Monthly);

            if (_daily == null)
            {
                _daily = repository.CreateEntity();
                _daily.PaymentModeID = PaymentModeCodes.Daily;
            }

            if (_weekly == null)
            {
                _weekly = repository.CreateEntity();
                _weekly.PaymentModeID = PaymentModeCodes.Weekly;
            }

            if (_semiMonthly == null)
            {
                _semiMonthly = repository.CreateEntity();
                _semiMonthly.PaymentModeID = PaymentModeCodes.SemiMonthly;
            }

            if (_monthly == null)
            {
                _monthly = repository.CreateEntity();
                _monthly.PaymentModeID = PaymentModeCodes.Monthly;
            }
        }

        public void Save()
        {
            _repository.SaveAll();
        }
    }
}
