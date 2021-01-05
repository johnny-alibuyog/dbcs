using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Transactions;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Loans;
using CooperativeSystem.Service.Presenters.Lookups.AccountStatuses;
using CooperativeSystem.Service.Presenters.Lookups.MembershipCategories;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan;
using CooperativeSystem.Service.Presenters.Plans.PensionPlan;
using CooperativeSystem.Service.Presenters.Savings.CapitalShare;
using CooperativeSystem.Service.Presenters.Savings.SavingsDeposit;
using CooperativeSystem.Service.Presenters.Savings.TimeDeposit;
using CooperativeSystem.Service.Presenters.SpecialFunds.DeathAidFund;
using CooperativeSystem.Service.Presenters.SpecialFunds.TulunganFund;
using CooperativeSystem.Service.Utilities;
using CooperativeSystem.Service.Utilities.Logs;
using CooperativeSystem.Service.Utilities.SequenceGenerators;

namespace CooperativeSystem.Service.Presenters
{
    public class CashDisbursementPresenter : PresenterTemplate
    {
        #region Fields

        // persistence
        private DataContext _db;
        private IRepository<Member> _repository;

        // voucher generator
        private CashDisbursementVoucherGenerator _voucherGenerator;

        // views
        private ICashDisbursementView _parentView;

        // loans
        private ILoanAssessmentView _childLoanView;

        // plans
        private ICIPWithdrawalAssessmentView _childCIPView;
        private IPensionPlanWithdrawalAssessmentView _childPensionPlanView;

        // savings
        private ICapitalShareWithdrawalAssessmentView _childCapitalShareView;
        private ITimeDepositWithdrawalAssessmentView _childTimeDepositView;
        private ISavingsDepositWithdrawalAssessmentView _childSavingsDepositView;

        // special funds
        private ITulunganFundWithdrawalAssessmentView _childTulunganFundView;
        private IDeathAidFundWithdrawalAssessmentView _childDeathAidFundView;

        // object graphs
        private Member _member;
        private CashDisbursement _cashDisbursement;
        private CashReceipt _cashReceipt;

        // lookup
        private IEnumerable<Models.Service> _services;
        private IEnumerable<Models.PaymentMode> _paymentModes;
        private IEnumerable<Models.LoanDeductionType> _loanDeductionTypes;

        #endregion

        #region Constructor

        public CashDisbursementPresenter(
            ICashDisbursementView parentView, 
            ILoanAssessmentView childLoanView,
            ICIPWithdrawalAssessmentView childCIPView, 
            IPensionPlanWithdrawalAssessmentView childPensionPlanView,
            ITimeDepositWithdrawalAssessmentView childTimeDepositView, 
            ICapitalShareWithdrawalAssessmentView childCapitalShareView, 
            ISavingsDepositWithdrawalAssessmentView childSavingsDepositView,
            ITulunganFundWithdrawalAssessmentView childTulunganFundView,
            IDeathAidFundWithdrawalAssessmentView childDeathAidFundView)
        {
            // views
            _parentView = parentView;
            _childLoanView = childLoanView;
            _childCIPView = childCIPView;
            _childPensionPlanView = childPensionPlanView;
            _childTimeDepositView = childTimeDepositView;
            _childCapitalShareView = childCapitalShareView;
            _childSavingsDepositView = childSavingsDepositView;
            _childTulunganFundView = childTulunganFundView;
            _childDeathAidFundView = childDeathAidFundView;

            // events
            WireChildViewEvents();
        }

        #endregion 

        #region Routine Helpers

        private void InitializePersistenceManager()
        {
            _db = new DataContextFactory().CreateDataContext();
            _repository = new GenericRepository<Member>(_db);
            _voucherGenerator = new CashDisbursementVoucherGenerator(_db);
        }

