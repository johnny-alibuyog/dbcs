using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Utilities.SequenceGenerators
{
    internal class CashDisbursementVoucherGenerator : GeneratorTemplate
    {
        public CashDisbursementVoucherGenerator(DataContext db)
            : base(db, "D") { }

        #region GeneratorTemplate Members

        public override bool ValidateSequence(string reference, out string remarks)
        {
            remarks = string.Empty;

            var result = 0L;
            var sequence = ParseSequence(reference);
            if (!long.TryParse(sequence, out result))
            {
                remarks = "Voucher should be numeric.";
                return false;
            }

            var exists = _db.GetTable<CashDisbursement>()
                .Any(cd => cd.CashDisbursementVoucher == reference);

            if (exists)
            {
                remarks = "Voucher already exist. Please select another.";
                return false;
            }
            
            return true;
        }

        public override string Generate()
        {
            // search for the recently used voucher number used
            var latestCashDisbursement = _db.GetTable<CashDisbursement>()
                .OrderByDescending(cd => cd.DisbursementID)
                .FirstOrDefault();

            var latestVoucher = (latestCashDisbursement != null)
                ? latestCashDisbursement.CashDisbursementVoucher
                : GetInitial();

            // generate voucher
            var remarks = string.Empty;
            var reference = GetNext(latestVoucher);
            if (!ValidateSequence(reference, out remarks))
            {
                var maxVoucher = _db.GetTable<CashDisbursement>()
                    .Max(x => x.CashDisbursementVoucher);

                reference = GetNext(maxVoucher);
            }

            return reference;
        }

        public override string Generate(string sequence, out string remarks)
        {
            remarks = string.Empty;
            var reference = Format(sequence);
            if (!ValidateSequence(reference, out remarks))
                return null;

            return reference;
        }

        #endregion
    }
}
