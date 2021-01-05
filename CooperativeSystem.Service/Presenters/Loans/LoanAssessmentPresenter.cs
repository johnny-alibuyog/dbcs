using System;
using System.Data.Linq;
using System.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Presenters.Lookups.ServiceCategories;

namespace CooperativeSystem.Service.Presenters.Loans
{
    public class LoanAssessmentPresenter : PresenterTemplate
    {
        private readonly ILoanAssessmentView _view;

        public LoanAssessmentPresenter(ILoanAssessmentView view)
        {
            _view = view;
        }

        public bool Initialize()
        {
            try
            {
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    var loanDeductionTypes = db.GetTable<LoanDeductionType>();
                    var paymentModes = db.GetTable<ServicePaymentMode>()
                        .Where(x => x.ServiceID == _view.LoanServiceID)
                        .Select(x => x.PaymentMode);

                    _view.PopulateLoanDeductionType(loanDeductionTypes.ToList());
                    _view.PopulatePaymentMode(paymentModes.ToList());
                }

                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool Assess(out string remarks)
        {
            bool result = false;
            remarks = string.Empty;
            try
            {
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    var repository = new LoanAssessmentRepository(db, _view.MemberID, _view.LoanServiceID, _view.LoanDate);

                    var assessment = repository.GetAssessment(_view.PaymentModeID, _view.LoanDeductionTypeID,
                        _view.Terms, _view.InterestRate, _view.LoanAmount, out remarks);

                    result = assessment != null;
                    if (result)
                    {
                        _view.InterestRate = assessment.InterestRate;
                        _view.Terms = assessment.Terms;
                        _view.MaximumLoanAmount = assessment.MaximumLoanAmount;
                        _view.LoanAmount = assessment.LoanAmount;
                        _view.DueDate = assessment.DueDate;
                        _view.PaymentStartDate = assessment.PaymentStartDate;
                        _view.OutstandingBalance = assessment.OutstandingBalance;
                        _view.OutstandingLoanId = assessment.OutstandngLoanId;
                        _view.ServiceFee = assessment.ServiceFee;
                        _view.CollectionFee = assessment.CollectionFee;
                        _view.CapitalBuildup = assessment.CapitalBuildup;
                        _view.LoanGuaranteeFund = assessment.LoanGuaranteeFund;
                        _view.Interest = assessment.Interest;
                        _view.Amortization = assessment.Amortization;
                        _view.NetAmountDue = assessment.NetAmountDue;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(remarks))
                            remarks = "Error in assessment occured.";
                        //OnError(remarks);
                    }
                }
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
            }
            return result;
        }

        public virtual void ViewReport()
        {
            var reportModel = new LoanAssessmentReportModel();

            using (var db = new DataContextFactory().CreateDataContext())
            {
                var member = db.GetTable<Member>().FirstOrDefault(x => x.MemberID == _view.MemberID);
                var service = db.GetTable<Models.Service>().FirstOrDefault(x => x.ServiceID == _view.LoanServiceID);
                var paymentMode = db.GetTable<Models.PaymentMode>().FirstOrDefault(x => x.PaymentModeID == _view.PaymentModeID);
                var deductionType = db.GetTable<Models.LoanDeductionType>().FirstOrDefault(x => x.LoanDeductionTypeID == _view.LoanDeductionTypeID);

                reportModel.Member = member != null ? member.FirstName + " " + member.MiddleName : string.Empty;
                reportModel.LoanService = service != null ? service.ServiceName : string.Empty;
                reportModel.PaymentMode = paymentMode != null ? paymentMode.PaymentModeName : string.Empty;
                reportModel.LoanDeductionType = deductionType != null ? deductionType.LoanDeductionTypeName : string.Empty;
                reportModel.PaymentStartDate = _view.PaymentStartDate;
                reportModel.DueDate = _view.DueDate;
                reportModel.InterestRate = _view.InterestRate;
                reportModel.Terms = _view.Terms;
                reportModel.MaximumLoanAmount = _view.MaximumLoanAmount;
                reportModel.LoanAmount = _view.LoanAmount;
                reportModel.OutstandingBalance = _view.OutstandingBalance;
                reportModel.ServiceFee = _view.ServiceFee;
                reportModel.CollectionFee = _view.CollectionFee;
                reportModel.CapitalBuildup = _view.CapitalBuildup;
                reportModel.LoanGuaranteeFund = _view.LoanGuaranteeFund;
                reportModel.Interest = _view.Interest;
                reportModel.Amortization = _view.Amortization;
                reportModel.NetAmountDue = _view.NetAmountDue;
            }

            _view.ViewReport(reportModel);
        }
    }
}
