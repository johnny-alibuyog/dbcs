using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare
{
    public interface IDividendDepositorySelectionView
    {
        int Year { get; }
        bool AllowSave { get; set; }

        long MemberID { get; set; }
        string Member { get; set; }
        string DepositoryServiceID { get; set; }
        IList<DividendComputation> DividendComputations { set; }

        void PopulateDepositoryServicePulldown(IList<Models.Service> services);
    }
}
