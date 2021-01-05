using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.TimeDeposit
{
    public class TimeDepositSummaryPresenter : PresenterTemplate
    {
        private ITimeDepositSummaryView _view;

        public TimeDepositSummaryPresenter(ITimeDepositSummaryView view)
        {
            _view = view;
        }

        public bool Load(long memberID)
        {
            try
            {
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    var transactionsQuery = db.GetTable<Service.Models.TimeDeposit>()
                        .Where(x => x.MemberID == memberID)
                        .Select(x => new TimeDepositTransaction()
                        {
                            Status = x.Status,
                            DepositDate = x.DepositDate,
                            DepositAmount = x.TimeDepositAmount,
                            Terms = x.Terms,
                            InterestRate = x.InterestRate,
                            Interest = x.Interest,
                            Balance = x.CurrentBalance,
                            MaturityDate = x.MaturityDate,
                            DisbursementDate = x.ConsummationDate,
                            DisbursementAmount = x.Consumed ? x.TimeDepositAmount + x.Interest : 0,
                            Consumed = x.Consumed
                        })
                        .OrderBy(x => x.DepositDate);

                    _view.Transactions = transactionsQuery.ToList();
                }

                return true;

            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool Clear()
        {
            _view.Transactions = null;

            _view.DepositDate = null;
            _view.DepositAmount = null;
            _view.Terms = null;
            _view.InterestRate = null;
            _view.Interest = null;
            _view.MaturityDate = null;
            _view.DisbursementDate = null;
            _view.DisbursementAmount = null;

            return true;
        }

        public void DisplayTransactionDetails(TimeDepositTransaction item)
        {
            _view.DepositDate = item.DepositDate;
            _view.DepositAmount = item.DepositAmount;
            _view.Terms = item.Terms;
            _view.InterestRate = item.InterestRate;
            _view.Interest = item.Interest;
            _view.MaturityDate = item.MaturityDate;
            _view.DisbursementDate = item.DisbursementDate;
            _view.DisbursementAmount = item.DisbursementAmount;
        }
    }
}
