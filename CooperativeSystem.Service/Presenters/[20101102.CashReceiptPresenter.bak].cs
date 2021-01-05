using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Loans;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan;
using CooperativeSystem.Service.Presenters.Savings.TimeDeposit;
using CooperativeSystem.Service.Presenters.Savings.TimeDeposit.Calculators;
using CooperativeSystem.Service.Utilities;
using CooperativeSystem.Service.Utilities.SequenceGenerators;

namespace CooperativeSystem.Service.Presenters
{
    public class CashReceiptPresenter : PresenterTemplate
    {
        #region Fields

        // persistence
        private DataContext _db;
        private IRepository<Member> _repository;

        // receipt generator
        private CashReceiptNumberGenerator _receiptGenerator;

        // views
        private ICashReceiptView _parentView;

        // loans
        private ILoanPaymentView _childLoanView;

        // plans
        private ICIPPaymentView _childCIPView;

        // savings
        private ITimeDepositDepositView _childTimeDepositView;

        // object graphs
        private Member _member;
        private CashReceipt _cashReceipt;

        #endregion

        #region Constructor

        public CashReceiptPresenter(ICashReceiptView parentView, 
            ILoanPaymentView childLoanView,
            ITimeDepositDepositView childTimeDepositView,
            ICIPPaymentView childCIPView)
        {
            // parent view
            _parentView = parentView;

            // child views
            _childLoanView = childLoanView;
            _childTimeDepositView = childTimeDepositView;
            _childCIPView = childCIPView;

            // events
            WireChildViewEvents();
        }

        #endregion 

        #region Routine Helpers

        private void InitializePersistenceManager()
        {
            // persistence
            _db = new DataContextFactory().CreateDataContext();
            _repository = new GenericRepository<Member>(_db);
            _receiptGenerator = new CashReceiptNumberGenerator(_db);
        }

        private void WireChildViewEvents()
        {
            _childLoanView.ReceiptAdd += new EventHandler(ChildLoanView_ReceiptAdd);
            _childTimeDepositView.AssessmentAdd += new EventHandler(ChildTimeDepositView_AssessmentAdd);
            _childCIPView.ReceiptAdd += new EventHandler(ChildCIPView_ReceiptAdd);
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
                case "MI":
                    _parentView.MiscellaneousIncome = amount;
                    break;
                case "O":
                    _parentView.Others = amount;
                    break;
            }

            if (!_parentView.IsThereServiceReceipt)
                _parentView.IsThereServiceReceipt = true;
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
            _parentView.MiscellaneousIncome = DEFAULT_AMOUNT;
            _parentView.MembershipFee = DEFAULT_AMOUNT;
            _parentView.Others = DEFAULT_AMOUNT;

            // receipt 
            _parentView.ReceiptNumber = _receiptGenerator.GenerateReceipt();
        }

        #endregion

        #region Object Graph state modifier methods

        private bool InitializeObjectGraph()
        {
            _parentView.IsThereServiceReceipt = false;
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

            _cashReceipt = new CashReceipt();
            _cashReceipt.ReceiptDate = _parentView.ReceiptDate;
            _cashReceipt.UserID = _parentView.UserID;
            _cashReceipt.Member = _member;

            return true;
        }

