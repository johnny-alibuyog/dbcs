using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Utilities;
using CooperativeSystem.Service.Presenters.Lookups.PaymentModes;

namespace CooperativeSystem.Service.Models
{
    partial class CollegeInsurancePlan
    {
        #region Routine Helpers

        private void SyncronizeEntityStateOnTransaction(DateTime transactionDate)
        {
            CurrentBalance = GetOutstandingBalance();

            if (IsPaymentCompleted())
            {
                PaymentCompletionDate = transactionDate;
                MaturityDate = transactionDate.AddYears(AgingPeriod);
            }
            else
            {
                PaymentCompletionDate = null;
                MaturityDate = null;
            }
        }

        private void SyncronizeEntityStateOnDisbursement()
        {
            Consumed = true;
            ConsummationDate = DateTime.Today;
        }

        private int GetConsumedPeriod()
        {
            var consumedDays = (DateTime.Today - ApplicationDate.TruncateTime()).TotalDays;
            var consumedTerms = consumedDays / PaymentMode.Days;

            // has passed to the next period of payment
            if (consumedTerms > 0D && consumedTerms.HasFractionalValue())
                consumedTerms++;

            return (int)consumedTerms;
        }

        private decimal GetTotalIncentives()
        {
            var totalIncentives = 0M;

            if (MaturityDate <= DateTime.Today)
                totalIncentives = AwardAmount - PaymentCompletionAmount;

            return totalIncentives;
        }

        public decimal GetBalanceOn(DateTime date)
        {
            return GetTotalIncentives() +
                GetReceiptsOn(date).Sum(x => x.Amount) +
                GetAdjustmentsOn(date).Sum(x => x.Amount) -
                GetDisbursementsOn(date).Sum(x => x.Amount);
        }

        private IEnumerable<CollegeInsurancePlanReceipt> GetReceiptsOn(DateTime date)
        {
            return CollegeInsurancePlanReceipts
                .Where(x => x.CashReceipt.ReceiptDate <= date)
                .OrderBy(x => x.CashReceipt.ReceiptDate);
        }

