using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare
{
    public interface IRefundRatioView
    {
        int DividendRatio { get; set; }
        int PatronageRatio { get; set; }
    }
}
