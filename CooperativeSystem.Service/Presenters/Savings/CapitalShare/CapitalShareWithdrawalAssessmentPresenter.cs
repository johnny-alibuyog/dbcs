using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Savings.CapitalShare.Calculators;

namespace CooperativeSystem.Service.Presenters.Savings.CapitalShare
{
    public class CapitalShareWithdrawalAssessmentPresenter : PresenterTemplate
    {
        private ICapitalShareWithdrawalAssessmentView _view;

        public CapitalShareWithdrawalAssessmentPresenter(ICapitalShareWithdrawalAssessmentView view)
        {
            _view = view;
        }


        public bool Load()
        {
            // TODO: withdraw of Capital Share == Closing of Account
            // Note: withdrawable amount = account credits - account debits
            //      Account Credits:
            //          Capital Share
            //          Savings
            //          Time Deposits
            //
            //      Account Debits
            //          Loans(including charges for late payment and delinquent if there is any)
            //          Unpaid Tulungan Funds
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

                if (member.CapitalShare == null)
                {
                    RaiseErrorEvent("You do not have capital share.");
                    return false;
                }

                _view.CurrentBalance = member.CapitalShare.CurrentBalance;

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
