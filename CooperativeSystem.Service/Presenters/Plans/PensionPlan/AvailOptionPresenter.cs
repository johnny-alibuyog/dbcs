using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Plans.PensionPlan
{
    public class AvailOptionPresenter : PresenterTemplate
    {
        private IAvailOptionView _view;

        #region Routine Helpers

        //private void InitializePersistenceManager()
        //{
        //    _repository = new GenericRepository<PensionPlanAvailOption>();
        //}

        private void SetValuesToModel(PensionPlanAvailOption entity, IAvailOptionView value)
        {
            entity.AvailOptionID = value.AvailOptionID;
            entity.AvailOptionName = value.AvailOptionName;
            entity.AvailOptionDescription = value.AvailOptionDescription;
            entity.AwardAmount = value.AwardAmount;
            entity.AgingPeriod = value.AgingPeriod;
            entity.WithMonthlyPension = value.WithMonthlyPension;
        }

        private void SetValuesToView(IAvailOptionView view, PensionPlanAvailOption value)
        {
            view.AvailOptionID = value.AvailOptionID;
            view.AvailOptionName = value.AvailOptionName;
            view.AvailOptionDescription = value.AvailOptionDescription;
            view.AwardAmount = value.AwardAmount;
            view.AgingPeriod = value.AgingPeriod;
            view.WithMonthlyPension = value.WithMonthlyPension;
        }

        private void InitializeViewValue(IAvailOptionView view)
        {
            view.AvailOptionID = 0;
            view.AvailOptionName = string.Empty;
            view.AvailOptionDescription = string.Empty;
            view.AwardAmount = 0M;
            view.AgingPeriod = 0;
            view.WithMonthlyPension = false;
        }

        #endregion

        public AvailOptionPresenter(IAvailOptionView view)
        {
            _view = view;
        }

        public bool NewAvailOption()
        {
            try
            {
                var repository = new GenericRepository<PensionPlanAvailOption>();
                var entity = repository.CreateEntity();

                SetValuesToView(_view, entity);
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool LoadAvailOption(int availOptionID)
        {
            try
            {
                var repository = new GenericRepository<PensionPlanAvailOption>();
                var entity = repository.GetEntity(x => x.AvailOptionID == availOptionID);

                SetValuesToView(_view, entity);
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool Insert()
        {
            try
            {
                var repository = new GenericRepository<PensionPlanAvailOption>();
                var entity = repository.CreateEntity();

                SetValuesToModel(entity, _view);
                repository.SaveAll();

                _view.AvailOptionID = entity.AvailOptionID; // reflect with the identity value
                
                RaiseSusccessEvent("Successful saving.");
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                var repository = new GenericRepository<PensionPlanAvailOption>();
                var entity = repository.GetEntity(ao => ao.AvailOptionID == _view.AvailOptionID);

                SetValuesToModel(entity, _view);
                repository.SaveAll();

                RaiseSusccessEvent("Successful saving.");
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool Delete()
        {
            try
            {
                var repository = new GenericRepository<PensionPlanAvailOption>();
                var entity = repository.GetEntity(x => x.AvailOptionID == _view.AvailOptionID);

                repository.MarkForDeletion(entity);
                repository.SaveAll();

                RaiseSusccessEvent("Successful deleting.");
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }
    }
}
