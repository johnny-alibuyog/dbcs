using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.MiscellaneousIncomes
{
    public interface IMiscellaneousIncomeAdjustmentView
    {
        string UserID { get; }
        DateTime AdjustmentDate { get; }
        string VoucherNumber { get; set; }
        string Sequence { get; }
        decimal Amount { get; set; }
        string Remarks { set; }

        bool IsLoadingDetails { get; set; }
        bool IsThereAdjustment { get; set; }
    }
}
