using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.WithdrawnMembers
{
    public interface IWithdrawnMembersReportView
    {
        void PopulateReports(IList<WithdrawnMemberModel> withdrawnMembers);
    }
}
