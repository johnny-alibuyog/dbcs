using System;
using System.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;
using System.Linq.Expressions;

namespace CooperativeSystem.Service.Presenters.Members
{
    public class MemberInquiryListingPresernter : PresenterTemplate
    {
        private IMemberInquiryListingView _view;

        public MemberInquiryListingPresernter(IMemberInquiryListingView view)
        {
            _view = view;

            var db = new DataContextFactory().CreateDataContext();
            var category = db.GetTable<MembershipCategory>().ToList();
            _view.PopulateMembershipCategory(category);
            _view.MembershipCategoryID = null;
            _view.ResultCount = 0;
        }

        public void SearchMembers()
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();

                var query = db.GetTable<Member>()
                    .Where(x =>
                        x.AccountNumber.StartsWith(_view.AccountNumber) &&
                        x.LastName.StartsWith(_view.LastName) &&
                        x.FirstName.StartsWith(_view.FirstName) &&
                        x.MiddleName.StartsWith(_view.MiddleName) &&
                        x.MembershipCategoryID.StartsWith(_view.MembershipCategoryID)
                    )
                    .OrderBy(x => x.AccountNumber)
                    .Select(x => new MemberInquiryListingModel()
                    {
                        MemberID = x.MemberID,
                        AccountNumber = x.AccountNumber,
                        LastName = x.LastName,
                        FirstName = x.FirstName,
                        MiddleName = x.MiddleName,
                        MembershipCategoryName = x.MembershipCategory.MembershipCategoryName
                    });

                var members = query.ToList();

                _view.ResultCount = members.Count;
                _view.PopulateListing(members);
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
        }

        public void ClearCriteria()
        {
            _view.AccountNumber = string.Empty;
            _view.LastName = string.Empty;
            _view.FirstName = string.Empty;
            _view.MiddleName = string.Empty;
        }


    }
}