        private void WireChildViewEvents()
        {
            _childLoanView.AssessmentAdd += new EventHandler(ChildLoanView_AssessmentAdd);
            _childCIPView.ReceiptAdd += new EventHandler(ChildCIPView_AssessmentAdd);
            _childPensionPlanView.AssessmentAdd += new EventHandler(ChildPensionPlanView_AssessmentAdd);
            _childTimeDepositView.AssessmentAdd += new EventHandler(ChildTimeDepositView_AssessmentAdd);
            _childCapitalShareView.AssessmentAdd += new EventHandler(ChildCapitalShareView_AssessmentAdd);
            _childSavingsDepositView.AssessmentAdd += new EventHandler(ChildSavingsDepositView_AssessmentAdd);
            _childTulunganFundView.AssessmentAdd += new EventHandler(ChildTulunganFundView_AssessmentAdd);
            _childDeathAidFundView.AssessmentAdd += new EventHandler(ChildDeathAidFundView_AssessmentAdd);
        }

        private void ReflectToParent(string serviceID, decimal amount)
        {
            // reflect to parent
            switch (serviceID)
            {
                // loans
                case ServiceCodes.ApplianceLoan:
                    _parentView.ApplianceLoan = amount;
                    break;
                case ServiceCodes.EasyLoan:
                    _parentView.EasyLoan = amount;
                    break;
                case ServiceCodes.EmergencyLoan:
                    _parentView.EmergencyLoan = amount;
                    break;
                case ServiceCodes.EquityLoan:
                    _parentView.EquityLoan = amount;
                    break;
                case ServiceCodes.PensionLoan:
                    _parentView.PensionLoan = amount;
                    break;
                case ServiceCodes.RegularLoan:
                    _parentView.RegularLoan = amount;
                    break;
                case ServiceCodes.DTILoan:          // TODO: remove this code soon
                    _parentView.DTILoan = amount;
                    break;
                case ServiceCodes.MEDPLoan:         // TODO: remove this code soon
                    _parentView.MEDPLoan = amount;
                    break;

                // plans
                case ServiceCodes.CollegeInsurancePlan:
                    _parentView.CollegeInsurancePlan = amount;
                    break;
                case ServiceCodes.PensionPlan:
                    _parentView.PensionPlan = amount;
                    break;

                // savings
                case ServiceCodes.CapitalShare:
                    _parentView.CapitalShare = amount;
                    break;
                case ServiceCodes.SavingsDeposit:
                    _parentView.SavingsDeposit = amount;
                    break;
                case ServiceCodes.TimeDeposit:
                    _parentView.TimeDeposit = amount;
                    break;

                // special funds
                case ServiceCodes.DeathAidFund:
                    _parentView.DeathAidFund = amount;
                    break;
                case ServiceCodes.TulunganFund:
                    _parentView.TulunganFund = amount;
                    break;
            }

            if (!_parentView.IsThereServiceAssessed)
                _parentView.IsThereServiceAssessed = true;
        }

        private void InitializeParentDisplayFields()
        {
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
        }

        //private bool IsThereAnyOtherLoansThan(string loanServiceID)
        //{
        //    var loanDisbursements = new Dictionary<string, decimal>();
        //    loanDisbursements.Add(ServiceCodes.ApplianceLoan, _parentView.ApplianceLoan);
        //    loanDisbursements.Add(ServiceCodes.EasyLoan, _parentView.EasyLoan);
        //    loanDisbursements.Add(ServiceCodes.EmergencyLoan, _parentView.EmergencyLoan);
        //    loanDisbursements.Add(ServiceCodes.EquityLoan, _parentView.EquityLoan);
        //    loanDisbursements.Add(ServiceCodes.PensionLoan, _parentView.PensionLoan);
        //    loanDisbursements.Add(ServiceCodes.RegularLoan, _parentView.RegularLoan);
        //    loanDisbursements.Add(ServiceCodes.DTILoan, _parentView.DTILoan);
        //    loanDisbursements.Add(ServiceCodes.MEDPLoan, _parentView.MEDPLoan);

        //    var result = loanDisbursements
        //        .Where(x =>
        //            x.Key != loanServiceID &&
        //            x.Value != 0M)
        //        .Any();

