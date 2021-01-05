using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Reports.AgingLoans
{
    public class AgingLoanModel
    {
        private Loan _loan;
        private FineComputationRate _fineComputationRate;

        public virtual string Name { get; private set; }

        public virtual Nullable<int> AgeInDays { get; private set; }

        public virtual Nullable<int> AgeInMonths { get; private set; }

        public virtual string AgeGroupInDays { get; private set; }

        public virtual string LoanType { get; private set; }

        public virtual Nullable<bool> LoanHasAged { get; private set; }

        public virtual Nullable<decimal> CurrentPayables { get; private set; }

        public virtual Nullable<decimal> OutstandingBalance { get; private set; }

        public virtual Nullable<decimal> AgedPayables { get; private set; }

        public virtual Nullable<decimal> GoodPayables { get; private set; }

        public virtual Nullable<decimal> LatePaymentFine { get; private set; }

        public virtual Nullable<decimal> DelinquentCharge { get; private set; }

        public virtual Nullable<DateTime> LoanDate { get; private set; }

        public virtual Nullable<DateTime> LastPaymentDate { get; private set; }

        public virtual Nullable<DateTime> DueDate { get; private set; }

        public AgingLoanModel() { }

        public AgingLoanModel(AgingLoanItem item) 
        { 
            Name = item.Name;
            AgeInDays = item.AgeInDays;
            AgeInMonths = item.AgeInMonths;
            AgeGroupInDays = item.AgeGroupInDays;
            LoanType = item.LoanType;
            LoanHasAged = item.LoanHasAged;
            CurrentPayables = item.CurrentPayables;
            OutstandingBalance = item.OutstandingBalance;
            AgedPayables = item.AgedPayables;
            GoodPayables = item.GoodPayables;
            LatePaymentFine = item.LatePaymentFine;
            DelinquentCharge = item.DelinquentCharge;
            LoanDate = item.LoanDate;
            LastPaymentDate = item.LastPaymentDate;
            DueDate = item.DueDate;
        }

        public AgingLoanModel(Loan loan, FineComputationRate fineComputationRate)
        {
            _loan = loan;
            _fineComputationRate = fineComputationRate;

            this.Name = loan.Member.LastName + ", " + loan.Member.FirstName + " " + loan.Member.MiddleName;
            this.AgeInDays = (DateTime.Today - _loan.NextPaymentDate.Value).Days;
            this.AgeInMonths = (DateTime.Today - _loan.NextPaymentDate.Value).Days / 30;
            this.AgeGroupInDays = ComputeAgeGroupInDays();
            this.LoanType = _loan.Service.ServiceName;
            this.LoanHasAged = this.AgeInDays > 0;
            this.CurrentPayables = _loan.GetCurrentPayableAmount();
            this.OutstandingBalance = _loan.GetOutstandingBalance();
            this.LatePaymentFine = _loan.ComputeDelayedPaymentFine(_fineComputationRate);
            this.DelinquentCharge = _loan.ComputeDelinquentCharge(_fineComputationRate);
            this.LoanDate = _loan.LoanDate;
            this.LastPaymentDate = _loan.LastPaymentDate;
            this.DueDate = _loan.DueDate;

            if (this.LoanHasAged != null && this.LoanHasAged.Value)
            {
                this.AgedPayables = this.CurrentPayables;
                this.GoodPayables = this.OutstandingBalance - this.AgedPayables;
            }
            else
            {
                this.AgedPayables = 0M;
                this.GoodPayables = this.OutstandingBalance;
            }
        }

        private string ComputeAgeGroupInDays()
        {
            if (AgeInMonths == 0 && AgeInDays > 0)
                AgeInMonths = 1;

            switch (AgeInMonths)
            {
                case 00: return null;
                case 01: return "01 - 30";
                case 02: return "31 - 60";
                case 03: return "61 - 90";
                case 04: return "91 - 120";
                case 05: return "121 - 150";
                case 06: return "151 - 180";
                case 07: return "181 - 210";
                case 08: return "211 - 240";
                case 09: return "241 - 270";
                case 10: return "271 - 300";
                case 11: return "301 - 330";
                case 12: return "331 - 360";
                default: return "360 and up";
            }
        }
    }
}
