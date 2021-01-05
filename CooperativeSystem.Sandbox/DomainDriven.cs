using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Sandbox
{
    public class DomainDriven
    {
        public static bool ShouldNotHaveAgregateRoot()
        {
            var sdr = new SavingsDepositReceipt();
            sdr.Amount = 200;

            //var savingsDeposit = new SavingsDeposit();
            //savingsDeposit.SavingsDepositReceipts.Add(new SavingsDepositReceipt()
            //{
            //    Amount = 100,
            //    CashReceipt = new CashReceipt()
            //    {
            //        OfficialReceiptNumber = "R00000454",
            //        UserID = "admin",
            //        ReceiptDate = DateTime.Today,
            //        MemberID = 1
            //    }
            //});

            return true;
        }

    }
}
