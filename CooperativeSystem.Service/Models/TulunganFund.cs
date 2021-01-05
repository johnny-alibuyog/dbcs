using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models
{
    partial class TulunganFund
    {
        #region Routine Helpers

        private decimal ComputeCurrenctBalance()
        {
            return
                TulunganFundReceipts.Sum(x => x.Amount) +
                TulunganFundAdjustments.Sum(x => x.Amount) -
                TulunganFundDisbursements.Sum(x => x.Amount);
        }

        private decimal GetBalanceBefore(DateTime date)
        {
            return
                GetReceiptsBefore(date).Sum(x => x.Amount) +
                GetAdjustmentsBefore(date).Sum(x => x.Amount) -
                GetDisbursementsBefore(date).Sum(x => x.Amount);
        }

        private IEnumerable<TulunganFundReceipt> GetReceiptsBefore(DateTime date)
        {
            return TulunganFundReceipts
                .Where(x => x.CashReceipt.ReceiptDate < date)
                .OrderBy(sdr => sdr.CashReceipt.ReceiptDate);
        }

        private IEnumerable<TulunganFundAdjustment> GetAdjustmentsBefore(DateTime date)
        {
            return TulunganFundAdjustments
                .Where(x => x.Adjustment.AdjustmentDate < date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<TulunganFundDisbursement> GetDisbursementsBefore(DateTime date)
        {
            return TulunganFundDisbursements
                .Where(x => x.CashDisbursement.DisbursementDate < date)
                .OrderBy(x => x.CashDisbursement.DisbursementDate);
        }

        private void SyncronizeEntityState()
        {
            CurrentBalance = ComputeCurrenctBalance();
        }

        #endregion

        public void AddTulunganFundReceipt(TulunganFundReceipt entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.CashReceipt.ReceiptDate) + entity.Amount;

            // add
            TulunganFundReceipts.Add(entity);

            // sync state
            SyncronizeEntityState();
        }

        public void AddTulunganFundAdjustment(TulunganFundAdjustment entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) + entity.Amount;

            // add
            TulunganFundAdjustments.Add(entity);

            // sync state
            SyncronizeEntityState();

            //var cashReceipt = entity.Adjustment.CashReceipt;

            //// apply adjustment
            //var exists = TulunganFundReceipts.Any(x => x.CashReceipt == cashReceipt);
            //if (exists)
            //    UpdateTulunganFundReceipt(entity.NewAmount, cashReceipt);
            //else
            //    AddTulunganFundReceipt(new TulunganFundReceipt() { Amount = entity.NewAmount, CashReceipt = cashReceipt });

            ////add
            //TulunganFundAdjustments.Add(entity);
        }

        public void AddTulunganFundDisbursement(TulunganFundDisbursement entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.CashDisbursement.DisbursementDate) - entity.Amount;

            // add
            TulunganFundDisbursements.Add(entity);

            // sync state
            SyncronizeEntityState();
        }

        public void UpdateTulunganFundReceipt(decimal amount, CashReceipt cashReceipt)
        {
            // get entity
            var entity = TulunganFundReceipts.Single(x => x.CashReceipt == cashReceipt);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(entity.CashReceipt.ReceiptDate) + entity.Amount;

            // business rule
            SyncronizeEntityState();
        }

        public void UpdateTulunganFundAdjustment(decimal amount, Adjustment adjustment)
        {
            // get entity
            var entity = TulunganFundAdjustments.Single(x => x.Adjustment == adjustment);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) + entity.Amount;

            // business rule
            SyncronizeEntityState();

            //var cashReceipt = adjustment.CashReceipt;

            //// apply adjustment
            //var exists = TulunganFundReceipts.Any(x => x.CashReceipt == cashReceipt);
            //if (exists)
            //    UpdateTulunganFundReceipt(newAmount, cashReceipt);
            //else
            //    AddTulunganFundReceipt(new TulunganFundReceipt() { Amount = newAmount, CashReceipt = cashReceipt });

            //// edit
            //var entity = TulunganFundAdjustments.Single(x => x.Adjustment == adjustment);
            //entity.NewAmount = newAmount;
            //entity.OriginalAmount = originalAmount;
        }

        public void UpdateTulunganFundDisbursement(decimal amount, CashDisbursement cashDisbursement)
        {
            // get entity
            var entity = TulunganFundDisbursements.Single(x => x.CashDisbursement == cashDisbursement);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(entity.CashDisbursement.DisbursementDate) - entity.Amount;

            // sync state
            SyncronizeEntityState();
        }
    }
}
