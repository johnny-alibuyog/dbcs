using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Presenters;
using System.Data.Linq;
using CooperativeSystem.Service.Presenters.Lookups.Services;

namespace CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan
{
    public class CIPSummaryPresenter : PresenterTemplate
    {
        private ICIPSummaryView _parentView;
        private ICIPEnrollmentView _childView;

        #region Routine Helpers

        private static DataContext CreateDataContext()
        {
            var loadOptions = new DataLoadOptions();
            loadOptions.LoadWith<Models.CollegeInsurancePlan>(x => x.Relation);
            loadOptions.LoadWith<Models.CollegeInsurancePlan>(x => x.PaymentMode);
            loadOptions.LoadWith<Models.CollegeInsurancePlan>(x => x.CollegeInsurancePlanReceipts);
            loadOptions.LoadWith<Models.CollegeInsurancePlan>(x => x.CollegeInsurancePlanAdjustments);
            loadOptions.LoadWith<Models.CollegeInsurancePlan>(x => x.CollegeInsurancePlanDisbursements);

            var db = new DataContextFactory().CreateDataContext();
            db.LoadOptions = loadOptions;
            return db;
        }

        private static GenericRepository<Models.CollegeInsurancePlan> CreateRepository()
        {
            var db = CreateDataContext();
            var repository = CreateRepository(db);
            return repository;
        }

        private static GenericRepository<Models.CollegeInsurancePlan> CreateRepository(DataContext db)
        {
            var repository = new GenericRepository<Models.CollegeInsurancePlan>(db);
            return repository;
        }

        private void FillEntity(Models.CollegeInsurancePlan entity, DataContext db)
        {
            entity.MemberID = _parentView.MemberID;

            entity.UserLastName = _childView.UserLastName;
            entity.UserFirstName = _childView.UserFirstName;
            entity.UserMiddleName = _childView.UserMiddleName;
            entity.DateOfBirth = _childView.DateOfBirth;
            entity.Relation = _childView.Relation != null
                ? db.GetTable<Relation>().Single(x => x.RelationID == _childView.Relation.RelationID)
                : null;
            entity.Address = _childView.Address;

            entity.ApplicationDate = _childView.ApplicationDate;
            entity.PaymentMode = db.GetTable<PaymentMode>().Single(x => x.PaymentModeID == _childView.PaymentMode.PaymentModeID);
            entity.Terms = _childView.Terms;
            entity.AgingPeriod = _childView.AgingPeriod;
            entity.Amortization = _childView.Amortization;
            entity.PaymentCompletionAmount = _childView.PaymentCompletionAmount;
            entity.AwardAmount = _childView.AwardAmount;
            //item.Consumed = false;
        }

        private void DisplayDetails(Models.CollegeInsurancePlan entity)
        {
            _parentView.Receipts = entity.CollegeInsurancePlanReceipts
                .Select(x => new TransactionModel()
                {
                    Date = x.CashReceipt.ReceiptDate,
                    TransactionType = "Receipt",
                    ReferenceNumber = x.CashReceipt.OfficialReceiptNumber,
                    Amount = x.Amount,
                    Balance = x.Balance
                })
                .Union(entity.CollegeInsurancePlanAdjustments
                .Select(x => new TransactionModel()
                {
                    Date = x.Adjustment.AdjustmentDate,
                    TransactionType = "Adjustment",
                    ReferenceNumber = x.Adjustment.AdjustmentJournalVoucher,
                    Amount = x.Amount,
                    Balance = x.Balance
                }))
                .Union(entity.CollegeInsurancePlanDisbursements
                .Select(x => new TransactionModel()
                {
                    Date = x.CashDisbursement.DisbursementDate,
                    TransactionType = "Disbursement",
                    ReferenceNumber = x.CashDisbursement.CashDisbursementVoucher,
                    Amount = x.Amount,
                    Balance = x.Balance
                }))
                .OrderBy(r => r.Date)
                .ToList();

            var last = _parentView.Receipts.LastOrDefault();
            _parentView.TotalBalance = last != null ? last.Balance : 0M; //entity.GetPaidAmount();

            _parentView.UserName = entity.UserName;
            _parentView.DateOfBirth = entity.DateOfBirth;
            _parentView.Relation = entity.Relation != null ? entity.Relation.ToString() : string.Empty;
            _parentView.Address = entity.Address;

            _parentView.ApplicationDate = entity.ApplicationDate;
            _parentView.PaymentCompletionDate = entity.PaymentCompletionDate;
            _parentView.MaturityDate = entity.MaturityDate;
            _parentView.PaymentMode = entity.PaymentMode.ToString();
            _parentView.Terms = entity.Terms;
            _parentView.AgingPeriod = entity.AgingPeriod;
            _parentView.Amortization = entity.Amortization;
            _parentView.PaymentCompletionAmount = entity.PaymentCompletionAmount;
            _parentView.AwardAmount = entity.AwardAmount;
        }

