using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan.Calculators;

namespace CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan
{
    public class CIPPaymentPresenter : PresenterTemplate
    {
        private ICIPPaymentView _view;

        public CIPPaymentPresenter(ICIPPaymentView view)
        {
            _view = view;
        }

        public bool Load()
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();
                var repository = new GenericRepository<Member>(db);
                var member = repository.GetEntity(m => m.MemberID == _view.MemberID);
                
                if (member == null)
                {
                    RaiseErrorEvent(string.Format("The system was not able to find MemberID {0}. Please verify.", _view.MemberID));
                    return false;
                }

                var planQuery = member.CollegeInsurancePlans;
                if (!planQuery.Any())
                {
                    RaiseErrorEvent("You do not have College Insurance Plan.");
                    return false;
                }

                var remarks = string.Empty;
                var settings = db.GetTable<Models.CollegeInsurancePlanSetting>().First();
                var calculator = new PayablePlanCalculator(planQuery.ToList(), settings);
                var payablePlans = calculator.GetPayablePlans(out remarks);
                if (payablePlans == null)
                {
                    RaiseErrorEvent(remarks);
                    return false;
                }

                _view.PayablePlans = payablePlans.ToList();

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
