using System;

namespace CooperativeSystem.Service.Models.Projections
{
    [Serializable]
    public class RelationListingModel
    {
        public virtual int RelationID { get; set; }
        public virtual string RelationName { get; set; }
    }
}
