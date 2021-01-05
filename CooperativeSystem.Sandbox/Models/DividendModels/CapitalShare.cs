using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Sandbox.Models.DividendModels
{
    public class CapitalShare
    {
        private Nullable<DateTime> _date;
        private Nullable<decimal> _amount;
        private Nullable<decimal> _balance;

        public virtual Nullable<DateTime> Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public virtual Nullable<decimal> Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public virtual Nullable<decimal> Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

    }
}
