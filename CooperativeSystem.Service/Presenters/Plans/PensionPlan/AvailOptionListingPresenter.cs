using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Plans.PensionPlan
{
    public class AvailOptionListingPresenter : PresenterTemplate
    {
        private IAvailOptionListingView _view;

        public AvailOptionListingPresenter(IAvailOptionListingView view)
        {
            _view = view;
        }

        public bool PopulateListing()
        {
            var result = false;
            try
            {
                var repository = new GenericRepository<PensionPlanAvailOption>();
                var availOptions = repository.GetAll().ToList();
                _view.PopulateListing(availOptions);
                result = true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                result = false;
            }
            return result;
        }
    }
}
