using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Utilities.SequenceGenerators
{
    internal class CashReceiptNumberGenerator : GeneratorTemplate
    {
        public CashReceiptNumberGenerator(DataContext db)
            : base(db, "R") { }

        #region GeneratorTemplate Members

        public override bool ValidateSequence(string reference, out string remarks)
        {
            remarks = string.Empty;

            var result = 0L;
            var sequence = ParseSequence(reference);
            if (!long.TryParse(sequence, out result))
            {
                remarks = "Receipt should be numeric.";
                return false;
            }

            var exists = _db.GetTable<CashReceipt>()
                .Where(cd => cd.OfficialReceiptNumber == reference)
                .Any();

            if (exists)
            {
                remarks = "Receipt already exist. Please select another.";
                return false;
            }

            return true;
        }

        public override string Generate()
        {
            // search for the maximum reciept number used
            var latestCashReceipt = _db.GetTable<CashReceipt>()
                .OrderByDescending(cr => cr.ReceiptID)
                .FirstOrDefault();

            var latesReceipt = (latestCashReceipt != null) 
                ? latestCashReceipt.OfficialReceiptNumber
                : GetInitial();

            // generate voucher
            var remarks = string.Empty;
            var reference = GetNext(latesReceipt);
            if (!ValidateSequence(reference, out remarks))
            {
                var maxReceipt = _db.GetTable<CashReceipt>()
                    .Max(x => x.OfficialReceiptNumber);

                reference = GetNext(maxReceipt);
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