        #endregion

        #region Event Handlers

        private void EnrollmentView_Enroll(object sender, EventArgs e)
        {
            using (var db = CreateDataContext())
            {
                var cip = new Models.CollegeInsurancePlan();
                FillEntity(cip, db);
                db.SubmitChanges();

                var cips = db.GetTable<Models.CollegeInsurancePlan>()
                    .Where(x => x.MemberID == _parentView.MemberID)
                    .ToList();

                if (cips.Any())
                {
                    _parentView.CollegeInsurancePlans = cips
                        .Select(x => new CIPModel()
                        {
                            CollegeInsurancePlanID = x.CollegeInsurancePlanID,
                            Status = x.GetStatus(),
                            UserName = x.UserName,
                            MaturityDate = x.MaturityDate
                        })
                        .ToList();
                }
            }
        }

        private void EnrollmentView_Modify(object sender, EventArgs e)
        {
            using (var db = CreateDataContext())
            {
                var cip = db.GetTable<Models.CollegeInsurancePlan>()
                    .Where(x => x.CollegeInsurancePlanID == _childView.CollegeInsurancePlanID)
                    .FirstOrDefault();

                FillEntity(cip, db);
                db.SubmitChanges();

                var cips = db.GetTable<Models.CollegeInsurancePlan>()
                    .Where(x => x.MemberID == _parentView.MemberID)
                    .ToList();

                if (cips.Any())
                {
                    _parentView.CollegeInsurancePlans = cips
                        .Select(x => new CIPModel()
                        {
                            CollegeInsurancePlanID = x.CollegeInsurancePlanID,
                            Status = x.GetStatus(),
                            UserName = x.UserName,
                            MaturityDate = x.MaturityDate
                        })
                        .ToList();
                }
            }
        }

        #endregion

        public CIPSummaryPresenter(ICIPSummaryView parentView, ICIPEnrollmentView childView)
        {
            _parentView = parentView;
            _childView = childView;

            _childView.Enroll += new EventHandler(EnrollmentView_Enroll);
            _childView.Modify += new EventHandler(EnrollmentView_Modify);
        }

        public bool LoadPulldownValues()
        {
            try
            {
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    var relations = db.GetTable<Relation>();
                    var paymentModes = db.GetTable<ServicePaymentMode>()
                        .Where(x => x.ServiceID == ServiceCodes.CollegeInsurancePlan)
                        .Select(x => x.PaymentMode);

                    _childView.PopulatePaymentModePulldown(paymentModes.ToList());
                    _childView.PopulateRelationPulldown(relations.ToList());
                }

                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }


