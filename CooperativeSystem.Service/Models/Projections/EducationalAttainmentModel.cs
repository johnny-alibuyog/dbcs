using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models.Projections
{
    public class EducationalAttainmentModel
    {
        public virtual long MemberID { get; set; }
        public virtual int LineNumber { get; set; }
        public virtual string Level { get; set; }
        public virtual string School { get; set; }
        public virtual string Year { get; set; }
    }
}
