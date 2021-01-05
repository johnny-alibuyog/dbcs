using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Sandbox.Models.DividendModels
{
    public class Member
    {
        private string _lastName;
        private string _firstName;
        private string _middleName;
        private IList<CapitalShare> _capitalShares;

        public override string ToString()
        {
            return LastName + ", " + FirstName + " " + MiddleName;
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }

        public virtual IList<CapitalShare> CapitalShares
        {
            get { return _capitalShares; }
            set { _capitalShares = value; }
        }
    }
}
