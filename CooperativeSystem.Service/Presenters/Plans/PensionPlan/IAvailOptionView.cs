using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Plans.PensionPlan
{
    public interface IAvailOptionView
    {
        int AvailOptionID { get; set; }
        string AvailOptionName { get; set; }
        string AvailOptionDescription { get; set; }
        decimal AwardAmount { get; set; }
        int AgingPeriod { get; set; }
        bool WithMonthlyPension { get; set; }

        void NewAvailOption();
        void LoadAvailOption(int availOptionID);
    }
}
