using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models
{
    partial class SavingsDeposit
    {
        #region Routine Helpers

        private decimal ComputeCurrentBalance()
        {
            return 
                SavingsDepositReceipts.Sum(x => x.Amount) +
                SavingsDepositAdjustments.Sum(x => x.Amount) +
                SavingsDepositDividendAdjustments.Sum(x => x.Amount) +
                SavingsDepositInterestAdjustments.Sum(x => x.Amount) -
                SavingsDepositDisbursements.Sum(x => x.Amount);
        }

        private decimal GetBalanceBefore(DateTime date)
        {
            return 
                GetReceiptsBefore(date).Sum(x => x.Amount) +
                GetAdjustmentsBefore(date).Sum(x => x.Amount) +
                GetDividendAdjustmentsBefore(date).Sum(x => x.Amount) +
                GetInterestAdjustmentsBefore(date).Sum(x => x.Amount) -
                GetDisbursementsBefore(date).Sum(x => x.Amount);
        }

        private IEnumerable<SavingsDepositReceipt> GetReceiptsBefore(DateTime date)
        {
            return SavingsDepositReceipts
                .Where(x => x.CashReceipt.ReceiptDate < date)
                .OrderBy(sdr => sdr.CashReceipt.ReceiptDate);
        }

        private IEnumerable<SavingsDepositAdjustment> GetAdjustmentsBefore(DateTime date)
        {
            return SavingsDepositAdjustments
                .Where(x => x.Adjustment.AdjustmentDate < date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<SavingsDepositDividendAdjustment> GetDividendAdjustmentsBefore(DateTime date)
        {
            return SavingsDepositDividendAdjustments
                .Where(x => x.Adjustment.AdjustmentDate < date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<SavingsDepositDisbursement> GetDisbursementsBefore(DateTime date)
        {
            return SavingsDepositDisbursements
                .Where(x => x.CashDisbursement.DisbursementDate < date)
                .OrderBy(x => x.CashDisbursement.DisbursementDate);
        }

        private IEnumerable<SavingsDepositInterestAdjustment> GetInterestAdjustmentsBefore(DateTime date)
        {
            return SavingsDepositInterestAdjustments
                .Where(x => x.Adjustment.AdjustmentDate < date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<SavingsDepositReceipt> GetReceiptsAfter(DateTime date)
        {
            return SavingsDepositReceipts
                .Where(x => x.CashReceipt.ReceiptDate > date)
                .OrderBy(x => x.CashReceipt.ReceiptDate);
        }

        private IEnumerable<SavingsDepositAdjustment> GetAdjustmentsAfter(DateTime date)
        {
            return SavingsDepositAdjustments
                .Where(x => x.Adjustment.AdjustmentDate > date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<SavingsDepositDividendAdjustment> GetDividendAdjustmentsAfter(DateTime date)
        {
            return SavingsDepositDividendAdjustments
                .Where(x => x.Adjustment.AdjustmentDate > date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<SavingsDepositDisbursement> GetDisbursementsAfter(DateTime date)
        {
            return SavingsDepositDisbursements
                .Where(x => x.CashDisbursement.DisbursementDate > date)
                .OrderBy(x => x.CashDisbursement.DisbursementDate);
        }

        private IEnumerable<SavingsDepositInterestAdjustment> GetInterestAdjustmentsAfter(DateTime date)
        {
            return SavingsDepositInterestAdjustments
                .Where(x => x.Adjustment.AdjustmentDate > date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private void AdjustBalancesAfter(DateTime date, decimal changeAmount)
        {
            var receiptsAfter = GetReceiptsAfter(date);
            var dividendsAfter = GetDividendAdjustmentsAfter(date);
            var disbursementsAfter = GetDisbursementsAfter(date);
            var interestAdjustmentsAfter = GetInterestAdjustmentsAfter(date);

            // adjust balances of transactions after
            foreach (var item in receiptsAfter)
                item.Balance -= changeAmount;

            foreach (var item in dividendsAfter)
                item.Balance -= changeAmount;

            foreach (var item in disbursementsAfter)
                item.Balance -= changeAmount;

            foreach (var item in interestAdjustmentsAfter)
                item.Balance -= changeAmount;
        }

        #endregion

        public void AddSavingsDepositReceipt(SavingsDepositReceipt entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.CashReceipt.ReceiptDate) + entity.Amount;

            // add
            SavingsDepositReceipts.Add(entity);

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void AddSavingsDepositAdjustment(SavingsDepositAdjustment entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) + entity.Amount;

            // add
            SavingsDepositAdjustments.Add(entity);

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();

            //var cashReceipt = entity.Adjustment.CashReceipt;

            //// apply adjustment
            //var exists = SavingsDepositReceipts.Any(x => x.CashReceipt == cashReceipt);
            //if (exists)
            //    UpdateSavingsDepositReceipt(entity.NewAmount, cashReceipt);
            //else
            //    AddSavingsDepositReceipt(new SavingsDepositReceipt() { Amount = entity.NewAmount, CashReceipt = cashReceipt });

            //// adjust affected periodical balances
            //AdjustBalancesAfter(cashReceipt.ReceiptDate, entity.ChangeAmount);

            //// add only if not exists
            //if (SavingsDepositAdjustments.Any(x => x.Adjustment == entity.Adjustment) == false)
            //    SavingsDepositAdjustments.Add(entity);
        }

        public void AddSavingsDepositDividendAdjustment(SavingsDepositDividendAdjustment entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) + entity.Amount;

            // add
            SavingsDepositDividendAdjustments.Add(entity);

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void AddSavingsDepositDisbursement(SavingsDepositDisbursement entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.CashDisbursement.DisbursementDate) - entity.Amount;

            // add
            SavingsDepositDisbursements.Add(entity);

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void AddSavingsDepositInterestAdjustment(SavingsDepositInterestAdjustment entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) + entity.Amount;

            // add
            SavingsDepositInterestAdjustments.Add(entity);

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void UpdateSavingsDepositReceipt(decimal amount, CashReceipt cashReceipt)
        {
            // get entity
            var entity = SavingsDepositReceipts.Single(x => x.CashReceipt == cashReceipt);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(cashReceipt.ReceiptDate) + amount;

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void UpdateSavingsDepositAdjustment(decimal amount, Adjustment adjustment)
        {
            // get entity
            var entity = SavingsDepositAdjustments.Single(x => x.Adjustment == adjustment);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(adjustment.AdjustmentDate) + amount;

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();

            //var cashReceipt = adjustment.CashReceipt;

            //// apply adjustment
            //var exists = SavingsDepositReceipts.Any(x => x.CashReceipt == cashReceipt);
            //if (exists)
            //    UpdateSavingsDepositReceipt(newAmount, cashReceipt);
            //else
            //    AddSavingsDepositReceipt(new SavingsDepositReceipt() { Amount = newAmount, CashReceipt = cashReceipt });

            //// edit
            //var entity = SavingsDepositAdjustments.Single(x => x.Adjustment == adjustment);
            //entity.NewAmount = newAmount;
            //entity.OriginalAmount = originalAmount;

            //// adjust affected periodical balances
            //AdjustBalancesAfter(cashReceipt.ReceiptDate, entity.ChangeAmount);
        }

        public void UpdateSavingsDepositDividendAdjustment(decimal amount, Adjustment adjustment)
        {
            // get entity
            var entity = SavingsDepositDividendAdjustments.Single(x => x.Adjustment == adjustment);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(adjustment.AdjustmentDate) + amount;

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void UpdateSavingsDepositDisbursement(decimal amount, CashDisbursement cashDisbursement)
        {
            // get entity
            var entity = SavingsDepositDisbursements.Single(x => x.CashDisbursement == cashDisbursement);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(cashDisbursement.DisbursementDate) - amount;

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void UpdateSavingsDepositInterestAdjustment(decimal amount, Adjustment adjustment)
        {
            // get entity
            var entity = SavingsDepositInterestAdjustments.Single(x => x.Adjustment == adjustment);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(adjustment.AdjustmentDate) + amount;

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void RecomputeBalance()
        {
            foreach (var item in SavingsDepositReceipts)
                item.Balance = GetBalanceBefore(item.CashReceipt.ReceiptDate) + item.Amount;

            foreach (var item in SavingsDepositAdjustments)
                item.Balance = GetBalanceBefore(item.Adjustment.AdjustmentDate) + item.Amount;

            foreach (var item in SavingsDepositDividendAdjustments)
                item.Balance = GetBalanceBefore(item.Adjustment.AdjustmentDate) + item.Amount;

            foreach (var item in SavingsDepositInterestAdjustments)
                item.Balance = GetBalanceBefore(item.Adjustment.AdjustmentDate) + item.Amount;

            foreach (var item in SavingsDepositDisbursements)
                item.Balance = GetBalanceBefore(item.CashDisbursement.DisbursementDate) - item.Amount;

            CurrentBalance = ComputeCurrentBalance();
        }
    }
}