        private IEnumerable<CollegeInsurancePlanAdjustment> GetAdjustmentsOn(DateTime date)
        {
            return CollegeInsurancePlanAdjustments
                .Where(x => x.Adjustment.AdjustmentDate <= date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<CollegeInsurancePlanDisbursement> GetDisbursementsOn(DateTime date)
        {
            return CollegeInsurancePlanDisbursements
                .Where(x => x.CashDisbursement.DisbursementDate <= date)
                .OrderBy(x => x.CashDisbursement.DisbursementDate);
        }

        private decimal GetBalanceBefore(DateTime date)
        {
            return GetTotalIncentives() + 
                GetReceiptsBefore(date).Sum(r => r.Amount) +
                GetAdjustmentBefore(date).Sum(x => x.Amount) -
                GetDisbursementBefore(date).Sum(a => a.Amount);
        }

        private IEnumerable<CollegeInsurancePlanReceipt> GetReceiptsBefore(DateTime date)
        {
            return CollegeInsurancePlanReceipts
                .Where(x => x.CashReceipt.ReceiptDate < date)
                .OrderBy(x => x.CashReceipt.ReceiptDate);
        }

        private IEnumerable<CollegeInsurancePlanAdjustment> GetAdjustmentBefore(DateTime date)
        {
            return CollegeInsurancePlanAdjustments
                .Where(x => x.Adjustment.AdjustmentDate < date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<CollegeInsurancePlanDisbursement> GetDisbursementBefore(DateTime date)
        {
            return CollegeInsurancePlanDisbursements
                .Where(x => x.CashDisbursement.DisbursementDate < date)
                .OrderBy(x => x.CashDisbursement.DisbursementDate);
        }

        private IEnumerable<CollegeInsurancePlanReceipt> GetReceiptsAfter(DateTime date)
        {
            return CollegeInsurancePlanReceipts
                .Where(x => x.CashReceipt.ReceiptDate > date)
                .OrderBy(x => x.CashReceipt.ReceiptDate);
        }

        private IEnumerable<CollegeInsurancePlanAdjustment> GetAdjustmentAfter(DateTime date)
        {
            return CollegeInsurancePlanAdjustments
                .Where(x => x.Adjustment.AdjustmentDate > date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<CollegeInsurancePlanDisbursement> GetDisbursementAfter(DateTime date)
        {
            return CollegeInsurancePlanDisbursements
                .Where(x => x.CashDisbursement.DisbursementDate > date)
                .OrderBy(x => x.CashDisbursement.DisbursementDate);
        }

        #endregion

        #region Aggregate Modifiers

        public void AddCollegeInsurancePlanReceipt(CollegeInsurancePlanReceipt entity)
        {
            entity.Balance = GetBalanceBefore(entity.CashReceipt.ReceiptDate) + entity.Amount;

            // add
            CollegeInsurancePlanReceipts.Add(entity);

            // sync state
            SyncronizeEntityStateOnTransaction(entity.CashReceipt.ReceiptDate);
        }

        public void AddCollegeInsurancePlanAdjustment(CollegeInsurancePlanAdjustment entity)
        {
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) + entity.Amount;

            // add
            CollegeInsurancePlanAdjustments.Add(entity);

            // sync state
            SyncronizeEntityStateOnTransaction(entity.Adjustment.AdjustmentDate);

            //var cashReceipt = entity.Adjustment.CashReceipt;

            //// apply adjustment
            //var exists = CollegeInsurancePlanReceipts.Any(x => x.CashReceipt == cashReceipt);
            //if (exists)
            //    UpdateCollegeInsurancePlanReceipt(entity.NewAmount, cashReceipt);
            //else
            //    AddCollegeInsurancePlanReceipt(new CollegeInsurancePlanReceipt() { Amount = entity.NewAmount, CashReceipt = cashReceipt });

            ////add
            //CollegeInsurancePlanAdjustments.Add(entity);
        }

        public void AddCollegeInsurancePlanDisbursement(CollegeInsurancePlanDisbursement entity)
        {
            entity.Balance = GetBalanceBefore(entity.CashDisbursement.DisbursementDate) - entity.Amount;

            // add
            CollegeInsurancePlanDisbursements.Add(entity);

            // sync state
            SyncronizeEntityStateOnDisbursement();
        }

        public void UpdateCollegeInsurancePlanReceipt(decimal amount, CashReceipt cashReceipt)
        {
            // get entity
            var entity = CollegeInsurancePlanReceipts.Single(x => x.CashReceipt == cashReceipt);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(entity.CashReceipt.ReceiptDate) + entity.Amount;

            // business rule
            SyncronizeEntityStateOnTransaction(cashReceipt.ReceiptDate);
        }

        public void UpdateCollegeInsurancePlanAdjustment(decimal amount, Adjustment adjustment)
        {
            // get entity
            var entity = CollegeInsurancePlanAdjustments.Single(x => x.Adjustment == adjustment);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) + entity.Amount;

            // business rule
            SyncronizeEntityStateOnTransaction(adjustment.AdjustmentDate);

            //var cashReceipt = adjustment.CashReceipt;

            //// apply adjustment
            //var exists = CollegeInsurancePlanReceipts.Any(x => x.CashReceipt == cashReceipt);
            //if (exists)
            //    UpdateCollegeInsurancePlanReceipt(newAmount, cashReceipt);
            //else
            //    AddCollegeInsurancePlanReceipt(new CollegeInsurancePlanReceipt() { Amount = newAmount, CashReceipt = cashReceipt });

            //// edit
            //var entity = CollegeInsurancePlanAdjustments.Single(x => x.Adjustment == adjustment);
            //entity.NewAmount = newAmount;
            //entity.OriginalAmount = originalAmount;
        }

        public void UpdateCollegeInsurancePlanDisbursement(decimal amount, CashDisbursement cashDisbursement)
        {
            // get entity
            var entity = CollegeInsurancePlanDisbursements.Single(x => x.CashDisbursement == cashDisbursement);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(entity.CashDisbursement.DisbursementDate) - entity.Amount;

            // sync state
            SyncronizeEntityStateOnDisbursement();
        }

        #endregion

        public bool IsPaymentCompleted()
        {
            var paid = GetPaidAmount();
            var paymentCompletion = PaymentCompletionAmount;
            return (paid >= paymentCompletion);
        }

        public decimal GetOutstandingBalance()
        {
            var payable = PaymentCompletionAmount;
            var paid = GetPaidAmount();

            var balance = payable - paid;
            if (balance < 0M)
                balance = 0M;

            return balance;
        }

        public decimal GetPaidAmount()
        {
            var paidAmount =
                CollegeInsurancePlanReceipts.Sum(x => x.Amount) +
                CollegeInsurancePlanAdjustments.Sum(x => x.Amount);

            return paidAmount;
        }

        public decimal GetCurrentPayableAmount()
        {
            var amount = 0M;
            var consumedPeriod = GetConsumedPeriod();
            var consumablePeriod = (PaymentModeID != PaymentModeCodes.Yearly)
                ? (Terms * 12) * PaymentMode.CIPContributionsPerMonth
                : (Terms);

            if (Consumed)
                return amount;

            if (consumedPeriod < 1)
                return amount;

            if (consumedPeriod > consumablePeriod)
                amount = GetOutstandingBalance();
            else
                amount = (consumedPeriod * Amortization) - GetPaidAmount();

            if (amount < 0M)
                amount = 0M;

            return amount;
        }

        public string UserName
        {
            get { return (UserLastName + ", " + UserFirstName + " " + UserMiddleName).Trim(); }
        }

        public string GetStatus()
        {
            var totalPayment = CollegeInsurancePlanReceipts.Sum(cip => cip.Amount);

            if (Consumed)
                return "Consumed";

            if ((MaturityDate != null) &&
                (DateTime.Today >= MaturityDate.Value.TruncateTime()) &&
                (totalPayment >= PaymentCompletionAmount))
                return "Matured";

            if (totalPayment >= PaymentCompletionAmount)
                return "Fully paid";

            if (totalPayment > 0M)
                return "Parially paid";

            return "Newly enrolled";
        }

        partial void OnCreated()
        {
            Consumed = false;
        }

        partial void OnDateOfBirthChanged()
        {
            if (_DateOfBirth != null)
                _DateOfBirth = _DateOfBirth.Value.TruncateTime();
        }

        partial void OnApplicationDateChanged()
        {
            _ApplicationDate = _ApplicationDate.TruncateTime();
        }

        partial void OnPaymentCompletionDateChanged()
        {
            if (_PaymentCompletionDate != null)
                _PaymentCompletionDate = _PaymentCompletionDate.Value.TruncateTime();
        }

        partial void OnMaturityDateChanged()
        {
            if (_MaturityDate != null)
                _MaturityDate = _MaturityDate.Value.TruncateTime();
        }
    }
}
