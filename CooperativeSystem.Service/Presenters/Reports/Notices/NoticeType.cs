using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Notices
{
    public class NoticeType
    {
        public virtual int Key { get; private set; }
        public virtual int Number { get; private set; }
        public virtual string Value { get; private set; }
        public virtual string ReportName { get; private set; }

        private NoticeType(int key, int number, string value, string reportName)
        {
            this.Key = key;
            this.Number = number;
            this.Value = value;
            this.ReportName = reportName;
        }

        public static readonly NoticeType FirstNotice = new NoticeType(1, 1, "First Notice", "FirstNoticeReport.rdlc");
        public static readonly NoticeType SecondNotice = new NoticeType(2, 2, "Second Notice", "SecondNoticeReport.rdlc");
        public static readonly NoticeType FinalNotice = new NoticeType(3, 3, "Final Notice", "FinalNoticeReport.rdlc");
        public static readonly IEnumerable<NoticeType> All = new List<NoticeType>()
            {
                FirstNotice,
                SecondNotice,
                FinalNotice
            };
    }

}
