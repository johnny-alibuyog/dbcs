using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models.Projections
{
    public class InterestRebateModel
    {
        private const int DAYS_IN_A_MONTH = 30;

        public virtual DateTime LoanDate { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual DateTime SettlementDate { get; set; }
        public virtual string PaymentMode { get; set; }
        public virtual int Terms { get; set; }
        public virtual decimal LoanAmount { get; set; }
        public virtual decimal InterestRate { get; set; }
        public virtual decimal Interest { get; set; }
        public virtual int RebateExemptedTerms { get; set; }

        public virtual decimal InterestRebate
        {
            get { return (this.MonthsRebatable * this.InterestPerMonth); }
        }

        public virtual int MonthsRebatable
        {
            get
            {
                var applicatbleStart = this.NumberOfDaysUponRebateExempted > this.NumberOfDaysUponSettlement
                    ? this.NumberOfDaysUponRebateExempted
                    : this.NumberOfDaysUponSettlement;

                return (this.NumberOfDaysUponDue - applicatbleStart) / DAYS_IN_A_MONTH;
            }
        }

        public virtual decimal InterestPerMonth
        {
            get { return (Interest / Terms); }
        }

        public virtual int NumberOfDaysUponSettlement
        {
            get { return (SettlementDate - LoanDate).Days; }
        }

        public virtual int NumberOfDaysUponRebateExempted
        {
            get { return this.RebateExemptedTerms * DAYS_IN_A_MONTH; }
        }

        public virtual int NumberOfDaysUponDue
        {
            get { return (DueDate - LoanDate).Days; }
        }
    }
}
