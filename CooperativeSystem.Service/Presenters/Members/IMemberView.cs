using System;
using System.Collections.Generic;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Presenters.Lookups.Services;
//using CooperativeSystem.Service.Presenters.Maintenance;

namespace CooperativeSystem.Service.Presenters.Members
{
    public delegate void MembershipCategoryChangedEventHandler(object sender, EventArgs e);

    public interface IMemberView
    {
        long MemberID { get; set; }
        string AccountNumber { get; set; }
        string AccountStatusID { get; set; }
        string MembershipCategoryID { get; set; }
        string MembershipCategoryName { get; }
        DateTime ApplicationDate { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string FullName { get; }
        DateTime DateOfBirth { get; set; }
        string PlaceOfBirth { get; set; }
        char MaritalStatusID { get; set; }
        char SexTypeID { get; set; }
        string Address { get; set; }
        string Province { get; set; }
        string HomePhone { get; set; }
        string MobilePhone { get; set; }
        string Occupation { get; set; }
        string MotherMaidenName { get; set; }
        string LanguageDialects { get; set; }
        string HighestEducationalAttainment { get; set; }
        string Employer { get; set; }
        decimal MonthlySalary { get; set; }
        string OfficeAddress { get; set; }
        string OfficePhone { get; set; }
        string SpouseLastName { get; set; }
        string SpouseFirstName { get; set; }
        string SpouseMiddleName { get; set; }
        string SpouseContactNumber { get; set; }
        string SpouseOccupation { get; set; }
        string SpouseEmployer { get; set; }
        string SpouseOfficeAddress { get; set; }
        string SpouseOfficePhone { get; set; }
        string NearestRelativeLastName { get; set; }
        string NearestRelativeFirstName { get; set; }
        string NearestRelativeMiddleName { get; set; }
        string NearestRelativeContactNumber { get; set; }
        string MotherLastName { get; set; }
        string MotherFirstName { get; set; }
        string MotherMiddleName { get; set; }
        string MotherContactNumber { get; set; }
        string MotherOccupation { get; set; }
        string MotherAddress { get; set; }
        string FatherLastName { get; set; }
        string FatherFirstName { get; set; }
        string FatherMiddleName { get; set; }
        string FatherContactNumber { get; set; }
        string FatherOccupation { get; set; }
        string FatherAddress { get; set; }
        byte[] Picture { get; set; }
        byte[] Signature { get; set; }
        IList<DependentModel> Dependents { get; set; }
        IList<EducationalAttainmentModel> EducationalAttainments { get; set; }
        IAvailedServicesView AvailedServices { get; }

        // pulldown menu methods
        void PopulateAccountStatusPulldown(IList<AccountStatus> accountStatuses);
        void PopulateMembershipCategoryPulldown(IList<MembershipCategory> membershipCategories);
        void PopulateMaritalStatusPulldown(IList<MaritalStatus> maritalStatuses);
        void PopulateSexTypePulldown(IList<SexType> sexTypes);
        void PopulateRelationPulldown(IList<Relation> relations);

        void RefreshMembershipCategoryServices(IServicesAdapter services);

        // events
        event MembershipCategoryChangedEventHandler MembershipCategoryChangedEvent;

        void LoadMember(long MemberID);
        void NewMember();
    }
}
