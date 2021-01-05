using System;

namespace CooperativeSystem.Service.Models.Projections
{
    [Serializable]
    public class UserListingModel
    {
        public virtual string UserID { get; set; }
        public virtual string Name { get; set; }
        public virtual string UserCategoryName { get; set; }
    }
}