        private void FinalizeObjectGraph()
        {
            /************************************
             * savings deposit
             ************************************/
            var hasSavingsDeposit = (_parentView.SavingsDeposit != 0M);
            if (hasSavingsDeposit)
            {
                var amount = _parentView.SavingsDeposit;
                var exists = (_member.SavingsDeposit.SavingsDepositReceipts.Any(x => x.CashReceipt == _cashReceipt));
                if (exists)
                    _member.SavingsDeposit.UpdateSavingsDepositReceipt(amount, _cashReceipt);
                else
                    _member.SavingsDeposit.AddSavingsDepositReceipt(new SavingsDepositReceipt() { Amount = amount, CashReceipt = _cashReceipt });

                //_member.SavingsDeposit.AddSavingsDepositReceipt(new SavingsDepositReceipt()
                //    {
                //        CashReceipt = _cashReceipt,
                //        Amount = _parentView.SavingsDeposit
                //    });

                //if (_member.SavingsDeposit == null)
                //{
                //    _member.SavingsDeposit = new SavingsDeposit();
                //    _member.SavingsDeposit.CurrentBalance = 0M;
                //}

                //// look for previous payment instance
                //var savingsDepositReceipt = _member.SavingsDeposit.SavingsDepositReceipts
                //    .Where(sdr => sdr.CashReceipt == _cashReceipt)
                //    .FirstOrDefault();

                //if (savingsDepositReceipt == null)
                //{
                //    savingsDepositReceipt = new SavingsDepositReceipt();
                //    _member.SavingsDeposit.SavingsDepositReceipts.Add(savingsDepositReceipt);
                //}
                //_member.SavingsDeposit.CurrentBalance += _parentView.SavingsDeposit;

                //savingsDepositReceipt.CashReceipt = _cashReceipt;
                //savingsDepositReceipt.Amount = _parentView.SavingsDeposit;
                //savingsDepositReceipt.Balance = _member.SavingsDeposit.CurrentBalance;
            }


            /************************************
             * capital share
             ************************************/
            var hasCapitalShare = (_parentView.CapitalShare != 0M);
            if (hasCapitalShare)
            {
                var amount = _parentView.CapitalShare;
                var exists = (_member.CapitalShare.CapitalShareReceipts.Any(x => x.CashReceipt == _cashReceipt));
                if (exists)
                    _member.CapitalShare.UpdateCapitalShareReceipt(amount, _cashReceipt);
                else
                    _member.CapitalShare.AddCapitalShareReceipt(new CapitalShareReceipt() { Amount = amount, CashReceipt = _cashReceipt });

                //if (_member.CapitalShare == null)
                //{
                //    _member.CapitalShare = new CapitalShare();
                //    _member.CapitalShare.CurrentBalance = 0M;
                //}

                //// look for previous payment instance
                //var capitalShareReceipt = _member.CapitalShare.CapitalShareReceipts
                //    .Where(sdr => sdr.CashReceipt == _cashReceipt)
                //    .FirstOrDefault();

                //if (capitalShareReceipt == null)
                //{
                //    capitalShareReceipt = new CapitalShareReceipt();
                //    _member.CapitalShare.CapitalShareReceipts.Add(capitalShareReceipt);
                //}
                //_member.CapitalShare.CurrentBalance += _parentView.CapitalShare;

                //capitalShareReceipt.CashReceipt = _cashReceipt;
                //capitalShareReceipt.Amount = _parentView.CapitalShare;
                //capitalShareReceipt.Balance = _member.CapitalShare.CurrentBalance;
            }


            /************************************
             * pension plan
             ************************************/
            var hasPensionPlan = (_parentView.PensionPlan != 0M);
            if (hasPensionPlan)
            {
                if (_member.PensionPlan == null)
                    throw new Exception("You do not have pension plan. Please enroll Pension Plan first.");

                // look for previous payment instance
                var pensionPlanReceipt = _member.PensionPlan.PensionPlanReceipts
                    .Where(sdr => sdr.CashReceipt == _cashReceipt)
                    .FirstOrDefault();

                if (pensionPlanReceipt == null)
                {
                    pensionPlanReceipt = new PensionPlanReceipt();
                    _member.PensionPlan.PensionPlanReceipts.Add(pensionPlanReceipt);
                }
                pensionPlanReceipt.CashReceipt = _cashReceipt;
                pensionPlanReceipt.Amount = _parentView.PensionPlan;

                var pensionPlan = _member.PensionPlan;
                var isFullyPaid = (pensionPlan.PensionPlanReceipts.Sum(r => r.Amount) >= pensionPlan.PaymentCompletionAmount);
                if (isFullyPaid)
                    pensionPlan.PaymentCompletionDate = _parentView.ReceiptDate;
            }
            

            /************************************
             * tulungan fund
             ************************************/
            var hasTulunganFund = (_parentView.TulunganFund != 0M);
            if (hasTulunganFund)
            {
                if (_member.TulunganFund == null)
                {
                    _member.TulunganFund = new TulunganFund();
                    _member.TulunganFund.CurrentBalance = 0;
                }

                // look for previous payment instance
                var tulunganFundReceipt = _member.TulunganFund.TulunganFundReceipts
                    .Where(sdr => sdr.CashReceipt == _cashReceipt)
                    .FirstOrDefault();

                if (tulunganFundReceipt == null)
                {
                    tulunganFundReceipt = new TulunganFundReceipt();
                    _member.TulunganFund.TulunganFundReceipts.Add(tulunganFundReceipt);
                }
                _member.TulunganFund.CurrentBalance += _parentView.TulunganFund;
                tulunganFundReceipt.CashReceipt = _cashReceipt;
                tulunganFundReceipt.Amount = _parentView.TulunganFund;
            }


            /************************************
             * death aid fund
             ************************************/
            var hasDeathAidFund = (_parentView.DeathAidFund != 0M);
            if (hasDeathAidFund)
            {
                if (_member.DeathAidFund == null)
                {
                    _member.DeathAidFund = new DeathAidFund();
                    _member.DeathAidFund.CurrentBalance = 0;
                }

                // look for previous payment instance
                var deathAidFundReceipt = _member.DeathAidFund.DeathAidFundReceipts
                    .Where(sdr => sdr.CashReceipt == _cashReceipt)
                    .FirstOrDefault();

                if (deathAidFundReceipt == null)
                {
                    deathAidFundReceipt = new DeathAidFundReceipt();
                    _member.DeathAidFund.DeathAidFundReceipts.Add(deathAidFundReceipt);
                }
                _member.DeathAidFund.CurrentBalance += _parentView.DeathAidFund;
                deathAidFundReceipt.CashReceipt = _cashReceipt;
                deathAidFundReceipt.Amount = _parentView.DeathAidFund;
            }


            /************************************
             * miscellaneous income
             ************************************/
            var hasMiscellaneousIncome = (_parentView.MiscellaneousIncome != 0M);
            if (hasMiscellaneousIncome)
            {
                _cashReceipt.MiscellaneousIncomeReceipt = new MiscellaneousIncomeReceipt();
                _cashReceipt.MiscellaneousIncomeReceipt.Amount = _parentView.MiscellaneousIncome;
            }

            /************************************
             * membership fee
             ************************************/
            var hasMembershipFee = (_parentView.Others != 0M);
            if (hasMembershipFee)
            {
                _cashReceipt.MembershipFeeReceipt = new MembershipFeeReceipt();
                _cashReceipt.MembershipFeeReceipt.Amount = _parentView.MembershipFee;
            }


            /************************************
             * others
             ************************************/
            var hasOthers = (_parentView.Others != 0M);
            if (hasOthers)
            {
                _cashReceipt.OtherReceipt = new OtherReceipt();
                _cashReceipt.OtherReceipt.Amount = _parentView.Others;
            }

        }

