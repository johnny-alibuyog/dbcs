using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.MiscellaneousIncomes
{
    public interface IMiscellaneousIncomeCashDisbursementView
    {
        string UserID { get; }
        DateTime DisbursementDate { get; }
        string VoucherNumber { get; set; }
        string Sequence { get; }
        decimal Amount { get; set; }
        string Remarks { get; set; }
    }
}
