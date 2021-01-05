using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models
{
    public class TransactionDetail
    {
        public virtual DateTime Date { get; set; }
        public virtual string TransactionType { get; set; }
        public virtual string ReceiptVoucher { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal Balance { get; set; }
    }
}
