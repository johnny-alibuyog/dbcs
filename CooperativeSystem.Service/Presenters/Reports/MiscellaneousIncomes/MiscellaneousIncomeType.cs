using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.MiscellaneousIncomes
{
    public class MiscellaneousIncomeType
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }

        private MiscellaneousIncomeType(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public static readonly MiscellaneousIncomeType None = new MiscellaneousIncomeType(0, "-- Select --");
        public static readonly MiscellaneousIncomeType OtherReceipt = new MiscellaneousIncomeType(1, "Other Receipt");
        public static readonly MiscellaneousIncomeType OtherAdjustment = new MiscellaneousIncomeType(2, "Other Adjustment");
        public static readonly MiscellaneousIncomeType OtherDisbursement = new MiscellaneousIncomeType(3, "Other Disbursement");
        public static readonly MiscellaneousIncomeType MembershipFeeReceipt = new MiscellaneousIncomeType(4, "Membership Fee Receipt");
        public static readonly MiscellaneousIncomeType MiscellaneousIncomeReceipt = new MiscellaneousIncomeType(5, "Miscellaneous Income Receipt");
        public static readonly MiscellaneousIncomeType MiscellaneousIncomeAdjustment = new MiscellaneousIncomeType(6, "Miscellaneous Income Adjustment");
        public static readonly MiscellaneousIncomeType MiscellaneousIncomeDisbursement = new MiscellaneousIncomeType(7, "Miscellaneous Income Disbursement");
        public static readonly IList<MiscellaneousIncomeType> All = new MiscellaneousIncomeType[] 
        {
            None,
            OtherReceipt,
            OtherAdjustment,
            OtherDisbursement,
            MembershipFeeReceipt,
            MiscellaneousIncomeReceipt,
            MiscellaneousIncomeAdjustment,
            MiscellaneousIncomeDisbursement
        };
    }
}
