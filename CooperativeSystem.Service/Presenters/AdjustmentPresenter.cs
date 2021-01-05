using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan;
using CooperativeSystem.Service.Presenters.Savings.TimeDeposit.Calculators;
using CooperativeSystem.Service.Utilities.SequenceGenerators;

namespace CooperativeSystem.Service.Presenters
{
    public class AdjustmentPresenter : PresenterTemplate
    {
        #region Fields

        private DataContext _db;
        private IRepository<Member> _repository;

        // voucher generator
        private AdjustmentVoucherGenerator _voucherGenerator;

        // views
        private IAdjustmentView _parentView;
        private ICIPAdjustmentView _childCIPView;

        // object graphs
        private Member _member;
        private Adjustment _adjustment;

        #endregion

        #region Constructor

        public AdjustmentPresenter(IAdjustmentView parentView, ICIPAdjustmentView childCIPView)
        {
            // views
            _parentView = parentView;
            _childCIPView = childCIPView;

            // events
            WireChildViewEvents();
        }

        #endregion

        #region Routine Helpers

        private void InitializePersistenceManager()
        {
            _db = new DataContextFactory().CreateDataContext();
            _repository = new GenericRepository<Member>(_db);
            _voucherGenerator = new AdjustmentVoucherGenerator(_db);
        }


        private void WireChildViewEvents()
        {
            _childCIPView.MakeAdjustment += new EventHandler(CIPAdjustmentView_MakeAdjustment);
            //_childLoanView.AssessmentAdd += new EventHandler(ChildLoanView_AssessmentAdd);
            //_childCIPView.ReceiptAdd += new EventHandler(ChildCIPView_AssessmentAdd);
            //_childPensionPlanView.AssessmentAdd += new EventHandler(ChildPensionPlanView_AssessmentAdd);
            //_childTimeDepositView.AssessmentAdd += new EventHandler(ChildTimeDepositView_AssessmentAdd);
            //_childCapitalShareView.AssessmentAdd += new EventHandler(ChildCapitalShareView_AssessmentAdd);
            //_childSavingsDepositView.AssessmentAdd += new EventHandler(ChildSavingsDepositView_AssessmentAdd);
        }

        private void ReflectToParent(string serviceID, decimal amount)
        {
            // reflect to parent
            switch (serviceID)
            {
                //// loans
                //case ServiceCodes.ApplianceLoan:
                //    _parentView.ApplianceLoan = amount;
                //    break;
                //case ServiceCodes.EasyLoan:
                //    _parentView.EasyLoan = amount;
                //    break;
                //case ServiceCodes.EmergencyLoan:
                //    _parentView.EmergencyLoan = amount;
                //    break;
                //case ServiceCodes.EquityLoan:
                //    _parentView.EquityLoan = amount;
                //    break;
                //case ServiceCodes.PensionLoan:
                //    _parentView.PensionLoan = amount;
                //    break;
                //case ServiceCodes.RegularLoan:
                //    _parentView.RegularLoan = amount;
                //    break;
                //case ServiceCodes.DTILoan:          // TODO: remove this code soon
                //    _parentView.DTILoan = amount;
                //    break;
                //case ServiceCodes.MEDPLoan:         // TODO: remove this code soon
                //    _parentView.MEDPLoan = amount;
                //    break;

                // plans
                case ServiceCodes.CollegeInsurancePlan:
                    _parentView.CollegeInsurancePlan = amount;
                    break;
                //case ServiceCodes.PensionPlan:
                //    _parentView.PensionPlan = amount;
                //    break;

                //// savings
                //case ServiceCodes.CapitalShare:
                //    _parentView.CapitalShare = amount;
                //    break;
                //case ServiceCodes.SavingsDeposit:
                //    _parentView.SavingsDeposit = amount;
                //    break;
                //case ServiceCodes.TimeDeposit:
                //    _parentView.TimeDeposit = amount;
                //    break;

                //// special funds
                //case ServiceCodes.DeathAidFund:
                //    _parentView.DeathAidFund = amount;
                //    break;
                //case ServiceCodes.TulunganFund:
                //    _parentView.TulunganFund = amount;
                //    break;
            }

            if (!_parentView.IsThereAdjustment)
                _parentView.IsThereAdjustment = true;
        }

