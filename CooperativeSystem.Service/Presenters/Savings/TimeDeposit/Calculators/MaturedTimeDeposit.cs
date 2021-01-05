using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.TimeDeposit.Calculators
{
    public class MaturedTimeDeposit
    {
        public virtual long TimeDepositID { get; set; }
        public virtual Models.TimeDeposit TimeDeposit { get; set; }
        public virtual DateTime MaturityDate { get; set; }
        public virtual decimal Interest { get; set; }
        public virtual decimal PrincipalAmount { get; set; }
        public virtual decimal TotalAmount { get { return Interest + PrincipalAmount; } }
    }
}
