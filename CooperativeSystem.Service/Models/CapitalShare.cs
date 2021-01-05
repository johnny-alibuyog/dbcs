using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models
{
    partial class CapitalShare
    {
        #region Routine Helpers

        private decimal ComputeCurrentBalance()
        {
            return 
                CapitalShareReceipts.Sum(x => x.Amount) +
                CapitalShareAdjustments.Sum(x => x.Amount) +
                CapitalShareBuildups.Sum(x => x.Amount) + 
                CapitalShareDividendAdjustments.Sum(x => x.Amount) +
                CapitalShareInterestRebateAdjustments.Sum(x => x.Amount) +
                CapitalSharePatronageRefundAdjustments.Sum(x => x.Amount) -
                CapitalShareDisbursements.Sum(x => x.Amount);
        }
 
        private decimal GetBalanceBefore(DateTime date)
        {
            return
                GetReceiptsBefore(date).Sum(x => x.Amount) +
                GetAdjustmentsBefore(date).Sum(x => x.Amount) +
                GetBuildupsBefore(date).Sum(x => x.Amount) +
                GetDividendsBefore(date).Sum(x => x.Amount) +
                GetInterestRebatesBefore(date).Sum(x => x.Amount) +
                GetPatronageRefundsBefore(date).Sum(x => x.Amount) -
                GetDisbursementsBefore(date).Sum(x => x.Amount);
        }

        private IEnumerable<CapitalShareReceipt> GetReceiptsBefore(DateTime date)
        {
            return CapitalShareReceipts
                .Where(x => x.CashReceipt.ReceiptDate < date)
                .OrderBy(x => x.CashReceipt.ReceiptDate);
        }

        private IEnumerable<CapitalShareAdjustment> GetAdjustmentsBefore(DateTime date)
        {
            return CapitalShareAdjustments
                .Where(x => x.Adjustment.AdjustmentDate < date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<CapitalShareDisbursement> GetDisbursementsBefore(DateTime date)
        {
            return CapitalShareDisbursements
                .Where(x => x.CashDisbursement.DisbursementDate < date)
                .OrderBy(x => x.CashDisbursement.DisbursementDate);
        }

        private IEnumerable<CapitalShareBuildup> GetBuildupsBefore(DateTime date)
        {
            return CapitalShareBuildups
                .Where(x => x.CashDisbursement.DisbursementDate < date)
                .OrderBy(x => x.CashDisbursement.DisbursementDate);
        }

        private IEnumerable<CapitalShareDividendAdjustment> GetDividendsBefore(DateTime date)
        {
            return CapitalShareDividendAdjustments
                .Where(x => x.Adjustment.AdjustmentDate < date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<CapitalShareInterestRebateAdjustment> GetInterestRebatesBefore(DateTime date)
        {
            return CapitalShareInterestRebateAdjustments
                .Where(x => x.Adjustment.AdjustmentDate < date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }
        
        private IEnumerable<CapitalSharePatronageRefundAdjustment> GetPatronageRefundsBefore(DateTime date)
        {
            return CapitalSharePatronageRefundAdjustments
                .Where(x => x.Adjustment.AdjustmentDate < date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<CapitalShareReceipt> GetReceiptsAfter(DateTime date)
        {
            return CapitalShareReceipts
                .Where(x => x.CashReceipt.ReceiptDate > date)
                .OrderBy(x => x.CashReceipt.ReceiptDate);
        }

        private IEnumerable<CapitalShareAdjustment> GetAdjustmentsAfter(DateTime date)
        {
            return CapitalShareAdjustments
                .Where(x => x.Adjustment.AdjustmentDate > date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<CapitalShareDisbursement> GetDisbursementsAfter(DateTime date)
        {
            return CapitalShareDisbursements
                .Where(x => x.CashDisbursement.DisbursementDate > date)
                .OrderBy(x => x.CashDisbursement.DisbursementDate);
        }

        private IEnumerable<CapitalShareBuildup> GetBuildupsAfter(DateTime date)
        {
            return CapitalShareBuildups
                .Where(x => x.CashDisbursement.DisbursementDate > date)
                .OrderBy(x => x.CashDisbursement.DisbursementDate);
        }

        private IEnumerable<CapitalShareDividendAdjustment> GetDividendsAfter(DateTime date)
        {
            return CapitalShareDividendAdjustments
                .Where(x => x.Adjustment.AdjustmentDate > date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<CapitalShareInterestRebateAdjustment> GetInterestRebatesAfter(DateTime date)
        {
            return CapitalShareInterestRebateAdjustments
                .Where(x => x.Adjustment.AdjustmentDate > date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<CapitalSharePatronageRefundAdjustment> GetPatronageRefundsAfter(DateTime date)
        {
            return CapitalSharePatronageRefundAdjustments
                .Where(x => x.Adjustment.AdjustmentDate > date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }
        
        private void AdjustBalancesAfter(DateTime date, decimal changeAmount)
        {
            var receiptsAfter = GetReceiptsAfter(date);
            var adjustmentsAfer = GetAdjustmentsAfter(date);
            var buildupsAfter = GetBuildupsAfter(date);
            var disbursementsAfter = GetDisbursementsAfter(date);
            var dividendsAfter = GetDividendsAfter(date);
            var interestRebatesAfter = GetInterestRebatesAfter(date);
            var patronageRefundsAfter = GetPatronageRefundsAfter(date);

            // adjust balances of transactions after
            foreach (var item in receiptsAfter)
                item.Balance -= changeAmount;

            foreach (var item in adjustmentsAfer)
                item.Balance -= changeAmount;

            foreach (var item in buildupsAfter)
                item.Balance -= changeAmount;

            foreach (var item in disbursementsAfter)
                item.Balance -= changeAmount;

            foreach (var item in dividendsAfter)
                item.Balance -= changeAmount;

            foreach (var item in interestRebatesAfter)
                item.Balance -= changeAmount;

            foreach (var item in patronageRefundsAfter)
                item.Balance -= changeAmount;
        }

        #endregion

        public void AddCapitalShareReceipt(CapitalShareReceipt entity)
        {
            // compute for the periodical balance 
            entity.Balance = GetBalanceBefore(entity.CashReceipt.ReceiptDate) + entity.Amount;
            
            // add
            CapitalShareReceipts.Add(entity);

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void AddCapitalShareAdjustment(CapitalShareAdjustment entity)
        {
            // compute for the periodical balance 
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) + entity.Amount;

            // add
            CapitalShareAdjustments.Add(entity);

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();

            //var cashReceipt = entity.Adjustment.CashReceipt;

            //// apply adjustment
            //var exists = CapitalShareReceipts.Any(x => x.CashReceipt == cashReceipt);
            //if (exists)
            //    UpdateCapitalShareReceipt(entity.NewAmount, cashReceipt);
            //else
            //    AddCapitalShareReceipt(new CapitalShareReceipt() { Amount = entity.NewAmount, CashReceipt = cashReceipt });

            //// adjust affected periodical balances
            //AdjustBalancesAfter(cashReceipt.ReceiptDate, entity.ChangeAmount);

            //// add only if not existing
            //if (CapitalShareAdjustments.Any(x => x.Adjustment == entity.Adjustment) == false)
            //    CapitalShareAdjustments.Add(entity);
        }

        public void AddCapitalShareDisbursement(CapitalShareDisbursement entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.CashDisbursement.DisbursementDate) - entity.Amount;

            // add
            CapitalShareDisbursements.Add(entity);

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void AddCapitalShareBuildup(CapitalShareBuildup entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.CashDisbursement.DisbursementDate) + entity.Amount;

            // add
            CapitalShareBuildups.Add(entity);

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void AddCapitalShareDividendAdjustment(CapitalShareDividendAdjustment entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) + entity.Amount;

            // add
            CapitalShareDividendAdjustments.Add(entity);

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void AddCapitalShareInterestRebateAdjustment(CapitalShareInterestRebateAdjustment entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) + entity.Amount;

            // add
            CapitalShareInterestRebateAdjustments.Add(entity);

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void AddCapitalSharePatronageRefundAdjustment(CapitalSharePatronageRefundAdjustment entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) + entity.Amount;

            // add
            CapitalSharePatronageRefundAdjustments.Add(entity);

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void UpdateCapitalShareAdjustment(decimal amount, Adjustment adjustment)
        {
                        // get entity
            var entity = CapitalShareAdjustments.Single(x => x.Adjustment == adjustment);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(adjustment.AdjustmentDate) + amount;

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();

            //var cashReceipt = adjustment.CashReceipt;

            //// apply adjustment
            //var exists = CapitalShareReceipts.Any(x => x.CashReceipt == cashReceipt);
            //if (exists)
            //    UpdateCapitalShareReceipt(newAmount, cashReceipt);
            //else
            //    AddCapitalShareReceipt(new CapitalShareReceipt() { Amount = newAmount, CashReceipt = cashReceipt });

            //// edit
            //var entity = CapitalShareAdjustments.Single(x => x.Adjustment == adjustment);
            //entity.NewAmount = newAmount;
            //entity.OriginalAmount = originalAmount;

            //// adjust affected periodical balances
            //AdjustBalancesAfter(cashReceipt.ReceiptDate, entity.ChangeAmount);
        }
        
        public void UpdateCapitalShareReceipt(decimal amount, CashReceipt cashReceipt)
        {
            // get entity
            var entity = CapitalShareReceipts.Single(x => x.CashReceipt == cashReceipt);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(cashReceipt.ReceiptDate) + amount;

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void UpdateCapitalShareDisbursement(decimal amount, CashDisbursement cashDisbursement)
        {
            // get entity
            var entity = CapitalShareDisbursements.Single(x => x.CashDisbursement == cashDisbursement);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(cashDisbursement.DisbursementDate) - amount;

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void UpdateCapitalShareBuildup(decimal amount, CashDisbursement cashDisbursement)
        {
            // get entity
            var entity = CapitalShareBuildups.Single(x => x.CashDisbursement == cashDisbursement);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(cashDisbursement.DisbursementDate) + amount;

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void UpdateCapitalShareDividendAdjustment(decimal amount, Adjustment adjustment)
        {
            // get entity
            var entity = CapitalShareDividendAdjustments.Single(x => x.Adjustment == adjustment);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(adjustment.AdjustmentDate) + amount;

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void UpdateCapitalShareInterestRebateAdjustment(decimal amount, Adjustment adjustment)
        {
            // get entity
            var entity = CapitalShareInterestRebateAdjustments.Single(x => x.Adjustment == adjustment);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(adjustment.AdjustmentDate) + amount;

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        public void UpdateCapitalSharePatronageRefundAdjustment(decimal amount, Adjustment adjustment)
        {
            // get entity
            var entity = CapitalSharePatronageRefundAdjustments.Single(x => x.Adjustment == adjustment);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(adjustment.AdjustmentDate) + amount;

            // syncronize current balance
            CurrentBalance = ComputeCurrentBalance();
        }

        internal void RecomputeBalance()
        {
            foreach (var item in CapitalShareReceipts)
                item.Balance = GetBalanceBefore(item.CashReceipt.ReceiptDate) + item.Amount;

            foreach (var item in CapitalShareAdjustments)
                item.Balance = GetBalanceBefore(item.Adjustment.AdjustmentDate) + item.Amount;

            foreach (var item in CapitalShareBuildups)
                item.Balance = GetBalanceBefore(item.CashDisbursement.DisbursementDate) + item.Amount;

            foreach (var item in CapitalShareDividendAdjustments)
                item.Balance = GetBalanceBefore(item.Adjustment.AdjustmentDate) + item.Amount;

            foreach (var item in CapitalShareInterestRebateAdjustments)
                item.Balance = GetBalanceBefore(item.Adjustment.AdjustmentDate) - item.Amount;

            foreach (var item in CapitalSharePatronageRefundAdjustments)
                item.Balance = GetBalanceBefore(item.Adjustment.AdjustmentDate) - item.Amount;

            foreach (var item in CapitalShareDisbursements)
                item.Balance = GetBalanceBefore(item.CashDisbursement.DisbursementDate) - item.Amount;
            
            CurrentBalance = ComputeCurrentBalance();
        }
    }
}
