using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models.Projections
{
    public class LoanLookupModel
    {
        public virtual long LoanID { get; set; }
        public virtual string VoucherNumber { get; set; }
    }
}
