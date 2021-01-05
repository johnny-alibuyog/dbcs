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
        // TODO: remove this code soon
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
        // TODO: remove this code soon

        // plans
        public AdjustmentChangeVersion<IList<CollegeInsurancePlanReceipt>> CollegeInsurancePlan
        {
            get
            {
                var receipts = _cashReceipt.CollegeInsurancePlanReceipts;
                var originalAmount = receipts != null ? receipts.Sum(r => r.Amount) : DEFAULT_VALUE;
                var newAmount = _view.CollegeInsurancePlan;
                return new AdjustmentChangeVersion<IList<CollegeInsurancePlanReceipt>>(receipts, originalAmount, newAmount, ServiceCodes.CollegeInsurancePlan);
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


        public AdjustmentChangeTracker(IAdjustmentView view, CashReceipt cashReceipt)
        {
            _view = view;
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
            _parentView.VoucherNumber = _voucherGenerator.GenerateVoucher();
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
                OnError("You did not perform customer search. Please select customer from custumer inquiry.");
                return false;
            }

            _member = _repository.GetEntity(m => m.MemberID == _parentView.MemberID);
            if (_member == null)
            {
                OnError(string.Format("Member doesn't exist. Please select a valid member."));
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
            //_parentView.CollegeInsurancePlan = _changeTracker.CollegeInsurancePlan.OriginalValue;

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
            var changeVersions = _childCIPView.CIPAdjustments
                .Where(a => a.HasChanged);

            var recepits = _changeTracker.CollegeInsurancePlan.Receipt;
            foreach (var changeVersion in changeVersions)
            {
                var receipt = recepits.FirstOrDefault(r => r.CollegeInsurancePlanID == changeVersion.CollegeInsurancePlanID);
                if (receipt == null)
                {
                    receipt = new CollegeInsurancePlanReceipt();
                    receipt.CashReceipt = _cashReceipt;
                    receipt.CollegeInsurancePlan = _member.CollegeInsurancePlans
                        .First(cip => cip.CollegeInsurancePlanID == changeVersion.CollegeInsurancePlanID); 
                }

                // assign new value
                receipt.Amount = changeVersion.NewAmount;
                var plan = receipt.CollegeInsurancePlan;
                var isPaymentCompleted = (plan.CollegeInsurancePlanReceipts.Sum(r => r.Amount) >= plan.PaymentCompletionAmount);
                if (isPaymentCompleted)
                {
                    plan.PaymentCompletionDate = _cashReceipt.ReceiptDate;
                    plan.MaturityDate = _cashReceipt.ReceiptDate.AddYears(plan.AgingPeriod);
                }
                else
                {
                    plan.PaymentCompletionDate = null;
                    plan.MaturityDate = null;
                }

                // log adjustment
                var cipAdjusetment = new CollegeInsurancePlanAdjustment();
                cipAdjusetment.CollegeInsurancePlanID = receipt.CollegeInsurancePlanID;
                cipAdjusetment.OriginalAmount = changeVersion.OriginalAmount;
                cipAdjusetment.NewAmount = changeVersion.NewAmount;
                
                _adjustment.CollegeInsurancePlanAdjustments.Add(cipAdjusetment);
            }

            ReflectToParent(ServiceCodes.CollegeInsurancePlan, _childCIPView.TotalAmount);
        }


        private void MakeTulunganFundAdjustment(AdjustmentChangeVersion<TulunganFundReceipt> changeVersion)
        {
            var receipt = changeVersion.Receipt;
            if (receipt == null)
            {
                if (_member.TulunganFund == null)
                {
                    _member.TulunganFund = new TulunganFund();
                    _member.TulunganFund.CurrentBalance = 0M;
                }

                // link relations
                receipt = new TulunganFundReceipt();
                receipt.CashReceipt = _cashReceipt;
                receipt.TulunganFund = _member.TulunganFund;
            }

            // assign new value
            receipt.Amount = changeVersion.NewAmount;
            _member.TulunganFund.CurrentBalance -= changeVersion.ChangedAmount;

            var tulunganFundAdjustment = new TulunganFundAdjustment();
            tulunganFundAdjustment.MemberID = receipt.MemberID;
            tulunganFundAdjustment.OriginalAmount = changeVersion.OriginalAmount;
            tulunganFundAdjustment.NewAmount = changeVersion.NewAmount;

            _adjustment.TulunganFundAdjustments.Add(tulunganFundAdjustment);
        }

        private void MakeDeathAidFundAdjustment(AdjustmentChangeVersion<DeathAidFundReceipt> changeVersion)
        {
            var receipt = changeVersion.Receipt;
            if (receipt == null)
            {
                if (_member.DeathAidFund == null)
                {
                    _member.DeathAidFund = new DeathAidFund();
                    _member.DeathAidFund.CurrentBalance = 0;
                }

                // link relations
                receipt = new DeathAidFundReceipt();
                receipt.CashReceipt = _cashReceipt;
                receipt.DeathAidFund = _member.DeathAidFund;
            }

            // assign the new amount
            receipt.Amount = changeVersion.NewAmount;
            _member.DeathAidFund.CurrentBalance -= changeVersion.ChangedAmount;

            // log adjustment
            var deathAidFundAdjustment = new DeathAidFundAdjustment();
            deathAidFundAdjustment.MemberID = receipt.MemberID;
            deathAidFundAdjustment.OriginalAmount = changeVersion.OriginalAmount;
            deathAidFundAdjustment.NewAmount = changeVersion.NewAmount;

            _adjustment.DeathAidFundAdjustments.Add(deathAidFundAdjustment);
        }

        private void MakeTimeDepositAdjustment(AdjustmentChangeVersion<TimeDepositReceipt> changeVersion)
        {
            var receipt = changeVersion.Receipt;
            if (receipt == null)
                throw new Exception("You do not have plan deposit for this receipt. Adjustment is not allowed.");

            var minimumAmount = _db.GetTable<TimeDepositMinimumAmount>().FirstOrDefault().Amount;
            if (changeVersion.NewAmount < minimumAmount)
                throw new Exception("Adjustment is under minimum amount. Adjustment is not allowd.");

            // compute for interest rate
            var interestRateCalculator = new InterestRateCalculator(_db.GetTable<TimeDepositInterestRate>().FirstOrDefault());
            var interestRate = interestRateCalculator.ComputeInterest(changeVersion.NewAmount);

            // assign the new amount
            receipt.Amount = changeVersion.NewAmount;

            var timeDepositAdjustment = new TimeDepositAdjustment();
            timeDepositAdjustment.TimeDepositID = receipt.TimeDepositID;
            timeDepositAdjustment.OriginalAmount = changeVersion.OriginalAmount;
            timeDepositAdjustment.NewAmount = changeVersion.NewAmount;

            _adjustment.TimeDepositAdjustments.Add(timeDepositAdjustment);
        }

        private void MakeSavingsDepositAdjustment(AdjustmentChangeVersion<SavingsDepositReceipt> changeVersion)
        {
            _member.SavingsDeposit.AddSavingsDepositAdjustment(new SavingsDepositAdjustment()
                {
                    Adjustment = _adjustment,
                    OriginalAmount = changeVersion.OriginalAmount,
                    NewAmount = changeVersion.NewAmount
                });

            //var savingsDeposit = _member.SavingsDeposit;
            //if (savingsDeposit == null)
            //{
            //    savingsDeposit = new SavingsDeposit();
            //    _member.SavingsDeposit = savingsDeposit;
            //}

            //// check if there is previous adjustment for this particular transaction
            //var savingsDepositAdjustment = savingsDeposit.SavingsDepositAdjustments
            //    .Where(a => a.Adjustment == _adjustment)
            //    .FirstOrDefault();

            //// create if there isn't any
            //if (savingsDepositAdjustment == null)
            //{
            //    savingsDepositAdjustment = new SavingsDepositAdjustment();
            //    savingsDepositAdjustment.Adjustment = _adjustment;
            //}

            //// set adjustment values
            //savingsDepositAdjustment.OriginalAmount = changeVersion.OriginalAmount;
            //savingsDepositAdjustment.NewAmount = changeVersion.NewAmount;

            //// attach adjustment
            //savingsDeposit.AddSavingsDepositAdjustment(savingsDepositAdjustment);

            //var receipt = changeVersion.Receipt;
            //if (receipt == null)
            //{
            //    var previousBalance = 0M;
            //    if (_member.SavingsDeposit == null)
            //    {
            //        _member.SavingsDeposit = new SavingsDeposit();
            //        _member.SavingsDeposit.CurrentBalance = 0M;
            //        previousBalance = _member.SavingsDeposit.CurrentBalance;
            //    }
            //    else
            //    {
            //        // look for the last
            //        var previousReceipt = _member.SavingsDeposit.SavingsDepositReceipts
            //            .Where(sdr =>
            //                sdr.CashReceipt.ReceiptDate <= _cashReceipt.ReceiptDate &&
            //                sdr.CashReceipt != _cashReceipt)
            //            .OrderByDescending(sdr => sdr.CashReceipt.ReceiptDate)
            //            .FirstOrDefault();

            //        previousBalance = (previousReceipt != null) ? previousReceipt.Balance : 0M;
            //    }

            //    // link relations
            //    receipt = new SavingsDepositReceipt();
            //    receipt.CashReceipt = _cashReceipt;
            //    receipt.SavingsDeposit = _member.SavingsDeposit;
            //    receipt.Balance = previousBalance;
            //}

            //// assign the new amount and adjust balance
            //receipt.Amount = changeVersion.NewAmount;
            //receipt.Balance -= changeVersion.ChangedAmount;

            //// adjust the balances of the recent transactions after the receipt date
            //var receiptDate = receipt.CashReceipt.ReceiptDate;
            //var savingsDeposit = _member.SavingsDeposit;
            //savingsDeposit.CurrentBalance -= changeVersion.ChangedAmount;

            //var recentReceipts = savingsDeposit.SavingsDepositReceipts
            //    .Where(sdr => 
            //        sdr.CashReceipt.ReceiptDate >= receiptDate &&
            //        sdr.CashReceipt != receipt.CashReceipt);

            //var recentDisbursements = savingsDeposit.SavingsDepositDisbursements
            //    .Where(sdd => sdd.CashDisbursement.DisbursementDate >= receiptDate);

            //var recentInterestDisbursements = savingsDeposit.SavingsDepositInterestAdjustments
            //    .Where(sdia => sdia.Adjustment.AdjustmentDate >= receiptDate);

            //foreach (var item in recentReceipts)
            //    item.Balance -= changeVersion.ChangedAmount;

            //foreach (var item in recentDisbursements)
            //    item.Balance -= changeVersion.ChangedAmount;

            //foreach (var item in recentInterestDisbursements)
            //    item.Balance -= changeVersion.ChangedAmount;

            //// log adjustment
            //var savingsDepositAdjustment = new SavingsDepositAdjustment();
            //savingsDepositAdjustment.MemberID = receipt.MemberID;
            //savingsDepositAdjustment.OriginalAmount = changeVersion.OriginalAmount;
            //savingsDepositAdjustment.NewAmount = changeVersion.NewAmount;

            //_adjustment.SavingsDepositAdjustments.Add(savingsDepositAdjustment);
        }

        private void MakeCapitalShareAdjustment(AdjustmentChangeVersion<CapitalShareReceipt> changeVersion)
        {
            var receipt = changeVersion.Receipt;
            if (receipt == null)
            {
                var previousBalance = 0M;
                if (_member.CapitalShare == null)
                {
                    _member.CapitalShare = new CapitalShare();
                    _member.CapitalShare.CurrentBalance = 0M;
                    previousBalance = _member.CapitalShare.CurrentBalance;
                }
                else
                {
                    // look for the last
                    var previousReceipt = _member.CapitalShare.CapitalShareReceipts
                        .Where(csr =>
                            csr.CashReceipt.ReceiptDate <= _cashReceipt.ReceiptDate &&
                            csr.CashReceipt != _cashReceipt)
                        .OrderByDescending(csr => csr.CashReceipt.ReceiptDate)
                        .FirstOrDefault();

                    previousBalance = (previousReceipt != null) ? previousReceipt.Balance : 0M;
                }

                // link relations
                receipt = new CapitalShareReceipt();
                receipt.CashReceipt = _cashReceipt;
                receipt.CapitalShare = _member.CapitalShare;
                receipt.Balance = previousBalance;
            }

            // assign the new amount and adjust balance
            receipt.Amount = changeVersion.NewAmount;
            receipt.Balance -= changeVersion.ChangedAmount;

            // adjust the balances of the recent transactions after the receipt date
            var receiptDate = receipt.CashReceipt.ReceiptDate;
            var capitalShare = _member.CapitalShare;
            capitalShare.CurrentBalance -= changeVersion.ChangedAmount;

            var recentReceipts = capitalShare.CapitalShareReceipts
                .Where(csr => 
                    csr.CashReceipt.ReceiptDate >= receiptDate &&
                    csr.CashReceipt != receipt.CashReceipt);

            var recentDisbusements = capitalShare.CapitalShareDisbursements
                .Where(csd => csd.CashDisbursement.DisbursementDate >= receiptDate);

            var recentDividendDisbursements = capitalShare.DividendAdjustments
                .Where(cda => cda.Adjustment.AdjustmentDate >= receiptDate);

            var recentPatronageRefundDisbusemets = capitalShare.PatronageRefundAdjustments
                .Where(pra => pra.Adjustment.AdjustmentDate >= receiptDate);

            foreach (var item in recentReceipts)
                item.Balance -= changeVersion.ChangedAmount;

            foreach (var item in recentDisbusements)
                item.Balance -= changeVersion.ChangedAmount;

            foreach (var item in recentDividendDisbursements)
                item.Balance -= changeVersion.ChangedAmount;

            foreach (var item in recentPatronageRefundDisbusemets)
                item.Balance -= changeVersion.ChangedAmount;

            // log adjustment
            var capitalShareAdjustment = new CapitalShareAdjustment();
            capitalShareAdjustment.MemberID = receipt.MemberID;
            capitalShareAdjustment.OriginalAmount = changeVersion.OriginalAmount;
            capitalShareAdjustment.NewAmount = changeVersion.NewAmount;

            _adjustment.CapitalShareAdjustments.Add(capitalShareAdjustment);
        }

        private void MakePensionPlanAdjustment(AdjustmentChangeVersion<PensionPlanReceipt> changeVersion)
        {
            var receipt = changeVersion.Receipt;
            if (receipt == null)
            {
                // check if pension plan is enrolled, do not allow adjustment if not enrolled
                var enrolled = _member.PensionPlan != null;
                if (enrolled)
                    throw new Exception(string.Format("Pension plan for {0} is not yet enrolled. " + 
                        "Adjustment is not allowed.", _member.ToString()));

                // link relations
                receipt = new PensionPlanReceipt();
                receipt.CashReceipt = _cashReceipt;
                receipt.PensionPlan = _member.PensionPlan;
            }

            // assing the new amount
            receipt.Amount = changeVersion.NewAmount;

            // business rules
            var pensionPlan = receipt.PensionPlan;
            var isFullyPaid = (pensionPlan.PensionPlanReceipts.Sum(r => r.Amount) >= pensionPlan.PaymentCompletionAmount);
            if (isFullyPaid)
                pensionPlan.PaymentCompletionDate = receipt.CashReceipt.ReceiptDate;

            // log adjustments
            var pensionPlanAdjustment = new PensionPlanAdjustment();
            pensionPlanAdjustment.MemberID = receipt.MemberID;
            pensionPlanAdjustment.OriginalAmount = changeVersion.OriginalAmount;
            pensionPlanAdjustment.NewAmount = changeVersion.NewAmount;

            _adjustment.PensionPlanAdjustments.Add(pensionPlanAdjustment);
        }

        private void MakeLoanAdjustment(AdjustmentChangeVersion<LoanReceipt> changeVersion)
        {
            var receipt = changeVersion.Receipt;
            if (receipt == null)
            {
                // check if there is outstanding loan for the adjustment
                var loan = _member.Loans
                    .FirstOrDefault(l => 
                        l.LoanServiceID == changeVersion.ServiceID && 
                        l.Settled == false);

                // no current loan to be adjusted, do not allow adjustment
                if (loan == null)
                {
                    var service = _db.GetTable<CooperativeSystem.Service.Models.Service>()
                        .First(s => s.ServiceID == changeVersion.ServiceID);

                    throw new Exception(string.Format("{0} doesn't have unsettled {1}. Adjustment is not allowed."
                        , _member.ToString(), service.ToString()));
                }

                // link relations
                receipt = new LoanReceipt();
                receipt.CashReceipt = _cashReceipt;
                receipt.Loan = loan;
            }

            // assing the new amount
            receipt.Amount = changeVersion.NewAmount;

            // check if needs it to set settled
            receipt.Loan.Settled = false; // reset
            receipt.Loan.Settled = (receipt.Loan.OutstandingBalance <= 0M); //(changeVersion.NewAmount >= receipt.Loan.OutstandingBalance);

            // log adjustment
            var loanAdjustment = new LoanAdjustment();
            loanAdjustment.LoanID = receipt.LoanID;
            loanAdjustment.OriginalAmount = changeVersion.OriginalAmount;
            loanAdjustment.NewAmount = changeVersion.NewAmount;

            _adjustment.LoanAdjustments.Add(loanAdjustment);
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
                    OnError("Receipt number does not exist. Please verify.");
                    return false;
                }

                _adjustment.CashReceipt = _cashReceipt;
                _changeTracker = new AdjustmentChangeTracker(_parentView, _cashReceipt);

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
                _parentView.CollegeInsurancePlan = _changeTracker.CollegeInsurancePlan.OriginalAmount;
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
                OnError(ex.Message, ex);
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
            var voucher = _voucherGenerator.GenerateVoucher(_parentView.Sequence, out remarks);
            if (string.IsNullOrEmpty(voucher))
            {
                OnError(remarks);
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
                    OnError(remarks);
                    return false;
                }

                _adjustment.AdjustmentDate = _parentView.AdjustmentDate;
                _adjustment.AdjustmentJournalVoucher = _parentView.VoucherNumber;

                _repository.SaveAll();
                OnSuccess("Successful.");
                return true;
            }
            catch (Exception ex)
            {
                //Transaction.Current.Rollback();
                Clear(); // just to prevent unwanted modification fragments
                OnError(ex.Message, ex);
                return false;
            }
            //}
        }

        #endregion
    }
}
