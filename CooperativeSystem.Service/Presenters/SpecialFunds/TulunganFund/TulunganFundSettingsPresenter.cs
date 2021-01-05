using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.SpecialFunds.TulunganFund
{
    public class TulunganFundSettingsPresenter : PresenterTemplate
    {
        private ITulunganFundSettingsView _view;
        private IRepository<TulunganFundSetting> _repository;
        private TulunganFundSetting _model;

        public TulunganFundSettingsPresenter(ITulunganFundSettingsView view)
        {
            _view = view;
            _repository = new GenericRepository<Models.TulunganFundSetting>();
        }

        public void Populate()
        {
            try
            {
                _model = _repository.GetEntity();
                if (_model == null)
                    _model = _repository.CreateEntity();

                _view.PerMemberYearlyContribution = _model.PerMemberYearlyContribution;
                _view.RequiredMinimumShare = _model.ReuiredMinimumShare;
                _view.AwardForShareBelowFifteenThousand = _model.AwardForShareBelowFifteenThousand;
                _view.AwardForShareFifteenThousandAndAbove = _model.AwardForShareFifteenThousandAndAbove;
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
                _model.PerMemberYearlyContribution = _view.PerMemberYearlyContribution;
                _model.ReuiredMinimumShare = _view.RequiredMinimumShare;
                _model.AwardForShareBelowFifteenThousand = _view.AwardForShareBelowFifteenThousand;
                _model.AwardForShareFifteenThousandAndAbove = _view.AwardForShareFifteenThousandAndAbove;

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
