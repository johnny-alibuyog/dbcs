using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.DeathAidFundTypes;

namespace CooperativeSystem.Service.Presenters.SpecialFunds.DeathAidFund
{
    public class DeathAidFundConfigurationPresenter : PresenterTemplate
    {
        private IDeathAidFundConfigurationView _view;
        private IRepository<DeathAidFundType> _repository;
        private IList<DeathAidFundType> _models;

        public DeathAidFundConfigurationPresenter(IDeathAidFundConfigurationView view)
        {
            _repository = new GenericRepository<DeathAidFundType>();
            _view = view;
        }

        public void Populate()
        {
            try
            {
                _models = _repository.GetAll().ToList();

                var exists = _models.Any(x => x.Id == DeathAidFundTypeCodes.Beneficiary);
                if (!exists)
                {
                    var entity = _repository.CreateEntity();
                    entity.Id = DeathAidFundTypeCodes.Beneficiary;
                    entity.Name = "Beneficiary";
                    entity.PerMemberAid = 10M;
                    _models.Add(entity);
                }

                exists = _models.Any(x => x.Id == DeathAidFundTypeCodes.Member);
                if (!exists)
                {
                    var entity = _repository.CreateEntity();
                    entity.Id = DeathAidFundTypeCodes.Member;
                    entity.Name = "Member";
                    entity.PerMemberAid = 50M;
                    _models.Add(entity);
                }

                _view.Beneficiary = _models.Single(x => x.Id == DeathAidFundTypeCodes.Beneficiary).PerMemberAid;
                _view.Member = _models.Single(x => x.Id == DeathAidFundTypeCodes.Member).PerMemberAid;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
        }

        public bool Update()
        {
            try
            {
                var beneficiary = _models.Single(x => x.Id == DeathAidFundTypeCodes.Beneficiary);
                var member = _models.Single(x => x.Id == DeathAidFundTypeCodes.Member);

                beneficiary.PerMemberAid = _view.Beneficiary;
                member.PerMemberAid = _view.Member;

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
