using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters
{
    public interface ICashReceiptView
    {
        long MemberID { get; }
        string UserID { get; }
        DateTime ReceiptDate { get; }
        string ReceiptNumber { get; set; }
        string Sequence { get; }

        // loans
        decimal ApplianceLoan { get; set; }
        decimal EasyLoan { get; set; }
        decimal EmergencyLoan { get; set; }
        decimal EquityLoan { get; set; }
        decimal PensionLoan { get; set; }
        decimal RegularLoan { get; set; }
        decimal DTILoan { get; set; }       // TODO: remove this code soon
        decimal MEDPLoan { get; set; }       // TODO: remove this code soon

        // plans
        decimal CollegeInsurancePlan { get; set; }
        decimal PensionPlan { get; set; }

        // savings
        decimal CapitalShare { get; set; }
        decimal SavingsDeposit { get; set; }
        decimal TimeDeposit { get; set; }

        // special funds
        decimal DeathAidFund { get; set; }
        decimal TulunganFund { get; set; }

        // miscellaneous
        decimal MiscellaneousIncome { get; set; }
        decimal MembershipFee { get; set; }
        decimal Others { get; set; }

        bool IsThereServiceReceipt { get; set; }
    }
}
