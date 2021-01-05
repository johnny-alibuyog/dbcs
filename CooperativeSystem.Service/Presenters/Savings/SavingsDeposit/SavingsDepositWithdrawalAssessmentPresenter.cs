using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Savings.SavingsDeposit
{
    public class SavingsDepositWithdrawalAssessmentPresenter : PresenterTemplate
    {
        private IRepository<CooperativeSystem.Service.Models.SavingsDeposit> _repository;
        private ISavingsDepositWithdrawalAssessmentView _view;

        public SavingsDepositWithdrawalAssessmentPresenter(ISavingsDepositWithdrawalAssessmentView view)
        {
            _repository = new GenericRepository<CooperativeSystem.Service.Models.SavingsDeposit>();
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
                    RaiseErrorEvent(string.Format("The system cannot find MemberID {0}. Please verify.", _view.MemberID));
                    return false;
                }

                if (member.SavingsDeposit == null)
                {
                    RaiseErrorEvent("You do not have savings deposit.");
                    return false;
                }

                _view.CurrentBalance = member.SavingsDeposit.CurrentBalance;

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
