using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.MemberSummaries
{
    public class MemberSummaryItem
    {
        private bool _isActive;
        private string _status;
        private string _category;
        private string _gender;
        private string _name;
        private int _isGood;
        private int _isBorrower;
        private int _isDelayed;
        private int _isDelinquent;
        private readonly int _entry = 1;

        public virtual bool IsActive
        {
            set { _isActive = value; }
        }

        public virtual string Status
        {
            get { return _status; }
            internal set { _status = value; }
        }

        public virtual string Category
        {
            get { return _category; }
            internal set { _category = value; }
        }

        public virtual string Gender
        {
            get { return _gender; }
            internal set { _gender = value; }
        }

        public virtual string Name
        {
            get { return _name; }
            internal set { _name = value; }
        }

        public virtual int IsGood
        {
            get { return _isGood; }
            internal set { _isGood = _isActive ? value : 0; }
        }

        public virtual int IsBorrower
        {
            get { return _isBorrower; }
            internal set { _isBorrower = _isActive ? value : 0; }
        }

        public virtual int IsDelayed
        {
            get { return _isDelayed; }
            internal set { _isDelayed = _isActive ? value : 0; }
        }

        public virtual int IsDelinquent
        {
            get { return _isDelinquent; }
            internal set { _isDelinquent = _isActive ? value : 0; }
        }

        public virtual int Entry
        {
            get { return _entry; }
        }
    }
}
