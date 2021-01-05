using System;
using System.Collections.Generic;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Members
{
    public interface IDependentView
    {
        event EventHandler AddingDependent;
        event EventHandler ModifyingDependent;
        event EventHandler RemovingDependent;

        long MemberID { get; set; }
        int LineNumber { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        int RelationID { get; set; }
        string RelationName { get; }

        void PopulateRelationPulldown(IList<Relation> relations);
    }
}
