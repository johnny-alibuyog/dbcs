
namespace CooperativeSystem.Service.Presenters.Lookups.Relations
{
    public interface IRelationView
    {
        int RelationID { get; set; }
        string RelationName { get; set; }

        void NewRelation();
        void LoadRelation(int relationID);
    }
}
