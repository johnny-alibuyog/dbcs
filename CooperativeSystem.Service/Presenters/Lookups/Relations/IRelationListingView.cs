using System.Collections.Generic;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.Lookups.Relations
{
    public interface IRelationListingView
    {
        void PopulateListing(IList<RelationListingModel> modelList);
    }
}
