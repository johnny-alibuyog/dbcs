using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Plans.PensionPlan
{
    public class PensionPlanPaymentPresenter : PresenterTemplate
    {
        private IPensionPlanPaymentView _view;

        public PensionPlanPaymentPresenter(IPensionPlanPaymentView view)
        {
            _view = view;
        }

        public bool Load()
        {
            try 
            {
                var repository = new GenericRepository<Models.PensionPlan>();
                var plan = repository.GetEntity(x => x.MemberID == _view.MemberID);

                if (plan == null)
                {
                    RaiseErrorEvent("You do not have pension plan.");
                    return false;
                }

                if (plan.Consumed)
                {
                    RaiseErrorEvent("Your plan has already been consumed.");
                    return false;
                }

                _view.PaymentMode = plan.PaymentMode.PaymentModeName;
                _view.Amortization = plan.Amortization;
                _view.UnpaidAmortization = plan.CurrentPayableAmount;
                _view.PaymentAmount = plan.CurrentPayableAmount;

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
