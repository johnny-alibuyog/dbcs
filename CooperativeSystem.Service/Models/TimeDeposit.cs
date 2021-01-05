using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Utilities;

namespace CooperativeSystem.Service.Models
{
    partial class TimeDeposit
    {

        #region Routine Helpers

        private decimal GetInterest()
        {
            return this.Interest != null ? this.Interest.Value : 0M;
        }

        protected decimal ComputeCurrentBalance()
        {
            return
                TimeDepositReceipts.Sum(r => r.Amount) +
                TimeDepositAdjustments.Sum(r => r.Amount) -
                TimeDepositDisbursements.Sum(d => d.Amount) +
                GetInterest();
        }

        private void SyncronizeEntityStateOnTransaction()
        {
            TimeDepositAmount = ComputeDepositedAmount();
            CurrentBalance = ComputeCurrentBalance();
        }

        private void SyncronizeEntityStateOnDisbursement()
        {
            Consumed = true;
            ConsummationDate = DateTime.Today;
            CurrentBalance = ComputeCurrentBalance();
        }

        internal decimal GetBalanceBefore(DateTime date)
        {
            return
                GetReceiptsBefore(date).Sum(r => r.Amount) +
                GetAdjustmentsBefore(date).Sum(r => r.Amount) -
                GetDisbursementsBefore(date).Sum(d => d.Amount) +
                GetInterest();
        }

        private IEnumerable<TimeDepositReceipt> GetReceiptsBefore(DateTime date)
        {
            return TimeDepositReceipts
                .Where(x => x.CashReceipt.ReceiptDate < date)
                .OrderBy(x => x.CashReceipt.ReceiptDate);
        }

        private IEnumerable<TimeDepositAdjustment> GetAdjustmentsBefore(DateTime date)
        {
            return TimeDepositAdjustments
                .Where(x => x.Adjustment.AdjustmentDate < date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<TimeDepositDisbursement> GetDisbursementsBefore(DateTime date)
        {
            return TimeDepositDisbursements
                .Where(x => x.CashDisbursement.DisbursementDate < date)
                .OrderBy(x => x.CashDisbursement.DisbursementDate);
        }

        #endregion

        //public virtual decimal CurrentBalace
        //{
        //    get { return ComputeCurrentBalance(); }
        //}

        public decimal ComputeDepositedAmount()
        {
            return
                TimeDepositReceipts.Sum(r => r.Amount) +
                TimeDepositAdjustments.Sum(r => r.Amount);
        }

        public void AddTimeDepositReceipt(TimeDepositReceipt entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.CashReceipt.ReceiptDate) + entity.Amount;

            // add
            TimeDepositReceipts.Add(entity);

            // syncronize entity state
            SyncronizeEntityStateOnTransaction();
        }

        public void AddTimeDepositAdjustment(TimeDepositAdjustment entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) + entity.Amount;

            // add
            TimeDepositAdjustments.Add(entity);

            // syncronize entity state
            SyncronizeEntityStateOnTransaction();

            //var cashReceipt = entity.Adjustment.CashReceipt;

            //if (!TimeDepositReceipts.Any(x => x.CashReceipt == cashReceipt))
            //    throw new Exception("You do not have Time Deposit for this receipt. " +
            //        "Adjustment is only allowed in receipts that has Time Deposit transaction.");

            //// apply adjustment
            //UpdateTimeDepositReceipt(entity.NewAmount, cashReceipt, interestRate);

            //// add
            //TimeDepositAdjustments.Add(entity);
        }

        public void AddTimeDepositDisbursement(TimeDepositDisbursement entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.CashDisbursement.DisbursementDate) + entity.Amount;

            // add
            TimeDepositDisbursements.Add(entity);

            // syncronize entity state
            SyncronizeEntityStateOnDisbursement();
        }

        public void UpdateTimeDepositReceipt(decimal amount, CashReceipt cashReceipt)
        {
            // get entity
            var entity = TimeDepositReceipts.Single(x => x.CashReceipt == cashReceipt);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(entity.CashReceipt.ReceiptDate) + entity.Amount;

            // syncronize entity state
            SyncronizeEntityStateOnTransaction();
        }

        public void UpdateTimeDepositAdjustment(decimal amount, Adjustment adjustment)
        {
            // get entity
            var entity = TimeDepositAdjustments.Single(x => x.Adjustment == adjustment);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) + entity.Amount;

            // syncronize entity state
            SyncronizeEntityStateOnTransaction();

            //var cashReceipt = adjustment.CashReceipt;

            //// apply adjustment
            //if (!TimeDepositReceipts.Any(x => x.CashReceipt == cashReceipt))
            //    throw new Exception("You do not have Time Deposit for this receipt. " +
            //        "Adjustment is only allowed in receipts that has Time Deposit transaction.");

            //UpdateTimeDepositReceipt(newAmount, cashReceipt, interestRate);

            //// edit
            //var entity = TimeDepositAdjustments.Single(x => x.Adjustment == adjustment);
            //entity.NewAmount = newAmount;
            //entity.OriginalAmount = originalAmount;
        }

        public void UpdateTimeDepositDisbursement(decimal amount, CashDisbursement cashDisbursement)
        {
            // get entity
            var entity = TimeDepositDisbursements.Single(x => x.CashDisbursement == cashDisbursement);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(entity.CashDisbursement.DisbursementDate) + entity.Amount;

            // syncronize entity state
            SyncronizeEntityStateOnDisbursement();
        }

        public string Status
        {
            get
            {
                if (Consumed)
                    return "Consumed";
                else if (DateTime.Today >= MaturityDate.TruncateTime())
                    return "Matured";
                else
                    return "Un-mature";
            }
        }

        partial void OnDepositDateChanged()
        {
            _DepositDate = _DepositDate.TruncateTime();
        }

        partial void OnMaturityDateChanged()
        {
            _MaturityDate = _MaturityDate.TruncateTime();
        }
    }
}
