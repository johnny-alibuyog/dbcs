using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Presenters.Lookups.AccountStatuses;

namespace CooperativeSystem.Service.Presenters.Reports.MembersInformations
{
    public class MembersInformationsReportPresenter : PresenterTemplate
    {
        private readonly IMembersInformationsReportView _view;

        public MembersInformationsReportPresenter(IMembersInformationsReportView view)
        {
            _view = view;
        }

        public virtual void Populate()
        {
            try
            {
                var items = (IList <MembersInformationsReportModel>)null;
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    items = db.GetTable<Models.Member>()
                        .Where(x => x.AccountStatusID != AccountStatusCodes.Closed)
                        .Select(x => new MembersInformationsReportModel()
                        {
                            Member = x.LastName + " " + x.FirstName,
                            MembershipCategory = x.MembershipCategory.MembershipCategoryName,
                            Address = x.Address,
                            HomePhone = x.HomePhone,
                            MobliePhone = x.MobilePhone,
                            PlaceOfBirth = x.PlaceOfBirth,
                            DateOfBirth = x.DateOfBirth
                        })
                        .OrderBy(x => x.MembershipCategory)
                        .ThenBy(x => x.Member)
                        .ToList();
                }

                _view.Populate(items);
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
        }
    }
}
