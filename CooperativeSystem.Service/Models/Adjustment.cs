using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Models
{
    partial class Adjustment
    {
        partial void OnAdjustmentDateChanged()
        {
            //_AdjustmentDate = _AdjustmentDate.TruncateTime();
        }
    }
}
