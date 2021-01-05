using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Presenters.Lookups.DeductionTypes;
using CooperativeSystem.Service.Utilities;
using CooperativeSystem.Service.Presenters.Lookups.Services;

namespace CooperativeSystem.Service.Models
{
    partial class Loan
    {
        private Nullable<decimal> _totalPayableAmount;
        private Nullable<decimal> _totalServiceFees;

        #region Routine Helpers

        private int GetConsumedPeriod()
        {
            var consumedDays = (DateTime.Today - LoanDate.TruncateTime()).TotalDays;
            var consumedTerms = consumedDays / PaymentMode.Days;

            // has passed to the next period of payment
            if (consumedTerms > 0D && consumedTerms.HasFractionalValue())
                consumedTerms++;

            return (int)consumedTerms;
        }

        private void SyncronizeEntityState(DateTime transactionDate)
        {
            CurrentBalance = GetOutstandingBalance();
            Settled = (decimal.Round(CurrentBalance) <= 0M);

            // union transaction dates
            var paymentTransactions = LoanReceipts
                .Select(x => new
                {
                    Amount = x.Amount,
                    TransactionDate = x.CashReceipt.ReceiptDate
                })
                .Concat(LoanAdjustments
                .Select(x => new
                {
                    Amount = x.Amount,
                    TransactionDate = x.Adjustment.AdjustmentDate
                }))
                .Concat(LoanDividendAdjustments
                .Select(x => new
                {
                    Amount = x.Amount,
                    TransactionDate = x.Adjustment.AdjustmentDate
                }));

            // get the last payement transaction date
            if (paymentTransactions.Any())
                LastPaymentDate = paymentTransactions.Max(x => x.TransactionDate);

            // this case only happens on adjustments.
            if (LastPaymentDate != null && LastPaymentDate > transactionDate)
                transactionDate = LastPaymentDate.Value;

            if (Settled)
            {
                SettlementDate = transactionDate;
                NextPaymentDate = null;
            }
            else
            {
                SettlementDate = null;

                //// do not modify next payment date if date is less than lastReceiptDate.
                //// this case only happens on adjustments.
                //if (lastTransactionDate != null && lastTransactionDate > transactionDate)
                //    return;

                // compute for the next payment date
                //var days = PaymentMode.Days;
                //var terms = ((transactionDate.TruncateTime() - LoanDate.TruncateTime()).Days / days) + 1;
                //var nextPaymentDate = LoanDate.AddDays(terms * days);
                //NextPaymentDate = nextPaymentDate < DueDate ? nextPaymentDate : DueDate;

                // do not set NextPaymentDate if transactionDate > LastPaymentDate 
                if (transactionDate > DueDate)
                {
                    if (NextPaymentDate == null)
                        NextPaymentDate = DueDate;

                    return;
                }

                var days = PaymentMode.Days;
                var terms = (int)(GetPaidAmount() / Amortization);
                var tempDate = LoanDate.AddDays((terms + 1) * days);
                NextPaymentDate = tempDate < DueDate ? tempDate : DueDate;
            }
        }

        private decimal GetBalanceBefore(DateTime date)
        {
            return GetTotalPayableAmount() -
                GetReceiptsBefore(date).Sum(x => x.Amount) -
                GetAdjustmentsBefore(date).Sum(x => x.Amount) -
                GetDividendAdjustmentsBefore(date).Sum(x => x.Amount);
        }

        private IEnumerable<LoanReceipt> GetReceiptsBefore(DateTime date)
        {
            return LoanReceipts
                .Where(x => x.CashReceipt.ReceiptDate < date)
                .OrderBy(x => x.CashReceipt.ReceiptDate);
        }

