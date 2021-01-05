using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Presenters.Lookups.DeductionTypes;
using CooperativeSystem.Service.Presenters.Lookups.Services;

namespace CooperativeSystem.Service.Presenters.Reports.IndividualLedgersRevision
{
    public class IndividualLedgerRevisionPresenter : PresenterTemplate
    {
        private IIndividualLedgerRevisionView _view;

        public IndividualLedgerRevisionPresenter(IIndividualLedgerRevisionView view)
        {
            _view = view;
        }

        public bool PopulateMemberLookup()
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();
                var query = db.GetTable<Member>()
                    .Where(m => m.MembershipCategoryID == _view.MembershipCategoryID)
                    .Select(m => new MemberLookupModel()
                    {
                        AccountNumber = m.AccountNumber,
                        Name = m.LastName + ", " + m.FirstName + " " + m.MiddleName
                    })
                    .OrderBy(m => m.Name);

                _view.PopulateMemberLookup(query.ToList());
                _view.SelectedAccountNumber = null;
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool PopulateReports()
        {
            try
            {
                if (_view.FilterType == FilterType.ByMember && string.IsNullOrEmpty(_view.SelectedAccountNumber))
                    throw new Exception("You must select a member.");

                //var loadOptions = new DataLoadOptions();
                //loadOptions.LoadWith<Loan>(l => l.LoanDisbursements);
                //loadOptions.LoadWith<Loan>(l => l.LoanReceipts);
                //loadOptions.LoadWith<Loan>(l => l.LatePaymentFineReceipts);
                //loadOptions.LoadWith<Loan>(l => l.DelinquentFineReceipts);

                //loadOptions.LoadWith<LoanDisbursement>(d => d.CashDisbursement);
                //loadOptions.LoadWith<LoanReceipt>(r => r.CashReceipt);
                //loadOptions.LoadWith<LatePaymentFineReceipt>(r => r.CashReceipt);
                //loadOptions.LoadWith<DelinquentFineReceipt>(r => r.CashReceipt);

                var db = new DataContextFactory().CreateDataContext();
                //db.LoadOptions = loadOptions;

                var serviceTable = db.GetTable<CooperativeSystem.Service.Models.Service>();

                var accountNumber = _view.SelectedAccountNumber ?? string.Empty;
                var membershipCategoryID = _view.MembershipCategoryID ?? string.Empty;

                var capitalShareQuery = db.GetTable<CapitalShareReceipt>()
                    .Where(x =>
                        x.CapitalShare.Member.AccountNumber.StartsWith(accountNumber) &&
                        x.CapitalShare.Member.MembershipCategoryID.Equals(membershipCategoryID))
                    .Select(x => new Account()
                    {
                        Member = x.CapitalShare.Member.LastName + ", " + x.CapitalShare.Member.FirstName + " " + x.CapitalShare.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.CapitalShare).ServiceName,
                        Date = x.CashReceipt.ReceiptDate,
                        TransactionType = "Receipt",
                        ORJVNumber = x.CashReceipt.OfficialReceiptNumber,
                        Amount = x.Amount,
                        Balance = x.Balance,
                    })
                    .Concat(db.GetTable<CapitalShareBuildup>()
                    .Where(x =>
                        x.CapitalShare.Member.AccountNumber.StartsWith(accountNumber) &&
                        x.CapitalShare.Member.MembershipCategoryID.Equals(membershipCategoryID))
                    .Select(x => new Account()
                    {
                        Member = x.CapitalShare.Member.LastName + ", " + x.CapitalShare.Member.FirstName + " " + x.CapitalShare.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.CapitalShare).ServiceName,
                        Date = x.CashDisbursement.DisbursementDate,
                        TransactionType = "Buildup",
                        ORJVNumber = x.CashDisbursement.CashDisbursementVoucher,
                        Amount = x.Amount,
                        Balance = x.Balance,
                    }))
                    .Concat(db.GetTable<CapitalShareDisbursement>()
                    .Where(x =>
                        x.CapitalShare.Member.AccountNumber.StartsWith(accountNumber) &&
                        x.CapitalShare.Member.MembershipCategoryID.Equals(membershipCategoryID))
                    .Select(x => new Account()
                    {
                        Member = x.CapitalShare.Member.LastName + ", " + x.CapitalShare.Member.FirstName + " " + x.CapitalShare.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.CapitalShare).ServiceName,
                        Date = x.CashDisbursement.DisbursementDate,
                        TransactionType = "Disbursement",
                        ORJVNumber = x.CashDisbursement.CashDisbursementVoucher,
                        Amount = x.Amount,
                        Balance = x.Balance,
                    }))
                    .Concat(db.GetTable<CapitalShareDividendAdjustment>()
                    .Where(x =>
                        x.CapitalShare.Member.AccountNumber.StartsWith(accountNumber) &&
                        x.CapitalShare.Member.MembershipCategoryID.Equals(membershipCategoryID))
                    .Select(x => new Account()
                    {
                        Member = x.CapitalShare.Member.LastName + ", " + x.CapitalShare.Member.FirstName + " " + x.CapitalShare.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.CapitalShare).ServiceName,
                        Date = x.Adjustment.AdjustmentDate,
                        TransactionType = "Dividend",
                        ORJVNumber = x.Adjustment.AdjustmentJournalVoucher,
                        Amount = x.Amount,
                        Balance = x.Balance,
                    }))
                    .Concat(db.GetTable<CapitalShareInterestRebateAdjustment>()
                    .Where(x =>
                        x.CapitalShare.Member.AccountNumber.StartsWith(accountNumber) &&
                        x.CapitalShare.Member.MembershipCategoryID.Equals(membershipCategoryID))
                    .Select(x => new Account()
                    {
                        Member = x.CapitalShare.Member.LastName + ", " + x.CapitalShare.Member.FirstName + " " + x.CapitalShare.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.CapitalShare).ServiceName,
                        Date = x.Adjustment.AdjustmentDate,
                        TransactionType = "Interest Rebate",
                        ORJVNumber = x.Adjustment.AdjustmentJournalVoucher,
                        Amount = x.Amount,
                        Balance = x.Balance,
                    })).Concat(db.GetTable<CapitalSharePatronageRefundAdjustment>()
                    .Where(x =>
                        x.CapitalShare.Member.AccountNumber.StartsWith(accountNumber) &&
                        x.CapitalShare.Member.MembershipCategoryID.Equals(membershipCategoryID))
                    .Select(x => new Account()
                    {
                        Member = x.CapitalShare.Member.LastName + ", " + x.CapitalShare.Member.FirstName + " " + x.CapitalShare.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.CapitalShare).ServiceName,
                        Date = x.Adjustment.AdjustmentDate,
                        TransactionType = "Patronage Refund",
                        ORJVNumber = x.Adjustment.AdjustmentJournalVoucher,
                        Amount = x.Amount,
                        Balance = x.Balance,
                    }));

                var savingsDepositQuery = db.GetTable<SavingsDepositReceipt>()
                    .Where(x => 
                        x.SavingsDeposit.Member.AccountNumber.StartsWith(accountNumber) &&
                        x.SavingsDeposit.Member.MembershipCategoryID.Equals(membershipCategoryID))
                    .Select(x => new Account()
                    {
                        Member = x.SavingsDeposit.Member.LastName + ", " + x.SavingsDeposit.Member.FirstName + " " + x.SavingsDeposit.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.SavingsDeposit).ServiceName,
                        Date = x.CashReceipt.ReceiptDate,
                        TransactionType = "Receipt",
                        ORJVNumber = x.CashReceipt.OfficialReceiptNumber,
                        Amount = x.Amount,
                        Balance = x.Balance,
                    })
                    .Concat(db.GetTable<SavingsDepositDisbursement>()
                    .Where(x =>
                        x.SavingsDeposit.Member.AccountNumber.StartsWith(accountNumber) &&
                        x.SavingsDeposit.Member.MembershipCategoryID.Equals(membershipCategoryID))
                    .Select(x => new Account()
                    {
                        Member = x.SavingsDeposit.Member.LastName + ", " + x.SavingsDeposit.Member.FirstName + " " + x.SavingsDeposit.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.SavingsDeposit).ServiceName,
                        Date = x.CashDisbursement.DisbursementDate,
                        TransactionType = "Disbursement",
                        ORJVNumber = x.CashDisbursement.CashDisbursementVoucher,
                        Amount = x.Amount,
                        Balance = x.Balance,
                    }))
                    .Concat(db.GetTable<SavingsDepositInterestAdjustment>()
                    .Where(x => 
                        x.SavingsDeposit.Member.AccountNumber.StartsWith(accountNumber) &&
                        x.SavingsDeposit.Member.MembershipCategoryID.Equals(membershipCategoryID))
                    .Select(x => new Account()
                    {
                        Member = x.SavingsDeposit.Member.LastName + ", " + x.SavingsDeposit.Member.FirstName + " " + x.SavingsDeposit.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.SavingsDeposit).ServiceName,
                        Date = x.Adjustment.AdjustmentDate,
                        TransactionType = "Interest",
                        ORJVNumber = x.Adjustment.AdjustmentJournalVoucher,
                        Amount = x.Amount,
                        Balance = x.Balance,
                    }))
                    .Concat(db.GetTable<SavingsDepositDividendAdjustment>()
                    .Where(x =>
                        x.SavingsDeposit.Member.AccountNumber.StartsWith(accountNumber) &&
                        x.SavingsDeposit.Member.MembershipCategoryID.Equals(membershipCategoryID))
                    .Select(x => new Account()
                    {
                        Member = x.SavingsDeposit.Member.LastName + ", " + x.SavingsDeposit.Member.FirstName + " " + x.SavingsDeposit.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.SavingsDeposit).ServiceName,
                        Date = x.Adjustment.AdjustmentDate,
                        TransactionType = "Dividend",
                        ORJVNumber = x.Adjustment.AdjustmentJournalVoucher,
                        Amount = x.Amount,
                        Balance = x.Balance,
                    }));

                var timeDepositBalance = db.GetTable<TimeDepositReceipt>()
                    .Where(x =>
                        x.TimeDeposit.Consumed == false &&
                        x.TimeDeposit.Member.AccountNumber.StartsWith(accountNumber) &&
                        x.TimeDeposit.Member.MembershipCategoryID.Equals(membershipCategoryID))
                    .Select(x => new 
                    { 
                        MemberID = x.TimeDeposit.MemberID, 
                        ReceiptDate = x.CashReceipt.ReceiptDate,
                        Amount = x.Amount 
                    });

                var timeDepositQuery = db.GetTable<TimeDepositReceipt>()
                    .Where(x =>
                        x.TimeDeposit.Consumed == false &&
                        x.TimeDeposit.Member.AccountNumber.StartsWith(accountNumber) &&
                        x.TimeDeposit.Member.MembershipCategoryID.Equals(membershipCategoryID))
                    .Select(x => new Account()
                    {
                        Member = x.TimeDeposit.Member.LastName + ", " + x.TimeDeposit.Member.FirstName + " " + x.TimeDeposit.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.TimeDeposit).ServiceName,
                        Date = x.CashReceipt.ReceiptDate,
                        TransactionType = "Receipt",
                        ORJVNumber = x.CashReceipt.OfficialReceiptNumber,
                        Amount = x.Amount,
                        Balance = timeDepositBalance
                            .Where(y =>
                                y.MemberID == x.TimeDeposit.MemberID &&
                                y.ReceiptDate <= x.CashReceipt.ReceiptDate)
                            .Sum(z => z.Amount)
                    });

                var loanAccountsQuery = db.GetTable<LoanReceipt>()
                    .Where(x => 
                        x.Loan.Settled == false &&
                        x.Loan.Member.AccountNumber.StartsWith(accountNumber) &&
                        x.Loan.Member.MembershipCategoryID.Equals(membershipCategoryID))
                    .Select(x => new Account()
                    {
                        Member = x.Loan.Member.LastName + ", " + x.Loan.Member.FirstName + " " + x.Loan.Member.MiddleName,
                        Service = x.Loan.Service.ServiceName + " - " + x.Loan.LoanDate,
                        Date = x.CashReceipt.ReceiptDate,
                        TransactionType = "Receipt",
                        ORJVNumber = x.CashReceipt.OfficialReceiptNumber,
                        Amount = x.Amount,
                        Balance = x.Balance
                    })
                    .Concat(db.GetTable<LoanDividendAdjustment>()
                    .Where(x =>
                        x.Loan.Settled == false &&
                        x.Loan.Member.AccountNumber.StartsWith(accountNumber) &&
                        x.Loan.Member.MembershipCategoryID.Equals(membershipCategoryID))
                    .Select(x => new Account()
                    {
                        Member = x.Loan.Member.LastName + ", " + x.Loan.Member.FirstName + " " + x.Loan.Member.MiddleName,
                        Service = x.Loan.Service.ServiceName + " - " + x.Loan.LoanDate,
                        Date = x.Adjustment.AdjustmentDate,
                        TransactionType = "Dividend",
                        ORJVNumber = x.Adjustment.AdjustmentJournalVoucher,
                        Amount = x.Amount,
                        Balance = x.Balance
                    }))
                    .Concat(db.GetTable<LoanDisbursement>()
                    .Where(x =>
                        x.Loan.Settled == false &&
                        x.Loan.Member.AccountNumber.StartsWith(accountNumber) &&
                        x.Loan.Member.MembershipCategoryID.Equals(membershipCategoryID))
                    .Select(x => new Account()
                    {
                        Member = x.Loan.Member.LastName + ", " + x.Loan.Member.FirstName + " " + x.Loan.Member.MiddleName,
                        Service = x.Loan.Service.ServiceName + " - " + x.Loan.LoanDate,
                        Date = x.CashDisbursement.DisbursementDate,
                        TransactionType = "Disbursement",
                        ORJVNumber = x.CashDisbursement.CashDisbursementVoucher,
                        Amount = 0M, // x.Amount,
                        Balance = (x.Loan.LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn) 
                            ? x.Loan.LoanAmount + x.Loan.ServiceFee + x.Loan.CollectionFee + x.Loan.CapitalBuildup + x.Loan.LoanGuaranteeFund + x.Loan.Interest
                            : x.Loan.LoanAmount // x.Balance,
                    }));

                var accountsQuery = capitalShareQuery
                    .Concat(savingsDepositQuery)
                    .Concat(timeDepositQuery)
                    .Concat(loanAccountsQuery)
                    .OrderBy(sa => sa.Member)
                    .ThenBy(sa => sa.Service)
                    .ThenBy(sa => sa.Date);

                var membershipCategory = db.GetTable<MembershipCategory>()
                    .Single(mc => mc.MembershipCategoryID == membershipCategoryID)
                    .MembershipCategoryName;

                _view.PopulateReports(accountsQuery.ToList(), membershipCategory);
                //_view.PopulateReports(accountsQuery.ToList(), loanAccountsQuery.ToList(), membershipCategory);

                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }
    }
}
