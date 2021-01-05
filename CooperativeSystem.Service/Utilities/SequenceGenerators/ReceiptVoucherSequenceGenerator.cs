using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters
{
    internal class ReceiptVoucherSequenceGenerator
    {
        private DataContext _db;

        public ReceiptVoucherSequenceGenerator()
        {
            _db = new DataContextFactory().CreateDataContext();
        }

        public string GenerateVoucherNumber()
        {
            var result = string.Empty;
            var dateSequence = DateTime.Now.ToString("yyMM");
            var sequenceNumber = 1;

            // search for the maximum voucher number used for the current month
            var maxVoucher = _db.GetTable<CashDisbursement>()
                .Where(cd => cd.CashDisbursementVoucher.StartsWith(dateSequence))
                .Max(cd => cd.CashDisbursementVoucher);

            if (!string.IsNullOrEmpty(maxVoucher))
            {
                // generate voucher number based on the maximum used for the current month
                string[] parts = maxVoucher.Split('-');
                int currentSequenceNumber = 0;
                if (parts.Count() > 1)
                {
                    int.TryParse(parts[1], out currentSequenceNumber);
                    sequenceNumber = currentSequenceNumber + 1;
                }
            }

            result = string.Format("{0}-{1}", dateSequence, sequenceNumber.ToString().PadLeft(4, '0'));
            return result;
        }

        public string GenerateReceiptNumber()
        {
            var result = string.Empty;
            var dateSequence = DateTime.Now.ToString("yyMM");
            var sequenceNumber = 1;

            // search for the maximum voucher number used for the current month
            var maxReceipt = _db.GetTable<CashReceipt>()
                .Where(cd => cd.OfficialReceiptNumber.StartsWith(dateSequence))
                .Max(cd => cd.OfficialReceiptNumber);

            if (!string.IsNullOrEmpty(maxReceipt))
            {
                // generate voucher number based on the maximum used for the current month
                string[] parts = maxReceipt.Split('-');
                int currentSequenceNumber = 0;
                if (parts.Count() > 1)
                {
                    int.TryParse(parts[1], out currentSequenceNumber);
                    sequenceNumber = currentSequenceNumber + 1;
                }
            }

            result = string.Format("{0}-{1}", dateSequence, sequenceNumber.ToString().PadLeft(4, '0'));
            return result;
        }
    }
}
