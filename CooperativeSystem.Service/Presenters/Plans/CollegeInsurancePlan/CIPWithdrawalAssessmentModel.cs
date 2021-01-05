using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan
{
    public class CIPWithdrawalAssessmentModel
    {
        public virtual long CollegeInsurancePlanID { get; internal set; }
        public virtual string UserName { get; internal set; }
        public virtual Nullable<DateTime> MaturityDate { get; internal set; }
        public virtual decimal TotalContributionAmount { get; internal set; }
        public virtual decimal AwardAmount { get; internal set; }

        public virtual bool IsMatured
        {
            get
            {
                if (MaturityDate == null)
                    return false;

                if (MaturityDate.Value.TruncateTime() > DateTime.Today)
                    return false;

                return true;
            }
        }

        public virtual decimal WithdrawAmount
        {
            get { return IsMatured ? AwardAmount : TotalContributionAmount; }
        }
    }
}
