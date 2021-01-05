using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models
{
    partial class Dependent
    {
        public override string ToString()
        {
            return (LastName + ", " + FirstName + " " + MiddleName).Trim();
        }
    }
}
