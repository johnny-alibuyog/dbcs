using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Loans
{
    public class LoanSettingsPresenter : PresenterTemplate
    {
        private readonly ILoanSettingsView _view;

        public LoanSettingsPresenter(ILoanSettingsView view)
        {
            _view = view;
        }

        public bool Populate()
        {
            try
            {
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    var model = db.GetTable<LoanSetting>()
                        .FirstOrDefault();

                    if (model == null)
                    {
                        model = new LoanSetting();
                        model.RenewablePaidPercentage = 50M;
                        model.RenewablePaidPercentage = 300M;
                        model.RebateExemptedTerms = 3;
                        db.GetTable<LoanSetting>().InsertOnSubmit(model);
                        db.SubmitChanges();
                    }

                    _view.RenewablePaidRercentage = model.RenewablePaidPercentage;
                    _view.RegularLoanMaxPrecentage = model.RegularLoanMaxPrecentage;
                    _view.RebateExemptedTerms = model.RebateExemptedTerms;

                    return true;
                }
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message);
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                using (var db = new DataContextFactory().CreateDataContext())
                {
                    var model = db.GetTable<LoanSetting>()
                        .FirstOrDefault();

                    if (model == null)
                    {
                        model = new LoanSetting();
                        db.GetTable<LoanSetting>().InsertOnSubmit(model);
                    }

                    model.RenewablePaidPercentage = _view.RenewablePaidRercentage;
                    model.RegularLoanMaxPrecentage = _view.RegularLoanMaxPrecentage;
                    model.RebateExemptedTerms = _view.RebateExemptedTerms;
                    db.SubmitChanges();
                }

                RaiseSusccessEvent("Successfuly updated.");
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message);
                return false;
            }
        }
    }
}
