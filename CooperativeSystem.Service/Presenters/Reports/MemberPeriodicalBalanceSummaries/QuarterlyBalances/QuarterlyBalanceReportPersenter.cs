using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using System.Data.Linq;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Lookups.DeductionTypes;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Presenters.Reports.MemberPeriodicalBalanceSummaries.QuarterlyBalances
{
    public class QuarterlyBalanceReportPersenter : PresenterTemplate
    {
        private readonly IQuarterlyBalanceReportView _view;
        private readonly IPeriodicalBalanceService _service;

        public QuarterlyBalanceReportPersenter(IQuarterlyBalanceReportView view)
        {
            _view = view;
            _service = new PeriodicalBalanceService();
        }

        public bool PopulateReports()
        {
            try
            {
                var quarterEnd = _view.Quarter.GetMaximumDateOfTheQuarter(_view.Year);
                var balances = _service.GenerateBalancesFor(quarterEnd);
                _view.PopulateReports(balances);

                return true;

                //var db = new DataContextFactory().CreateDataContext();

                //var query = db.GetTable<Member>()
                //    .Select(x => new QuarterlyBalance()
                //    {
                //        // member name
                //        Member = 
                //            x.LastName + " " + 
                //            x.FirstName + (
                //            x.MiddleName != null && x.MiddleName != string.Empty 
                //                ? ", " + x.MiddleName
                //                : string.Empty),

                //        // category
                //        Category = x.MembershipCategory.MembershipCategoryName,

                //        // savings deposit
                //        SavingsDepositReceipt = x.SavingsDeposit.SavingsDepositReceipts
                //            .Where(y => y.CashReceipt.ReceiptDate <= quarterEnd)
                //            .Sum(z => z.Amount),
                //        SavingsDepositInterestAdjustment = x.SavingsDeposit.SavingsDepositInterestAdjustments
                //            .Where(y => y.Adjustment.AdjustmentDate <= quarterEnd)
                //            .Sum(z => z.Amount),
                //        SavingsDepositDividendAdjustment = x.SavingsDeposit.SavingsDepositDividendAdjustments
                //            .Where(y => y.Adjustment.AdjustmentDate <= quarterEnd)
                //            .Sum(z => z.Amount),
                //        SavingsDepositDisbursement = x.SavingsDeposit.SavingsDepositDisbursements
                //            .Where(y => y.CashDisbursement.DisbursementDate <= quarterEnd)
                //            .Sum(z => z.Amount),

                //        // capital share
                //        CapitalShareReceipt = x.CapitalShare.CapitalShareReceipts
                //            .Where(y => y.CashReceipt.ReceiptDate <= quarterEnd)
                //            .Sum(z => z.Amount),
                //        CapitalShareDisbursement = x.CapitalShare.CapitalShareDisbursements
                //            .Where(y => y.CashDisbursement.DisbursementDate <= quarterEnd)
                //            .Sum(z => z.Amount),
                //        CapitalShareDividendAdjustment = x.CapitalShare.CapitalShareDividendAdjustments
                //            .Where(y => y.Adjustment.AdjustmentDate <= quarterEnd)
                //            .Sum(z => z.Amount),
                //        CapitalShareInterestRebateAdjustment = x.CapitalShare.CapitalShareInterestRebateAdjustments
                //            .Where(y => y.Adjustment.AdjustmentDate <= quarterEnd)
                //            .Sum(z => z.Amount),
                //        CapitalSharePatronageRefundAdjustment = x.CapitalShare.CapitalSharePatronageRefundAdjustments
                //            .Where(y => y.Adjustment.AdjustmentDate <= quarterEnd)
                //            .Sum(z => z.Amount),

                //        // time deposit
                //        TimeDepositReceipt = x.TimeDeposits
                //            .Where(y => 
                //                //y.DepositDate >= quarterStart && 
                //                y.DepositDate <= quarterEnd && (
                //                y.ConsummationDate != null ? y.ConsummationDate > quarterEnd : true))
                //            .SelectMany(y => y.TimeDepositReceipts)
                //            .Sum(y => y.Amount),
                //        TimeDepositDisbursement = x.TimeDeposits
                //            .Where(y =>
                //                //y.DepositDate >= quarterStart &&
                //                y.DepositDate <= quarterEnd && (
                //                y.ConsummationDate != null ? y.ConsummationDate > quarterEnd : true))
                //            .SelectMany(y => y.TimeDepositDisbursements)
                //            .Sum(y => y.Amount),

                //        // Appliance Loan
                //        ApplianceLoanTotalPayableAmount = x.Loans
                //            .Where(y =>
                //                y.LoanServiceID == ServiceCodes.ApplianceLoan &&
                //                //y.LoanDate >= quarterStart &&
                //                y.LoanDate <= quarterEnd && (
                //                y.SettlementDate != null ? y.SettlementDate > quarterEnd : true))
                //            .Sum(y => y.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn
                //                ? y.LoanAmount + y.ServiceFee + y.CollectionFee + y.CapitalBuildup + y.LoanGuaranteeFund + y.Interest
                //                : y.LoanAmount),
                //        ApplianceLoanReceipt = x.Loans
                //            .Where(y =>
                //                y.LoanServiceID == ServiceCodes.ApplianceLoan &&
                //                //y.LoanDate >= quarterStart &&
                //                y.LoanDate <= quarterEnd && (
                //                y.SettlementDate != null ? y.SettlementDate > quarterEnd : true))
                //            .SelectMany(y => y.LoanReceipts)
                //            .Sum(y => y.Amount),
                //        ApplianceLoanDividendAdjustment = x.Loans
                //            .Where(y =>
                //                y.LoanServiceID == ServiceCodes.ApplianceLoan &&
                //                //y.LoanDate >= quarterStart &&
                //                y.LoanDate <= quarterEnd && (
                //                y.SettlementDate != null ? y.SettlementDate > quarterEnd : true))
                //            .SelectMany(y => y.LoanDividendAdjustments)
                //            .Sum(y => y.Amount),

                //        // Easy Loan
                //        EasyLoanTotalPayableAmount = x.Loans
                //            .Where(y =>
                //                y.LoanServiceID == ServiceCodes.EasyLoan &&
                //                //y.LoanDate >= quarterStart &&
                //                y.LoanDate <= quarterEnd && (
                //                y.SettlementDate != null ? y.SettlementDate > quarterEnd : true))
                //            .Sum(y => y.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn
                //                ? y.LoanAmount + y.ServiceFee + y.CollectionFee + y.CapitalBuildup + y.LoanGuaranteeFund + y.Interest
                //                : y.LoanAmount),
                //        EasyLoanReceipt = x.Loans
                //            .Where(y =>
                //                y.LoanServiceID == ServiceCodes.EasyLoan &&
                //                //y.LoanDate >= quarterStart &&
                //                y.LoanDate <= quarterEnd && (
                //                y.SettlementDate != null ? y.SettlementDate > quarterEnd : true))
                //            .SelectMany(y => y.LoanReceipts)
                //            .Sum(y => y.Amount),
                //        EasyLoanDividendAdjustment = x.Loans
                //            .Where(y =>
                //                y.LoanServiceID == ServiceCodes.EasyLoan &&
                //                //y.LoanDate >= quarterStart &&
                //                y.LoanDate <= quarterEnd && (
                //                y.SettlementDate != null ? y.SettlementDate > quarterEnd : true))
                //            .SelectMany(y => y.LoanDividendAdjustments)
                //            .Sum(y => y.Amount),
                            
                //        // Emergency Loan
                //        EmergencyLoanTotalPayableAmount = x.Loans
                //            .Where(y =>
                //                y.LoanServiceID == ServiceCodes.EmergencyLoan &&
                //                //y.LoanDate >= quarterStart &&
                //                y.LoanDate <= quarterEnd && (
                //                y.SettlementDate != null ? y.SettlementDate > quarterEnd : true))
                //            .Sum(y => y.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn
                //                ? y.LoanAmount + y.ServiceFee + y.CollectionFee + y.CapitalBuildup + y.LoanGuaranteeFund + y.Interest
                //                : y.LoanAmount),
                //        EmergencyLoanReceipt = x.Loans
                //            .Where(y =>
                //                y.LoanServiceID == ServiceCodes.EmergencyLoan &&
                //                //y.LoanDate >= quarterStart &&
                //                y.LoanDate <= quarterEnd && (
                //                y.SettlementDate != null ? y.SettlementDate > quarterEnd : true))
                //            .SelectMany(y => y.LoanReceipts)
                //            .Sum(y => y.Amount),
                //        EmergencyLoanDividendAdjustment = x.Loans
                //            .Where(y =>
                //                y.LoanServiceID == ServiceCodes.EmergencyLoan &&
                //                //y.LoanDate >= quarterStart &&
                //                y.LoanDate <= quarterEnd && (
                //                y.SettlementDate != null ? y.SettlementDate > quarterEnd : true))
                //            .SelectMany(y => y.LoanDividendAdjustments)
                //            .Sum(y => y.Amount),

                //        // Equity Loan
                //        EquityLoanTotalPayableAmount = x.Loans
                //            .Where(y =>
                //                y.LoanServiceID == ServiceCodes.EquityLoan &&
                //                //y.LoanDate >= quarterStart && 
                //                y.LoanDate <= quarterEnd && (
                //                y.SettlementDate != null ? y.SettlementDate > quarterEnd : true))
                //            .Sum(y => y.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn
                //                ? y.LoanAmount + y.ServiceFee + y.CollectionFee + y.CapitalBuildup + y.LoanGuaranteeFund + y.Interest
                //                : y.LoanAmount),
                //        EquityLoanReceipt = x.Loans
                //            .Where(y =>
                //                y.LoanServiceID == ServiceCodes.EquityLoan &&
                //                //y.LoanDate >= quarterStart &&
                //                y.LoanDate <= quarterEnd && (
                //                y.SettlementDate != null ? y.SettlementDate > quarterEnd : true))
                //            .SelectMany(y => y.LoanReceipts)
                //            .Sum(y => y.Amount),
                //        EquityLoanDividendAdjustment = x.Loans
                //            .Where(y =>
                //                y.LoanServiceID == ServiceCodes.EquityLoan &&
                //                //y.LoanDate >= quarterStart &&
                //                y.LoanDate <= quarterEnd && (
                //                y.SettlementDate != null ? y.SettlementDate > quarterEnd : true))
                //            .SelectMany(y => y.LoanDividendAdjustments)
                //            .Sum(y => y.Amount),

                //        // Pension Loan
                //        PensionLoanTotalPayableAmount = x.Loans
                //            .Where(y =>
                //                y.LoanServiceID == ServiceCodes.PensionLoan &&
                //                //y.LoanDate >= quarterStart &&
                //                y.LoanDate <= quarterEnd && (
                //                y.SettlementDate != null ? y.SettlementDate > quarterEnd : true))
                //            .Sum(y => y.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn
                //                ? y.LoanAmount + y.ServiceFee + y.CollectionFee + y.CapitalBuildup + y.LoanGuaranteeFund + y.Interest
                //                : y.LoanAmount),
                //        PensionLoanReceipt = x.Loans
                //            .Where(y =>
                //                y.LoanServiceID == ServiceCodes.PensionLoan &&
                //                //y.LoanDate >= quarterStart &&
                //                y.LoanDate <= quarterEnd && (
                //                y.SettlementDate != null ? y.SettlementDate > quarterEnd : true))
                //            .SelectMany(y => y.LoanReceipts)
                //            .Sum(y => y.Amount),
                //        PensionLoanDividendAdjustment = x.Loans
                //            .Where(y =>
                //                y.LoanServiceID == ServiceCodes.PensionLoan &&
                //                //y.LoanDate >= quarterStart &&
                //                y.LoanDate <= quarterEnd && (
                //                y.SettlementDate != null ? y.SettlementDate > quarterEnd : true))
                //            .SelectMany(y => y.LoanDividendAdjustments)
                //            .Sum(y => y.Amount),

                //        // Regular Loan
                //        RegularLoanTotalPayableAmount = x.Loans
                //            .Where(y =>
                //                y.LoanServiceID == ServiceCodes.RegularLoan &&
                //                //y.LoanDate >= quarterStart &&
                //                y.LoanDate <= quarterEnd && (
                //                y.SettlementDate != null ? y.SettlementDate > quarterEnd : true))
                //            .Sum(y => y.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn
                //                ? y.LoanAmount + y.ServiceFee + y.CollectionFee + y.CapitalBuildup + y.LoanGuaranteeFund + y.Interest
                //                : y.LoanAmount),
                //        RegularLoanReceipt = x.Loans
                //            .Where(y =>
                //                y.LoanServiceID == ServiceCodes.RegularLoan &&
                //                //y.LoanDate >= quarterStart &&
                //                y.LoanDate <= quarterEnd && (
                //                y.SettlementDate != null ? y.SettlementDate > quarterEnd : true))
                //            .SelectMany(y => y.LoanReceipts)
                //            .Sum(y => y.Amount),
                //        RegularLoanDividendAdjustment = x.Loans
                //            .Where(y =>
                //                y.LoanServiceID == ServiceCodes.RegularLoan &&
                //                //y.LoanDate >= quarterStart &&
                //                y.LoanDate <= quarterEnd && (
                //                y.SettlementDate != null ? y.SettlementDate > quarterEnd : true))
                //            .SelectMany(y => y.LoanDividendAdjustments)
                //            .Sum(y => y.Amount),

                //        // pension plan
                //        PensionPlanReceipt = x.PensionPlan.PensionPlanReceipts
                //            .Where(y =>
                //                //y.PensionPlan.ApplicationDate >= quarterStart &&
                //                y.PensionPlan.ApplicationDate <= quarterEnd && (
                //                y.PensionPlan.ConsummationDate != null ? y.PensionPlan.ConsummationDate > quarterEnd : true))
                //            .Sum(y => y.Amount),
                //        PensionPlanInterestAdjustment = x.PensionPlan.PensionPlanInterestAdjustments
                //            .Where(y =>
                //                //y.PensionPlan.ApplicationDate >= quarterStart &&
                //                y.PensionPlan.ApplicationDate <= quarterEnd && (
                //                y.PensionPlan.ConsummationDate != null ? y.PensionPlan.ConsummationDate > quarterEnd : true))
                //            .Sum(y => y.Amount),
                //        PensionPlanDisbursement = x.PensionPlan.PensionPlanDisbursements
                //            .Where(y =>
                //                //y.PensionPlan.ApplicationDate >= quarterStart &&
                //                y.PensionPlan.ApplicationDate <= quarterEnd && (
                //                y.PensionPlan.ConsummationDate != null ? y.PensionPlan.ConsummationDate > quarterEnd : true))
                //            .Sum(y => y.Amount),

                //        // college insurance plan 
                //        CollegeInsurancePlanReceipt = x.CollegeInsurancePlans
                //            .Where(y =>
                //                //y.ApplicationDate >= quarterStart &&
                //                y.ApplicationDate <= quarterEnd && (
                //                y.ConsummationDate != null ? y.ConsummationDate > quarterEnd : true))
                //            .SelectMany(y => y.CollegeInsurancePlanReceipts)
                //            .Sum(y => y.Amount),
                //        CollegeInsurancePlanDisbursement = x.CollegeInsurancePlans
                //            .Where(y =>
                //                //y.ApplicationDate >= quarterStart &&
                //                y.ApplicationDate <= quarterEnd && (
                //                y.ConsummationDate != null ? y.ConsummationDate > quarterEnd : true))
                //            .SelectMany(y => y.CollegeInsurancePlanDisbursements)
                //            .Sum(y => y.Amount),

                //        // death aid fund
                //        DeathAidFundReceipt = x.DeathAidFund.DeathAidFundReceipts
                //            .Where(y => y.CashReceipt.ReceiptDate <= quarterEnd)
                //            .Sum(y => y.Amount),
                //        DeathAidFundDisbursement = x.DeathAidFund.DeathAidFundDisbursements
                //            .Where(y => y.CashDisbursement.DisbursementDate <= quarterEnd)
                //            .Sum(y => y.Amount),

                //        // tulungan fund
                //        TulunganFundReceipt = x.TulunganFund.TulunganFundReceipts
                //            .Where(y => y.CashReceipt.ReceiptDate <= quarterEnd)
                //            .Sum(y => y.Amount),
                //        TulunganFundDisbursement = x.TulunganFund.TulunganFundDisbursements
                //            .Where(y => y.CashDisbursement.DisbursementDate <= quarterEnd)
                //            .Sum(y => y.Amount)
                //    })
                //    .OrderBy(x => x.Member);

                //_view.PopulateReports(query.ToList());
                //return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }
    }
}
