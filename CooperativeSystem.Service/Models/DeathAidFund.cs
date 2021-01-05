using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models
{
    partial class DeathAidFund
    {
        #region Routine Helpers

        private decimal ComputeCurrenctBalance()
        {
            return
                DeathAidFundReceipts.Sum(x => x.Amount) +
                DeathAidFundAdjustments.Sum(x => x.Amount) -
                DeathAidFundDisbursements.Sum(x => x.Amount);
        }

        private decimal GetBalanceBefore(DateTime date)
        {
            return
                GetReceiptsBefore(date).Sum(x => x.Amount) +
                GetAdjustmentsBefore(date).Sum(x => x.Amount) -
                GetDisbursementsBefore(date).Sum(x => x.Amount);
        }

        private IEnumerable<DeathAidFundReceipt> GetReceiptsBefore(DateTime date)
        {
            return DeathAidFundReceipts
                .Where(x => x.CashReceipt.ReceiptDate < date)
                .OrderBy(sdr => sdr.CashReceipt.ReceiptDate);
        }

        private IEnumerable<DeathAidFundAdjustment> GetAdjustmentsBefore(DateTime date)
        {
            return DeathAidFundAdjustments
                .Where(x => x.Adjustment.AdjustmentDate < date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<DeathAidFundDisbursement> GetDisbursementsBefore(DateTime date)
        {
            return DeathAidFundDisbursements
                .Where(x => x.CashDisbursement.DisbursementDate < date)
                .OrderBy(x => x.CashDisbursement.DisbursementDate);
        }

        private void SyncronizeEntityState()
        {
            CurrentBalance = ComputeCurrenctBalance();
        }

        //private decimal CurrentReceiptAmount
        //{
        //    get
        //    {
        //        return DeathAidFundReceipts
        //            //.Where(x => x.CashReceipt.ReceiptDate.Year == DateTime.Today.Year)
        //            .Sum(x => x.Amount);
        //    }
        //}

        //private decimal CurrentDisbursementAmount
        //{
        //    get
        //    {
        //        return DeathAidFundDisbursements
        //            //.Where(x => x.CashDisbursement.DisbursementDate.Year == DateTime.Today.Year)
        //            .Sum(x => x.Amount);
        //    }
        //}

        //private void SyncronizeEntityState()
        //{
        //    CurrentBalance = CurrentReceiptAmount - CurrentDisbursementAmount;
        //}

        #endregion

        public void AddDeathAidFundAdjustment(DeathAidFundAdjustment entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) + entity.Amount;

            // add
            DeathAidFundAdjustments.Add(entity);

            // sync state
            SyncronizeEntityState();

            //var cashReceipt = entity.Adjustment.CashReceipt;

            //// apply adjustment
            //var exists = DeathAidFundReceipts.Any(x => x.CashReceipt == cashReceipt);
            //if (exists)
            //    UpdateDeathAidFundReceipt(entity.Amount, cashReceipt);
            //else
            //    AddDeathAidFundReceipt(new DeathAidFundReceipt() { Amount = entity.Amount, CashReceipt = cashReceipt });

            ////add
            //DeathAidFundAdjustments.Add(entity);
        }

        public void AddDeathAidFundReceipt(DeathAidFundReceipt entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.CashReceipt.ReceiptDate) + entity.Amount;

            // add
            DeathAidFundReceipts.Add(entity);

            // sync state
            SyncronizeEntityState();
        }

        public void AddDeathAidFundDisbursement(DeathAidFundDisbursement entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.CashDisbursement.DisbursementDate) - entity.Amount;

            // add
            DeathAidFundDisbursements.Add(entity);

            // sync state
            SyncronizeEntityState();
        }

        public void UpdateDeathAidFundAdjustment(decimal amount, Adjustment adjustment)
        {
            // get entity
            var entity = DeathAidFundAdjustments.Single(x => x.Adjustment == adjustment);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(adjustment.AdjustmentDate) + amount;

            // business rule
            SyncronizeEntityState();

            //var cashReceipt = adjustment.CashReceipt;

            //// apply adjustment
            //var exists = DeathAidFundReceipts.Any(x => x.CashReceipt == cashReceipt);
            //if (exists)
            //    UpdateDeathAidFundReceipt(newAmount, cashReceipt);
            //else
            //    AddDeathAidFundReceipt(new DeathAidFundReceipt() { Amount = newAmount, CashReceipt = cashReceipt });

            //// edit
            //var entity = DeathAidFundAdjustments.Single(x => x.Adjustment == adjustment);
            //entity.NewAmount = newAmount;
            //entity.OriginalAmount = originalAmount;
        }


        public void UpdateDeathAidFundReceipt(decimal amount, CashReceipt cashReceipt)
        {
            // get entity
            var entity = DeathAidFundReceipts.Single(x => x.CashReceipt == cashReceipt);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(cashReceipt.ReceiptDate) + amount;

            // business rule
            SyncronizeEntityState();
        }

        public void UpdateDeathAidFundDisbursement(decimal amount, CashDisbursement cashDisbursement)
        {
            // get entity
            var entity = DeathAidFundDisbursements.Single(x => x.CashDisbursement == cashDisbursement);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(cashDisbursement.DisbursementDate) - amount;

            // sync state
            SyncronizeEntityState();
        }
    }
}
