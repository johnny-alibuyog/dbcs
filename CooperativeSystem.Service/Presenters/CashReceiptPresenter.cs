using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Loans;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan;
using CooperativeSystem.Service.Presenters.Plans.CollegeInsurancePlan.Calculators;
using CooperativeSystem.Service.Presenters.Plans.PensionPlan;
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
        private IPensionPlanPaymentView _childPensionPlanView;

        // savings
        private ITimeDepositDepositView _childTimeDepositView;

        // object graphs
        private Member _member;
        private CashReceipt _cashReceipt;

        #endregion

        #region Properties

        public DataContext DataContext
        {
            get { return _db; }
            set { _db = value; }
        }

        #endregion

        #region Constructor

        public CashReceiptPresenter(
            ICashReceiptView parentView,
            ILoanPaymentView childLoanView,
            ITimeDepositDepositView childTimeDepositView,
            ICIPPaymentView childCIPView,
            IPensionPlanPaymentView childPensionPlanView
        )
        {
            // parent view
            _parentView = parentView;

            // child views
            _childLoanView = childLoanView;
            _childTimeDepositView = childTimeDepositView;
            _childCIPView = childCIPView;
            _childPensionPlanView = childPensionPlanView;

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
            _childPensionPlanView.ReceiptAdd += new EventHandler(ChildPensionPlanView_ReceiptAdd);
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
            _parentView.ReceiptNumber = _receiptGenerator.Generate();
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
                RaiseErrorEvent("You did not perform customer search. Please select customer from custumer inquiry.");
                return false;
            }

            _member = _repository.GetEntity(m => m.MemberID == _parentView.MemberID);
            if (_member == null)
            {
                RaiseErrorEvent(string.Format("Member doesn't exist. Please select a valid member."));
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
                MakeSavingsDepositReceipt(_parentView.SavingsDeposit);
            }


            /************************************
             * capital share
             ************************************/
            var hasCapitalShare = (_parentView.CapitalShare != 0M);
            if (hasCapitalShare)
            {
                MakeCapitalShareReceipt(_parentView.CapitalShare);
            }


            ///************************************
            // * pension plan
            // ************************************/
            //var hasPensionPlan = (_parentView.PensionPlan != 0M);
            //if (hasPensionPlan)
            //{
            //    if (_member.PensionPlan == null)
            //        throw new Exception("You do not have pension plan. Please enroll Pension Plan first.");

            //    var amount = _parentView.PensionPlan;
            //    var exists = (_member.PensionPlan.PensionPlanReceipts.Any(x => x.CashReceipt == _cashReceipt));
            //    if (exists)
            //        _member.PensionPlan.UpdatePensionPlanReceipt(amount, _cashReceipt);
            //    else
            //        _member.PensionPlan.AddPensionPlanReceipt(new PensionPlanReceipt() { Amount = amount, CashReceipt = _cashReceipt });
            //}


            /************************************
             * tulungan fund
             ************************************/
            var hasTulunganFund = (_parentView.TulunganFund != 0M);
            if (hasTulunganFund)
            {
                MakeTulunganFundReceipt(_parentView.TulunganFund);
            }


            /************************************
             * death aid fund
             ************************************/
            var hasDeathAidFund = (_parentView.DeathAidFund != 0M);
            if (hasDeathAidFund)
            {
                MakeDeathAidFundReceipt(_parentView.DeathAidFund);
            }


            /************************************
             * miscellaneous income
             ************************************/
            var hasMiscellaneousIncome = (_parentView.MiscellaneousIncome != 0M);
            if (hasMiscellaneousIncome)
            {
                MakeMiscellaneousIncomeReceipt(_parentView.MiscellaneousIncome);
            }


            /************************************
             * membership fee
             ************************************/
            var hasMembershipFee = (_parentView.MembershipFee != 0M);
            if (hasMembershipFee)
            {
                MakeMembershipFeeReceipt(_parentView.MembershipFee);
            }


            /************************************
             * others
             ************************************/
            var hasOthers = (_parentView.Others != 0M);
            if (hasOthers)
            {
                MakeOthersReceipt(_parentView.Others);
            }

        }

        private void MakeSavingsDepositReceipt(decimal amount)
        {
            if (_member.SavingsDeposit == null)
            {
                _member.SavingsDeposit = new SavingsDeposit();
                _member.SavingsDeposit.CurrentBalance = 0M;
            }

            var exists = (_member.SavingsDeposit.SavingsDepositReceipts.Any(x => x.CashReceipt == _cashReceipt));
            if (exists)
                _member.SavingsDeposit.UpdateSavingsDepositReceipt(amount, _cashReceipt);
            else
                _member.SavingsDeposit.AddSavingsDepositReceipt(new SavingsDepositReceipt() { Amount = amount, CashReceipt = _cashReceipt });
        }

        private void MakeCapitalShareReceipt(decimal amount)
        {
            if (_member.CapitalShare == null)
            {
                _member.CapitalShare = new CapitalShare();
                _member.CapitalShare.CurrentBalance = 0;
            }

            var exists = (_member.CapitalShare.CapitalShareReceipts.Any(x => x.CashReceipt == _cashReceipt));
            if (exists)
                _member.CapitalShare.UpdateCapitalShareReceipt(amount, _cashReceipt);
            else
                _member.CapitalShare.AddCapitalShareReceipt(new CapitalShareReceipt() { Amount = amount, CashReceipt = _cashReceipt });
        }

        private void MakeTulunganFundReceipt(decimal amount)
        {
            if (_member.TulunganFund == null)
            {
                _member.TulunganFund = new TulunganFund();
                _member.TulunganFund.CurrentBalance = 0;
            }

            var exists = (_member.TulunganFund.TulunganFundReceipts.Any(x => x.CashReceipt == _cashReceipt));
            if (exists)
                _member.TulunganFund.UpdateTulunganFundReceipt(amount, _cashReceipt);
            else
                _member.TulunganFund.AddTulunganFundReceipt(new TulunganFundReceipt() { Amount = amount, CashReceipt = _cashReceipt });
        }

        private void MakeDeathAidFundReceipt(decimal amount)
        {
            if (_member.DeathAidFund == null)
            {
                _member.DeathAidFund = new DeathAidFund();
                _member.DeathAidFund.CurrentBalance = 0;
            }

            var exists = (_member.DeathAidFund.DeathAidFundReceipts.Any(x => x.CashReceipt == _cashReceipt));
            if (exists)
                _member.DeathAidFund.UpdateDeathAidFundReceipt(amount, _cashReceipt);
            else
                _member.DeathAidFund.AddDeathAidFundReceipt(new DeathAidFundReceipt() { Amount = amount, CashReceipt = _cashReceipt });
        }

        private void MakeMiscellaneousIncomeReceipt(decimal amount)
        {
            _cashReceipt.MiscellaneousIncomeReceipt = new MiscellaneousIncomeReceipt();
            _cashReceipt.MiscellaneousIncomeReceipt.Amount = amount;
        }

        private void MakeMembershipFeeReceipt(decimal amount)
        {
            _cashReceipt.MembershipFeeReceipt = new MembershipFeeReceipt();
            _cashReceipt.MembershipFeeReceipt.Amount = amount;
        }

        private void MakeOthersReceipt(decimal amount)
        {
            _cashReceipt.OtherReceipt = new OtherReceipt();
            _cashReceipt.OtherReceipt.Amount = amount;
        }

        private void ChildLoanView_ReceiptAdd(object sender, EventArgs e)
        {
            var totalPaymentAmount = 0M;

            // look for the loan 
            var loan = _member.Loans.FirstOrDefault(l => l.LoanID == _childLoanView.LoanID);

            // if none, this is an exceptional case. Throw error
            if (loan == null)
                throw new Exception("The system was unable to add the loan payment. Please verify.");

            //if (_childLoanView.PaymentAmount == 0M)
            //    throw new Exception("Please specify payment amount.");

            if (_childLoanView.FullyPayOutstandingBalance == true)
            {
                if (_childLoanView.FullyPayLatePaymentCharge == false &&
                    _childLoanView.CondoneLatePaymentCharge == false)
                    throw new Exception("Please pay your late payment charge first.");

                if (_childLoanView.FullyPayDelinquentCharge == false &&
                    _childLoanView.CondoneDelinquentCharge == false)
                    throw new Exception("Please pay your delinquent charge first.");
            }

            var amount = _childLoanView.PaymentAmount;
            totalPaymentAmount += amount;

            // allow charge payment only
            //if (totalPaymentAmount <= 0M)
            //    throw new Exception("Please specify payment amount.");

            var exists = (loan.LoanReceipts.Any(x => x.CashReceipt == _cashReceipt));
            if (exists)
            {
                loan.UpdateLoanReceipt(amount, _cashReceipt);
            }
            else
            {
                loan.AddLoanReceipt(new LoanReceipt() 
                { 
                    Amount = amount, 
                    CashReceipt = _cashReceipt 
                });
            }

            loan.UnpaidPayables = _childLoanView.PayableAmount - _childLoanView.PaymentAmount;
            if (loan.UnpaidPayables < 0M)
                loan.UnpaidPayables = 0M;

            // handle late payment charge
            if (_childLoanView.HasLatePaymentCharge)
            {
                if (_childLoanView.CondoneLatePaymentCharge || _childLoanView.LatePaymentCharge > 0M)
                {
                    amount = _childLoanView.LatePaymentCharge;
                    totalPaymentAmount += amount;
                    loan.UnpaidLatePaymentCharge = null;

                    exists = (loan.LatePaymentFineReceipts.Any(x => x.CashReceipt == _cashReceipt));
                    if (exists)
                    {
                        loan.UpdateLatePaymentFineReceipt(
                            amount: amount,
                            computedAmount: _childLoanView.ComputedLatePaymentCharge,
                            previousUnpaid: _childLoanView.PreviousUnpaidLatePaymentCharge,
                            condone: _childLoanView.CondoneLatePaymentCharge,
                            cashReceipt: _cashReceipt
                        );
                    }
                    else
                    {
                        loan.AddLatePaymentFineReceipt(new LatePaymentFineReceipt()
                        {
                            Amount = amount,
                            ComputedAmount = _childLoanView.ComputedLatePaymentCharge,
                            PreviousUnpaid = _childLoanView.PreviousUnpaidLatePaymentCharge,
                            Condone = _childLoanView.CondoneLatePaymentCharge,
                            CashReceipt = _cashReceipt
                        });
                    }
                }
                else
                {
                    loan.UnpaidLatePaymentCharge = _childLoanView.LatePaymentCharge;
                }
            }

            // handle delinquent charge
            if (_childLoanView.HasDelinquentCharge)
            {
                if (_childLoanView.CondoneDelinquentCharge || _childLoanView.DelinquentCharge > 0M)
                {
                    amount = _childLoanView.DelinquentCharge;
                    totalPaymentAmount += amount;
                    loan.UnpaidDelinquentCharge = null;

                    exists = (loan.DelinquentFineReceipts.Any(x => x.CashReceipt == _cashReceipt));
                    if (exists)
                    {
                        loan.UpdateDelinquentFineReceipts(
                            amount: amount,
                            computedAmount: _childLoanView.ComputedDelinquentCharge,
                            previousUnpaid: _childLoanView.PreviousUnpaidDelinquentCharge,
                            condone: _childLoanView.CondoneDelinquentCharge,
                            cashReceipt: _cashReceipt
                        );
                    }
                    else
                    {
                        loan.AddDelinquentFineReceipts(new DelinquentFineReceipt()
                        {
                            Amount = amount,
                            ComputedAmount = _childLoanView.ComputedDelinquentCharge,
                            PreviousUnpaid = _childLoanView.PreviousUnpaidDelinquentCharge,
                            Condone = _childLoanView.CondoneDelinquentCharge,
                            CashReceipt = _cashReceipt
                        });
                    }
                }
                else
                {
                    loan.UnpaidDelinquentCharge = _childLoanView.DelinquentCharge;
                }
            }

            //if (_childLoanView.FullyPayPayableAmount)
            //{
            //    if (_childLoanView.FullyPayLatePaymentCharge || _childLoanView.CondoneLatePaymentCharge)
            //    {
            //        var accumulatedFines = loan.LatePaymentFineReceipts.Where(x => x.Accumulated == true);
            //        foreach ( var item in accumulatedFines)
            //        {
            //            item.Accumulated = false;
            //        }
            //    }

            //    if (_childLoanView.FullyPayDelinquentCharge || _childLoanView.CondoneDelinquentCharge)
            //    {
            //        var accumulatedCharges = loan.DelinquentFineReceipts.Where(x => x.Accumulated == true);
            //        foreach (var item in accumulatedCharges)
            //        {
            //            item.Accumulated = false;
            //        }
            //    }
            //}


            if (totalPaymentAmount <= 0M)
                throw new Exception("Please specify amount.");

            ReflectToParent(_childLoanView.LoanServiceID, totalPaymentAmount);
        }

        private void ChildTimeDepositView_AssessmentAdd(object sender, EventArgs e)
        {
            // validate business rules
            var minimumAmount = _db.GetTable<TimeDepositMinimumAmount>().FirstOrDefault().Amount;
            var timeDepositAmount = _childTimeDepositView.Amount;
            if (timeDepositAmount < minimumAmount)
                throw new Exception(string.Format("Deposit is under minimum amount. Please deposit {0} or higher.", minimumAmount.ToString("N2")));

            // compute for interest rate
            var interestRateCalculator = new InterestRateCalculator(_db.GetTable<TimeDepositInterestRate>().FirstOrDefault());
            var interestRate = interestRateCalculator.ComputeInterest(timeDepositAmount);

            // look for previous instance
            var timeDeposit = _member.TimeDeposits.FirstOrDefault(td => td.TimeDepositID == 0);

            // create new if none
            if (timeDeposit == null)
            {
                timeDeposit = new TimeDeposit();
                _member.TimeDeposits.Add(timeDeposit);
            }

            timeDeposit.DepositDate = _childTimeDepositView.DepositDate;
            timeDeposit.TimeDepositAmount = timeDepositAmount;
            timeDeposit.InterestRate = interestRate;
            timeDeposit.Terms = _childTimeDepositView.Terms;
            timeDeposit.MaturityDate = _childTimeDepositView.MaturityDate;
            timeDeposit.Consumed = false;

            // add receipt aggregate
            var amount = timeDepositAmount;
            var exists = timeDeposit.TimeDepositReceipts.Any(x => x.CashReceipt == _cashReceipt);
            if (exists)
                timeDeposit.UpdateTimeDepositReceipt(amount, _cashReceipt);
            else
                timeDeposit.AddTimeDepositReceipt(new TimeDepositReceipt() { Amount = amount, CashReceipt = _cashReceipt });

            ReflectToParent(ServiceCodes.TimeDeposit, timeDepositAmount);
        }

        private void ChildCIPView_ReceiptAdd(object sender, EventArgs e)
        {
            var payablePlans = _member.CollegeInsurancePlans
                .Where(x => 
                    x.Consumed == false &&
                    x.IsPaymentCompleted() == false
                );

            // this is bad, this should not happen. inform user and exit function
            if (!payablePlans.Any())
                throw new Exception("Unexpected error occured. " +
                    "The system cannot find any of your payable College Insurance Plan. Please verify.");

            // this is bad, this should not happen. should validate at _childCIPView 
            // before triggering AssessmentAdd event handler 
            if (_childCIPView.PayablePlansToPay == null || _childCIPView.PayablePlansToPay.Count < 1)
                throw new Exception("There is not item to selected. If you intend to pay your " +
                    "College Insurance Plan, please select item from the list.");

            // clear any recent assessment
            foreach (var plan in payablePlans)
            {
                //plan.Consumed = false;

                var item = plan.CollegeInsurancePlanReceipts
                    .Where(x => x.CashReceipt == _cashReceipt)
                    .FirstOrDefault();

                if (item != null)
                    plan.CollegeInsurancePlanReceipts.Remove(item);

                //if (cipr != null)
                //{
                //    plan.CollegeInsurancePlanReceipts.Remove(cipr);
                //    _db.GetTable(typeof(Member)).DeleteOnSubmit(cipr);
                //}
            }

            // add the new receipts
            foreach (var planToPay in _childCIPView.PayablePlansToPay)
            {
                var target = payablePlans.Single(td => td.CollegeInsurancePlanID == planToPay.CollegeInsurancePlanID);
                var amount = planToPay.PaymentAmount;
                target.AddCollegeInsurancePlanReceipt(new CollegeInsurancePlanReceipt() { Amount = amount, CashReceipt = _cashReceipt });
            }

            ReflectToParent(ServiceCodes.CollegeInsurancePlan, _childCIPView.TotalPaymentAmount);
        }

        private void ChildPensionPlanView_ReceiptAdd(object sender, EventArgs e)
        {
            if (_member.PensionPlan == null)
                throw new Exception("You do not have pension plan. Please enroll Pension Plan first.");

            if (_childPensionPlanView.PaymentAmount == 0M)
                throw new Exception("Please specify payment amount.");

            var amount = _childPensionPlanView.PaymentAmount;
            var exists = (_member.PensionPlan.PensionPlanReceipts.Any(x => x.CashReceipt == _cashReceipt));
            if (exists)
                _member.PensionPlan.UpdatePensionPlanReceipt(amount, _cashReceipt);
            else
                _member.PensionPlan.AddPensionPlanReceipt(new PensionPlanReceipt() { Amount = amount, CashReceipt = _cashReceipt });

            ReflectToParent(ServiceCodes.PensionPlan, amount);
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
            var reciept = _receiptGenerator.Generate(_parentView.Sequence, out remarks);
            if (string.IsNullOrEmpty(reciept))
            {
                RaiseErrorEvent(remarks);
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