        //    return result;
        //}

        #endregion

        #region Object Graph state modifier methods

        private bool InitializeObjectGraph()
        {
            _parentView.IsThereServiceAssessed = false;
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

            // initialize lookup
            _services = _db.GetTable<Models.Service>();
            _paymentModes = _db.GetTable<Models.PaymentMode>();
            _loanDeductionTypes = _db.GetTable<Models.LoanDeductionType>();

            _cashDisbursement = new CashDisbursement();
            _cashDisbursement.DisbursementDate = _parentView.DisbursementDate;
            _cashDisbursement.UserID = _parentView.UserID;
            _cashDisbursement.Member = _member;

            return true;
        }

        private void ChildLoanView_AssessmentAdd(object sender, EventArgs e)
        {
            // look for previous loan assessment in the object graph
            var loan = _member.Loans
                .FirstOrDefault(l =>
                    l.LoanServiceID == _childLoanView.LoanServiceID &&
                    l.LoanID == 0M);

            // create new if none
            if (loan == null)
            {
                loan = new Loan();
                _member.Loans.Add(loan);
            }

            // assign values
            loan.MemberID = _childLoanView.MemberID;
            loan.Service = _services.Single(x => x.ServiceID ==  _childLoanView.LoanServiceID);
            loan.PaymentMode = _paymentModes.Single(x => x.PaymentModeID == _childLoanView.PaymentModeID);
            loan.LoanDeductionType = _loanDeductionTypes.Single(x => x.LoanDeductionTypeID == _childLoanView.LoanDeductionTypeID);
            //loan.LoanServiceID = _childLoanView.LoanServiceID;
            //loan.PaymentModeID = _childLoanView.PaymentModeID;
            //loan.LoanDeductionTypeID = _childLoanView.LoanDeductionTypeID;
            loan.LoanDate = _childLoanView.LoanDate;
            loan.Terms = _childLoanView.Terms;
            loan.InterestRate = _childLoanView.InterestRate;
            loan.DueDate = _childLoanView.DueDate;
            loan.NextPaymentDate = _childLoanView.PaymentStartDate;
            
            loan.LoanAmount = _childLoanView.LoanAmount;
            loan.PreviousOutstandingBalance = _childLoanView.OutstandingBalance; 
            loan.ServiceFee = _childLoanView.ServiceFee;
            loan.CollectionFee = _childLoanView.CollectionFee;
            loan.CapitalBuildup = _childLoanView.CapitalBuildup;
            loan.LoanGuaranteeFund = _childLoanView.LoanGuaranteeFund;
            loan.Interest = _childLoanView.Interest;
            loan.Amortization = _childLoanView.Amortization;

            // settle outstanding loan
            if (_childLoanView.OutstandingLoanId != null)
            {
                var outstandingLoan = _member.Loans
                    .FirstOrDefault(x => x.LoanID == _childLoanView.OutstandingLoanId.Value);

                // create a receipt just to zero out balance
                if (outstandingLoan != null)
                {
                    if (_cashReceipt == null)
                    {
                        _cashReceipt = new CashReceipt();
                        _cashReceipt.ReceiptDate = _parentView.DisbursementDate;
                        _cashReceipt.UserID = _parentView.UserID;
                        _cashReceipt.Member = _member;
                    }

                    var outstandingBalance = _childLoanView.OutstandingBalance;
                    var receipExists = (outstandingLoan.LoanReceipts.Any(x => x.CashReceipt == _cashReceipt));
                    if (receipExists)
                        outstandingLoan.UpdateLoanReceipt(outstandingBalance, _cashReceipt);
                    else
                        outstandingLoan.AddLoanReceipt(new LoanReceipt() { Amount = outstandingBalance, CashReceipt = _cashReceipt });

                    // safe guard. settle regardless
                    outstandingLoan.Settled = true;
                    outstandingLoan.SettlementDate = DateTime.Now;
                }
            }
            else
            {
                _cashReceipt = null;
            }

            var amount = _childLoanView.LoanAmount;
            var exists = (loan.LoanDisbursements.Any(x => x.CashDisbursement == _cashDisbursement));
            if (exists)
                loan.UpdateLoanDisbursement(amount, _cashDisbursement);
            else
                loan.AddLoanDisbursement(new LoanDisbursement() { Amount = amount, CashDisbursement = _cashDisbursement });

            var capitalShare = _member.CapitalShare;
            amount = _childLoanView.CapitalBuildup;
            exists = (capitalShare.CapitalShareBuildups.Any(x => x.CashDisbursement == _cashDisbursement));
            if (exists)
            {
                capitalShare.UpdateCapitalShareBuildup(amount, _cashDisbursement);
            }
            else
            {
                if (amount > 0M)
                    capitalShare.AddCapitalShareBuildup(new CapitalShareBuildup() { Amount = amount, CashDisbursement = _cashDisbursement });
            }

            ReflectToParent(_childLoanView.LoanServiceID, _childLoanView.LoanAmount);
        }

