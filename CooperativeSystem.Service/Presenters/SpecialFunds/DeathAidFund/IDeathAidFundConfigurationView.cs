using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.SpecialFunds.DeathAidFund
{
    public interface IDeathAidFundConfigurationView
    {
        decimal Beneficiary { get; set; }
        decimal Member { get; set; }
    }
}