        private void InitializeParentDisplayFields()
        {
            //_parentView.IsLoadingReceiptDetails = true;
            const decimal DEFAULT_AMOUNT = 0M;
            _parentView.ApplianceLoan = DEFAULT_AMOUNT;
            _parentView.EasyLoan = DEFAULT_AMOUNT;
            _parentView.EmergencyLoan = DEFAULT_AMOUNT;
            _parentView.EquityLoan = DEFAULT_AMOUNT;
            _parentView.PensionLoan = DEFAULT_AMOUNT;
            _parentView.RegularLoan = DEFAULT_AMOUNT;
            _parentView.DTILoan = DEFAULT_AMOUNT;
            _parentView.MEDPLoan = DEFAULT_AMOUNT;
            _parentView.CollegeInsurancePlan = DEFAULT_AMOUNT;
            _parentView.PensionPlan = DEFAULT_AMOUNT;
            _parentView.CapitalShare = DEFAULT_AMOUNT;
            _parentView.SavingsDeposit = DEFAULT_AMOUNT;
            _parentView.TimeDeposit = DEFAULT_AMOUNT;
            _parentView.DeathAidFund = DEFAULT_AMOUNT;
            _parentView.TulunganFund = DEFAULT_AMOUNT;

            // generate voucher number
            _parentView.VoucherNumber = _voucherGenerator.Generate();
            //_parentView.IsLoadingReceiptDetails = false;
        }

        #endregion

        #region Object Graph state modifier methods

        private bool InitializeObjectGraph()
        {
            _parentView.IsLoadingDetails = true;
            _parentView.IsThereAdjustment = false;
            InitializePersistenceManager();
            InitializeParentDisplayFields();

            if (_parentView.MemberID == 0L)
            {
                RaiseErrorEvent("You did not perform customer search. Please select customer from custumer inquiry.");
                return false;
            }

            _member = _repository.GetEntity(m => m.MemberID == _parentView.MemberID);
            if (_member == null)
            {
                RaiseErrorEvent(string.Format("Member doesn't exist. Please select a valid member."));
                return false;
            }

            _adjustment = new Adjustment();
            _adjustment.AdjustmentDate = _parentView.AdjustmentDate;
            _adjustment.UserID = _parentView.UserID;
            _adjustment.Member = _member;

            _parentView.IsLoadingDetails = false;

            return true;
        }

        private bool FinalizeObjectGraph(out string remarks)
        {
            var hasChanged = false;
            remarks = string.Empty;
            var amount = 0M;

            Func<decimal, bool> HasValue = (x) => x != 0M;

            // loans
            amount = _parentView.ApplianceLoan;
            if (HasValue(amount))
            {
                MakeLoanAdjustment(ServiceCodes.ApplianceLoan, amount);
                hasChanged = true;
            }

            amount = _parentView.EasyLoan;
            if (HasValue(amount))
            {
                MakeLoanAdjustment(ServiceCodes.EasyLoan, amount);
                hasChanged = true;
            }

            amount = _parentView.EmergencyLoan;
            if (HasValue(amount))
            {
                MakeLoanAdjustment(ServiceCodes.EmergencyLoan, amount);
                hasChanged = true;
            }

            amount = _parentView.EquityLoan;
            if (HasValue(amount))
            {
                MakeLoanAdjustment(ServiceCodes.EquityLoan, amount);
                hasChanged = true;
            }

            amount = _parentView.PensionLoan;
            if (HasValue(amount))
            {
                MakeLoanAdjustment(ServiceCodes.PensionLoan, amount);
                hasChanged = true;
            }

            amount = _parentView.RegularLoan;
            if (HasValue(amount))
            {
                MakeLoanAdjustment(ServiceCodes.RegularLoan, amount);
                hasChanged = true;
            }

            amount = _parentView.DTILoan;
            if (HasValue(amount))
            {
                MakeLoanAdjustment(ServiceCodes.DTILoan, amount);
                hasChanged = true;
            }

            amount = _parentView.MEDPLoan;
            if (HasValue(amount))
            {
                MakeLoanAdjustment(ServiceCodes.MEDPLoan, amount);
                hasChanged = true;
            }


            // plans
            if (_childCIPView.CIPAdjustments.Any(x => x.Amount != 0M))
            {
                MakeCollegeInsurancePlanAdjustment();
                hasChanged = true;
            }

            amount = _parentView.PensionPlan;
            if (HasValue(amount))
            {
                MakePensionPlanAdjustment(amount);
                hasChanged = true;
            }


            // savings
            amount = _parentView.CapitalShare;
            if (HasValue(amount))
            {
                MakeCapitalShareAdjustment(amount);
                hasChanged = true;
            }

            amount = _parentView.SavingsDeposit;
            if (HasValue(amount))
            {
                MakeSavingsDepositAdjustment(amount);
                hasChanged = true;
            }

            amount = _parentView.TimeDeposit;
            if (HasValue(amount))
            {
                MakeTimeDepositAdjustment(amount);
                hasChanged = true;
            }


            // special funds
            amount = _parentView.DeathAidFund;
            if (HasValue(amount))
            {
                MakeDeathAidFundAdjustment(amount);
                hasChanged = true;
            }

            amount = _parentView.TulunganFund;
            if (HasValue(amount))
            {
                MakeTulunganFundAdjustment(amount);
                hasChanged = true;
            }

            if (hasChanged == false)
                remarks = "No adjustment has been made.";

            return hasChanged;
        }