        private void ChildCIPView_AssessmentAdd(object sender, EventArgs e)
        {
            var unconsumedCIPs = _member.CollegeInsurancePlans
                .Where(x => 
                    x.Consumed == false || 
                    x.CollegeInsurancePlanDisbursements.Any(o => o.CashDisbursement == _cashDisbursement)
                );

            // this is bad, this should not happen. inform user and exit function
            if (!unconsumedCIPs.Any()) 
                throw new Exception("Unexpected error occured. " +
                    "The system cannot find any of your college insurance plan that pass maturity. Please verify.");

            // this is bad, this should not happen. should validate at _childCIPView 
            // before triggering AssessmentAdd event handler 
            if (_childCIPView.CIPAssessmentsToWithdraw == null || _childCIPView.CIPAssessmentsToWithdraw.Count < 1)
                throw new Exception("There is not item to selected. If you intend to withdraw your " + 
                    "plan, please select item from the list.");

            // clear any recent assessment
            foreach (var cip in unconsumedCIPs)
            {
                cip.Consumed = false;
                cip.ConsummationDate = null;
                cip.CollegeInsurancePlanDisbursements = null;
            }

            // add the new assessment/s
            foreach (var cipToWithdraw in _childCIPView.CIPAssessmentsToWithdraw)
            {
                var target = unconsumedCIPs.Single(cip => cip.CollegeInsurancePlanID == cipToWithdraw.CollegeInsurancePlanID);
                var amount = cipToWithdraw.WithdrawAmount;
                target.AddCollegeInsurancePlanDisbursement(new CollegeInsurancePlanDisbursement() { Amount = amount, CashDisbursement = _cashDisbursement });
            }

            ReflectToParent(ServiceCodes.CollegeInsurancePlan, _childCIPView.TotalWithdrawAmount);
        }

        private void ChildPensionPlanView_AssessmentAdd(object sender, EventArgs e)
        {
            //// validate business rules
            //if (_childPensionPlanView.MaturityDate != null && 
            //    DateTime.Today < _childPensionPlanView.MaturityDate.Value.TruncateTime())
            //    throw new Exception("Your pension plan haven't reached the maturity date yet.");

            //if (_childPensionPlanView.PayedAmount < _childPensionPlanView.PaymentCompletionAmount)
            //    throw new Exception("You are not fully paid yet. Please pay for the remaining balance.");

            if (_childPensionPlanView.MaximumWithdrawableAmount < _childPensionPlanView.WithdrawAmount)
                throw new Exception(string.Format("You exeeded the maximum withdrawable amount. "+
                    "You only have {0} remaining balance in you account.", _childPensionPlanView.MaximumWithdrawableAmount));

            var disbursement = _member.PensionPlan.PensionPlanDisbursements
                .FirstOrDefault(ppd => ppd.CashDisbursement == _cashDisbursement);

            var amount = _childPensionPlanView.WithdrawAmount;
            var exists = (_member.PensionPlan.PensionPlanDisbursements.Any(x => x.CashDisbursement == _cashDisbursement));
            if (exists)
                _member.PensionPlan.UpdatePensionPlanDisbursement(amount, _cashDisbursement);
            else
                _member.PensionPlan.AddPensionPlanDisbursement(new PensionPlanDisbursement() { Amount = amount, CashDisbursement = _cashDisbursement });

            ReflectToParent(ServiceCodes.PensionPlan, _childPensionPlanView.WithdrawAmount);
        }

