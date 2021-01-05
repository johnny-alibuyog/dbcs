using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Utilities.SequenceGenerators;

namespace CooperativeSystem.Service.Presenters.MiscellaneousIncomes
{
    public class MiscellaneousIncomeCashDisbursementPresenter : PresenterTemplate
    {
        #region Fields

        // persistence
        private DataContext _db;
        private IRepository<MiscellaneousIncomeDisbursement> _repository;

        private MiscellaneousIncomeDisbursement _entity;
        private IMiscellaneousIncomeCashDisbursementView _view;

        // receipt generator
        private CashDisbursementVoucherGenerator _voucherGenerator;

        #endregion

        #region Routine Helpers

        private void InitializePersistenceManager()
        {
            // persistence
            _db = new DataContextFactory().CreateDataContext();
            _repository = new GenericRepository<MiscellaneousIncomeDisbursement>(_db);
            _voucherGenerator = new CashDisbursementVoucherGenerator(_db);

            _entity = _repository.CreateEntity();
        }

        private void InitializeViewDisplayFields()
        {
            // receipt 
            _view.VoucherNumber = _voucherGenerator.Generate();

            _view.Amount = 0M;
            _view.Remarks = string.Empty;
        }

        #endregion

        public MiscellaneousIncomeCashDisbursementPresenter(IMiscellaneousIncomeCashDisbursementView view)
        {
            _view = view;
            InitializePersistenceManager();
            InitializeViewDisplayFields();
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

        public bool Clear()
        {
            InitializePersistenceManager();
            InitializeViewDisplayFields();
            return true;
        }

        public bool Accept()
        {
            try
            {
                _entity.Amount = _view.Amount;
                _entity.Remarks = _view.Remarks;
                _entity.CashDisbursement = new CashDisbursement()
                {
                    UserID = _view.UserID,
                    DisbursementDate = _view.DisbursementDate,
                    CashDisbursementVoucher = _view.VoucherNumber
                };

                _repository.SaveAll();
                RaiseSusccessEvent("Successful.");

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
