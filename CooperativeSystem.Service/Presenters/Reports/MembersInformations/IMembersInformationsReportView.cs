using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Reports.MembersInformations
{
    public interface IMembersInformationsReportView
    {
        void Populate(IList<MembersInformationsReportModel> items);
    }
}
