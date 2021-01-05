using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Savings.TimeDeposit.Calculators;
using CooperativeSystem.Service.Utilities.SequenceGenerators;
using CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan;

namespace CooperativeSystem.Service.Presenters
{
    #region Helpers

    internal class AdjustmentChangeVersion<TReceipt>
    {
        public virtual TReceipt Receipt { get; private set; }
        public virtual decimal OriginalAmount { get; private set; }
        public virtual decimal NewAmount { get; private set; }
        public virtual decimal ChangedAmount { get { return OriginalAmount - NewAmount; } }
        public virtual string ServiceID { get; private set; }
        public virtual bool HasChanged { get { return (OriginalAmount != NewAmount); } }

        public AdjustmentChangeVersion(TReceipt receipt, decimal originalAmount, decimal newAmount, string serviceID)
        {
            Receipt = receipt;
            OriginalAmount = originalAmount;
            NewAmount = newAmount;
            ServiceID = serviceID;
        }
    }

    internal class AdjustmentChangeTracker
    {
        private const decimal DEFAULT_VALUE = 0M;

        private IAdjustmentView _view;
        private ICIPAdjustmentView _cipView;
        private CashReceipt _cashReceipt;

        // loans
        public AdjustmentChangeVersion<LoanReceipt> ApplianceLoan
        {
            get
            {
                var receipt = _cashReceipt.LoanReceipts
                    .FirstOrDefault(lr => lr.Loan.LoanServiceID == ServiceCodes.ApplianceLoan);
                var originalAmount = receipt != null ? receipt.Amount : DEFAULT_VALUE;;
                var newAmount = _view.ApplianceLoan;
                return new AdjustmentChangeVersion<LoanReceipt>(receipt, originalAmount, newAmount, ServiceCodes.ApplianceLoan);
            } 
        }

        public AdjustmentChangeVersion<LoanReceipt> EasyLoan
        {
            get
            {
                var receipt = _cashReceipt.LoanReceipts
                    .FirstOrDefault(lr => lr.Loan.LoanServiceID == ServiceCodes.EasyLoan);
                var originalAmount = receipt != null ? receipt.Amount : DEFAULT_VALUE; ;
                var newAmount = _view.EasyLoan;
                return new AdjustmentChangeVersion<LoanReceipt>(receipt, originalAmount, newAmount, ServiceCodes.EasyLoan);
            }
        }

        public AdjustmentChangeVersion<LoanReceipt> EmergencyLoan
        {
            get
            {
                var receipt = _cashReceipt.LoanReceipts
                    .FirstOrDefault(lr => lr.Loan.LoanServiceID == ServiceCodes.EmergencyLoan);
                var originalAmount = receipt != null ? receipt.Amount : DEFAULT_VALUE; ;
                var newAmount = _view.EmergencyLoan;
                return new AdjustmentChangeVersion<LoanReceipt>(receipt, originalAmount, newAmount, ServiceCodes.EmergencyLoan);
            }
        }

        public AdjustmentChangeVersion<LoanReceipt> EquityLoan
        {
            get
            {
                var receipt = _cashReceipt.LoanReceipts
                    .FirstOrDefault(lr => lr.Loan.LoanServiceID == ServiceCodes.EquityLoan);
                var originalAmount = receipt != null ? receipt.Amount : DEFAULT_VALUE; ;
                var newAmount = _view.EquityLoan;
                return new AdjustmentChangeVersion<LoanReceipt>(receipt, originalAmount, newAmount, ServiceCodes.EquityLoan);
            }
        }

        public AdjustmentChangeVersion<LoanReceipt> PensionLoan
        {
            get
            {
                var receipt = _cashReceipt.LoanReceipts
                    .FirstOrDefault(lr => lr.Loan.LoanServiceID == ServiceCodes.PensionLoan);
                var originalAmount = receipt != null ? receipt.Amount : DEFAULT_VALUE; ;
                var newAmount = _view.PensionLoan;
                return new AdjustmentChangeVersion<LoanReceipt>(receipt, originalAmount, newAmount, ServiceCodes.PensionLoan);
            }
        }