        private void ChildTimeDepositView_AssessmentAdd(object sender, EventArgs e)
        {
            var unconsumedTimeDeposits = _member.TimeDeposits
                .Where(td => 
                    td.Consumed == false ||
                    td.TimeDepositDisbursements.Any(
                        tdd => tdd.CashDisbursement == _cashDisbursement
                    )
                );

            // this is bad, this should not happen. inform user and exit function
            if (!unconsumedTimeDeposits.Any())
                throw new Exception("Unexpected error occured. " +
                    "The system cannot find any of your time deposits that pass maturity. Please verify.");

            // this is bad, this should not happen. should validate at _childTimeDepositView 
            // before triggering AssessmentAdd event handler 
            if (_childTimeDepositView.TimeDepositsToWithdraw == null || _childTimeDepositView.TimeDepositsToWithdraw.Count < 1)
                throw new Exception("There is not item to selected. If you intend to withdraw your " +
                    "deposit, please select item from the list.");

            // clear any recent assessment
            foreach (var timeDeposit in unconsumedTimeDeposits)
            {
                timeDeposit.Consumed = false;
                timeDeposit.ConsummationDate = null;
                timeDeposit.Interest = null;
                timeDeposit.TimeDepositDisbursements = null;
            }

            // add the new assessment/s
            foreach (var timeDepositToWithdraw in _childTimeDepositView.TimeDepositsToWithdraw)
            {
                var target = unconsumedTimeDeposits.Single(td => td.TimeDepositID == timeDepositToWithdraw.TimeDepositID);
                target.Interest = timeDepositToWithdraw.Interest;

                target.AddTimeDepositDisbursement(
                    new TimeDepositDisbursement() 
                    {
                        Amount = timeDepositToWithdraw.WithdrawAmount, 
                        CashDisbursement = _cashDisbursement 
                    }
                );
            }

            ReflectToParent(ServiceCodes.TimeDeposit, _childTimeDepositView.TotalWithdrawAmount);
        }

        private void ChildCapitalShareView_AssessmentAdd(object sender, EventArgs e)
        {
            // validate business rules
            if (_childCapitalShareView.CurrentBalance < _childCapitalShareView.WithdrawAmount)
                throw new Exception(string.Format("You exeeded the maximum withdrawable amount. " +
                    "You only have {0} remaining balance in you account.", _childCapitalShareView.CurrentBalance.ToString()));

            var amount = _childCapitalShareView.WithdrawAmount;
            var exists = (_member.CapitalShare.CapitalShareDisbursements.Any(x => x.CashDisbursement == _cashDisbursement));
            if (exists)
                _member.CapitalShare.UpdateCapitalShareDisbursement(amount, _cashDisbursement);
            else
                _member.CapitalShare.AddCapitalShareDisbursement(new CapitalShareDisbursement() { Amount = amount, CashDisbursement = _cashDisbursement });

            ReflectToParent(ServiceCodes.CapitalShare, _childCapitalShareView.WithdrawAmount);
        }

