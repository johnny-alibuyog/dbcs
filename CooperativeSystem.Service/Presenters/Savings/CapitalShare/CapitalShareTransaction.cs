using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare.Calculators
{
    [Serializable]
    public class CapitalShareTransaction
    {
        public virtual DateTime Date { get; set; }
        public virtual string TransactionType { get; set; }
        public virtual string ReceiptVoucher { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal Balance { get; set; }
    }
}
