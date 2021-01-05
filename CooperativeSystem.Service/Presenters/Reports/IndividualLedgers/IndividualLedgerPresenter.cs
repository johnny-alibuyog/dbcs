using System;
using System.Data.Linq;
using System.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Presenters.Reports.IndividualLedgers
{
    public class IndividualLedgerPresenter : PresenterTemplate
    {
        private IIndividualLedgerView _view;

        public IndividualLedgerPresenter(IIndividualLedgerView view)
        {
            _view = view;
        }

        public bool PopulateMemberLookup()
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();
                var query = db.GetTable<Member>()
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

                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Loan>(x => x.LoanReceipts);
                loadOptions.LoadWith<Loan>(x => x.LoanAdjustments);
                loadOptions.LoadWith<Loan>(x => x.LoanDividendAdjustments);
                loadOptions.LoadWith<Loan>(x => x.LoanDisbursements);
                loadOptions.LoadWith<Loan>(x => x.LatePaymentFineReceipts);
                loadOptions.LoadWith<Loan>(x => x.DelinquentFineReceipts);

                loadOptions.LoadWith<LoanReceipt>(x => x.CashReceipt);
                loadOptions.LoadWith<LoanAdjustment>(x => x.Adjustment);
                loadOptions.LoadWith<LoanDividendAdjustment>(x => x.Adjustment);
                loadOptions.LoadWith<LoanDisbursement>(x => x.CashDisbursement);
                loadOptions.LoadWith<LatePaymentFineReceipt>(x => x.CashReceipt);
                loadOptions.LoadWith<DelinquentFineReceipt>(x => x.CashReceipt);

                var db = new DataContextFactory().CreateDataContext();
                //db.LoadOptions = loadOptions;

                var serviceTable = db.GetTable<CooperativeSystem.Service.Models.Service>();

                var accountNumber = _view.SelectedAccountNumber ?? string.Empty;
                var membershipCategoryID = _view.MembershipCategoryID ?? string.Empty;

                var capitalShareQuery = (db.GetTable<CapitalShareReceipt>()
                    .Where(r => r.CapitalShare.Member.AccountNumber.StartsWith(accountNumber))
                    .Select(r => new SavingsAccount()
                    {
                        Member = r.CapitalShare.Member.LastName + ", " + r.CapitalShare.Member.FirstName + " " + r.CapitalShare.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.CapitalShare).ServiceName,
                        Date = r.CashReceipt.ReceiptDate,
                        TransationType = "Receipt",
                        ORJVNumber = r.CashReceipt.OfficialReceiptNumber,
                        Amount = r.Amount,
                        Balance = r.Balance,
                    }))
                    .Concat(db.GetTable<CapitalShareBuildup>()
                    .Where(d => d.CapitalShare.Member.AccountNumber.StartsWith(accountNumber))
                    .Select(d => new SavingsAccount()
                    {
                        Member = d.CapitalShare.Member.LastName + ", " + d.CapitalShare.Member.FirstName + " " + d.CapitalShare.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.CapitalShare).ServiceName,
                        Date = d.CashDisbursement.DisbursementDate,
                        TransationType = "Buildup",
                        ORJVNumber = d.CashDisbursement.CashDisbursementVoucher,
                        Amount = d.Amount,
                        Balance = d.Balance,
                    }))
                    .Concat(db.GetTable<CapitalShareDisbursement>()
                    .Where(d => d.CapitalShare.Member.AccountNumber.StartsWith(accountNumber))
                    .Select(d => new SavingsAccount()
                    {
                        Member = d.CapitalShare.Member.LastName + ", " + d.CapitalShare.Member.FirstName + " " + d.CapitalShare.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.CapitalShare).ServiceName,
                        Date = d.CashDisbursement.DisbursementDate,
                        TransationType = "Disbursement",
                        ORJVNumber = d.CashDisbursement.CashDisbursementVoucher,
                        Amount = d.Amount,
                        Balance = d.Balance,
                    }))
                    .Concat(db.GetTable<CapitalShareDividendAdjustment>()
                    .Where(a => a.CapitalShare.Member.AccountNumber.StartsWith(accountNumber))
                    .Select(a => new SavingsAccount()
                    {
                        Member = a.CapitalShare.Member.LastName + ", " + a.CapitalShare.Member.FirstName + " " + a.CapitalShare.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.CapitalShare).ServiceName,
                        Date = a.Adjustment.AdjustmentDate,
                        TransationType = "Dividend",
                        ORJVNumber = a.Adjustment.AdjustmentJournalVoucher,
                        Amount = a.Amount,
                        Balance = a.Balance,
                    }))
                    .Concat(db.GetTable<CapitalSharePatronageRefundAdjustment>()
                    .Where(a => a.CapitalShare.Member.AccountNumber.StartsWith(accountNumber))
                    .Select(a => new SavingsAccount()
                    {
                        Member = a.CapitalShare.Member.LastName + ", " + a.CapitalShare.Member.FirstName + " " + a.CapitalShare.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.CapitalShare).ServiceName,
                        Date = a.Adjustment.AdjustmentDate,
                        TransationType = "Patronage Refund",
                        ORJVNumber = a.Adjustment.AdjustmentJournalVoucher,
                        Amount = a.Amount,
                        Balance = a.Balance,
                    }));

                var savingsDepositQuery = (db.GetTable<SavingsDepositReceipt>()
                    .Where(r => r.SavingsDeposit.Member.AccountNumber.StartsWith(accountNumber))
                    .Select(r => new SavingsAccount()
                    {
                        Member = r.SavingsDeposit.Member.LastName + ", " + r.SavingsDeposit.Member.FirstName + " " + r.SavingsDeposit.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.SavingsDeposit).ServiceName,
                        Date = r.CashReceipt.ReceiptDate,
                        TransationType = "Receipt",
                        ORJVNumber = r.CashReceipt.OfficialReceiptNumber,
                        Amount = r.Amount,
                        Balance = r.Balance,
                    }))
                    .Concat(db.GetTable<SavingsDepositDisbursement>()
                    .Where(d => d.SavingsDeposit.Member.AccountNumber.StartsWith(accountNumber))
                    .Select(d => new SavingsAccount()
                    {
                        Member = d.SavingsDeposit.Member.LastName + ", " + d.SavingsDeposit.Member.FirstName + " " + d.SavingsDeposit.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.SavingsDeposit).ServiceName,
                        Date = d.CashDisbursement.DisbursementDate,
                        TransationType = "Disbursement",
                        ORJVNumber = d.CashDisbursement.CashDisbursementVoucher,
                        Amount = d.Amount,
                        Balance = d.Balance,
                    }))
                    .Concat(db.GetTable<SavingsDepositInterestAdjustment>()
                    .Where(a => a.SavingsDeposit.Member.AccountNumber.StartsWith(accountNumber))
                    .Select(a => new SavingsAccount()
                    {
                        Member = a.SavingsDeposit.Member.LastName + ", " + a.SavingsDeposit.Member.FirstName + " " + a.SavingsDeposit.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.SavingsDeposit).ServiceName,
                        Date = a.Adjustment.AdjustmentDate,
                        TransationType = "Interest",
                        ORJVNumber = a.Adjustment.AdjustmentJournalVoucher,
                        Amount = a.Amount,
                        Balance = a.Balance,
                    }))
                    .Concat(db.GetTable<SavingsDepositDividendAdjustment>()
                    .Where(a => a.SavingsDeposit.Member.AccountNumber.StartsWith(accountNumber))
                    .Select(a => new SavingsAccount()
                    {
                        Member = a.SavingsDeposit.Member.LastName + ", " + a.SavingsDeposit.Member.FirstName + " " + a.SavingsDeposit.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.SavingsDeposit).ServiceName,
                        Date = a.Adjustment.AdjustmentDate,
                        TransationType = "Dividend",
                        ORJVNumber = a.Adjustment.AdjustmentJournalVoucher,
                        Amount = a.Amount,
                        Balance = a.Balance,
                    }));

                var timeDepositQuery = (db.GetTable<TimeDepositReceipt>()
                    .Where(r => 
                        r.TimeDeposit.Member.AccountNumber.StartsWith(accountNumber) &&
                        r.TimeDeposit.Consumed == false)
                    .Select(r => new SavingsAccount()
                    {
                        Member = r.TimeDeposit.Member.LastName + ", " + r.TimeDeposit.Member.FirstName + " " + r.TimeDeposit.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.TimeDeposit).ServiceName,
                        Date = r.CashReceipt.ReceiptDate,
                        TransationType = "Receipt",
                        ORJVNumber = r.CashReceipt.OfficialReceiptNumber,
                        Amount = r.Amount,
                        Balance = 0M,
                    }))
                    .Concat(db.GetTable<TimeDepositDisbursement>()
                    .Where(d =>
                        d.TimeDeposit.Member.AccountNumber.StartsWith(accountNumber) &&
                        d.TimeDeposit.Consumed == false)
                    .Select(d => new SavingsAccount()
                    {
                        Member = d.TimeDeposit.Member.LastName + ", " + d.TimeDeposit.Member.FirstName + " " + d.TimeDeposit.Member.MiddleName,
                        Service = serviceTable.Single(s => s.ServiceID == ServiceCodes.TimeDeposit).ServiceName,
                        Date = d.CashDisbursement.DisbursementDate,
                        TransationType = "Disbursement",
                        ORJVNumber = d.CashDisbursement.CashDisbursementVoucher,
                        Amount = d.Amount,
                        Balance = 0M,
                    }));


                var savingsAccountsQuery = capitalShareQuery
                    .Concat(savingsDepositQuery)
                    .Concat(timeDepositQuery)
                    .OrderBy(sa => sa.Service)
                    .ThenBy(sa => sa.Date);

                var loanAccountsQuery = db.GetTable<Loan>()
                    .Where(l => l.Member.AccountNumber.StartsWith(accountNumber))
                    .Select(l => new LoanAccount(l)
                    {
                        Member = l.Member.LastName + ", " + l.Member.FirstName + " " + l.Member.MiddleName
                    });

                var membershipCategory = db.GetTable<MembershipCategory>()
                    .Single(mc => mc.MembershipCategoryID.Equals(membershipCategoryID))
                    .MembershipCategoryName;

                _view.PopulateReports(savingsAccountsQuery.ToList(), loanAccountsQuery.ToList(), membershipCategory);

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