        private void ChildSavingsDepositView_AssessmentAdd(object sender, EventArgs e)
        {
            // validate business rules
            if (_childSavingsDepositView.CurrentBalance < _childSavingsDepositView.WithdrawAmount)
                throw new Exception(string.Format("You exeeded the maximum withdrawable amount. " +
                    "You only have {0} remaining balance in you account.", _childSavingsDepositView.CurrentBalance.ToString()));

            var amount = _childSavingsDepositView.WithdrawAmount;
            var exists = (_member.SavingsDeposit.SavingsDepositDisbursements.Any(x => x.CashDisbursement == _cashDisbursement));
            if (exists)
                _member.SavingsDeposit.UpdateSavingsDepositDisbursement(amount, _cashDisbursement);
            else
                _member.SavingsDeposit.AddSavingsDepositDisbursement(new SavingsDepositDisbursement() { Amount = amount, CashDisbursement = _cashDisbursement });

            ReflectToParent(ServiceCodes.SavingsDeposit, _childSavingsDepositView.WithdrawAmount);
        }

        private void ChildTulunganFundView_AssessmentAdd(object sender, EventArgs e)
        {
            if (_member.TulunganFund == null)
            {
                _member.TulunganFund = new TulunganFund();
                _member.TulunganFund.CurrentBalance = 0M;
            }

            var amount = _childTulunganFundView.Amount;
            var exists = (_member.TulunganFund.TulunganFundDisbursements.Any(x => x.CashDisbursement == _cashDisbursement));
            if (exists)
                _member.TulunganFund.UpdateTulunganFundDisbursement(amount, _cashDisbursement);
            else
                _member.TulunganFund.AddTulunganFundDisbursement(new TulunganFundDisbursement() { Amount = amount, CashDisbursement = _cashDisbursement });

            ReflectToParent(ServiceCodes.TulunganFund, _childTulunganFundView.Amount);
        }

        private void ChildDeathAidFundView_AssessmentAdd(object sender, EventArgs e)
        {
            if (_member.DeathAidFund == null)
            {
                _member.DeathAidFund = new DeathAidFund();
                _member.DeathAidFund.CurrentBalance = 0M;
            }

            //var amount = _db.GetTable<DeathAidFundSetting>().Single().PerMemberAid;
            //var members = _db.GetTable<Member>()
            //    .Where(Member.TheMembersEntitledForDeathAidFund());

            var amount = _db.GetTable<DeathAidFundType>()
                .Single(x => x.Id == _childDeathAidFundView.DeathAidFundTypeId)
                .PerMemberAid;

            var members = _db.GetTable<Member>()
                .Where(x =>
                    x.DeathAidFund != null &&
                    x.AccountStatusID != AccountStatusCodes.Closed &&
                    x.AvailedServices.Any(o => o.ServiceID == ServiceCodes.DeathAidFund) &&
                    x.DeathAidFund.CurrentBalance >= amount
                );

            // distribute disbursement
            foreach (var member in members)
            {
                var exists = (member.DeathAidFund.DeathAidFundDisbursements.Any(x => x.CashDisbursement == _cashDisbursement));
                if (exists)
                    member.DeathAidFund.UpdateDeathAidFundDisbursement(amount, _cashDisbursement);
                else
                    member.DeathAidFund.AddDeathAidFundDisbursement(new DeathAidFundDisbursement() { Amount = amount, CashDisbursement = _cashDisbursement });
            }

            ReflectToParent(ServiceCodes.DeathAidFund, _childDeathAidFundView.WithdrawAmount);
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
            //using (var transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
            //{
                try
                {
                    _cashDisbursement.DisbursementDate = _parentView.DisbursementDate;
                    _cashDisbursement.CashDisbursementVoucher = _parentView.VoucherNumber;

                    // this is used to zero out outstanding loan if there is any
                    if (_cashReceipt != null)
                        _cashReceipt.OfficialReceiptNumber = _parentView.VoucherNumber;

                    _repository.SaveAll();
                    RaiseSusccessEvent("Successful.");
                    return true;
                }
                catch (Exception ex)
                {
                    //Transaction.Current.Rollback();
                    Clear(); // just to prevent unwanted modification fragments
                    RaiseErrorEvent(ex.Message, ex);
                    return false;
                }
            //}
        }

        #endregion
    }
}
