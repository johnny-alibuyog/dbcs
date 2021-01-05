using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.AccountStatuses;
using CooperativeSystem.Service.Presenters.Lookups.DeductionTypes;
using CooperativeSystem.Service.Presenters.Lookups.Services;

namespace CooperativeSystem.Service.Presenters.Reports.MemberPeriodicalBalanceSummaries
{
    internal class PeriodicalBalanceService : CooperativeSystem.Service.Presenters.Reports.MemberPeriodicalBalanceSummaries.IPeriodicalBalanceService
    {
        public IList<PeriodicalBalance> GenerateBalancesFor(DateTime cutOffDate)
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();

                var query = db.GetTable<Member>()
                    .Where(x => x.AccountStatusID == AccountStatusCodes.Active)
                    .Select(x => new PeriodicalBalance()
                    {
                        // member name
                        Member =
                            x.LastName + " " +
                            x.FirstName + (
                            x.MiddleName != null && x.MiddleName != string.Empty
                                ? ", " + x.MiddleName
                                : string.Empty),

                        // category
                        Category = x.MembershipCategory.MembershipCategoryName,

                        // savings deposit
                        SavingsDepositReceipt = x.SavingsDeposit.SavingsDepositReceipts
                            .Where(y => y.CashReceipt.ReceiptDate <= cutOffDate)
                            .Sum(z => z.Amount),
                        SavingsDepositAdjustment = x.SavingsDeposit.SavingsDepositAdjustments
                            .Where(y => y.Adjustment.AdjustmentDate <= cutOffDate)
                            .Sum(z => z.Amount),
                        SavingsDepositInterestAdjustment = x.SavingsDeposit.SavingsDepositInterestAdjustments
                            .Where(y => y.Adjustment.AdjustmentDate <= cutOffDate)
                            .Sum(z => z.Amount),
                        SavingsDepositDividendAdjustment = x.SavingsDeposit.SavingsDepositDividendAdjustments
                            .Where(y => y.Adjustment.AdjustmentDate <= cutOffDate)
                            .Sum(z => z.Amount),
                        SavingsDepositDisbursement = x.SavingsDeposit.SavingsDepositDisbursements
                            .Where(y => y.CashDisbursement.DisbursementDate <= cutOffDate)
                            .Sum(z => z.Amount),

                        // capital share
                        CapitalShareReceipt = x.CapitalShare.CapitalShareReceipts
                            .Where(y => y.CashReceipt.ReceiptDate <= cutOffDate)
                            .Sum(z => z.Amount),
                        CapitalShareAdjustment = x.CapitalShare.CapitalShareAdjustments
                            .Where(y => y.Adjustment.AdjustmentDate <= cutOffDate)
                            .Sum(z => z.Amount),
                        CapitalShareBuildup = x.CapitalShare.CapitalShareBuildups
                            .Where(y => y.CashDisbursement.DisbursementDate <= cutOffDate)
                            .Sum(z => z.Amount),
                        CapitalShareDisbursement = x.CapitalShare.CapitalShareDisbursements
                            .Where(y => y.CashDisbursement.DisbursementDate <= cutOffDate)
                            .Sum(z => z.Amount),
                        CapitalShareDividendAdjustment = x.CapitalShare.CapitalShareDividendAdjustments
                            .Where(y => y.Adjustment.AdjustmentDate <= cutOffDate)
                            .Sum(z => z.Amount),
                        CapitalShareInterestRebateAdjustment = x.CapitalShare.CapitalShareInterestRebateAdjustments
                            .Where(y => y.Adjustment.AdjustmentDate <= cutOffDate)
                            .Sum(z => z.Amount),
                        CapitalSharePatronageRefundAdjustment = x.CapitalShare.CapitalSharePatronageRefundAdjustments
                            .Where(y => y.Adjustment.AdjustmentDate <= cutOffDate)
                            .Sum(z => z.Amount),

                        // time deposit
                        TimeDepositInterest =  x.TimeDeposits
                            .Sum(y => y.Interest),
                        TimeDepositReceipt = x.TimeDeposits
                            .SelectMany(y => y.TimeDepositReceipts)
                            .Where(y =>
                                y.CashReceipt.ReceiptDate <= cutOffDate && (
                                y.TimeDeposit.ConsummationDate != null ? y.TimeDeposit.ConsummationDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        TimeDepositAdjustment = x.TimeDeposits
                            .SelectMany(y => y.TimeDepositAdjustments)
                            .Where(y =>
                                y.Adjustment.AdjustmentDate <= cutOffDate && (
                                y.TimeDeposit.ConsummationDate != null ? y.TimeDeposit.ConsummationDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        TimeDepositDisbursement = x.TimeDeposits
                            .SelectMany(y => y.TimeDepositDisbursements)
                            .Where(y =>
                                y.CashDisbursement.DisbursementDate <= cutOffDate && (
                                y.TimeDeposit.ConsummationDate != null ? y.TimeDeposit.ConsummationDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),

                        // Appliance Loan
                        ApplianceLoanTotalPayableAmount = x.Loans
                            .Where(y =>
                                y.LoanDate <= cutOffDate &&
                                y.LoanServiceID == ServiceCodes.ApplianceLoan && (
                                y.SettlementDate != null ? y.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn
                                ? y.LoanAmount + y.ServiceFee + y.CollectionFee + y.CapitalBuildup + y.LoanGuaranteeFund + y.Interest
                                : y.LoanAmount
                            ),
                        ApplianceLoanReceipt = x.Loans
                            .SelectMany(y => y.LoanReceipts)
                            .Where(y =>
                                y.CashReceipt.ReceiptDate <= cutOffDate &&
                                y.Loan.LoanServiceID == ServiceCodes.ApplianceLoan && (
                                y.Loan.SettlementDate != null ? y.Loan.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        ApplianceLoanAdjustment = x.Loans
                            .SelectMany(y => y.LoanAdjustments)
                            .Where(y =>
                                y.Adjustment.AdjustmentDate <= cutOffDate &&
                                y.Loan.LoanServiceID == ServiceCodes.ApplianceLoan && (
                                y.Loan.SettlementDate != null ? y.Loan.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        ApplianceLoanDividendAdjustment = x.Loans
                            .SelectMany(y => y.LoanDividendAdjustments)
                            .Where(y =>
                                y.Adjustment.AdjustmentDate <= cutOffDate &&
                                y.Loan.LoanServiceID == ServiceCodes.ApplianceLoan && (
                                y.Loan.SettlementDate != null ? y.Loan.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),

                        // Easy Loan
                        EasyLoanTotalPayableAmount = x.Loans
                            .Where(y =>
                                y.LoanDate <= cutOffDate &&
                                y.LoanServiceID == ServiceCodes.EasyLoan && (
                                y.SettlementDate != null ? y.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn
                                ? y.LoanAmount + y.ServiceFee + y.CollectionFee + y.CapitalBuildup + y.LoanGuaranteeFund + y.Interest
                                : y.LoanAmount
                            ),
                        EasyLoanReceipt = x.Loans
                            .SelectMany(y => y.LoanReceipts)
                            .Where(y =>
                                y.CashReceipt.ReceiptDate <= cutOffDate &&
                                y.Loan.LoanServiceID == ServiceCodes.EasyLoan && (
                                y.Loan.SettlementDate != null ? y.Loan.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        EasyLoanAdjustment = x.Loans
                            .SelectMany(y => y.LoanAdjustments)
                            .Where(y =>
                                y.Adjustment.AdjustmentDate <= cutOffDate &&
                                y.Loan.LoanServiceID == ServiceCodes.EasyLoan && (
                                y.Loan.SettlementDate != null ? y.Loan.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        EasyLoanDividendAdjustment = x.Loans
                            .SelectMany(y => y.LoanDividendAdjustments)
                            .Where(y =>
                                y.Adjustment.AdjustmentDate <= cutOffDate &&
                                y.Loan.LoanServiceID == ServiceCodes.EasyLoan && (
                                y.Loan.SettlementDate != null ? y.Loan.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),

                        // Emergency Loan
                        EmergencyLoanTotalPayableAmount = x.Loans
                            .Where(y =>
                                y.LoanDate <= cutOffDate &&
                                y.LoanServiceID == ServiceCodes.EmergencyLoan && (
                                y.SettlementDate != null ? y.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn
                                ? y.LoanAmount + y.ServiceFee + y.CollectionFee + y.CapitalBuildup + y.LoanGuaranteeFund + y.Interest
                                : y.LoanAmount
                            ),
                        EmergencyLoanReceipt = x.Loans
                            .SelectMany(y => y.LoanReceipts)
                            .Where(y =>
                                y.CashReceipt.ReceiptDate <= cutOffDate &&
                                y.Loan.LoanServiceID == ServiceCodes.EmergencyLoan && (
                                y.Loan.SettlementDate != null ? y.Loan.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        EmergencyLoanAdjustment = x.Loans
                            .SelectMany(y => y.LoanAdjustments)
                            .Where(y =>
                                y.Adjustment.AdjustmentDate <= cutOffDate &&
                                y.Loan.LoanServiceID == ServiceCodes.EmergencyLoan && (
                                y.Loan.SettlementDate != null ? y.Loan.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        EmergencyLoanDividendAdjustment = x.Loans
                            .SelectMany(y => y.LoanDividendAdjustments)
                            .Where(y =>
                                y.Adjustment.AdjustmentDate <= cutOffDate &&
                                y.Loan.LoanServiceID == ServiceCodes.EmergencyLoan && (
                                y.Loan.SettlementDate != null ? y.Loan.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),

                        // Equity Loan
                        EquityLoanTotalPayableAmount = x.Loans
                            .Where(y =>
                                y.LoanDate <= cutOffDate &&
                                y.LoanServiceID == ServiceCodes.EquityLoan && (
                                y.SettlementDate != null ? y.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn
                                ? y.LoanAmount + y.ServiceFee + y.CollectionFee + y.CapitalBuildup + y.LoanGuaranteeFund + y.Interest
                                : y.LoanAmount
                            ),
                        EquityLoanReceipt = x.Loans
                            .SelectMany(y => y.LoanReceipts)
                            .Where(y =>
                                y.CashReceipt.ReceiptDate <= cutOffDate && 
                                y.Loan.LoanServiceID == ServiceCodes.EquityLoan &&(
                                y.Loan.SettlementDate != null ? y.Loan.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        EquityLoanAdjustment = x.Loans
                            .SelectMany(y => y.LoanAdjustments)
                            .Where(y =>
                                y.Adjustment.AdjustmentDate <= cutOffDate &&
                                y.Loan.LoanServiceID == ServiceCodes.EquityLoan && (
                                y.Loan.SettlementDate != null ? y.Loan.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        EquityLoanDividendAdjustment = x.Loans
                            .SelectMany(y => y.LoanDividendAdjustments)
                            .Where(y =>
                                y.Adjustment.AdjustmentDate <= cutOffDate && 
                                y.Loan.LoanServiceID == ServiceCodes.EquityLoan && (
                                y.Loan.SettlementDate != null ? y.Loan.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),

                        // Pension Loan
                        PensionLoanTotalPayableAmount = x.Loans
                            .Where(y =>
                                y.LoanDate <= cutOffDate &&
                                y.LoanServiceID == ServiceCodes.PensionLoan && (
                                y.SettlementDate != null ? y.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn
                                ? y.LoanAmount + y.ServiceFee + y.CollectionFee + y.CapitalBuildup + y.LoanGuaranteeFund + y.Interest
                                : y.LoanAmount
                            ),
                        PensionLoanReceipt = x.Loans
                            .SelectMany(y => y.LoanReceipts)
                            .Where(y =>
                                y.CashReceipt.ReceiptDate <= cutOffDate && 
                                y.Loan.LoanServiceID == ServiceCodes.PensionLoan &&(
                                y.Loan.SettlementDate != null ? y.Loan.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        PensionLoanAdjustment = x.Loans
                            .SelectMany(y => y.LoanAdjustments)
                            .Where(y =>
                                y.Adjustment.AdjustmentDate <= cutOffDate &&
                                y.Loan.LoanServiceID == ServiceCodes.PensionLoan && (
                                y.Loan.SettlementDate != null ? y.Loan.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        PensionLoanDividendAdjustment = x.Loans
                            .SelectMany(y => y.LoanDividendAdjustments)
                            .Where(y =>
                                y.Adjustment.AdjustmentDate <= cutOffDate && 
                                y.Loan.LoanServiceID == ServiceCodes.PensionLoan &&(
                                y.Loan.SettlementDate != null ? y.Loan.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),

                        // Regular Loan
                        RegularLoanTotalPayableAmount = x.Loans
                            .Where(y =>
                                y.LoanDate <= cutOffDate &&
                                y.LoanServiceID == ServiceCodes.RegularLoan && (
                                y.SettlementDate != null ? y.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn
                                ? y.LoanAmount + y.ServiceFee + y.CollectionFee + y.CapitalBuildup + y.LoanGuaranteeFund + y.Interest
                                : y.LoanAmount
                            ),
                        RegularLoanReceipt = x.Loans
                            .SelectMany(y => y.LoanReceipts)
                            .Where(y =>
                                y.CashReceipt.ReceiptDate <= cutOffDate &&
                                y.Loan.LoanServiceID == ServiceCodes.RegularLoan && (
                                y.Loan.SettlementDate != null ? y.Loan.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        RegularLoanAdjustment = x.Loans
                            .SelectMany(y => y.LoanAdjustments)
                            .Where(y =>
                                y.Adjustment.AdjustmentDate <= cutOffDate &&
                                y.Loan.LoanServiceID == ServiceCodes.RegularLoan && (
                                y.Loan.SettlementDate != null ? y.Loan.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        RegularLoanDividendAdjustment = x.Loans
                            .SelectMany(y => y.LoanDividendAdjustments)
                            .Where(y =>
                                y.Adjustment.AdjustmentDate <= cutOffDate &&
                                y.Loan.LoanServiceID == ServiceCodes.RegularLoan && (
                                y.Loan.SettlementDate != null ? y.Loan.SettlementDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),

                        // pension plan
                        PensionPlanReceipt = x.PensionPlan.PensionPlanReceipts
                            .Where(y =>
                                y.CashReceipt.ReceiptDate <= cutOffDate && (
                                y.PensionPlan.ConsummationDate != null ? y.PensionPlan.ConsummationDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        PensionPlanAdjustment = x.PensionPlan.PensionPlanAdjustments
                            .Where(y =>
                                y.Adjustment.AdjustmentDate <= cutOffDate && (
                                y.PensionPlan.ConsummationDate != null ? y.PensionPlan.ConsummationDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        PensionPlanInterestAdjustment = x.PensionPlan.PensionPlanInterestAdjustments
                            .Where(y =>
                                y.Adjustment.AdjustmentDate <= cutOffDate && (
                                y.PensionPlan.ConsummationDate != null ? y.PensionPlan.ConsummationDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        PensionPlanDisbursement = x.PensionPlan.PensionPlanDisbursements
                            .Where(y =>
                                y.CashDisbursement.DisbursementDate <= cutOffDate && (
                                y.PensionPlan.ConsummationDate != null ? y.PensionPlan.ConsummationDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),

                        // college insurance plan 
                        CollegeInsurancePlanReceipt = x.CollegeInsurancePlans
                            .SelectMany(y => y.CollegeInsurancePlanReceipts)
                            .Where(y =>
                                y.CashReceipt.ReceiptDate <= cutOffDate && (
                                y.CollegeInsurancePlan.ConsummationDate != null ? y.CollegeInsurancePlan.ConsummationDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        CollegeInsurancePlanAdjustment = x.CollegeInsurancePlans
                            .SelectMany(y => y.CollegeInsurancePlanAdjustments)
                            .Where(y =>
                                y.Adjustment.AdjustmentDate <= cutOffDate && (
                                y.CollegeInsurancePlan.ConsummationDate != null ? y.CollegeInsurancePlan.ConsummationDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),
                        CollegeInsurancePlanDisbursement = x.CollegeInsurancePlans
                            .SelectMany(y => y.CollegeInsurancePlanDisbursements)
                            .Where(y =>
                                y.CashDisbursement.DisbursementDate <= cutOffDate && (
                                y.CollegeInsurancePlan.ConsummationDate != null ? y.CollegeInsurancePlan.ConsummationDate > cutOffDate : true)
                            )
                            .Sum(y => y.Amount),

                        // death aid fund
                        DeathAidFundReceipt = x.DeathAidFund.DeathAidFundReceipts
                            .Where(y => y.CashReceipt.ReceiptDate <= cutOffDate)
                            .Sum(y => y.Amount),
                        DeathAidFundDisbursement = x.DeathAidFund.DeathAidFundDisbursements
                            .Where(y => y.CashDisbursement.DisbursementDate <= cutOffDate)
                            .Sum(y => y.Amount),

                        // tulungan fund
                        TulunganFundReceipt = x.TulunganFund.TulunganFundReceipts
                            .Where(y => y.CashReceipt.ReceiptDate <= cutOffDate)
                            .Sum(y => y.Amount),
                        TulunganFundAdjustment = x.TulunganFund.TulunganFundAdjustments
                            .Where(y => y.Adjustment.AdjustmentDate <= cutOffDate)
                            .Sum(y => y.Amount),
                        TulunganFundDisbursement = x.TulunganFund.TulunganFundDisbursements
                            .Where(y => y.CashDisbursement.DisbursementDate <= cutOffDate)
                            .Sum(y => y.Amount)
                    })
                    .OrderBy(x => x.Member);

                return query.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
