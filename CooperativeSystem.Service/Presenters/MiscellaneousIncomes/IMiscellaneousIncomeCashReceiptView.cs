using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.MiscellaneousIncomes
{
    public interface IMiscellaneousIncomeCashReceiptView
    {
        string UserID { get; }
        DateTime ReceiptDate { get; }
        string ReceiptNumber { get; set; }
        string Sequence { get; }
        decimal Amount { get; set; }
        string Remarks { get; set; }
    }
}
