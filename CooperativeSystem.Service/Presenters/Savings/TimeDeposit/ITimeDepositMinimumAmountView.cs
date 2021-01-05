using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.TimeDeposit
{
    public interface ITimeDepositMinimumAmountView
    {
        int Id { get; set; }
        decimal Amount { get; set; }
    }
}