        public AdjustmentChangeVersion<LoanReceipt> RegularLoan
        {
            get
            {
                var receipt = _cashReceipt.LoanReceipts
                    .FirstOrDefault(lr => lr.Loan.LoanServiceID == ServiceCodes.RegularLoan);
                var originalAmount = receipt != null ? receipt.Amount : DEFAULT_VALUE; ;
                var newAmount = _view.RegularLoan;
                return new AdjustmentChangeVersion<LoanReceipt>(receipt, originalAmount, newAmount, ServiceCodes.RegularLoan);
            }
        }

        public AdjustmentChangeVersion<LoanReceipt> DTILoan
        {
            get
            {
                var receipt = _cashReceipt.LoanReceipts
                    .FirstOrDefault(lr => lr.Loan.LoanServiceID == ServiceCodes.DTILoan);
                var originalAmount = receipt != null ? receipt.Amount : DEFAULT_VALUE; ;
                var newAmount = _view.DTILoan;
                return new AdjustmentChangeVersion<LoanReceipt>(receipt, originalAmount, newAmount, ServiceCodes.DTILoan);
            }
        }

        public AdjustmentChangeVersion<LoanReceipt> MEDPLoan
        {
            get
            {
                var receipt = _cashReceipt.LoanReceipts
                    .FirstOrDefault(lr => lr.Loan.LoanServiceID == ServiceCodes.MEDPLoan);
                var originalAmount = receipt != null ? receipt.Amount : DEFAULT_VALUE; ;
                var newAmount = _view.MEDPLoan;
                return new AdjustmentChangeVersion<LoanReceipt>(receipt, originalAmount, newAmount, ServiceCodes.MEDPLoan);
            }
        }


        // plans
        public IList<AdjustmentChangeVersion<CollegeInsurancePlanReceipt>> CollegeInsurancePlans
        {
            get
            {
                var changeVersions = new List<AdjustmentChangeVersion<CollegeInsurancePlanReceipt>>();
                foreach (var receipt in _cashReceipt.CollegeInsurancePlanReceipts)
                {
                    var adjustment = _cipView.CIPAdjustments.FirstOrDefault(x => x.CollegeInsurancePlanID == receipt.CollegeInsurancePlanID);
                    var originalAmount = receipt.Amount;
                    var newAmount = adjustment != null ? adjustment.NewAmount : 0M;
                    var changeVersion = new AdjustmentChangeVersion<CollegeInsurancePlanReceipt>(receipt, originalAmount, newAmount, ServiceCodes.CollegeInsurancePlan);
                    changeVersions.Add(changeVersion);
                }

                //foreach (var item in _cipView.CIPAdjustments)
                //{
                //    var receipt = _cashReceipt.CollegeInsurancePlanReceipts.FirstOrDefault(x => x.CollegeInsurancePlanID == item.CollegeInsurancePlanID);
                //    var originalAmount = receipt != null ? receipt.Amount : DEFAULT_VALUE;
                //    var newAmount = item.NewAmount;
                //    var changeVersion = new AdjustmentChangeVersion<CollegeInsurancePlanReceipt>(receipt, originalAmount, newAmount, ServiceCodes.CollegeInsurancePlan);
                //    changeVersions.Add(changeVersion);
                //}

                return changeVersions;
            }
        }

        public AdjustmentChangeVersion<PensionPlanReceipt> PensionPlan
        {
            get
            {
                var receipt = _cashReceipt.PensionPlanReceipts.FirstOrDefault();
                var originalAmount = receipt != null ? receipt.Amount : DEFAULT_VALUE;
                var newAmount = _view.PensionPlan;
                return new AdjustmentChangeVersion<PensionPlanReceipt>(receipt, originalAmount, newAmount, ServiceCodes.PensionPlan);
            }
        }


        // savings
        public AdjustmentChangeVersion<CapitalShareReceipt> CapitalShare
        {
            get
            {
                var receipt = _cashReceipt.CapitalShareReceipts.FirstOrDefault();
                var originalAmount = receipt != null ? receipt.Amount : DEFAULT_VALUE;
                var newAmount = _view.CapitalShare;
                return new AdjustmentChangeVersion<CapitalShareReceipt>(receipt, originalAmount, newAmount, ServiceCodes.CapitalShare);
            }
        }