        public bool Load(long memberID)
        {
            try
            {
                // load member cips
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Models.CollegeInsurancePlan>(x => x.Relation);
                loadOptions.LoadWith<Models.CollegeInsurancePlan>(x => x.PaymentMode);
                loadOptions.LoadWith<Models.CollegeInsurancePlan>(x => x.CollegeInsurancePlanReceipts);
                //loadOptions.LoadWith<Models.CollegeInsurancePlan>(x => x.CollegeInsurancePlanAdjustments);
                loadOptions.LoadWith<Models.CollegeInsurancePlan>(x => x.CollegeInsurancePlanDisbursements);
                loadOptions.LoadWith<Models.CollegeInsurancePlanReceipt>(x => x.CashReceipt);
                //loadOptions.LoadWith<Models.CollegeInsurancePlanAdjustment>(x => x.Adjustment);
                loadOptions.LoadWith<Models.CollegeInsurancePlanDisbursement>(x => x.CashDisbursement);

                using (var db = new DataContextFactory().CreateDataContext())
                {
                    db.LoadOptions = loadOptions;

                    var cips = db.GetTable<Models.CollegeInsurancePlan>()
                        .Where(x => x.MemberID == memberID)
                        .ToList();

                    if (cips.Any())
                    {
                        _parentView.CollegeInsurancePlans = cips
                            .Select(x => new CIPModel()
                            {
                                CollegeInsurancePlanID = x.CollegeInsurancePlanID,
                                Status = x.GetStatus(),
                                UserName = x.UserName,
                                MaturityDate = x.MaturityDate
                            })
                            .ToList();

                        DisplayDetails(cips.First());
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool CheckQualification()
        {
            try
            {
                var hasRequiredMinimumShare = false;
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    hasRequiredMinimumShare = db.GetTable<CapitalShare>()
                        .Where(x =>
                            x.MemberID == _parentView.MemberID &&
                            x.CurrentBalance >= db.GetTable<CapitalShareMinimumAmount>().FirstOrDefault().Amount
                        )
                        .Any();
                }

                if (!hasRequiredMinimumShare)
                {
                    RaiseErrorEvent("You must have the required minimum share to avail this service.");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool Clear()
        {
            //_repository = null;
            //_member = null;

            _parentView.MemberID = 0L;

            _parentView.CollegeInsurancePlans = null;
            _parentView.Receipts = null;

            _parentView.TotalBalance = null;

            _parentView.UserName = string.Empty;
            _parentView.DateOfBirth = null;
            _parentView.Relation = string.Empty;
            _parentView.Address = string.Empty;

            _parentView.ApplicationDate = null;
            _parentView.PaymentCompletionDate = null;
            _parentView.MaturityDate = null;
            _parentView.PaymentMode = string.Empty;
            _parentView.Terms = null;
            _parentView.AgingPeriod = null;
            _parentView.Amortization = null;
            _parentView.PaymentCompletionAmount = null;
            _parentView.AwardAmount = null;

            return true;
        }

        public bool DisplayPlanDetails(long collegeInsurancePlanID)
        {
            try
            {
                //var repository = CreateRepository();

                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Models.CollegeInsurancePlan>(x => x.Relation);
                loadOptions.LoadWith<Models.CollegeInsurancePlan>(x => x.PaymentMode);
                loadOptions.LoadWith<Models.CollegeInsurancePlan>(x => x.CollegeInsurancePlanReceipts);
                loadOptions.LoadWith<Models.CollegeInsurancePlan>(x => x.CollegeInsurancePlanAdjustments);
                loadOptions.LoadWith<Models.CollegeInsurancePlan>(x => x.CollegeInsurancePlanDisbursements);
                loadOptions.LoadWith<Models.CollegeInsurancePlanReceipt>(x => x.CashReceipt);
                loadOptions.LoadWith<Models.CollegeInsurancePlanAdjustment>(x => x.Adjustment);
                loadOptions.LoadWith<Models.CollegeInsurancePlanDisbursement>(x => x.CashDisbursement);

                Models.CollegeInsurancePlan cip = null;
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    db.LoadOptions = loadOptions;

                    if (_parentView.MemberID == 0)
                        return false;

                    cip = db.GetTable<Models.CollegeInsurancePlan>()
                        .Where(x => x.CollegeInsurancePlanID == collegeInsurancePlanID)
                        .FirstOrDefault();
                }

                if (cip == null)
                {
                    RaiseErrorEvent("Unable to display plan's details.");
                    return false;
                }

                DisplayDetails(cip);
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
