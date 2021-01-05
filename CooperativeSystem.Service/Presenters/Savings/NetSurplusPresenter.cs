using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Savings
{
    public class NetSurplusPresenter : PresenterTemplate
    {
        private INetSurplusView _view;
        private IRepository<NetSurplus> _repository;
        private NetSurplus _entity;
        private DataContext _db;

        public NetSurplusPresenter(INetSurplusView view)
        {
            _db = new DataContextFactory().CreateDataContext();
            _repository = new GenericRepository<NetSurplus>(_db);
            _view = view;
        }

        public bool Populate()
        {
            try
            {
                _entity = _repository.GetEntity(ns => ns.Year == _view.Year);

                if (_entity != null)
                    _view.Amount = _entity.Amount;
                else
                    _view.Amount = 0M;

                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool Save()
        {
            try
            {
                var hasBeenCommited = _db.GetTable<YearlyDividend>()
                    .Any(yd => yd.Year == _view.Year);

                if (hasBeenCommited)
                {
                    RaiseErrorEvent(string.Format("Dividend for the year of {0} has already been distributed. You can no longer change the net surplus.", _view.Year.ToString()));
                    return false;
                }

                if (_entity == null)
                    _entity = _repository.CreateEntity();

                _entity.Year = _view.Year;
                _entity.Amount = _view.Amount;
                _repository.SaveAll();
                RaiseSusccessEvent("Successful saving.");
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
