using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Disbursements.DailyDisbursements
{
    public class DailyDisbursement : DisbursementTemplate
    {
        public virtual string Member { get; set; }
        public virtual string User { get; set; }
        public virtual string JVNumber { get; set; }
    }
}
