using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters
{
    public interface IPostingView
    {
        event EventHandler Posting;

        string Sequence { get; set; }
        string VoucherNumber { get; set; }
    }
}
