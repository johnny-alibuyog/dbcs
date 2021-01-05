using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.Notices
{
    public interface INoticeReportView
    {
        NoticeType SelectedNoticeType { get; set; }
        IEnumerable<NoticeType> NoticeTypes { set; }
        void PopulateReports(IList<NoticeReportItem> items);
    }
}
