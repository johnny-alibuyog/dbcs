using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.SexTypes;

namespace CooperativeSystem.Service.Presenters.Reports.Notices
{
    public class NoticeReportPresenter : PresenterTemplate
    {
        private readonly INoticeReportView _view;

        public NoticeReportPresenter(INoticeReportView view)
        {
            _view = view;
            _view.NoticeTypes = NoticeType.All;
        }

        public virtual bool PopulateReport()
        {
            try
            {
                var items = new List<NoticeReportItem>();

                using (var db = new DataContextFactory().CreateDataContext())
                {
                    var loadOptions = new DataLoadOptions();
                    loadOptions.LoadWith<Loan>(x => x.Member);
                    loadOptions.LoadWith<Loan>(x => x.LoanReceipts);
                    loadOptions.LoadWith<Loan>(x => x.LoanAdjustments);
                    loadOptions.LoadWith<Loan>(x => x.LoanDividendAdjustments);
                    loadOptions.LoadWith<LoanReceipt>(x => x.CashReceipt);
                    loadOptions.LoadWith<LoanDividendAdjustment>(x => x.Adjustment);

                    db.LoadOptions = loadOptions;

                    var application = db.GetTable<Application>().FirstOrDefault();
                    var fineComputationRate = db.GetTable<FineComputationRate>().FirstOrDefault();

                    var agedLoanQuery = db.GetTable<Loan>()
                        .Where(x =>
                            x.Settled == false &&
                            x.NextPaymentDate.Value < DateTime.Today
                        );

                    foreach (var loan in agedLoanQuery)
                    {
                        var previousNotice = (LoanNotice)null;
                        var notice = (LoanNotice)null;

                        if (_view.SelectedNoticeType == NoticeType.FirstNotice)
                        {
                            if (loan.LoanNotices.Count == 0)
                            {
                                notice = CreateNotice(application, fineComputationRate, loan, previousNotice, notice);
                            }
                            else
                            {
                                notice = loan.LoanNotices.FirstOrDefault();
                            }
                        }
                        else if (_view.SelectedNoticeType == NoticeType.SecondNotice)
                        {
                            if (loan.LoanNotices.Count < 1)
                            {
                                continue;
                            }
                            else if (loan.LoanNotices.Count == 1)
                            {
                                previousNotice = loan.LoanNotices[_view.SelectedNoticeType.Number - 2];
                                notice = CreateNotice(application, fineComputationRate, loan, previousNotice, notice);
                            }
                            else
                            {
                                previousNotice = loan.LoanNotices[_view.SelectedNoticeType.Number - 2];
                                notice = loan.LoanNotices[_view.SelectedNoticeType.Number - 1];
                            }
                        }
                        else if (_view.SelectedNoticeType == NoticeType.FinalNotice)
                        {
                            if (loan.LoanNotices.Count < 2)
                            {
                                continue;
                            }
                            else if (loan.LoanNotices.Count == 2)
                            {
                                previousNotice = loan.LoanNotices[_view.SelectedNoticeType.Number - 2];
                                notice = CreateNotice(application, fineComputationRate, loan, previousNotice, notice);
                            }
                            else
                            {
                                previousNotice = loan.LoanNotices[_view.SelectedNoticeType.Number - 2];
                                notice = loan.LoanNotices[_view.SelectedNoticeType.Number - 1];
                            }
                        }

                        items.Add(new NoticeReportItem(notice));
                    }

                    db.SubmitChanges();
                }

                _view.PopulateReports(items);

                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }

        }

        private LoanNotice CreateNotice(Application application, FineComputationRate fineComputationRate, Loan loan, LoanNotice previousNotice, LoanNotice notice)
        {
            if (notice == null)
            {
                notice = new LoanNotice()
                {
                    PreviousIssueDate = previousNotice != null ? previousNotice.IssueDate : null,
                    IssueDate = DateTime.Today,
                    IssueAddress = loan.Member.Address,
                    IssueTo = loan.Member.FirstName + " " + loan.Member.LastName,
                    LoanDate = loan.LoanDate,
                    DueDate = loan.NextPaymentDate,
                    AmountDue = loan.GetCurrentPayableAmount(),
                    Fine = loan.ComputeDelayedPaymentFine(fineComputationRate),
                    Charge = loan.ComputeDelinquentCharge(fineComputationRate),
                    Manager = application.Manager,
                };

                loan.LoanNotices.Add(notice);
            }
            return notice;
        }
    }
}
