using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters.Lookups.Services;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.ServiceFeeCalculators
{
    internal abstract class ServiceFeeCalculatorTemplate
    {
        #region Fields

        private Member _member;
        private DataContext _db;

        #endregion

        #region Properties

        protected Member Member
        {
            get { return _member; }
            set { _member = value; }
        }

        protected DataContext Db
        {
            get { return _db; }
            set { _db = value; }
        }

        #endregion

        internal abstract ServiceFees ComputeServiceFees(string paymentModeID, string loanDeductionTypeID, decimal loanAmount, int terms, ref decimal interestRate);

        public ServiceFeeCalculatorTemplate(DataContext db, Member member)
        {
            _db = db;
            _member = member;
        }
    }
}
