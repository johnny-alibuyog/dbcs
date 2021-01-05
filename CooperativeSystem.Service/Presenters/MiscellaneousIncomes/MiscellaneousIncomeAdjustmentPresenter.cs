using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Utilities.SequenceGenerators;

namespace CooperativeSystem.Service.Presenters.MiscellaneousIncomes
{
    public class MiscellaneousIncomeAdjustmentPresenter : PresenterTemplate
    {
        #region Fields

        // presistence
        private DataContext _db;
        private IRepository<MiscellaneousIncomeAdjustment> _adjustmentRepository;
        private IRepository<MiscellaneousIncomeReceipt> _receiptRepository;

        // views
        private IMiscellaneousIncomeAdjustmentView _view;

        // object graphs
        private MiscellaneousIncomeAdjustment _adjustment;
        //private MiscellaneousIncomeReceipt _receipt;
        
        // voucher generator
        private AdjustmentVoucherGenerator _voucherGenerator;

        #endregion

        #region Routine Helpers

        private void InitializePersistenceManager()
        {
            _db = new DataContextFactory().CreateDataContext();
            _adjustmentRepository = new GenericRepository<MiscellaneousIncomeAdjustment>(_db);
            _receiptRepository = new GenericRepository<MiscellaneousIncomeReceipt>(_db);
            _voucherGenerator = new AdjustmentVoucherGenerator(_db);
        }

        private void InitializeViewDisplayFields()
        {
            // receipt 
            _view.VoucherNumber = _voucherGenerator.Generate();

            _view.Amount = 0M;
            _view.Remarks = string.Empty;
            _view.IsThereAdjustment = false;
        }

       #endregion

        public MiscellaneousIncomeAdjustmentPresenter(IMiscellaneousIncomeAdjustmentView view)
        {
            _view = view;
        }

        public bool Clear()
        {
            InitializePersistenceManager();
            InitializeViewDisplayFields();
            return true;
        }

        public bool Load()
        {
            InitializePersistenceManager();
            InitializeViewDisplayFields();
            return true;
        }

        //public bool LoadReceipt(long receiptID)
        //{
        //    try
        //    {
        //        _view.IsLoadingDetails = true;

        //        _receiptRepository = new GenericRepository<MiscellaneousIncomeReceipt>(_db);
        //        _receipt = _receiptRepository.GetEntity(r => r.CashReceipt.ReceiptID == receiptID);
        //        if (_receipt == null)
        //        {
        //            RaiseErrorEvent("Receipt number does not exist. Please verify.");
        //            return false;
        //        }

        //        _view.Amount = _receipt.Amount;
        //        _view.Remarks = _receipt.Remarks;

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        RaiseErrorEvent(ex.Message, ex);
        //        return false;
        //    }
        //    finally
        //    {
        //        _view.IsLoadingDetails = false;
        //    }
        //}

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

        public bool Accept()
        {
            //using (var transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
            //{
            try
            {
                //if (_view.Amount == _receipt.Amount)
                //{
                //    RaiseErrorEvent("No adjustment has been made.");
                //    return false;
                //}

                // create adjustment
                _adjustment = _adjustmentRepository.CreateEntity();
                _adjustment.Amount = _view.Amount;
                _adjustment.Adjustment = new Adjustment()
                {
                    UserID = _view.UserID,
                    AdjustmentDate = _view.AdjustmentDate,
                    AdjustmentJournalVoucher = _view.VoucherNumber,
                };

                _adjustmentRepository.SaveAll();
                _receiptRepository.SaveAll();
                RaiseSusccessEvent("Successful.");
                return true;
            }
            catch (Exception ex)
            {
                //Transaction.Current.Rollback();
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
            //}
        }

    }
}