        private void CIPAdjustmentView_MakeAdjustment(object sender, EventArgs e)
        {
            //var changeVersions = _childCIPView.CIPAdjustments
            //    .Where(a => a.HasChanged);

            //foreach (var changeVersion in changeVersions)
            //{
            //    var plan = _member.CollegeInsurancePlans.Single(x => x.CollegeInsurancePlanID == changeVersion.CollegeInsurancePlanID);
            //    var exists = plan.CollegeInsurancePlanAdjustments.Any(x => x.Adjustment == _adjustment);
            //    if (exists)
            //    {
            //        plan.UpdateCollegeInsurancePlanDisbursement(_adjustment,
            //            changeVersion.OriginalAmount, changeVersion.NewAmount);
            //    }
            //    else
            //    {
            //        plan.AddCollegeInsurancePlanAdjustment(new CollegeInsurancePlanAdjustment()
            //        {
            //            Adjustment = _adjustment,
            //            OriginalAmount = changeVersion.OriginalAmount,
            //            NewAmount = changeVersion.NewAmount
            //        });
            //    }
            //}

            ReflectToParent(ServiceCodes.CollegeInsurancePlan, _childCIPView.TotalAmount);
        }

        private void MakeTulunganFundAdjustment(decimal amount)
        {
            if (_member.TulunganFund == null)
            {
                _member.TulunganFund = new TulunganFund();
                _member.TulunganFund.CurrentBalance = 0M;
            }

            var exists = _member.TulunganFund.TulunganFundAdjustments.Any(x => x.Adjustment == _adjustment);
            if (exists)
                _member.TulunganFund.UpdateTulunganFundAdjustment(amount, _adjustment);
            else
                _member.TulunganFund.AddTulunganFundAdjustment(new TulunganFundAdjustment() { Amount = amount, Adjustment = _adjustment });
        }

        private void MakeDeathAidFundAdjustment(decimal amount)
        {
            if (_member.DeathAidFund == null)
            {
                _member.DeathAidFund = new DeathAidFund();
                _member.DeathAidFund.CurrentBalance = 0M;
            }

            var exists = _member.DeathAidFund.DeathAidFundAdjustments.Any(x => x.Adjustment == _adjustment);
            if (exists)
                _member.DeathAidFund.UpdateDeathAidFundAdjustment(amount, _adjustment);
            else
                _member.DeathAidFund.AddDeathAidFundAdjustment(new DeathAidFundAdjustment() { Amount = amount, Adjustment = _adjustment });
        }

        private void MakeTimeDepositAdjustment(decimal amount)
        {
            var timeDeposit = _member.TimeDeposits.LastOrDefault();

            if (timeDeposit == null)
            {
                throw new Exception(
                    "You do not have Time Deposit for this receipt. Adjustment is " +
                    "only allowed in receipts that has Time Deposit transaction."
                );
            }

            var exists = timeDeposit.TimeDepositAdjustments.Any(x => x.Adjustment == _adjustment);
            if (exists)
                timeDeposit.UpdateTimeDepositAdjustment(amount, _adjustment);
            else
                timeDeposit.AddTimeDepositAdjustment(new TimeDepositAdjustment() { Amount = amount, Adjustment = _adjustment });
        }

