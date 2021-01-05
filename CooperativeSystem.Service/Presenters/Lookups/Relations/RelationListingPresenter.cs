using System;
using System.Collections.Generic;
using System.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;

namespace CooperativeSystem.Service.Presenters.Lookups.Relations
{
    public class RelationListingPresenter : PresenterTemplate
    {
        private IRelationListingView _view;

        public RelationListingPresenter(IRelationListingView view)
        {
            _view = view;
        }

        public bool PopulateListing()
        {
            bool result = false;
            try
            {
                var repository = new GenericRepository<Relation>();
                var relations = repository.GetAll()
                    .Select(r => new RelationListingModel()
                    {
                        RelationID = r.RelationID,
                        RelationName = r.RelationName
                    })
                    .ToList();

                _view.PopulateListing(relations);
                result = true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
            return result;
        }
    }
}
