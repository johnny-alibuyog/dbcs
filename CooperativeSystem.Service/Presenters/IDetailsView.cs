using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters
{
    public interface ISummaryView
    {
        bool IsSummaryLoaded { get; set; }
        void LoadSummary(long memberID);
        void ClearSummary();
    }
}