        private void MakeSavingsDepositAdjustment(decimal amount)
        {
            var exists = _member.SavingsDeposit.SavingsDepositAdjustments.Any(x => x.Adjustment == _adjustment);
            if (exists)
                _member.SavingsDeposit.UpdateSavingsDepositAdjustment(amount, _adjustment);
            else
                _member.SavingsDeposit.AddSavingsDepositAdjustment(new SavingsDepositAdjustment() { Amount = amount, Adjustment = _adjustment });
        }

        private void MakeCapitalShareAdjustment(decimal amount)
        {
            var exists = _member.CapitalShare.CapitalShareAdjustments.Any(x => x.Adjustment == _adjustment);
            if (exists)
                _member.CapitalShare.UpdateCapitalShareAdjustment(amount, _adjustment);
            else
                _member.CapitalShare.AddCapitalShareAdjustment(new CapitalShareAdjustment() { Amount = amount, Adjustment = _adjustment });
        }

        private void MakeCollegeInsurancePlanAdjustment()
        {
            var adjustmentItems = _childCIPView.CIPAdjustments.Where(x => x.Amount != 0M);

            foreach (var item in adjustmentItems)
            {
                var plan = _member.CollegeInsurancePlans.Single(x => x.CollegeInsurancePlanID == item.CollegeInsurancePlanID);
                var exists = plan.CollegeInsurancePlanAdjustments.Any(x => x.Adjustment == _adjustment);
                if (exists)
                    plan.UpdateCollegeInsurancePlanAdjustment(item.Amount, _adjustment);
                else
                    plan.AddCollegeInsurancePlanAdjustment(new CollegeInsurancePlanAdjustment() { Amount = item.Amount, Adjustment = _adjustment });
            }
        }

        private void MakePensionPlanAdjustment(decimal amount)
        {
            // check if pension plan is enrolled, do not allow adjustment if not enrolled
            if (_member.PensionPlan == null)
                throw new Exception(string.Format("Pension plan for {0} is not yet enrolled. " + "Adjustment is not allowed.", _member.ToString()));

            var exists = _member.PensionPlan.PensionPlanAdjustments.Any(x => x.Adjustment == _adjustment);
            if (exists)
                _member.PensionPlan.UpdatePensionPlanAdjustment(amount, _adjustment);
            else
                _member.PensionPlan.AddPensionPlanAdjustment(new PensionPlanAdjustment() { Amount = amount, Adjustment = _adjustment });
        }

        private void MakeLoanAdjustment(string serviceId, decimal amount)
        {
            // select the latest loan to adjust
            var loan = _member.Loans
                .Where(x => x.LoanServiceID == serviceId)
                .LastOrDefault();

            if (loan == null)
            {
                var service = _db.GetTable<Models.Service>()
                    .First(s => s.ServiceID == serviceId);

                throw new Exception(string.Format("No loan for {0} found.", service.ServiceName));
            }

            var exists = loan.LoanAdjustments.Any(x => x.Adjustment == _adjustment);
            if (exists)
                loan.UpdateLoanAdjustment(amount, _adjustment);
            else
                loan.AddLoanAdjustment(new LoanAdjustment() { Amount = amount, Adjustment = _adjustment });
        }

        #endregion

        #region Public Members

        public bool Load()
        {
            return InitializeObjectGraph();
        }

        public bool Clear()
        {
            return InitializeObjectGraph();
        }

        public bool GenerateVoucherNumber()
        {
            var remarks = string.Empty;
            var voucher = _voucherGenerator.Generate(_parentView.Sequence, out remarks);
            if (string.IsNullOrEmpty(voucher))
            {
                RaiseErrorEvent(remarks);
                return false;
            }

            _parentView.VoucherNumber = voucher;
            return true;
        }

        public bool Accept()
        {
            try
            {
                var remarks = string.Empty;
                if (!FinalizeObjectGraph(out remarks))
                {
                    RaiseErrorEvent(remarks);
                    return false;
                }

                _adjustment.AdjustmentDate = _parentView.AdjustmentDate;
                _adjustment.AdjustmentJournalVoucher = _parentView.VoucherNumber;

                _repository.SaveAll();
                RaiseSusccessEvent("Successful.");
                return true;
            }
            catch (Exception ex)
            {
                Clear(); // just to prevent unwanted modification fragments
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        #endregion
    }
}
