using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Utilities.SequenceGenerators;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.MiscellaneousIncomes
{
    public class MiscellaneousIncomeCashReceiptPresenter : PresenterTemplate
    {
        #region Fields

        // persistence
        private DataContext _db;
        private IRepository<MiscellaneousIncomeReceipt> _repository;

        private MiscellaneousIncomeReceipt _entity;
        private IMiscellaneousIncomeCashReceiptView _view;

        // receipt generator
        private CashReceiptNumberGenerator _receiptGenerator;

        #endregion

        #region Routine Helpers

        private void InitializePersistenceManager()
        {
            // persistence
            _db = new DataContextFactory().CreateDataContext();
            _repository = new GenericRepository<MiscellaneousIncomeReceipt>(_db);
            _receiptGenerator = new CashReceiptNumberGenerator(_db);

            _entity = _repository.CreateEntity();
        }

        private void InitializeViewDisplayFields()
        {
            // receipt 
            _view.ReceiptNumber = _receiptGenerator.Generate();

            _view.Amount = 0M;
            _view.Remarks = string.Empty;
        }

        #endregion

        public MiscellaneousIncomeCashReceiptPresenter(IMiscellaneousIncomeCashReceiptView view)
        {
            _view = view;
            InitializePersistenceManager();
            InitializeViewDisplayFields();
        }

        public bool GenerateReceiptNumber()
        {
            var remarks = string.Empty;
            var reciept = _receiptGenerator.Generate(_view.Sequence, out remarks);
            if (string.IsNullOrEmpty(reciept))
            {
                RaiseErrorEvent(remarks);
                return false;
            }

            _view.ReceiptNumber = reciept;
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
                _entity.CashReceipt = new CashReceipt()
                {
                    UserID = _view.UserID,
                    ReceiptDate = _view.ReceiptDate,
                    OfficialReceiptNumber = _view.ReceiptNumber
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
