using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Loans
{
    public interface ILoanSettingsView
    {
        decimal RenewablePaidRercentage { get; set; }
        decimal RegularLoanMaxPrecentage { get; set; }
        int RebateExemptedTerms { get; set; }
    }
}
