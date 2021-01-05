using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Members
{
    internal class AccountNumberGenerator
    {
        private DataContext _db;

        public AccountNumberGenerator(DataContext db)
        {
            _db = db;
        }

        public string GenerateAccountNumber()
        {
            var result = string.Empty;
            var dateSequence = DateTime.Today.ToString("yyyy-MM-dd");
            var sequenceNumber = 1;

            // search for the maximum account number used for the current month
            var maxAccountNumber = _db.GetTable<Member>()
                .Where(m => m.AccountNumber.StartsWith(dateSequence))
                .Max(m => m.AccountNumber);

            if (!string.IsNullOrEmpty(maxAccountNumber))
            {
                // generate account number based on the maximum used for the current month
                var currentSequenceNumberString = maxAccountNumber.Substring(dateSequence.Length);
                var currentSequenceNumber = 0;
                int.TryParse(currentSequenceNumberString, out currentSequenceNumber);
                sequenceNumber = currentSequenceNumber + 1;
            }

            //var padLength = 7 - sequenceNumber.ToString().Length;
            result = dateSequence + sequenceNumber.ToString().PadLeft(3, '0');
            return result;
        }    
    }
}
