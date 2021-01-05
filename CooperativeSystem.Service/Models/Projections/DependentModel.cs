using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models.Projections
{
    [Serializable]
    public class DependentModel
    {
        public virtual long MemberID { get; set; }
        public virtual int LineNumber { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual int RelationID { get; set; }
        public virtual string RelationName { get; set; }

        public virtual string FullName
        {
            get
            {
                if ((this.LastName + this.FirstName + this.MiddleName).Trim() != string.Empty)
                    return string.Format("{0}, {1} {2}", this.LastName, this.FirstName, this.MiddleName);
                else
                    return string.Empty;
            }
        }
    }
}