        private void ChildLoanView_ReceiptAdd(object sender, EventArgs e)
        {
            var totalPaymentAmount = 0M;

            // look for the loan 
            var loan = _member.Loans
                .FirstOrDefault(l => l.LoanID == _childLoanView.LoanID);

            // if none, this is an exceptional case. Throw error
            if (loan == null)
                throw new Exception("The system was unable to add the loan payment. Please verify.");

            // look for previous receipt
            var loanReceipt = loan.LoanReceipts
                .FirstOrDefault(lr => lr.CashReceipt == _cashReceipt);

            // create new if none
            if (loanReceipt == null)
            {
                loanReceipt = new LoanReceipt();
                loan.LoanReceipts.Add(loanReceipt);
            }
            loanReceipt.CashReceipt = _cashReceipt;
            loanReceipt.Amount = _childLoanView.PaymentAmount;
            totalPaymentAmount += _childLoanView.PaymentAmount;

            // check balance
            loan.Settled = (loan.OutstandingBalance <= 0M); //(_childLoanView.PaymentAmount >= _childLoanView.OutstandingBalance);
            if (!loan.Settled)
            {
                // compute for the next payment date
                var days = loan.PaymentMode.Days;
                var terms = ((DateTime.Today - loan.LoanDate.TruncateTime()).Days / days) + 1;
                var nextPaymentDueDate = loan.LoanDate.AddDays(terms * days);
                loan.NextPaymentDueDate = nextPaymentDueDate < loan.DueDate 
                    ? nextPaymentDueDate 
                    : loan.DueDate;
            }

            // handle late payment charge
            if (_childLoanView.HasLatePaymentCharge && _childLoanView.PayLatePaymentCharge)
            {
                if (_childLoanView.LatePaymentCharge == 0M)
                    throw new Exception("Please specify late payment charge amount.");

                // look for previous receipt
                var latePaymentFineReceipt = loan.LatePaymentFineReceipts
                    .FirstOrDefault(lr => lr.CashReceipt == _cashReceipt);

                // create new if none
                if (latePaymentFineReceipt == null)
                {
                    latePaymentFineReceipt = new LatePaymentFineReceipt();
                    loan.LatePaymentFineReceipts.Add(latePaymentFineReceipt);
                }
                latePaymentFineReceipt.CashReceipt = _cashReceipt;
                latePaymentFineReceipt.Amount = _childLoanView.LatePaymentCharge;
                totalPaymentAmount += _childLoanView.LatePaymentCharge;
            }

            // handle delinquent charge
            if (_childLoanView.HasDelinquentCharge && _childLoanView.PayDelinquentCharge)
            {
                if (_childLoanView.DelinquentCharge == 0M)
                    throw new Exception("Please specify deliqeunt charge amount.");

                // look for previous receipt
                var delinquentFineReceipt = loan.DelinquentFineReceipts
                    .FirstOrDefault(lr => lr.CashReceipt == _cashReceipt);

                // create new if none
                if (delinquentFineReceipt == null)
                {
                    delinquentFineReceipt = new DelinquentFineReceipt();
                    loan.DelinquentFineReceipts.Add(delinquentFineReceipt);
                }
                delinquentFineReceipt.CashReceipt = _cashReceipt;
                delinquentFineReceipt.Amount = _childLoanView.DelinquentCharge;
                totalPaymentAmount += _childLoanView.DelinquentCharge;
            }

            ReflectToParent(_childLoanView.LoanServiceID, totalPaymentAmount);
        }

