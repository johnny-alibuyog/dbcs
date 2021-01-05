using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Presenters.Lookups.MembershipCategories;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Lookups.AccountStatuses;

namespace CooperativeSystem.Service.Presenters.SpecialFunds.TulunganFund
{
    public class TulunganFundWithdrawalAssessmentPresenter : PresenterTemplate
    {
        private ITulunganFundWithdrawalAssessmentView _view;

        public TulunganFundWithdrawalAssessmentPresenter(ITulunganFundWithdrawalAssessmentView view)
        {
            _view = view;
        }

        public bool Load()
        {
            try
            {
                var db = new DataContextFactory().CreateDataContext();
                var isEntitled = db.GetTable<Member>()
                    .Where(m =>
                        m.TulunganFund != null &&
                        m.AccountStatusID != AccountStatusCodes.Closed &&
                        m.AvailedServices.Any(a => a.ServiceID == ServiceCodes.TulunganFund))
                    .Any();

                if (!isEntitled)
                {
                    RaiseErrorEvent("You are not entitled for Tulungan Fund.");
                    return false;
                }

                var tulunganFundSetting = db.GetTable<Models.TulunganFundSetting>().Single();
                var capitalShare =  db.GetTable<CapitalShare>().Single(x => x.MemberID == _view.MemberID);
                var hasRequiredMinimumShare = capitalShare.CurrentBalance >= tulunganFundSetting.ReuiredMinimumShare;
                if (!hasRequiredMinimumShare)
                {
                    RaiseErrorEvent("You do not have the required minimun share.");
                    return false;
                }

                var amount = capitalShare.CurrentBalance < 15000
                    ? tulunganFundSetting.AwardForShareBelowFifteenThousand
                    : tulunganFundSetting.AwardForShareFifteenThousandAndAbove;

                _view.Amount = amount;
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
