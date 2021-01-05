using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Plans.PensionPlan
{
    public class AvailOptionSetterPersenter : PresenterTemplate
    {
        private IAvailOptionSetterView _view;

        public AvailOptionSetterPersenter(IAvailOptionSetterView view)
        {
            _view = view;
        }

        public void LoadAvailOptions()
        {
            var db = new DataContextFactory().CreateDataContext();
            var repository = new GenericRepository<PensionPlanAvailOption>(db);

            var availOptions = repository.GetAll();
            var entity = db.GetTable<Models.PensionPlan>()
                .Where(x => x.MemberID == _view.MemberID)
                .Select(x => x.PensionPlanAvailOption)
                .FirstOrDefault();

            if (entity == null)
                entity = availOptions.FirstOrDefault();

            _view.PopulateAvailOption(availOptions.ToList());
            _view.AvailOption = entity;
        }

        public void SyncronizeSelection()
        {
            var availOption = _view.AvailOption;
            if (availOption != null)
            {
                _view.MonthlyPension = availOption.WithMonthlyPension ? new Nullable<decimal>(0M) : null;
                _view.WithMonthlyPension = availOption.WithMonthlyPension;
                _view.AwardAmount = availOption.AwardAmount;
                _view.AgingPeriod = availOption.AgingPeriod;
                _view.AvailOptionDescription = availOption.AvailOptionDescription;
            }
        }

        public bool SetAvailOption()
        {
            try
            {
                var repository = new GenericRepository<CooperativeSystem.Service.Models.PensionPlan>();
                var plan = repository.GetEntity(p => p.MemberID == _view.MemberID);
                if (plan == null)
                {
                    RaiseErrorEvent("You do not have Pension Plan. Please verify.");
                    return false;
                }

                if (_view.AvailOption == null)
                {
                    RaiseErrorEvent("Please select an avail option first");
                    return false;
                }

                plan.AvailOptionID = _view.AvailOption.AvailOptionID;
                plan.MonthlyPension = _view.MonthlyPension;
                plan.AwardAmount = _view.AwardAmount;
                plan.AgingPeriod = _view.AgingPeriod;

                repository.SaveAll();
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }
    }
}
