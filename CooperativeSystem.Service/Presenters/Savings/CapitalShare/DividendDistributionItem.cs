using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare
{
    public class DividendDistributionItem
    {
        public virtual string Member { get; set; }
        public virtual string DepositoryService { get; set; }
        public virtual string TransactionType { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual decimal MoneyValue { get; set; }
        public virtual double NumberOfDaysUnchanged { get; set; }
        public virtual decimal AverageShare { get; set; }
        public virtual decimal Dividend { get; set; }
    }
}
