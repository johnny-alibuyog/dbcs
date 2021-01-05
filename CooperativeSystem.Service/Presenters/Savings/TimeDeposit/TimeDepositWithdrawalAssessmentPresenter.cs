using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Savings.TimeDeposit.Calculators;

namespace CooperativeSystem.Service.Presenters.Savings.TimeDeposit
{
    public class TimeDepositWithdrawalAssessmentPresenter : PresenterTemplate
    {
        private ITimeDepositWithdrawalAssessmentView _view;

        public TimeDepositWithdrawalAssessmentPresenter(ITimeDepositWithdrawalAssessmentView view)
        {
            _view = view;
        }

        public bool Load()
        {
            try 
            {
                //repository = new GenericRepository<Models.TimeDeposit>(); 
                //var repository = new GenericRepository<Member>();
                //var member = repository.GetEntity(m => m.MemberID == _view.MemberID);

                //if (member == null)
                //{
                //    OnError(string.Format("The system cannot find MemberID {0}. Please verify.", _view.MemberID));
                //    return false;
                //}

                //var remarks = string.Empty;
                //var calculator = new MaturedTimeDepositCalculator(member);
                //var maturedTimeDeposits = calculator.GetMaturedTimeDeposits(out remarks);

                //if (maturedTimeDeposits == null)
                //{
                //    OnError(remarks);
                //    return false;
                //}

                //_view.TimeDeposits = maturedTimeDeposits;
                //return true;

                using (var db = new DataContextFactory().CreateDataContext())
                {
                    var assessments = db.GetTable<Models.TimeDeposit>()
                        .Where(x =>
                            x.MemberID == _view.MemberID &&
                            x.Consumed == false
                        )
                        .Select(x => new TimeDepositWithdrawalAssessmentModel()
                        {
                            TimeDepositID = x.TimeDepositID,
                            DepositDate = x.DepositDate,
                            MaturityDate = x.MaturityDate,
                            Terms = x.Terms,
                            InterestRate = x.InterestRate,
                            PrincipalAmount = x.TimeDepositAmount
                        })
                        .ToList();

                    if (!assessments.Any())
                    {
                        RaiseErrorEvent("You do not have any time deposit.");
                        return false;
                    }

                    _view.TimeDeposits = assessments;
                }

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
