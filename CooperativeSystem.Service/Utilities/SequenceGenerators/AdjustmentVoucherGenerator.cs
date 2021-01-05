using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Utilities.SequenceGenerators
{
    public class AdjustmentVoucherGenerator : GeneratorTemplate
    {
        private readonly string _currentYear;

        public AdjustmentVoucherGenerator(DataContext db)
            : base(db, "A")
        {
            _currentYear = DateTime.Today.Year.ToString();
        }


        #region Routine Helpers

        protected override string IncrementSequence(string sequenceInString)
        {
            long sequence = 0L;
            var result = long.TryParse(sequenceInString, out sequence);
            if (!result)
                throw new Exception("Unable to generate new sequence. Please select another.");

            sequence++;
            return (sequence).ToString();
        }

        protected override string PadSequence(string sequence)
        {
            var allowableLegnth = SEQUENCE_LENGTH - _currentYear.Length;
            var length = sequence.Length;

            if (length > allowableLegnth)
                sequence = sequence.Substring(length - allowableLegnth);

            sequence = sequence.PadLeft(allowableLegnth, '0');

            return sequence;
        }

        protected override string ParseSequence(string full)
        {
            var allowableLegnth = SEQUENCE_LENGTH - _currentYear.Length;
            var fullLength = full.Length;

            if (fullLength > allowableLegnth)
                return full.Substring(fullLength - allowableLegnth);

            return full;
        }

        protected virtual string ParseYear(string reference)
        {
            var start = _prefix.Length;
            var length = _currentYear.Length;
            return reference.Substring(start, length);
        }

        protected override string GetInitial()
        {
            var sequence = "0";
            return Format(sequence);
        }

        protected override string GetNext(string reference)
        {
            var year = ParseYear(reference);
            var sequence = string.Empty;
            if (_currentYear == year)
                sequence = ParseSequence(reference);
            else
                sequence = "0";

            var nextSquence = IncrementSequence(sequence);
            return Format(nextSquence);
        }

        protected override string Format(string sequence)
        {
            var padded = PadSequence(sequence);
            return _prefix + _currentYear + padded;
        }


        #endregion

        #region GeneratorTemplate Members

        public override bool ValidateSequence(string reference, out string remarks)
        {
            remarks = string.Empty;

            var result = 0L;
            var sequence = ParseSequence(reference);
            if (!long.TryParse(sequence, out result))
            {
                remarks = "Adjustment should be numeric.";
                return false;
            }

            var exists = _db.GetTable<Adjustment>()
                .Where(a => a.AdjustmentJournalVoucher == reference)
                .Any();

            if (exists)
            {
                remarks = "Adjustment already exist. Please select another.";
                return false;
            }

            return true;
        }

        public override string Generate()
        {
            // search for the recently used voucher number used
            var latestAdjustment = _db.GetTable<Adjustment>()
                .OrderByDescending(a => a.AdjustmentID)
                .FirstOrDefault();

            var latestVoucher = (latestAdjustment != null)
                ? latestAdjustment.AdjustmentJournalVoucher
                : GetInitial();

            // generate voucher
            var remarks = string.Empty;
            var reference = GetNext(latestVoucher);
            if (!ValidateSequence(reference, out remarks))
            {
                var maxVoucher = _db.GetTable<Adjustment>()
                    .Max(x => x.AdjustmentJournalVoucher);

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
