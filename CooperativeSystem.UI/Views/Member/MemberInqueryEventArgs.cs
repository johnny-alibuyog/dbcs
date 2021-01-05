using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.UI.Views.Member
{
    public class MemberInquiryEventArgs : EventArgs
    {
        public long MemberID { get; set; }

        public MemberInquiryEventArgs(long memberID)
        {
            MemberID = memberID;
        }
    }

}
