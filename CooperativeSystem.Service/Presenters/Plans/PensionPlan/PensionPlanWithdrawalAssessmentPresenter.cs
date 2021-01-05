using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.PensionPlanAvailOptions;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Presenters.Plans.PensionPlan
{
    public class PensionPlanWithdrawalAssessmentPresenter : PresenterTemplate
    {
        private IPensionPlanWithdrawalAssessmentView _view;

        public PensionPlanWithdrawalAssessmentPresenter(IPensionPlanWithdrawalAssessmentView view)
        {
            _view = view;
        }

        public bool Load()
        {
            try 
            {
                //var repository = new GenericRepository<CooperativeSystem.Service.Models.PensionPlan>();
                //var pensionPlanQuery = repository.GetAll(pp => pp.MemberID == _view.MemberID);

                //var db = new DataContextFactory().CreateDataContext();
                //var pensionPlanTable = db.GetTable<CooperativeSystem.Service.Models.PensionPlan>();

                //var plan = pensionPlanTable.FirstOrDefault(p => p.MemberID == _view.MemberID);

                //if (plan == null)
                //{
                //    OnError("You do not have pension plan.");
                //    return false;
                //}

                //if (plan.Consumed)
                //{
                //    OnError("Your plan has already been consumed.");
                //    return false;
                //}

                ////if (plan.MaturityDate == null || plan.MaturityDate.Value.TruncateTime() < DateTime.Today)
                ////{
                ////    OnError("Your plan is not yet matured.");
                ////    return false;
                ////}

                //if (plan.AvailOptionID == null)
                //{
                //    OnError("You haven't selected avail option. Please select an avail option first.");
                //    return false;
                //}

                ////var query = pensionPlanTable
                ////    .Where(p => 
                ////        p.MemberID == _view.MemberID && 
                ////        p.Consumed == false && 
                ////        p.AvailOptionID != null)
                ////    .Select(p => new
                ////    {
                ////        AvailOption = p.PensionPlanAvailOption.AvailOptionName,
                ////        ApplicationDate = p.ApplicationDate,
                ////        PaymentCompeletionDate = p.PaymentCompletionDate,
                ////        MaturityDate = p.MaturityDate,
                ////        PaymentCompletionAmount = p.PaymentCompletionAmount,
                ////        AwardAmount = p.AwardAmount,
                ////        PayedAmount = p.PensionPlanReceipts.Sum(r => r.Amount),
                ////        Interests = p.PensionPlanInterestDisbursements.Sum(i => i.Amount),
                ////        DisbursedAmount = p.PensionPlanDisbursements.Sum(d => d.Amount),
                ////        MaximumWithdrawableAmount = p.AwardAmount + 
                ////            p.PensionPlanInterestDisbursements.Sum(i => i.Amount) -
                ////            p.PensionPlanDisbursements.Sum(d => d.Amount),
                ////        WithdrawAmount = p.AvailOptionID == PensionPlanAvailOptionCodes.Option2
                ////            ? p.MonthlyPension
                ////            : p.AwardAmount +
                ////                p.PensionPlanInterestDisbursements.Sum(i => i.Amount) -
                ////                p.PensionPlanDisbursements.Sum(d => d.Amount)
                ////    });

                //var planDetails = new
                //{
                //    AvailOption = plan.PensionPlanAvailOption.AvailOptionName,
                //    ApplicationDate = plan.ApplicationDate,
                //    PaymentCompeletionDate = plan.PaymentCompletionDate,
                //    MaturityDate = plan.MaturityDate,
                //    PaymentCompletionAmount = plan.PaymentCompletionAmount,
                //    AwardAmount = plan.AwardAmount,
                //    PayedAmount = plan.PensionPlanReceipts.Sum(r => r.Amount),
                //    Interests = plan.PensionPlanInterestAdjustments.Sum(i => i.Amount),
                //    DisbursedAmount = plan.PensionPlanDisbursements.Sum(d => d.Amount),
                //    MaximumWithdrawableAmount = plan.AwardAmount +
                //        plan.PensionPlanInterestAdjustments.Sum(i => i.Amount) -
                //        plan.PensionPlanDisbursements.Sum(d => d.Amount),
                //    WithdrawAmount = plan.AvailOptionID == PensionPlanAvailOptionCodes.Option2
                //        ? plan.MonthlyPension
                //        : plan.AwardAmount +
                //            plan.PensionPlanInterestAdjustments.Sum(i => i.Amount) -
                //            plan.PensionPlanDisbursements.Sum(d => d.Amount)
                //};

                //_view.AvailOption = planDetails.AvailOption;
                //_view.ApplicationDate = planDetails.ApplicationDate;
                //_view.PaymentCompeletionDate = planDetails.PaymentCompeletionDate;
                //_view.MaturityDate = planDetails.MaturityDate;
                //_view.PaymentCompletionAmount = planDetails.PaymentCompletionAmount;
                //_view.AwardAmount = planDetails.AwardAmount.Value;
                //_view.PayedAmount = planDetails.PayedAmount;
                //_view.Interests = planDetails.Interests;
                //_view.DisbursedAmount = planDetails.DisbursedAmount;
                //_view.MaximumWithdrawableAmount = planDetails.MaximumWithdrawableAmount.Value;
                //_view.WithdrawAmount = planDetails.WithdrawAmount.Value;

                //return true;


                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Models.PensionPlan>(x => x.PensionPlanAvailOption);
                loadOptions.LoadWith<Models.PensionPlan>(x => x.PensionPlanReceipts);
                loadOptions.LoadWith<Models.PensionPlan>(x => x.PensionPlanAdjustments);
                loadOptions.LoadWith<Models.PensionPlan>(x => x.PensionPlanInterestAdjustments);
                loadOptions.LoadWith<Models.PensionPlan>(x => x.PensionPlanDisbursements);

                PensionPlanWithdrawalAssessmentModel assessment = null;
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    db.LoadOptions = loadOptions;
                    
                    var query = db.GetTable<Models.PensionPlan>()
                        .Where(x => x.MemberID == _view.MemberID)
                        .Select(x => new PensionPlanWithdrawalAssessmentModel()
                        {
                            AvailOption = x.PensionPlanAvailOption,
                            Consumed = x.Consumed,
                            ApplicationDate = x.ApplicationDate,
                            PaymentCompeletionDate = x.PaymentCompletionDate,
                            MaturityDate = x.MaturityDate,
                            PaymentCompletionAmount = x.PaymentCompletionAmount,
                            AwardAmount = x.AwardAmount,
                            PaidAmount =
                                (x.PensionPlanReceipts.Any() ? x.PensionPlanReceipts.Sum(o => o.Amount) : 0M) +
                                (x.PensionPlanAdjustments.Any() ? x.PensionPlanAdjustments.Sum(o => o.Amount) : 0M),
                            Interests = x.PensionPlanInterestAdjustments.Sum(o => o.Amount),
                            DisbursedAmount = x.PensionPlanDisbursements.Sum(o => o.Amount),
                            MonthlyPension = x.MonthlyPension
                        });

                    assessment = query.FirstOrDefault();
                }

                if (assessment == null)
                {
                    RaiseErrorEvent("You do not have pension plan.");
                    return false;
                }

                if (assessment.Consumed)
                {
                    RaiseErrorEvent("Your plan has already been consumed.");
                    return false;
                }

                if (assessment.AvailOption == null)
                {
                    RaiseErrorEvent("You haven't selected avail option. Please select an avail option first.");
                    return false;
                }
              
                _view.AvailOption = assessment.AvailOption.ToString();
                _view.ApplicationDate = assessment.ApplicationDate;
                _view.PaymentCompeletionDate = assessment.PaymentCompeletionDate;
                _view.MaturityDate = assessment.MaturityDate;
                _view.PaymentCompletionAmount = assessment.PaymentCompletionAmount.Value;
                _view.AwardAmount = assessment.AwardAmount.Value;
                _view.PayedAmount = assessment.PaidAmount.Value;
                _view.Interests = assessment.Interests.Value;
                _view.DisbursedAmount = assessment.DisbursedAmount.Value;
                _view.MaximumWithdrawableAmount = assessment.MaximumWithdrawableAmount.Value;
                _view.WithdrawAmount = assessment.WithdrawAmount.Value;

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
