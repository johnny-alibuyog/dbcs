using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.MaxLoanAmountCalculators
{
    internal abstract class MaxLoanAmountCalculatorTemplate
    {
        #region Fields

        private Member _member;
        private DataContext _db;

        #endregion

        #region Properties

        protected Member Member
        {
            get { return _member; }
        }

        protected DataContext Db
        {
            get { return _db; }
        }

        #endregion

        internal abstract decimal ComputeMaxLoanAmount(out string remarks);

        public MaxLoanAmountCalculatorTemplate(DataContext db, Member member)
        {
            _db = db;
            _member = member;
        }
    }
}
