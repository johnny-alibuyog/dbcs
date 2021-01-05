using System;
using System.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.Members
{
    public class MemberListingPresenter : PresenterTemplate
    {
        //private IRepository<Member> _repository;
        private IMemberListingView _view;

        public MemberListingPresenter(IMemberListingView view)
        {
            //_repository = new GenericRepository<Member>();
            _view = view;
        }

        public bool PopulateListing()
        {
            bool result = false;
            try 
            {
                var db = new DataContextFactory().CreateDataContext();
                var query = db.GetTable<Member>()
                    .Select(x => new MemberListingModel()
                    {
                        MemberID = x.MemberID,
                        AccountNumber = x.AccountNumber,
                        Name = string.Format("{0}, {1} {2}", x.LastName, x.FirstName, x.MiddleName),
                        ApplicationDate = x.ApplicationDate,
                        MembershipCategory = x.MembershipCategory.MembershipCategoryName
                    });

                _view.PopulateListing(query.ToList());
                result = true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
            return result;
        }
    }
}
