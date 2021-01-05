using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.ServiceFeeCalculators
{
    [Serializable]
    internal class ServiceFees
    {
        public virtual decimal ServiceFee { get; set; }
        public virtual decimal CollectionFee { get; set; }
        public virtual decimal CapitalBuildup { get; set; }
        public virtual decimal LoanGuaranteeFund { get; set; }
        public virtual decimal Interest { get; set; }
        public virtual decimal Total 
        { 
            get { return ServiceFee + CollectionFee + CapitalBuildup + LoanGuaranteeFund + Interest; } 
        }
    }
}
