using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.MemberPeriodicalBalanceSummaries
{
    public class PeriodicalBalance
    {
        #region Member

        private string _member;

        public string Member
        {
            get { return _member; }
            internal set 
            { 
                if (value.Contains("Lulu"))
                    Console.WriteLine("hehe");

                _member = value;
            }
        }

        #endregion

        #region Category

        private string _category;

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        #endregion

        #region Savings

        #region Savings Deposit

        private Nullable<decimal> _savingsDeposit;
        internal virtual Nullable<decimal> SavingsDepositReceipt { get; set; }
        internal virtual Nullable<decimal> SavingsDepositAdjustment { get; set; }
        internal virtual Nullable<decimal> SavingsDepositInterestAdjustment { get; set; }
        internal virtual Nullable<decimal> SavingsDepositDividendAdjustment { get; set; }
        internal virtual Nullable<decimal> SavingsDepositDisbursement { get; set; }

        public virtual decimal SavingsDeposit 
        {
            get
            {

                if (_savingsDeposit == null)
                {
                    _savingsDeposit =
                        (SavingsDepositReceipt ?? 0M) +
                        (SavingsDepositAdjustment ?? 0M) +
                        (SavingsDepositInterestAdjustment ?? 0M) +
                        (SavingsDepositDividendAdjustment ?? 0M) -
                        (SavingsDepositDisbursement ?? 0M);
                }
                return _savingsDeposit.Value;
            }
        }

        #endregion

        #region Capital Share

        private Nullable<decimal> _capitalShare;
        internal virtual Nullable<decimal> CapitalShareReceipt { get; set; }
        internal virtual Nullable<decimal> CapitalShareBuildup { get; set; }
        internal virtual Nullable<decimal> CapitalShareAdjustment { get; set; }
        internal virtual Nullable<decimal> CapitalShareDisbursement { get; set; }
        internal virtual Nullable<decimal> CapitalShareDividendAdjustment { get; set; }
        internal virtual Nullable<decimal> CapitalShareInterestRebateAdjustment { get; set; }
        internal virtual Nullable<decimal> CapitalSharePatronageRefundAdjustment { get; set; }

        public virtual decimal CapitalShare
        { 
            get 
            {
                if (_capitalShare == null)
                {
                    _capitalShare =
                        (CapitalShareReceipt ?? 0M) +
                        (CapitalShareBuildup ?? 0M) +
                        (CapitalShareAdjustment ?? 0M) +
                        (CapitalShareDividendAdjustment ?? 0M) +
                        (CapitalShareInterestRebateAdjustment ?? 0M) +
                        (CapitalSharePatronageRefundAdjustment ?? 0M) -
                        (CapitalShareDisbursement ?? 0M);
                }
                return _capitalShare.Value;
            } 
        }

        #endregion

        #region Time Deposit

        private Nullable<decimal> _timeDeposit;
        internal virtual Nullable<decimal> TimeDepositInterest { get; set; }
        internal virtual Nullable<decimal> TimeDepositReceipt { get; set; }
        internal virtual Nullable<decimal> TimeDepositAdjustment { get; set; }
        internal virtual Nullable<decimal> TimeDepositDisbursement { get; set; }

        public virtual decimal TimeDeposit
        { 
            get 
            {
                if (_timeDeposit == null)
                {
                    _timeDeposit =
                        (TimeDepositInterest ?? 0M) +
                        (TimeDepositReceipt ?? 0M) +
                        (TimeDepositAdjustment ?? 0M) -
                        (TimeDepositDisbursement ?? 0M);
                }
                return _timeDeposit.Value;
            } 
        }

        #endregion

        #endregion

        #region Loans

        #region Appliance Loan

        private Nullable<decimal> _applianceLoan;
        internal virtual Nullable<decimal> ApplianceLoanTotalPayableAmount { get; set; }
        internal virtual Nullable<decimal> ApplianceLoanReceipt { get; set; }
        internal virtual Nullable<decimal> ApplianceLoanAdjustment { get; set; }
        internal virtual Nullable<decimal> ApplianceLoanDividendAdjustment { get; set; }

        public virtual decimal ApplianceLoan 
        {
            get 
            {
                if (_applianceLoan == null)
                {
                    _applianceLoan =
                        (ApplianceLoanTotalPayableAmount ?? 0M) -
                        (ApplianceLoanReceipt ?? 0M) -
                        (ApplianceLoanAdjustment ?? 0M) -
                        (ApplianceLoanDividendAdjustment ?? 0M);
                }
                return _applianceLoan.Value;
            }
        }

        #endregion

        #region Easy Loan

        private Nullable<decimal> _easyLoan;
        internal virtual Nullable<decimal> EasyLoanTotalPayableAmount { get; set; }
        internal virtual Nullable<decimal> EasyLoanReceipt { get; set; }
        internal virtual Nullable<decimal> EasyLoanAdjustment { get; set; }
        internal virtual Nullable<decimal> EasyLoanDividendAdjustment { get; set; }

        public virtual decimal EasyLoan
        {
            get
            {
                if (_easyLoan == null)
                {
                    _easyLoan =
                        (EasyLoanTotalPayableAmount ?? 0M) -
                        (EasyLoanReceipt ?? 0M) -
                        (EasyLoanAdjustment ?? 0M) -
                        (EasyLoanDividendAdjustment ?? 0M);
                }
                return _easyLoan.Value;
            }
        }

        #endregion

        #region Emergency Loan

        private Nullable<decimal> _emergencyLoan;
        internal virtual Nullable<decimal> EmergencyLoanTotalPayableAmount { get; set; }
        internal virtual Nullable<decimal> EmergencyLoanReceipt { get; set; }
        internal virtual Nullable<decimal> EmergencyLoanAdjustment { get; set; }
        internal virtual Nullable<decimal> EmergencyLoanDividendAdjustment { get; set; }

        public virtual decimal EmergencyLoan
        {
            get
            {
                if (_emergencyLoan == null)
                {
                    _emergencyLoan =
                        (EmergencyLoanTotalPayableAmount ?? 0M) -
                        (EmergencyLoanReceipt ?? 0M) -
                        (EmergencyLoanAdjustment ?? 0M) -
                        (EmergencyLoanDividendAdjustment ?? 0M);
                }
                return _emergencyLoan.Value;
            }
        }

        #endregion

        #region Equity Loan

        private Nullable<decimal> _equityLoan;
        internal virtual Nullable<decimal> EquityLoanTotalPayableAmount { get; set; }
        internal virtual Nullable<decimal> EquityLoanReceipt { get; set; }
        internal virtual Nullable<decimal> EquityLoanAdjustment { get; set; }
        internal virtual Nullable<decimal> EquityLoanDividendAdjustment { get; set; }

        public virtual decimal EquityLoan
        {
            get
            {
                if (_equityLoan == null)
                {
                    _equityLoan =
                        (EquityLoanTotalPayableAmount ?? 0M) -
                        (EquityLoanReceipt ?? 0M) -
                        (EquityLoanAdjustment ?? 0M) -
                        (EquityLoanDividendAdjustment ?? 0M);
                }
                return _equityLoan.Value;
            }
        }

        #endregion

        #region Pension Loan

        private Nullable<decimal> _pensionLoan;
        internal virtual Nullable<decimal> PensionLoanTotalPayableAmount { get; set; }
        internal virtual Nullable<decimal> PensionLoanReceipt { get; set; }
        internal virtual Nullable<decimal> PensionLoanAdjustment { get; set; }
        internal virtual Nullable<decimal> PensionLoanDividendAdjustment { get; set; }

        public virtual decimal PensionLoan
        {
            get
            {
                if (_pensionLoan == null)
                {
                    _pensionLoan =
                        (PensionLoanTotalPayableAmount ?? 0M) -
                        (PensionLoanReceipt ?? 0M) -
                        (PensionLoanAdjustment ?? 0M) -
                        (PensionLoanDividendAdjustment ?? 0M);
                }
                return _pensionLoan.Value;
            }
        }

        #endregion

        #region Regular Loan

        private Nullable<decimal> _regularLoan;
        internal virtual Nullable<decimal> RegularLoanTotalPayableAmount { get; set; }
        internal virtual Nullable<decimal> RegularLoanReceipt { get; set; }
        internal virtual Nullable<decimal> RegularLoanAdjustment { get; set; }
        internal virtual Nullable<decimal> RegularLoanDividendAdjustment { get; set; }

        public virtual decimal RegularLoan
        {
            get
            {
                if (_regularLoan == null)
                {
                    _regularLoan =
                        (RegularLoanTotalPayableAmount ?? 0M) -
                        (RegularLoanReceipt ?? 0M) -
                        (RegularLoanAdjustment ?? 0M) -
                        (RegularLoanDividendAdjustment ?? 0M);
                }
                return _regularLoan.Value;
            }
        }

        #endregion

        #endregion

        #region Plans

        #region Pension Plan

        private Nullable<decimal> _pensionPlan;
        internal virtual Nullable<decimal> PensionPlanReceipt { get; set; }
        internal virtual Nullable<decimal> PensionPlanAdjustment { get; set; }
        internal virtual Nullable<decimal> PensionPlanInterestAdjustment { get; set; }
        internal virtual Nullable<decimal> PensionPlanDisbursement { get; set; }

        public virtual decimal PensionPlan
        {
            get
            {
                if (_pensionPlan == null)
                {
                    _pensionPlan =
                        (PensionPlanReceipt ?? 0M) +
                        (PensionPlanAdjustment ?? 0M) +
                        (PensionPlanInterestAdjustment ?? 0M) -
                        (PensionPlanDisbursement ?? 0M);
                }
                return _pensionPlan.Value;
            }
        }

        #endregion

        #region College Insurance Plan

        private Nullable<decimal> _collegeInsurancePlan;
        internal virtual Nullable<decimal> CollegeInsurancePlanReceipt { get; set; }
        internal virtual Nullable<decimal> CollegeInsurancePlanAdjustment { get; set; }
        internal virtual Nullable<decimal> CollegeInsurancePlanDisbursement { get; set; }

        public virtual decimal CollegeInsurancePlan
        {
            get
            {
                if (_collegeInsurancePlan == null)
                {
                    _collegeInsurancePlan =
                        (CollegeInsurancePlanReceipt ?? 0M) +
                        (CollegeInsurancePlanAdjustment ?? 0M) -
                        (CollegeInsurancePlanDisbursement ?? 0M);
                }
                return _collegeInsurancePlan.Value;
            }
        }

        #endregion

        #endregion

        #region Special Funds

        #region Death Aid Fund

        private Nullable<decimal> _deathAidFund;
        internal virtual Nullable<decimal> DeathAidFundReceipt { get; set; }
        internal virtual Nullable<decimal> DeathAidFundAdjustment { get; set; }
        internal virtual Nullable<decimal> DeathAidFundDisbursement { get; set; }

        public virtual decimal DeathAidFund
        {
            get
            {
                if (_deathAidFund == null)
                {
                    _deathAidFund =
                        (DeathAidFundReceipt ?? 0M) +
                        (DeathAidFundAdjustment ?? 0M) -
                        (DeathAidFundDisbursement ?? 0M);
                }
                return _deathAidFund.Value;
            }
        }

        #endregion

        #region Tulungan Fund

        private Nullable<decimal> _tulunganFund;
        internal virtual Nullable<decimal> TulunganFundReceipt { get; set; }
        internal virtual Nullable<decimal> TulunganFundAdjustment { get; set; }
        internal virtual Nullable<decimal> TulunganFundDisbursement { get; set; }

        public virtual decimal TulunganFund
        {
            get
            {
                if (_tulunganFund == null)
                {
                    _tulunganFund =
                        (TulunganFundReceipt ?? 0M) +
                        (TulunganFundAdjustment ?? 0M) -
                        (TulunganFundDisbursement ?? 0M);
                }
                return _tulunganFund.Value;
            }
        }

        #endregion

        #endregion

        #region Total

        private Nullable<decimal> _total;

        public decimal Total
        {
            get
            {
                if (_total == null)
                {
                    _total = 
                        SavingsDeposit + CapitalShare + TimeDeposit + ApplianceLoan + EasyLoan +
                        EmergencyLoan + EquityLoan + PensionLoan + RegularLoan + PensionPlan +
                        CollegeInsurancePlan + TulunganFund + DeathAidFund;
                }
                return _total.Value;
            }
        }

        #endregion
    }
}
