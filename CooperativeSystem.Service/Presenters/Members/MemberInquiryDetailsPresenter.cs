using System;
using System.Data.Linq;
using System.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.Members
{
    public class MemberInquiryDetailsPresenter : PresenterTemplate
    {
        private IMemberInquiryDetailsView _view;

        public MemberInquiryDetailsPresenter(IMemberInquiryDetailsView view)
        {
            _view = view;
        }

        public bool SearchMember(long memberID)
        {
            bool result = false;
            try
            {
                var db = new DataContextFactory().CreateDataContext();
                var member = db.GetTable<Member>()
                    .Where(x => x.MemberID == memberID)
                    .Select(x => new MemberInquiryDetailsModel()
                    {
                        MemberID = x.MemberID,
                        AccountNumber = x.AccountNumber,
                        LastName = x.LastName,
                        FirstName = x.FirstName,
                        MiddleName = x.MiddleName,
                        MembershipCategoryName = x.MembershipCategory.MembershipCategoryName,
                        ApplicationDate = x.ApplicationDate,
                        DateOfBirth = x.DateOfBirth,
                        PlaceOfBirth = x.PlaceOfBirth,
                        Address = x.Address,
                        HomePhone = x.HomePhone,
                        MobilePhone = x.MobilePhone,
                        MaritalStatusName = x.MaritalStatus.MaritalStatusName,
                        SexTypeName = x.SexType.SexTypeName,
                        Picture = x.Picture.Image != null ? x.Picture.Image.ToArray() : null,
                        Signature = x.Picture.Signature != null ? x.Picture.Signature.ToArray() : null,
                        AvailedServices = new AvailedServicesAdapter(x.AvailedServices)
                    })
                    .FirstOrDefault();

                result = member != null;
                if (result)
                {
                    _view.MemberID = member.MemberID;
                    _view.AccountNumber = member.AccountNumber;
                    _view.FullName = member.FullName;
                    _view.MembershipCategoryName = member.MembershipCategoryName;
                    _view.DateApplied = member.ApplicationDate.HasValue ?
                        member.ApplicationDate.Value.ToString("MM-dd-yyyy") : string.Empty;
                    _view.DateOfBirth = member.DateOfBirth.HasValue ?
                        member.DateOfBirth.Value.ToString("MM-dd-yyyy") : string.Empty;
                    _view.PlaceOfBirth = member.PlaceOfBirth;
                    _view.Address = member.Address;
                    _view.HomePhone = member.HomePhone;
                    _view.MobilePhone = member.MobilePhone;
                    _view.MaritalStatusName = member.MaritalStatusName;
                    _view.SexTypeName = member.SexTypeName;
                    _view.Picture = member.Picture;
                    _view.Signature = member.Signature;
                    _view.AvailedServices = member.AvailedServices;
                }
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
            return result;
        }

        public void Clear()
        {
            _view.MemberID = 0L;
            _view.AccountNumber = string.Empty;
            _view.FullName = string.Empty;
            _view.MembershipCategoryName = string.Empty;
            _view.DateApplied = string.Empty;
            _view.DateOfBirth = string.Empty;
            _view.PlaceOfBirth = string.Empty;
            _view.Address = string.Empty;
            _view.HomePhone = string.Empty;
            _view.MobilePhone = string.Empty;
            _view.MaritalStatusName = string.Empty;
            _view.SexTypeName = string.Empty;
            _view.Picture = null;
            _view.AvailedServices = null;
        }
    }
}
