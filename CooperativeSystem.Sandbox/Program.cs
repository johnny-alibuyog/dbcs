using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace CooperativeSystem.Sandbox
{
    class Program
    {
        public event EventHandler handler;

        static void Main(string[] args)
        {
            DomainDriven.ShouldNotHaveAgregateRoot();
            //var repository = new DividendRepository();
            //var dividendComputations = repository.ComputeMemberDividends(2009, 48000M);

            //foreach (var dividendComputation in dividendComputations)
            //{
            //    Console.WriteLine("Member: " + dividendComputation.Member);
            //    Console.WriteLine("Total Dividend for Distribution: " + dividendComputation.TotalDividendForDistribution.Value.ToString("N2"));
            //    Console.WriteLine("Total Average Share: " + dividendComputation.TotalAverageShare.Value.ToString("N2"));
            //    Console.WriteLine("Average Share: " + dividendComputation.AverageShare.Value.ToString("N2"));
            //    Console.WriteLine("Dividend: " + dividendComputation.Dividend.Value.ToString("N2"));
            //    var format = "{0} {1} {2} {3} {4}\n";
            //    Console.WriteLine(string.Format(format, "Date      ", "Amount Received", "Balance    ", "Peso Value    ", "Days Unchanged"));
            //    Console.WriteLine(string.Format(format, "==========", "===============", "===========", "==============", "=============="));

            //    foreach (var shareItem in dividendComputation.DividendShareItems)
            //    {
            //        Console.WriteLine(string.Format(format, 
            //            shareItem.Date.ToShortDateString().PadLeft(10),
            //            shareItem.AmountReceived.ToString("N2").PadLeft(15),
            //            shareItem.Balance.ToString("N2").PadLeft(11),
            //            shareItem.PesoValue.ToString("N2").PadLeft(14),
            //            shareItem.NumberOfDaysUnchanged.ToString().PadLeft(14)));
            //    }
            //}

            //Console.WriteLine();
            //Console.WriteLine("Total Dividend Distributed: " + dividendComputations.Sum(dc => dc.Dividend));
            //Console.Read();
        }
    }
}