        public AdjustmentChangeVersion<SavingsDepositReceipt> SavingsDeposit
        {
            get
            {
                var receipt = _cashReceipt.SavingsDepositReceipts.FirstOrDefault();
                var originalAmount = receipt != null ? receipt.Amount : DEFAULT_VALUE;
                var newAmount = _view.SavingsDeposit;
                return new AdjustmentChangeVersion<SavingsDepositReceipt>(receipt, originalAmount, newAmount, ServiceCodes.SavingsDeposit);
            }
        }

        public AdjustmentChangeVersion<TimeDepositReceipt> TimeDeposit
        {
            get
            {
                var receipt = _cashReceipt.TimeDepositReceipts.FirstOrDefault();
                var originalAmount = receipt != null ? receipt.Amount : DEFAULT_VALUE;
                var newAmount = _view.TimeDeposit;
                return new AdjustmentChangeVersion<TimeDepositReceipt>(receipt, originalAmount, newAmount, ServiceCodes.TimeDeposit);
            }
        }


        // special funds
        public AdjustmentChangeVersion<DeathAidFundReceipt> DeathAidFund
        {
            get
            {
                var receipt = _cashReceipt.DeathAidFundReceipts.FirstOrDefault();
                var originalAmount = receipt != null ? receipt.Amount : DEFAULT_VALUE;
                var newAmount = _view.DeathAidFund;
                return new AdjustmentChangeVersion<DeathAidFundReceipt>(receipt, originalAmount, newAmount, ServiceCodes.DeathAidFund);
            }
        }

        public AdjustmentChangeVersion<TulunganFundReceipt> TulunganFund
        {
            get
            {
                var receipt = _cashReceipt.TulunganFundReceipts.FirstOrDefault();
                var originalAmount = receipt != null ? receipt.Amount : DEFAULT_VALUE;
                var newAmount = _view.TulunganFund;
                return new AdjustmentChangeVersion<TulunganFundReceipt>(receipt, originalAmount, newAmount, ServiceCodes.TulunganFund);
            }
        }


        public AdjustmentChangeTracker(IAdjustmentView view, ICIPAdjustmentView cipView, CashReceipt cashReceipt)
        {
            _view = view;
            _cipView = cipView;
            _cashReceipt = cashReceipt;
        }
    }

    #endregion

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
        private CashReceipt _cashReceipt;
        private AdjustmentChangeTracker _changeTracker;

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

            var cashReceiptsLookup = _member.CashReceipts
                .Select(cr => new CashReceiptLookupModel()
                {
                    ReceiptID = cr.ReceiptID,
                    OfficialReceiptNumber = cr.OfficialReceiptNumber
                })
                .OrderByDescending(crlm => crlm.OfficialReceiptNumber)
                .ToList();

            _parentView.PopulateReceiptPulldown(cashReceiptsLookup);

            _adjustment = new Adjustment();
            _adjustment.AdjustmentDate = _parentView.AdjustmentDate;
            _adjustment.UserID = _parentView.UserID;
            _adjustment.Member = _member;

            _cashReceipt = null;
            _parentView.IsLoadingDetails = false;

