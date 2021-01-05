using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.AccountStatuses;
using CooperativeSystem.Service.Presenters.Lookups.DeathAidFundTypes;
using CooperativeSystem.Service.Presenters.Lookups.MembershipCategories;
using CooperativeSystem.Service.Presenters.Lookups.Services;

namespace CooperativeSystem.Service.Presenters.SpecialFunds.DeathAidFund
{
    public class DeathAidFundWithdrawalAssessmentPresenter : PresenterTemplate
    {
        private IDeathAidFundWithdrawalAssessmentView _view;
        private IList<DeathAidFundWithdrawalAssessmentItem> _items;

        public virtual IList<DeathAidFundWithdrawalAssessmentItem> Items
        {
            get { return _items; }
        }

        public DeathAidFundWithdrawalAssessmentPresenter(IDeathAidFundWithdrawalAssessmentView view)
        {
            _view = view;
        }

        public bool Load()
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();
                var dafTypes = db.GetTable<Models.DeathAidFundType>();

                _view.PopulateDeathAidFundTypes(dafTypes.ToList());
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool LoadWithdrawAmount()
        {
            try
            {
                _view.IsAssessed = false;

                var db = new DataContextFactory().CreateDataContext();
                //var dafCollection = db.GetTable<Models.Member>()
                //    .Where(Member.TheMembersEntitledForDeathAidFund())
                //    .Select(m => new { dafTypes.Single(x => x.Id == deathAidFundTypeId) });

                var hasBalance = db.GetTable<Models.DeathAidFund>()
                    .Where(x => 
                        x.MemberID == _view.MemberID && 
                        x.CurrentBalance > 0M)
                    .Any();

                if (!hasBalance)
                {
                    RaiseErrorEvent("You are not qualified to avail Death Aid Fund since you're current balance is now Zero(0) or less.");
                    return false;
                }

                var dafType = db.GetTable<Models.DeathAidFundType>().Single(x => x.Id == _view.DeathAidFundTypeId);

                _items = db.GetTable<Models.Member>()
                    .Where(m =>
                        m.DeathAidFund != null &&
                        m.AccountStatusID != AccountStatusCodes.Closed &&
                        m.AvailedServices.Any(a => a.ServiceID == ServiceCodes.DeathAidFund) &&
                        m.DeathAidFund.CurrentBalance >= dafType.PerMemberAid)
                    .Select(x => new DeathAidFundWithdrawalAssessmentItem()
                    {
                        Member = x.LastName + ", " + x.FirstName,
                        Balance = x.DeathAidFund.CurrentBalance,
                        ConsumableAmount = dafType.PerMemberAid
                    })
                    .OrderBy(x => x.Member)
                    .ToList();

                _view.WithdrawAmount = _items.Sum(x => x.ConsumableAmount);
                _view.IsAssessed = true;
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
