using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Disbursements.MonthlyDisbursements
{
    public class MonthlyDisbursement : DisbursementTemplate
    {
        public virtual int Day { get; set; }
    }
}