            return true;
        }

        private bool FinalizeObjectGraph(out string remarks)
        {
            var hasChanged = false;
            remarks = string.Empty;

            // loans
            var applianceLoanChangeVersion = _changeTracker.ApplianceLoan;
            if (applianceLoanChangeVersion.HasChanged)
            {
                MakeLoanAdjustment(applianceLoanChangeVersion);
                hasChanged = true;
            }

            var easyLoanChangeVesrion = _changeTracker.EasyLoan;
            if (easyLoanChangeVesrion.HasChanged)
            {
                MakeLoanAdjustment(easyLoanChangeVesrion);
                hasChanged = true;
            }

            var emergencyLoanChangeVersion = _changeTracker.EmergencyLoan;
            if (emergencyLoanChangeVersion.HasChanged)
            {
                MakeLoanAdjustment(emergencyLoanChangeVersion);
                hasChanged = true;
            }

            var equityLoanChangeVersion = _changeTracker.EquityLoan;
            if (equityLoanChangeVersion.HasChanged)
            {
                MakeLoanAdjustment(equityLoanChangeVersion);
                hasChanged = true;
            }

            var pensionLoanChangeVersion = _changeTracker.PensionLoan;
            if (pensionLoanChangeVersion.HasChanged)
            {
                MakeLoanAdjustment(pensionLoanChangeVersion);
                hasChanged = true;
            }

            var regularLoanChangeVersion = _changeTracker.RegularLoan;
            if (regularLoanChangeVersion.HasChanged)
            {
                MakeLoanAdjustment(regularLoanChangeVersion);
                hasChanged = true;
            }

            var dtiLoanChangeVersion = _changeTracker.DTILoan;
            if (dtiLoanChangeVersion.HasChanged)
            {
                MakeLoanAdjustment(dtiLoanChangeVersion);
                hasChanged = true;
            }

            var medpLoanChangeVersion = _changeTracker.MEDPLoan;
            if (medpLoanChangeVersion.HasChanged)
            {
                MakeLoanAdjustment(medpLoanChangeVersion);
                hasChanged = true;
            }
            

            // plans
            var cipsChangeVersions = _changeTracker.CollegeInsurancePlans;
            if (cipsChangeVersions.Any(x => x.HasChanged))
            {
                MakeCollegeInsurancePlanAdjustment();
                hasChanged = true;
            }

            var pensionPlanChangeVersion = _changeTracker.PensionPlan;
            if (pensionPlanChangeVersion.HasChanged)
            {
                MakePensionPlanAdjustment(pensionPlanChangeVersion);
                hasChanged = true;
            }


            // savings
            var capitalShareChangeVesrion = _changeTracker.CapitalShare;
            if (capitalShareChangeVesrion.HasChanged)
            {
                MakeCapitalShareAdjustment(capitalShareChangeVesrion);
                hasChanged = true;
            }

            var savingsDepositChangeVersion = _changeTracker.SavingsDeposit;
            if (savingsDepositChangeVersion.HasChanged)
            {
                MakeSavingsDepositAdjustment(savingsDepositChangeVersion);
                hasChanged = true;
            }

            var timeDepositChangeVersion = _changeTracker.TimeDeposit;
            if (timeDepositChangeVersion.HasChanged)
            {
                MakeTimeDepositAdjustment(timeDepositChangeVersion);
                hasChanged = true;
            }


            // special funds
            var deathAidFundChangeVersion = _changeTracker.DeathAidFund;
            if (deathAidFundChangeVersion.HasChanged)
            {
                MakeDeathAidFundAdjustment(deathAidFundChangeVersion);
                hasChanged = true;
            }

            var tulunganFundChangeVersion = _changeTracker.TulunganFund;
            if (tulunganFundChangeVersion.HasChanged)
            {
                MakeTulunganFundAdjustment(tulunganFundChangeVersion);
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
        
        private void MakeTulunganFundAdjustment(AdjustmentChangeVersion<TulunganFundReceipt> changeVersion)
        {
            if (_member.TulunganFund == null)
            {
                _member.TulunganFund = new TulunganFund();
                _member.TulunganFund.CurrentBalance = 0M;
            }

            var exists = _member.TulunganFund.TulunganFundAdjustments.Any(x => x.Adjustment == _adjustment);
            if (exists)
            {
                _member.TulunganFund.UpdateTulunganFundAdjustment(_adjustment,
                    changeVersion.OriginalAmount, changeVersion.NewAmount);
            }
            else
            {
                _member.TulunganFund.AddTulunganFundAdjustment(new TulunganFundAdjustment()
                {
                    Adjustment = _adjustment,
                    OriginalAmount = changeVersion.OriginalAmount,
                    NewAmount = changeVersion.NewAmount
                });
            }
        }

        private void MakeDeathAidFundAdjustment(AdjustmentChangeVersion<DeathAidFundReceipt> changeVersion)
        {
            if (_member.DeathAidFund == null)
            {
                _member.DeathAidFund = new DeathAidFund();
                _member.DeathAidFund.CurrentBalance = 0M;
            }

            var exists = _member.DeathAidFund.DeathAidFundAdjustments.Any(x => x.Adjustment == _adjustment);
            if (exists)
            {
                _member.DeathAidFund.UpdateDeathAidFundAdjustment(_adjustment,
                    changeVersion.OriginalAmount, changeVersion.NewAmount);
            }
            else
            {
                _member.DeathAidFund.AddDeathAidFundAdjustment(new DeathAidFundAdjustment()
                {
                    Adjustment = _adjustment,
                    OriginalAmount = changeVersion.OriginalAmount,
                    NewAmount = changeVersion.NewAmount
                });
            }
        }

        private void MakeTimeDepositAdjustment(AdjustmentChangeVersion<TimeDepositReceipt> changeVersion)
        {
            var timeDeposit = _member.TimeDeposits
                .SelectMany(x => x.TimeDepositReceipts)
                .Where(x => x.CashReceipt == _cashReceipt)
                .Select(x => x.TimeDeposit)
                .FirstOrDefault();

            if (timeDeposit == null)
                throw new Exception("You do not have Time Deposit for this receipt. " +
                    "Adjustment is only allowed in receipts that has Time Deposit transaction.");

            var minimum = _db.GetTable<TimeDepositMinimumAmount>().FirstOrDefault();
            if (changeVersion.NewAmount < minimum.Amount)
                throw new Exception(string.Format("Adjustment is under minimum amount of {0}. " +
                    "Adjustment is not allowd.", minimum.Amount.ToString("N2")));

            // compute for interest rate
            var interestRateCalculator = new InterestRateCalculator(_db.GetTable<TimeDepositInterestRate>().FirstOrDefault());
            var interestRate = interestRateCalculator.ComputeInterest(changeVersion.NewAmount);

            var exists = timeDeposit.TimeDepositAdjustments.Any(x => x.Adjustment == _adjustment);
            if (exists)
            {
                timeDeposit.UpdateTimeDepositAdjustment(_adjustment,
                    changeVersion.OriginalAmount, changeVersion.NewAmount, interestRate);
            }
            else
            {
                timeDeposit.AddTimeDepositAdjustment(new TimeDepositAdjustment()
                    {
                        Adjustment = _adjustment,
                        OriginalAmount = changeVersion.OriginalAmount,
                        NewAmount = changeVersion.NewAmount
                    },
                    interestRate);
            }
        }

        private void MakeSavingsDepositAdjustment(AdjustmentChangeVersion<SavingsDepositReceipt> changeVersion)
        {
            var exists = _member.SavingsDeposit.SavingsDepositAdjustments.Any(x => x.Adjustment == _adjustment);
            if (exists)
            {
                _member.SavingsDeposit.UpdateSavingsDepositAdjustment(_adjustment,
                    changeVersion.OriginalAmount, changeVersion.NewAmount);
            }
            else
            {
                _member.SavingsDeposit.AddSavingsDepositAdjustment(new SavingsDepositAdjustment()
                    {
                        Adjustment = _adjustment,
                        OriginalAmount = changeVersion.OriginalAmount,
                        NewAmount = changeVersion.NewAmount
                    });
            }
        }

        private void MakeCapitalShareAdjustment(AdjustmentChangeVersion<CapitalShareReceipt> changeVersion)
        {
            var exists = _member.CapitalShare.CapitalShareAdjustments.Any(x => x.Adjustment == _adjustment);
            if (exists)
            {
                _member.CapitalShare.UpdateCapitalShareAdjustment(_adjustment,
                    changeVersion.OriginalAmount, changeVersion.NewAmount);
            }
            else
            {
                _member.CapitalShare.AddCapitalShareAdjustment(new CapitalShareAdjustment()
                {
                    Adjustment = _adjustment,
                    OriginalAmount = changeVersion.OriginalAmount,
                    NewAmount = changeVersion.NewAmount
                });
            }
        }

        private void MakeCollegeInsurancePlanAdjustment()
        {
            var changeVersions = _childCIPView.CIPAdjustments
                .Where(a => a.HasChanged);

            foreach (var changeVersion in changeVersions)
            {
                var plan = _member.CollegeInsurancePlans.Single(x => x.CollegeInsurancePlanID == changeVersion.CollegeInsurancePlanID);
                var exists = plan.CollegeInsurancePlanAdjustments.Any(x => x.Adjustment == _adjustment);
                if (exists)
                {
                    plan.UpdateCollegeInsurancePlanDisbursement(_adjustment,
                        changeVersion.OriginalAmount, changeVersion.NewAmount);
                }
                else
                {
                    plan.AddCollegeInsurancePlanAdjustment(new CollegeInsurancePlanAdjustment()
                    {
                        Adjustment = _adjustment,
                        OriginalAmount = changeVersion.OriginalAmount,
                        NewAmount = changeVersion.NewAmount
                    });
                }
            }
        }

        private void MakePensionPlanAdjustment(AdjustmentChangeVersion<PensionPlanReceipt> changeVersion)
        {
            // check if pension plan is enrolled, do not allow adjustment if not enrolled
            if (_member.PensionPlan == null)
                throw new Exception(string.Format("Pension plan for {0} is not yet enrolled. " +
                    "Adjustment is not allowed.", _member.ToString()));

            var exists = _member.PensionPlan.PensionPlanAdjustments.Any(x => x.Adjustment == _adjustment);
            if (exists)
            {
                _member.PensionPlan.UpdatePensionPlanAdjustment(_adjustment,
                    changeVersion.OriginalAmount, changeVersion.NewAmount);
            }
            else
            {
                _member.PensionPlan.AddPensionPlanAdjustment(new PensionPlanAdjustment()
                {
                    Adjustment = _adjustment,
                    OriginalAmount = changeVersion.OriginalAmount,
                    NewAmount = changeVersion.NewAmount
                });
            }
        }

        private void MakeLoanAdjustment(AdjustmentChangeVersion<LoanReceipt> changeVersion)
        {
            // check if there is outstanding loan for the adjustment
            //var hasUnsettledLoan = _member.Loans
            //    .Any(l =>
            //        l.LoanServiceID == changeVersion.ServiceID &&
            //        l.Settled == false);

            //if (!hasUnsettledLoan)
            //{
            //    {
            //        var service = _db.GetTable<Models.Service>()
            //            .First(s => s.ServiceID == changeVersion.ServiceID);

            //        throw new Exception(string.Format("{0} doesn't have unsettled {1}. Adjustment is not allowed."
            //            , _member.ToString(), service.ToString()));
            //    }
            //}

            //var loan = _member.Loans
            //    .SelectMany(x => x.LoanAdjustments)
            //    .Where(x => x.Adjustment == _adjustment)
            //    .Select(x => x.Loan)
            //    .FirstOrDefault();

            // select the latest loan to adjust
            var loan = _member.Loans
                .Where(x => 
                    x.LoanServiceID == changeVersion.ServiceID &&
                    x.LoanDate <= _cashReceipt.ReceiptDate)
                .SelectMany(x => x.LoanReceipts)
                .OrderByDescending(x => x.CashReceipt.ReceiptDate)
                .Select(x => x.Loan)
                .FirstOrDefault();

            if (loan == null)
            {
                var service = _db.GetTable<Models.Service>()
                    .First(s => s.ServiceID == changeVersion.ServiceID);

                throw new Exception(string.Format("{0} doesn't have valid {1} for date {2}. Adjustment is not allowed."
                    , _member.ToString(), service.ToString(), _cashReceipt.ReceiptDate.ToShortDateString()));
            }
            
            var exists = loan.LoanAdjustments.Any(x => x.Adjustment == _adjustment);
            if (exists)
            {
                loan.UpdateLoanAdjustment(_adjustment,
                    changeVersion.OriginalAmount, changeVersion.NewAmount);
            }
            else
            {
                loan.AddLoanAdjustment(new LoanAdjustment()
                {
                    Adjustment = _adjustment,
                    OriginalAmount = changeVersion.OriginalAmount,
                    NewAmount = changeVersion.NewAmount
                });
            }

            //var receipt = changeVersion.Receipt;
            //if (receipt == null)
            //{
            //    // check if there is outstanding loan for the adjustment
            //    var loan = _member.Loans
            //        .FirstOrDefault(l => 
            //            l.LoanServiceID == changeVersion.ServiceID && 
            //            l.Settled == false);

            //    // no current loan to be adjusted, do not allow adjustment
            //    if (loan == null)
            //    {
            //        var service = _db.GetTable<Models.Service>()
            //            .First(s => s.ServiceID == changeVersion.ServiceID);

            //        throw new Exception(string.Format("{0} doesn't have unsettled {1}. Adjustment is not allowed."
            //            , _member.ToString(), service.ToString()));
            //    }

            //    // link relations
            //    receipt = new LoanReceipt();
            //    receipt.CashReceipt = _cashReceipt;
            //    receipt.Loan = loan;
            //}

            //// assing the new amount
            //receipt.Amount = changeVersion.NewAmount;

            //// check if needs it to set settled
            //receipt.Loan.Settled = false; // reset
            //receipt.Loan.Settled = (receipt.Loan.OutstandingBalance <= 0M); //(changeVersion.NewAmount >= receipt.Loan.OutstandingBalance);

            //// log adjustment
            //var loanAdjustment = new LoanAdjustment();
            //loanAdjustment.LoanID = receipt.LoanID;
            //loanAdjustment.OriginalAmount = changeVersion.OriginalAmount;
            //loanAdjustment.NewAmount = changeVersion.NewAmount;

            //_adjustment.LoanAdjustments.Add(loanAdjustment);
        }

        #endregion

        #region Public Members

        public bool Load()
        {
            return InitializeObjectGraph();
        }

        public bool LoadReceipt(long receiptID)
        {
            try
            {
                _parentView.IsLoadingDetails = true;

                _cashReceipt = _db.GetTable<CashReceipt>()
                    .FirstOrDefault(cr => cr.ReceiptID == receiptID);

                if (_cashReceipt == null)
                {
                    RaiseErrorEvent("Receipt number does not exist. Please verify.");
                    return false;
                }

                _adjustment.CashReceipt = _cashReceipt;
                _changeTracker = new AdjustmentChangeTracker(_parentView, _childCIPView, _cashReceipt);

                // loans
                _parentView.ApplianceLoan = _changeTracker.ApplianceLoan.OriginalAmount;
                _parentView.EasyLoan = _changeTracker.EasyLoan.OriginalAmount;
                _parentView.EmergencyLoan = _changeTracker.EmergencyLoan.OriginalAmount;
                _parentView.EquityLoan = _changeTracker.EquityLoan.OriginalAmount;
                _parentView.PensionLoan = _changeTracker.PensionLoan.OriginalAmount;
                _parentView.RegularLoan = _changeTracker.RegularLoan.OriginalAmount;
                _parentView.DTILoan = _changeTracker.DTILoan.OriginalAmount;
                _parentView.MEDPLoan = _changeTracker.MEDPLoan.OriginalAmount;

                // plans
                _parentView.CollegeInsurancePlan = _changeTracker.CollegeInsurancePlans.Sum(x => x.OriginalAmount);
                _parentView.PensionPlan = _changeTracker.PensionPlan.OriginalAmount;

                // savings
                _parentView.CapitalShare = _changeTracker.CapitalShare.OriginalAmount;
                _parentView.SavingsDeposit = _changeTracker.SavingsDeposit.OriginalAmount;
                _parentView.TimeDeposit = _changeTracker.TimeDeposit.OriginalAmount;

                // special funds
                _parentView.DeathAidFund = _changeTracker.DeathAidFund.OriginalAmount;
                _parentView.TulunganFund = _changeTracker.TulunganFund.OriginalAmount;

                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
            finally
            {
                _parentView.IsLoadingDetails = false;
            }
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
            //using (var transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
            //{
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
                //Transaction.Current.Rollback();
                Clear(); // just to prevent unwanted modification fragments
                _parentView.LoadReceipt();
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
            //}
        }

        #endregion
    }
}
