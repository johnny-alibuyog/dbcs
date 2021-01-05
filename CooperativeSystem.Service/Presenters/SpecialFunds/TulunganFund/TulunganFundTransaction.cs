using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.SpecialFunds.TulunganFund
{
    public class TulunganFundTransaction
    {
        public virtual DateTime Date { get; set; }
        public virtual string TransactionType { get; set; }
        public virtual string ReceiptVoucher { get; set; }
        public virtual decimal Amount { get; set; }
    }
}
