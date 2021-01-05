using System;

namespace CooperativeSystem.Service.Models.Projections
{
    [Serializable]
    public class MemberInquiryListingModel
    {
        public virtual long MemberID { get; set; }
        public virtual string AccountNumber { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string MembershipCategoryName { get; set; }

        public virtual string FullName
        {
            get
            {
                if ((LastName + FirstName + MiddleName).Trim() != string.Empty)
                    return string.Format("{0}, {1} {2}", LastName, FirstName, MiddleName);
                else
                    return string.Empty;
            }
        }
    }
}
