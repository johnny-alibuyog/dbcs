using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models.Projections
{
    public class CashReceiptLookupModel
    {
        public virtual long ReceiptID { get; set; }
        public virtual string OfficialReceiptNumber { get; set; }
    }
}
