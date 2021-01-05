using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.TimeDeposit
{
    public interface ITimeDepositSummaryView : ISummaryView
    {
        IList<TimeDepositTransaction> Transactions { set; }

        Nullable<DateTime> DepositDate { set; }
        Nullable<decimal> DepositAmount { set; }
        Nullable<int> Terms { set; }
        Nullable<decimal> InterestRate { set; }
        Nullable<decimal> Interest { set; }
        Nullable<DateTime> MaturityDate { set; }
        Nullable<DateTime> DisbursementDate { set; }
        Nullable<decimal> DisbursementAmount { set; }
    }
}
