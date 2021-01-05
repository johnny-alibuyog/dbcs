using System;
using System.Collections.Generic;
using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Loans.Calculators.FineCalculators
{
    interface IFineCalculator
    {
        //IList<FineDetails> ComputeFine(IList<Loan> loans);
        FineComputationRate FineComputationRate { get; set; }
        FineDetails ComputeFine(Loan loan);
    }
}
