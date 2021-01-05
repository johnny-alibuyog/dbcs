using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.WithdrawnMembers
{
    public class WithdrawnMemberModel
    {
        private string _name;
        private string _membershipCategory;
        private DateTime _applicationDate;
        private DateTime _withdrawalDate;
        private Nullable<decimal> _amount;

        public virtual string Name 
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual string MembershipCategory 
        {
            get { return _membershipCategory; }
            set { _membershipCategory = value; } 
        }

        public virtual DateTime ApplicationDate
        {
            get { return _applicationDate; }
            set { _applicationDate = value; }
        }

        public virtual DateTime WithdrawalDate
        {
            get { return _withdrawalDate; }
            set { _withdrawalDate = value; }
        }

        public virtual Nullable<decimal> Amount
        {
            get { return _amount; }
            set { _amount = value ?? 0M; }
        }

    }
}