        private void ChildTimeDepositView_AssessmentAdd(object sender, EventArgs e)
        {
            // validate business rules
            var minimumAmount = _db.GetTable<TimeDepositMinimumAmount>().FirstOrDefault().Amount;
            var depositAmount = _childTimeDepositView.Amount;
            if (depositAmount < minimumAmount)
                throw new Exception(string.Format("Deposit is under minimum amount. Please deposit {0} or higher.", minimumAmount.ToString("N2")));

            // compute for interest rate
            var interestRateCalculator = new InterestRateCalculator(_db.GetTable<TimeDepositInterestRate>().FirstOrDefault());
            var interestRate = interestRateCalculator.ComputeInterest(depositAmount);

            // look for previous receipt
            var timeDeposit = _member.TimeDeposits
                .FirstOrDefault(td => td.TimeDepositID == 0);

            // create new if none
            if (timeDeposit == null)
            {
                timeDeposit = new TimeDeposit();
                _member.TimeDeposits.Add(timeDeposit);
            }

            timeDeposit.DepositDate = _childTimeDepositView.DepositDate;
            timeDeposit.InterestRate = interestRate;
            timeDeposit.Terms = _childTimeDepositView.Terms;
            timeDeposit.MaturityDate = _childTimeDepositView.MaturityDate;
            timeDeposit.Consumed = false;

            var timeDepositReceipt = timeDeposit.TimeDepositReceipts
                .FirstOrDefault(lr => lr.CashReceipt == _cashReceipt);

            // create new if none
            if (timeDepositReceipt == null)
            {
                timeDepositReceipt = new TimeDepositReceipt();
                timeDeposit.TimeDepositReceipts.Add(timeDepositReceipt);
            }
            timeDepositReceipt.CashReceipt = _cashReceipt;
            timeDepositReceipt.Amount = depositAmount;

            ReflectToParent(ServiceCodes.TimeDeposit, depositAmount);
        }

