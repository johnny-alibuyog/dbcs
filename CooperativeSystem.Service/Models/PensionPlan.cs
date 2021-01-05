using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Models
{
    partial class PensionPlan
    {
        #region Routine Helpers

        private void SyncronizeEntityStateOnTransaction(DateTime transactionDate)
        {
            CurrentBalance = GetOutstandingBalance();

            if (IsPaymentCompleted())
            {
                PaymentCompletionDate = transactionDate;
                MaturityDate = PaymentCompletionDate.Value.AddYears(AgingPeriod);
            }
            else
            {
                PaymentCompletionDate = null;
                MaturityDate = null;
            }

            
            //var isFullyPaid = (PensionPlanReceipts.Sum(r => r.Amount) >= PaymentCompletionAmount);
            //if (isFullyPaid)
            //{
            //    PaymentCompletionDate = receiptDate;
            //    MaturityDate = PaymentCompletionDate.Value.AddYears(AgingPeriod);
            //}
            //else
            //{
            //    PaymentCompletionDate = null;
            //    MaturityDate = null;
            //}
        }

        private void SyncronizeEntityStateOnDisbursement()
        {
            var consumableAmount = MaturityDate != null && MaturityDate <= DateTime.Today ? AwardAmount : GetPaidAmount();

            Consumed = (PensionPlanDisbursements.Sum(x => x.Amount) >= consumableAmount);
            if (Consumed)
                ConsummationDate = DateTime.Today;
            else
                ConsummationDate = null;
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

        public decimal GetTotalIncentives()
        {
            var totalIncentives = 0M;

            if (MaturityDate <= DateTime.Today)
                totalIncentives = (AwardAmount ?? 0M) - PaymentCompletionAmount;

            return totalIncentives;
        }

        public decimal GetBalance()
        {
            return GetTotalIncentives() +
                PensionPlanReceipts.Sum(x => x.Amount) +
                PensionPlanAdjustments.Sum(x => x.Amount) +
                PensionPlanInterestAdjustments.Sum(x => x.Amount) -
                PensionPlanDisbursements.Sum(x => x.Amount);
        }

        public decimal GetBalanceOn(DateTime date)
        {
            return GetTotalIncentives() +
                GetReceiptsOn(date).Sum(x => x.Amount) +
                GetAdjustmentOn(date).Sum(x => x.Amount) +
                GetInterestAdjustmentOn(date).Sum(x => x.Amount) -
                GetDisbursementsOn(date).Sum(x => x.Amount);
        }

        private IEnumerable<PensionPlanReceipt> GetReceiptsOn(DateTime date)
        {
            return PensionPlanReceipts
                .Where(x => x.CashReceipt.ReceiptDate <= date)
                .OrderBy(x => x.CashReceipt.ReceiptDate);
        }

        private IEnumerable<PensionPlanAdjustment> GetAdjustmentOn(DateTime date)
        {
            return PensionPlanAdjustments
                .Where(x => x.Adjustment.AdjustmentDate <= date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }
        
        private IEnumerable<PensionPlanDisbursement> GetDisbursementsOn(DateTime date)
        {
            return PensionPlanDisbursements
                .Where(x => x.CashDisbursement.DisbursementDate <= date)
                .OrderBy(x => x.CashDisbursement.DisbursementDate);
        }

        private IEnumerable<PensionPlanInterestAdjustment> GetInterestAdjustmentOn(DateTime date)
        {
            return PensionPlanInterestAdjustments
                .Where(x => x.Adjustment.AdjustmentDate <= date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private decimal GetBalanceBefore(DateTime date)
        {
            return GetTotalIncentives() +
                GetReceiptsBefore(date).Sum(r => r.Amount) +
                GetAdjustmentBefore(date).Sum(x => x.Amount) +
                GetInterestAdjustmentBefore(date).Sum(x => x.Amount) -
                GetDisbursementBefore(date).Sum(a => a.Amount);
        }

        private IEnumerable<PensionPlanReceipt> GetReceiptsBefore(DateTime date)
        {
            return PensionPlanReceipts
                .Where(x => x.CashReceipt.ReceiptDate < date)
                .OrderBy(x => x.CashReceipt.ReceiptDate);
        }

        private IEnumerable<PensionPlanAdjustment> GetAdjustmentBefore(DateTime date)
        {
            return PensionPlanAdjustments
                .Where(x => x.Adjustment.AdjustmentDate < date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<PensionPlanInterestAdjustment> GetInterestAdjustmentBefore(DateTime date)
        {
            return PensionPlanInterestAdjustments
                .Where(x => x.Adjustment.AdjustmentDate < date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<PensionPlanDisbursement> GetDisbursementBefore(DateTime date)
        {
            return PensionPlanDisbursements
                .Where(x => x.CashDisbursement.DisbursementDate < date)
                .OrderBy(x => x.CashDisbursement.DisbursementDate);
        }

        private IEnumerable<PensionPlanReceipt> GetReceiptsAfter(DateTime date)
        {
            return PensionPlanReceipts
                .Where(x => x.CashReceipt.ReceiptDate > date)
                .OrderBy(x => x.CashReceipt.ReceiptDate);
        }

        private IEnumerable<PensionPlanAdjustment> GetAdjustmentAfter(DateTime date)
        {
            return PensionPlanAdjustments
                .Where(x => x.Adjustment.AdjustmentDate > date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<PensionPlanInterestAdjustment> GetInterestAdjustmentAfter(DateTime date)
        {
            return PensionPlanInterestAdjustments
                .Where(x => x.Adjustment.AdjustmentDate > date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<PensionPlanDisbursement> GetDisbursementAfter(DateTime date)
        {
            return PensionPlanDisbursements
                .Where(x => x.CashDisbursement.DisbursementDate > date)
                .OrderBy(x => x.CashDisbursement.DisbursementDate);
        }

        #endregion

        #region Aggregate Modifiers

        public void AddPensionPlanReceipt(PensionPlanReceipt entity)
        {
            entity.Balance = GetBalanceBefore(entity.CashReceipt.ReceiptDate) + entity.Amount;

            // add
            PensionPlanReceipts.Add(entity);

            // syncronize entity state
            SyncronizeEntityStateOnTransaction(entity.CashReceipt.ReceiptDate);
        }

        public void AddPensionPlanAdjustment(PensionPlanAdjustment entity)
        {
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) + entity.Amount;

            // add
            PensionPlanAdjustments.Add(entity);

            // syncronize entity state
            SyncronizeEntityStateOnTransaction(entity.Adjustment.AdjustmentDate);

            //var cashReceipt = entity.Adjustment.CashReceipt;

            //// apply adjustment
            //var exists = PensionPlanReceipts.Any(x => x.CashReceipt == cashReceipt);
            //if (exists)
            //    UpdatePensionPlanReceipt(entity.NewAmount, cashReceipt);
            //else
            //    AddPensionPlanReceipt(new PensionPlanReceipt() { Amount = entity.NewAmount, CashReceipt = cashReceipt });

            //// add 
            //PensionPlanAdjustments.Add(entity);
        }

        public void AddPensionPlanInterestAdjustment(PensionPlanInterestAdjustment entity)
        {
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) + entity.Amount;

            // add
            PensionPlanInterestAdjustments.Add(entity);

            // syncronize entity state
            SyncronizeEntityStateOnTransaction(entity.Adjustment.AdjustmentDate);
        }

        public void AddPensionPlanDisbursement(PensionPlanDisbursement entity)
        {
            entity.Balance = GetBalanceBefore(entity.CashDisbursement.DisbursementDate) - entity.Amount;

            // add
            PensionPlanDisbursements.Add(entity);

            // syncronize entity state
            SyncronizeEntityStateOnDisbursement();
        }

        public void UpdatePensionPlanReceipt(decimal amount, CashReceipt cashReceipt)
        {
            // get entity
            var entity = PensionPlanReceipts.Single(x => x.CashReceipt == cashReceipt);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(entity.CashReceipt.ReceiptDate) + entity.Amount;

            // syncronize entity state
            SyncronizeEntityStateOnTransaction(entity.CashReceipt.ReceiptDate);
        }

        public void UpdatePensionPlanAdjustment(decimal amount, Adjustment adjustment)
        {
            // get entity
            var entity = PensionPlanAdjustments.Single(x => x.Adjustment == adjustment);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) + entity.Amount;

            // syncronize entity state
            SyncronizeEntityStateOnTransaction(entity.Adjustment.AdjustmentDate);

            //var cashReceipt = adjustment.CashReceipt;

            //// apply adjustment
            //var exists = PensionPlanReceipts.Any(x => x.CashReceipt == cashReceipt);
            //if (exists)
            //    UpdatePensionPlanReceipt(newAmount, cashReceipt);
            //else
            //    AddPensionPlanReceipt(new PensionPlanReceipt() { Amount = newAmount, CashReceipt = cashReceipt });

            //// edit
            //var entity = PensionPlanAdjustments.Single(x => x.Adjustment == adjustment);
            //entity.NewAmount = newAmount;
            //entity.OriginalAmount = originalAmount;
        }

        public void UpdatePensionPlanInterestAdjustment(decimal amount, Adjustment adjustment)
        {
            // get entity
            var entity = PensionPlanInterestAdjustments.Single(x => x.Adjustment == adjustment);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) + entity.Amount;

            // syncronize entity state
            SyncronizeEntityStateOnTransaction(entity.Adjustment.AdjustmentDate);
        }

        public void UpdatePensionPlanDisbursement(decimal amount, CashDisbursement cashDisbursement)
        {
            // get entity
            var entity = PensionPlanDisbursements.Single(x => x.CashDisbursement == cashDisbursement);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(entity.CashDisbursement.DisbursementDate) - entity.Amount;

            // syncronize entity state
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
                PensionPlanReceipts.Sum(x => x.Amount) +
                PensionPlanAdjustments.Sum(x => x.Amount);

            return paidAmount;
        }

        public decimal CurrentPayableAmount
        {
            get
            {
                var amount = 0M;
                var consumablePeriod = (Terms * 12) * PaymentMode.CIPContributionsPerMonth;
                var consumedPeriod = GetConsumedPeriod();

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

        partial void OnAgingPeriodChanged()
        {
            if (_PaymentCompletionDate != null)
                _MaturityDate = _PaymentCompletionDate.Value.AddYears(_AgingPeriod);
        }
    }
}
