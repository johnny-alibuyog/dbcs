using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Savings.SavingsDeposit
{
    public interface IQuarterlyInterestComputationView
    {
        string UserID { get; set; }

        int Year { get; }
        int QuarterID { get; }
        bool AllowSave { set; }
        bool AllowPost { set; }

        void PopulateQuaterPulldown(IList<Quarter> quarters);
        void PopulateReports(IList<QuarterlyInterestComputationItem> quarterlyInterestItems);
    }
}