        private IEnumerable<LoanAdjustment> GetAdjustmentsBefore(DateTime date)
        {
            return LoanAdjustments
                .Where(x => x.Adjustment.AdjustmentDate < date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<LoanDividendAdjustment> GetDividendAdjustmentsBefore(DateTime date)
        {
            return LoanDividendAdjustments
                .Where(x => x.Adjustment.AdjustmentDate < date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<LoanDisbursement> GetDisbursementsBefore(DateTime date)
        {
            return LoanDisbursements
                .Where(x => x.CashDisbursement.DisbursementDate < date)
                .OrderBy(x => x.CashDisbursement.DisbursementDate);
        }

        private IEnumerable<LoanReceipt> GetReceiptsAfter(DateTime date)
        {
            return LoanReceipts
                .Where(x => x.CashReceipt.ReceiptDate > date)
                .OrderBy(x => x.CashReceipt.ReceiptDate);
        }

        private IEnumerable<LoanAdjustment> GetAdjustmentsAfter(DateTime date)
        {
            return LoanAdjustments
                .Where(x => x.Adjustment.AdjustmentDate > date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<LoanDividendAdjustment> GetDividendAdjustmentsAfter(DateTime date)
        {
            return LoanDividendAdjustments
                .Where(x => x.Adjustment.AdjustmentDate > date)
                .OrderBy(x => x.Adjustment.AdjustmentDate);
        }

        private IEnumerable<LoanDisbursement> GetDisbursementsAfter(DateTime date)
        {
            return LoanDisbursements
                .Where(x => x.CashDisbursement.DisbursementDate > date)
                .OrderBy(x => x.CashDisbursement.DisbursementDate);
        }

        private void CheckLatePaymentChargeComputationCompletion()
        {
            if (DateTime.Today >= this.DueDate)
                this.IsLatePaymentChargeCalculationCompleted = true;
        }

        //private void AdjustBalancesAfter(DateTime date, decimal changeAmount)
        //{
        //    var receiptsAfter = GetReceiptsAfter(date);
        //    var dividendsAfter = GetDividendAdjustmentsAfter(date);

        //    // adjust balances of transactions after
        //    foreach (var item in receiptsAfter)
        //        item.Balance += changeAmount; // += operator must be used 

        //    foreach (var item in dividendsAfter)
        //        item.Balance += changeAmount; // += operator must be used 
        //}

        #endregion

        #region Aggregate Modifiers

        public void AddLoanReceipt(LoanReceipt entity)
        {
            // compute for the periodical balance 
            entity.Balance = GetBalanceBefore(entity.CashReceipt.ReceiptDate) - entity.Amount;

            // add
            LoanReceipts.Add(entity);

            // syncronize entity state
            SyncronizeEntityState(entity.CashReceipt.ReceiptDate);
        }

        public void AddLoanAdjustment(LoanAdjustment entity)
        {
            // compute for the periodical balance 
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) - entity.Amount;

            // add
            LoanAdjustments.Add(entity);

            // syncronize entity state
            SyncronizeEntityState(entity.Adjustment.AdjustmentDate);
        }

        public void AddLoanDividendAdjustment(LoanDividendAdjustment entity)
        {
            // compute for the periodical balance 
            entity.Balance = GetBalanceBefore(entity.Adjustment.AdjustmentDate) - entity.Amount;

            // add
            LoanDividendAdjustments.Add(entity);

            // syncronize entity state
            SyncronizeEntityState(entity.Adjustment.AdjustmentDate);
        }

        public void AddLoanDisbursement(LoanDisbursement entity)
        {
            // compute for the periodical balance
            entity.Balance = GetBalanceBefore(entity.CashDisbursement.DisbursementDate); // redundunt + entity.Amount;

            // add
            LoanDisbursements.Add(entity);

            // syncronize entity state
            SyncronizeEntityState(entity.CashDisbursement.DisbursementDate);
        }

        public void AddLatePaymentFineReceipt(LatePaymentFineReceipt entity)
        {
            LatePaymentFineReceipts.Add(entity);

            this.UnpaidLatePaymentCharge = entity.GetUnpaidBalance();

            this.CheckLatePaymentChargeComputationCompletion();
        }

        public void AddDelinquentFineReceipts(DelinquentFineReceipt entity)
        {
            DelinquentFineReceipts.Add(entity);

            this.UnpaidDelinquentCharge = entity.GetUnpaidBalance();
        }

        public void UpdateLoanReceipt(decimal amount, CashReceipt cashReceipt)
        {
            // get entity
            var entity = LoanReceipts.Single(x => x.CashReceipt == cashReceipt);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(cashReceipt.ReceiptDate) - amount;

            // syncronize entity state
            SyncronizeEntityState(cashReceipt.ReceiptDate);
        }

        public void UpdateLoanAdjustment(decimal amount, Adjustment adjustment)
        {
            // get entity
            var entity = LoanAdjustments.Single(x => x.Adjustment == adjustment);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(adjustment.AdjustmentDate) - amount;

            // syncronize entity state
            SyncronizeEntityState(adjustment.AdjustmentDate);

            //var cashReceipt = adjustment.CashReceipt;

            //// apply adjustment
            //var exists = LoanReceipts.Any(x => x.CashReceipt == cashReceipt);
            //if (exists)
            //    UpdateLoanReceipt(newAmount, cashReceipt);
            //else
            //    AddLoanReceipt(new LoanReceipt() { Amount = newAmount, CashReceipt = cashReceipt });

            //// edit
            //var entity = LoanAdjustments.Single(x => x.Adjustment == adjustment);
            //entity.NewAmount = newAmount;
            //entity.OriginalAmount = originalAmount;

            //// adjust affected periodical balances
            //AdjustBalancesAfter(cashReceipt.ReceiptDate, entity.ChangeAmount);
        }

        public void UpdateLoanDividendAdjustment(decimal amount, Adjustment adjustment)
        {
            // get entity
            var entity = LoanDividendAdjustments.Single(x => x.Adjustment == adjustment);

            // update entity
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(adjustment.AdjustmentDate) - amount;

            // syncronize entity state
            SyncronizeEntityState(adjustment.AdjustmentDate);
        }

        public void UpdateLoanDisbursement(decimal amount, CashDisbursement cashDisbursement)
        {
            // get entity
            var entity = LoanDisbursements.Single(x => x.CashDisbursement == cashDisbursement);

            // update entity
            _totalPayableAmount = null;
            entity.Amount = amount;
            entity.Balance = GetBalanceBefore(cashDisbursement.DisbursementDate); //redundunt + amount;

            // syncronize entity state
            SyncronizeEntityState(cashDisbursement.DisbursementDate);
        }

        public void UpdateLatePaymentFineReceipt(decimal amount, decimal computedAmount, Nullable<decimal> previousUnpaid, bool condone, CashReceipt cashReceipt)
        {
            // get entity
            var entity = LatePaymentFineReceipts.Single(x => x.CashReceipt == cashReceipt);

            // update entity
            entity.Amount = amount;
            entity.ComputedAmount = computedAmount;
            entity.PreviousUnpaid = previousUnpaid;
            entity.Condone = condone;

            this.UnpaidLatePaymentCharge = entity.GetUnpaidBalance();

            this.CheckLatePaymentChargeComputationCompletion();
        }

        public void UpdateDelinquentFineReceipts(decimal amount, decimal computedAmount, Nullable<decimal> previousUnpaid, bool condone, CashReceipt cashReceipt)
        {
            // get entity
            var entity = DelinquentFineReceipts.Single(x => x.CashReceipt == cashReceipt);

            // update entity
            entity.Amount = amount;
            entity.ComputedAmount = computedAmount;
            entity.PreviousUnpaid = previousUnpaid;
            entity.Condone = condone;

            this.UnpaidDelinquentCharge = entity.GetUnpaidBalance();
        }

        #endregion

        public virtual decimal GetTotalPayableAmount()
        {
            if (_totalPayableAmount == null)
            {
                _totalPayableAmount = new Nullable<decimal>();
                if (LoanDeductionTypeID == LoanDeductionTypeCodes.AddOn)
                    _totalPayableAmount = LoanAmount + GetTotalServiceFees();
                else if (LoanDeductionTypeID == LoanDeductionTypeCodes.Deducted)
                    _totalPayableAmount = LoanAmount;
            }
            return _totalPayableAmount.Value;
        }

        public virtual decimal GetTotalServiceFees()
        {
            if (_totalServiceFees == null)
            {
                _totalServiceFees = new Nullable<decimal>();
                _totalServiceFees = ServiceFee + CollectionFee +
                    CapitalBuildup + LoanGuaranteeFund + Interest;
            }
            return _totalServiceFees.Value;
        }

        public virtual decimal GetCurrentPayableAmount()
        {
            var outstandingBalance = GetOutstandingBalance();
            var consumablePeriod = Terms * PaymentMode.LoanPaymentsPerMonth;
            var consumedPeriod = GetConsumedPeriod();

            if (Settled)
                return 0M;

            if (consumedPeriod < 1)
                return 0M;

            if (consumedPeriod > consumablePeriod)
                return outstandingBalance;

            var paidAmount = GetPaidAmount();
            var amount = (consumedPeriod * Amortization) - paidAmount;

            // validate with outstanding balance
            var difference = outstandingBalance - amount;

            // remove sign
            if (difference < 0)
                difference *= -1;

            if (difference < 1)
                amount = outstandingBalance;

            return (amount < 0M) ? 0M : amount;
        }

        public virtual Nullable<DateTime> GetCurrentPayableDate()
        {
            Nullable<DateTime> dueDate = null;
            if (!Settled)
            {
                dueDate = new Nullable<DateTime>();
                dueDate = DateTime.Today < DueDate.TruncateTime()
                    ? DateTime.Today
                    : DueDate.TruncateTime();
            }
            return dueDate;
        }

        public virtual decimal GetPaidAmount()
        {
            var paidAmount =
                LoanReceipts.Sum(x => x.Amount) +
                LoanAdjustments.Sum(x => x.Amount) +
                LoanDividendAdjustments.Sum(x => x.Amount);

            return paidAmount;
        }

        public virtual decimal GetPercentagePaid()
        {
            var paid = GetPaidAmount();
            var payable = GetTotalPayableAmount();
            return (paid / payable) * 100;
        }

        public virtual decimal GetOutstandingBalance()
        {
            var payable = GetTotalPayableAmount();
            var paid = GetPaidAmount();

            var balance = payable - paid;
            if (balance < 0M)
                balance = 0M;

            return balance;
        }

        public virtual bool IsDelayed()
        {
            if (Settled)
                return false;

            var currentPayableDate = GetCurrentPayableDate();
            if (NextPaymentDate == null || currentPayableDate == null)
                return false;

            var consumedPeriod = (currentPayableDate.Value - NextPaymentDate.Value).Days;
            var gracePeriod = PaymentMode.GracePeriod;

            return (consumedPeriod > gracePeriod);
        }

        public virtual Nullable<TimeSpan> GetPeriodDelayed()
        {
            Nullable<TimeSpan> periodDelayed = null;
            if (this.IsDelayed())
            {
                var currentPayableDate = GetCurrentPayableDate();

                periodDelayed = new Nullable<TimeSpan>();
                periodDelayed = currentPayableDate - NextPaymentDate;
            }
            return periodDelayed;
        }

        public virtual int GetDaysDelayed()
        {
            var periodDelayed = GetPeriodDelayed();
            return periodDelayed != null ? periodDelayed.Value.Days : 0;
        }

        public virtual decimal ComputeDelayedPaymentFine(FineComputationRate fineComputationRate)
        {
            var fine = this.UnpaidLatePaymentCharge ?? 0M;
            if (this.IsDelayed())
            {
                if (LoanServiceID == ServiceCodes.EmergencyLoan)
                {
                    // no fine for emergency loan since 
                    // this loan is payable only in one month
                    fine = 0M;
                }
                else
                {
                    if (!this.IsLatePaymentChargeCalculationCompleted.HasValue ||
                        !this.IsLatePaymentChargeCalculationCompleted.Value)
                    {
                        var paymentsPerMonth = PaymentMode.LoanPaymentsPerMonth;
                        var paymentModeRate = (fineComputationRate.Rate / 100) / paymentsPerMonth;

                        //var finedAmount = this.UnpaidPayables ?? 0M;
                        var finableAmount = GetCurrentPayableAmount(); // - Amortization;

                        if (this.DueDate > DateTime.Today)
                            finableAmount -= Amortization;

                        //while (finableAmount > finedAmount)
                        while (finableAmount > 0M)
                        {
                            fine += finableAmount * paymentModeRate;
                            finableAmount -= finableAmount > Amortization ? Amortization : finableAmount;
                        }
                    }
                }
            }

            if (fine < 0M)
                fine = 0M;

            return fine;


            //var fine = 0M;
            //if (this.IsDelayed())
            //{
            //    //############################################################################
            //    //const int DAYS_PER_MONTH = 30;
            //    //var paymentIntervalInDays = PaymentMode.Days;
            //    //var fineComputationRatePerMonth = fineComputationRate.Rate;
            //    //var paymentModeRate = (fineComputationRatePerMonth / 100) / (DAYS_PER_MONTH / paymentIntervalInDays);

            //    //var accumulation = 0M;
            //    //var finableAmount = OutstandingBalance;
            //    //var i = 1;
            //    //while (finableAmount > 0M)
            //    //{
            //    //    var temp = finableAmount > Amortization ? Amortization : finableAmount;
            //    //    accumulation += temp;
            //    //    finableAmount -= temp;
            //    //    fine += accumulation * paymentModeRate;
            //    //    //Console.WriteLine(i);
            //    //    i++;
            //    //}
            //    //############################################################################

            //    //############################################################################
            //    if (LoanServiceID == ServiceCodes.EmergencyLoan)
            //    {
            //        const int DAYS_PER_MONTH = 30;
            //        var daysDelayed = GetDaysDelayed();
            //        var monthsDelayed = daysDelayed / DAYS_PER_MONTH;
            //        if (monthsDelayed > 0)
            //            fine = monthsDelayed * fineComputationRate.EmergencyLoanFine;
            //    }
            //    else
            //    {
            //        var paymentsPerMonth = PaymentMode.LoanPaymentsPerMonth;
            //        var paymentModeRate = (fineComputationRate.Rate / 100) / paymentsPerMonth;

            //        var accumulation = 0M;
            //        var finableAmount = GetCurrentPayableAmount();
            //        var i = 1;
            //        while (finableAmount > 0M)
            //        {
            //            var temp = finableAmount > Amortization
            //                ? Amortization
            //                : finableAmount;
            //            accumulation += temp;
            //            finableAmount -= temp;
            //            fine += accumulation * paymentModeRate;
            //            //Console.WriteLine(i);
            //            i++;
            //        }
            //    }
            //    //############################################################################

            //    var paidFine = this.LatePaymentFineReceipts
            //        .Where(x => x.Accumulated == true)
            //        .Sum(x => x.Condone == true
            //            ? x.ComputedAmount.Value
            //            : x.Amount
            //        );

            //    fine -= paidFine;
            //}
            //else
            //{
            //    // get previously unpaid fines
            //    fine = this.LatePaymentFineReceipts
            //        .Where(x =>
            //            x.Accumulated == true &&
            //            x.ComputedAmount != null &&
            //            x.Condone == false
            //        )
            //        .Sum(x => x.ComputedAmount.Value - x.Amount);
            //}

            //if (fine < 0M)
            //    fine = 0M;

            //return fine;
        }

        public virtual bool IsDelinquent()
        {
            if (Settled)
                return false;

            return (DateTime.Today > DueDate.TruncateTime());
        }

        public virtual Nullable<TimeSpan> GetPeriodDelinquent()
        {
            var period = (Nullable<TimeSpan>)null;
            if (this.IsDelinquent())
            {
                period = new Nullable<TimeSpan>();
                period = DateTime.Today - DueDate.TruncateTime();
            }
            return period;
        }

        public virtual int GetDaysDelinquent()
        {
            var periodDelinquent = GetPeriodDelinquent();
            return periodDelinquent != null ? periodDelinquent.Value.Days : 0;
        }

        public virtual decimal ComputeDelinquentCharge(FineComputationRate fineComputationRate)
        {
            //var charge = this.UnpaidDelinquentCharge ?? 0M;
            var charge = 0M;
            if (this.IsDelinquent())
            {
                if (LoanServiceID == ServiceCodes.EmergencyLoan)
                {
                    if (fineComputationRate.EmergencyLoanFineComputationBase == null)
                        return charge;

                    const int DAYS_PER_MONTH = 30;
                    var daysDelinquent = GetDaysDelinquent();
                    var monthsDelinquent = Convert.ToDouble(daysDelinquent) / Convert.ToDouble(DAYS_PER_MONTH);
                    if (monthsDelinquent > 0D && monthsDelinquent.HasFractionalValue())
                        monthsDelinquent++;

                    var chargePerMonth = (this.LoanAmount / fineComputationRate.EmergencyLoanFineComputationBase.Value) * fineComputationRate.EmergencyLoanFine;

                    charge = (int)monthsDelinquent * chargePerMonth;
                }
                else
                {
                    const double DAYS_PER_MONTH = 30;
                    var periodDelinquent = GetPeriodDelinquent();
                    var monthsDelinquent = (decimal)(periodDelinquent.Value.TotalDays / DAYS_PER_MONTH);
                    var fineMonthlyRate = fineComputationRate.Rate / 100;
                    var outstandingBalance = GetOutstandingBalance();
                    charge = outstandingBalance * monthsDelinquent * fineMonthlyRate;
                }
            }

            charge -= this.DelinquentFineReceipts.Sum(x => x.GetCreditedAmount());

            if (charge < 0M)
                charge = 0M;

            return charge;

            //var charge = 0M;
            //if (this.IsDelinquent())
            //{
            //    //#####################################################################################################
            //    //var daysInAMonth = 30;
            //    //var paymentIntervalsInDays = PaymentMode.Days;
            //    //var termsDelinquent = (DaysDelinquent / paymentIntervalsInDays);
            //    //var fineComputationRatePerMonth = fineComputationRate.Rate;
            //    //var paymentModeRate = (fineComputationRatePerMonth / 100) / (daysInAMonth / paymentIntervalsInDays);
            //    //charge = paymentModeRate * OutstandingBalance * termsDelinquent;
            //    //#####################################################################################################

            //    if (LoanServiceID == ServiceCodes.EmergencyLoan)
            //    {
            //        if (fineComputationRate.EmergencyLoanFineComputationBase == null)
            //            return charge;

            //        const int DAYS_PER_MONTH = 30;
            //        var daysDelinquent = GetDaysDelinquent();
            //        var monthsDelinquent = Convert.ToDouble(daysDelinquent) / Convert.ToDouble(DAYS_PER_MONTH);
            //        if (monthsDelinquent > 0D && monthsDelinquent.HasFractionalValue())
            //            monthsDelinquent++;

            //        var chargePerMonth = (this.LoanAmount / fineComputationRate.EmergencyLoanFineComputationBase.Value) * fineComputationRate.EmergencyLoanFine;

            //        charge = (int)monthsDelinquent * chargePerMonth;
            //    }
            //    else
            //    {
            //        //#####################################################################################################
            //        const double DAYS_PER_MONTH = 30;
            //        var periodDelinquent = GetPeriodDelinquent();
            //        var monthsDelinquent = (decimal)(periodDelinquent.Value.TotalDays / DAYS_PER_MONTH);
            //        var fineMonthlyRate = fineComputationRate.Rate / 100;
            //        var outstandingBalance = GetOutstandingBalance();
            //        charge = outstandingBalance * monthsDelinquent * fineMonthlyRate;
            //        //#####################################################################################################

            //        var paidCharge = this.DelinquentFineReceipts
            //          .Where(x => x.Accumulated == true)
            //          .Sum(x => x.Condone == true
            //              ? x.ComputedAmount.Value
            //              : x.Amount
            //          );

            //        charge -= paidCharge;
            //    }
            //}
            //else
            //{
            //    // get previously unpaid fines
            //    charge = this.DelinquentFineReceipts
            //        .Where(x =>
            //            x.Accumulated == true &&
            //            x.ComputedAmount != null &&
            //            x.Condone == false
            //        )
            //        .Sum(x => x.ComputedAmount.Value - x.Amount);
            //}

            //if (charge < 0M)
            //    charge = 0M;

            //return charge;
        }

        partial void OnLoanDateChanged()
        {
            _LoanDate = _LoanDate.TruncateTime();
        }

        partial void OnDueDateChanged()
        {
            _DueDate = _DueDate.TruncateTime();
        }

        partial void OnNextPaymentDateChanged()
        {
            if (_NextPaymentDate != null)
                _NextPaymentDate = _NextPaymentDate.Value.TruncateTime();
        }

        partial void OnSettlementDateChanged()
        {
            if (_SettlementDate != null)
                _SettlementDate = _SettlementDate.Value.TruncateTime();
        }
    }
}
