using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.SexTypes;

namespace CooperativeSystem.Service.Presenters.Reports.Notices
{
    public class NoticeReportItem
    {
        public virtual Nullable<DateTime> PreviousIssueDate { get; set; }
        public virtual Nullable<DateTime> IssueDate { get; set; }
        public virtual string IssueAddress { get; set; }
        public virtual string IssueTo { get; set; }
        public virtual string SalutationAddress { get; set; }
        public virtual Nullable<DateTime> LoanDate { get; set; }
        public virtual Nullable<DateTime> DueDate { get; set; }
        public virtual Nullable<decimal> AmountDue { get; set; }
        public virtual Nullable<decimal> Fine { get; set; }
        public virtual Nullable<decimal> Charge { get; set; }
        public virtual string Manager { get; set; }

        public NoticeReportItem() { }

        public NoticeReportItem(LoanNotice notice)
        {
            this.PreviousIssueDate = notice.PreviousIssueDate;
            this.IssueDate = notice.IssueDate;
            this.IssueAddress = notice.IssueAddress;
            this.IssueTo = notice.IssueTo;
            this.SalutationAddress = notice.Loan.Member.SexTypeID == SexTypeCodes.Female
                ? "Ms. " + notice.Loan.Member.LastName
                : "Mr. " + notice.Loan.Member.LastName;
            this.LoanDate = notice.LoanDate;
            this.DueDate = notice.DueDate;
            this.AmountDue = notice.AmountDue;
            this.Fine = notice.Fine;
            this.Charge = notice.Charge;
            this.Manager = notice.Manager;
        }
    }
}
