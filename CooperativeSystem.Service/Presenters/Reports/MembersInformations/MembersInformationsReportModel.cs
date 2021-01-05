using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.MembersInformations
{
    public class MembersInformationsReportModel
    {
        public virtual string Member { get; set; }
        public virtual string MembershipCategory { get; set; }
        public virtual string Address { get; set; }
        public virtual string HomePhone { get; set; }
        public virtual string MobliePhone { get; set; }
        public virtual string PlaceOfBirth { get; set; }
        public virtual Nullable<DateTime> DateOfBirth { get; set; }
    }
}
