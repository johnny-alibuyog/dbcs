using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings
{
    public interface INetSurplusView
    {
        int Year { get; set; }
        decimal Amount { get; set; }
    }
}
