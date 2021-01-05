using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Members
{
    public interface IEducationalAttainmentView
    {
        event EventHandler AddingEducationalAttainment;
        event EventHandler ModifyingEducationalAttainment;
        event EventHandler RemovingEducationalAttainment;

        long MemberID { get; set; }
        int LineNumber { get; set; }
        string Level { get; set; }
        string School { get; set; }
        string Year { get; set; }
    }
}
