using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Models
{
    partial class CashDisbursement
    {
        partial void OnDisbursementDateChanged()
        {
            //_DisbursementDate = _DisbursementDate.TruncateTime();
        }
    }
}
