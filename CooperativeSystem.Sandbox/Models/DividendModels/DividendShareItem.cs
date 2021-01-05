using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Sandbox.Models.DividendModels
{
    public class DividendShareItem
    {
        private DateTime _date;
        private decimal _amountReceived;
        private decimal _balance;
        //private decimal _pesoValue;
        private double _numberOfDaysUnchanged;

        public virtual DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public virtual decimal AmountReceived
        {
            get { return _amountReceived; }
            set { _amountReceived = value; }
        }

        public virtual decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public virtual decimal PesoValue
        {
            get { return Convert.ToDecimal(NumberOfDaysUnchanged) * Balance; }
            //set { _pesoValue = value; }
        }

        public virtual double NumberOfDaysUnchanged
        {
            get { return _numberOfDaysUnchanged; }
            set { _numberOfDaysUnchanged = value; }
        }
    }
}
