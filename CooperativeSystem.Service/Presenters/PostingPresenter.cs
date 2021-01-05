using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Utilities.SequenceGenerators;
using System.Data.Linq;

namespace CooperativeSystem.Service.Presenters
{
    public class PostingPresenter : PresenterTemplate
    {
        private IPostingView _view;

        private DataContext _db;
        private AdjustmentVoucherGenerator _voucherGenerator;

        public PostingPresenter(IPostingView view)
        {
            _db = new DataContextFactory().CreateDataContext();
            _voucherGenerator = new AdjustmentVoucherGenerator(_db);

            _view = view;
            _view.VoucherNumber = _voucherGenerator.Generate();
        }

        public bool GenerateVoucherNumber()
        {
            var remarks = string.Empty;
            var voucher = _voucherGenerator.Generate(_view.Sequence, out remarks);
            if (string.IsNullOrEmpty(voucher))
            {
                RaiseErrorEvent(remarks);
                return false;
            }

            _view.VoucherNumber = voucher;
            return true;
        }
    }
}
