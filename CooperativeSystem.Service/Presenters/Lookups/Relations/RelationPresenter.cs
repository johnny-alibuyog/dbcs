using System;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Lookups.Relations
{
    public class RelationPresenter : PresenterTemplate
    {
        private IRepository<Relation> _repository;
        private Relation _model;
        private IRelationView _view;

        public RelationPresenter(IRelationView view)
        {
            _repository = new GenericRepository<Relation>();
            _view = view;
        }

        public bool NewRelation()
        {
            bool result = false;
            try 
            {
            _repository = new GenericRepository<Relation>();
            _model = _repository.CreateEntity();

            _view.RelationID = _model.RelationID;
            _view.RelationName = _model.RelationName;

            result = true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
            return result;
        }

        public bool LoadRelation(int relationID)
        {
            bool result = false;
            try 
            {
                _repository = new GenericRepository<Relation>();
                _model = _repository.GetEntity(r => r.RelationID == relationID);

                _view.RelationID = _model.RelationID;
                _view.RelationName = _model.RelationName;

                result = true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
            return result;
        }
        
        public bool Insert()
        {
            bool result = false;
            try
            {
                //_model = _repository.CreateInstance();
                //_model.RelationID = _view.RelationID;
                _model.RelationName = _view.RelationName;

                _repository.SaveAll();
                RaiseSusccessEvent("Successful saving.");
                _view.RelationID = _model.RelationID;
                result = true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
            return result;
        }

        public bool Update()
        {
            bool result = false;
            try
            {
                _model.RelationID = _view.RelationID;
                _model.RelationName = _view.RelationName;

                _repository.SaveAll();
                RaiseSusccessEvent("Successful saving.");
                result = true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
            return result;
        }

        public bool Delete()
        {
            bool result = false;
            try
            {
                _model.RelationID = _view.RelationID;
                _model.RelationName = _view.RelationName;

                _repository.MarkForDeletion(_model);
                _repository.SaveAll();
                RaiseSusccessEvent("Successful deleting.");
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
