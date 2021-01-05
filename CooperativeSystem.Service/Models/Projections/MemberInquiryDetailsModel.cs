using System;
using CooperativeSystem.Service.Presenters.Members;

namespace CooperativeSystem.Service.Models.Projections
{
    [Serializable]
    public class MemberInquiryDetailsModel
    {
        public virtual long MemberID { get; set; }
        public virtual string AccountNumber { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string MembershipCategoryName { get; set; }
        public virtual DateTime? ApplicationDate { get; set; }
        public virtual DateTime? DateOfBirth { get; set; }
        public virtual string PlaceOfBirth { get; set; }
        public virtual string Address { get; set; }
        public virtual string HomePhone { get; set; }
        public virtual string MobilePhone { get; set; }
        public virtual string MaritalStatusName { get; set; }
        public virtual string SexTypeName { get; set; }
        public virtual byte[] Picture { get; set; }
        public virtual byte[] Signature { get; set; }
        public virtual AvailedServicesAdapter AvailedServices { get; set; }

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
