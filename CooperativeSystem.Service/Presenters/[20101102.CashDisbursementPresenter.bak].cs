using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Transactions;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Loans;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan;
using CooperativeSystem.Service.Presenters.Plans.PensionPlan;
using CooperativeSystem.Service.Presenters.Savings.CapitalShare;
using CooperativeSystem.Service.Presenters.Savings.SavingsDeposit;
using CooperativeSystem.Service.Presenters.Savings.TimeDeposit;
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

        // object graphs
        private Member _member;
        private CashDisbursement _cashDisbursement;

        #endregion

        #region Constructor

        public CashDisbursementPresenter(
            ICashDisbursementView parentView, 
            ILoanAssessmentView childLoanView,
            ICIPWithdrawalAssessmentView childCIPView, 
            IPensionPlanWithdrawalAssessmentView childPensionPlanView,
            ITimeDepositWithdrawalAssessmentView childTimeDepositView, 
            ICapitalShareWithdrawalAssessmentView childCapitalShareView, 
            ISavingsDepositWithdrawalAssessmentView childSavingsDepositView)
        {
            // views
            _parentView = parentView;
            _childLoanView = childLoanView;
            _childCIPView = childCIPView;
            _childPensionPlanView = childPensionPlanView;
            _childTimeDepositView = childTimeDepositView;
            _childCapitalShareView = childCapitalShareView;
            _childSavingsDepositView = childSavingsDepositView;

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
            _parentView.VoucherNumber = _voucherGenerator.GenerateVoucher();
        }

        #endregion

        #region Object Graph state modifier methods

        private bool InitializeObjectGraph()
        {
            _parentView.IsThereServiceAssessed = false;
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

            // look for previous disbursement assessment
            var loanDisbursement = loan.LoanDisbursements
                .FirstOrDefault(ld => ld.CashDisbursement == _cashDisbursement);

            // create new if none
            if (loanDisbursement == null)
            {
                loanDisbursement = new LoanDisbursement();
                loan.LoanDisbursements.Add(loanDisbursement);
            }

            // assign values
            loan.MemberID = _childLoanView.MemberID;
            loan.LoanServiceID = _childLoanView.LoanServiceID;
            loan.PaymentModeID = _childLoanView.PaymentModeID;
            loan.LoanDeductionTypeID = _childLoanView.LoanDeductionTypeID;
            loan.LoanDate = _childLoanView.LoanDate;
            loan.Terms = _childLoanView.Terms;
            loan.InterestRate = _childLoanView.InterestRate;
            loan.DueDate = _childLoanView.DueDate;
            loan.NextPaymentDueDate = _childLoanView.PaymentStartDate;
            
            loan.LoanAmount = _childLoanView.LoanAmount;
            loan.PreviousOutstandingBalance = _childLoanView.OutstandingBalance; 
            loan.ServiceFee = _childLoanView.ServiceFee;
            loan.CollectionFee = _childLoanView.CollectionFee;
            loan.CapitalBuildup = _childLoanView.CapitalBuildup;
            loan.LoanGuaranteeFund = _childLoanView.LoanGuaranteeFund;
            loan.Interest = _childLoanView.Interest;
            loan.Amortization = _childLoanView.Amortization;
            loanDisbursement.CashDisbursement = _cashDisbursement;
            loanDisbursement.Amount = _childLoanView.LoanAmount;

            ReflectToParent(_childLoanView.LoanServiceID, _childLoanView.LoanAmount);
        }

        private void ChildCIPView_AssessmentAdd(object sender, EventArgs e)
        {
            var query = _member.CollegeInsurancePlans
                .Where(cip => 
                    cip.Consumed == false || 
                    cip.CollegeInsurancePlanDisbursements.Where(cipd => cipd.CashDisbursement == _cashDisbursement).Any());

            var unconsumedCIPs = query.Any() ? query.ToList() : null;

            // this is bad, this should not happen. inform user and exit function
            if (unconsumedCIPs == null) 
                throw new Exception("Unexpected error occured. " +
                    "The system cannot find any of your college insurance plan that pass maturity. Please verify.");

            // this is bad, this should not happen. should validate at _childCIPView 
            // before triggering AssessmentAdd event handler 
            if (_childCIPView.CIPsToAvail == null || _childCIPView.CIPsToAvail.Count < 1)
                throw new Exception("There is not item to selected. If you intend to withdraw your " + 
                    "plan, please select item from the list.");

            // clear any recent assessment
            foreach (var cip in unconsumedCIPs)
            {
                cip.Consumed = false;
                cip.CollegeInsurancePlanDisbursements = null;
            }

            // add the new assessment/s
            foreach (var cipToAvail in _childCIPView.CIPsToAvail)
            {
                var target = unconsumedCIPs
                    .FirstOrDefault(cip => cip.CollegeInsurancePlanID == cipToAvail.CollegeInsurancePlanID);

                // this should never happen. throw error if in case it does.
                if (target == null)
                    throw new Exception("Unexpected error occured. Error adding you assessment.");

                var disbursement = new CollegeInsurancePlanDisbursement() 
                { 
                    CashDisbursement = _cashDisbursement,
                    Amount = target.AwardAmount 
                };

                target.CollegeInsurancePlanDisbursements.Add(disbursement);
            }

            ReflectToParent(ServiceCodes.CollegeInsurancePlan, _childCIPView.TotalWithdrawAmount);
        }

        private void ChildPensionPlanView_AssessmentAdd(object sender, EventArgs e)
        {
            // validate business rules
            if (_childPensionPlanView.MaturityDate != null && 
                DateTime.Today < _childPensionPlanView.MaturityDate.Value.TruncateTime())
                throw new Exception("Your pension plan haven't reached the maturity date yet.");

            if (_childPensionPlanView.PayedAmount < _childPensionPlanView.PaymentCompletionAmount)
                throw new Exception("You are not fully paid yet. Please pay for the remaining balance.");

            if (_childPensionPlanView.MaximumWithdrawableAmount < _childPensionPlanView.WithdrawAmount)
                throw new Exception(string.Format("You exeeded the maximum withdrawable amount. "+
                    "You only have {0} remaining balance in you account.", _childPensionPlanView.MaximumWithdrawableAmount));

            var disbursement = _member.PensionPlan.PensionPlanDisbursements
                .FirstOrDefault(ppd => ppd.CashDisbursement == _cashDisbursement);

            if (disbursement == null)
            {
                disbursement = new PensionPlanDisbursement();
                _member.PensionPlan.PensionPlanDisbursements.Add(disbursement);
            }
            disbursement.CashDisbursement = _cashDisbursement;
            disbursement.Amount = _childPensionPlanView.WithdrawAmount;

            // set consumed to true if maximum withdrawable amount is withdrawn
            _member.PensionPlan.Consumed = (_childPensionPlanView.WithdrawAmount >= _childPensionPlanView.MaximumWithdrawableAmount);

            ReflectToParent(ServiceCodes.PensionLoan, _childPensionPlanView.WithdrawAmount);
        }

        private void ChildTimeDepositView_AssessmentAdd(object sender, EventArgs e)
        {
            var unconsumedTimeDepositQuery = _member.TimeDeposits
                .Where(td => 
                    td.Consumed == false ||
                    td.TimeDepositDisbursements.Where(tdd => tdd.CashDisbursement == _cashDisbursement).Any());

            var unconsumedTimeDeposits = unconsumedTimeDepositQuery.Any() 
                ? unconsumedTimeDepositQuery.ToList() 
                : null;

            // this is bad, this should not happen. inform user and exit function
            if (unconsumedTimeDeposits == null)
                throw new Exception("Unexpected error occured. " +
                    "The system cannot find any of your time deposits that pass maturity. Please verify.");

            // this is bad, this should not happen. should validate at _childTimeDepositView 
            // before triggering AssessmentAdd event handler 
            if (_childTimeDepositView.TimeDepositsToAvail == null || _childTimeDepositView.TimeDepositsToAvail.Count < 1)
                throw new Exception("There is not item to selected. If you intend to withdraw your " +
                    "deposit, please select item from the list.");

            // clear any recent assessment
            foreach (var timeDeposit in unconsumedTimeDeposits)
            {
                timeDeposit.Consumed = false;
                timeDeposit.TimeDepositDisbursements = null;
            }

            // add the new assessment/s
            foreach (var timeDepositToAvail in _childTimeDepositView.TimeDepositsToAvail)
            {
                var target = unconsumedTimeDeposits
                    .FirstOrDefault(td => td.TimeDepositID == timeDepositToAvail.TimeDepositID);

                // this should never happen. throw error if in case it does.
                if (target == null)
                    throw new Exception("Unexpected error occured. Error adding you assessment.");

                target.Consumed = true;
                target.Interest = timeDepositToAvail.Interest;

                var disbursement = new TimeDepositDisbursement()
                {
                    CashDisbursement = _cashDisbursement,
                    Amount = timeDepositToAvail.TotalAmount
                };

                target.TimeDepositDisbursements.Add(disbursement);
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


            //var disbursement = _member.CapitalShare.CapitalShareDisbursements
            //    .FirstOrDefault(csd => csd.CashDisbursement == _cashDisbursement);

            //if (disbursement == null)
            //{
            //    disbursement = new CapitalShareDisbursement();
            //    _member.CapitalShare.CapitalShareDisbursements.Add(disbursement);
            //}
            //_member.CapitalShare.CurrentBalance -= _childCapitalShareView.WithdrawAmount;

            //disbursement.CashDisbursement = _cashDisbursement;
            //disbursement.Amount = _childCapitalShareView.WithdrawAmount;
            //disbursement.Balance = _member.CapitalShare.CurrentBalance;

            //ReflectToParent(ServiceCodes.CapitalShare, _childCapitalShareView.WithdrawAmount);
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

            //_member.SavingsDeposit.AddSavingsDepositDisbursement(new SavingsDepositDisbursement()
            //    {
            //        CashDisbursement = _cashDisbursement,
            //        Amount = _childSavingsDepositView.WithdrawAmount
            //    });
            
            //if (disbursement == null)
            //{
            //    disbursement = new SavingsDepositDisbursement();
            //    _member.SavingsDeposit.SavingsDepositDisbursements.Add(disbursement);
            //}
            //_member.SavingsDeposit.CurrentBalance -= _childSavingsDepositView.WithdrawAmount;

            //disbursement.CashDisbursement = _cashDisbursement;
            //disbursement.Amount = _childSavingsDepositView.WithdrawAmount;
            //disbursement.Balance = _member.SavingsDeposit.CurrentBalance;

            ReflectToParent(ServiceCodes.SavingsDeposit, _childSavingsDepositView.WithdrawAmount);



            //// validate business rules
            //if (_childSavingsDepositView.CurrentBalance < _childSavingsDepositView.WithdrawAmount)
            //    throw new Exception(string.Format("You exeeded the maximum withdrawable amount. " +
            //        "You only have {0} remaining balance in you account.", _childSavingsDepositView.CurrentBalance.ToString()));

            //var disbursement = _member.SavingsDeposit.SavingsDepositDisbursements
            //    .FirstOrDefault(csd => csd.CashDisbursement == _cashDisbursement);

            //if (disbursement == null)
            //{
            //    disbursement = new SavingsDepositDisbursement();
            //    _member.SavingsDeposit.SavingsDepositDisbursements.Add(disbursement);
            //}
            //_member.SavingsDeposit.CurrentBalance -= _childSavingsDepositView.WithdrawAmount;

            //disbursement.CashDisbursement = _cashDisbursement;
            //disbursement.Amount = _childSavingsDepositView.WithdrawAmount;
            //disbursement.Balance = _member.SavingsDeposit.CurrentBalance;

            //ReflectToParent(ServiceCodes.SavingsDeposit, _childSavingsDepositView.WithdrawAmount);
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
                    _cashDisbursement.DisbursementDate = _parentView.DisbursementDate;
                    _cashDisbursement.CashDisbursementVoucher = _parentView.VoucherNumber;

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
