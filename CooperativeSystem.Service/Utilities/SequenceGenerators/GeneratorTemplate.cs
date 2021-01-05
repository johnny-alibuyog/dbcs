using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Utilities.SequenceGenerators
{
    public abstract class GeneratorTemplate
    {
        protected readonly DataContext _db;

        protected readonly string _prefix;
        protected const int SEQUENCE_LENGTH = 8;

        #region Abstract Members

        public abstract bool ValidateSequence(string sequence, out string remarks);
        public abstract string Generate();
        public abstract string Generate(string sequence, out string remarks);

        #endregion

        #region Routine Helpers

        protected virtual string IncrementSequence(string sequenceInString)
        {
            long sequence = 0L;
            var result = long.TryParse(sequenceInString, out sequence);
            if (!result)
                throw new Exception("Unable to generate new sequence. Please select another.");

            sequence++;
            return (sequence).ToString();
        }

        protected virtual string PadSequence(string sequence)
        {
            if (SEQUENCE_LENGTH > sequence.Length)
                sequence = sequence.PadLeft(SEQUENCE_LENGTH, '0');
            return sequence;
        }

        protected virtual string ParseSequence(string full)
        {
            return new string(full
                .Where(x => char.IsDigit(x))
                .ToArray());

            //return full.Replace(_prefix, string.Empty);
        }

        protected virtual string GetInitial()
        {
            var sequence = "0";
            return Format(sequence);
        }

        protected virtual string GetNext(string reference)
        {
            var sequence = ParseSequence(reference);
            var nextSquence = IncrementSequence(sequence);
            return Format(nextSquence);
        }

        protected virtual string Format(string sequence)
        {
            var paded = PadSequence(sequence);
            return _prefix + paded;
        }

        #endregion
        
        public GeneratorTemplate(DataContext db, string prefix)
        {
            _db = db;
            _prefix = prefix;
        }
    }
}
