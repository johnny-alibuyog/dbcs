using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.MemberBalanceSummaries
{
    public class MemberBalanceSummaryItem
    {
        private string _member;
        private string _serviceCategory;
        private string _service;
        private decimal _balance;

        public virtual string Member
        {
            get { return _member; }
            internal set { _member = value; }
        }

        public virtual string ServiceCategory
        {
            get { return _serviceCategory; }
            internal set { _serviceCategory = value; }
        }

        public virtual string Service
        {
            get { return _service; }
            internal set { _service = value; }
        }

        public virtual Nullable<decimal> Balance
        {
            get { return _balance; }
            internal set { _balance = value ?? 0M; }
        }
    }
}
