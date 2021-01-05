using System;
using System.Linq;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Members
{
    public class DependentPresenter : PresenterTemplate
    {
        IRepository<Relation> _repository;
        IDependentView _view;

        public DependentPresenter(IDependentView view)
        {
            try
            {
                _repository = new GenericRepository<Relation>();
                _view = view;
                _view.PopulateRelationPulldown(_repository.GetAll().ToList());
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
        }
    }
}
