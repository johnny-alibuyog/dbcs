using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators
{
    [Serializable]
    public class FineDetails
    {
        public virtual Loan Loan { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual int Days { get; set; }
        public virtual decimal Amount { get; set; }
    }
}
