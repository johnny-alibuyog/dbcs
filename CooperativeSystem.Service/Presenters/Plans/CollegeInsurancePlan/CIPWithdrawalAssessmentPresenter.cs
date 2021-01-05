using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan
{
    public class CIPWithdrawalAssessmentPresenter : PresenterTemplate
    {
        private ICIPWithdrawalAssessmentView _view;

        public CIPWithdrawalAssessmentPresenter(ICIPWithdrawalAssessmentView view)
        {
            _view = view;
        }

        public bool Load()
        {
            try
            {
                //// get only matured plans
                //var repository = new GenericRepository<CooperativeSystem.Service.Models.CollegeInsurancePlan>();
                //var cips = repository
                //    .GetAll(cip =>
                //        cip.MemberID == _view.MemberID &&
                //        cip.MaturityDate.Value <= DateTime.Today &&
                //        cip.PaymentCompletionAmount <= cip.CollegeInsurancePlanReceipts.Sum(cipd => cipd.Amount) &&
                //        cip.Consumed == false);

                //if (!cips.Any())
                //{
                //    OnError("You do not have colleges insurance plan that pass maturity.");
                //    return false;
                //}

                //_view.CIPs = cips.ToList();
                //return true;

                var db = new DataContextFactory().CreateDataContext();
                var withdrawalAssessments = db.GetTable<Models.CollegeInsurancePlan>()
                    .Where(x =>
                        x.Consumed == false &&
                        x.MemberID == _view.MemberID
                    )
                    .Select(x => new CIPWithdrawalAssessmentModel()
                    {
                        CollegeInsurancePlanID = x.CollegeInsurancePlanID,
                        UserName = x.UserLastName + ", " + x.UserFirstName + " " + x.UserMiddleName,
                        MaturityDate = x.MaturityDate,
                        TotalContributionAmount = //x.CurrentBalance,
                            (x.CollegeInsurancePlanReceipts.Any() ? x.CollegeInsurancePlanReceipts.Sum(y => y.Amount) : 0M) +
                            (x.CollegeInsurancePlanAdjustments.Any() ? x.CollegeInsurancePlanAdjustments.Sum(y => y.Amount) : 0M),
                        AwardAmount = x.AwardAmount
                    })
                    .ToList();

                if (!withdrawalAssessments.Any())
                {
                    RaiseErrorEvent("You do not have colleges insurance plan that pass maturity.");
                    return false;
                }

                _view.CIPAssessments = withdrawalAssessments;
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