        private void ChildCIPView_ReceiptAdd(object sender, EventArgs e)
        {
            var payablePlanQuery = _member.CollegeInsurancePlans
                .Where(p =>
                    p.Consumed == false &&
                    p.PaymentCompletionAmount > p.CollegeInsurancePlanReceipts.Sum(r => r.Amount));

            // this is bad, this should not happen. inform user and exit function
            if (payablePlanQuery == null)
                throw new Exception("Unexpected error occured. " +
                    "The system cannot find any of your payable College Insurance Plan. Please verify.");

            // this is bad, this should not happen. should validate at _childCIPView 
            // before triggering AssessmentAdd event handler 
            if (_childCIPView.PayablePlansToPay == null || _childCIPView.PayablePlansToPay.Count < 1)
                throw new Exception("There is not item to selected. If you intend to pay your " +
                    "College Insurance Plan, please select item from the list.");

            // clear any recent assessment
            foreach (var plan in payablePlanQuery)
            {
                //plan.Consumed = false;

                var cipr = plan.CollegeInsurancePlanReceipts
                    .Where(r => r.CashReceipt == _cashReceipt)
                    .FirstOrDefault();

                if (cipr != null)
                    plan.CollegeInsurancePlanReceipts.Remove(cipr);

                //if (cipr != null)
                //{
                //    plan.CollegeInsurancePlanReceipts.Remove(cipr);
                //    _db.GetTable(typeof(Member)).DeleteOnSubmit(cipr);
                //}
            }

            // add the new receipts
            foreach (var planToPay in _childCIPView.PayablePlansToPay)
            {
                var target = payablePlanQuery
                    .FirstOrDefault(td => td.CollegeInsurancePlanID == planToPay.CollegeInsurancePlanID);

                // this should never happen. throw error if in case it does.
                if (target == null)
                    throw new Exception("Unexpected error occured. Error adding you payment.");

                var receipt = new CollegeInsurancePlanReceipt()
                {
                    //ReceiptID = _cashReceipt.ReceiptID,
                    CashReceipt = _cashReceipt,
                    Amount = planToPay.PaymentAmount,
                };

                target.CollegeInsurancePlanReceipts.Add(receipt);
                var isPaymentCompleted = (target.CollegeInsurancePlanReceipts.Sum(r => r.Amount) >= target.PaymentCompletionAmount);
                if (isPaymentCompleted)
                {
                    target.PaymentCompletionDate = _parentView.ReceiptDate;
                    target.MaturityDate = _parentView.ReceiptDate.AddYears(target.AgingPeriod);
                }

            }

            ReflectToParent(ServiceCodes.CollegeInsurancePlan, _childCIPView.TotalPaymentAmount);
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

        public bool GenerateReceiptNumber()
        {
            var remarks = string.Empty;
            var reciept = _receiptGenerator.GenerateReceipt(_parentView.Sequence, out remarks);
            if (string.IsNullOrEmpty(reciept))
            {
                OnError(remarks);
                return false;
            }

            _parentView.ReceiptNumber = reciept;
            return true;
        }

        public bool Accept()
        {
            //using (var transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
            //{
            try
            {
                FinalizeObjectGraph();

                _cashReceipt.ReceiptDate = _parentView.ReceiptDate;
                _cashReceipt.OfficialReceiptNumber = _parentView.ReceiptNumber;

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
