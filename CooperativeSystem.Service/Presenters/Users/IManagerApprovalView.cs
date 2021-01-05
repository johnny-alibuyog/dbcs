using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Users
{
    public interface IManagerApprovalView
    {
        string UserID { get; set; }
        string Password { get; set; }
    }
}
