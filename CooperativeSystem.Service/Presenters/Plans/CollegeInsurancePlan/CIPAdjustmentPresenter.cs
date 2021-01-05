using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan
{
    public class CIPAdjustmentPresenter : PresenterTemplate
    {
        private ICIPAdjustmentView _view;

        public CIPAdjustmentPresenter(ICIPAdjustmentView view)
        {
            _view = view;
        }

        public bool Load()
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();
                //var repository = new GenericRepository<CooperativeSystem.Service.Models.CollegeInsurancePlan>(db);
                
                //var planQuery = db.GetTable<CooperativeSystem.Service.Models.CollegeInsurancePlan>()
                //    .Where(cip =>
                //        cip.MemberID == _view.MemberID &&
                //        cip.Consumed == false);

                //var planReceiptQuery = db.GetTable<CollegeInsurancePlanReceipt>()
                //    .Where(cipr => cipr.ReceiptID == _view.ReceiptID);

                //var query = planQuery
                //    .Where(plan =>
                //        plan.MemberID == _view.MemberID &&
                //        plan.Consumed == false)
                //    .GroupJoin(
                //        planReceiptQuery,
                //        plan => plan.CollegeInsurancePlanID,
                //        planReceipt => planReceipt.CollegeInsurancePlanID,
                //        (plan, planReceipt) => new { CollegeInsurancePlan = plan, CollegeInsurancePlanReceipts = planReceipt })
                //    .SelectMany(
                //        group => group.CollegeInsurancePlanReceipts.DefaultIfEmpty(),
                //        (group, prq) => new CIPAdjustmentItem()
                //        {
                //            CollegeInsurancePlanID = group.CollegeInsurancePlan.CollegeInsurancePlanID,
                //            OriginalAmount = (prq != null) ? prq.Amount : 0M,
                //            NewAmount = (prq != null) ? prq.Amount : 0M,
                //        });

                //var query = db.GetTable<Models.CollegeInsurancePlan>()
                //    .Where(x =>
                //        x.MemberID == _view.MemberID &&
                //        x.Consumed == false
                //    )
                //    .GroupJoin(
                //        db.GetTable<CollegeInsurancePlanReceipt>().Where(o => o.ReceiptID == _view.ReceiptID),
                //        x => x.CollegeInsurancePlanID,
                //        x => x.CollegeInsurancePlanID,
                //        (plan, receipt) => new 
                //        { 
                //            CollegeInsurancePlan = plan, 
                //            CollegeInsurancePlanReceipts = receipt 
                //        }
                //    )
                //    .SelectMany(
                //        x => x.CollegeInsurancePlanReceipts.DefaultIfEmpty(),
                //        (cipa, cipr) => new CIPAdjustmentItem()
                //        {
                //            CollegeInsurancePlanID = cipa.CollegeInsurancePlan.CollegeInsurancePlanID,
                //            UserName = cipa.CollegeInsurancePlan.UserLastName + ", " + 
                //                cipa.CollegeInsurancePlan.UserFirstName + " " + 
                //                cipa.CollegeInsurancePlan.UserMiddleName,
                //            Amount = (cipr != null) ? cipr.Amount : 0M
                //        }
                //    );

                var query = db.GetTable<Models.CollegeInsurancePlan>()
                    .Where(x =>
                        x.MemberID == _view.MemberID &&
                        x.Consumed == false
                    )
                    .Select(x => new CIPAdjustmentItem()
                    {
                        CollegeInsurancePlanID = x.CollegeInsurancePlanID,
                        UserName = x.UserFirstName + " " + x.UserLastName,
                        Amount = 0M,
                    });

                _view.CIPAdjustments = query.ToList();

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
