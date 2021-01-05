using System;

namespace CooperativeSystem.Service.Models.Projections
{
    [Serializable]
    public class MemberListingModel
    {
        public virtual long MemberID { get; set; }
        public virtual string AccountNumber { get; set; }
        public virtual DateTime ApplicationDate { get; set; }
        public virtual string Name { get; set; }
        public virtual string MembershipCategory { get; set; }
    }
}
