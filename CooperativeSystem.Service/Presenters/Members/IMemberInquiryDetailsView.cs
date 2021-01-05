
namespace CooperativeSystem.Service.Presenters.Members
{
    public interface IMemberInquiryDetailsView
    {
        long MemberID { get; set; }
        string AccountNumber { get; set; }
        string FullName { get; set; }
        string MembershipCategoryName { get; set; }
        string DateApplied { get; set; }
        string DateOfBirth { get; set; }
        string PlaceOfBirth { get; set; }
        string Address { get; set; }
        string HomePhone { get; set; }
        string MobilePhone { get; set; }
        string MaritalStatusName { get; set; }
        string SexTypeName { get; set; }
        byte[] Picture { get; set; }
        byte[] Signature { get; set; }
        AvailedServicesAdapter AvailedServices { get; set; }        
    }
}
